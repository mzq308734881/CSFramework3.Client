///*************************************************************************/
///*
///* 文件名    ：dalAttachFile.cs                                     
///* 程序说明  : 附件管理数据层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework3.Models;
using System.Data;
using CSFramework.ORM;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 附件管理数据层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_AttachFile), true)]
    public class dalAttachFile : dalBaseDataDict, IBridge_AttachFile
    {
        public dalAttachFile(Loginer loginer)
            : base(loginer)
        {
            _TableName = tb_AttachFile.__TableName;
            _KeyName = tb_AttachFile.__KeyName;
            _ModelType = typeof(tb_AttachFile);
        }

        /// <summary>
        /// 获取指定单据的附件数据
        /// </summary>
        /// <param name="docID">单据号码</param>
        /// <returns></returns>
        public DataTable GetData(string docID)
        {
            string sql = "select * from [tb_AttachFile] where [DocID]=@DocID";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@docID", SqlDbType.VarChar, docID);
            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_AttachFile.__TableName);
            return dt;
        }
    }
}
