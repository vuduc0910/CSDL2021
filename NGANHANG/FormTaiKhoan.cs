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
    public partial class FormTaiKhoan : Form
    {
        Boolean flgAdd = false;
        int vitri = 0;
        public FormTaiKhoan()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTaiKhoan.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSTK);

        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            DSTK.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dSTK.TaiKhoan' table. You can move, or remove it, as needed.
            this.tableAdapterManager.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DSTK.TaiKhoan);
            // TODO: This line of code loads data into the 'dSTK.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DSTK.GD_GOIRUT);
            // TODO: This line of code loads data into the 'dSTK.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DSTK.GD_CHUYENTIEN);
            cmbMaChiNhanh.DataSource = Program.bds_DSPM;
            cmbMaChiNhanh.DisplayMember = "TENCN";
            cmbMaChiNhanh.ValueMember = "TENCN";
            if (Program.mGroup == "NGANHANG")
            {
               
                btnThem.Enabled =
                btnHieuChinh.Enabled =
                btnXoa.Enabled = false;
            }
            else
            {
                
                btnThem.Enabled =
                btnHieuChinh.Enabled =
                btnXoa.Enabled = true;

            }
            panelControlDetail.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = false;
            if (bdsTaiKhoan.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối với server", "ERROR", MessageBoxButtons.OK);
                return;
            }
            Program.myReader = Program.ExecSqlDataReader("EXEC dbo.sp_Check_MATK ");
            if(Program.myReader == null)
            {
                return;
            }
            Program.myReader.Read();
            int matk = int.Parse(Program.myReader.GetValue(0).ToString());
            bdsTaiKhoan.AddNew();
            txtSTK.Text = matk.ToString();
            panelControlDetail.Enabled = btnPhucHoi.Enabled = btnLuu.Enabled =flgAdd = true;
            taiKhoanGridControl.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = false;
            cmbMaChiNhanh.SelectedIndex = Program.mChinhanh;
            txtSoDu.Text = "0";
            Program.myReader.Close();
            Program.conn.Close();

        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsTaiKhoan.Position;
            panelControlDetail.Enabled = btnPhucHoi.Enabled = btnLuu.Enabled = true;
            taiKhoanGridControl.Enabled = btnThem.Enabled =  btnXoa.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flgAdd)
            {
                bdsTaiKhoan.EndEdit();
                bdsTaiKhoan.RemoveCurrent();
                flgAdd = false;
            }
            else
            {
                bdsTaiKhoan.CancelEdit();
                bdsTaiKhoan.Position = vitri;
            }
            panelControlDetail.Enabled = btnPhucHoi.Enabled = btnLuu.Enabled = false;
            taiKhoanGridControl.Enabled = btnThem.Enabled =  btnXoa.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = true;
            bdsTaiKhoan.Position = vitri;
            if (bdsTaiKhoan.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DSTK.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu data" + ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String cmnd = "";
            if(bdsChuyenTienDen.Count > 0 || bdsChuyenTienDi.Count > 0 || bdsGuiRut.Count > 0)
            {
                MessageBox.Show("Không thể xoá tài khoản này do tài khoản đã thực hiện giao dịch", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if(MessageBox.Show("Bạn có chắc chắn xoá khách hàng này không?", "Xác Nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    cmnd = ((DataRowView)bdsTaiKhoan[bdsTaiKhoan.Position])["CMND"].ToString();
                    bdsTaiKhoan.RemoveCurrent();
                    this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.taiKhoanTableAdapter.Update(this.DSTK.TaiKhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xOá nhân viên: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                    this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.taiKhoanTableAdapter.Fill(this.DSTK.TaiKhoan);
                    bdsTaiKhoan.Position = bdsTaiKhoan.Find("CMND", cmnd);
                }
                if(bdsTaiKhoan.Count == 0)
                {
                    btnXoa.Enabled = false;
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập chứng minh nhân dân của khách hàng!", "ERROR", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if(int.Parse(txtSoDu.Text.Trim().Replace(",","")) <0)
            {
                MessageBox.Show("Vui lòng nhập  số dư của khách hàng >= 0đ!", "ERROR", MessageBoxButtons.OK);
                txtSoDu.Focus();
                return;
            }
            try
            {
                bdsTaiKhoan.EndEdit();
                bdsTaiKhoan.ResetCurrentItem();
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Update(this.DSTK.TaiKhoan);
                panelControlDetail.Enabled = btnPhucHoi.Enabled = btnLuu.Enabled = false;
                taiKhoanGridControl.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu data: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.DSTK.TaiKhoan);
            }
            flgAdd = false;
        }
    }
}
