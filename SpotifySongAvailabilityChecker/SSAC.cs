using Newtonsoft.Json;
using RESTCountries.Models;
using RESTCountries.Services;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    public partial class SSAC : Form
    {
        static EmbedIOAuthServer server;
        static SpotifyClient client;
    
        readonly List<ListViewItem> availability = new List<ListViewItem>();
        List<ListViewItem> availabilitySubsection;

        List<SearchObject> searches = new List<SearchObject>();
        List<SearchObject> searchSubsection;

        List<Country> countries;

        ListViewItem itemAvailability;
        ListViewItem itemSearch;

        Country albumCountry;
        Country trackCountry;

        SearchObject albumObj;
        SearchObject trackObj;

        readonly string locationForSSACContent = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SSAC_Storage");
        bool searchActivated;
        int searchSectionIndex;

        public SSAC()
        {
            InitializeComponent();
        }

        private void SSAC_Load(object sender, EventArgs e)
        {
            txtSearchInput.Text = string.Empty;

            txtAlbumID.Enabled = false;
            chkAutoSwitchTabs.Checked = true;
            chkEnableProgramResize.Checked = true;
            chkAllowColumnReorder.Checked = true;

            cbxDefSortOrder.SelectedIndex = 0;
            cbxSearchHistoryType.SelectedIndex = 0;
            cbxAvailabilitySearch.SelectedIndex = 0;

            chkAutoSwitchTabs.Checked = Properties.Settings.Default.AutoSwitchTabs;
            chkShowGridlines.Checked = Properties.Settings.Default.ShowGridlines;
            chkAllowColumnReorder.Checked = Properties.Settings.Default.AllowColumnReorder;
            chkEnableProgramResize.Checked = Properties.Settings.Default.EnableProgramResize;
            chkEnableExperiments.Checked = Properties.Settings.Default.EnableExperiments;
            chkIsAlbum.Checked = Properties.Settings.Default.SelectedAlbum;
            chkCacheCountryInfo.Checked = Properties.Settings.Default.EnableCountryCache;

            txtTrackID.Text = Properties.Settings.Default.SongLink;
            txtAlbumID.Text = Properties.Settings.Default.AlbumLink;
            txtSearchInput.Text = Properties.Settings.Default.AvailabilitySearchInput;
            txtSearchHistory.Text = Properties.Settings.Default.SearchHistoryInput;

            cbxAvailabilitySearch.SelectedIndex = Properties.Settings.Default.AvailabilitySearchBy;
            cbxSearchHistoryType.SelectedIndex = Properties.Settings.Default.SearchHistoryBy;
            cbxDefSortOrder.SelectedIndex = Properties.Settings.Default.GeneralColumnSort;

            try
            {
                if (File.Exists(Path.Combine(locationForSSACContent, "SearchHistory.json")))
                    searches = JsonConvert.DeserializeObject<List<SearchObject>>(File.ReadAllText(Path.Combine(locationForSSACContent, "SearchHistory.json")));
                else
                    searches = new List<SearchObject>();

                if (searches == null)
                    searches = new List<SearchObject>();
            }
            catch
            {
                rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] The search history file is not in the right format, attempting to delete{Environment.NewLine}{Environment.NewLine}";
                try
                {
                    File.Delete(Path.Combine(locationForSSACContent, "SearchHistory.json"));
                }
                catch (Exception ex)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to delete the search history file{Environment.NewLine}" +
                        $"Error: {ex}{Environment.NewLine}{Environment.NewLine}";
                }
            }

            if (chkCacheCountryInfo.Checked)
            {
                try
                {
                    if (!File.Exists(Path.Combine(locationForSSACContent, "CountryCache.json")))
                        File.Create(Path.Combine(locationForSSACContent, "CountryCache.json"));
                    else
                    {
                        string cache = File.ReadAllText(Path.Combine(locationForSSACContent, "CountryCache.json"));
                        countries = JsonConvert.DeserializeObject<List<Country>>(cache);
                    }
                }
                catch (IOException io)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to create or read the country cache file{Environment.NewLine}" +
                        $"Error: {io}{Environment.NewLine}{Environment.NewLine}";
                }
                catch (UnauthorizedAccessException ua)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to access the country cache file{Environment.NewLine}" +
                        $"Error: {ua}{Environment.NewLine}{Environment.NewLine}";
                }
            }

            VerifyStoragePath();

            if (searches != null)
            {
                foreach (SearchObject obj in searches)
                {
                    ListViewItem item = new ListViewItem(new string[] { obj.GetFavoriteUnicode(), obj.Title, obj.Author, obj.Type.ToString(), obj.GetCorrectLink() });
                    lvwSearchHistory.Items.Add(item);
                }
            }
        }

        private void chkIsAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAlbum.Checked)
            {
                txtAlbumID.Enabled = true;
                txtTrackID.Enabled = false;
            }
            else
            {
                txtAlbumID.Enabled = false;
                txtTrackID.Enabled = true;
            }
        }

        private async void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToken.Text))
            {
                MessageBox.Show("Please generate an access token by clicking \"Get Access Token\" to continue", "Missing access token", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (countries == null)
                countries = await RESTCountriesAPI.GetAllCountriesAsync();

            if (chkIsAlbum.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAlbumID.Text))
                {
                    MessageBox.Show("Please enter in an album URL to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string id;
                FullAlbum album;
                try
                {
                    int beginIndex = txtAlbumID.Text.LastIndexOf("/") + 1;
                    int endIndex = txtAlbumID.Text.IndexOf("?si=") - 1;
                    id = txtAlbumID.Text.Substring(beginIndex, endIndex - beginIndex + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(
                        "The information you have provided cannot be converted into an album ID\n\n" +
                        "On a Spotify album, click \"Copy Album Link\"", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    album = client.Albums.Get(id).Result;
                }
                catch (AggregateException ae)
                {
                    Exception ex = ae.GetBaseException();

                    if (ex is APIException)
                        MessageBox.Show("Please provide a valid album URL", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex is APIUnauthorizedException)
                        MessageBox.Show("Please use a new access token as the current one has expired", "Authorization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to get the album{Environment.NewLine}" +
                            $"Error: {ex}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }

                albumObj = new SearchObject(album.Name)
                {
                    AlbumLink = txtAlbumID.Text,
                    Type = Enums.ObjectType.Album,
                    IsFavorite = false
                };

                foreach (SimpleArtist artist in album.Artists)
                    albumObj.Author += $"{artist.Name}, ";
                albumObj.Author = albumObj.Author.Substring(0, albumObj.Author.Length - 2);

                try
                {
                    VerifyStoragePath();
                }
                catch (UnauthorizedAccessException ua)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to verify the storage file (Does the program have the proper permissions?){Environment.NewLine}" +
                        $"Error: {ua}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
                catch (IOException io)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] The program was not able to verify the storage properly{Environment.NewLine}" +
                        $"Error: {io}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }

                btnResetHistorySearch_Click(sender, e);
                searches.Add(albumObj);
                itemSearch = new ListViewItem(new string[] { albumObj.GetFavoriteUnicode(), albumObj.Title, albumObj.Author, albumObj.Type.ToString(), albumObj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(itemSearch);

                txtTitle.Text = album.Name;
                rtbAuthors.Text = string.Empty;
                rtbCopyright.Text = string.Empty;

                foreach (SimpleArtist artist in album.Artists)
                    rtbAuthors.Text += $"{artist.Name}\n";

                for (int i = 0; i < album.Copyrights.Count; i++)
                    rtbCopyright.Text += i == 0 ? $"\u00A9{album.Copyrights[i].Text}{Environment.NewLine}" : $"\u2117{album.Copyrights[i].Text}{Environment.NewLine}";

                lvwAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    if (album.AvailableMarkets.Count == 0)
                    {
                        cbxAvailabilitySearch.Enabled = false;
                        txtSearchInput.Text = "N/A (Song not available on any markets, choose a new song to re-enable searching)";
                        txtSearchInput.Enabled = false;
                        btnSearch.Enabled = false;
                        btnReset.Enabled = false;

                        itemAvailability = new ListViewItem(new string[] { "N/A (Song not available)", "N/A (Song not available)" });
                        lvwAvailability.Items.Add(itemAvailability);
                    }
                    else
                    {
                        cbxAvailabilitySearch.Enabled = true;
                        txtSearchInput.Text = string.Empty;
                        txtSearchInput.Enabled = true;
                        btnSearch.Enabled = true;
                        btnReset.Enabled = true;

                        foreach (string s in album.AvailableMarkets)
                        {
                            albumCountry = countries.FirstOrDefault(c => c.Alpha2Code.Equals(s));
                            itemAvailability = new ListViewItem(new string[] { s, albumCountry.Name });
                            lvwAvailability.Items.Add(itemAvailability);
                            availability.Add(itemAvailability);
                        }
                        if (chkAutoSwitchTabs.Checked)
                            tctrlMain.SelectedIndex = 0;
                    }
                }
                catch (ArgumentNullException an)
                {
                    rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] Argument \"{an.ParamName}\" caused a conversion error{Environment.NewLine}" +
                            $"Error: {an}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
                catch (Exception ex)
                {
                    rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] Exception occured{Environment.NewLine}" +
                            $"Error: {ex}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTrackID.Text))
                {
                    MessageBox.Show("Please enter in a track URL to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string id;
                FullTrack track;
                try
                {
                    int beginIndex = txtTrackID.Text.LastIndexOf("/") + 1;
                    int endIndex = txtTrackID.Text.IndexOf("?si=") - 1;
                    id = txtTrackID.Text.Substring(beginIndex, endIndex - beginIndex + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(
                        $"The information you have provided cannot be converted into an track ID{Environment.NewLine}{Environment.NewLine}" +
                        "On a Spotify album, click \"Copy Song Link\"", "Track ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    track = client.Tracks.Get(id).Result;
                }
                catch (AggregateException ae)
                {
                    Exception ex = ae.GetBaseException();

                    if (ex is APIException)
                        MessageBox.Show("Please provide a valid track URL", "Track ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex is APIUnauthorizedException)
                        MessageBox.Show("Please use a new access token as the current one has expired", "Authorization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to get the track{Environment.NewLine}" +
                            $"Error: {ex}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }

                trackObj = new SearchObject(track.Name)
                {
                    SongLink = txtTrackID.Text,
                    Type = Enums.ObjectType.Song,
                    IsFavorite = false
                };

                foreach (SimpleArtist artist in track.Artists)
                    trackObj.Author += $"{artist.Name}, ";
                trackObj.Author = trackObj.Author.Substring(0, trackObj.Author.Length - 2);

                try
                {
                    VerifyStoragePath();
                }
                catch (UnauthorizedAccessException ua)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to verify the storage file (Does the program have the proper permissions?){Environment.NewLine}" +
                        $"Error: {ua}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
                catch (IOException io)
                {
                    rtbDebugConsole.Text +=
                        $"[{DateTime.Now.ToString("HH:mm:ss tt")}] The program was not able to verify the storage properly{Environment.NewLine}" +
                        $"Error: {io}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }

                btnResetHistorySearch_Click(sender, e);
                searches.Add(trackObj);
                itemSearch = new ListViewItem(new string[] { trackObj.GetFavoriteUnicode(), trackObj.Title, trackObj.Author, trackObj.Type.ToString(), trackObj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(itemSearch);

                txtTitle.Text = track.Name;
                rtbAuthors.Text = string.Empty;
                rtbCopyright.Text = "N/A (Only available on albums)";

                txtTitle.Text = track.Name;

                foreach (SimpleArtist artist in track.Artists)
                    rtbAuthors.Text += $"{artist.Name}{Environment.NewLine}";

                lvwAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    if (track.AvailableMarkets.Count == 0)
                    {
                        cbxAvailabilitySearch.Enabled = false;
                        txtSearchInput.Text = "N/A (Song not available on any markets, choose a new song to re-enable searching)";
                        txtSearchInput.Enabled = false;
                        btnSearch.Enabled = false;
                        btnReset.Enabled = false;

                        itemAvailability = new ListViewItem(new string[] { "N/A (Song not available)", "N/A (Song not available)" });
                        lvwAvailability.Items.Add(itemAvailability);
                    }
                    else
                    {

                        cbxAvailabilitySearch.Enabled = true;
                        txtSearchInput.Text = string.Empty;
                        txtSearchInput.Enabled = true;
                        btnSearch.Enabled = true;
                        btnReset.Enabled = true;

                        foreach (string s in track.AvailableMarkets)
                        {
                            trackCountry = countries.FirstOrDefault(c => c.Alpha2Code.Equals(s));
                            itemAvailability = new ListViewItem(new string[] { s, trackCountry.Name });
                            lvwAvailability.Items.Add(itemAvailability);
                            availability.Add(itemAvailability);
                        }
                        if (chkAutoSwitchTabs.Checked)
                            tctrlMain.SelectedIndex = 0;
                    }
                }
                catch (ArgumentNullException an)
                {
                    rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] Argument \"{an.ParamName}\" caused a conversion error{Environment.NewLine}" +
                            $"Error: {an}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
                catch (Exception ex)
                {
                    rtbDebugConsole.Text +=
                            $"[{DateTime.Now.ToString("HH:mm:ss tt")}] Exception occured{Environment.NewLine}" +
                            $"Error: {ex}{Environment.NewLine}{Environment.NewLine}";
                    return;
                }
            }
        }

        private async void btnToken_Click(object sender, EventArgs e)
        {
            server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
            await server.Start();

            server.ImplictGrantReceived += OnImplicitGrantReceived;
            server.ErrorReceived += OnErrorReceived;

            LoginRequest request = new LoginRequest(server.BaseUri, "4f8281c491f244d0a4b2058dbb4587a6", LoginRequest.ResponseType.Token);
            Uri requestUri = request.ToUri();
            BrowserUtil.Open(requestUri);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchInput.Text))
            {
                MessageBox.Show("Enter a search term to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbxAvailabilitySearch.SelectedIndex == 0)
                availabilitySubsection = availability.Where(r => r.SubItems[cbxAvailabilitySearch.SelectedIndex].Text.Contains(txtSearchInput.Text.ToUpperInvariant())).ToList();
            else
                availabilitySubsection = availability.Where(r => r.SubItems[cbxAvailabilitySearch.SelectedIndex].Text.Contains(txtSearchInput.Text)).ToList();

            if (availabilitySubsection.Count == 0)
            {
                MessageBox.Show("There are no results that match", "No matching results", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lvwAvailability.Items.Clear();
            foreach (ListViewItem item in availabilitySubsection)
                lvwAvailability.Items.Add(item);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lvwAvailability.Items.Clear();
            foreach (ListViewItem item in availability)
                lvwAvailability.Items.Add(item);
        }

        private void txtSearchInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            btnSearch_Click(sender, e);
        }


        private void txtSearchHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            btnSearchHistory_Click(sender, e);
        }

        private async Task OnImplicitGrantReceived(object sender, ImplictGrantResponse response)
        {
            server.ImplictGrantReceived -= OnImplicitGrantReceived;
            await server.Stop();
            client = new SpotifyClient(response.AccessToken);
            txtToken.Invoke(new Action(() => txtToken.Text = response.AccessToken));
        }

        private async Task OnErrorReceived(object sender, string error, string state)
        {
            server.ErrorReceived -= OnErrorReceived;
            await server.Stop();
            MessageBox.Show(
                "There was an error trying to authorize your Spotify account with the program\n\n" +
                $"Error Message: {error}{Environment.NewLine}{Environment.NewLine}" +
                $"State: {state}", "Authorization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchHistory.Text) && cbxSearchHistoryType.SelectedIndex != 0)
            {
                MessageBox.Show(
                    $"Enter a search term to continue{Environment.NewLine}{Environment.NewLine}" +
                    "(Search by \"Favorites\" does not need a search term)", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (cbxSearchHistoryType.SelectedIndex)
            {
                case 0:
                    searchSubsection = searches.Where(r => r.IsFavorite).ToList();
                    break;
                case 1:
                    searchSubsection = searches.Where(r => r.Title.Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 2:
                    searchSubsection = searches.Where(r => r.Author.Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 3:
                    searchSubsection = searches.Where(r => r.Type.ToString().Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 4:
                    searchSubsection = searches.Where(r => r.GetCorrectLink().Contains(txtSearchHistory.Text)).ToList();
                    break;
            }

            if (searchSubsection.Count == 0)
            {
                MessageBox.Show("There are no results that match", "No matching results", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            searchActivated = true;
            lvwSearchHistory.Items.Clear();

            foreach (SearchObject obj in searchSubsection)
            {
                ListViewItem item = new ListViewItem(new string[] { obj.GetFavoriteUnicode(), obj.Title, obj.Author, obj.Type.ToString(), obj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(item);
            }
        }


        private void btnResetHistorySearch_Click(object sender, EventArgs e)
        {
            searchActivated = false;
            lvwSearchHistory.Items.Clear();
            if (searches != null)
            {
                foreach (SearchObject obj in searches)
                {
                    ListViewItem item = new ListViewItem(new string[] { obj.GetFavoriteUnicode(), obj.Title, obj.Author, obj.Type.ToString(), obj.GetCorrectLink() });
                    lvwSearchHistory.Items.Add(item);
                }
            }
        }

        private void btnUseSearch_Click(object sender, EventArgs e)
        {
            if (searchSectionIndex < 0 || searchSectionIndex >= lvwSearchHistory.Items.Count)
            {
                MessageBox.Show("Please select an item from the list to use (if there are any items)", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string urlToUse;
            Enums.ObjectType type;
            if (searchActivated)
            {
                urlToUse = searchSubsection[searchSectionIndex].GetCorrectLink();
                type = searchSubsection[searchSectionIndex].Type;
            }
            else
            {
                urlToUse = searches[searchSectionIndex].GetCorrectLink();
                type = searches[searchSectionIndex].Type;
            }

            switch (type)
            {
                case Enums.ObjectType.Song:
                    txtTrackID.Text = urlToUse;
                    break;
                case Enums.ObjectType.Album:
                    txtAlbumID.Text = urlToUse;
                    break;
            }

            if (chkIsAlbum.Checked && type == Enums.ObjectType.Song)
                chkIsAlbum.Checked = false;
            else if (!chkIsAlbum.Checked && type == Enums.ObjectType.Album)
                chkIsAlbum.Checked = true;

            if (!string.IsNullOrWhiteSpace(txtToken.Text))
            {
                btnCheckAvailability_Click(sender, e);
                if (chkAutoSwitchTabs.Checked)
                    tctrlMain.SelectedIndex = 0;
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            if (chkIsAlbum.Checked)
                txtAlbumID.Text = string.Empty;
            else
                txtTrackID.Text = string.Empty;
        }


        private void btnClearSearchHistory_Click(object sender, EventArgs e)
        {
            btnResetHistorySearch_Click(sender, e);
            searches.Clear();
            lvwSearchHistory.Items.Clear();
        }

        private void btnFavoriteSong_Click(object sender, EventArgs e)
        {
            if (lvwSearchHistory.Items.Count <= 0)
            {
                MessageBox.Show("There is nothing in your search history to favorite", "No history error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (searchActivated)
            {
                SearchObject obj = searchSubsection[searchSectionIndex];
                if (searches[searches.IndexOf(obj)].IsFavorite)
                {
                    searches[searches.IndexOf(obj)].IsFavorite = false;
                    lvwSearchHistory.Items[searchSectionIndex].SubItems[0].Text = string.Empty;
                    lvwSearchHistory.Items.RemoveAt(searchSectionIndex);
                    searchSubsection.Remove(obj);
                }
                else
                {
                    searches[searches.IndexOf(obj)].IsFavorite = true;
                    lvwSearchHistory.Items[searchSectionIndex].SubItems[0].Text = "\u2605";
                }
            }
            else
            {
                if (searches[searchSectionIndex].IsFavorite)
                {
                    searches[searchSectionIndex].IsFavorite = false;
                    lvwSearchHistory.Items[searchSectionIndex].SubItems[0].Text = string.Empty;
                }
                else
                {
                    searches[searchSectionIndex].IsFavorite = true;
                    lvwSearchHistory.Items[searchSectionIndex].SubItems[0].Text = "\u2605";
                }
            }
        }

        private void lvwSearchHistory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            searchSectionIndex = e.ItemIndex;
        }

        private void SSAC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.AutoSwitchTabs = chkAutoSwitchTabs.Checked;
            Properties.Settings.Default.ShowGridlines = chkShowGridlines.Checked;
            Properties.Settings.Default.AllowColumnReorder = chkAllowColumnReorder.Checked;
            Properties.Settings.Default.EnableProgramResize = chkEnableProgramResize.Checked;
            Properties.Settings.Default.EnableExperiments = chkEnableExperiments.Checked;
            Properties.Settings.Default.SongLink = txtTrackID.Text;
            Properties.Settings.Default.AlbumLink = txtAlbumID.Text;
            Properties.Settings.Default.AvailabilitySearchInput = txtSearchInput.Text;
            Properties.Settings.Default.SearchHistoryInput = txtSearchHistory.Text;
            Properties.Settings.Default.AvailabilitySearchBy = cbxAvailabilitySearch.SelectedIndex;
            Properties.Settings.Default.SearchHistoryBy = cbxSearchHistoryType.SelectedIndex;
            Properties.Settings.Default.GeneralColumnSort = cbxDefSortOrder.SelectedIndex;
            Properties.Settings.Default.SelectedAlbum = chkIsAlbum.Checked;
            Properties.Settings.Default.EnableCountryCache = chkCacheCountryInfo.Checked;
            Properties.Settings.Default.Save();

            string searchHistoryObject = JsonConvert.SerializeObject(searches, Formatting.Indented);

            try
            {
                File.WriteAllText(Path.Combine(locationForSSACContent, "SearchHistory.json"), searchHistoryObject);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"The program does not have the proper rights to save the search history at: {Path.Combine(locationForSSACContent, "SearchHistory.json")}", "Permissions error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show($"The program cannot access: {Path.Combine(locationForSSACContent, "SearchHistory.json")}", "File access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (chkCacheCountryInfo.Checked && countries != null)
            {
                string countryCache = JsonConvert.SerializeObject(countries, Formatting.Indented);
                try
                {
                    File.WriteAllText(Path.Combine(locationForSSACContent, "CountryCache.json"), countryCache);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show($"The program does not have the proper rights to save the country cache at: {Path.Combine(locationForSSACContent, "SearchHistory.json")}", "Permissions error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException)
                {
                    MessageBox.Show($"The program cannot access: {Path.Combine(locationForSSACContent, "CountryCache.json")}", "File access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkShowGridlines_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowGridlines.Checked)
            {
                lvwAvailability.GridLines = true;
                lvwSearchHistory.GridLines = true;
            }
            else
            {
                lvwAvailability.GridLines = false;
                lvwSearchHistory.GridLines = false;
            }
        }

        private void chkEnableProgramResize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableProgramResize.Checked)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                MaximizeBox = true;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                MaximizeBox = false;
            }
        }

        private void chkAllowColumnReorder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowColumnReorder.Checked)
            {
                lvwAvailability.AllowColumnReorder = true;
                lvwSearchHistory.AllowColumnReorder = true;
            }
            else
            {
                lvwAvailability.AllowColumnReorder = false;
                lvwSearchHistory.AllowColumnReorder = false;
            }
        }

        private void cbxDefSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxDefSortOrder.SelectedIndex)
            {
                case 0:
                    lvwAvailability.Sorting = SortOrder.None;
                    lvwSearchHistory.Sorting = SortOrder.None;
                    break;
                case 1:
                    lvwAvailability.Sorting = SortOrder.Ascending;
                    lvwSearchHistory.Sorting = SortOrder.Ascending;
                    break;
                case 2:
                    lvwAvailability.Sorting = SortOrder.Descending;
                    lvwSearchHistory.Sorting = SortOrder.Descending;
                    break;
            }
        }

        private void chkEnableExperiments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableExperiments.Checked)
                cbxDefSortOrder.Enabled = true;
            else
                cbxDefSortOrder.Enabled = false;
        }

        private void VerifyStoragePath()
        {
            if (!Directory.Exists(locationForSSACContent))
                _ = Directory.CreateDirectory(locationForSSACContent);

            if (!File.Exists(Path.Combine(locationForSSACContent, "SearchHistory.json")))
                _ = File.Create(Path.Combine(locationForSSACContent, "SearchHistory.json"));
        }
    }
}
