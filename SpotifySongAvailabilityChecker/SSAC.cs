using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        List<ListViewItem> availability = new List<ListViewItem>();
        List<ListViewItem> availabilitySubsection;

        List<SearchObject> searches;
        List<SearchObject> searchSubsection;

        ListViewItem itemAvailability;
        ListViewItem itemSearch;

        RegionInfo albumInfo;
        RegionInfo trackInfo;

        SearchObject albumObj;
        SearchObject trackObj;

        string historyLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SSAC_Storage");
        bool searchActivated;

        public SSAC()
        {
            InitializeComponent();
        }

        private void SSAC_Load(object sender, EventArgs e)
        {
            txtAlbumID.Enabled = false;
            cbxSearchHistoryType.SelectedIndex = 0;
            cbxAvailabilitySearch.SelectedIndex = 0;
            VerifyStoragePath();

            try
            {
                searches = File.ReadAllLines(Path.Combine(historyLocation, "SearchHistory.json")).Select(line => JsonConvert.DeserializeObject<SearchObject>(line)).ToList();
            }
            catch
            {
                searches = new List<SearchObject>();
            }

            foreach (SearchObject obj in searches)
            {
                ListViewItem item = new ListViewItem(new string[] { obj.Title, obj.Author, obj.GetCorrectType(), obj.GetCorrectLink()});
                lvwSearchHistory.Items.Add(item);
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

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToken.Text))
            {
                MessageBox.Show("Please generate an access token by clicking \"Get Access Token\" to continue", "Missing access token", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                albumObj = new SearchObject(album.Name);
                albumObj.AlbumLink = txtAlbumID.Text;

                foreach (SimpleArtist artist in album.Artists)
                    albumObj.Author += $"{artist.Name}, ";
                albumObj.Author = albumObj.Author.Substring(0, albumObj.Author.Length - 2);

                try
                {
                    VerifyStoragePath();
                    File.AppendAllText(Path.Combine(historyLocation, "SearchHistory.json"), $"{JsonConvert.SerializeObject(albumObj)}\n");
                }
                catch (IOException io)
                {
                    MessageBox.Show(
                        "There was an error trying to create an entry in the search history file\n\n" +
                        $"Error: {io.Message}", "Search history error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ResetSearchHistory();
                searches.Add(albumObj);
                itemSearch = new ListViewItem(new string[] { albumObj.Title, albumObj.Author, albumObj.GetCorrectType(), albumObj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(itemSearch);

                txtTitle.Text = album.Name;
                rtbAuthors.Text = string.Empty;
                rtbCopyright.Text = string.Empty;

                foreach (SimpleArtist artist in album.Artists)
                    rtbAuthors.Text += $"{artist.Name}\n";

                for (int i = 0; i < album.Copyrights.Count; i++)
                    rtbCopyright.Text += i == 0 ? $"\u00A9{album.Copyrights[i].Text}\n" : $"\u2117{album.Copyrights[i].Text}\n";

                lvwAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    foreach (string s in album.AvailableMarkets)
                    {
                        albumInfo = new RegionInfo(s.ToLowerInvariant());
                        itemAvailability = new ListViewItem(new string[] { s, albumInfo.DisplayName });
                        lvwAvailability.Items.Add(itemAvailability);
                        availability.Add(itemAvailability);
                    }
                }
                catch (ArgumentException an)
                {
                    MessageBox.Show($"RegionInfo {an.ParamName} caused a conversion error", "Region error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "The information you have provided cannot be converted into an track ID\n\n" +
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
                        MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                trackObj = new SearchObject(track.Name);
                trackObj.SongLink = txtTrackID.Text;

                foreach (SimpleArtist artist in track.Artists)
                    trackObj.Author += $"{artist.Name}, ";
                trackObj.Author = trackObj.Author.Substring(0, trackObj.Author.Length - 2);

                try
                {
                    VerifyStoragePath();
                    File.AppendAllText(Path.Combine(historyLocation, "SearchHistory.json"), $"{JsonConvert.SerializeObject(trackObj)}\n");
                }
                catch (IOException io)
                {
                    MessageBox.Show(
                        "There was an error trying to create an entry in the search history file\n\n" +
                        $"Error: {io.Message}", "Search history error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ResetSearchHistory();
                searches.Add(trackObj);
                itemSearch = new ListViewItem(new string[] { trackObj.Title, trackObj.Author, trackObj.GetCorrectType(), trackObj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(itemSearch);

                txtTitle.Text = track.Name;
                rtbAuthors.Text = string.Empty;
                rtbCopyright.Text = "N/A (Only available on albums)";

                txtTitle.Text = track.Name;

                foreach (SimpleArtist artist in track.Artists)
                    rtbAuthors.Text += $"{artist.Name}\n";

                lvwAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    foreach (string s in track.AvailableMarkets)
                    {
                        trackInfo = new RegionInfo(s.ToLowerInvariant());
                        itemAvailability = new ListViewItem(new string[] { s, trackInfo.DisplayName });
                        lvwAvailability.Items.Add(itemAvailability);
                        availability.Add(itemAvailability);
                    }
                }
                catch (ArgumentException an)
                {
                    MessageBox.Show($"RegionInfo: {an.ParamName} caused a conversion error", "Region error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DoSearch();   
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

            DoSearch();

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
                $"Error Message: {error}\n\n" +
                $"State: {state}", "Authorization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchHistory.Text))
            {
                MessageBox.Show("Enter a search term to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            searchActivated = true;
            lvwSearchHistory.Items.Clear();
            switch (cbxSearchHistoryType.SelectedIndex)
            {
                case 0:
                    searchSubsection = searches.Where(r => r.Title.Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 1:
                    searchSubsection = searches.Where(r => r.Author.Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 2:
                    searchSubsection = searches.Where(r => r.GetCorrectType().Contains(txtSearchHistory.Text)).ToList();
                    break;
                case 3:
                    searchSubsection = searches.Where(r => r.GetCorrectLink().Contains(txtSearchHistory.Text)).ToList();
                    break;
            }

            foreach (SearchObject obj in searchSubsection)
            {
                ListViewItem item = new ListViewItem(new string[] { obj.Title, obj.Author, obj.GetCorrectType(), obj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(item);
            }
        }

        private void btnResetHistorySearch_Click(object sender, EventArgs e)
        {
            ResetSearchHistory();
        }


        private void DoSearch()
        {
            if (string.IsNullOrWhiteSpace(txtSearchInput.Text))
            {
                MessageBox.Show("Enter a search term to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            availabilitySubsection = availability.Where(r => r.SubItems[cbxAvailabilitySearch.SelectedIndex].Text.Contains(txtSearchInput.Text)).ToList();

            lvwAvailability.Items.Clear();
            foreach (ListViewItem item in availabilitySubsection)
                lvwAvailability.Items.Add(item);
        }

        private void VerifyStoragePath()
        {
            if (!Directory.Exists(historyLocation))
                Directory.CreateDirectory(historyLocation);

            if (!File.Exists(Path.Combine(historyLocation, "SearchHistory.json")))
                File.Create(Path.Combine(historyLocation, "SearchHistory.json"));
        }

        private void ResetSearchHistory()
        {
            searchActivated = false;
            lvwSearchHistory.Items.Clear();
            foreach (SearchObject obj in searches)
            {
                ListViewItem item = new ListViewItem(new string[] { obj.Title, obj.Author, obj.GetCorrectType(), obj.GetCorrectLink() });
                lvwSearchHistory.Items.Add(item);
            }
        }
    }
}
