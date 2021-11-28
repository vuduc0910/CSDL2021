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
    public partial class FormDangKyTK : Form
    {
        private String cn;
        private int mCN;
        public static BindingSource bds_NV = new BindingSource();
        public FormDangKyTK()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormDangKyTK_Load(object sender, EventArgs e)
        {
            if (Program.mloginDN == "") return;
            cn = Program.svname;
            mCN = Program.mChinhanh;
            comboBoxChiNhanh.DataSource = Program.bds_DSPM;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            textBoxRole.Text = Program.mGroup;
            if(Program.mGroup == "CHINHANH")
            {
                comboBoxChiNhanh.Enabled = false;
                comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            }
            else
            {
                comboBoxChiNhanh.Enabled = true;
                comboBoxChiNhanh.SelectedIndex = Program.mChinhanh;
            }
            GetNV();
        }
        private void GetNV() {
            if (Program.mloginDN == "") return;
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            DataTable db = new DataTable();
            String sql = "SELECT * FROM dbo.V_NHAN_VIEN WHERE TRANGTHAIXOA = 0 ";
            SqlDataAdapter da = new SqlDataAdapter(sql, Program.conn);
            da.Fill(db);
            bds_NV.DataSource = db;
            comboBoxUsers.DataSource = bds_NV;
            comboBoxUsers.DisplayMember = "HOTEN";
            comboBoxUsers.ValueMember = "MANV";

        }
        private void comboBoxChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.Logout) return;
            if(comboBoxChiNhanh.SelectedIndex != mCN)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
                Program.svname = comboBoxChiNhanh.SelectedValue.ToString();
                GetNV();
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
                Program.svname = cn;
                GetNV();
            }
            
        }
        //button dang ki
        private void button1_Click(object sender, EventArgs e)
        {
            String userName = comboBoxUsers.SelectedValue.ToString();
            if(textBoxLoginName.Text == "" || textBoxPass.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            String lenh = "EXEC dbo.sp_Check_Trang_Thai_Xoa @MANV = N'" + userName + "'";
            Program.myReader = Program.ExecSqlDataReader(lenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int check = 0;
            check = int.Parse(Program.myReader.GetValue(0).ToString());
            if (check == 1)
            {
                MessageBox.Show("Nhân viên đã nghỉ hoặc chuyển chi nhánh, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                textBoxLoginName.Focus();
                return;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối data", "Thông báo", MessageBoxButtons.OK);
                return;
            }


            // CALL SP TAO LOGIN


            String sqlDk = "EXEC dbo.SP_TAOLOGIN @LGNAME = '"+ textBoxLoginName.Text + "', @PASS = '"+ textBoxPass.Text + "',@USERNAME = '"+userName+"', @ROLE = '"+Program.mGroup+"'";
            Program.myReader = Program.ExecSqlDataReader(sqlDk);
            if (Program.myReader == null) return;
            MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
            this.Close();         
        }

        private void button2_Click(object sender, EventArgs e) //thoat
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát đăng kí", "Thông báo", MessageBoxButtons.YesNo);
            switch (rs)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                default:
                    return;
            }
        }
    }
}
