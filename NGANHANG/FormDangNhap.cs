using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class FormDangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int KetNoi_GOC()
        {
            if(conn_publisher !=null && conn_publisher.State == ConnectionState.Open)
            {
                conn_publisher.Close();
            }
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publsisher;
                conn_publisher.Open();
                return 1;
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở dữ liệu" + e.Message);
                return 0;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void GetDSPM(String cmd)
        {
            DataTable db = new DataTable();
            if ( conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(db);
            conn_publisher.Close();
            Program.bds_DSPM.DataSource = db;
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_GOC() == 0) return;
            GetDSPM("SELECT * FROM V_DS_PHANMANH");
            comboBoxChiNhanh.SelectedIndex = 1;
            comboBoxChiNhanh.SelectedIndex = 0;
            comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if(TextBoxTaiKhoan.Text.Trim() == "" || TextboxMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai định dạng", "", MessageBoxButtons.OK);
                TextBoxTaiKhoan.Focus();
                return;
            }
            Program.mlogin = TextBoxTaiKhoan.Text; Program.password = TextboxMatKhau.Text;
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "", MessageBoxButtons.OK);
                TextBoxTaiKhoan.Focus();
                return;
            }
            // connected
            Program.mChinhanh = comboBoxChiNhanh.SelectedIndex;
            // save account
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            // get profile account
            String str = "EXEC dbo.sp_Lay_Thong_Tin_NV_Tu_Login @TENLOGIN = N'" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(str);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            if (!Convert.IsDBNull(Program.username))
            {
                if (Program.KetNoi() == 0) return;
                String lenh = "EXEC dbo.sp_Check_Trang_Thai_Xoa @MANV = N'"+Program.username+"'";
                Program.myReader = Program.ExecSqlDataReader(lenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                int check = 0;
                check = int.Parse(Program.myReader.GetValue(0).ToString());
                if(check == 1)
                {
                    MessageBox.Show("Nhân viên đã nghỉ hoặc chuyển chi nhánh, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                    TextBoxTaiKhoan.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Account không có quyền truy cập dữ liệu", "", MessageBoxButtons.OK);
                TextBoxTaiKhoan.Focus();
                return;
            }
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Đăng nhập thành công", "Notification", MessageBoxButtons.OK);
            Program.frmChinh.MANV.Text = "Mã Nhân Viên : " + Program.username;
            Program.frmChinh.HOTEN.Text = "Họ Tên : " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "Nhóm : " + Program.mGroup;
            showMenu();


        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình", "Thông báo", MessageBoxButtons.YesNo);
            switch (rs)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                default:
                    return;
            }
            
        }

        private void showMenu()
        {
            Program.frmChinh.barButtonDangNhap.Enabled = false;
            Program.frmChinh.barButtonDangXuat.Enabled = true;
            Program.frmChinh.barButtonDKTaiKhoan.Enabled = true;
            Program.frmChinh.barButtonChuyenTien.Enabled = true;
            Program.frmChinh.barButtonGDGR.Enabled = true;
            Program.frmChinh.barButtonKhachHang.Enabled = true;
            Program.frmChinh.barButtonMoTaiKhoan.Enabled = true;
            Program.frmChinh.barButtonNhanVien.Enabled = true;
            Program.frmChinh.Visible = true;
            Program.Logout = false;
            this.Close();
        }
        private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.svname = comboBoxChiNhanh.SelectedValue.ToString();

            }
            catch (Exception) { }
        }
    }
}
