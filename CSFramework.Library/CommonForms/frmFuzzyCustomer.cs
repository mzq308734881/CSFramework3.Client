using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using CSFramework3.Business;
using CSFramework3.Models;
using CSFramework.Common;

namespace CSFramework.Library
{

    public partial class frmFuzzyCustomer : frmBaseDialog
    {
        private DataRow _ReturnRow = null; //返回一条记录.

        private string _AttributeCodes = "";

        //私有构造器
        private frmFuzzyCustomer()
        {
            InitializeComponent();
        }

        private void frmFuzzyCustomer_Load(object sender, EventArgs e)
        {
            if (gcSummary.DataSource == null) this.btnQuery.PerformClick();

            if (_AttributeCodes == "")
                lblAttribute.Text = "未指定.";
            else
                lblAttribute.Text = GetAttributeName(_AttributeCodes);
        }

        private string GetAttributeName(string attributeCodes)
        {
            string[] codes = attributeCodes.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            string item;
            StringBuilder sb = new StringBuilder();
            foreach (string code in codes)
            {
                item = code;                
                string filter = tb_CustomerAttribute.AttributeCode + "='" + code + "'";
                DataRow[] rows = DataDictCache.Cache.CustomerAttributes.Select(filter);
                if (rows.Length > 0)
                    item = item + "=" + rows[0][tb_CustomerAttribute.NativeName].ToString();
                sb.Append(item + ",");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 打开客戶资料查询窗体
        /// </summary>
        /// <param name="Sender">ButtonEdit</param>
        /// <param name="callBack">当选中客戶，返回客戶资料</param>
        public static void Execute(ButtonEdit Sender, SearchCallBack callBack)
        {
            frmFuzzyCustomer form = new frmFuzzyCustomer();
            form.txtValue.Text = Sender.Text;
            form.DoQuery(form.txtValue.Text);
            form.ShowDialog();
            if ((callBack != null) && (form._ReturnRow != null)) callBack(form._ReturnRow);
        }

        public static void Execute(ButtonEdit Sender, string attributeCodes, SearchCallBack callBack)
        {
            frmFuzzyCustomer form = new frmFuzzyCustomer();
            form._AttributeCodes = attributeCodes;
            form.ShowDialog();
            if ((callBack != null) && (form._ReturnRow != null)) callBack(form._ReturnRow);
        }

        /// <summary>
        ///  打开客戶资料查询窗体．
        /// </summary>
        /// <returns></returns>
        public static DataRow Execute()
        {
            frmFuzzyCustomer form = new frmFuzzyCustomer();
            form.ShowDialog();
            return form._ReturnRow;
        }

        /// <summary>
        /// 打开客戶资料查询窗体
        /// </summary>
        /// <param name="Sender">ButtonEdit</param>
        /// <param name="customers">數據源</param>
        /// <param name="callBack">当选中客戶，返回客戶资料</param>
        public static void Execute(ButtonEdit Sender, DataTable customers, SearchCallBack callBack)
        {
            frmFuzzyCustomer form = new frmFuzzyCustomer();
            form.gcSummary.DataSource = customers;
            form.ShowDialog();
            if ((callBack != null) && (form._ReturnRow != null)) callBack(form._ReturnRow);
        }

        public static void Execute(ButtonEdit Sender, DataTable customers, string attributeCodes, SearchCallBack callBack)
        {
            frmFuzzyCustomer form = new frmFuzzyCustomer();
            form.gcSummary.DataSource = customers;
            form._AttributeCodes = attributeCodes;
            form.ShowDialog();
            if ((callBack != null) && (form._ReturnRow != null)) callBack(form._ReturnRow);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvSummary.FocusedRowHandle < 0) return;

                //返回当前选择的记录.
                _ReturnRow = gvSummary.GetDataRow(gvSummary.FocusedRowHandle);

                this.Close();
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.DoQuery(txtValue.Text);
        }

        private void DoQuery(string content)
        {
            try
            {
                btnQuery.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = new bllCustomer().FuzzySearch(_AttributeCodes, content);
                gvSummary.GridControl.DataSource = dt;
            }
            finally
            {
                btnQuery.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void gvSummary_DoubleClick(object sender, EventArgs e)
        {
            if (gvSummary.RowCount > 0) btnOk.PerformClick();
        }

        private void frmFuzzyCustomer_Shown(object sender, EventArgs e)
        {
            if (gcSummary.CanFocus) gvSummary.Focus();
        }

        private void frmFuzzyCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (gvSummary.RowCount > 0)) btnOk.PerformClick();
        }





    }
}
