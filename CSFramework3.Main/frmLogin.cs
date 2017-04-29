
///*************************************************************************/
///*
///* 文件名    ：frmLogin.cs    
///*
///* 程序说明  : 登录窗体
///*              登录成功后加载MDI主窗体，同时加载进度在登录窗体内显示
///
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
using System.Threading;
using System.Windows.Forms;
using CSFramework3.Business;
using CSFramework.Common;
using CSFramework.Library;
using CSFramework3.Business.Security;
using CSFramework.Core;
using CSFramework3.Interfaces;
using System.IO;
using CSFramework3.Models;
using CSFramework3.Bridge;

namespace CSFramework3.Main
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class frmLogin : frmBase
    {
        private ILoginAuthorization _CurrentAuthorization = null;//当前授权模式

        /// <summary>
        /// 私有构造器
        /// </summary>
        private frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            InitLoginWindow(); //初始化登陆窗体
        }

        /// <summary>
        /// 显示登陆窗体.(公共静态方法)
        /// </summary>        
        public static bool Login()
        {
            frmLogin form = new frmLogin();
            DialogResult result = form.ShowDialog();
            bool ret = (result == DialogResult.OK) && (SystemAuthentication.Current != null);
            return ret;
        }

        /// <summary>
        /// 初始化登陆窗体, 创建登录策略
        /// </summary>
        private void InitLoginWindow()
        {
            this.BindingDataSet();//绑定帐套数据源
            this.ReadLoginInfo(); //读取保存的登录信息
            this.Text += " (后台连接:" + BridgeFactory.BridgeType.ToString() + ")";

            SystemAuthentication.Current = null;

            LoginAuthType authType = (LoginAuthType)SystemConfig.CurrentConfig.LoginAuthType; //系统设置
            if (authType == LoginAuthType.LocalSystemAuth)
            {
                _CurrentAuthorization = new LoginSystemAuth();
                btnLogin.Text = "登录 (&L)";
            }
            else if (authType == LoginAuthType.NovellUserAuth)
            {
                _CurrentAuthorization = new LoginNovellAuth(txtUser, lblLoadingInfo);
                btnLogin.Text = "Novell自动登录";

                this.txtPwd.Enabled = false;
                this.txtUser.Enabled = false;
                this.Visible = true;
                this.Update();//自动显示窗体

                btnLogin.PerformClick();//直接登录系统
            }
            else if (authType == LoginAuthType.WindowsDomainAuth)
            {
                _CurrentAuthorization = new LoginWindowsDomainAuth(txtUser, lblLoadingInfo);
                btnLogin.Text = "域用户自动登录";

                this.txtPwd.Enabled = false;
                this.txtUser.Enabled = false;
                this.Visible = true;
                this.Update();//自动显示窗体

                btnLogin.PerformClick();//直接登录系统
            }
            else //不明类型,禁止登录
            {
                pcInputArea.Enabled = false;
                btnLogin.Enabled = false;
            }

        }

        private void ReadLoginInfo()
        {
            //存在用户配置文件，自动加载登录信息
            string cfgINI = Application.StartupPath + BridgeFactory.INI_CFG;
            if (File.Exists(cfgINI))
            {
                IniFile ini = new IniFile(cfgINI);
                txtUser.Text = ini.IniReadValue("LoginWindow", "User");
                txtDataset.EditValue = ini.IniReadValue("LoginWindow", "DataSetID");
                txtPwd.Text = CEncoder.Decode(ini.IniReadValue("LoginWindow", "Password"));
                chkSaveLoginInfo.Checked = ini.IniReadValue("LoginWindow", "SaveLogin") == "Y";
            }
        }

        private void SaveLoginInfo()
        {
            //存在用户配置文件，自动加载登录信息
            string cfgINI = Application.StartupPath + BridgeFactory.INI_CFG;

            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("LoginWindow", "User", txtUser.Text);
            ini.IniWriteValue("LoginWindow", "DataSetID", txtDataset.EditValue.ToString());
            ini.IniWriteValue("LoginWindow", "Password", CEncoder.Encode(txtPwd.Text));
            ini.IniWriteValue("LoginWindow", "SaveLogin", chkSaveLoginInfo.Checked ? "Y" : "N");
        }

        private void BindingDataSet()
        {
            DataTable data = CommonData.GetSystemDataSet();
            DataBinder.BindingLookupEditDataSource(txtDataset, data, "DataSetName", "DataSetID");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SetButtonEnable(false);
                this.Update();//必须
                this.ShowLoginInfo("正在验证用户名及密码");

                bllUser.ValidateLogin(txtUser.Text, txtPwd.Text);//检查登录信息

                string userID = txtUser.Text;
                string password = CEncoder.Encode(txtPwd.Text);/*常规加密*/
                string dataSetID = txtDataset.EditValue.ToString();//帐套编号
                string dataSetDB = GetDataSetDBName();

                LoginUser loginUser = new LoginUser(userID, password, dataSetID, dataSetDB);

                if (_CurrentAuthorization.Login(loginUser)) //调用登录策略
                {
                    if (chkSaveLoginInfo.Checked) this.SaveLoginInfo();//跟据选项保存登录信息                    
                    SystemAuthentication.Current = _CurrentAuthorization; //授权成功, 保存当前授权模式
                    Program.MainForm = new frmMain();//登录成功创建主窗体                    
                    Program.MainForm.InitUserInterface(new LoadStatus(lblLoadingInfo));
                    this.DialogResult = DialogResult.OK; //成功
                    this.Close(); //关闭登陆窗体
                }
                else
                {
                    this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                    Msg.Warning("登录失败，请检查用户名和密码!");
                }
            }
            catch (CustomException ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo(ex.Message);
                Msg.Warning(ex.Message);
            }
            catch (Exception ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                Msg.Warning("登录失败，请检查用户名和密码!");
            }

            this.Cursor = Cursors.Default;
        }

        private string GetDataSetDBName()
        {
            DataRowView view = (DataRowView)txtDataset.Properties.GetDataSourceRowByKeyValue(txtDataset.EditValue);
            return ConvertEx.ToString(view.Row["DBName"]);
        }


        private void ShowLoginInfo(string info)
        {
            lblLoadingInfo.Text = info;
            lblLoadingInfo.Update();
        }

        private void SetButtonEnable(bool value)
        {
            btnLogin.Enabled = value;
            btnCancel.Enabled = value;
            btnLogin.Update();
            btnCancel.Update();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Msg.AskQuestion("确定要退出系统吗？")) Application.Exit();
        }

        private void btnModifyPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginUser user = new LoginUser();
            user.Account = txtUser.Text;
            user.DataSetID = txtDataset.EditValue.ToString();
            user.DataSetDBName = GetDataSetDBName();
            frmModifyPwd.Execute(user, ModifyPwdType.LoginWindowDirect);
        }
    }
}