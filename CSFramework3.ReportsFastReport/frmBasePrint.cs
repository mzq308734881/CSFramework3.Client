using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;
using CSFramework.Library;
using CSFramework.Common;

namespace CSFramework3.ReportsFastReport
{
    public partial class frmBasePrint : frmBase
    {

        public frmBasePrint()
        {
            InitializeComponent();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPreview();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPrint();
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoHelp();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoClose();
        }


        protected void AssertNull(object o, string throwMsg)
        {
            if (o == null) throw new Exception(throwMsg);
        }

        protected void AssertNullDataSet(DataSet ds, string throwMsg)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) throw new Exception(throwMsg);
        }

        protected virtual void DoDesignReport()
        {
            //
        }

        protected virtual void DoPreview()
        {
            //

        }
        protected virtual void DoPrint()
        {
            //
        }
        protected virtual void DoHelp()
        {
            //
        }
        protected virtual void DoClose()
        {
            this.Close();
        }

        private void frmPrintBase_Load(object sender, EventArgs e)
        {
            btnClose.Glyph = Globals.LoadImage("24_Exit.ico");
            btnPrint.Glyph = Globals.LoadImage("24_Print.ico");
            btnPreview.Glyph = Globals.LoadImage("24_PrintPreview.ico");
            btnHelp.Glyph = Globals.LoadImage("24_Help.ico");
            btnDesign.Glyph = Globals.LoadImage("24_DesignReport.ico");
        }

        private void btnDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoDesignReport();
        }
    }
}