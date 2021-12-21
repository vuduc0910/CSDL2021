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
    public partial class FormNhanVien : Form
    {
        String macn;
        Boolean flgAdd = false;
        int vitri = 0;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNhanVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSNV);

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSNV.V_PHAI' table. You can move, or remove it, as needed.
            
            DSNV.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DSNV.GD_GOIRUT);
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DSNV.GD_CHUYENTIEN);
            this.v_PHAITableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_PHAITableAdapter.Fill(this.DSNV.V_PHAI);
            try {
                macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            }
            catch
            {
                foreach (Form f in Program.frmChinh.MdiChildren)
                    f.Close();
                Program.frmChinh.DangNhap();
                return;
            }
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "NGANHANG")
            {
                comboBoxChiNhanh.Enabled = true;
                btnThem.Enabled = 
                btnPhucHoi.Enabled = 
                btnLuu.Enabled = 
                btnHieuChinh.Enabled = btnChuyenNhanVien.Enabled =
                btnXoa.Enabled = false;
            }
            else
            {
                comboBoxChiNhanh.Enabled = false;
                btnThem.Enabled = 
                
                btnHieuChinh.Enabled = btnChuyenNhanVien.Enabled =
                btnXoa.Enabled = true;
                btnPhucHoi.Enabled =
                btnLuu.Enabled = false;


            }
            groupBox1.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = false; 
        }

        private void pHAICheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pHAILabel_Click(object sender, EventArgs e)
        {

        }

        private void dIACHITextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dIACHILabel_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNhanVien.Position;
            groupBox1.Enabled = true;
            bdsNhanVien.AddNew();
            txtMaCN.Text = macn;
            cmbPhai.SelectedIndex = 0;
            if (macn == "BENTHANH  ")
            {
                txtMaNV.Text = (bdsNhanVien.Count * 2 - 1).ToString();
            }
            else
            {
                txtMaNV.Text = (bdsNhanVien.Count * 2).ToString();
            }
            btnChuyenNhanVien.Enabled = btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = false;
            btnPhucHoi.Enabled = btnLuu.Enabled = true;
            nhanVienGridControl.Enabled = false;
            trangThaiXoaCheckBox.Checked = false;
            trangThaiXoaCheckBox.Enabled = false;
            flgAdd = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (flgAdd)
            {
                bdsNhanVien.EndEdit();
                bdsNhanVien.RemoveCurrent();
                flgAdd = false;
            }
            else
            {
                bdsNhanVien.Position = vitri;
                bdsNhanVien.CancelEdit();
            }
            nhanVienGridControl.Enabled = true;
            groupBox1.Enabled = false;
            btnChuyenNhanVien.Enabled = btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = true;
            btnLuu.Enabled = btnPhucHoi.Enabled = false;
            if (bdsNhanVien.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
        }

        private void cmbPhai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pHAIRadioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pHAILabel_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Vui long nhap ho", "ERROR", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if(txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui long nhap ten", "ERROR", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if(txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Vui long nhap SDT", "ERROR", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }
            if(!Program.IsNumber(txtSDT.Text.Trim()) || !Program.IsPhoneNumber(txtSDT.Text.Trim()))
            {

                MessageBox.Show("Vui long nhap dung dinh dang sdt", "ERROR", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }
            if(txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Vui long nhap dia chi", "ERROR", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            try
            {
                bdsNhanVien.EndEdit();
                bdsNhanVien.ResetCurrentItem();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.DSNV.NhanVien);
                groupBox1.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = false;
                btnChuyenNhanVien.Enabled = btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = nhanVienGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu data" + ex.Message , "ERROR", MessageBoxButtons.OK);
                this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
            }
            flgAdd = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNhanVien.Position;
            groupBox1.Enabled = true;
            btnChuyenNhanVien.Enabled = btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = false;
            btnLuu.Enabled = btnPhucHoi.Enabled = true;
            nhanVienGridControl.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload dữ liệu :" + ex.Message, "ERROR", MessageBoxButtons.OK);
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 manv = 0;
            if(bds_CT.Count > 0)
            {
                MessageBox.Show("Không thể xoá nhân viên vì đã có giao dịch chuyển tiền","ERROR", MessageBoxButtons.OK);
                return;
            }
            if (bds_GR.Count > 0)
            {
                MessageBox.Show("Không thể xoá nhân viên vì đã có giao dịch gởi rút", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xoá nhân viên này không?", "Xác Nhận", MessageBoxButtons.OKCancel) == DialogResult.OK
            )
            {
                try
                {
                    manv = int.Parse(((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString());
                    bdsNhanVien.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DSNV.NhanVien);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá nhân viên : "+ ex.Message, "ERROR", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
                    bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv);
                }
            }
            if(bdsNhanVien.Count == 0)
            {
                foreach (Form f in Program.frmChinh.MdiChildren)
                    f.Close();
                Program.frmChinh.DangNhap();
                return;
            }
        }

        private void btnChuyenNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(trangThaiXoaCheckBox.Checked == true)
            {
                MessageBox.Show(" Nhân viên này đã được chuyển qua chi nhánh khác?", "ERROR", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn chuyển nhân viên này không?", "Xác Nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //chuyen tran thai xoa
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                String sqlLenh = "EXEC dbo.sp_Chuyen_Trang_Thai_Xoa @MANV = N'" + txtMaNV.Text + "'";
                Program.myReader = Program.ExecSqlDataReader(sqlLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                Program.myReader.Close();


                //tao moi hoac chuyen trang thai xoa cho nhan vien
                String sv = Program.svname;
                Program.svname = Program.svChu;
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
                String cnht = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                String lenh = "EXEC dbo.sp_chuyen_nhan_vien @MANV = N'" + txtMaNV.Text + "', @MACNHT = N'" + cnht + "'";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                Program.svname = sv;
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
                if (Program.KetNoi() == 0)
                {
                    MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
                Program.myReader.Close();
                Program.conn.Close();
            }
        }

        private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView" || Program.Logout)
            {
                return;
            }
            if(comboBoxChiNhanh.SelectedIndex != Program.mChinhanh)
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
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DSNV.NhanVien);
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.DSNV.GD_GOIRUT);
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.DSNV.GD_CHUYENTIEN);
            this.v_PHAITableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_PHAITableAdapter.Fill(this.DSNV.V_PHAI);
            Program.myReader.Close();
            Program.conn.Close();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
