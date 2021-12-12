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
    public partial class FormReportTaiKhoan : Form
    {
        String macn;
        public FormReportTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormReportTaiKhoan_Load(object sender, EventArgs e)
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
            this.dateEditFrom.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditTo.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEditFrom.Text = DateTime.Now.ToString();
            dateEditTo.Text = DateTime.Now.ToString();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            String dateFrom =  dateEditFrom.Text;
            String dateFromConverted = DateTime.ParseExact(dateEditFrom.Text + " 00:00:00,000", "dd/MM/yyyy HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
            String dateTo = dateEditTo.Text;
            String dateToConverted = DateTime.ParseExact(dateEditTo.Text + " 00:00:00,000", "dd/MM/yyyy HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
            String mcn = checkBoxAllStore.Checked ? "ALL" : macn;
            XtraReportTaiKhoan rpt = new XtraReportTaiKhoan(mcn, dateFromConverted, dateToConverted);
            rpt.xrLabelTieuDe.Text = "DANH SÁCH LẬP TÀI KHOẢN TỪ "+dateFrom+" ĐẾN "+dateTo+" CỦA" + (checkBoxAllStore.Checked ? " TOÀN BỘ CÁC CHI NHÁNH" : " CHI NHÁNH " + macn);
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

        private void checkBoxAllStore_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAllStore.Checked == true)
            {
                comboBoxChiNhanh.Enabled = false;
            }
            else
            {
                if (Program.mGroup == "NGANHANG")
                {
                    comboBoxChiNhanh.Enabled = true;
                }
                else
                {
                    comboBoxChiNhanh.Enabled = false;

                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
