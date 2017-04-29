///*************************************************************************/
///*
///* 文件名    ：ButtonAuthority.cs                                      
///* 程序说明  : 系统权限功能点定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.Common
{
    /// <summary>
    ///每个功能点按钮对应的数值. 定义为2^n次方(n>0)    
    ///每个窗体最多支持20个功能按钮(权限按钮)，对于一般的系统来讲完全足够。
    /// </summary>
    public class ButtonAuthority
    {
        /// <summary>
        /// 未定义
        /// </summary>
        public const int NONE = 0;

        /// <summary>
        /// 新增功能
        /// </summary>
        public const int ADD = 1;

        /// <summary>
        /// 删除
        /// </summary>
        public const int DELETE = 2;

        /// <summary>
        /// 修改
        /// </summary>
        public const int EDIT = 4;

        /// <summary>
        /// 批准(审核/核对)
        /// </summary>
        public const int APPROVAL = 8;

        /// <summary>
        /// 变更单据版本
        /// </summary>
        public const int CHANGE_VERSION = 16;

        /// <summary>
        /// 打印
        /// </summary>
        public const int PRINT = 32;

        /// <summary>
        /// 打印预览
        /// </summary>
        public const int PREVIEW = 64;

        /// <summary>
        /// 作废单据
        /// </summary>
        public const int VOID = 128;

        /// <summary>
        /// 生成单据
        /// </summary>
        public const int GENERATE = 256;

        /// <summary>
        /// 复制单据
        /// </summary>
        public const int CLONE = 512;

        /// <summary>
        /// 导出数据，如:Excel,PDF文件
        /// </summary>
        public const int EXPORT = 1024;

        /// <summary>
        /// 锁定 
        /// </summary>
        public const int LOCK = 2048;

        /// <summary>
        /// 单据反向操作(如反锁定,反审核)
        /// </summary>
        public const int UNDO = 4096;

        /// <summary>
        /// 预留权限
        /// </summary>
        public const int RESERVED = 8192;

        /// <summary>
        /// 查看版本历史记录
        /// </summary>
        public const int SHOW_VER_HISTORY = 16384;

        /// <summary>
        /// 查看数据修改历史记录
        /// </summary>
        public const int SHOW_MOD_HISTORY = 32768;

        /// <summary>
        /// 扩展权限EX_01:65566
        /// </summary>
        public const int EX_01 = 65536;

        /// <summary>
        /// 扩展权限EX_02:131072
        /// </summary>
        public const int EX_02 = 131072;

        /// <summary>
        /// 扩展权限EX_03:262144
        /// </summary>
        public const int EX_03 = 262144;

        /// <summary>
        /// 扩展权限EX_04:524288
        /// </summary>
        public const int EX_04 = 524288;

    }

    /// <summary>
    /// 权限分类
    /// </summary>
    public class AuthorityCategory
    {
        public const int NONE = 0;

        /// <summary>
        /// 数据窗体拥有的功能
        /// </summary>
        public const int DATA_ACTION_VALUE = ButtonAuthority.ADD + ButtonAuthority.EDIT + ButtonAuthority.DELETE;

        /// <summary>
        /// 报表窗体拥有的功能
        /// </summary>
        public const int REPORT_ACTION_VALUE = ButtonAuthority.PREVIEW + ButtonAuthority.PRINT;  //2^2  控制打印功能,Export

        /// <summary>
        /// 业务单据拥有的功能
        /// </summary>
        public const int BUSINESS_ACTION_VALUE = DATA_ACTION_VALUE + REPORT_ACTION_VALUE +
            ButtonAuthority.APPROVAL +
            ButtonAuthority.CHANGE_VERSION +
            ButtonAuthority.SHOW_MOD_HISTORY +
            ButtonAuthority.SHOW_VER_HISTORY;

        /// <summary>
        /// 数据字典拥有的功能
        /// </summary>
        public const int MASTER_ACTION = DATA_ACTION_VALUE + REPORT_ACTION_VALUE;

        /// <summary>
        /// 所有功能
        /// </summary>
        public const int ALL_ACTION_VALUE =
            DATA_ACTION_VALUE +
            REPORT_ACTION_VALUE +
            BUSINESS_ACTION_VALUE;
    }


}

