///*************************************************************************/
///*
///* 文件名    ：SystemLog.cs                                
///* 程序说明  : 系统日志业务逻辑
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework.Core.Log;

namespace CSFramework3.Server.DataAccess.DAL_System
{

    /// <summary>
    /// 修改历史记录的数据层
    /// </summary>
    public class dalEditLogHistory : IBridge_EditLogHistory
    {
        private Loginer _Loginer = null;

        public dalEditLogHistory(Loginer loginer)
        {
            _Loginer = loginer;
        }

        /// <summary>
        /// 保存跟踪的字段定义数据字典
        /// </summary>
        public bool SaveFieldDef(DataTable data)
        {
            string sqlAdd = "INSERT INTO tb_LogFields(TableName,FieldName) VALUES (@TableName,@FieldName)";
            string sqlEdt = "UPDATE tb_LogFields SET TableName=@TableName,FieldName=@FieldName WHERE isid=@isid ";
            string sqlDel = "DELETE tb_LogFields WHERE isid=@isid";

            SqlConnection conn = DataProvider.Instance.CreateConnection(_Loginer.DBName);

            SqlCommand cmdUpdate = new SqlCommand(sqlEdt, conn);
            cmdUpdate.Parameters.Add("@TableName", SqlDbType.VarChar, 50, "TableName");
            cmdUpdate.Parameters.Add("@FieldName", SqlDbType.VarChar, 20, "FieldName");
            cmdUpdate.Parameters.Add("@isid", SqlDbType.Int, 4, "isid");

            SqlCommand cmdDelete = new SqlCommand(sqlDel, conn);
            cmdDelete.Parameters.Add("@isid", SqlDbType.Int, 4, "isid");

            SqlCommand cmdInsert = new SqlCommand(sqlAdd, conn);
            cmdInsert.Parameters.Add("@TableName", SqlDbType.VarChar, 50, "TableName");
            cmdInsert.Parameters.Add("@FieldName", SqlDbType.VarChar, 20, "FieldName");

            SqlDataAdapter adp = new SqlDataAdapter();
            adp.UpdateCommand = cmdUpdate;
            adp.DeleteCommand = cmdDelete;
            adp.InsertCommand = cmdInsert;
            int ret = adp.Update(data);
            return ret > 0;
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="log"></param>
        private void WriteLog(LogDef log)
        {
            string sql1 = "INSERT INTO tb_Log(GUID32 ,LogUser ,LogDate ,OPType ,DocNo ,TableName ,KeyFieldName,IsMaster) " +
                         "           VALUES (@GUID32,@LogUser,@LogDate,@OPType,@DocNo,@TableName,@KeyFieldName,@IsMaster)";

            string sql2 = "INSERT INTO [tb_LogDtl] ([GUID32],[TableName],[FieldName],[OldValue],[NewValue]) VALUES(@GUID32,@TableName,@FieldName,@OldValue,@NewValue)";

            SqlConnection conn = DataProvider.Instance.CreateConnection(_Loginer.DBName);
            try
            {
                if (log.IsMaster == true) //注意! 只有主表才写入tb_Log表
                {
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    cmd.Parameters.Add("@GUID32", SqlDbType.VarChar, 32, "GUID32").Value = log.GUID32;
                    cmd.Parameters.Add("@LogUser", SqlDbType.VarChar, 20, "LogUser").Value = log.LogUser;
                    cmd.Parameters.Add("@LogDate", SqlDbType.DateTime, 8, "LogDate").Value = log.LogDate;
                    cmd.Parameters.Add("@OPType", SqlDbType.Int, 4, "OPType").Value = (int)log.OPType;
                    cmd.Parameters.Add("@DocNo", SqlDbType.VarChar, 20, "DocNo").Value = log.DocNo;
                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 30, "TableName").Value = log.TableName;
                    cmd.Parameters.Add("@KeyFieldName", SqlDbType.VarChar, 30, "KeyFieldName").Value = log.KeyFieldName;
                    cmd.Parameters.Add("@IsMaster", SqlDbType.VarChar, 1, "IsMaster").Value = log.IsMaster ? "Y" : "N";
                    cmd.ExecuteNonQuery();
                }

                //log明细
                foreach (LogDefDtl d in log.Details)
                {
                    SqlCommand cmdDtl = new SqlCommand(sql2, conn);
                    cmdDtl.Parameters.Add("@GUID32", SqlDbType.VarChar, 32, "GUID32").Value = d.GUID32; //明细表外键
                    cmdDtl.Parameters.Add("@TableName", SqlDbType.VarChar, 50, "TableName").Value = d.TableName;
                    cmdDtl.Parameters.Add("@FieldName", SqlDbType.VarChar, 50, "FieldName").Value = d.FieldName;
                    cmdDtl.Parameters.Add("@OldValue", SqlDbType.VarChar, 250, "OldValue").Value = d.OldValue;
                    cmdDtl.Parameters.Add("@NewValue", SqlDbType.VarChar, 250, "NewValue").Value = d.NewValue;
                    cmdDtl.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 比较新/旧数据,如有修改则生成对应的修改日志.
        /// </summary>
        /// <param name="changes">修改后的数据</param>       
        /// <param name="tracedFields">跟踪的字段列表</param>
        /// <param name="keyField">记录主键,比较新旧数据时用于定位</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private IList CompareTable(string logID, DataTable originalData, DataTable changes, string[] tracedFields, string keyField, string tableName, bool isMaster)
        {
            IList logs = new ArrayList();

            #region 循环原始数据比较修改后的数据
            foreach (DataRow row in originalData.Rows)
            {
                string keyValue = row[keyField].ToString();//主键值
                DataRow[] current = changes.Select(keyField + "='" + keyValue + "'");
                if (current.Length == 0) continue;//没有记录,不写日志

                LogDef log = new LogDef();
                log.GUID32 = logID;
                log.DocNo = keyValue;
                log.KeyFieldName = keyField;
                log.LogDate = DateTime.Now;
                log.LogUser = _Loginer.Account; //当前登录用户
                log.OPType = LogOPType.LogEdit;//新增或修改
                log.TableName = tableName;
                log.IsMaster = isMaster;

                if (current[0].RowState == DataRowState.Deleted) continue;//已经删除,不写入日志

                foreach (string fieldName in tracedFields)
                {
                    //if (IsNumbericField(row.Table.Columns[fieldName].DataType))
                    string c1 = ConvertEx.ToString(row[fieldName]); //取原始数据
                    string c2 = ConvertEx.ToString(current[0][fieldName]);//取最新修改值

                    //数字类型要特别处理
                    if (CompareNumbericField(row.Table.Columns[fieldName], c1, c2))
                        log.AppendDetail(tableName, fieldName, c1, c2);//对比有差异\
                    else if (c1 != c2)
                        log.AppendDetail(tableName, fieldName, c1, c2);//对比有差异
                }

                if (log.HasDetail) logs.Add(log); //有修改记录
            }
            #endregion

            return logs;
        }

        /// <summary>
        /// 比较数字类型值1和值2
        /// </summary>
        /// <param name="dataColumn">列</param>
        /// <param name="c1">值1</param>
        /// <param name="c2">值2</param>
        /// <returns></returns>
        private bool CompareNumbericField(DataColumn dataColumn, string c1, string c2)
        {
            if ((c1 == "") && (c2 == "")) return false;
            if ((c1 == "") && (c2 != "")) return true;
            if ((c1 != "") && (c2 == "")) return true;

            double result1;
            double result2;
            if (double.TryParse(c1, out result1) && double.TryParse(c2, out result2))
            {
                return result1 != result2;
            }

            return false;
        }

        /// <summary>
        /// 获取指定表需要跟踪的字段列表
        /// </summary>
        /// <param name="tableName">数据表</param>
        /// <returns></returns>
        public string[] GetTracedFields(string tableName)
        {
            DataTable tracedFields = this.GetLogFieldDef(tableName);
            string[] fields = new string[tracedFields.Rows.Count];
            for (int i = 0; i <= tracedFields.Rows.Count - 1; i++)
                fields[i] = tracedFields.Rows[i]["FieldName"].ToString();
            return fields;
        }

        /// <summary>
        /// 获取跟踪的字段
        /// </summary>
        /// <param name="tableName">表名</param>        
        public DataTable GetLogFieldDef(string tableName)
        {
            string sql = "select * from tb_LogFields where TableName='" + tableName + "'";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_LogFields");
        }

        /// <summary>
        /// 记录单表日志
        /// </summary>
        /// <param name="changes">修改后的数据</param>
        /// <param name="tableName">表名</param>
        /// <param name="keyFieldName">记录的主键,比较新旧数据时用于定位</param>
        public void WriteLog(string logID, DataTable originalData, DataTable changes, string tableName, string keyFieldName, bool isMaster)
        {
            if ((changes == null) || (changes.Rows.Count == 0)) return;

            string[] tracedFields = this.GetTracedFields(tableName);
            IList logs = this.CompareTable(logID, originalData, changes, tracedFields, keyFieldName, tableName, isMaster);

            foreach (LogDef log in logs) this.WriteLog(log); //写入数据库
        }

        /// <summary>
        /// 搜索系统日志数据
        /// </summary>
        /// <param name="logUser">用户</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="dateFrom">日志日期：由</param>
        /// <param name="dateTo">日志日期：至</param>
        /// <returns></returns>
        public DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            SqlCommandBase cmd = SqlBuilder.BuildSqlProcedure("sp_SearchLog");
            cmd.AddParam("@LogUser", SqlDbType.VarChar, logUser);
            cmd.AddParam("@TableName", SqlDbType.VarChar, tableName);
            cmd.AddParam("@LogDateFrom", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(dateFrom));
            cmd.AddParam("@LogDateTo", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(dateTo));
            return DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
        }
    }
}
