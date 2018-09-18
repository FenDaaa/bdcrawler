namespace ConfigurationEditor
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.siteComboBox = new System.Windows.Forms.ComboBox();
            this.siteNameTextBox = new System.Windows.Forms.TextBox();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.startNumber = new System.Windows.Forms.NumericUpDown();
            this.siteLabel = new System.Windows.Forms.Label();
            this.siteNameLabel = new System.Windows.Forms.Label();
            this.urlPatternLabel = new System.Windows.Forms.Label();
            this.itemPatternLabel = new System.Windows.Forms.Label();
            this.startNumberLabel = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.urlPositionLabel = new System.Windows.Forms.Label();
            this.urlPosition = new System.Windows.Forms.NumericUpDown();
            this.captionPositionLabel = new System.Windows.Forms.Label();
            this.captionPosition = new System.Windows.Forms.NumericUpDown();
            this.testButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.startUrlLabel = new System.Windows.Forms.Label();
            this.startUrlTextBox = new System.Windows.Forms.TextBox();
            this.datePositionLabel = new System.Windows.Forms.Label();
            this.datePosition = new System.Windows.Forms.NumericUpDown();
            this.categoryPatternLabel = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.indexCodePatternLabel = new System.Windows.Forms.Label();
            this.indexCodeTextBox = new System.Windows.Forms.TextBox();
            this.issueCodeLabel = new System.Windows.Forms.Label();
            this.issueCodeTextBox = new System.Windows.Forms.TextBox();
            this.attachmentLabel = new System.Windows.Forms.Label();
            this.attachmentTextBox = new System.Windows.Forms.TextBox();
            this.keywordLabel = new System.Windows.Forms.Label();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.publishAgencyLabel = new System.Windows.Forms.Label();
            this.publishAgencyTextBox = new System.Windows.Forms.TextBox();
            this.testLogTextBox = new System.Windows.Forms.TextBox();
            this.publishDateLabel = new System.Windows.Forms.Label();
            this.publishDateTextBox = new System.Windows.Forms.TextBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.parseKeyTextBox = new System.Windows.Forms.TextBox();
            this.htmlReaderLabel = new System.Windows.Forms.Label();
            this.itemReaderLabel = new System.Windows.Forms.Label();
            this.parseValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageStepNumber = new System.Windows.Forms.NumericUpDown();
            this.AddDicButton = new System.Windows.Forms.Button();
            this.parseDicDataGridView = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeDicButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captionPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageStepNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseDicDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1064, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.FileName = "CrawlerConfiguration";
            this.openFileDialog.Filter = "JSON files (*.json)|*.json";
            // 
            // siteComboBox
            // 
            this.siteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteComboBox.FormattingEnabled = true;
            this.siteComboBox.Location = new System.Drawing.Point(160, 28);
            this.siteComboBox.Name = "siteComboBox";
            this.siteComboBox.Size = new System.Drawing.Size(336, 21);
            this.siteComboBox.TabIndex = 1;
            this.siteComboBox.SelectedIndexChanged += new System.EventHandler(this.SiteComboBox_SelectedIndexChanged);
            // 
            // siteNameTextBox
            // 
            this.siteNameTextBox.Location = new System.Drawing.Point(160, 55);
            this.siteNameTextBox.Name = "siteNameTextBox";
            this.siteNameTextBox.Size = new System.Drawing.Size(336, 20);
            this.siteNameTextBox.TabIndex = 2;
            this.siteNameTextBox.TextChanged += new System.EventHandler(this.SiteNameTextBox_TextChanged);
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(160, 133);
            this.itemTextBox.Multiline = true;
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(336, 80);
            this.itemTextBox.TabIndex = 3;
            this.itemTextBox.TextChanged += new System.EventHandler(this.ItemTextBox_TextChanged);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(160, 107);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(336, 20);
            this.urlTextBox.TabIndex = 4;
            this.urlTextBox.TextChanged += new System.EventHandler(this.UrlTextBox_TextChanged);
            // 
            // startNumber
            // 
            this.startNumber.Location = new System.Drawing.Point(116, 532);
            this.startNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startNumber.Name = "startNumber";
            this.startNumber.Size = new System.Drawing.Size(55, 20);
            this.startNumber.TabIndex = 6;
            this.startNumber.ValueChanged += new System.EventHandler(this.StartNumber_ValueChanged);
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Location = new System.Drawing.Point(108, 33);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(30, 13);
            this.siteLabel.TabIndex = 7;
            this.siteLabel.Text = "Sites";
            // 
            // siteNameLabel
            // 
            this.siteNameLabel.AutoSize = true;
            this.siteNameLabel.Location = new System.Drawing.Point(84, 59);
            this.siteNameLabel.Name = "siteNameLabel";
            this.siteNameLabel.Size = new System.Drawing.Size(56, 13);
            this.siteNameLabel.TabIndex = 8;
            this.siteNameLabel.Text = "Site Name";
            // 
            // urlPatternLabel
            // 
            this.urlPatternLabel.AutoSize = true;
            this.urlPatternLabel.Location = new System.Drawing.Point(72, 111);
            this.urlPatternLabel.Name = "urlPatternLabel";
            this.urlPatternLabel.Size = new System.Drawing.Size(66, 13);
            this.urlPatternLabel.TabIndex = 9;
            this.urlPatternLabel.Text = "URL Pattern";
            // 
            // itemPatternLabel
            // 
            this.itemPatternLabel.AutoSize = true;
            this.itemPatternLabel.Location = new System.Drawing.Point(66, 169);
            this.itemPatternLabel.Name = "itemPatternLabel";
            this.itemPatternLabel.Size = new System.Drawing.Size(64, 13);
            this.itemPatternLabel.TabIndex = 10;
            this.itemPatternLabel.Text = "Item Pattern";
            // 
            // startNumberLabel
            // 
            this.startNumberLabel.AutoSize = true;
            this.startNumberLabel.Location = new System.Drawing.Point(28, 537);
            this.startNumberLabel.Name = "startNumberLabel";
            this.startNumberLabel.Size = new System.Drawing.Size(69, 13);
            this.startNumberLabel.TabIndex = 11;
            this.startNumberLabel.Text = "Start Number";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(510, 542);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 35);
            this.newButton.TabIndex = 12;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.FileName = "CrawlerConfiguration";
            this.saveFileDialog.Filter = "JSON files (*.json)|*.json";
            // 
            // urlPositionLabel
            // 
            this.urlPositionLabel.AutoSize = true;
            this.urlPositionLabel.Location = new System.Drawing.Point(251, 499);
            this.urlPositionLabel.Name = "urlPositionLabel";
            this.urlPositionLabel.Size = new System.Drawing.Size(69, 13);
            this.urlPositionLabel.TabIndex = 14;
            this.urlPositionLabel.Text = "URL Position";
            // 
            // urlPosition
            // 
            this.urlPosition.Location = new System.Drawing.Point(345, 497);
            this.urlPosition.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.urlPosition.Name = "urlPosition";
            this.urlPosition.Size = new System.Drawing.Size(55, 20);
            this.urlPosition.TabIndex = 13;
            this.urlPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.urlPosition.ValueChanged += new System.EventHandler(this.UrlPosition_ValueChanged);
            // 
            // captionPositionLabel
            // 
            this.captionPositionLabel.AutoSize = true;
            this.captionPositionLabel.Location = new System.Drawing.Point(227, 535);
            this.captionPositionLabel.Name = "captionPositionLabel";
            this.captionPositionLabel.Size = new System.Drawing.Size(83, 13);
            this.captionPositionLabel.TabIndex = 16;
            this.captionPositionLabel.Text = "Caption Position";
            // 
            // captionPosition
            // 
            this.captionPosition.Location = new System.Drawing.Point(345, 532);
            this.captionPosition.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.captionPosition.Name = "captionPosition";
            this.captionPosition.Size = new System.Drawing.Size(55, 20);
            this.captionPosition.TabIndex = 15;
            this.captionPosition.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.captionPosition.ValueChanged += new System.EventHandler(this.CaptionPosition_ValueChanged);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(802, 542);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(80, 35);
            this.testButton.TabIndex = 17;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(510, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(550, 277);
            this.dataGridView.TabIndex = 18;
            // 
            // startUrlLabel
            // 
            this.startUrlLabel.AutoSize = true;
            this.startUrlLabel.Location = new System.Drawing.Point(84, 91);
            this.startUrlLabel.Name = "startUrlLabel";
            this.startUrlLabel.Size = new System.Drawing.Size(54, 13);
            this.startUrlLabel.TabIndex = 20;
            this.startUrlLabel.Text = "Start URL";
            // 
            // startUrlTextBox
            // 
            this.startUrlTextBox.Location = new System.Drawing.Point(160, 81);
            this.startUrlTextBox.Name = "startUrlTextBox";
            this.startUrlTextBox.Size = new System.Drawing.Size(336, 20);
            this.startUrlTextBox.TabIndex = 19;
            this.startUrlTextBox.TextChanged += new System.EventHandler(this.StartUrlTextBox_TextChanged);
            // 
            // datePositionLabel
            // 
            this.datePositionLabel.AutoSize = true;
            this.datePositionLabel.Location = new System.Drawing.Point(245, 566);
            this.datePositionLabel.Name = "datePositionLabel";
            this.datePositionLabel.Size = new System.Drawing.Size(70, 13);
            this.datePositionLabel.TabIndex = 22;
            this.datePositionLabel.Text = "Date Position";
            // 
            // datePosition
            // 
            this.datePosition.Location = new System.Drawing.Point(345, 564);
            this.datePosition.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.datePosition.Name = "datePosition";
            this.datePosition.Size = new System.Drawing.Size(55, 20);
            this.datePosition.TabIndex = 21;
            this.datePosition.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.datePosition.ValueChanged += new System.EventHandler(this.DatePosition_ValueChanged);
            // 
            // categoryPatternLabel
            // 
            this.categoryPatternLabel.AutoSize = true;
            this.categoryPatternLabel.Location = new System.Drawing.Point(42, 262);
            this.categoryPatternLabel.Name = "categoryPatternLabel";
            this.categoryPatternLabel.Size = new System.Drawing.Size(86, 13);
            this.categoryPatternLabel.TabIndex = 24;
            this.categoryPatternLabel.Text = "Category Pattern";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(160, 259);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(336, 20);
            this.categoryTextBox.TabIndex = 23;
            this.categoryTextBox.TextChanged += new System.EventHandler(this.Category_ValueChanged);
            // 
            // indexCodePatternLabel
            // 
            this.indexCodePatternLabel.AutoSize = true;
            this.indexCodePatternLabel.Location = new System.Drawing.Point(37, 288);
            this.indexCodePatternLabel.Name = "indexCodePatternLabel";
            this.indexCodePatternLabel.Size = new System.Drawing.Size(95, 13);
            this.indexCodePatternLabel.TabIndex = 26;
            this.indexCodePatternLabel.Text = "IndexCode Pattern";
            // 
            // indexCodeTextBox
            // 
            this.indexCodeTextBox.Location = new System.Drawing.Point(160, 285);
            this.indexCodeTextBox.Name = "indexCodeTextBox";
            this.indexCodeTextBox.Size = new System.Drawing.Size(336, 20);
            this.indexCodeTextBox.TabIndex = 25;
            this.indexCodeTextBox.TextChanged += new System.EventHandler(this.IndexCode_ValueChanged);
            // 
            // issueCodeLabel
            // 
            this.issueCodeLabel.AutoSize = true;
            this.issueCodeLabel.Location = new System.Drawing.Point(36, 314);
            this.issueCodeLabel.Name = "issueCodeLabel";
            this.issueCodeLabel.Size = new System.Drawing.Size(94, 13);
            this.issueCodeLabel.TabIndex = 28;
            this.issueCodeLabel.Text = "IssueCode Pattern";
            // 
            // issueCodeTextBox
            // 
            this.issueCodeTextBox.Location = new System.Drawing.Point(160, 311);
            this.issueCodeTextBox.Name = "issueCodeTextBox";
            this.issueCodeTextBox.Size = new System.Drawing.Size(336, 20);
            this.issueCodeTextBox.TabIndex = 27;
            this.issueCodeTextBox.TextChanged += new System.EventHandler(this.IssueCode_ValueChanged);
            // 
            // attachmentLabel
            // 
            this.attachmentLabel.AutoSize = true;
            this.attachmentLabel.Location = new System.Drawing.Point(30, 392);
            this.attachmentLabel.Name = "attachmentLabel";
            this.attachmentLabel.Size = new System.Drawing.Size(98, 13);
            this.attachmentLabel.TabIndex = 34;
            this.attachmentLabel.Text = "Attachment Pattern";
            // 
            // attachmentTextBox
            // 
            this.attachmentTextBox.Location = new System.Drawing.Point(160, 389);
            this.attachmentTextBox.Name = "attachmentTextBox";
            this.attachmentTextBox.Size = new System.Drawing.Size(336, 20);
            this.attachmentTextBox.TabIndex = 33;
            this.attachmentTextBox.TextChanged += new System.EventHandler(this.Attachment_ValueChanged);
            // 
            // keywordLabel
            // 
            this.keywordLabel.AutoSize = true;
            this.keywordLabel.Location = new System.Drawing.Point(48, 366);
            this.keywordLabel.Name = "keywordLabel";
            this.keywordLabel.Size = new System.Drawing.Size(85, 13);
            this.keywordLabel.TabIndex = 32;
            this.keywordLabel.Text = "Keyword Pattern";
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(160, 363);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(336, 20);
            this.keywordTextBox.TabIndex = 31;
            this.keywordTextBox.TextChanged += new System.EventHandler(this.Keyword_ValueChanged);
            // 
            // publishAgencyLabel
            // 
            this.publishAgencyLabel.AutoSize = true;
            this.publishAgencyLabel.Location = new System.Drawing.Point(13, 340);
            this.publishAgencyLabel.Name = "publishAgencyLabel";
            this.publishAgencyLabel.Size = new System.Drawing.Size(114, 13);
            this.publishAgencyLabel.TabIndex = 30;
            this.publishAgencyLabel.Text = "PublishAgency Pattern";
            // 
            // publishAgencyTextBox
            // 
            this.publishAgencyTextBox.Location = new System.Drawing.Point(160, 337);
            this.publishAgencyTextBox.Name = "publishAgencyTextBox";
            this.publishAgencyTextBox.Size = new System.Drawing.Size(336, 20);
            this.publishAgencyTextBox.TabIndex = 29;
            this.publishAgencyTextBox.TextChanged += new System.EventHandler(this.PublishAgency_ValueChanged);
            // 
            // testLogTextBox
            // 
            this.testLogTextBox.Location = new System.Drawing.Point(510, 314);
            this.testLogTextBox.Multiline = true;
            this.testLogTextBox.Name = "testLogTextBox";
            this.testLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.testLogTextBox.Size = new System.Drawing.Size(550, 120);
            this.testLogTextBox.TabIndex = 35;
            this.testLogTextBox.WordWrap = false;
            // 
            // publishDateLabel
            // 
            this.publishDateLabel.AutoSize = true;
            this.publishDateLabel.Location = new System.Drawing.Point(24, 421);
            this.publishDateLabel.Name = "publishDateLabel";
            this.publishDateLabel.Size = new System.Drawing.Size(101, 13);
            this.publishDateLabel.TabIndex = 37;
            this.publishDateLabel.Text = "PublishDate Pattern";
            // 
            // publishDateTextBox
            // 
            this.publishDateTextBox.Location = new System.Drawing.Point(160, 418);
            this.publishDateTextBox.Name = "publishDateTextBox";
            this.publishDateTextBox.Size = new System.Drawing.Size(336, 20);
            this.publishDateTextBox.TabIndex = 36;
            this.publishDateTextBox.TextChanged += new System.EventHandler(this.PublishDate_ValueChanged);
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "UTF-8",
            "GBK"});
            this.languageComboBox.Location = new System.Drawing.Point(696, 549);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(80, 21);
            this.languageComboBox.TabIndex = 38;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(627, 554);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 39;
            this.languageLabel.Text = "Language";
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(160, 226);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(336, 20);
            this.contentTextBox.TabIndex = 42;
            this.contentTextBox.TextChanged += new System.EventHandler(this.Content_ValueChanged);
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(47, 229);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(81, 13);
            this.contentLabel.TabIndex = 43;
            this.contentLabel.Text = "Content Pattern";
            // 
            // parseKeyTextBox
            // 
            this.parseKeyTextBox.Location = new System.Drawing.Point(160, 444);
            this.parseKeyTextBox.Name = "parseKeyTextBox";
            this.parseKeyTextBox.Size = new System.Drawing.Size(155, 20);
            this.parseKeyTextBox.TabIndex = 40;
            // 
            // htmlReaderLabel
            // 
            this.htmlReaderLabel.AutoSize = true;
            this.htmlReaderLabel.Location = new System.Drawing.Point(69, 447);
            this.htmlReaderLabel.Name = "htmlReaderLabel";
            this.htmlReaderLabel.Size = new System.Drawing.Size(55, 13);
            this.htmlReaderLabel.TabIndex = 41;
            this.htmlReaderLabel.Text = "Parse Key";
            // 
            // itemReaderLabel
            // 
            this.itemReaderLabel.AutoSize = true;
            this.itemReaderLabel.Location = new System.Drawing.Point(345, 447);
            this.itemReaderLabel.Name = "itemReaderLabel";
            this.itemReaderLabel.Size = new System.Drawing.Size(64, 13);
            this.itemReaderLabel.TabIndex = 45;
            this.itemReaderLabel.Text = "Parse Value";
            // 
            // parseValueTextBox
            // 
            this.parseValueTextBox.Location = new System.Drawing.Point(446, 444);
            this.parseValueTextBox.Name = "parseValueTextBox";
            this.parseValueTextBox.Size = new System.Drawing.Size(155, 20);
            this.parseValueTextBox.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 571);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Site Step";
            // 
            // pageStepNumber
            // 
            this.pageStepNumber.Location = new System.Drawing.Point(116, 569);
            this.pageStepNumber.Margin = new System.Windows.Forms.Padding(2);
            this.pageStepNumber.Name = "pageStepNumber";
            this.pageStepNumber.Size = new System.Drawing.Size(54, 20);
            this.pageStepNumber.TabIndex = 51;
            this.pageStepNumber.ValueChanged += new System.EventHandler(this.PageStepNumber_ValueChanged);
            // 
            // AddDicButton
            // 
            this.AddDicButton.Location = new System.Drawing.Point(618, 442);
            this.AddDicButton.Name = "AddDicButton";
            this.AddDicButton.Size = new System.Drawing.Size(75, 23);
            this.AddDicButton.TabIndex = 53;
            this.AddDicButton.Text = "AddDic";
            this.AddDicButton.UseVisualStyleBackColor = true;
            this.AddDicButton.Click += new System.EventHandler(this.AddDicButton_Click);
            // 
            // parseDicDataGridView
            // 
            this.parseDicDataGridView.AllowUserToAddRows = false;
            this.parseDicDataGridView.AllowUserToDeleteRows = false;
            this.parseDicDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parseDicDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.parseDicDataGridView.Location = new System.Drawing.Point(719, 442);
            this.parseDicDataGridView.MultiSelect = false;
            this.parseDicDataGridView.Name = "parseDicDataGridView";
            this.parseDicDataGridView.ReadOnly = true;
            this.parseDicDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parseDicDataGridView.Size = new System.Drawing.Size(333, 94);
            this.parseDicDataGridView.TabIndex = 54;
            // 
            // Key
            // 
            this.Key.DataPropertyName = "Key";
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Width = 120;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 150;
            // 
            // removeDicButton
            // 
            this.removeDicButton.Location = new System.Drawing.Point(618, 472);
            this.removeDicButton.Name = "removeDicButton";
            this.removeDicButton.Size = new System.Drawing.Size(75, 23);
            this.removeDicButton.TabIndex = 55;
            this.removeDicButton.Text = "RemoveDic";
            this.removeDicButton.UseVisualStyleBackColor = true;
            this.removeDicButton.Click += new System.EventHandler(this.removeDicButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 541);
            this.Controls.Add(this.removeDicButton);
            this.Controls.Add(this.parseDicDataGridView);
            this.Controls.Add(this.AddDicButton);
            this.Controls.Add(this.pageStepNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemReaderLabel);
            this.Controls.Add(this.parseValueTextBox);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.htmlReaderLabel);
            this.Controls.Add(this.parseKeyTextBox);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.publishDateLabel);
            this.Controls.Add(this.publishDateTextBox);
            this.Controls.Add(this.testLogTextBox);
            this.Controls.Add(this.attachmentLabel);
            this.Controls.Add(this.attachmentTextBox);
            this.Controls.Add(this.keywordLabel);
            this.Controls.Add(this.keywordTextBox);
            this.Controls.Add(this.publishAgencyLabel);
            this.Controls.Add(this.publishAgencyTextBox);
            this.Controls.Add(this.issueCodeLabel);
            this.Controls.Add(this.issueCodeTextBox);
            this.Controls.Add(this.indexCodePatternLabel);
            this.Controls.Add(this.indexCodeTextBox);
            this.Controls.Add(this.categoryPatternLabel);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.datePositionLabel);
            this.Controls.Add(this.datePosition);
            this.Controls.Add(this.startUrlLabel);
            this.Controls.Add(this.startUrlTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.captionPositionLabel);
            this.Controls.Add(this.captionPosition);
            this.Controls.Add(this.urlPositionLabel);
            this.Controls.Add(this.urlPosition);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.startNumberLabel);
            this.Controls.Add(this.itemPatternLabel);
            this.Controls.Add(this.urlPatternLabel);
            this.Controls.Add(this.siteNameLabel);
            this.Controls.Add(this.siteLabel);
            this.Controls.Add(this.startNumber);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.itemTextBox);
            this.Controls.Add(this.siteNameTextBox);
            this.Controls.Add(this.siteComboBox);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Configuration Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urlPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captionPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageStepNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parseDicDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox siteComboBox;
        private System.Windows.Forms.TextBox siteNameTextBox;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.NumericUpDown startNumber;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.Label siteNameLabel;
        private System.Windows.Forms.Label urlPatternLabel;
        private System.Windows.Forms.Label itemPatternLabel;
        private System.Windows.Forms.Label startNumberLabel;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label urlPositionLabel;
        private System.Windows.Forms.NumericUpDown urlPosition;
        private System.Windows.Forms.Label captionPositionLabel;
        private System.Windows.Forms.NumericUpDown captionPosition;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label startUrlLabel;
        private System.Windows.Forms.TextBox startUrlTextBox;
        private System.Windows.Forms.Label datePositionLabel;
        private System.Windows.Forms.NumericUpDown datePosition;
        private System.Windows.Forms.Label categoryPatternLabel;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label indexCodePatternLabel;
        private System.Windows.Forms.TextBox indexCodeTextBox;
        private System.Windows.Forms.Label issueCodeLabel;
        private System.Windows.Forms.TextBox issueCodeTextBox;
        private System.Windows.Forms.Label attachmentLabel;
        private System.Windows.Forms.TextBox attachmentTextBox;
        private System.Windows.Forms.Label keywordLabel;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Label publishAgencyLabel;
        private System.Windows.Forms.TextBox publishAgencyTextBox;
        private System.Windows.Forms.TextBox testLogTextBox;
        private System.Windows.Forms.Label publishDateLabel;
        private System.Windows.Forms.TextBox publishDateTextBox;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.TextBox parseKeyTextBox;
        private System.Windows.Forms.Label htmlReaderLabel;
        private System.Windows.Forms.Label itemReaderLabel;
        private System.Windows.Forms.TextBox parseValueTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pageStepNumber;
        private System.Windows.Forms.Button AddDicButton;
        private System.Windows.Forms.DataGridView parseDicDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button removeDicButton;
    }
}

