
///*************************************************************************/
///*
///* 文件名    ：ActionNodeTag.cs    
///*
///* 程序说明  : 权限标记(标记增/删/改等功能)
///*              用于权限管理的树视图操作，标记树结点是否增/删/改
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Business.Security
{
    /// <summary>
    /// 权限标记(标记增/删/改等功能)
    /// 用于权限管理的树视图操作，标记树结点是否增/删/改
    /// </summary>
    public class ActionNodeTag
    {
        /// <summary>
        /// 权限值
        /// </summary>
        private int _ActionValue = 0;

        /// <summary>
        /// 资料行
        /// </summary>
        private DataRow _DataRow = null;

        /// <summary>
        /// 菜单名变量
        /// </summary>
        private string _TagMenuNameRef = "";

        /// <summary>
        /// 功能点对应的按钮标题
        /// </summary>
        private string _TagNameOld = "";

        /// <summary>
        /// 功能点的资料行
        /// </summary>
        private DataRow _TagNameDataRow = null;

        /// <summary>
        /// 功能点的数据表
        /// </summary>
        private DataTable _TagNameTable = null;


        public ActionNodeTag(int actionValue, DataRow row)
        {
            _ActionValue = actionValue;
            _DataRow = row;
        }

        /// <summary>
        /// 权限值
        /// </summary>
        public int ActionValue { get { return _ActionValue; } set { _ActionValue = value; } }

        /// <summary>
        /// 对应的权限记录
        /// </summary>
        public DataRow DataRow { get { return _DataRow; } set { _DataRow = value; } }

        /// <summary>
        /// 功能点的资料行
        /// </summary>
        public DataRow TagNameDataRow { get { return _TagNameDataRow; } set { _TagNameDataRow = value; } }

        /// <summary>
        /// 功能点的数据表
        /// </summary>
        public DataTable TagNameTable { get { return _TagNameTable; } set { _TagNameTable = value; } }

        /// <summary>
        /// 功能点对应的按钮标题
        /// </summary>
        public string TagNameOld { get { return _TagNameOld; } set { _TagNameOld = value; } }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string TagMenuNameRef { get { return _TagMenuNameRef; } set { _TagMenuNameRef = value; } }
    }

}
