///*************************************************************************/
///*
///* 文件名    ：dalBaseBusiness.cs                                 
///* 程序说明  : 业务单据数据层基类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CSFramework.Common;
using CSFramework.ORM;
using CSFramework3.Server.DataAccess.DAL_System;

namespace CSFramework3.Server.DataAccess.DAL_Base
{
    /// <summary>
    /// 业务单据数据层基类
    /// </summary>
    public class dalBaseBusiness : dalBase
    {
        /// <summary>
        /// 主表表名
        /// </summary>
        protected string _SummaryTableName = "";

        /// <summary>
        /// 主表主键
        /// </summary>
        protected string _SummaryKeyName = "";

        /// <summary>
        /// 业务单据号码更新类型(如生成流水号，或GUID)
        /// </summary>
        protected UpdateKeyMode _UpdateSummaryKeyMode = UpdateKeyMode.None;

        public dalBaseBusiness(Loginer loginer)
            : base(loginer)
        {
            //
        }

        /// <summary>
        /// 业务单据的保存数据方法
        /// </summary>
        public virtual SaveResult Update(DataSet data)
        {
            /***********************************************************************************
             *  数据更新注意事项:             
             *
             *  1. 参数:data 是业务数据所有更新的数据表. DataSet第1张表为主表，
             *     第2,3,...n张表为明细表或其它相关数据。
             * 
             *  2. 主表的主关键字可能是系统自动生成或用户输入，必须在保存前检查唯一性. 
             *     当_UpdateSummaryKeyMode=UpdateKeyMode.None为用户自行输入单号.
             * 
             *  3. 获取主表主键的值，调用UpdateDetailKey()方法更新所有明细表的外键值
             *     (更新外键：与主表建立关联的字段)                                                                    
             *     
             ************************************************************************************/

            SaveResult mResult = SaveResult.CreateDefault(); //预设保存结果

            string mGUID = string.Empty;
            string mDocNo = string.Empty;

            //非用户手动事务模式，预设启用事务
            if (_UserManualControlTrans == false) this.BeginTransaction();

            if (_CurrentTrans == null) throw new Exception("用户手动控制事务模式下，但您没有启用事务！");

            try
            {
                //更新所有资料表
                foreach (DataTable dt in data.Tables)
                {
                    //仅处理有作修改的资料表
                    if (dt.GetChanges() == null) continue;

                    //根据资料表名获取SQL命令生成器
                    IGenerateSqlCommand gen = this.CreateSqlGenerator(dt.TableName);
                    if (gen == null) continue; //当前数据层无法识别的SQL命令生成器，则不更新当前资料表

                    //本次更新是更新主表,取主表的主键用于设置明细表的外键
                    if (gen.IsSummary())
                    {
                        UpdateSummaryKey(_CurrentTrans, dt, _UpdateSummaryKeyMode, gen.GetPrimaryFieldName(),
                            ref mGUID, gen.GetDocNoFieldName(), ref mDocNo);

                        mResult.GUID = mGUID;
                        mResult.DocNo = mDocNo;
                    }
                    else
                    {
                        //更新明细表的外键
                        if (_UpdateSummaryKeyMode == UpdateKeyMode.OnlyDocumentNo) //单号
                            UpdateDetailKey(dt, gen.GetForeignFieldName(), mDocNo);
                        else if (_UpdateSummaryKeyMode == UpdateKeyMode.OnlyGuid) //GUID
                            UpdateDetailKey(dt, gen.GetForeignFieldName(), mGUID);
                        else if (_UpdateSummaryKeyMode == UpdateKeyMode.None)
                            UpdateDetailKey(dt, gen.GetForeignFieldName(), mDocNo);//不指定更新类型预设为用户输入单号
                    }

                    //使用基于ADO构架的SqlClient组件更新数据
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.RowUpdating += new SqlRowUpdatingEventHandler(OnAdapterRowUpdating);
                    adp.UpdateCommand = GetUpdateCommand(gen, _CurrentTrans);
                    adp.InsertCommand = GetInsertCommand(gen, _CurrentTrans);
                    adp.DeleteCommand = GetDeleteCommand(gen, _CurrentTrans);
                    adp.Update(dt);
                }

                if (_UserManualControlTrans == false) this.CommitTransaction(); //提交事务       
                 
            }
            catch (Exception ex)
            {
                if (_UserManualControlTrans == false) this.RollbackTransaction();//回滚事务      
  
                mResult.SetException(ex); //保存结果设置异常消息

                throw new Exception("更新数据发生错误！Event:Update()\r\n\r\n" + ex.Message);
            }

            return mResult; //返回保存结果
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected virtual IGenerateSqlCommand CreateSqlGenerator(string tableName) { return null; }

        /// <summary>
        /// 获取业务单据流水号
        /// </summary>        
        protected virtual string GetNumber(SqlTransaction tran) { return string.Empty; }

        /// <summary>
        /// 更新明细表的外键
        /// </summary>
        /// <param name="detail">明细表</param>
        /// <param name="foreignFieldName">外键名称</param>
        /// <param name="foreignKeyValue">外键值</param>
        protected void UpdateDetailKey(DataTable detail, string foreignFieldName, string foreignKeyValue)
        {
            if (detail == null) return;
            if (foreignFieldName == "") throw new Exception("明细表没指定外键, 请检查表模型定义！");
            if (foreignKeyValue == "") throw new Exception("外键是空值！表:" + detail.TableName);

            foreach (DataRow row in detail.Rows)
            {
                //仅新增记录才需要更新外键，注意状态的使用
                if (row.RowState == DataRowState.Added)
                {
                    row[foreignFieldName] = foreignKeyValue;
                }
            }
        }

        /// <summary>
        /// 更新主表主键
        /// </summary>
        /// <param name="tran">事务</param>
        /// <param name="summary">主表</param>
        /// <param name="model">主键更新类型</param>
        /// <param name="keyFieldName">主键字段名称</param>
        /// <param name="GUID">生成32位GUID主键值</param>
        /// <param name="docNoFieldName">单据号码的字段名</param>
        /// <param name="docNo">单据号码</param>
        protected virtual void UpdateSummaryKey(SqlTransaction tran, DataTable summary, UpdateKeyMode model,
             string keyFieldName, ref string GUID, string docNoFieldName, ref string docNo)
        {
            DataRow row = summary.Rows[0]; //取主表第一条记录

            //如果未指定单号更新类型则取旧的单号.
            if ((row.RowState != DataRowState.Added) || (model == UpdateKeyMode.None)) //取旧的单号
            {
                GUID = row[keyFieldName].ToString();
                docNo = row[docNoFieldName].ToString();
                return;
            }

            //新增记录,更新主键的值
            if (row.RowState == DataRowState.Added)
            {
                //注意状态的使用,只有在新增状态下才更新单号
                if (model == UpdateKeyMode.OnlyGuid)
                {
                    if (keyFieldName == "") throw new Exception("没有设定主键,检查类模型参数定义！");
                    GUID = Guid.NewGuid().ToString().Replace("-", "");
                    row[keyFieldName] = GUID;
                }

                if (model == UpdateKeyMode.OnlyDocumentNo)
                {
                    if (docNoFieldName == "") throw new Exception("没有设定单号主键,检查类模型参数定义！");
                    docNo = GetNumber(tran); //调用模板方法获取单据号码
                    row[docNoFieldName] = docNo;
                }
            }
        }

        /// <summary>
        /// 检查业务数据是否存在
        /// </summary>
        /// <param name="keyValue">业务单据主键</param>
        /// <returns></returns>
        public virtual bool CheckNoExists(string keyValue)
        {
            string sql = string.Format("SELECT COUNT(*) C FROM [{0}] WHERE [{1}]=@KEY", _SummaryTableName, _SummaryKeyName);
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@KEY", SqlDbType.VarChar, keyValue);
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, cmd.SqlCommand);

            return ConvertEx.ToInt(o) > 0;
        }

        /// <summary>
        /// 单据审核/批准功能
        /// </summary>
        /// <param name="keyValue">业务主键</param>
        /// <param name="flagApp">审核标记:Y/N</param>
        /// <param name="appUser">审核人</param>
        /// <param name="appDate">审核日期</param>
        public virtual void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate)
        {
            string sql = "UPDATE {0} SET FlagApp=@FlagApp,AppUser=@AppUser,AppDate=@AppDate WHERE {1}=@DocNo";
            sql = string.Format(sql, _SummaryTableName, _SummaryKeyName);
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@FlagApp", SqlDbType.VarChar, flagApp);
            cmd.AddParam("@AppUser", SqlDbType.VarChar, appUser);
            cmd.AddParam("@AppDate", SqlDbType.DateTime, appDate);
            cmd.AddParam("@DocNo", SqlDbType.VarChar, keyValue);
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
        }
    }

    /// <summary>
    /// 更新主表关键字段模式
    /// </summary>
    public enum UpdateKeyMode
    {
        /// <summary>
        /// 未指定．单据号码手工输入
        /// </summary>
        None,

        /// <summary>
        /// 流水号
        /// </summary>
        OnlyDocumentNo,

        /// <summary>
        /// 32位GUID
        /// </summary>
        OnlyGuid,

        /// <summary>
        /// 流水号及32位GUID，生成两个字段的单号.
        /// </summary>
        DocumentNoAndGuid
    }
}
