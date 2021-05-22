
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSAC));
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
            this.txtSearchInput = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tctrlMain = new System.Windows.Forms.TabControl();
            this.tpgAvailability = new System.Windows.Forms.TabPage();
            this.lvwAvailability = new System.Windows.Forms.ListView();
            this.chdrCountryCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpgSearchHistory = new System.Windows.Forms.TabPage();
            this.lvwSearchHistory = new System.Windows.Forms.ListView();
            this.chdrTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.rtbAuthors = new System.Windows.Forms.RichTextBox();
            this.rtbCopyright = new System.Windows.Forms.RichTextBox();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tctrlMain.SuspendLayout();
            this.tpgAvailability.SuspendLayout();
            this.tpgSearchHistory.SuspendLayout();
            this.gbxInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTrackID
            // 
            this.txtTrackID.Location = new System.Drawing.Point(77, 20);
            this.txtTrackID.Name = "txtTrackID";
            this.txtTrackID.Size = new System.Drawing.Size(340, 22);
            this.txtTrackID.TabIndex = 2;
            // 
            // lblTrackID
            // 
            this.lblTrackID.AutoSize = true;
            this.lblTrackID.Location = new System.Drawing.Point(8, 25);
            this.lblTrackID.Name = "lblTrackID";
            this.lblTrackID.Size = new System.Drawing.Size(61, 13);
            this.lblTrackID.TabIndex = 1;
            this.lblTrackID.Text = "Song Link:";
            // 
            // txtAlbumID
            // 
            this.txtAlbumID.Location = new System.Drawing.Point(77, 49);
            this.txtAlbumID.Name = "txtAlbumID";
            this.txtAlbumID.Size = new System.Drawing.Size(340, 22);
            this.txtAlbumID.TabIndex = 4;
            // 
            // lblAlbumID
            // 
            this.lblAlbumID.AutoSize = true;
            this.lblAlbumID.Location = new System.Drawing.Point(8, 52);
            this.lblAlbumID.Name = "lblAlbumID";
            this.lblAlbumID.Size = new System.Drawing.Size(67, 13);
            this.lblAlbumID.TabIndex = 3;
            this.lblAlbumID.Text = "Album Link:";
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(106, 319);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(112, 23);
            this.btnCheckAvailability.TabIndex = 15;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // chkIsAlbum
            // 
            this.chkIsAlbum.AutoSize = true;
            this.chkIsAlbum.Location = new System.Drawing.Point(183, 111);
            this.chkIsAlbum.Name = "chkIsAlbum";
            this.chkIsAlbum.Size = new System.Drawing.Size(75, 17);
            this.chkIsAlbum.TabIndex = 7;
            this.chkIsAlbum.Text = "Is Album?";
            this.chkIsAlbum.UseVisualStyleBackColor = true;
            this.chkIsAlbum.CheckedChanged += new System.EventHandler(this.chkIsAlbum_CheckedChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(20, 53);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(52, 19);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Authors: ";
            // 
            // lblContentTitle
            // 
            this.lblContentTitle.Location = new System.Drawing.Point(38, 23);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(33, 19);
            this.lblContentTitle.TabIndex = 9;
            this.lblContentTitle.Text = "Title: ";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(94, 77);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(323, 22);
            this.txtToken.TabIndex = 6;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(8, 80);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(77, 13);
            this.lblToken.TabIndex = 5;
            this.lblToken.Text = "Access Token:";
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(224, 319);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(112, 23);
            this.btnToken.TabIndex = 16;
            this.btnToken.Text = "Get Access Token";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // txtSearchInput
            // 
            this.txtSearchInput.Location = new System.Drawing.Point(6, 6);
            this.txtSearchInput.Name = "txtSearchInput";
            this.txtSearchInput.Size = new System.Drawing.Size(328, 22);
            this.txtSearchInput.TabIndex = 18;
            this.txtSearchInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchInput_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(340, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(417, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tctrlMain
            // 
            this.tctrlMain.Controls.Add(this.tpgAvailability);
            this.tctrlMain.Controls.Add(this.tpgSearchHistory);
            this.tctrlMain.Location = new System.Drawing.Point(445, 8);
            this.tctrlMain.Name = "tctrlMain";
            this.tctrlMain.SelectedIndex = 0;
            this.tctrlMain.Size = new System.Drawing.Size(503, 339);
            this.tctrlMain.TabIndex = 17;
            // 
            // tpgAvailability
            // 
            this.tpgAvailability.Controls.Add(this.lvwAvailability);
            this.tpgAvailability.Controls.Add(this.txtSearchInput);
            this.tpgAvailability.Controls.Add(this.btnReset);
            this.tpgAvailability.Controls.Add(this.btnSearch);
            this.tpgAvailability.Location = new System.Drawing.Point(4, 22);
            this.tpgAvailability.Name = "tpgAvailability";
            this.tpgAvailability.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAvailability.Size = new System.Drawing.Size(495, 313);
            this.tpgAvailability.TabIndex = 0;
            this.tpgAvailability.Text = "Availability";
            this.tpgAvailability.UseVisualStyleBackColor = true;
            // 
            // lvwAvailability
            // 
            this.lvwAvailability.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdrCountryCode,
            this.chdrCountry});
            this.lvwAvailability.HideSelection = false;
            this.lvwAvailability.Location = new System.Drawing.Point(6, 34);
            this.lvwAvailability.Name = "lvwAvailability";
            this.lvwAvailability.Size = new System.Drawing.Size(483, 273);
            this.lvwAvailability.TabIndex = 25;
            this.lvwAvailability.UseCompatibleStateImageBehavior = false;
            this.lvwAvailability.View = System.Windows.Forms.View.Details;
            // 
            // chdrCountryCode
            // 
            this.chdrCountryCode.Text = "Country Code";
            this.chdrCountryCode.Width = 120;
            // 
            // chdrCountry
            // 
            this.chdrCountry.Text = "Country Name";
            this.chdrCountry.Width = 360;
            // 
            // tpgSearchHistory
            // 
            this.tpgSearchHistory.Controls.Add(this.lvwSearchHistory);
            this.tpgSearchHistory.Location = new System.Drawing.Point(4, 22);
            this.tpgSearchHistory.Name = "tpgSearchHistory";
            this.tpgSearchHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSearchHistory.Size = new System.Drawing.Size(495, 313);
            this.tpgSearchHistory.TabIndex = 1;
            this.tpgSearchHistory.Text = "Search History";
            this.tpgSearchHistory.UseVisualStyleBackColor = true;
            // 
            // lvwSearchHistory
            // 
            this.lvwSearchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdrTitle,
            this.chdrAuthor,
            this.chdrType,
            this.chdrLink});
            this.lvwSearchHistory.HideSelection = false;
            this.lvwSearchHistory.Location = new System.Drawing.Point(6, 6);
            this.lvwSearchHistory.Name = "lvwSearchHistory";
            this.lvwSearchHistory.Size = new System.Drawing.Size(483, 301);
            this.lvwSearchHistory.TabIndex = 24;
            this.lvwSearchHistory.UseCompatibleStateImageBehavior = false;
            this.lvwSearchHistory.View = System.Windows.Forms.View.Details;
            // 
            // chdrTitle
            // 
            this.chdrTitle.Text = "Title";
            this.chdrTitle.Width = 120;
            // 
            // chdrAuthor
            // 
            this.chdrAuthor.Text = "Author";
            this.chdrAuthor.Width = 120;
            // 
            // chdrType
            // 
            this.chdrType.Text = "Type";
            // 
            // chdrLink
            // 
            this.chdrLink.Text = "Link";
            this.chdrLink.Width = 284;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(10, 98);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(67, 18);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "Copyright:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(78, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(339, 22);
            this.txtTitle.TabIndex = 10;
            // 
            // rtbAuthors
            // 
            this.rtbAuthors.Location = new System.Drawing.Point(78, 53);
            this.rtbAuthors.Name = "rtbAuthors";
            this.rtbAuthors.ReadOnly = true;
            this.rtbAuthors.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbAuthors.Size = new System.Drawing.Size(339, 42);
            this.rtbAuthors.TabIndex = 12;
            this.rtbAuthors.Text = "";
            // 
            // rtbCopyright
            // 
            this.rtbCopyright.Location = new System.Drawing.Point(78, 101);
            this.rtbCopyright.Name = "rtbCopyright";
            this.rtbCopyright.ReadOnly = true;
            this.rtbCopyright.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbCopyright.Size = new System.Drawing.Size(339, 42);
            this.rtbCopyright.TabIndex = 14;
            this.rtbCopyright.Text = "";
            // 
            // gbxInput
            // 
            this.gbxInput.Controls.Add(this.txtTrackID);
            this.gbxInput.Controls.Add(this.lblTrackID);
            this.gbxInput.Controls.Add(this.lblAlbumID);
            this.gbxInput.Controls.Add(this.txtAlbumID);
            this.gbxInput.Controls.Add(this.chkIsAlbum);
            this.gbxInput.Controls.Add(this.lblToken);
            this.gbxInput.Controls.Add(this.txtToken);
            this.gbxInput.Location = new System.Drawing.Point(7, 8);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(432, 139);
            this.gbxInput.TabIndex = 0;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "Content Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.lblContentTitle);
            this.groupBox1.Controls.Add(this.rtbCopyright);
            this.groupBox1.Controls.Add(this.lblAuthor);
            this.groupBox1.Controls.Add(this.rtbAuthors);
            this.groupBox1.Controls.Add(this.lblCopyright);
            this.groupBox1.Location = new System.Drawing.Point(7, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 153);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content Information";
            // 
            // SSAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxInput);
            this.Controls.Add(this.tctrlMain);
            this.Controls.Add(this.btnToken);
            this.Controls.Add(this.btnCheckAvailability);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(970, 393);
            this.MinimumSize = new System.Drawing.Size(970, 393);
            this.Name = "SSAC";
            this.Text = "Spotify Song Availability Checker";
            this.Load += new System.EventHandler(this.SSAC_Load);
            this.tctrlMain.ResumeLayout(false);
            this.tpgAvailability.ResumeLayout(false);
            this.tpgAvailability.PerformLayout();
            this.tpgSearchHistory.ResumeLayout(false);
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TextBox txtSearchInput;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabControl tctrlMain;
        private System.Windows.Forms.TabPage tpgAvailability;
        private System.Windows.Forms.TabPage tpgSearchHistory;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox rtbAuthors;
        private System.Windows.Forms.RichTextBox rtbCopyright;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwSearchHistory;
        private System.Windows.Forms.ColumnHeader chdrTitle;
        private System.Windows.Forms.ColumnHeader chdrLink;
        private System.Windows.Forms.ColumnHeader chdrType;
        private System.Windows.Forms.ColumnHeader chdrAuthor;
        private System.Windows.Forms.ListView lvwAvailability;
        private System.Windows.Forms.ColumnHeader chdrCountryCode;
        private System.Windows.Forms.ColumnHeader chdrCountry;
    }
}

