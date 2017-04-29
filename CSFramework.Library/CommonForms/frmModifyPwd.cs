///*************************************************************************/
///*
///* 文件名    ：frmModifyPwd.cs                   
///* 程序说明  : 修改密码
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
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Business;
using CSFramework3.Business.Security;

namespace CSFramework.Library
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public partial class frmModifyPwd : frmBaseDialog
    {
        private LoginUser _user = null;

        private ModifyPwdType _type;

        //私有构造器
        private frmModifyPwd()
        {
            InitializeComponent();
        }

        private void frmModifyPwd_Load(object sender, EventArgs e)
        {
            BindingDataSet();

            //此段代码仅用户管理窗体修改密码有效
            if (ModifyPwdType.UserManage == _type)
            {
                if (Loginer.CurrentUser.IsAdmin())
                {
                    txtOldPwd.Text = "************";//仅用于显示
                    txtOldPwd.Enabled = false;
                }

                //普通用户仅修改本人的密码
                if (false == Loginer.CurrentUser.IsAdmin())
                {
                    //如果已经登录，修改当前用户的密码
                    if (Loginer.CurrentUser.Account != string.Empty)
                    {
                        txtAccount.Text = Loginer.CurrentUser.Account;
                        txtAccount.Enabled = false;
                    }
                }
            }
        }

        private void BindingDataSet()
        {
            DataTable data = CommonData.GetSystemDataSet();
            DataBinder.BindingLookupEditDataSource(txtDataset, data, "DataSetName", "DataSetID");
            txtDataset.EditValue = _user.DataSetID;
        }


        /// <summary>
        /// 执行窗体.参数:loginInfo为登录对象ss
        /// </summary>
        public static void Execute(LoginUser user, ModifyPwdType type)
        {
            frmModifyPwd form = new frmModifyPwd();
            form.txtAccount.Text = user.Account;
            form._user = user;
            form._type = type;
            form.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text.Trim() == string.Empty)
            {
                Msg.Warning("请输入登录帐号！");
                txtAccount.Focus();
                return;
            }

            if (txtOldPwd.EditValue == null || txtOldPwd.EditValue.ToString().Trim() == string.Empty)
            {
                Msg.Warning("请输入旧密码！");
                txtOldPwd.Focus();
                return;
            }

            //取修改密码用户的资料
            DataTable dt = new bllUser().GetUserDirect(txtAccount.Text, _user.DataSetDBName);
            if (dt.Rows.Count > 0)
            {
                //管理员修改用户密码不需要验证旧密码
                if (false == Loginer.CurrentUser.IsAdmin())
                {
                    string pwd = CEncoder.Decode(dt.Rows[0][TUser.Password].ToString());
                    if (pwd != txtOldPwd.Text.Trim())
                    {
                        Msg.Warning("所输入旧密码不正确！");
                        txtOldPwd.Focus();
                        return;
                    }
                }
            }
            else
            {
                Msg.Warning("登录帐号'" + txtAccount.Text + "'不存在！");
                return;
            }

            if (txtPwdF.EditValue == null || txtPwdF.EditValue.ToString().Trim() == string.Empty)
            {
                Msg.Warning("请输入新密码！");
                txtPwdF.Focus();
                return;
            }

            if (txtPwdF.Text.Trim().Length < 3)
            {
                Msg.Warning("密码长度必须大于2位!");
                txtPwdF.Focus();
                return;
            }

            if (txtPwdS.EditValue == null || txtPwdS.EditValue.ToString().Trim() == string.Empty)
            {
                Msg.Warning("请确认新密码！");
                txtPwdS.Focus();
                return;
            }

            if (txtPwdF.EditValue.ToString() != txtPwdS.EditValue.ToString())
            {
                Msg.Warning("两次新密码不相同！");
                txtPwdF.Focus();
                return;
            }

            if (Msg.AskQuestion("要修改密码？"))
            {
                bool success = new bllUser().ModifyPasswordDirect(txtAccount.Text, CEncoder.Encode(txtPwdF.Text), _user.DataSetDBName);
                if (success)
                {
                    _user.Password = txtPwdF.Text;
                    Msg.ShowInformation("修改成功！");
                    this.Close();
                }
                else
                {
                    Msg.Warning("修改出错！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModifyPwd_Activated(object sender, EventArgs e)
        {
            if (txtAccount.CanFocus)
                txtAccount.Focus();
            else
                txtOldPwd.Focus();
        }

        private void frmModifyPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }

    /// <summary>
    /// 修改密码类型
    /// </summary>
    public enum ModifyPwdType
    {
        /// <summary>
        /// 登录窗体直接修改密码
        /// </summary>
        LoginWindowDirect,

        /// <summary>
        /// 用户管理窗体修改密码
        /// </summary>
        UserManage
    }

}


