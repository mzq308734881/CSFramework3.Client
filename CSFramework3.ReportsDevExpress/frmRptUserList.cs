using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSFramework3.Business.Security;
using DevReportTester;
using DevExpress.XtraReports.UI;

namespace CSFramework3.ReportsDevExpress
{
    public partial class frmRptUserList : CSFramework3.ReportsDevExpress.frmPrintBase
    {
        public frmRptUserList()
        {
            InitializeComponent();
        }

        protected override XtraReport DoPrepareReport()
        {
            rptUserList mReport = new rptUserList(); //报表实例

            DataSet data = new bllUser().GetUserReportData(txtDateFrom.DateTime, txtDateTo.DateTime);
            mReport.SetReportDataSource(data);//绑定报表的数据源

            return mReport;
        }

    }
}
