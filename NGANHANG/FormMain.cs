using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            DangNhap();
        }
        private Form CheckExists(Type ftyple)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftyple)
                    return f;
            return null;
        }
        public void DangNhap()
        {

            Form frm = this.CheckExists(typeof(FormDangNhap));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            } 
                
            else
            {
                FormDangNhap f = new FormDangNhap();
                f.MdiParent = this;
                f.Show();
            }

            barButtonDangNhap.Enabled = true;
            barButtonDangXuat.Enabled = false;
            barButtonDKTaiKhoan.Enabled = false;
            barButtonChuyenTien.Enabled = false;
            barButtonGDGR.Enabled = false;
            barButtonKhachHang.Enabled = false;
            barButtonMoTaiKhoan.Enabled = false;
            barButtonNhanVien.Enabled = false;
        }
        private void DangkyTK()
        {
            Form frm = this.CheckExists(typeof(FormDangKyTK));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormDangKyTK f = new FormDangKyTK();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void MANV_Click(object sender, EventArgs e)
        {
        }

        private void barButtonThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất", "Thông báo", MessageBoxButtons.YesNo);
            switch (rs)
            {
                case DialogResult.Yes:
                    {
                        Program.Logout = true;
                        Program.myReader = null;
                        Program.mlogin = "";
                        Program.mloginDN = "";
                        Program.mGroup = "";
                        Program.mHoten = "";
                        Program.password = "";
                        Program.passwordDN = "";
                        Program.frmChinh.MANV.Text = "MANV";
                        Program.frmChinh.HOTEN.Text = "HOTEN";
                        Program.frmChinh.NHOM.Text = "NHOM";
                        MessageBox.Show("Đăng suất thành công", "Thông báo", MessageBoxButtons.OK);
                        foreach (Form f in this.MdiChildren)
                            f.Close();
                        DangNhap();
                        break;
                    }
                case DialogResult.No:
                default:
                    return;
            }
           
        }

        private void barButtonDKTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DangkyTK();
        }

        private void barButtonNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormNhanVien));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormNhanVien f = new FormNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormKhachHang));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormKhachHang f = new FormKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonMoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormTaiKhoan f = new FormTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonGDGR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormGoiRut));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormGoiRut f = new FormGoiRut();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonChuyenTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormChuyenTien));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormChuyenTien f = new FormChuyenTien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonSKTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormReportTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormReportTaiKhoan f = new FormReportTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonLKKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormReportKhachHang));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormReportKhachHang f = new FormReportKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonSKGD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormReportGiaoDich));
            if (frm != null)
            {
                frm.Activate();
                frm.Visible = true;
            }

            else
            {
                FormReportGiaoDich f = new FormReportGiaoDich();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
   
}
