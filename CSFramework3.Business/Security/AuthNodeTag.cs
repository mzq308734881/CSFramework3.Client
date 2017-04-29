
///*************************************************************************/
///*
///* 文件名    ：AuthNodeTag.cs        
///
///* 程序说明  : 用于标志增加或删除权限
///               树结点与对应的权限记录建立映射关系,用于标志增加或删除权限.
///               当选中树结点表示新增权限，取消选中表示删除权限.
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CSFramework.Common;

namespace CSFramework3.Business.Security
{
    /// <summary>
    /// 树结点与对应的权限记录建立映射关系,用于标志增加或删除权限.
    /// 当选中树结点表示新增权限，取消选中表示删除权限.
    /// 
    /// </summary>
    public class AuthNodeTag
    {
        private string _AuthID;//对应菜单名称
        private DataRow _DataRow;//数据行
        private ToolStripItem _MenuItem;//对应菜单

        public AuthNodeTag() { }

        public AuthNodeTag(string authID, DataRow dataRow, ToolStripItem menuItem)
        {
            _AuthID = authID;
            _DataRow = dataRow;
            _MenuItem = menuItem;

        }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType MenuType
        {
            get
            {
                if (_MenuItem != null && _MenuItem.Tag != null)
                    return (_MenuItem.Tag as MenuItemTag).MenuType;
                return MenuType.Unknow;
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        public ToolStripItem MenuItem
        {
            get { return _MenuItem; }
            set { _MenuItem = value; }
        }

        /// <summary>
        /// 权限编号,实为菜单名称
        /// </summary>
        public string AuthID
        {
            get { return _AuthID; }
            set { _AuthID = value; }
        }

        /// <summary>
        /// 树结点对应的权限记录
        /// 当选中树结点时新增一条记录，取消选中时该变量为null.
        /// </summary>
        public DataRow DataRow
        {
            get { return _DataRow; }
            set { _DataRow = value; }
        }
    }
}
