using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing.Printing;

namespace CSFramework3.ReportsDevExpress
{
    /// <summary>
    /// 主从表报表
    /// </summary>
    public partial class rptSO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSO()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置主从表的数据源
        /// </summary>
        /// <param name="reportData"></param>
        public void SetReportDataSource(DataSet reportData)
        {
            //因涉及到修改DataSet的内部属性，建议创建副本进行操作。
            DataSet ds = reportData.Copy();//创建副本

            //重要！！！给组(GroupHeader)绑定主键字段
            //本报表是按业务单号分组
            GroupField gf = new GroupField("SONO", XRColumnSortOrder.Ascending);
            GroupHeader1.GroupFields.Add(gf);

            //给数据集建立主外键关系
            DataColumn parentColumn = ds.Tables["tb_SO"].Columns["SONO"];
            DataColumn childColumn = ds.Tables["tb_SOs"].Columns["SONO"];
            DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);
            ds.Relations.Add(R1);

            //绑定主表的数据源
            this.DataMember = "tb_SO";
            this.DataSource = ds;

            //绑定明细表的数据源
            this.DetailReport.DataMember = "R1";
            this.DetailReport.DataSource = ds;

            //自动绑定明细表XRLabel的数据源
            this.BindingFields(ds, this.Detail1.Controls);

            xrLabel15.DataBindings.Add("Text", ds, "R1.Amount");//绑定小计(当前单据的总金额)
            xrLabel23.DataBindings.Add("Text", ds, "R1.Amount");//绑定总计(所有单据的总金额)
        }

        /// <summary>
        /// 动态绑定字段
        /// </summary>
        /// <param name="dataSource">报表的数据源</param>
        /// <param name="bindableControls">对应字段的报表控件集体</param>
        private void BindingFields(DataSet dataSource, XRControlCollection bindableControls)
        {
            foreach (XRControl C in bindableControls)
            {
                if ((C.Tag != null) && (C.Tag.ToString() == "DATA")) //注意！只处理Tag=DATA的控件
                {
                    C.DataBindings.Add("Text", dataSource, C.Text.Replace("[", "").Replace("]", ""));
                }
            }
        }

        private void XtraReport_MasterDetail_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {            
            //
        }

        private void XtraReport_MasterDetail_PrintProgress(object sender, DevExpress.XtraPrinting.PrintProgressEventArgs e)
        {
            //
        }

        private void XtraReport_MasterDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //
        }

    }
}
