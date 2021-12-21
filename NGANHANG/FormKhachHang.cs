using System;
using System.Data;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class FormKhachHang : Form
    {
        String macn;
        Boolean flgAdd = false;
        int vitri = 0;
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhachHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSKH);

        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSKH.V_PHAI' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dSKH.KhachHang' table. You can move, or remove it, as needed.
            DSKH.EnforceConstraints = false;
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DSKH.KhachHang);
            this.v_PHAITableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_PHAITableAdapter.Fill(this.DSKH.V_PHAI);
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
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
            if(bdsKhachHang.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            try
            {
                macn = ((DataRowView)bdsKhachHang[0])["MACN"].ToString();
            }
            catch
            {
                macn = ((DataRowView)Program.bds_DSPM[Program.mChinhanh])["TENCN"].ToString();
            }
            this.dateEditNgayCap.Properties.EditMask = "dd/MM/yyyy";
            this.dateEditNgayCap.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControlDetail.Enabled = btnLuu.Enabled = btnPhucHoi.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnHieuChinh.Enabled = false;
            vitri = bdsKhachHang.Position;
            bdsKhachHang.AddNew();
            if (macn == "System.Data.DataRowView")
            {
                txtMaCN.Text = comboBoxChiNhanh.SelectedIndex.ToString();
            }
            else
            {
                txtMaCN.Text = macn;
            }
            cmbPhai.SelectedIndex = 0;
            khachHangGridControl.Enabled = false;
            flgAdd = true;

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //bdsKhachHang.CancelEdit();
            if (flgAdd)
            {
                bdsKhachHang.EndEdit();
                bdsKhachHang.RemoveCurrent(); 
                flgAdd = false;
            }
            else
            {
                bdsKhachHang.Position = vitri;
                bdsKhachHang.CancelEdit();
            }
            btnLuu.Enabled = btnPhucHoi.Enabled = panelControlDetail.Enabled =false;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = khachHangGridControl.Enabled = true;
            if (bdsKhachHang.Count == 0)
            {
                btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKhachHang.Position;
            btnLuu.Enabled = btnPhucHoi.Enabled = panelControlDetail.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = khachHangGridControl.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khachHangTableAdapter.Fill(this.DSKH.KhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload dữ liệu :" + ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String cmnd = "";
           if(MessageBox.Show("Bạn có chắc chắn xoá khách hàng này không?", "Xác Nhận" , MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    cmnd = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString();
                    bdsKhachHang.RemoveCurrent();
                    this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khachHangTableAdapter.Update(this.DSKH.KhachHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá khách  hàng :" + ex.Message, "ERROR", MessageBoxButtons.OK);
                    this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khachHangTableAdapter.Fill(this.DSKH.KhachHang);
                    bdsKhachHang.Position = bdsKhachHang.Find("CMND", cmnd);
                }
                if(bdsKhachHang.Count == 0)
                {
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           if(txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Chứng minh nhân dân không thể để trống", "ERROR", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if (!Program.IsNumber(txtCMND.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cmnd", "ERROR", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
           if(txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ không thể để trống", "ERROR", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không thể để trống", "ERROR", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("SDT không thể để trống", "ERROR", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }
            if (!Program.IsNumber(txtSDT.Text.Trim()) || !Program.IsPhoneNumber(txtSDT.Text.Trim()))
            {

                MessageBox.Show("Vui long nhap dung dinh dang so dien thoai", "ERROR", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không thể để trống", "ERROR", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if(dateEditNgayCap.Text.Trim() == "")
            {
                MessageBox.Show("Ngày cấp không thể để trống", "ERROR", MessageBoxButtons.OK);
                dateEditNgayCap.Focus();
                return;
            }
            if (Program.KetNoi() == 0) {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (flgAdd)
            {
                String lenh = "EXEC dbo.sp_Check_CMND @CMND = N'" + txtCMND.Text.Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                int check = 0;
                check = int.Parse(Program.myReader.GetValue(0).ToString());
                if (check == 1)
                {
                    MessageBox.Show("Số chứng minh nhân dân này đã được tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (check == 2)
                {
                    MessageBox.Show("Số chứng minh nhân dân này đã được tạo ở chi nhánh khác", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                Program.myReader.Close();
                Program.conn.Close();
            }
            try
            {
                bdsKhachHang.EndEdit();
                bdsKhachHang.ResetCurrentItem();
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Update(this.DSKH.KhachHang);
                btnLuu.Enabled = btnPhucHoi.Enabled = panelControlDetail.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = btnReload.Enabled = khachHangGridControl.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu data" + ex.Message, "ERROR", MessageBoxButtons.OK);
                this.khachHangTableAdapter.Fill(this.DSKH.KhachHang);
            }
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
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.DSKH.KhachHang);
            this.v_PHAITableAdapter.Connection.ConnectionString = Program.connstr;
            this.v_PHAITableAdapter.Fill(this.DSKH.V_PHAI);
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
