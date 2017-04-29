using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace CSFramework3.ReportsFastReport
{
    /// <summary>
    /// 报表预览窗体
    /// </summary>
    public partial class frmPreview : Form
    {
        private frmPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 预览报表
        /// </summary>
        /// <param name="report">报表对象</param>
        /// <param name="owner">指定窗体拥有者</param>
        public static void Preview(Report report, Form owner)
        {
            frmPreview previewForm = new frmPreview();
            report.Preview = previewForm.previewControl1;
            //准备工作,显示报表预览窗体
            report.Prepare();
            report.ShowPrepared(true, owner);
            previewForm.ShowDialog();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            this.LoadExportTypes();
            cbExportTypes.SelectedIndex = 0;//PDF
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            ExportReportItem item = cbExportTypes.SelectedItem as ExportReportItem;
            string filePath = item.ExportToFile(previewControl1.Report); //导出报表文件            
            string subject = "尊敬的用户您好,请查看报表文件.";
            string body = "尊敬的用户您好! 这是一封由电脑系统自动发送的邮件,请不要回复,谢谢!";
            //frmSendMail.Execute(filePath, true, subject, body, "发送报表文件"); //打开发送窗体
        }

        private void LoadExportTypes()
        {            
            cbExportTypes.Items.Clear();
            cbExportTypes.Items.Add(new ExportReportItem("图片格式报表", ExportReportItem.ExportType.IMG));
            cbExportTypes.Items.Add(new ExportReportItem("PDF格式报表", ExportReportItem.ExportType.PDF));
            cbExportTypes.Items.Add(new ExportReportItem("Excel格式报表", ExportReportItem.ExportType.XLS));
            cbExportTypes.Items.Add(new ExportReportItem("HTML格式报表", ExportReportItem.ExportType.HTML));
            cbExportTypes.SelectedIndex = 0;//PDF预设
        }
    }
}
