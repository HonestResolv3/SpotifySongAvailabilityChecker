using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    public partial class SSAC : Form
    {
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
                MessageBox.Show("Please enter in a token to continue", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                    album = client.Albums.Get(id).Result;
                }
                catch
                {
                    MessageBox.Show("Please provide a valid album URL", "Album ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblContentTitle.Text = string.Concat("Title: ", album.Name);
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in album.Artists)
                    lblAuthor.Text += string.Concat(artist.Name, ", ");
                lblAuthor.Text = lblAuthor.Text.Substring(0, lblAuthor.Text.Length - 2);

                lstAvailability.Items.Clear();
                foreach (string s in album.AvailableMarkets)
                {
                    try
                    {
                        albumInfo = new RegionInfo(s.ToLowerInvariant());
                        string information = string.Concat(s, " - ", albumInfo.DisplayName);
                        lstAvailability.Items.Add(information);
                        availability.Add(information);
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
                    track = client.Tracks.Get(id).Result;
                }
                catch
                {
                    MessageBox.Show("Please provide a valid track URL", "Track URL error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblContentTitle.Text = string.Concat("Title: ", track.Name);
                lblAuthor.Text = "Artists: ";

                foreach (SimpleArtist artist in track.Artists)
                    lblAuthor.Text += string.Concat(artist.Name, ", ");
                lblAuthor.Text = lblAuthor.Text.Substring(0, lblAuthor.Text.Length - 2);

                lstAvailability.Items.Clear();
                availability.Clear();
                foreach (string s in track.AvailableMarkets)
                {
                    try
                    {
                        trackInfo = new RegionInfo(s.ToLowerInvariant());
                        string information = string.Concat(s, " - ", trackInfo.DisplayName);
                        lstAvailability.Items.Add(information);
                        availability.Add(information);
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

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstAvailability.Items.Clear();
            foreach (string s in availability)
                lstAvailability.Items.Add(s);
        }
    }
}
