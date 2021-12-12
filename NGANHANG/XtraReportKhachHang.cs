using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class XtraReportKhachHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportKhachHang()
        {
            InitializeComponent();
        }
        public XtraReportKhachHang(String mcn)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = mcn;
            xrLabelTime.Text = DateTime.Now.ToString();
        }


    }
}
