using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class XtraReportGiaoDich : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportGiaoDich()
        {
            InitializeComponent();
        }
        public XtraReportGiaoDich(String mcn, String dateFrom, String dateTo, String stk)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dateFrom;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dateTo;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = mcn;
            this.sqlDataSource1.Fill();
            xrLabelDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
