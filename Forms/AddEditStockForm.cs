using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StockDatasCollection.Models;

namespace StockDatasCollection.Forms
{
    public partial class AddEditStockForm : Form
    {
        public StockCode Result { get; private set; }
        private readonly bool _isEdit;

        public AddEditStockForm(StockCode existing = null)
        {
            InitializeComponent();
            _isEdit = existing != null;

            if (_isEdit)
            {
                this.Text = "编辑股票";
                txtCode.Text = existing.Code;
                txtCode.ReadOnly = true;
                txtNotes.Text = existing.Notes;
            }
            else
            {
                this.Text = "添加股票";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim().ToLower();
            if (!Regex.IsMatch(code, @"^(sh|sz)\d{6}$"))
            {
                MessageBox.Show("股票代码格式无效。\n格式: sh/sz + 6位数字，例如 sh600519 或 sz002463",
                    "格式错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new StockCode
            {
                Code = code,
                Notes = txtNotes.Text.Trim()
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
