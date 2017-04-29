///*************************************************************************/
///*
///* 文件名    ：SystemAuthentication.cs                                
///* 程序说明  : 系统授权全局公共类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CSFramework3.Interfaces;
using CSFramework.Common;

namespace CSFramework.Core
{
    /// <summary>
    /// 系统授权全局公共类
    /// </summary>
    public class SystemAuthentication
    {
        /// <summary>
        /// 当前用户的权限数据
        /// </summary>
        private static DataTable _UserAuthorities = null;

        /// <summary>
        /// 当前用户的权限数据
        /// </summary>
        public static DataTable UserAuthorities
        {
            get { return _UserAuthorities; }
            set { _UserAuthorities = value; }
        }

        /// <summary>
        /// 系统登录策略
        /// </summary>
        private static ILoginAuthorization _Current = null;

        /// <summary>
        /// 系统预设的授权模式
        /// </summary>
        public static ILoginAuthorization Current
        {
            get { return _Current; }
            set { _Current = value; }
        }

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public static Loginer User
        {
            get { return Loginer.CurrentUser; }
        }

        /// <summary>
        /// 设置窗体的权限
        /// </summary>
        /// <param name="form">支持权限控制的窗体</param>
        /// <param name="authorityID">窗体的可用权限</param>
        public static void SetFormAuthority(IPurviewControllable form, string authorityID)
        {
            DataRow[] rows = SystemAuthentication.UserAuthorities.Select(string.Format("AuthorityID='{0}'", authorityID));

            DataRow authority = (rows != null) && (rows.Length > 0) ? rows[0] : null;
            if (authority != null)
            {
                int actions = ConvertEx.ToInt(authority["Authorities"].ToString());
                (form as IPurviewControllable).FormAuthorities = actions;
            }
            else
                (form as IPurviewControllable).FormAuthorities = 0;
        }

        /// <summary>
        /// 检查窗体的权限是否拥有参数authorityValue的权限
        /// </summary>
        /// <param name="formAuthorities">窗体的权限</param>
        /// <param name="authorityValue">权限值(功能点的权限值)</param>
        /// <returns></returns>
        public static bool ButtonAuthorized(int formAuthorities, int authorityValue)
        {
            if (authorityValue == ButtonAuthority.NONE) return true;

            if (Loginer.CurrentUser.IsAdmin()) return true; //超级用户

            //逻辑运算(与and运算)
            return (authorityValue & formAuthorities) == authorityValue;
        }

        /// <summary>
        /// 设置主菜单的权限。取当前用户拥有的权限，
        /// 枚举所有菜单，没有权限的菜单隐藏。
        /// </summary>
        /// <param name="menuStrip"></param>
        public static void SetMenuAuthority(MenuStrip menuStrip)
        {
            foreach (ToolStripItem item in menuStrip.Items)
            {
                if (item.Tag != null && item.Tag.ToString() == "IsSystemMenu") continue;

                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu = item as ToolStripMenuItem;
                    if (menu.DropDown.Items.Count > 0) SetMenuItemSecurity(menu);
                }
            }
        }

        /// <summary>
        /// 递归设置菜单的权限
        /// </summary>
        /// <param name="parent">父级菜单</param>
        private static void SetMenuItemSecurity(ToolStripMenuItem parent)
        {
            if ((!Loginer.CurrentUser.IsAdmin()) && (SystemAuthentication.UserAuthorities == null))
                throw new Exception("User does't login!");

            //The parent menuitem object will disabled if all child menuitem is disabled.
            bool hasShow = false;

            foreach (ToolStripItem sub in parent.DropDown.Items)
            {
                if (sub is ToolStripMenuItem)
                {
                    DataRow[] rows = SystemAuthentication.UserAuthorities.Select(string.Format("AuthorityID='{0}' ", sub.Name));
                    ToolStripMenuItem menu = sub as ToolStripMenuItem;
                    //窗体
                    if (menu.DropDown.Items.Count == 0)
                    {
                        sub.Enabled = Loginer.CurrentUser.IsAdmin() || rows != null && rows.Length > 0;
                        sub.Visible = sub.Enabled; //No right,No Menu
                        if (sub.Enabled) hasShow = true;
                    }

                    if (menu.DropDown.Items.Count > 0)
                    {
                        SetMenuItemSecurityChild(menu, ref hasShow);
                    }
                }
            }

            //Process the parent menuitem
            parent.Enabled = hasShow;
            parent.Visible = hasShow;
        }

        /// <summary>
        /// 递归设置菜单的权限
        /// </summary>
        /// <param name="parent">父级菜单</param>
        /// /// <param name="hideParentIfAllChildInvisible">如果子菜单都被隐藏，是否要显示父级菜单</param>
        private static void SetMenuItemSecurityChild(ToolStripMenuItem parent, ref bool hideParentIfAllChildInvisible)
        {
            if ((!Loginer.CurrentUser.IsAdmin()) && (SystemAuthentication.UserAuthorities == null)) throw new Exception("User does't login!");

            //The parent menuitem object will disabled if all child menuitem is disabled.
            bool hasShow = false;

            foreach (ToolStripItem sub in parent.DropDown.Items)
            {
                if (sub is ToolStripMenuItem)
                {
                    DataRow[] rows = SystemAuthentication.UserAuthorities.Select(string.Format("AuthorityID='{0}' ", sub.Name));
                    ToolStripMenuItem menu = sub as ToolStripMenuItem;
                    if (menu.DropDown.Items.Count == 0)
                    {
                        sub.Enabled = Loginer.CurrentUser.IsAdmin() || rows != null && rows.Length > 0;
                        sub.Visible = sub.Enabled; //No right,No Menu
                        if (sub.Enabled) hasShow = true;
                    }

                    if (menu.DropDown.Items.Count > 0)
                    {
                        SetMenuItemSecurityChild(menu, ref hasShow);
                    }
                }
            }

            //Process the parent menuitem
            parent.Enabled = hasShow;
            parent.Visible = hasShow;

            if (!hideParentIfAllChildInvisible) hideParentIfAllChildInvisible = hasShow;
        }
    
    }
}
