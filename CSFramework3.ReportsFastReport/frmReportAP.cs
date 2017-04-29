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
using CSFramework3.Models;

namespace CSFramework3.ReportsFastReport
{
    public partial class frmReportAP : CSFramework3.ReportsFastReport.frmBasePrint
    {
        private frmReportAP()
        {
            InitializeComponent();
        }

        public static void Execute(string docNoFrom, string docNoTo)
        {
            frmReportAP form = new frmReportAP();
            form.txtNoFrom.Text = docNoFrom;
            form.txtNoTo.Text = docNoTo;
            form.ShowDialog();
        }

        protected override void DoPrint()
        {//打印
            this.InitializeReport_DOC();
            rptAP.Prepare();//准备工作,显示报表预览窗体
            rptAP.PrintPrepared();
        }

        protected override void DoPreview()
        {
            this.InitializeReport_DOC();
            frmPreview.Preview(this.rptAP, this);
        }

        protected override void DoDesignReport()
        {//设计报表
            string file = Application.StartupPath + @"\Reports\rptAP.frx";
            rptAP.Load(file);//加载报表模板文件
            rptAP.Design(true);
        }

        private void InitializeReport_DOC()
        {
            //打印主从表数据
            string file = Application.StartupPath + @"\Reports\rptAP.frx";
            rptAP.Load(file);//加载报表模板文件

            DataSet ds = new bllAP().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("没有查询到报表数据！");
            ds.Tables[0].TableName = "M";//换个短的别名
            ds.Tables[1].TableName = "D";//换个短的别名

            rptAP.RegisterData(ds.Tables[0], "M");  //注册数据源,主表
            rptAP.RegisterData(ds.Tables[1], "D"); //注册数据源,从表

            //给DataBand(主表数据)绑定数据源
            DataBand masterBand = rptAP.FindObject("Data1") as DataBand;
            masterBand.DataSource = rptAP.GetDataSource("M"); //主表

            //给DataBand(明细数据)绑定数据源
            DataBand detailBand = rptAP.FindObject("Data2") as DataBand;
            detailBand.DataSource = rptAP.GetDataSource("D"); //明细表        

            //重要！！给明细表设置主外键关系！
            detailBand.Relation = new Relation();
            detailBand.Relation.ParentColumns = new string[] { tb_AP.APNO };
            detailBand.Relation.ParentDataSource = rptAP.GetDataSource("M"); //主表
            detailBand.Relation.ChildColumns = new string[] { tb_AP.APNO };
            detailBand.Relation.ChildDataSource = rptAP.GetDataSource("D"); //明细表 

            (rptAP.FindObject("Text52") as RichObject).Text = Loginer.CurrentUser.AccountName;
        }

    }
}
