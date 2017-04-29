
///*************************************************************************/
///*
///* 文件名    ：frmPerson.cs    
///*
///* 程序说明  :  产品资料管理(数据字典开发模板窗体)
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
using DevExpress.XtraEditors;
using CSFramework.Library;
using CSFramework3.Business;
using CSFramework3.Interfaces;
using CSFramework.Core;
using CSFramework.Common;
using CSFramework3.Models;

namespace CSFramework3.DataDictionary
{
    /// <summary>
    /// 产品资料管理
    /// </summary>
    public partial class frmProduct : frmBaseDataDictionary
    {
        private bllProduct _BllInstance; //业务逻辑层对象引用

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            this.InitializeForm();
        }

        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);//每个业务窗体必需给这个变量赋值.
            _ActiveEditor = txtPcode;
            _KeyEditor = txtPcode;
            _DetailGroupControl = gcDetailEditor;
            _BLL = new bllProduct(); //业务逻辑实例
            _BllInstance = _BLL as bllProduct; //本窗体引用

            base.InitializeForm();
        }

        // 检查主表数据是否完整或合法
        protected override bool ValidatingData()
        {
            if (txtPcode.Text == string.Empty)
            {
                Msg.Warning("编号不能为空!");
                txtPcode.Focus();
                return false;
            }

            if (txtPname.Text.Trim() == string.Empty)
            {
                Msg.Warning("名称不能为空!");
                txtPname.Focus();
                return false;
            }


            if (_UpdateType == UpdateType.Add)
            {
                if (_BLL.CheckNoExists(txtPcode.Text))
                {
                    Msg.Warning("编号已存在!");
                    txtPcode.Focus();
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
                DataBinder.BindingTextEdit(txtPcode, summary, tb_Product.ProductCode);
                DataBinder.BindingTextEdit(txtPname, summary, tb_Product.ProductName);
                DataBinder.BindingTextEdit(txtPrice, summary, tb_Product.SellPrice);
                DataBinder.BindingTextEdit(txtRemark, summary, tb_Product.Remark);
                DataBinder.BindingTextEdit(txtSupplier, summary, tb_Product.Supplier);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
    }
}
