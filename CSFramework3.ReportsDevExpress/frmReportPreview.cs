using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace DevReportTester
{
    public partial class frmReportPreview : DevExpress.XtraEditors.XtraForm
    {
        private frmReportPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开报表预览窗体
        /// </summary>
        /// <param name="report">报表实例</param>
        /// <param name="owner">父级窗体</param>
        public static void DoPreviewReport(XtraReport report, Form owner)
        {
            using (frmReportPreview preview = new frmReportPreview())
            {
                preview.Owner = owner;
                preview.Initialize(report);
                preview.WindowState = FormWindowState.Maximized; //最大化
                preview.ShowDialog();
            }
        }

        private void Initialize(XtraReport report)
        {
            //重要！XtraReport(报表实例)与PrintControl(打印预览组件)建立关联!
            printControl1.PrintingSystem = report.PrintingSystem;

            //初始化报表，创建报表后进入预览状态。
            report.CreateDocument(true);

            //隐藏某些按钮,CommandVisibility.None 表示隐藏
            printControl1.PrintingSystem.SetCommandVisibility(new PrintingSystemCommand[]
            {
                PrintingSystemCommand.Open,
                PrintingSystemCommand.Save,
                PrintingSystemCommand.ClosePreview,
                PrintingSystemCommand.Customize,
                PrintingSystemCommand.SendCsv,
                PrintingSystemCommand.SendFile,
                PrintingSystemCommand.SendGraphic,
                PrintingSystemCommand.SendMht,
                PrintingSystemCommand.SendPdf,
                PrintingSystemCommand.SendRtf,
                PrintingSystemCommand.SendTxt,
                PrintingSystemCommand.SendXls,
                PrintingSystemCommand.Watermark
            }, CommandVisibility.None);


        }
    }
}
