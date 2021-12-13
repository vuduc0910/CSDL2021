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
    public partial class FormChuyenTien : Form
    {
        String macn;
        Boolean flgAdd;
        int vitri = 0;
        public FormChuyenTien()
        {
            InitializeComponent();
        }

        private void gD_CHUYENTIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSCT);

        }

        private void FormChuyenTien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCT.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            DSCT.EnforceConstraints = false;
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DSCT.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'dSCT.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DSCT.TaiKhoan);
            // TODO: This line of code loads data into the 'dSCT.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DSCT.NhanVien);
            
            


            if (Program.mGroup == "NGANHANG")
            {
                comboBoxChiNhanh.Enabled = true;
                btnThem.Enabled =
                btnHieuChinh.Enabled =
                btnXoa.Enabled = false;
            }
            else
            {
                comboBoxChiNhanh.Enabled = false;
                btnThem.Enabled =
                btnHieuChinh.Enabled =
                btnXoa.Enabled = true;

            }
            panelControlDetail.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = false;
            if (bdsCT.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            try
            {
                macn = ((DataRowView)bdsCT[0])["MACN"].ToString();
            }
            catch
            {
                macn = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
            }
            this.dateEditNgayGD.Properties.EditMask = "dd/MM/yyyy";

        }

        private void gD_CHUYENTIENBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsCT.AddNew();
            flgAdd = true;
            int vitri = bdsNhanVien.Find("MANV", Program.username);
            if (vitri == -1 && comboBoxChiNhanh.SelectedValue.ToString() == macn)
            {
                MessageBox.Show("Nhân viên đăng nhập đang bị lỗi, vui lòng đăng nhập lại.", "Error Important", MessageBoxButtons.OK);
                foreach (Form f in Program.frmChinh.MdiChildren)
                    f.Close();
                Program.frmChinh.DangNhap();
                return;
            }
            else
            {
                cmbMaNhanVien.SelectedValue = Program.username;
            }
            panelControlDetail.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = true;
            chuyentienGridControl.Enabled = btnThem.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = false;
            dateEditNgayGD.Text = DateTime.Now.ToString();
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flgAdd)
            {
                bdsCT.EndEdit();
                bdsCT.RemoveCurrent();
                flgAdd = false;
            }
            else
            {
                bdsCT.CancelEdit();
                bdsCT.Position = vitri;
            }
            chuyentienGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
            btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
            if (bdsCT.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsCT.Position;
            chuyentienGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = true;
            txtSoTien.Enabled = txtSoTKC.Enabled = txtSoTKN.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try {
                this.gD_CHUYENTIENTableAdapter.Fill(this.DSCT.GD_CHUYENTIEN);
                this.nhanVienTableAdapter.Fill(this.DSCT.NhanVien);
                this.taiKhoanTableAdapter.Fill(this.DSCT.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn xoá giao dịch này không?", "Xác Nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsCT.RemoveCurrent();
                    bdsCT.ResetCurrentItem();
                    this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gD_CHUYENTIENTableAdapter.Update(this.DSCT.GD_CHUYENTIEN);
                    chuyentienGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
                    btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá giao dịch: " + ex.Message, "Error", MessageBoxButtons.OK);
                    this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gD_CHUYENTIENTableAdapter.Fill(this.DSCT.GD_CHUYENTIEN);

                }
                if (bdsCT.Count == 0)
                {
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
                }
            }

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtSoTKC.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản chuyển !!", "Erorr", MessageBoxButtons.OK);
                return;
            }
            if(txtSoTKN.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản nhận !!", "Erorr", MessageBoxButtons.OK);
                return;
            }
            if(txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển !!", "Erorr", MessageBoxButtons.OK);
                return;
            }
            if(int.Parse(txtSoTien.Text.Trim().Replace(",", "")) < 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển lớn hơn 0", "Erorr", MessageBoxButtons.OK);
                return;
            }
            if(txtSoTKC.Text.Trim() == txtSoTKN.Text.Trim())
            {
                MessageBox.Show("Tài khoản chuyển phải khác tài khoản chuyển !!", "Erorr", MessageBoxButtons.OK);
                return;
            }
            if (flgAdd)
            {

                if(Program.KetNoi() == 0)
                {
                    return;
                }
                int check = 0;
                String lenh = "EXEC dbo.sp_Kiem_Tra_STK @stk = N'" + txtSoTKC.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                check = int.Parse(Program.myReader.GetValue(0).ToString());
                if (check == -1)
                {
                    MessageBox.Show("Số tài khoản chuyển không tồn tại, vui lòng kiểm tra lại!", "ERROR", MessageBoxButtons.OK);
                    return;
                }
                if (check < int.Parse(txtSoTien.Text.Trim().Replace(",", "")))
                {
                    MessageBox.Show("Số dư trong tài khoản không đủ, vui lòng kiểm tra lại!", "ERROR", MessageBoxButtons.OK);
                    return;
                }
                txtSoDuTKC.Text = check.ToString();
                Program.myReader.Close();

                // TKN
                lenh = "EXEC dbo.sp_Kiem_Tra_STK @stk = N'" + txtSoTKN.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                check = int.Parse(Program.myReader.GetValue(0).ToString());
                if(check == -1)
                {                        
                    MessageBox.Show("Số tài khoản nhận không tồn tại, vui lòng kiểm tra lại!", "ERROR", MessageBoxButtons.OK);
                    return;                        
                }
                txtSODUTKN.Text = check.ToString();
                Program.myReader.Close();
                lenh = "EXEC dbo.sp_chuyen_tien @stkc = N'"+ txtSoTKC.Text.Trim() + "', @stkn = N'"+ txtSoTKN.Text.Trim() + "', @st = "+ int.Parse(txtSoTien.Text.Trim().Replace(",", "")) + "";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                
            }
            try
            {

                bdsCT.EndEdit();
                bdsCT.ResetCurrentItem();
                this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_CHUYENTIENTableAdapter.Update(this.DSCT.GD_CHUYENTIEN);
                chuyentienGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
                btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_CHUYENTIENTableAdapter.Fill(this.DSCT.GD_CHUYENTIEN);
                return;
            }
            Program.conn.Close();
            Program.myReader.Close();
            flgAdd = false;
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
            Program.svname = comboBoxChiNhanh.SelectedValue.ToString();
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DSCT.GD_CHUYENTIEN);
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DSCT.TaiKhoan);
        }

        private void panelControlDetail_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
