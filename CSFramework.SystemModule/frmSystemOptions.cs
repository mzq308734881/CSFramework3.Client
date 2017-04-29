///*************************************************************************/
///*
///* 文件名    ：frmSystemOptions.cs                   
///* 程序说明  : 系统参数定义窗体
///* 原创作者  ：孙中吕 
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
using CSFramework.Library;
using CSFramework.Common;
using CSFramework.Core;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 系统参数定义窗体
    /// </summary>
    public partial class frmSystemOptions : frmBaseDialog
    {
        public frmSystemOptions()
        {
            InitializeComponent();
        }

        private void frmSystemOptions_Load(object sender, EventArgs e)
        {
            SkinTools.LoadSkin(txtSkins); //加载皮肤列表

            txtSkins.Text = SystemConfig.CurrentConfig.SkinName;
            chkLocalLog.Checked = SystemConfig.CurrentConfig.WriteLocalLog;
            chkAllowRunMultiInstance.Checked = SystemConfig.CurrentConfig.AllowRunMultiInstance;
            chkDoubleClickIntoEditMode.Checked = SystemConfig.CurrentConfig.DoubleClickIntoEditMode;

            rgAuthType.SelectedIndex = SystemConfig.CurrentConfig.LoginAuthType - 1;
            rgUpgraderType.SelectedIndex = SystemConfig.CurrentConfig.UpgradeType - 1;
            txtUpgraderIP.Text = SystemConfig.CurrentConfig.UpgraderServerIP;
            txtUpgraderPort.Text = SystemConfig.CurrentConfig.UpgraderServerPort;
            chkCheckVer.Checked = SystemConfig.CurrentConfig.AutoCheckVersion;
            chkExitAppIfOldVer.Checked = SystemConfig.CurrentConfig.ExitAppIfOldVersion;

            this.xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SystemConfig.CurrentConfig.SkinName = txtSkins.Text;
            SystemConfig.CurrentConfig.WriteLocalLog = chkLocalLog.Checked;
            SystemConfig.CurrentConfig.AllowRunMultiInstance = chkAllowRunMultiInstance.Checked;
            SystemConfig.CurrentConfig.DoubleClickIntoEditMode = chkDoubleClickIntoEditMode.Checked;
            SystemConfig.CurrentConfig.LoginAuthType = rgAuthType.SelectedIndex + 1;
            SystemConfig.CurrentConfig.UpgradeType = rgUpgraderType.SelectedIndex + 1;
            SystemConfig.CurrentConfig.UpgraderServerIP = txtUpgraderIP.Text;
            SystemConfig.CurrentConfig.UpgraderServerPort = txtUpgraderPort.Text;
            SystemConfig.CurrentConfig.AutoCheckVersion = chkCheckVer.Checked;
            SystemConfig.CurrentConfig.ExitAppIfOldVersion = chkExitAppIfOldVer.Checked;
            SystemConfig.WriteSettings(SystemConfig.CurrentConfig);
            this.Close();
        }

        private void btnApplySkin_Click(object sender, EventArgs e)
        {
            if (txtSkins.SelectedItem != null)
                SkinTools.SetSkin(txtSkins.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtSkins.Text != SystemConfig.CurrentConfig.SkinName)
                SkinTools.SetSkin(SystemConfig.CurrentConfig.SkinName);
        }
    }
}