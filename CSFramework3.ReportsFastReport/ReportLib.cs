using System;
using System.IO;
using FastReport;
using FastReport.Export;
using FastReport.Export.Html;
using FastReport.Export.Image;
using FastReport.Export.Pdf;
using FastReport.Export.Xml;
using CSFramework.Common;

namespace CSFramework3.ReportsFastReport
{

    public enum ReportType
    {
        PrintDocument = 0,
        PrintCheckList = 1
    }//

    public class ExportReportItem
    {
        public enum ExportType
        {
            IMG,
            PDF,
            XLS,
            HTML
        }

        private string _ItemCaption;
        private ExportType _exportType;

        public ExportReportItem(string itemCaption, ExportType exportType)
        {
            _ItemCaption = itemCaption;
            _exportType = exportType;
        }

        public override string ToString()
        {
            return _ItemCaption;
        }

        public string ExportToFile(Report report)
        {
            ExportBase export = null;
            string fileName = Path.GetTempPath() + @"\_rpt" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + Loginer.CurrentUser.Account;
            
            if (ExportType.IMG == _exportType)
            {
                fileName = fileName + ".png";
                export = new ImageExport();
                (export as ImageExport).ImageFormat = ImageExportFormat.Png;
            }
            else if (ExportType.PDF == _exportType)
            {
                fileName = fileName + ".pdf";
                export = new PDFExport();
            }
            else if (ExportType.XLS == _exportType)
            {
                fileName = fileName + ".xls";
                export = new XMLExport();
            }
            else if (ExportType.HTML == _exportType)
            {
                fileName = fileName + ".html";
                export = new HTMLExport();
            }

            export.AllowOpenAfter = false;
            report.Export(export, fileName);

            return fileName;
        }
    }
}
