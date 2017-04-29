using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;
using FastReport.Data;
using CSFramework.Common;
using CSFramework3.Business.Security;

namespace CSFramework3.ReportsFastReport
{
    public partial class frmReportUser : CSFramework3.ReportsFastReport.frmBasePrint
    {
        public frmReportUser()
        {
            InitializeComponent();
        }

        protected override void DoPrint()
        {
            this.InitializeReport();
            rptUser.Prepare();//准备工作,显示报表预览窗体
            rptUser.PrintPrepared();
        }

        protected override void DoPreview()
        {
            this.InitializeReport();
            frmPreview.Preview(this.rptUser, this);
        }

        protected override void DoDesignReport()
        {
            string file = Application.StartupPath + @"\Reports\rptUser.frx";
            rptUser.Load(file);//加载报表模板文件
            rptUser.Design(true);
        }

        private void InitializeReport()
        {
            //打印单表数据
            string file = Application.StartupPath + @"\Reports\rptUser.frx";
            rptUser.Load(file);//加载报表模板文件

            DataSet ds = new bllUser().GetUserReportData(txtFrom.DateTime, txtTo.DateTime);//取报表数据

            rptUser.RegisterData(ds.Tables[0], "tb_MyUser"); //注册数据源,单表

            //给DataBand(明细数据)绑定数据源
            DataBand band = rptUser.FindObject("Data1") as DataBand;
            DataSourceBase dataSource = rptUser.GetDataSource("tb_MyUser");
            band.DataSource = dataSource;

            //自定义处理
            band.BeforePrint += new EventHandler(band_BeforePrint);

            (rptUser.FindObject("Text16") as RichObject).Text = Loginer.CurrentUser.AccountName;
        }

        void band_BeforePrint(object sender, EventArgs e)
        {
            //取出当前打印的记录。
            DataRow row = (sender as DataBand).DataSource.CurrentRow as DataRow;

            //做其它特殊处理：

            int i = (sender as DataBand).DataSource.CurrentRowNo;
            (rptUser.FindObject("Text8") as TextObject).Text = "DataRow:" + i.ToString();
        }
    }
}
