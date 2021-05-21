using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    public partial class SSAC : Form
    {
        static EmbedIOAuthServer server;
        static SpotifyClient client;

        List<string> availability = new List<string>();
        List<string> subsection = new List<string>();
        RegionInfo albumInfo;
        RegionInfo trackInfo;

        public SSAC()
        {
            InitializeComponent();
        }

        private void SSAC_Load(object sender, EventArgs e)
        {
            txtAlbumID.Enabled = false;
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

                lblContentTitle.Text = $"Title: {album.Name}";
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in album.Artists)
                    lblAuthor.Text += $"{artist.Name}, ";

                lblAuthor.Text = lblAuthor.Text.Substring(0, lblAuthor.Text.Length - 2);
                lstAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    foreach (string s in album.AvailableMarkets)
                    {
                        albumInfo = new RegionInfo(s.ToLowerInvariant());
                        string information = $"{s} - {albumInfo.DisplayName}";
                        lstAvailability.Items.Add(information);
                        availability.Add(information);
                    }
                }
                catch (ArgumentException an)
                {
                    MessageBox.Show($"RegionInfo: {an.ParamName} caused a conversion error", "Region could occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "The information you have provided cannot be converted into an album ID\n\n" +
                        "On a Spotify album, click \"Copy Album Link\"", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Please provide a valid album URL", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex is APIUnauthorizedException)
                        MessageBox.Show("Please use a new access token as the current one has expired", "Authorization error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblContentTitle.Text = $"Title: {track.Name}";
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in track.Artists)
                    lblAuthor.Text += $"{artist.Name}, ";

                lblAuthor.Text = lblAuthor.Text.Substring(0, lblAuthor.Text.Length - 2);
                lstAvailability.Items.Clear();
                availability.Clear();

                try
                {
                    foreach (string s in track.AvailableMarkets)
                    {
                        trackInfo = new RegionInfo(s.ToLowerInvariant());
                        string information = $"{s} - {trackInfo.DisplayName}";
                        lstAvailability.Items.Add(information);
                        availability.Add(information);
                    }
                }
                catch (ArgumentException an)
                {
                    MessageBox.Show($"RegionInfo: {an.ParamName} caused a conversion error", "Region could occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lstAvailability.Items.Clear();
            foreach (string s in availability)
                lstAvailability.Items.Add(s);
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

        private void DoSearch()
        {
            if (string.IsNullOrWhiteSpace(txtSearchInput.Text))
            {
                MessageBox.Show("Enter a search term to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            subsection = availability.Where(r => r.Contains(txtSearchInput.Text)).ToList();

            lstAvailability.Items.Clear();
            foreach (string s in subsection)
                lstAvailability.Items.Add(s);
        }
    }
}
