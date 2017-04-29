///*************************************************************************/
///*
///* 文件名    ：dalMenu.cs                                
///* 程序说明  : 菜单数据字典的DAL层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework3.Models;
using CSFramework.ORM;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 菜单数据字典的DAL层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(TMenu), true)]
    public class dalMenu : dalBaseDataDict
    {
        public dalMenu(Loginer loginer)
            : base(loginer)
        {
            _KeyName = TMenu.__KeyName;
            _TableName = TMenu.__TableName;
            _ModelType = typeof(TMenu);
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == TMenu.__TableName) ORM = typeof(TMenu);
            if (tableName == TFormTagName.__TableName) ORM = typeof(TFormTagName);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            //支持两种SQL命令生成器
            return new GenerateSqlCmdByTableFields(ORM);

        }

    }
}
