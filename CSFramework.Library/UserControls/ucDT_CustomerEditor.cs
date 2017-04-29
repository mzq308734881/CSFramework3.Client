using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Data;
using System.ComponentModel;
using CSFramework3.Business;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework3.Models;

/* ==========================================================================
 *  控件使用方法：
 * 
 *  1. 拖放ucDT_CustomerEditor到界面上
 *  2. 设置CustomerAttributeCodes,CustomerNameControl,CustomerNameField属性
 *  2. 绑定事件：OnSetResult.
 *  3. 请参考frmSO窗体的txtCustomer.
 *  
  ==========================================================================*/

namespace CSFramework.Library.UserControls
{
    /// <summary>
    /// 客户资料输入组件，可输入客户编号或名称，通过后台模糊查询数据。
    /// <para>在输入框输入内容：</para>
    /// <para>  1. 自动搜索编号和名称并返回数据。</para>
    /// <para>  2. 如返回一条记录则取当前记录的值。</para>
    /// <para>  3. 如匹配到多条记录则弹出窗体由用户选择。</para>
    /// </summary>
    public class ucDT_CustomerEditor : ButtonEdit
    {
        private bool _OwnerKeyPreview = false;//特殊处理标记，当焦点移到当前控件，窗体的KeyPreview属性失效.        
        private string _LastValue = "";//记录最后一次输入的客户编号,避免Validing事件重复查询数据

        public ucDT_CustomerEditor()
        {
            this.KeyDown += new KeyEventHandler(ucDT_CustomerEditor_KeyDown);

            this.Enter += new EventHandler(ucDT_CustomerEditor_Enter);
            this.Leave += new EventHandler(ucDT_CustomerEditor_Leave);

            this.Validating += new System.ComponentModel.CancelEventHandler(ucDT_CustomerEditor_Validating);
            this.ButtonClick += new ButtonPressedEventHandler(ucDT_CustomerEditor_ButtonClick);

            this.BindingContextChanged += new EventHandler(ucDT_CustomerEditor_BindingContextChanged);
        }

        private string _CustomerAttributeCodes = "";

        [Description("属性。如:,CUS,SPL, 表示查询客户和供应商的商户信息。")]
        public string CustomerAttributeCodes
        {
            get { return _CustomerAttributeCodes; }
            set { _CustomerAttributeCodes = value; }
        }

        private event SearchCallBack _OnSetResult = null;

        /// <summary>
        /// 当用户选择记录后关闭窗体时触发的事件。
        /// </summary>
        public event SearchCallBack OnSetResult
        {
            add { _OnSetResult += value; }
            remove { _OnSetResult -= value; }
        }

        private BaseEdit _CustomerNameControl = null;

        [Description("客户名称输入框。")]
        public BaseEdit CustomerNameControl
        {
            get { return _CustomerNameControl; }
            set { _CustomerNameControl = value; }
        }

        private string _CustomerNameField = tb_Customer.NativeName;

        [Description("从资料行取客户名称的字段名。")]
        public string CustomerNameField
        {
            get { return _CustomerNameField; }
            set { _CustomerNameField = value; }
        }

        private void OnSearchCallBack(DataRow resultRow)
        {
            try
            {                
                string customerCode = ConvertEx.ToString(resultRow[tb_Customer.CustomerCode]);
                string customerName = ConvertEx.ToString(resultRow[_CustomerNameField]);

                _LastValue = customerCode;//记录最后一次获取的客户编号

                //给输入框设置客户编号
                DataBinder.SetEditorBindingValue(this, customerCode);

                //设置客户名称
                if (_CustomerNameControl != null)
                    DataBinder.SetEditorBindingValue(_CustomerNameControl, customerName);

                //回调函数,事件
                if (_OnSetResult != null) _OnSetResult(resultRow);
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }

        void ucDT_CustomerEditor_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmFuzzyCustomer.Execute(this, _CustomerAttributeCodes, OnSearchCallBack);            
        }

        //检查数据
        void ucDT_CustomerEditor_Validating(object sender, CancelEventArgs e)
        {
            if (this.IsOwnerEditMode() && (this.Text.Trim() != _LastValue))
            {
                if (this.Text.Trim() != "")
                {
                    DataTable customers = new bllCustomer().FuzzySearch(_CustomerAttributeCodes, this.Text.Trim());

                    if (customers.Rows.Count > 1)//查询出多条记录，打开筛选窗体给用户选取。
                        frmFuzzyCustomer.Execute(this, customers, _CustomerAttributeCodes, OnSearchCallBack);
                    else if (customers.Rows.Count == 1)
                        OnSearchCallBack(customers.Rows[0]);
                    else
                    {
                        Msg.Warning("客户编号不存在！");
                        e.Cancel = true;
                    }
                }
                else
                {
                    OnSearchCallBack(null);
                }
            }            
        }

        //处理按键
        void ucDT_CustomerEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.IsOwnerEditMode() && (this.Text.Trim() != "") && (this.Text.Trim() != _LastValue))
                {
                    ucDT_CustomerEditor_Validating(this, new CancelEventArgs());
                }
                else
                {
                    Form form = this.FindForm();
                    if (form is frmBaseDataForm)
                    {
                        (form as frmBaseDataForm).SelectNextControl(this, true, true, true, false);
                    }
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }

        //离开输入框
        void ucDT_CustomerEditor_Leave(object sender, EventArgs e)
        {
            this.FindForm().KeyPreview = _OwnerKeyPreview;
        }

        //获得焦点
        void ucDT_CustomerEditor_Enter(object sender, EventArgs e)
        {
            Form owner = this.FindForm();
            _OwnerKeyPreview = owner.KeyPreview;
            owner.KeyPreview = false;
        }

        /// <summary>
        /// 当数据窗体操作模式是”新增“或“修改”时值为True。
        /// </summary>
        /// <returns></returns>
        private bool IsOwnerEditMode()
        {
            Form owner = this.FindForm();

            if (owner is IDataOperatable)
            {
                IDataOperatable dataForm = owner as IDataOperatable;
                return ((UpdateType.Add == dataForm.UpdateType) || (UpdateType.Modify == dataForm.UpdateType));
            }
            return false;
        }

        //绑定数据源触发该事件
        private void ucDT_CustomerEditor_BindingContextChanged(object sender, EventArgs e)
        {
            _LastValue = "";
        }

    }
}
