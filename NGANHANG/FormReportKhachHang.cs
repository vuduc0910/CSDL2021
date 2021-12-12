using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class FormReportKhachHang : Form
    {
        String macn;
        public FormReportKhachHang()
        {
            InitializeComponent();
        }

        private void FormReportKhachHang_Load(object sender, EventArgs e)
        {
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                comboBoxChiNhanh.Enabled = true;
            }
            else
            {
                comboBoxChiNhanh.Enabled = false;

            }
            macn = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            XtraReportKhachHang rpt = new XtraReportKhachHang(macn);
            rpt.xrLabelTieuDe.Text = "DANH SÁCH KHÁCH HÀNG CỦA CHI NHÁNH " + macn;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView" || Program.Logout)
            {
                return;
            }
            if (comboBoxChiNhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;

            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            macn = ((DataRowView)Program.bds_DSPM[comboBoxChiNhanh.SelectedIndex])["TENCN"].ToString();
            Program.svname = comboBoxChiNhanh.SelectedValue.ToString();
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
