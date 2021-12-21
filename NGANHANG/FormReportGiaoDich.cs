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
    public partial class FormReportGiaoDich : Form
    {
        String macn;
        public FormReportGiaoDich()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTaiKhoan.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTK);

        }

        private void FormReportGiaoDich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSTK.TaiKhoan' table. You can move, or remove it, as needed.
            dSTK.EnforceConstraints = false;
            this.tableAdapterManager.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.dSTK.TaiKhoan);
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
                checkBoxAllStore.Enabled = false;

            }
            macn = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
            this.dateEditFrom.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditTo.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEditFrom.Text = DateTime.Now.ToString();
            dateEditTo.Text = DateTime.Now.ToString();
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
            if (checkBoxAllStore.Checked == true)
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
                    checkBoxAllStore.Enabled = false;

                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if(cmbSoTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tai khoản", "Error", MessageBoxButtons.OK);
                return;
            }
            string sqlLenh = "EXEC dbo.sp_Kiem_Tra_STK @stk = N'" + cmbSoTK.Text.Trim() + "'";
            int check = 0;
            Program.myReader = Program.ExecSqlDataReader(sqlLenh);
            Program.myReader.Read();
            check = int.Parse(Program.myReader.GetValue(0).ToString());
            if (check == -1)
            {
                MessageBox.Show("Số tài khoản không tồn tại, vui lòng kiểm tra lại!", "ERROR", MessageBoxButtons.OK);
                return;
            }
            Program.myReader.Close();
            //Program.conn.Close();
            String dateFrom = dateEditFrom.Text;
            String dateFromConverted = DateTime.ParseExact(dateEditFrom.Text + " 00:00:00,000", "dd/MM/yyyy HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
            String dateTo = dateEditTo.Text;
            String dateToConverted = DateTime.ParseExact(dateEditTo.Text + " 00:00:00,000", "dd/MM/yyyy HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy");
            String mcn = checkBoxAllStore.Checked ? "ALL" : macn;
            String stk = cmbSoTK.Text.Trim();
            XtraReportGiaoDich rpt = new XtraReportGiaoDich(mcn, dateFromConverted, dateToConverted, stk);
            //rpt.xrLabelTieuDe.Text = "DANH SÁCH LẬP TÀI KHOẢN TỪ " + dateFrom + " ĐẾN " + dateTo + " CỦA" + (checkBoxAllStore.Checked ? " TOÀN BỘ CÁC CHI NHÁNH" : " CHI NHÁNH " + macn);
            rpt.xrLabelTieuDe.Text = "DANH SÁCH GIAO DỊCH CỦA TÀI KHOẢN "+stk+" TỪ NGÀY "+dateFrom+" ĐẾN " + dateTo;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
