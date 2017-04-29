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
using CSFramework3.Business;

namespace CSFramework3.ReportsFastReport
{
    public partial class frmReportSO : CSFramework3.ReportsFastReport.frmBasePrint
    {
        private frmReportSO()
        {
            InitializeComponent();
        }

        public static void Execute(string docNoFrom, string docNoTo)
        {
            frmReportSO form = new frmReportSO();
            form.txtNoFrom.Text = docNoFrom;
            form.txtNoTo.Text = docNoTo;
            form.ShowDialog();
        }

        protected override void DoPrint()
        {
            this.InitializeReport();
            rptSO.Prepare();//准备工作,显示报表预览窗体
            rptSO.PrintPrepared();
        }

        protected override void DoPreview()
        {
            this.InitializeReport();
            frmPreview.Preview(this.rptSO, this);
        }

        protected override void DoDesignReport()
        {
            string file = Application.StartupPath + @"\Reports\rptSO.frx";
            rptSO.Load(file);//加载报表模板文件
            rptSO.Design(true);
        }

        private void InitializeReport()
        {
            //打印主从表数据
            string file = Application.StartupPath + @"\Reports\rptSO.frx";
            rptSO.Load(file);//加载报表模板文件

            DataSet ds = new bllSO().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);
            ds.Tables[0].TableName = "M";//换个短的别名
            ds.Tables[1].TableName = "D";//换个短的别名

            rptSO.RegisterData(ds.Tables[0], "M");  //注册数据源,主表
            rptSO.RegisterData(ds.Tables[1], "D"); //注册数据源,从表

            //给DataBand(主表数据)绑定数据源
            DataBand masterBand = rptSO.FindObject("Data1") as DataBand;
            masterBand.DataSource = rptSO.GetDataSource("M"); //主表

            //给DataBand(明细数据)绑定数据源
            DataBand detailBand = rptSO.FindObject("Data2") as DataBand;
            detailBand.DataSource = rptSO.GetDataSource("D"); //明细表        

            //重要！！给明细表设置主外键关系！
            detailBand.Relation = new Relation();
            detailBand.Relation.ParentColumns = new string[] { "SONO" };
            detailBand.Relation.ParentDataSource = rptSO.GetDataSource("M"); //主表
            detailBand.Relation.ChildColumns = new string[] { "SONO" };
            detailBand.Relation.ChildDataSource = rptSO.GetDataSource("D"); //明细表 

            (rptSO.FindObject("Text52") as RichObject).Text = Loginer.CurrentUser.AccountName;
        }

    }
}
