
///*************************************************************************/
///*
///* 文件名    ：frmCustomer.cs    
///*
///* 程序说明  : 客户管理窗体
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

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
using CSFramework.Library;
using CSFramework3.Interfaces;
using CSFramework.Core;

namespace CSFramework3.DataDictionary
{
    /// <summary>
    /// 客户管理窗体
    /// </summary>
    public partial class frmCustomer : frmBaseDataDictionary
    {
        private bllCustomer _BllCustomer; //业务逻辑层对象引用

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作            
        }

        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);//每个业务窗体必需给这个变量赋值.
            _ActiveEditor = txtCode;
            _KeyEditor = txtCode;
            _DetailGroupControl = gcDetailEditor;
            _BLL = new bllCustomer(); //业务逻辑实例
            _BllCustomer = _BLL as bllCustomer; //本窗体引用

            base.InitializeForm();

            //绑定相关缓存数据
            DataBinder.BindingLookupEditDataSource(txt_Attr, DataDictCache.Cache.CustomerAttributes, "NativeName", "AttributeCode");
            DataBinder.BindingLookupEditDataSource(txtBank, DataDictCache.Cache.Bank, "NativeName", "DataCode");
            ucCusAttributes.BindingDataSource(DataDictCache.Cache.CustomerAttributes, "AttributeCode", "NativeName");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {//搜索数据            
            this._BllCustomer.SearchBy(txt_CustomerFrom.Text, txt_CustomerTo.Text, txt_Name.Text, ConvertEx.ToString(txt_Attr.EditValue), true);
            this.DoBindingSummaryGrid(_BLL.SummaryTable); //绑定主表的Grid
            this.ShowSummaryPage(true); //显示Summary页面. 
        }

        // 检查主表数据是否完整或合法
        protected override bool ValidatingData()
        {
            if (txtCode.Text == string.Empty)
            {
                Msg.Warning("客户编号不能为空!");
                txtCode.Focus();
                return false;
            }

            if (txtNativeName.Text.Trim() == string.Empty)
            {
                Msg.Warning("客户名称不能为空!");
                txtNativeName.Focus();
                return false;
            }

            if (ucCusAttributes.Text == string.Empty)
            {
                Msg.Warning("公司类型不能为空!");
                ucCusAttributes.Focus();
                return false;
            }

            if (_UpdateType == UpdateType.Add)
            {
                if (_BLL.CheckNoExists(txtCode.Text))
                {
                    Msg.Warning("客户编号已存在!");
                    txtCode.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 绑定输入框
        /// </summary>
        /// <param name="summary"></param>
        protected override void DoBindingSummaryEditor(DataTable summary)
        {
            try
            {
                if (summary == null) return;
                DataBinder.BindingTextEdit(txtCode, summary, tb_Customer.CustomerCode);
                DataBinder.BindingTextEdit(txtAddress1, summary, tb_Customer.Address1);
                DataBinder.BindingTextEdit(txtAddress2, summary, tb_Customer.Address2);
                DataBinder.BindingTextEdit(txtAddress3, summary, tb_Customer.Address3);
                DataBinder.BindingTextEdit(txtBank, summary, tb_Customer.Bank);
                DataBinder.BindingTextEdit(txtBankAccount, summary, tb_Customer.BankAccount);
                DataBinder.BindingTextEdit(txtBankAddress, summary, tb_Customer.BankAddress);
                DataBinder.BindingTextEdit(txtCity, summary, tb_Customer.City);
                DataBinder.BindingTextEdit(txtCityCode, summary, tb_Customer.CityCode);
                DataBinder.BindingTextEdit(txtContactPerson, summary, tb_Customer.ContactPerson);
                DataBinder.BindingTextEdit(txtCountry, summary, tb_Customer.Country);
                DataBinder.BindingTextEdit(txtCountryCode, summary, tb_Customer.CountryCode);
                DataBinder.BindingTextEdit(txtEmail, summary, tb_Customer.Email);
                DataBinder.BindingTextEdit(txtEnglishName, summary, tb_Customer.EnglishName);
                DataBinder.BindingTextEdit(txtFax, summary, tb_Customer.Fax);
                DataBinder.BindingTextEdit(txtNativeName, summary, tb_Customer.NativeName);
                DataBinder.BindingTextEdit(txtPaymentTerm, summary, tb_Customer.PaymentTerm);
                DataBinder.BindingTextEdit(txtPostalCode, summary, tb_Customer.PostalCode);
                DataBinder.BindingTextEdit(txtRegion, summary, tb_Customer.Region);
                DataBinder.BindingTextEdit(txtRemark, summary, tb_Customer.Remark);
                DataBinder.BindingTextEdit(txtTel, summary, tb_Customer.Tel);
                DataBinder.BindingTextEdit(txtWebAddress, summary, tb_Customer.WebAddress);
                DataBinder.BindingTextEdit(txtZipCode, summary, tb_Customer.ZipCode);
                DataBinder.BindingCheckEdit(chkInUse, summary, tb_Customer.InUse);

                DataBinder.BindingControl(ucCusAttributes, summary, tb_Customer.AttributeCodes, "EditValue");
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            base.ClearContainerEditorText(panelControl3);            
        }

    }
}
