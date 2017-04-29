
///*************************************************************************/
///*
///* 文件名    ：bllCompanyInfo.cs      
///
///* 程序说明  : 公司资料管理业务逻辑层
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.Common;
using CSFramework3.Models;


using CSFramework3.Bridge;
using CSFramework3.Business.BLL_Base;


namespace CSFramework3.Business
{
    /// <summary>
    /// 公司资料管理业务逻辑层
    /// </summary>
    public class bllCompanyInfo : bllBaseDataDict
    {
        public bllCompanyInfo()
        {
            _KeyFieldName = tb_CompanyInfo.CompanyCode;
            _SummaryTableName = tb_CompanyInfo.__TableName;
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_CompanyInfo));
        }

        private bool _IsAdd = false;

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="updateType">操作类型</param>
        /// <returns></returns>
        public override bool Update(UpdateType updateType)
        {
            _SummaryTable.Rows[0][tb_CompanyInfo.LastUpdateDate] = DateTime.Now;
            _SummaryTable.Rows[0][tb_CompanyInfo.LastUpdatedBy] = Loginer.CurrentUser.Account;

            _SummaryTable.AcceptChanges();

            if (_IsAdd)
                _SummaryTable.Rows[0].SetAdded();
            else
                _SummaryTable.Rows[0].SetModified();

            DataSet ds = new DataSet();
            ds.Tables.Add(_SummaryTable.Copy());
            bool ret = _DataDictBridge.Update(ds); //调用DAL层更新数据

            if (ret)
            {
                _SummaryTable.AcceptChanges();
                _IsAdd = false;
            }

            return ret;
        }

        /// <summary>
        /// 获取公司资料
        /// </summary>
        public override DataTable GetSummaryData(bool resetCurrent)
        {
            _SummaryTable = _DataDictBridge.GetSummaryData();

            if (_SummaryTable.Rows.Count == 0)
            {
                DataRow row = _SummaryTable.NewRow();
                row[tb_CompanyInfo.ISID] = "1";
                row[tb_CompanyInfo.CreatedBy] = Loginer.CurrentUser.Account;
                row[tb_CompanyInfo.CreationDate] = DateTime.Now;
                _SummaryTable.Rows.Add(row);
                _IsAdd = true;
            }
            else _IsAdd = false;

            return _SummaryTable;
        }
    }
}
