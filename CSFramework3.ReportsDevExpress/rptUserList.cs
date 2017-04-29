using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CSFramework3.ReportsDevExpress
{
    public partial class rptUserList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptUserList()
        {
            InitializeComponent();
        }

        public void SetReportDataSource(DataSet dataSource)
        {
            this.DataSource = dataSource.Tables[0];//用户数据

            xrLabelRowCount.Text = dataSource.Tables[0].Rows.Count.ToString();//记录数
        }

    }
}
