using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using StockDatasCollection.IO;
using StockDatasCollection.Models;
using StockDatasCollection.Services;

namespace StockDatasCollection.Forms
{
    public partial class MainForm : Form
    {
        // --- Services ---
        private readonly StockCodeManager _codeManager = new StockCodeManager();
        private readonly StockDataCollector _collector = new StockDataCollector();
        private readonly DataCacheService _cache = new DataCacheService();
        private readonly ArchiveService _archiver = new ArchiveService();

        // --- Timers ---
        private System.Timers.Timer _collectTimer;
        private bool _collecting;
        private DateTime? _lastCollectTime;
        private DateTime? _nextCollectTime;

        // UI refresh timer (runs on UI thread)
        private System.Windows.Forms.Timer _uiTimer;

        public MainForm()
        {
            InitializeComponent();
            _archiver.ArchiveCompleted += OnArchiveCompleted;
            _uiTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _uiTimer.Tick += OnUiTimerTick;
            _uiTimer.Start();
        }

        // ============================================================
        // Form Load
        // ============================================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshStockGrid();
            // Set default archive directory
            txtArchiveDir.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Archives");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _collectTimer?.Stop();
            _archiver.Stop();
            _uiTimer.Stop();
        }

        // ============================================================
        // Tab 1 — 股票管理
        // ============================================================
        private void RefreshStockGrid()
        {
            var stocks = _codeManager.GetAll();
            dgvStocks.Rows.Clear();
            for (int i = 0; i < stocks.Count; i++)
            {
                var s = stocks[i];
                dgvStocks.Rows.Add(i + 1, s.Code, s.Name, s.Notes);
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditStockForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _codeManager.Add(form.Result);
                        RefreshStockGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnEditStock_Click(object sender, EventArgs e)
        {
            if (dgvStocks.CurrentRow == null) return;
            string code = dgvStocks.CurrentRow.Cells["colCode"].Value?.ToString();
            var existing = _codeManager.GetAll().Find(s => s.Code == code);
            if (existing == null) return;

            using (var form = new AddEditStockForm(existing))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var updated = new StockCode
                        {
                            Code = existing.Code,
                            Name = existing.Name,
                            Notes = form.Result.Notes
                        };
                        _codeManager.Update(updated);
                        RefreshStockGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDeleteStock_Click(object sender, EventArgs e)
        {
            if (dgvStocks.CurrentRow == null) return;
            string code = dgvStocks.CurrentRow.Cells["colCode"].Value?.ToString();
            if (string.IsNullOrEmpty(code)) return;

            var answer = MessageBox.Show($"确认删除股票 {code}？",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                _codeManager.Remove(code);
                RefreshStockGrid();
            }
        }

        // ============================================================
        // Tab 2 — 数据采集
        // ============================================================
        private void btnStartCollect_Click(object sender, EventArgs e)
        {
            var codes = _codeManager.GetAll();
            if (codes.Count == 0)
            {
                MessageBox.Show("请先添加关注的股票代码。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int interval = (int)nudCollectInterval.Value;
            _collectTimer?.Stop();
            _collectTimer = new System.Timers.Timer(interval * 1000.0);
            _collectTimer.Elapsed += (s, ev) => DoCollect();
            _collectTimer.AutoReset = true;
            _collectTimer.Start();

            _nextCollectTime = DateTime.Now.AddSeconds(interval);
            lblCollectStatus.Text = "状态：采集中";
            btnStartCollect.Enabled = false;
            btnStopCollect.Enabled = true;

            // Trigger one immediate collection
            DoCollect();
        }

        private void btnStopCollect_Click(object sender, EventArgs e)
        {
            _collectTimer?.Stop();
            _collectTimer = null;
            _nextCollectTime = null;
            lblCollectStatus.Text = "状态：已停止";
            btnStartCollect.Enabled = true;
            btnStopCollect.Enabled = false;
        }

        private async void DoCollect()
        {
            if (_collecting) return;
            _collecting = true;
            try
            {
                var codes = _codeManager.GetAll();
                if (codes.Count == 0) return;

                var points = await _collector.FetchAsync(codes);
                _cache.AddRange(points);
                _lastCollectTime = DateTime.Now;
                _nextCollectTime = DateTime.Now.AddSeconds((int)nudCollectInterval.Value);

                // Auto-update stock names
                foreach (var p in points)
                    _codeManager.UpdateName(p.StockCode, p.StockName);
            }
            catch (Exception ex)
            {
                // Log collection error without crashing
                AppendArchiveLog($"[{DateTime.Now:HH:mm:ss}] 采集错误: {ex.Message}");
            }
            finally
            {
                _collecting = false;
            }
        }

        // ============================================================
        // Tab 3 — 数据存档
        // ============================================================
        private void btnBrowseArchiveDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = txtArchiveDir.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtArchiveDir.Text = dlg.SelectedPath;
            }
        }

        private void btnStartArchive_Click(object sender, EventArgs e)
        {
            _archiver.ArchiveIntervalSeconds = (int)nudArchiveInterval.Value;
            _archiver.ArchiveDirectory = txtArchiveDir.Text;
            _archiver.Start(_cache);
            btnStartArchive.Enabled = false;
            btnStopArchive.Enabled = true;
            AppendArchiveLog($"[{DateTime.Now:HH:mm:ss}] 存档已启动，间隔 {_archiver.ArchiveIntervalSeconds} 秒。");
        }

        private void btnStopArchive_Click(object sender, EventArgs e)
        {
            _archiver.Stop();
            btnStartArchive.Enabled = true;
            btnStopArchive.Enabled = false;
            AppendArchiveLog($"[{DateTime.Now:HH:mm:ss}] 存档已停止。");
        }

        private void btnArchiveNow_Click(object sender, EventArgs e)
        {
            _archiver.ArchiveDirectory = txtArchiveDir.Text;
            try
            {
                _archiver.ArchiveNow(_cache);
            }
            catch (Exception ex)
            {
                AppendArchiveLog($"[{DateTime.Now:HH:mm:ss}] 手动存档失败: {ex.Message}");
            }
        }

        private void OnArchiveCompleted(object sender, string message)
        {
            // Marshal to UI thread
            if (InvokeRequired)
                BeginInvoke(new Action(() => AppendArchiveLog(message)));
            else
                AppendArchiveLog(message);
        }

        private void AppendArchiveLog(string msg)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => AppendArchiveLog(msg))); return; }
            rtbArchiveLog.AppendText(msg + Environment.NewLine);
            rtbArchiveLog.ScrollToCaret();
        }

        // ============================================================
        // Tab 4 — 数据加载
        // ============================================================
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Archive files (*.bin)|*.bin|All files (*.*)|*.*";
                dlg.InitialDirectory = txtLoadPath.Text.Length > 0
                    ? Path.GetDirectoryName(txtLoadPath.Text)
                    : _archiver.ArchiveDirectory;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtLoadPath.Text = dlg.FileName;
            }
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = txtArchiveDir.Text;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    txtLoadPath.Text = dlg.SelectedPath;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = txtLoadPath.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请先选择文件或目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var loader = new ArchiveDataLoader();
            List<StockDataPoint> points;
            List<string> errors = new List<string>();

            try
            {
                if (File.Exists(path))
                {
                    points = loader.Load(path);
                }
                else if (Directory.Exists(path))
                {
                    var result = loader.LoadDirectory(path);
                    points = result.Item1;
                    errors = result.Item2;
                }
                else
                {
                    MessageBox.Show("路径不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateLoadGrid(points);
            string summary = $"共加载 {points.Count} 条记录。";
            if (errors.Count > 0) summary += $" {errors.Count} 个文件读取失败。";
            lblLoadStatus.Text = summary;

            if (errors.Count > 0)
                MessageBox.Show("以下文件读取失败：\n" + string.Join("\n", errors),
                    "部分错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PopulateLoadGrid(List<StockDataPoint> points)
        {
            dgvLoadData.Rows.Clear();
            foreach (var p in points)
            {
                dgvLoadData.Rows.Add(
                    p.StockCode, p.StockName,
                    p.CollectedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    p.TradeDate, p.TradeTime,
                    p.CurrentPrice, p.OpenPrice, p.PreClosePrice,
                    p.HighPrice, p.LowPrice,
                    p.Volume, p.Turnover,
                    p.Buy1Vol, p.Buy1Price,
                    p.Sell1Vol, p.Sell1Price,
                    p.StatusCode);
            }
        }

        // ============================================================
        // UI Refresh Timer (1 second tick)
        // ============================================================
        private void OnUiTimerTick(object sender, EventArgs e)
        {
            // Tab 2: update status labels
            if (_lastCollectTime.HasValue)
                lblLastCollect.Text = "最后采集：" + _lastCollectTime.Value.ToString("HH:mm:ss");
            if (_nextCollectTime.HasValue)
                lblNextCollect.Text = "下次采集：" + _nextCollectTime.Value.ToString("HH:mm:ss");

            lblCacheCount.Text = "缓存记录：" + _cache.GetTotalCount();

            // Refresh live data grid on Tab 2
            RefreshLiveDataGrid();

            // Tab 3: archive status
            if (_archiver.LastArchiveTime.HasValue)
                lblLastArchive.Text = "最后存档：" + _archiver.LastArchiveTime.Value.ToString("HH:mm:ss");
            if (_archiver.NextArchiveTime.HasValue)
                lblNextArchive.Text = "下次存档：" + _archiver.NextArchiveTime.Value.ToString("HH:mm:ss");
        }

        private void RefreshLiveDataGrid()
        {
            var latest = _cache.GetLatestPerStock();
            dgvLiveData.Rows.Clear();
            foreach (var p in latest)
            {
                dgvLiveData.Rows.Add(
                    p.StockCode, p.StockName,
                    p.CurrentPrice, p.OpenPrice, p.PreClosePrice,
                    p.HighPrice, p.LowPrice,
                    p.Volume, p.Turnover,
                    p.TradeDate, p.TradeTime);
            }
        }
    }
}
