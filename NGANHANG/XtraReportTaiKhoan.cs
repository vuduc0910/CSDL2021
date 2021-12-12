﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class XtraReportTaiKhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportTaiKhoan()
        {
           
        }
        public XtraReportTaiKhoan(String mcn, String dateFrom, String dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = mcn;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dateFrom;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dateTo;
            this.sqlDataSource1.Fill();
            xrLabelThoigianLap.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

    }
}
