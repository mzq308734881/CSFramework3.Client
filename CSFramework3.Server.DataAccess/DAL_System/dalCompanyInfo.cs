///*************************************************************************/
///*
///* 文件名    ：dalCommonService.cs                                
///* 程序说明  : 公共数据层
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 公司资料设置
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_CompanyInfo),true)]
    public class dalCompanyInfo : dalBaseDataDict
    {
        public dalCompanyInfo(Loginer loginer)
            : base(loginer)
        {
            _TableName = tb_CompanyInfo.__TableName;
            _KeyName = tb_CompanyInfo.__KeyName;
            _ModelType = typeof(tb_CompanyInfo);
        }
    }
}
