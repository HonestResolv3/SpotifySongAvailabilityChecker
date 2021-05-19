
namespace SpotifySongAvailabilityChecker
{
    partial class SSAC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAvailability = new System.Windows.Forms.ListBox();
            this.txtTrackID = new System.Windows.Forms.TextBox();
            this.lblTrackID = new System.Windows.Forms.Label();
            this.txtAlbumID = new System.Windows.Forms.TextBox();
            this.lblAlbumID = new System.Windows.Forms.Label();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.chkIsAlbum = new System.Windows.Forms.CheckBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblContentTitle = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblToken = new System.Windows.Forms.Label();
            this.btnToken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAvailability
            // 
            this.lstAvailability.FormattingEnabled = true;
            this.lstAvailability.Location = new System.Drawing.Point(405, 18);
            this.lstAvailability.MaximumSize = new System.Drawing.Size(238, 238);
            this.lstAvailability.MinimumSize = new System.Drawing.Size(238, 238);
            this.lstAvailability.Name = "lstAvailability";
            this.lstAvailability.Size = new System.Drawing.Size(238, 238);
            this.lstAvailability.TabIndex = 2;
            // 
            // txtTrackID
            // 
            this.txtTrackID.Location = new System.Drawing.Point(77, 22);
            this.txtTrackID.Name = "txtTrackID";
            this.txtTrackID.Size = new System.Drawing.Size(322, 20);
            this.txtTrackID.TabIndex = 4;
            // 
            // lblTrackID
            // 
            this.lblTrackID.AutoSize = true;
            this.lblTrackID.Location = new System.Drawing.Point(8, 25);
            this.lblTrackID.Name = "lblTrackID";
            this.lblTrackID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackID.TabIndex = 3;
            this.lblTrackID.Text = "Track URL:";
            // 
            // txtAlbumID
            // 
            this.txtAlbumID.Location = new System.Drawing.Point(77, 50);
            this.txtAlbumID.Name = "txtAlbumID";
            this.txtAlbumID.Size = new System.Drawing.Size(322, 20);
            this.txtAlbumID.TabIndex = 6;
            // 
            // lblAlbumID
            // 
            this.lblAlbumID.AutoSize = true;
            this.lblAlbumID.Location = new System.Drawing.Point(8, 53);
            this.lblAlbumID.Name = "lblAlbumID";
            this.lblAlbumID.Size = new System.Drawing.Size(64, 13);
            this.lblAlbumID.TabIndex = 5;
            this.lblAlbumID.Text = "Album URL:";
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(86, 226);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(112, 23);
            this.btnCheckAvailability.TabIndex = 7;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // chkIsAlbum
            // 
            this.chkIsAlbum.AutoSize = true;
            this.chkIsAlbum.Location = new System.Drawing.Point(11, 112);
            this.chkIsAlbum.Name = "chkIsAlbum";
            this.chkIsAlbum.Size = new System.Drawing.Size(72, 17);
            this.chkIsAlbum.TabIndex = 8;
            this.chkIsAlbum.Text = "Is Album?";
            this.chkIsAlbum.UseVisualStyleBackColor = true;
            this.chkIsAlbum.CheckedChanged += new System.EventHandler(this.chkIsAlbum_CheckedChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(82, 183);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(234, 35);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Authors: ";
            // 
            // lblContentTitle
            // 
            this.lblContentTitle.Location = new System.Drawing.Point(82, 145);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(234, 38);
            this.lblContentTitle.TabIndex = 10;
            this.lblContentTitle.Text = "Title: ";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(94, 78);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(305, 20);
            this.txtToken.TabIndex = 13;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(8, 81);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(79, 13);
            this.lblToken.TabIndex = 12;
            this.lblToken.Text = "Access Token:";
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(204, 226);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(112, 23);
            this.btnToken.TabIndex = 17;
            this.btnToken.Text = "Get Access Token";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // SSAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 266);
            this.Controls.Add(this.btnToken);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblContentTitle);
            this.Controls.Add(this.chkIsAlbum);
            this.Controls.Add(this.btnCheckAvailability);
            this.Controls.Add(this.txtAlbumID);
            this.Controls.Add(this.lblAlbumID);
            this.Controls.Add(this.txtTrackID);
            this.Controls.Add(this.lblTrackID);
            this.Controls.Add(this.lstAvailability);
            this.Name = "SSAC";
            this.Text = "Spotify Song Availability Checker";
            this.Load += new System.EventHandler(this.SSAC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstAvailability;
        private System.Windows.Forms.TextBox txtTrackID;
        private System.Windows.Forms.Label lblTrackID;
        private System.Windows.Forms.TextBox txtAlbumID;
        private System.Windows.Forms.Label lblAlbumID;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.CheckBox chkIsAlbum;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblContentTitle;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Button btnToken;
    }
}

