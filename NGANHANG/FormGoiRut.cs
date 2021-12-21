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
    public partial class FormGoiRut : Form
    {
        String macn;
        Boolean flgAdd;
        int vitri = 0;
        public FormGoiRut()
        {
            InitializeComponent();
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
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DSGR.GD_GOIRUT);
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DSGR.TaiKhoan);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gD_GOIRUTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGR.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSGR);

        }

        private void FormGoiRut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSGR.NhanVien' table. You can move, or remove it, as needed.

            DSGR.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DSGR.V_NHAN_VIEN' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DSGR.GD_GOIRUT);
            // TODO: This line of code loads data into the 'DSGR.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.DSGR.TaiKhoan);
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DSGR.NhanVien);
            // TODO: This line of code loads data into the 'DSGR.NhanVien' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dSGR.GD_GOIRUT' table. You can move, or remove it, as needed.
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
            if (bdsGR.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            try
            {
                macn = ((DataRowView)bdsGR[0])["MACN"].ToString();
            }
            catch {
                macn = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
            }
            this.dateEditNgayGD.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditNgayGD.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void mANVLabel_Click(object sender, EventArgs e)
        {

        }

        private void mANVTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGR.AddNew();
            int vitri = bdsNhanVien.Find("MANV", Program.username);
            if(vitri == -1 && comboBoxChiNhanh.SelectedValue.ToString() == macn)
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
            
            dateEditNgayGD.Text = DateTime.Now.ToString();
            goirutGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = flgAdd = true;
             cmbSoTK.SelectedIndex = 0;
            cmbLoaiGD.SelectedIndex = 1;
            cmbLoaiGD.SelectedIndex = 0;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            goirutGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = true;
            vitri = bdsGR.Position;
            cmbLoaiGD.Enabled = cmbSoTK.Enabled = txtSoTien.Enabled = false;
            
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            
            if (flgAdd)
            {
                bdsGR.EndEdit();
                bdsGR.RemoveCurrent();
                flgAdd = false;
            }
            else
            {
                bdsGR.CancelEdit();
                bdsGR.Position = vitri;
            }
            goirutGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
            btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
            cmbLoaiGD.Enabled = cmbSoTK.Enabled = txtSoTien.Enabled = true;
            cmbLoaiGD.SelectedIndex = 1;
            cmbLoaiGD.SelectedIndex = 0;
            if (bdsGR.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(cmbSoTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn số tài khoản " , "ERROR", MessageBoxButtons.OK);
                return;
            }
            if(txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn số tiền ", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if(!Program.IsNumber(txtSoTien.Text.Trim().Replace(",", "")))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền ", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if(int.Parse(txtSoTien.Text.Trim().Replace(",", "")) < 100000)
            {
                MessageBox.Show("Vui lòng chọn số tiền >= 100,000 ", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if(Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối vui lòng thử lại!", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (flgAdd)
            {
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
                if (check < int.Parse(txtSoTien.Text.Trim().Replace(",", "")) && cmbLoaiGD.Text == "RT")
                {
                    MessageBox.Show("Số dư trong tài khoản không đủ, vui lòng kiểm tra lại!", "ERROR", MessageBoxButtons.OK);
                    return;
                }
;                Program.myReader.Close();
                try
                {
                    int sotien = int.Parse(txtSoTien.Text.Trim().Replace(",", ""));
                    sotien = cmbLoaiGD.Text == "RT" ? 0 - sotien : sotien;
                    sqlLenh = "dbo.sp_Goi_Rut_Tien @stk = N'" + cmbSoTK.Text.Trim() + "', @sotien = " + sotien + "";
                    Program.myReader = Program.ExecSqlDataReader(sqlLenh);
                    Program.myReader.Read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                    return;
                }
                Program.myReader.Close();
                Program.conn.Close();
                txtSODU.Text = check.ToString();
            }
            try
            {
                bdsGR.EndEdit();
                bdsGR.ResetCurrentItem();
                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Update(this.DSGR.GD_GOIRUT);
                goirutGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
                btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DSGR.GD_GOIRUT);
                return;
            }
            cmbLoaiGD.SelectedIndex = 1;
            cmbLoaiGD.SelectedIndex = 0;
            cmbLoaiGD.Enabled = cmbSoTK.Enabled = txtSoTien.Enabled = true;
            flgAdd = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.gD_GOIRUTTableAdapter.Fill(this.DSGR.GD_GOIRUT);
                this.taiKhoanTableAdapter.Fill(this.DSGR.TaiKhoan);
                this.nhanVienTableAdapter.Fill(this.DSGR.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload dữ liệu :" + ex.Message, "ERROR", MessageBoxButtons.OK);
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
                    bdsGR.RemoveCurrent();
                    bdsGR.ResetCurrentItem();
                    this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gD_GOIRUTTableAdapter.Update(this.DSGR.GD_GOIRUT);
                    goirutGridControl.Enabled = btnThem.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = btnXoa.Enabled = true;
                    btnPhucHoi.Enabled = btnLuu.Enabled = panelControlDetail.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá giao dịch: " + ex.Message, "Error", MessageBoxButtons.OK);
                    this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gD_GOIRUTTableAdapter.Fill(this.DSGR.GD_GOIRUT);

                }
                if (bdsGR.Count == 0)
                {
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
                }
            }
        }

        private void mANVComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mANVLabel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
