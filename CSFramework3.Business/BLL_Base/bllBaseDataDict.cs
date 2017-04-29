///*************************************************************************/
///*
///* 文件名    ：bllBaseDataDict.cs                                     
///* 程序说明  : 数据字典业务逻辑层基类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Interfaces;
using CSFramework.Common;
using CSFramework.Core.Log;
using CSFramework3.Bridge;
using CSFramework3.Bridge.DataDictModule;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Business.BLL_Business;

namespace CSFramework3.Business.BLL_Base
{
    /// <summary>
    /// 数据字典业务逻辑层基类
    /// </summary>
    public class bllBaseDataDict : bllBase, ILogSupportable
    {

        /// <summary>
        /// 数据字典连接数据层的接口
        /// </summary>
        protected IBridge_DataDict _DataDictBridge = null;

        /// <summary>
        /// 数据字典(在表格内显示)
        /// </summary>
        protected DataTable _SummaryTable = null;

        /// <summary>
        /// 本次操作的数据(仅一条记录)，当前绑定输入框的数据
        /// </summary>
        protected DataTable _DataBinder = null;

        /// <summary>
        /// 标记是否保存日志
        /// </summary>
        protected bool _WriteDataLog = false;

        /// <summary>
        /// 数据表名
        /// </summary>
        protected string _SummaryTableName = string.Empty;

        /// <summary>
        /// 主键字段名
        /// </summary>
        protected string _KeyFieldName = string.Empty;

        /// <summary>
        /// 主键字段名
        /// </summary>
        public string KeyFieldName { get { return _KeyFieldName; } }

        /// <summary>
        /// 主表名称
        /// </summary>
        public string SummaryTableName { get { return _SummaryTableName; } }

        /// <summary>
        /// 字典数据表
        /// </summary>
        public DataTable SummaryTable { get { return _SummaryTable; } }

        /// <summary>
        /// 当前数据绑定对象(DataTable)
        /// 该表只有一条记录，用于数据修改页面的数据绑定。
        /// </summary>
        public DataTable DataBinder { get { return _DataBinder; } }

        /// <summary>
        /// 因绑定输入控件的数据源为DataTable,所以提供SourceRow创建一个DataTable
        /// </summary>
        public virtual void CreateDataBinder(DataRow sourceRow)
        {
            if (sourceRow == null)
            {
                _DataBinder = _SummaryTable.Clone();
                _DataBinder.Rows.Add(_DataBinder.NewRow());//插入一条空记录
            }
            else
            {
                _DataBinder = sourceRow.Table.Clone();
                _DataBinder.Rows.Add(sourceRow.ItemArray);
            }
        }

        /// <summary>
        /// 保存数据字典
        /// </summary>
        /// <param name="updateType">本次操作状态(新增/修改)</param>
        /// <returns></returns>
        public virtual bool Update(UpdateType updateType)
        {
            DataTable original = null;

            //提交缓存数据，确保输入框的数据已提交到绑定的数据源，将记录状态改变Unchanged.
            _DataBinder.AcceptChanges();

            //再还原记录的状态
            if (updateType == UpdateType.Modify) _DataBinder.Rows[0].SetModified();
            if (updateType == UpdateType.Add) _DataBinder.Rows[0].SetAdded();

            //创建一个副本用于保存
            DataSet data = new DataSet();
            data.Tables.Add(_DataBinder.Copy());

            //取当前记录的主键值
            string key = ConvertEx.ToString(_DataBinder.Rows[0][_KeyFieldName]);

            //如启用日志功能记录本次修改
            if (_WriteDataLog)
            {
                original = _DataDictBridge.GetDataByKey(key); //保存前的原始数据
                this.WriteLog(original, _DataBinder);//保存修改日志
            }

            //调用数据层的方法提交数据
            return _DataDictBridge.Update(data);
        }

        /// <summary>
        /// 保存数据字典，返回由后台自动生成的主键。
        /// </summary>
        /// <param name="updateType">本次操作状态(新增/修改)</param>
        /// <returns>返回结果</returns>
        public virtual SaveResultEx UpdateEx(UpdateType updateType)
        {
            DataTable original = null;

            //提交缓存数据，确保输入框的数据已提交到绑定的数据源，将记录状态改变Unchanged.
            _DataBinder.AcceptChanges();

            //再还原记录的状态
            if (updateType == UpdateType.Modify) _DataBinder.Rows[0].SetModified();
            if (updateType == UpdateType.Add) _DataBinder.Rows[0].SetAdded();

            //创建一个副本用于保存
            DataSet data = new DataSet();
            data.Tables.Add(_DataBinder.Copy());

            //取当前记录的主键值
            string key = ConvertEx.ToString(_DataBinder.Rows[0][_KeyFieldName]);

            //如启用日志功能记录本次修改
            if (_WriteDataLog)
            {
                original = _DataDictBridge.GetDataByKey(key); //保存前的原始数据
                this.WriteLog(original, _DataBinder);//保存修改日志
            }

            //调用数据层的方法提交数据
            return _DataDictBridge.UpdateEx(data);
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="resetCurrent">是否重置本次操作的数据字典</param>
        /// <returns></returns>
        public virtual DataTable GetSummaryData(bool resetCurrent)
        {
            DataTable data = _DataDictBridge.GetSummaryData();
            this.SetDefault(data);

            if (resetCurrent) _SummaryTable = data;
            return data;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public virtual bool Delete(string keyValue)
        {
            return _DataDictBridge.Delete(keyValue);
        }

        /// <summary>
        /// 获取指定主键的数据字典
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public virtual DataTable GetDataByKey(string keyValue)
        {
            return _DataDictBridge.GetDataByKey(keyValue);
        }

        /// <summary>
        /// 检查主键是否存在
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public virtual bool CheckNoExists(string keyValue)
        {
            return _DataDictBridge.CheckNoExists(keyValue);
        }

        /// <summary>
        /// 设置缺省值
        /// </summary>
        /// <param name="data">数据表</param>
        protected virtual void SetDefault(DataTable data) { }

        #region ILogSupportable Members

        /// <summary>
        /// 记录单表日志
        /// </summary>
        /// <param name="changes">修改后的数据</param>
        /// <param name="tableName">表名</param>
        /// <param name="keyFieldName">记录的主键,比较新旧数据时用于定位</param>
        public void WriteLog(DataTable original, DataTable changes)
        {
            string GUID = Guid.NewGuid().ToString().Replace("-", "");

            IBridge_EditLogHistory bridge = bllBusinessLog.CreateEditLogHistoryBridge();
            bridge.WriteLog(GUID, original, changes, _SummaryTableName, _KeyFieldName, true);
        }

        /// <summary>
        /// 写入多表日志. 数据字典是单表.此方法无效
        /// </summary>
        public void WriteLog(DataSet original, DataSet changes) { }

        #endregion
    }
}
