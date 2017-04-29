
///*************************************************************************/
///*
///* 文件名    ：LoginAuthorization.cs      
///
///* 程序说明  : 系统登录策略
///               1.系统内部用户授权 2.Novell网用户授权 3.Windows域用户授权
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CSFramework.Common;
using System.Drawing;
using CSFramework3.Business;
using System.Data;
using CSFramework3.Models;
using CSFramework.Core;

using CSFramework3.Interfaces;
using CSFramework3.Bridge;

namespace CSFramework3.Business.Security
{

    /// <summary>
    /// 系统内部用户授权
    /// </summary>
    public class LoginSystemAuth : ILoginAuthorization
    {
        public bool SupportLogout { get { return true; } }

        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            try
            {
                IBridge_User user = BridgeFactory.CreateUserBridge();
                user.Logout(Loginer.CurrentUser.Account);
            }
            catch
            {

            }
        }

        public bool Login(LoginUser loginUser)
        {
            //调用数据访问层的接口检查用户登录
            //用户登录前尚未创建Loginer对象，所有传null值
            IBridge_User bridge = BridgeFactory.CreateUserBridge();
            DataTable data = bridge.Login(loginUser, Char.Parse(LoginUserType.S.ToString()));
            if (data.Rows.Count == 0) throw new CustomException("登录失败，请检查用户名和密码！");
            DataRow row = data.Rows[0];

            //用户实例,登录成功
            Loginer user = new Loginer();
            user.Account = ConvertEx.ToString(row[TUser.Account]);
            user.AccountName = ConvertEx.ToString(row[TUser.UserName]);
            user.FlagAdmin = ConvertEx.ToString(row[TUser.FlagAdmin]);
            user.Email = ConvertEx.ToString(row[TUser.Email]);
            user.LoginTime = DateTime.Now;

            //参数：dataSet: 帐套编号, 从帐套字典表获取DBName,DataSetID,DataSetName三个字段的值
            //给下面三个属性赋值            
            user.DBName = loginUser.DataSetDBName; //重要：在数据层根据DBName设置连接数据库            
            user.DataSetID = loginUser.DataSetID;

            Loginer.CurrentUser = user;//保存当前用户

            SystemAuthentication.UserAuthorities = bridge.GetUserAuthorities(user); //下载用户权限    

            return true;
        }
    }

    /// <summary>
    ///Novell网用户授权 
    /// </summary>
    public class LoginNovellAuth : ILoginAuthorization
    {
        private Control _User;
        private Label _InfoLable;

        public LoginNovellAuth(Control user, Label infoLabel)
        {
            _User = user;
            _InfoLable = infoLabel;
        }

        public bool SupportLogout { get { return false; } }

        public void Logout()
        {

        }

        public bool Login(LoginUser loginUser)
        {
            string novellAccount = NovellLdapTools.NovellWhoAmI();

            //获取当前Novell用户及组. 通过groups获取用户权限数据
            //string[] groups = NovellLdapTools.NovellGetGroups(ref novellAccount);            

            if (string.IsNullOrEmpty(novellAccount))
                throw new CustomException("获取Novell本地用户登录资料失败！");

            _User.Text = novellAccount; //显示当前Novell帐号
            _User.Update();

            loginUser.Account = novellAccount;

            IBridge_User bridge = BridgeFactory.CreateUserBridge();

            //调用数据访问层的接口检查用户登录
            DataTable dt = bridge.Login(loginUser, Char.Parse(LoginUserType.N.ToString()));
            if (dt.Rows.Count == 0) throw new CustomException("Novell用户'" + novellAccount + "'没有建立权限关联！");
            DataRow row = dt.Rows[0];

            Loginer user = new Loginer();
            user.Account = ConvertEx.ToString(row[TUser.Account]);
            user.AccountName = ConvertEx.ToString(row[TUser.UserName]);
            user.FlagAdmin = ConvertEx.ToString(row[TUser.FlagAdmin]);
            user.Email = ConvertEx.ToString(row[TUser.Email]);
            user.LoginTime = DateTime.Now;

            Loginer.CurrentUser = user;//保存当前用户
            SystemAuthentication.UserAuthorities = bridge.GetUserAuthorities(user);//下载用户权限

            return true;
        }
    }

    /// <summary>
    /// Windows域用户授权
    /// </summary>
    public class LoginWindowsDomainAuth : ILoginAuthorization
    {
        private Control _User;
        private Label _InfoLable;

        public LoginWindowsDomainAuth(Control user, Label infoLabel)
        {
            _User = user;
            _InfoLable = infoLabel;
        }

        public bool SupportLogout { get { return false; } }

        public void Logout()
        {

        }

        public bool Login(LoginUser loginUser)
        {
            string userPrincipalName = DomainLdapTools.GetCurrentUserPrincipalName();

            if (string.IsNullOrEmpty(userPrincipalName))
                throw new CustomException("获取本地域用户资料失败！");

            _User.Text = userPrincipalName; //显示当前Domain帐号
            _User.Update();

            loginUser.Account = userPrincipalName;

            IBridge_User bridge = BridgeFactory.CreateUserBridge();

            //调用数据访问层的接口检查用户登录
            DataTable dt = bridge.Login(loginUser, Char.Parse(LoginUserType.W.ToString()));
            if (dt.Rows.Count == 0) throw new CustomException("域用户'" + userPrincipalName + "'没有建立权限关联！");
            DataRow row = dt.Rows[0];

            Loginer user = new Loginer();
            user.Account = ConvertEx.ToString(row[TUser.Account]);
            user.AccountName = ConvertEx.ToString(row[TUser.UserName]);
            user.FlagAdmin = ConvertEx.ToString(row[TUser.FlagAdmin]);
            user.Email = ConvertEx.ToString(row[TUser.Email]);
            user.LoginTime = DateTime.Now;
            Loginer.CurrentUser = user;//保存当前用户

            //下载用户权限
            SystemAuthentication.UserAuthorities = bridge.GetUserAuthorities(user);

            return true;
        }
    }


}
