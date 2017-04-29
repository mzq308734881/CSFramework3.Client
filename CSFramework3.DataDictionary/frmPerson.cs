
///*************************************************************************/
///*
///* 文件名    ：frmPerson.cs    
///*
///* 程序说明  :  销售员管理(数据字典开发模板窗体)
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
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework.Core;
using CSFramework3.Business;
using CSFramework3.Models;

namespace CSFramework3.DataDictionary
{
    /// <summary>
    /// 销售员管理(数据字典开发模板窗体)
    /// </summary>
    public partial class frmPerson : frmBaseDataDictionary
    {
        public frmPerson()
        {
            InitializeComponent();
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作
        }

        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);//给成员变量赋值.每个业务窗体必需给这个变量赋值.
            _ActiveEditor = txtCode;
            _DetailGroupControl = gcDetailEditor;
            _BLL = new bllPerson();

            base.InitializeForm();
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            txtCode.Enabled = UpdateType.Add == currentState;
        }

        // 检查主表数据是否完整或合法
        protected override bool ValidatingData()
        {
            if (txtCode.Text == string.Empty)
            {
                Msg.Warning("销售员编号不能为空!");
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == string.Empty)
            {
                Msg.Warning("销售员姓名不能为空!");
                txtName.Focus();
                return false;
            }

            if (_UpdateType == UpdateType.Add)
            {
                if (_BLL.CheckNoExists(txtCode.Text))
                {
                    Msg.Warning("销售员编号已存在!");
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
                DataBinder.BindingTextEdit(txtCode, summary, tb_Person._SalesCode);
                DataBinder.BindingTextEdit(txtName, summary, tb_Person._SalesName);
                DataBinder.BindingTextEdit(txtDept.InnerLookupEdit, summary, tb_Person._Department);
                DataBinder.BindingCheckEdit(chkInUse, summary, tb_Person._InUse);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
    }
}
