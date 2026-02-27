namespace StockDatasCollection.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStockMgr = new System.Windows.Forms.TabPage();
            this.tabCollect = new System.Windows.Forms.TabPage();
            this.tabArchive = new System.Windows.Forms.TabPage();
            this.tabLoader = new System.Windows.Forms.TabPage();

            // ---- Tab 1 controls ----
            this.dgvStocks = new System.Windows.Forms.DataGridView();
            this.colIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStockButtons = new System.Windows.Forms.Panel();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnEditStock = new System.Windows.Forms.Button();
            this.btnDeleteStock = new System.Windows.Forms.Button();

            // ---- Tab 2 controls ----
            this.panelCollectSettings = new System.Windows.Forms.Panel();
            this.lblIntervalCollect = new System.Windows.Forms.Label();
            this.nudCollectInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSecCollect = new System.Windows.Forms.Label();
            this.btnStartCollect = new System.Windows.Forms.Button();
            this.btnStopCollect = new System.Windows.Forms.Button();
            this.lblCollectStatus = new System.Windows.Forms.Label();
            this.lblLastCollect = new System.Windows.Forms.Label();
            this.lblNextCollect = new System.Windows.Forms.Label();
            this.lblCacheCount = new System.Windows.Forms.Label();
            this.dgvLiveData = new System.Windows.Forms.DataGridView();
            this.colLiveCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveOpen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLivePreClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveTurnover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // ---- Tab 3 controls ----
            this.panelArchiveSettings = new System.Windows.Forms.Panel();
            this.lblIntervalArchive = new System.Windows.Forms.Label();
            this.nudArchiveInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSecArchive = new System.Windows.Forms.Label();
            this.lblArchiveDir = new System.Windows.Forms.Label();
            this.txtArchiveDir = new System.Windows.Forms.TextBox();
            this.btnBrowseArchiveDir = new System.Windows.Forms.Button();
            this.btnStartArchive = new System.Windows.Forms.Button();
            this.btnStopArchive = new System.Windows.Forms.Button();
            this.btnArchiveNow = new System.Windows.Forms.Button();
            this.lblLastArchive = new System.Windows.Forms.Label();
            this.lblNextArchive = new System.Windows.Forms.Label();
            this.rtbArchiveLog = new System.Windows.Forms.RichTextBox();

            // ---- Tab 4 controls ----
            this.panelLoadTop = new System.Windows.Forms.Panel();
            this.txtLoadPath = new System.Windows.Forms.TextBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvLoadData = new System.Windows.Forms.DataGridView();
            this.colLdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdCollectedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdOpen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdPreClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdTurnover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdBuy1Vol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdBuy1Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdSell1Vol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdSell1Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLoadStatus = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ==============================================================
            // tabControl
            // ==============================================================
            this.tabControl.Controls.Add(this.tabStockMgr);
            this.tabControl.Controls.Add(this.tabCollect);
            this.tabControl.Controls.Add(this.tabArchive);
            this.tabControl.Controls.Add(this.tabLoader);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);

            // ==============================================================
            // Tab 1: 股票管理
            // ==============================================================
            this.tabStockMgr.Text = "股票管理";
            this.tabStockMgr.Padding = new System.Windows.Forms.Padding(5);

            // dgvStocks
            this.dgvStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStocks.AllowUserToAddRows = false;
            this.dgvStocks.AllowUserToDeleteRows = false;
            this.dgvStocks.ReadOnly = true;
            this.dgvStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.colIdx.HeaderText = "序号";    this.colIdx.Name = "colIdx";    this.colIdx.FillWeight = 30;
            this.colCode.HeaderText = "代码";   this.colCode.Name = "colCode";  this.colCode.FillWeight = 60;
            this.colName.HeaderText = "名称";   this.colName.Name = "colName";  this.colName.FillWeight = 80;
            this.colNotes.HeaderText = "备注";  this.colNotes.Name = "colNotes"; this.colNotes.FillWeight = 130;
            this.dgvStocks.Columns.AddRange(this.colIdx, this.colCode, this.colName, this.colNotes);

            // panelStockButtons
            this.panelStockButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStockButtons.Height = 45;
            this.btnAddStock.Text = "添加";   this.btnAddStock.Size = new System.Drawing.Size(80, 30); this.btnAddStock.Location = new System.Drawing.Point(5, 7);
            this.btnEditStock.Text = "编辑";  this.btnEditStock.Size = new System.Drawing.Size(80, 30); this.btnEditStock.Location = new System.Drawing.Point(95, 7);
            this.btnDeleteStock.Text = "删除"; this.btnDeleteStock.Size = new System.Drawing.Size(80, 30); this.btnDeleteStock.Location = new System.Drawing.Point(185, 7);
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            this.btnEditStock.Click += new System.EventHandler(this.btnEditStock_Click);
            this.btnDeleteStock.Click += new System.EventHandler(this.btnDeleteStock_Click);
            this.panelStockButtons.Controls.Add(this.btnAddStock);
            this.panelStockButtons.Controls.Add(this.btnEditStock);
            this.panelStockButtons.Controls.Add(this.btnDeleteStock);

            this.tabStockMgr.Controls.Add(this.dgvStocks);
            this.tabStockMgr.Controls.Add(this.panelStockButtons);

            // ==============================================================
            // Tab 2: 数据采集
            // ==============================================================
            this.tabCollect.Text = "数据采集";
            this.tabCollect.Padding = new System.Windows.Forms.Padding(5);

            // Settings panel
            this.panelCollectSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCollectSettings.Height = 115;

            this.lblIntervalCollect.Text = "采集间隔(秒):"; this.lblIntervalCollect.Location = new System.Drawing.Point(10, 12); this.lblIntervalCollect.AutoSize = true;
            this.nudCollectInterval.Location = new System.Drawing.Point(110, 9); this.nudCollectInterval.Size = new System.Drawing.Size(70, 23);
            this.nudCollectInterval.Minimum = 1; this.nudCollectInterval.Maximum = 3600; this.nudCollectInterval.Value = 5;
            this.lblSecCollect.Text = "秒"; this.lblSecCollect.Location = new System.Drawing.Point(185, 12); this.lblSecCollect.AutoSize = true;

            this.btnStartCollect.Text = "开始采集"; this.btnStartCollect.Size = new System.Drawing.Size(90, 30); this.btnStartCollect.Location = new System.Drawing.Point(10, 40);
            this.btnStopCollect.Text = "停止采集"; this.btnStopCollect.Size = new System.Drawing.Size(90, 30); this.btnStopCollect.Location = new System.Drawing.Point(110, 40); this.btnStopCollect.Enabled = false;
            this.btnStartCollect.Click += new System.EventHandler(this.btnStartCollect_Click);
            this.btnStopCollect.Click += new System.EventHandler(this.btnStopCollect_Click);

            this.lblCollectStatus.Text = "状态：已停止"; this.lblCollectStatus.Location = new System.Drawing.Point(10, 80); this.lblCollectStatus.AutoSize = true;
            this.lblLastCollect.Text = "最后采集：—";   this.lblLastCollect.Location = new System.Drawing.Point(130, 80); this.lblLastCollect.AutoSize = true;
            this.lblNextCollect.Text = "下次采集：—";   this.lblNextCollect.Location = new System.Drawing.Point(300, 80); this.lblNextCollect.AutoSize = true;
            this.lblCacheCount.Text = "缓存记录：0";    this.lblCacheCount.Location = new System.Drawing.Point(470, 80); this.lblCacheCount.AutoSize = true;

            this.panelCollectSettings.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblIntervalCollect, nudCollectInterval, lblSecCollect,
                btnStartCollect, btnStopCollect,
                lblCollectStatus, lblLastCollect, lblNextCollect, lblCacheCount
            });

            // Live data grid
            this.dgvLiveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLiveData.AllowUserToAddRows = false;
            this.dgvLiveData.AllowUserToDeleteRows = false;
            this.dgvLiveData.ReadOnly = true;
            this.dgvLiveData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colLiveCode.HeaderText = "代码";      this.colLiveCode.Name = "colLiveCode";
            this.colLiveName.HeaderText = "名称";      this.colLiveName.Name = "colLiveName";
            this.colLiveCurrent.HeaderText = "现价";   this.colLiveCurrent.Name = "colLiveCurrent";
            this.colLiveOpen.HeaderText = "今开";      this.colLiveOpen.Name = "colLiveOpen";
            this.colLivePreClose.HeaderText = "昨收";  this.colLivePreClose.Name = "colLivePreClose";
            this.colLiveHigh.HeaderText = "最高";      this.colLiveHigh.Name = "colLiveHigh";
            this.colLiveLow.HeaderText = "最低";       this.colLiveLow.Name = "colLiveLow";
            this.colLiveVol.HeaderText = "成交量";     this.colLiveVol.Name = "colLiveVol";
            this.colLiveTurnover.HeaderText = "成交额"; this.colLiveTurnover.Name = "colLiveTurnover";
            this.colLiveDate.HeaderText = "交易日期";  this.colLiveDate.Name = "colLiveDate";
            this.colLiveTime.HeaderText = "交易时间";  this.colLiveTime.Name = "colLiveTime";
            this.dgvLiveData.Columns.AddRange(
                colLiveCode, colLiveName, colLiveCurrent, colLiveOpen, colLivePreClose,
                colLiveHigh, colLiveLow, colLiveVol, colLiveTurnover, colLiveDate, colLiveTime);

            this.tabCollect.Controls.Add(this.dgvLiveData);
            this.tabCollect.Controls.Add(this.panelCollectSettings);

            // ==============================================================
            // Tab 3: 数据存档
            // ==============================================================
            this.tabArchive.Text = "数据存档";
            this.tabArchive.Padding = new System.Windows.Forms.Padding(5);

            this.panelArchiveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelArchiveSettings.Height = 135;

            this.lblIntervalArchive.Text = "存档间隔(秒):"; this.lblIntervalArchive.Location = new System.Drawing.Point(10, 12); this.lblIntervalArchive.AutoSize = true;
            this.nudArchiveInterval.Location = new System.Drawing.Point(110, 9); this.nudArchiveInterval.Size = new System.Drawing.Size(70, 23);
            this.nudArchiveInterval.Minimum = 5; this.nudArchiveInterval.Maximum = 86400; this.nudArchiveInterval.Value = 60;
            this.lblSecArchive.Text = "秒"; this.lblSecArchive.Location = new System.Drawing.Point(185, 12); this.lblSecArchive.AutoSize = true;

            this.lblArchiveDir.Text = "存档目录:"; this.lblArchiveDir.Location = new System.Drawing.Point(10, 45); this.lblArchiveDir.AutoSize = true;
            this.txtArchiveDir.Location = new System.Drawing.Point(80, 42); this.txtArchiveDir.Size = new System.Drawing.Size(350, 23);
            this.btnBrowseArchiveDir.Text = "浏览"; this.btnBrowseArchiveDir.Location = new System.Drawing.Point(440, 41); this.btnBrowseArchiveDir.Size = new System.Drawing.Size(60, 25);
            this.btnBrowseArchiveDir.Click += new System.EventHandler(this.btnBrowseArchiveDir_Click);

            this.btnStartArchive.Text = "开始存档"; this.btnStartArchive.Size = new System.Drawing.Size(90, 30); this.btnStartArchive.Location = new System.Drawing.Point(10, 75);
            this.btnStopArchive.Text = "停止存档";  this.btnStopArchive.Size = new System.Drawing.Size(90, 30); this.btnStopArchive.Location = new System.Drawing.Point(110, 75); this.btnStopArchive.Enabled = false;
            this.btnArchiveNow.Text = "立即存档";   this.btnArchiveNow.Size = new System.Drawing.Size(90, 30); this.btnArchiveNow.Location = new System.Drawing.Point(210, 75);
            this.btnStartArchive.Click += new System.EventHandler(this.btnStartArchive_Click);
            this.btnStopArchive.Click += new System.EventHandler(this.btnStopArchive_Click);
            this.btnArchiveNow.Click += new System.EventHandler(this.btnArchiveNow_Click);

            this.lblLastArchive.Text = "最后存档：—"; this.lblLastArchive.Location = new System.Drawing.Point(10, 110); this.lblLastArchive.AutoSize = true;
            this.lblNextArchive.Text = "下次存档：—"; this.lblNextArchive.Location = new System.Drawing.Point(160, 110); this.lblNextArchive.AutoSize = true;

            this.panelArchiveSettings.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblIntervalArchive, nudArchiveInterval, lblSecArchive,
                lblArchiveDir, txtArchiveDir, btnBrowseArchiveDir,
                btnStartArchive, btnStopArchive, btnArchiveNow,
                lblLastArchive, lblNextArchive
            });

            this.rtbArchiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbArchiveLog.ReadOnly = true;
            this.rtbArchiveLog.BackColor = System.Drawing.Color.Black;
            this.rtbArchiveLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.rtbArchiveLog.Font = new System.Drawing.Font("Consolas", 9F);

            this.tabArchive.Controls.Add(this.rtbArchiveLog);
            this.tabArchive.Controls.Add(this.panelArchiveSettings);

            // ==============================================================
            // Tab 4: 数据加载
            // ==============================================================
            this.tabLoader.Text = "数据加载";
            this.tabLoader.Padding = new System.Windows.Forms.Padding(5);

            this.panelLoadTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoadTop.Height = 45;

            this.txtLoadPath.Location = new System.Drawing.Point(5, 10); this.txtLoadPath.Size = new System.Drawing.Size(400, 23);
            this.btnBrowseFile.Text = "浏览文件"; this.btnBrowseFile.Location = new System.Drawing.Point(415, 9); this.btnBrowseFile.Size = new System.Drawing.Size(80, 25);
            this.btnBrowseDir.Text = "浏览目录";  this.btnBrowseDir.Location = new System.Drawing.Point(505, 9); this.btnBrowseDir.Size = new System.Drawing.Size(80, 25);
            this.btnLoad.Text = "加载";           this.btnLoad.Location = new System.Drawing.Point(595, 9); this.btnLoad.Size = new System.Drawing.Size(60, 25);
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.panelLoadTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtLoadPath, btnBrowseFile, btnBrowseDir, btnLoad
            });

            this.lblLoadStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLoadStatus.Height = 22;
            this.lblLoadStatus.Text = "请选择文件或目录后点击加载。";

            // Load data grid
            this.dgvLoadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoadData.AllowUserToAddRows = false;
            this.dgvLoadData.AllowUserToDeleteRows = false;
            this.dgvLoadData.ReadOnly = true;
            this.dgvLoadData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colLdCode.HeaderText = "代码";      this.colLdCode.Name = "colLdCode";
            this.colLdName.HeaderText = "名称";      this.colLdName.Name = "colLdName";
            this.colLdCollectedAt.HeaderText = "采集时间"; this.colLdCollectedAt.Name = "colLdCollectedAt"; this.colLdCollectedAt.FillWeight = 120;
            this.colLdDate.HeaderText = "交易日期";  this.colLdDate.Name = "colLdDate";
            this.colLdTime.HeaderText = "交易时间";  this.colLdTime.Name = "colLdTime";
            this.colLdCurrent.HeaderText = "现价";   this.colLdCurrent.Name = "colLdCurrent";
            this.colLdOpen.HeaderText = "今开";      this.colLdOpen.Name = "colLdOpen";
            this.colLdPreClose.HeaderText = "昨收";  this.colLdPreClose.Name = "colLdPreClose";
            this.colLdHigh.HeaderText = "最高";      this.colLdHigh.Name = "colLdHigh";
            this.colLdLow.HeaderText = "最低";       this.colLdLow.Name = "colLdLow";
            this.colLdVol.HeaderText = "成交量";     this.colLdVol.Name = "colLdVol";
            this.colLdTurnover.HeaderText = "成交额"; this.colLdTurnover.Name = "colLdTurnover";
            this.colLdBuy1Vol.HeaderText = "买一量"; this.colLdBuy1Vol.Name = "colLdBuy1Vol";
            this.colLdBuy1Price.HeaderText = "买一价"; this.colLdBuy1Price.Name = "colLdBuy1Price";
            this.colLdSell1Vol.HeaderText = "卖一量"; this.colLdSell1Vol.Name = "colLdSell1Vol";
            this.colLdSell1Price.HeaderText = "卖一价"; this.colLdSell1Price.Name = "colLdSell1Price";
            this.colLdStatus.HeaderText = "状态码";  this.colLdStatus.Name = "colLdStatus"; this.colLdStatus.FillWeight = 50;
            this.dgvLoadData.Columns.AddRange(
                colLdCode, colLdName, colLdCollectedAt, colLdDate, colLdTime,
                colLdCurrent, colLdOpen, colLdPreClose, colLdHigh, colLdLow,
                colLdVol, colLdTurnover, colLdBuy1Vol, colLdBuy1Price,
                colLdSell1Vol, colLdSell1Price, colLdStatus);

            this.tabLoader.Controls.Add(this.dgvLoadData);
            this.tabLoader.Controls.Add(this.panelLoadTop);
            this.tabLoader.Controls.Add(this.lblLoadStatus);

            // ==============================================================
            // MainForm
            // ==============================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "股票数据实时采集存档系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ---- Tab Control ----
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStockMgr;
        private System.Windows.Forms.TabPage tabCollect;
        private System.Windows.Forms.TabPage tabArchive;
        private System.Windows.Forms.TabPage tabLoader;

        // ---- Tab 1 ----
        private System.Windows.Forms.DataGridView dgvStocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Panel panelStockButtons;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnEditStock;
        private System.Windows.Forms.Button btnDeleteStock;

        // ---- Tab 2 ----
        private System.Windows.Forms.Panel panelCollectSettings;
        private System.Windows.Forms.Label lblIntervalCollect;
        private System.Windows.Forms.NumericUpDown nudCollectInterval;
        private System.Windows.Forms.Label lblSecCollect;
        private System.Windows.Forms.Button btnStartCollect;
        private System.Windows.Forms.Button btnStopCollect;
        private System.Windows.Forms.Label lblCollectStatus;
        private System.Windows.Forms.Label lblLastCollect;
        private System.Windows.Forms.Label lblNextCollect;
        private System.Windows.Forms.Label lblCacheCount;
        private System.Windows.Forms.DataGridView dgvLiveData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLivePreClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveTurnover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveTime;

        // ---- Tab 3 ----
        private System.Windows.Forms.Panel panelArchiveSettings;
        private System.Windows.Forms.Label lblIntervalArchive;
        private System.Windows.Forms.NumericUpDown nudArchiveInterval;
        private System.Windows.Forms.Label lblSecArchive;
        private System.Windows.Forms.Label lblArchiveDir;
        private System.Windows.Forms.TextBox txtArchiveDir;
        private System.Windows.Forms.Button btnBrowseArchiveDir;
        private System.Windows.Forms.Button btnStartArchive;
        private System.Windows.Forms.Button btnStopArchive;
        private System.Windows.Forms.Button btnArchiveNow;
        private System.Windows.Forms.Label lblLastArchive;
        private System.Windows.Forms.Label lblNextArchive;
        private System.Windows.Forms.RichTextBox rtbArchiveLog;

        // ---- Tab 4 ----
        private System.Windows.Forms.Panel panelLoadTop;
        private System.Windows.Forms.TextBox txtLoadPath;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvLoadData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdCollectedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdPreClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdTurnover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdBuy1Vol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdBuy1Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdSell1Vol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdSell1Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLdStatus;
        private System.Windows.Forms.Label lblLoadStatus;
    }
}
