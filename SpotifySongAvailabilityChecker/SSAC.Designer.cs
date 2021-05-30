
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
            this.lblCopyright = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.rtbAuthors = new System.Windows.Forms.RichTextBox();
            this.rtbCopyright = new System.Windows.Forms.RichTextBox();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumUnavailCountries = new System.Windows.Forms.TextBox();
            this.lblNumUnavailCountries = new System.Windows.Forms.Label();
            this.txtNumCountries = new System.Windows.Forms.TextBox();
            this.lblNumCountries = new System.Windows.Forms.Label();
            this.tpgSearchHistory = new System.Windows.Forms.TabPage();
            this.btnClearSearchHistory = new System.Windows.Forms.Button();
            this.btnFavoriteSong = new System.Windows.Forms.Button();
            this.btnUseSearch = new System.Windows.Forms.Button();
            this.lblSearchInput = new System.Windows.Forms.Label();
            this.cbxSearchHistoryType = new System.Windows.Forms.ComboBox();
            this.lblSearchPrompt = new System.Windows.Forms.Label();
            this.btnSearchHistory = new System.Windows.Forms.Button();
            this.txtSearchHistory = new System.Windows.Forms.TextBox();
            this.btnResetHistorySearch = new System.Windows.Forms.Button();
            this.lvwSearchHistory = new System.Windows.Forms.ListView();
            this.chdrFavorite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpgAvailability = new System.Windows.Forms.TabPage();
            this.cbxAvailabilitySearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lvwAvailability = new System.Windows.Forms.ListView();
            this.chdrCountryCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdrCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearchInput = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tctrlMain = new System.Windows.Forms.TabControl();
            this.tpgSettings = new System.Windows.Forms.TabPage();
            this.gbxGeneral = new System.Windows.Forms.GroupBox();
            this.chkEnableExperiments = new System.Windows.Forms.CheckBox();
            this.gbxProgramDisplay = new System.Windows.Forms.GroupBox();
            this.chkEnableProgramResize = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxDefSortOrder = new System.Windows.Forms.ComboBox();
            this.lblDefSortOrder = new System.Windows.Forms.Label();
            this.chkAllowColumnReorder = new System.Windows.Forms.CheckBox();
            this.chkShowGridlines = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAutoSwitchTabs = new System.Windows.Forms.CheckBox();
            this.rtbDebugConsole = new System.Windows.Forms.RichTextBox();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.tctrlProgramErrors = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpgSearchHistory.SuspendLayout();
            this.tpgAvailability.SuspendLayout();
            this.tctrlMain.SuspendLayout();
            this.tpgSettings.SuspendLayout();
            this.gbxGeneral.SuspendLayout();
            this.gbxProgramDisplay.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tctrlProgramErrors.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTrackID
            // 
            this.txtTrackID.Location = new System.Drawing.Point(77, 20);
            this.txtTrackID.Name = "txtTrackID";
            this.txtTrackID.Size = new System.Drawing.Size(439, 22);
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
            this.txtAlbumID.Size = new System.Drawing.Size(439, 22);
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
            this.btnCheckAvailability.Location = new System.Drawing.Point(97, 371);
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
            this.chkIsAlbum.Location = new System.Drawing.Point(235, 111);
            this.chkIsAlbum.Name = "chkIsAlbum";
            this.chkIsAlbum.Size = new System.Drawing.Size(75, 17);
            this.chkIsAlbum.TabIndex = 7;
            this.chkIsAlbum.Text = "Is Album?";
            this.chkIsAlbum.UseVisualStyleBackColor = true;
            this.chkIsAlbum.CheckedChanged += new System.EventHandler(this.chkIsAlbum_CheckedChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 49);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(54, 13);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Authors: ";
            // 
            // lblContentTitle
            // 
            this.lblContentTitle.AutoSize = true;
            this.lblContentTitle.Location = new System.Drawing.Point(38, 21);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(35, 13);
            this.lblContentTitle.TabIndex = 9;
            this.lblContentTitle.Text = "Title: ";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(94, 78);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(422, 22);
            this.txtToken.TabIndex = 6;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(8, 81);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(77, 13);
            this.lblToken.TabIndex = 5;
            this.lblToken.Text = "Access Token:";
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(215, 371);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(112, 23);
            this.btnToken.TabIndex = 16;
            this.btnToken.Text = "Get Access Token";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(10, 96);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(61, 13);
            this.lblCopyright.TabIndex = 13;
            this.lblCopyright.Text = "Copyright:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(78, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(438, 22);
            this.txtTitle.TabIndex = 10;
            // 
            // rtbAuthors
            // 
            this.rtbAuthors.Location = new System.Drawing.Point(78, 49);
            this.rtbAuthors.Name = "rtbAuthors";
            this.rtbAuthors.ReadOnly = true;
            this.rtbAuthors.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbAuthors.Size = new System.Drawing.Size(438, 42);
            this.rtbAuthors.TabIndex = 12;
            this.rtbAuthors.Text = "";
            // 
            // rtbCopyright
            // 
            this.rtbCopyright.Location = new System.Drawing.Point(78, 99);
            this.rtbCopyright.Name = "rtbCopyright";
            this.rtbCopyright.ReadOnly = true;
            this.rtbCopyright.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbCopyright.Size = new System.Drawing.Size(438, 42);
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
            this.gbxInput.Size = new System.Drawing.Size(522, 139);
            this.gbxInput.TabIndex = 0;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "Content Input";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumUnavailCountries);
            this.groupBox1.Controls.Add(this.lblNumUnavailCountries);
            this.groupBox1.Controls.Add(this.txtNumCountries);
            this.groupBox1.Controls.Add(this.lblNumCountries);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.lblContentTitle);
            this.groupBox1.Controls.Add(this.rtbCopyright);
            this.groupBox1.Controls.Add(this.lblAuthor);
            this.groupBox1.Controls.Add(this.rtbAuthors);
            this.groupBox1.Controls.Add(this.lblCopyright);
            this.groupBox1.Location = new System.Drawing.Point(7, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 209);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content Information";
            // 
            // txtNumUnavailCountries
            // 
            this.txtNumUnavailCountries.Location = new System.Drawing.Point(275, 178);
            this.txtNumUnavailCountries.Name = "txtNumUnavailCountries";
            this.txtNumUnavailCountries.ReadOnly = true;
            this.txtNumUnavailCountries.Size = new System.Drawing.Size(241, 22);
            this.txtNumUnavailCountries.TabIndex = 18;
            // 
            // lblNumUnavailCountries
            // 
            this.lblNumUnavailCountries.AutoSize = true;
            this.lblNumUnavailCountries.Location = new System.Drawing.Point(9, 181);
            this.lblNumUnavailCountries.Name = "lblNumUnavailCountries";
            this.lblNumUnavailCountries.Size = new System.Drawing.Size(260, 13);
            this.lblNumUnavailCountries.TabIndex = 17;
            this.lblNumUnavailCountries.Text = "Number of Countries the song is not available in:";
            // 
            // txtNumCountries
            // 
            this.txtNumCountries.Location = new System.Drawing.Point(254, 149);
            this.txtNumCountries.Name = "txtNumCountries";
            this.txtNumCountries.ReadOnly = true;
            this.txtNumCountries.Size = new System.Drawing.Size(262, 22);
            this.txtNumCountries.TabIndex = 16;
            // 
            // lblNumCountries
            // 
            this.lblNumCountries.AutoSize = true;
            this.lblNumCountries.Location = new System.Drawing.Point(9, 152);
            this.lblNumCountries.Name = "lblNumCountries";
            this.lblNumCountries.Size = new System.Drawing.Size(239, 13);
            this.lblNumCountries.TabIndex = 15;
            this.lblNumCountries.Text = "Number of Countries the song is available in:";
            // 
            // tpgSearchHistory
            // 
            this.tpgSearchHistory.Controls.Add(this.btnClearSearchHistory);
            this.tpgSearchHistory.Controls.Add(this.btnFavoriteSong);
            this.tpgSearchHistory.Controls.Add(this.btnUseSearch);
            this.tpgSearchHistory.Controls.Add(this.lblSearchInput);
            this.tpgSearchHistory.Controls.Add(this.cbxSearchHistoryType);
            this.tpgSearchHistory.Controls.Add(this.lblSearchPrompt);
            this.tpgSearchHistory.Controls.Add(this.btnSearchHistory);
            this.tpgSearchHistory.Controls.Add(this.txtSearchHistory);
            this.tpgSearchHistory.Controls.Add(this.btnResetHistorySearch);
            this.tpgSearchHistory.Controls.Add(this.lvwSearchHistory);
            this.tpgSearchHistory.Location = new System.Drawing.Point(4, 22);
            this.tpgSearchHistory.Name = "tpgSearchHistory";
            this.tpgSearchHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSearchHistory.Size = new System.Drawing.Size(541, 360);
            this.tpgSearchHistory.TabIndex = 1;
            this.tpgSearchHistory.Text = "Search History";
            this.tpgSearchHistory.UseVisualStyleBackColor = true;
            // 
            // btnClearSearchHistory
            // 
            this.btnClearSearchHistory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearSearchHistory.Location = new System.Drawing.Point(336, 329);
            this.btnClearSearchHistory.Name = "btnClearSearchHistory";
            this.btnClearSearchHistory.Size = new System.Drawing.Size(120, 23);
            this.btnClearSearchHistory.TabIndex = 34;
            this.btnClearSearchHistory.Text = "Clear Search History";
            this.btnClearSearchHistory.UseVisualStyleBackColor = true;
            this.btnClearSearchHistory.Click += new System.EventHandler(this.btnClearSearchHistory_Click);
            // 
            // btnFavoriteSong
            // 
            this.btnFavoriteSong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFavoriteSong.Location = new System.Drawing.Point(207, 329);
            this.btnFavoriteSong.Name = "btnFavoriteSong";
            this.btnFavoriteSong.Size = new System.Drawing.Size(123, 23);
            this.btnFavoriteSong.TabIndex = 33;
            this.btnFavoriteSong.Text = "Favorite/Unfavorite";
            this.btnFavoriteSong.UseVisualStyleBackColor = true;
            this.btnFavoriteSong.Click += new System.EventHandler(this.btnFavoriteSong_Click);
            // 
            // btnUseSearch
            // 
            this.btnUseSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUseSearch.Location = new System.Drawing.Point(89, 329);
            this.btnUseSearch.Name = "btnUseSearch";
            this.btnUseSearch.Size = new System.Drawing.Size(112, 23);
            this.btnUseSearch.TabIndex = 32;
            this.btnUseSearch.Text = "Use Search Info";
            this.btnUseSearch.UseVisualStyleBackColor = true;
            this.btnUseSearch.Click += new System.EventHandler(this.btnUseSearch_Click);
            // 
            // lblSearchInput
            // 
            this.lblSearchInput.AutoSize = true;
            this.lblSearchInput.Location = new System.Drawing.Point(6, 9);
            this.lblSearchInput.Name = "lblSearchInput";
            this.lblSearchInput.Size = new System.Drawing.Size(75, 13);
            this.lblSearchInput.TabIndex = 25;
            this.lblSearchInput.Text = "Search Input:";
            // 
            // cbxSearchHistoryType
            // 
            this.cbxSearchHistoryType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSearchHistoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchHistoryType.FormattingEnabled = true;
            this.cbxSearchHistoryType.Items.AddRange(new object[] {
            "Favorites",
            "Title",
            "Author",
            "Type",
            "Link"});
            this.cbxSearchHistoryType.Location = new System.Drawing.Point(68, 34);
            this.cbxSearchHistoryType.Name = "cbxSearchHistoryType";
            this.cbxSearchHistoryType.Size = new System.Drawing.Size(231, 21);
            this.cbxSearchHistoryType.TabIndex = 28;
            // 
            // lblSearchPrompt
            // 
            this.lblSearchPrompt.AutoSize = true;
            this.lblSearchPrompt.Location = new System.Drawing.Point(6, 37);
            this.lblSearchPrompt.Name = "lblSearchPrompt";
            this.lblSearchPrompt.Size = new System.Drawing.Size(58, 13);
            this.lblSearchPrompt.TabIndex = 27;
            this.lblSearchPrompt.Text = "Search By:";
            // 
            // btnSearchHistory
            // 
            this.btnSearchHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchHistory.Location = new System.Drawing.Point(306, 33);
            this.btnSearchHistory.Name = "btnSearchHistory";
            this.btnSearchHistory.Size = new System.Drawing.Size(112, 23);
            this.btnSearchHistory.TabIndex = 29;
            this.btnSearchHistory.Text = "Search";
            this.btnSearchHistory.UseVisualStyleBackColor = true;
            this.btnSearchHistory.Click += new System.EventHandler(this.btnSearchHistory_Click);
            // 
            // txtSearchHistory
            // 
            this.txtSearchHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchHistory.Location = new System.Drawing.Point(87, 6);
            this.txtSearchHistory.Name = "txtSearchHistory";
            this.txtSearchHistory.Size = new System.Drawing.Size(448, 22);
            this.txtSearchHistory.TabIndex = 26;
            this.txtSearchHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchHistory_KeyPress);
            // 
            // btnResetHistorySearch
            // 
            this.btnResetHistorySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetHistorySearch.Location = new System.Drawing.Point(423, 33);
            this.btnResetHistorySearch.Name = "btnResetHistorySearch";
            this.btnResetHistorySearch.Size = new System.Drawing.Size(112, 23);
            this.btnResetHistorySearch.TabIndex = 30;
            this.btnResetHistorySearch.Text = "Reset";
            this.btnResetHistorySearch.UseVisualStyleBackColor = true;
            this.btnResetHistorySearch.Click += new System.EventHandler(this.btnResetHistorySearch_Click);
            // 
            // lvwSearchHistory
            // 
            this.lvwSearchHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSearchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdrFavorite,
            this.chdrTitle,
            this.chdrAuthor,
            this.chdrType,
            this.chdrLink});
            this.lvwSearchHistory.FullRowSelect = true;
            this.lvwSearchHistory.HideSelection = false;
            this.lvwSearchHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvwSearchHistory.Location = new System.Drawing.Point(6, 62);
            this.lvwSearchHistory.Name = "lvwSearchHistory";
            this.lvwSearchHistory.Size = new System.Drawing.Size(529, 259);
            this.lvwSearchHistory.TabIndex = 31;
            this.lvwSearchHistory.UseCompatibleStateImageBehavior = false;
            this.lvwSearchHistory.View = System.Windows.Forms.View.Details;
            this.lvwSearchHistory.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwSearchHistory_ItemSelectionChanged);
            // 
            // chdrFavorite
            // 
            this.chdrFavorite.Text = "★";
            this.chdrFavorite.Width = 25;
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
            this.chdrLink.Width = 200;
            // 
            // tpgAvailability
            // 
            this.tpgAvailability.Controls.Add(this.cbxAvailabilitySearch);
            this.tpgAvailability.Controls.Add(this.label1);
            this.tpgAvailability.Controls.Add(this.lbl);
            this.tpgAvailability.Controls.Add(this.lvwAvailability);
            this.tpgAvailability.Controls.Add(this.txtSearchInput);
            this.tpgAvailability.Controls.Add(this.btnReset);
            this.tpgAvailability.Controls.Add(this.btnSearch);
            this.tpgAvailability.Location = new System.Drawing.Point(4, 22);
            this.tpgAvailability.Name = "tpgAvailability";
            this.tpgAvailability.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAvailability.Size = new System.Drawing.Size(541, 360);
            this.tpgAvailability.TabIndex = 0;
            this.tpgAvailability.Text = "Availability";
            this.tpgAvailability.UseVisualStyleBackColor = true;
            // 
            // cbxAvailabilitySearch
            // 
            this.cbxAvailabilitySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAvailabilitySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAvailabilitySearch.FormattingEnabled = true;
            this.cbxAvailabilitySearch.Items.AddRange(new object[] {
            "Country Code",
            "Country Code (Unavailability)",
            "Country Name",
            "Country Name (Unavailability)",
            "Unavailablity"});
            this.cbxAvailabilitySearch.Location = new System.Drawing.Point(68, 34);
            this.cbxAvailabilitySearch.Name = "cbxAvailabilitySearch";
            this.cbxAvailabilitySearch.Size = new System.Drawing.Size(232, 21);
            this.cbxAvailabilitySearch.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search Input:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(6, 37);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(58, 13);
            this.lbl.TabIndex = 20;
            this.lbl.Text = "Search By:";
            // 
            // lvwAvailability
            // 
            this.lvwAvailability.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAvailability.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdrCountryCode,
            this.chdrCountry});
            this.lvwAvailability.FullRowSelect = true;
            this.lvwAvailability.HideSelection = false;
            this.lvwAvailability.Location = new System.Drawing.Point(6, 62);
            this.lvwAvailability.Name = "lvwAvailability";
            this.lvwAvailability.Size = new System.Drawing.Size(529, 297);
            this.lvwAvailability.TabIndex = 24;
            this.lvwAvailability.UseCompatibleStateImageBehavior = false;
            this.lvwAvailability.View = System.Windows.Forms.View.Details;
            // 
            // chdrCountryCode
            // 
            this.chdrCountryCode.Text = "Country Code";
            this.chdrCountryCode.Width = 180;
            // 
            // chdrCountry
            // 
            this.chdrCountry.Text = "Country Name";
            this.chdrCountry.Width = 345;
            // 
            // txtSearchInput
            // 
            this.txtSearchInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchInput.Location = new System.Drawing.Point(87, 6);
            this.txtSearchInput.Name = "txtSearchInput";
            this.txtSearchInput.Size = new System.Drawing.Size(448, 22);
            this.txtSearchInput.TabIndex = 19;
            this.txtSearchInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchInput_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(423, 33);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 23);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(306, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tctrlMain
            // 
            this.tctrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tctrlMain.Controls.Add(this.tpgAvailability);
            this.tctrlMain.Controls.Add(this.tpgSearchHistory);
            this.tctrlMain.Controls.Add(this.tpgSettings);
            this.tctrlMain.Location = new System.Drawing.Point(535, 8);
            this.tctrlMain.Name = "tctrlMain";
            this.tctrlMain.SelectedIndex = 0;
            this.tctrlMain.Size = new System.Drawing.Size(549, 386);
            this.tctrlMain.TabIndex = 17;
            // 
            // tpgSettings
            // 
            this.tpgSettings.Controls.Add(this.gbxGeneral);
            this.tpgSettings.Controls.Add(this.gbxProgramDisplay);
            this.tpgSettings.Controls.Add(this.groupBox2);
            this.tpgSettings.Controls.Add(this.groupBox3);
            this.tpgSettings.Location = new System.Drawing.Point(4, 22);
            this.tpgSettings.Name = "tpgSettings";
            this.tpgSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSettings.Size = new System.Drawing.Size(541, 360);
            this.tpgSettings.TabIndex = 3;
            this.tpgSettings.Text = "Settings";
            this.tpgSettings.UseVisualStyleBackColor = true;
            // 
            // gbxGeneral
            // 
            this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGeneral.Controls.Add(this.chkEnableExperiments);
            this.gbxGeneral.Location = new System.Drawing.Point(6, 271);
            this.gbxGeneral.Name = "gbxGeneral";
            this.gbxGeneral.Size = new System.Drawing.Size(575, 40);
            this.gbxGeneral.TabIndex = 5;
            this.gbxGeneral.TabStop = false;
            this.gbxGeneral.Text = "General Settings";
            // 
            // chkEnableExperiments
            // 
            this.chkEnableExperiments.AutoSize = true;
            this.chkEnableExperiments.Location = new System.Drawing.Point(10, 19);
            this.chkEnableExperiments.Name = "chkEnableExperiments";
            this.chkEnableExperiments.Size = new System.Drawing.Size(180, 17);
            this.chkEnableExperiments.TabIndex = 0;
            this.chkEnableExperiments.Text = "Enable experimental features?";
            this.chkEnableExperiments.UseVisualStyleBackColor = true;
            this.chkEnableExperiments.CheckedChanged += new System.EventHandler(this.chkEnableExperiments_CheckedChanged);
            // 
            // gbxProgramDisplay
            // 
            this.gbxProgramDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxProgramDisplay.Controls.Add(this.chkEnableProgramResize);
            this.gbxProgramDisplay.Location = new System.Drawing.Point(6, 199);
            this.gbxProgramDisplay.Name = "gbxProgramDisplay";
            this.gbxProgramDisplay.Size = new System.Drawing.Size(575, 45);
            this.gbxProgramDisplay.TabIndex = 4;
            this.gbxProgramDisplay.TabStop = false;
            this.gbxProgramDisplay.Text = "Main Display";
            // 
            // chkEnableProgramResize
            // 
            this.chkEnableProgramResize.AutoSize = true;
            this.chkEnableProgramResize.Location = new System.Drawing.Point(10, 20);
            this.chkEnableProgramResize.Name = "chkEnableProgramResize";
            this.chkEnableProgramResize.Size = new System.Drawing.Size(156, 17);
            this.chkEnableProgramResize.TabIndex = 0;
            this.chkEnableProgramResize.Text = "Enable program resizing?";
            this.chkEnableProgramResize.UseVisualStyleBackColor = true;
            this.chkEnableProgramResize.CheckedChanged += new System.EventHandler(this.chkEnableProgramResize_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbxDefSortOrder);
            this.groupBox2.Controls.Add(this.lblDefSortOrder);
            this.groupBox2.Controls.Add(this.chkAllowColumnReorder);
            this.groupBox2.Controls.Add(this.chkShowGridlines);
            this.groupBox2.Location = new System.Drawing.Point(6, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 89);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Display";
            // 
            // cbxDefSortOrder
            // 
            this.cbxDefSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDefSortOrder.Enabled = false;
            this.cbxDefSortOrder.FormattingEnabled = true;
            this.cbxDefSortOrder.Items.AddRange(new object[] {
            "None",
            "Ascending",
            "Descending"});
            this.cbxDefSortOrder.Location = new System.Drawing.Point(245, 62);
            this.cbxDefSortOrder.Name = "cbxDefSortOrder";
            this.cbxDefSortOrder.Size = new System.Drawing.Size(121, 21);
            this.cbxDefSortOrder.TabIndex = 9;
            this.cbxDefSortOrder.SelectedIndexChanged += new System.EventHandler(this.cbxDefSortOrder_SelectedIndexChanged);
            // 
            // lblDefSortOrder
            // 
            this.lblDefSortOrder.AutoSize = true;
            this.lblDefSortOrder.Location = new System.Drawing.Point(7, 65);
            this.lblDefSortOrder.Name = "lblDefSortOrder";
            this.lblDefSortOrder.Size = new System.Drawing.Size(232, 13);
            this.lblDefSortOrder.TabIndex = 8;
            this.lblDefSortOrder.Text = "[EXPERIMENTAL] Default General Sort Order:";
            // 
            // chkAllowColumnReorder
            // 
            this.chkAllowColumnReorder.AutoSize = true;
            this.chkAllowColumnReorder.Location = new System.Drawing.Point(10, 42);
            this.chkAllowColumnReorder.Name = "chkAllowColumnReorder";
            this.chkAllowColumnReorder.Size = new System.Drawing.Size(194, 17);
            this.chkAllowColumnReorder.TabIndex = 1;
            this.chkAllowColumnReorder.Text = "Allow columns to be re-ordered?";
            this.chkAllowColumnReorder.UseVisualStyleBackColor = true;
            this.chkAllowColumnReorder.CheckedChanged += new System.EventHandler(this.chkAllowColumnReorder_CheckedChanged);
            // 
            // chkShowGridlines
            // 
            this.chkShowGridlines.AutoSize = true;
            this.chkShowGridlines.Location = new System.Drawing.Point(10, 19);
            this.chkShowGridlines.Name = "chkShowGridlines";
            this.chkShowGridlines.Size = new System.Drawing.Size(187, 17);
            this.chkShowGridlines.TabIndex = 0;
            this.chkShowGridlines.Text = "Show gridlines on list displays?";
            this.chkShowGridlines.UseVisualStyleBackColor = true;
            this.chkShowGridlines.CheckedChanged += new System.EventHandler(this.chkShowGridlines_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkAutoSwitchTabs);
            this.groupBox3.Location = new System.Drawing.Point(6, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 43);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Searching";
            // 
            // chkAutoSwitchTabs
            // 
            this.chkAutoSwitchTabs.AutoSize = true;
            this.chkAutoSwitchTabs.Location = new System.Drawing.Point(10, 18);
            this.chkAutoSwitchTabs.Name = "chkAutoSwitchTabs";
            this.chkAutoSwitchTabs.Size = new System.Drawing.Size(302, 17);
            this.chkAutoSwitchTabs.TabIndex = 0;
            this.chkAutoSwitchTabs.Text = "Switch tab to Availability when a search is performed?";
            this.chkAutoSwitchTabs.UseVisualStyleBackColor = true;
            // 
            // rtbDebugConsole
            // 
            this.rtbDebugConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDebugConsole.Location = new System.Drawing.Point(6, 6);
            this.rtbDebugConsole.Name = "rtbDebugConsole";
            this.rtbDebugConsole.ReadOnly = true;
            this.rtbDebugConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDebugConsole.Size = new System.Drawing.Size(1057, 269);
            this.rtbDebugConsole.TabIndex = 15;
            this.rtbDebugConsole.Text = "";
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(333, 371);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(112, 23);
            this.btnClearInput.TabIndex = 19;
            this.btnClearInput.Text = "Clear Input";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // tctrlProgramErrors
            // 
            this.tctrlProgramErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tctrlProgramErrors.Controls.Add(this.tabPage1);
            this.tctrlProgramErrors.Location = new System.Drawing.Point(7, 399);
            this.tctrlProgramErrors.Name = "tctrlProgramErrors";
            this.tctrlProgramErrors.SelectedIndex = 0;
            this.tctrlProgramErrors.Size = new System.Drawing.Size(1077, 306);
            this.tctrlProgramErrors.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbDebugConsole);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1069, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Program Errors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SSAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 711);
            this.Controls.Add(this.tctrlProgramErrors);
            this.Controls.Add(this.btnClearInput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxInput);
            this.Controls.Add(this.tctrlMain);
            this.Controls.Add(this.btnToken);
            this.Controls.Add(this.btnCheckAvailability);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1106, 690);
            this.Name = "SSAC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotify Song Availability Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SSAC_FormClosing);
            this.Load += new System.EventHandler(this.SSAC_Load);
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpgSearchHistory.ResumeLayout(false);
            this.tpgSearchHistory.PerformLayout();
            this.tpgAvailability.ResumeLayout(false);
            this.tpgAvailability.PerformLayout();
            this.tctrlMain.ResumeLayout(false);
            this.tpgSettings.ResumeLayout(false);
            this.gbxGeneral.ResumeLayout(false);
            this.gbxGeneral.PerformLayout();
            this.gbxProgramDisplay.ResumeLayout(false);
            this.gbxProgramDisplay.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tctrlProgramErrors.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox rtbAuthors;
        private System.Windows.Forms.RichTextBox rtbCopyright;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tpgSearchHistory;
        private System.Windows.Forms.Button btnFavoriteSong;
        private System.Windows.Forms.Button btnUseSearch;
        private System.Windows.Forms.Label lblSearchInput;
        private System.Windows.Forms.ComboBox cbxSearchHistoryType;
        private System.Windows.Forms.Label lblSearchPrompt;
        private System.Windows.Forms.Button btnSearchHistory;
        private System.Windows.Forms.TextBox txtSearchHistory;
        private System.Windows.Forms.Button btnResetHistorySearch;
        private System.Windows.Forms.TabPage tpgAvailability;
        private System.Windows.Forms.ComboBox cbxAvailabilitySearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ListView lvwAvailability;
        private System.Windows.Forms.ColumnHeader chdrCountryCode;
        private System.Windows.Forms.ColumnHeader chdrCountry;
        private System.Windows.Forms.TextBox txtSearchInput;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tctrlMain;
        private System.Windows.Forms.ListView lvwSearchHistory;
        private System.Windows.Forms.ColumnHeader chdrTitle;
        private System.Windows.Forms.ColumnHeader chdrAuthor;
        private System.Windows.Forms.ColumnHeader chdrType;
        private System.Windows.Forms.ColumnHeader chdrLink;
        private System.Windows.Forms.ColumnHeader chdrFavorite;
        private System.Windows.Forms.TabPage tpgSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkShowGridlines;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAutoSwitchTabs;
        private System.Windows.Forms.GroupBox gbxProgramDisplay;
        private System.Windows.Forms.CheckBox chkEnableProgramResize;
        private System.Windows.Forms.ComboBox cbxDefSortOrder;
        private System.Windows.Forms.Label lblDefSortOrder;
        private System.Windows.Forms.CheckBox chkAllowColumnReorder;
        private System.Windows.Forms.GroupBox gbxGeneral;
        private System.Windows.Forms.CheckBox chkEnableExperiments;
        private System.Windows.Forms.RichTextBox rtbDebugConsole;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.Button btnClearSearchHistory;
        private System.Windows.Forms.TextBox txtNumCountries;
        private System.Windows.Forms.Label lblNumCountries;
        private System.Windows.Forms.TabControl tctrlProgramErrors;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNumUnavailCountries;
        private System.Windows.Forms.Label lblNumUnavailCountries;
    }
}

