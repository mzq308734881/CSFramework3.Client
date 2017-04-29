using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSFramework3.Business;
using CSFramework.Common;
using CSFramework3.Models;

namespace CSFramework3.AccountModule
{

    public enum OutstandingType
    {
        AR,
        AP,
        None
    }


    public partial class frmQueryOutstanding : CSFramework.Library.frmBaseDialog
    {

        private OutstandingType _Type;
        public OutstandingType OutstandingType
        {
            get { return _Type; }
            set
            {
                _Type = value;

                if (_Type == OutstandingType.AR) cmbType.SelectedIndex = 0;
                else if (_Type == OutstandingType.AP) cmbType.SelectedIndex = 1;
                else cmbType.SelectedIndex = -1;
            }
        }


        private bool _okClicked = false;
        private bool _byCustomer = false;

        //私有构造器
        private frmQueryOutstanding()
        {
            InitializeComponent();
        }

        private void frmQueryOutstanding_Load(object sender, EventArgs e)
        {
            //私有构造器
        }

        #region 打开窗体

        /// <summary>
        /// 打开窗体，不返回任何数据
        /// </summary>
        public static void Execute_Query(OutstandingType type)
        {
            frmQueryOutstanding form = new frmQueryOutstanding();
            form.OutstandingType = type;
            form.cmbType.Enabled = OutstandingType.None == type;
            form.btnOk.Visible = false;//查询窗体不显示确认按钮
            form.ShowDialog();
        }

        /// <summary>
        /// 打开窗体，跟据参数取当前客户的帐款资料。
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public static DataRow Execute_SelectRow(string customerCode, OutstandingType type)
        {
            frmQueryOutstanding form = new frmQueryOutstanding();
            form.OutstandingType = type;
            form.cmbType.Enabled = OutstandingType.None == type;
            form.Init(customerCode);
            if (!String.IsNullOrEmpty(customerCode))
                form.btnQuery_Click(form.btnQuery, new EventArgs());//自动查询客户的余款
            form.ShowDialog();
            return form.GetResult(); //返回选择的记录
        }

        #endregion

        private void Init(string customerCode)
        {

            txt_Customer.EditValue = customerCode;
            txt_EndDate.DateTime = DateTime.Today;

            if (!String.IsNullOrEmpty(customerCode))
            {
                DataTable dt = new bllCustomer().GetDataByKey(customerCode);
                txtCustomerName.Text = ConvertEx.ToString(dt.Rows[0][tb_Customer.NativeName]);//显示客户名称
                txt_Customer.Enabled = false;//指定客户，不可重新选择客户
                _byCustomer = true;
            }
        }

        /// <summary>
        /// 返回选择的资料行
        /// </summary>
        /// <returns></returns>
        private DataRow GetResult()
        {
            if (!_okClicked) return null;

            if (gvOutstand.FocusedRowHandle >= 0)
                return gvOutstand.GetDataRow(gvOutstand.FocusedRowHandle);
            else
                return null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //关闭窗体
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _okClicked = true; //确认
            this.Close();
        }

        private void gvReceiptOutstand_DoubleClick(object sender, EventArgs e)
        {
            if (btnOk.Visible && (gvOutstand.FocusedRowHandle >= 0))
                btnOk_Click(btnOk, new EventArgs());
        }

        private void frmOutstandingPicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && gvOutstand.FocusedRowHandle >= 0)
                btnOk_Click(btnOk, new EventArgs());
        }

        private void frmOutstandingPicker_Activated(object sender, EventArgs e)
        {
            gcOutstand.Focus();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnQuery.Enabled = false;
                string type = cmbType.SelectedIndex == 0 ? "AR" : "AP";
                //查询数据
                DataTable dt = CommonData.SearchOutstanding("", ConvertEx.ToString(txt_Customer.EditValue),
                  txt_DateFrom.DateTime,
                  txt_DateTo.DateTime,
                  txt_EndDate.DateTime,
                  type);

                gcOutstand.DataSource = dt;
                gcOutstand.RefreshDataSource();
            }
            finally
            {
                btnQuery.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            txt_EndDate.EditValue = null;
            txt_DateFrom.EditValue = null;
            txt_DateTo.EditValue = null;
            if (!_byCustomer) txt_Customer.EditValue = null;
        }

        private void gcReceiptOutstand_DoubleClick(object sender, EventArgs e)
        {
            if (gvOutstand.RowCount > 0) btnOk.PerformClick();
        }


        private void txt_Customer_OnSetResult(DataRow resultRow)
        {
            if (resultRow != null)
                txtCustomerName.Text = resultRow[tb_Customer.NativeName].ToString();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (gvOutstand.RowCount <= 0)
            {
                Msg.Warning("没有数据！");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Microsoft Excel(*.xls)|*.xls";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                gvOutstand.ExportToXls(dlg.FileName);
                Msg.ShowInformation("导出文件 '" + dlg.FileName + "' 成功！");
            }
        }

    }
}
