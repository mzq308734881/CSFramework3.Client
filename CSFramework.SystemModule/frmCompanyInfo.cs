///*************************************************************************/
///*
///* 文件名    ：frmCompanyInfo.cs    
///*
///* 程序说明  : 公司资料设置
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
using CSFramework.Library;
using CSFramework3.Models;
using CSFramework3.Interfaces;
using CSFramework.Core;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 公司资料设置
    /// </summary>
    public partial class frmCompanyInfo : frmBaseDataDictionary
    {
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            _BLL = new bllCompanyInfo(); //业务逻辑层
            _BLL.GetSummaryData(true);//获取数据
            _DetailGroupControl = gcDetailEditor;

            this.InitializeForm();
            BindingSummaryEditor(_BLL.SummaryTable); //绑定输入控件
            ButtonStateChanged(UpdateType.None);
            this.ShowDetailPage(true);
            tpSummary.Hide();
        }

        public override void DoCancel(IButtonInfo sender)
        {
            if (!Msg.AskQuestion("要取消修改吗?")) return;

            _BLL.GetSummaryData(true);//获取数据
            BindingSummaryEditor(_BLL.SummaryTable); //绑定输入控件

            this._UpdateType = UpdateType.None;
            this.SetViewMode();
            this.ButtonStateChanged(_UpdateType);
        }

        public override void DoEdit(IButtonInfo sender)
        {
            this._UpdateType = UpdateType.Modify;
            this.SetEditMode();
            this.ButtonStateChanged(_UpdateType);
        }

        public override void DoSave(IButtonInfo sender)
        {
            this.UpdateLastControl();

            if (txtCompanyCode.Text == "")
            {
                Msg.Warning("公司编号不能为空！");
                txtCompanyCode.Focus();
                return;
            }

            if (txtNativeName.Text == "")
            {
                Msg.Warning("公司中文名称不能为空！");
                txtNativeName.Focus();
                return;
            }

            if (_BLL.Update(_UpdateType))
            {
                this._UpdateType = UpdateType.None;
                this.SetViewMode();
                this.ButtonStateChanged(_UpdateType);
                Msg.ShowInformation("保存成功！");
            }
            else
                Msg.ShowInformation("保存失败！");
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            bool accessable = currentState == UpdateType.Add || currentState == UpdateType.Modify;
            base.SetDetailEditorsAccessable(gcDetailEditor, accessable);
            base.ButtonStateChanged(currentState);

            //禁用数据操作按钮
            _buttons.GetButtonByName("btnView").Enable = false;
            _buttons.GetButtonByName("btnAdd").Enable = false;
            _buttons.GetButtonByName("btnDelete").Enable = false;
            _buttons.GetButtonByName("btnPrint").Enable = false;
            _buttons.GetButtonByName("btnPreview").Enable = false;
        }

        private void BindingSummaryEditor(object summary)
        {
            try
            {
                if (summary == null) return;
                DataBinder.BindingTextEdit(txtCompanyCode, summary, tb_CompanyInfo.CompanyCode);
                DataBinder.BindingTextEdit(txtEnglishName, summary, tb_CompanyInfo.EnglishName);
                DataBinder.BindingTextEdit(txtNativeName, summary, tb_CompanyInfo.NativeName);
                DataBinder.BindingTextEdit(txtProgramName, summary, tb_CompanyInfo.ProgramName);

                DataBinder.BindingTextEdit(txtAddress, summary, tb_CompanyInfo.Address);
                DataBinder.BindingTextEdit(txtFax, summary, tb_CompanyInfo.Fax);
                DataBinder.BindingTextEdit(txtReportHead, summary, tb_CompanyInfo.ReportHead);
                DataBinder.BindingTextEdit(txtTel, summary, tb_CompanyInfo.Tel);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
    }
}
