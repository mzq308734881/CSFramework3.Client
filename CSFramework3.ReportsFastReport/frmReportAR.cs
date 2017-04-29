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
    public partial class frmReportAR : CSFramework3.ReportsFastReport.frmBasePrint
    {
        private frmReportAR()
        {
            InitializeComponent();
        }

        private void frmReportAR_Load(object sender, EventArgs e)
        {
            
        }

        public static void Execute(string docNoFrom, string docNoTo)
        {
            frmReportAR form = new frmReportAR();
            form.txtNoFrom.Text = docNoFrom;
            form.txtNoTo.Text = docNoTo;
            form.ShowDialog();
        }

        protected override void DoPrint()
        {//打印
            if (cmbReportType.SelectedIndex == 0)//Document
            {
                this.InitializeReport_DOC();
                rptAR.Prepare();//准备工作,显示报表预览窗体
                rptAR.PrintPrepared();
            }
            if (cmbReportType.SelectedIndex == 1)//Document-Normal
            {
                this.InitializeReport_Normal();
                rptARNormal.Prepare();//准备工作,显示报表预览窗体
                rptARNormal.PrintPrepared();
            }
            if (cmbReportType.SelectedIndex == 2)//check list
            {
                this.InitializeReport_Checklist();
                rptAR_Checklist.Prepare();//准备工作,显示报表预览窗体
                rptAR_Checklist.PrintPrepared();
            }
        }

        protected override void DoPreview()
        {//打印预览
            if (cmbReportType.SelectedIndex == 0)//Document
            {
                this.InitializeReport_DOC();
                frmPreview.Preview(this.rptAR, this);
            }
            if (cmbReportType.SelectedIndex == 1)//Document-Normal
            {
                this.InitializeReport_Normal();
                frmPreview.Preview(this.rptARNormal, this);
            }
            if (cmbReportType.SelectedIndex == 2)//check list
            {
                this.InitializeReport_Checklist();
                frmPreview.Preview(this.rptAR_Checklist, this);
            }
        }

        protected override void DoDesignReport()
        {//设计报表
            if (cmbReportType.SelectedIndex == 0)//Document
            {
                string file = Application.StartupPath + @"\Reports\rptAR.frx";
                rptAR.Load(file);//加载报表模板文件
                rptAR.Design(true);
            }
            if (cmbReportType.SelectedIndex == 1)//Document-Normal
            {
                string file = Application.StartupPath + @"\Reports\rptAR_Normal.frx";

                rptARNormal.Load(file);//加载报表模板文件
                rptARNormal.Design(true);
            }
            if (cmbReportType.SelectedIndex == 2)//check list
            {
                string file = Application.StartupPath + @"\Reports\rptAR_Checklist.frx";
                rptAR_Checklist.Load(file);//加载报表模板文件
                rptAR_Checklist.Design(true);
            }
        }

        private void InitializeReport_DOC()
        {
            //打印主从表数据
            string file = Application.StartupPath + @"\Reports\rptAR.frx";

            rptAR.Load(file);//加载报表模板文件

            DataSet ds = new bllAR().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("没有查询到报表数据！");
            ds.Tables[0].TableName = "M";//换个短的别名
            ds.Tables[1].TableName = "D";//换个短的别名

            rptAR.RegisterData(ds.Tables[0], "M");  //注册数据源,主表
            rptAR.RegisterData(ds.Tables[1], "D"); //注册数据源,从表

            //给DataBand(主表数据)绑定数据源
            DataBand masterBand = rptAR.FindObject("Data1") as DataBand;
            masterBand.DataSource = rptAR.GetDataSource("M"); //主表

            //给DataBand(明细数据)绑定数据源
            DataBand detailBand = rptAR.FindObject("Data2") as DataBand;
            detailBand.DataSource = rptAR.GetDataSource("D"); //明细表        

            //重要！！给明细表设置主外键关系！
            detailBand.Relation = new Relation();
            detailBand.Relation.ParentColumns = new string[] { tb_AR.ARNO };
            detailBand.Relation.ParentDataSource = rptAR.GetDataSource("M"); //主表
            detailBand.Relation.ChildColumns = new string[] { tb_AR.ARNO };
            detailBand.Relation.ChildDataSource = rptAR.GetDataSource("D"); //明细表 

            (rptAR.FindObject("Text52") as RichObject).Text = Loginer.CurrentUser.AccountName;

        }

        private void InitializeReport_Normal()
        {
            //打印主从表数据
            string file = Application.StartupPath + @"\Reports\rptAR_Normal.frx";

            rptARNormal.Load(file);//加载报表模板文件

            DataSet ds = new bllAR().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("没有查询到报表数据！");
            ds.Tables[0].TableName = "M";//换个短的别名
            ds.Tables[1].TableName = "D";//换个短的别名

            rptARNormal.RegisterData(ds.Tables[0], "M");  //注册数据源,主表
            rptARNormal.RegisterData(ds.Tables[1], "D"); //注册数据源,从表

            //给DataBand(主表数据)绑定数据源
            DataBand masterBand = rptARNormal.FindObject("Data1") as DataBand;
            masterBand.DataSource = rptARNormal.GetDataSource("M"); //主表

            masterBand.BeforePrint += new EventHandler(band_BeforePrint);//自定义处理

            //给DataBand(明细数据)绑定数据源
            DataBand detailBand = rptARNormal.FindObject("Data2") as DataBand;
            detailBand.DataSource = rptARNormal.GetDataSource("D"); //明细表        

            //重要！！给明细表设置主外键关系！
            detailBand.Relation = new Relation();
            detailBand.Relation.ParentColumns = new string[] { tb_AR.ARNO };
            detailBand.Relation.ParentDataSource = rptARNormal.GetDataSource("M"); //主表
            detailBand.Relation.ChildColumns = new string[] { tb_AR.ARNO };
            detailBand.Relation.ChildDataSource = rptARNormal.GetDataSource("D"); //明细表 

            (rptARNormal.FindObject("Text52") as RichObject).Text = Loginer.CurrentUser.AccountName;
        }

        void band_BeforePrint(object sender, EventArgs e)
        {
            //取出当前正在打印的记录(DataRow)。
            DataRow row = (sender as DataBand).DataSource.CurrentRow as DataRow;

            decimal amount = ConvertEx.ToDecimal(row[tb_AR.Amount]);
            RichObject txtAmt = rptARNormal.FindObject("RichCHNAmount") as RichObject;
            txtAmt.Text = RMBConverter.toRMB(amount);     
        }

        private void InitializeReport_Checklist()
        {
            //打印单表数据
            string file = Application.StartupPath + @"\Reports\rptAR_Checklist.frx";
            rptAR_Checklist.Load(file);//加载报表模板文件

            DataSet ds = new bllAR().GetReportData_Checklist(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime); //取报表数据
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("没有查询到报表数据！");
            rptAR_Checklist.RegisterData(ds.Tables[0], "D"); //注册数据源,别名为：D

            //给DataBand(明细数据)绑定数据源
            DataBand band = rptAR_Checklist.FindObject("Data1") as DataBand;
            DataSourceBase dataSource = rptAR_Checklist.GetDataSource("D");
            band.DataSource = dataSource;

            (rptAR_Checklist.FindObject("Text16") as RichObject).Text = Loginer.CurrentUser.AccountName;//打印人员
            rptAR_Checklist.Parameters.FindByName("pRowCount").Value = ds.Tables[0].Rows.Count.ToString();//报表参数，设置记录数

        }


    }
}
