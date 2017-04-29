///*************************************************************************/
///*
///* 文件名    ：bllNullObjectDataDict.cs    
///*
///* 程序说明  : 数据字典的空业务逻辑类．仅用于初始化实例．
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Business.BLL_Base;


namespace CSFramework3.Business
{
    /// <summary>
    /// 数据字典的空业务逻辑类．仅用于初始化实例．
    /// </summary>
    public class bllNullObjectDataDict : bllBaseDataDict
    {
        public override bool CheckNoExists(string keyValue)
        {
            return false;
        }

        public override void CreateDataBinder(System.Data.DataRow sourceRow)
        {
            //
        }

        public override bool Delete(string keyValue)
        {
            return true;
        }

        public override System.Data.DataTable GetDataByKey(string keyValue)
        {
            return new DataTable();
        }

        public override DataTable GetSummaryData(bool resetCurrent)
        {
            return new DataTable();
        }

        public override bool Update(CSFramework.Common.UpdateType updateType)
        {
            return true;
        }
    }
}
