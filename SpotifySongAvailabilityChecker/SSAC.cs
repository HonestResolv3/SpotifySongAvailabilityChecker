using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    public partial class SSAC : Form
    {
        static SpotifyClient client;
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
            /*if (client == null)
            {
                MessageBox.Show("You need to get an access token by \"Get Token\" to continue", "No token provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            try
            {
                client = new SpotifyClient(txtToken.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (chkIsAlbum.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtAlbumID.Text))
                {
                    MessageBox.Show("Please enter in an album ID to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FullAlbum album;
                try
                {
                    album = client.Albums.Get(txtAlbumID.Text).Result;
                }
                catch
                {
                    MessageBox.Show("Please provide a valid Album ID", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblContentTitle.Text = string.Concat("Title: ", album.Name);
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in album.Artists)
                    lblAuthor.Text += string.Concat(artist.Name, ", ");

                lstAvailability.Items.Clear();
                foreach (string s in album.AvailableMarkets)
                {
                    try
                    {
                        albumInfo = new RegionInfo(s.ToLowerInvariant());
                        lstAvailability.Items.Add(string.Concat(s, " - ", albumInfo.DisplayName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTrackID.Text))
                {
                    MessageBox.Show("Please enter in a track ID to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FullTrack track;
                try
                {
                    track = client.Tracks.Get(txtTrackID.Text).Result;
                }
                catch
                {
                    MessageBox.Show("Please provide a valid Track ID", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblContentTitle.Text = string.Concat("Title: ", track.Name);
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in track.Artists)
                    lblAuthor.Text += string.Concat(artist.Name, ", ");

                lstAvailability.Items.Clear();
                foreach (string s in track.AvailableMarkets)
                {
                    try
                    {
                        trackInfo = new RegionInfo(s.ToLowerInvariant());
                        lstAvailability.Items.Add(string.Concat(s, " - ", trackInfo.DisplayName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnToken_Click(object sender, EventArgs e)
        {
            LoginRequest request = new LoginRequest(new Uri("https://webpages.uncc.edu/hquresh1/SpotifyRedirect/callback/"), "4f8281c491f244d0a4b2058dbb4587a6", LoginRequest.ResponseType.Token);
            Uri requestUri = request.ToUri();
            BrowserUtil.Open(requestUri);
        }

        /**
         * Credit to Brock Allen for finding this hack how to make URL's load cross-platform
         * URL here: https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
         */
        private void runUrlLoad(string Url)
        {
            try
            {
                Process.Start(Url);
            }
            catch
            {
                // This area checks the platform the program is running on and then starts a new process with the URL and with different commands depending on the system
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Url = Url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {Url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    Process.Start("xdg-open", Url);
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    Process.Start("open", Url);
                else
                    throw;
            }
        }
    }
}
