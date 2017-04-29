///*************************************************************************/
///*
///* 文件名    ：SqlBuilder.cs                                
///* 程序说明  : 自定义SQL命令生成器
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
using CSFramework.Common;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 自定义SQL命令生成器
    /// </summary>
    public class SqlBuilder
    {
        /// <summary>
        /// 创建SqlProcedure对象
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <returns></returns>
        public static SqlProcedure BuildSqlProcedure(string spName)
        {
            SqlCommand cmd = new SqlCommand(spName);
            cmd.CommandType = CommandType.StoredProcedure;
            return new SqlProcedure(cmd);
        }

        /// <summary>
        /// 创建SQL命令对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static SqlCommandBase BuildSqlCommandBase(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            return new SqlCommandBase(cmd);
        }

        /// <summary>
        /// 创建SqlUpdateCommand对象
        /// </summary>
        /// <param name="tableName">需要更新的数据表名</param>
        /// <param name="fields">需要更新的字段列表</param>
        /// <returns>返回SqlUpdateCommand对象</returns>
        public static SqlUpdateCommand BuildUpdateCommand(string tableName, string fields,
            string keyFieldName, DataTable dtFields)
        {
            if (dtFields == null || dtFields.Rows.Count == 0) throw new Exception("没有表定义!");
            string[] fs = fields.Split(new char[] { char.Parse(",") });
            if (fs.Length == 0) throw new Exception("没有字段定义!");
            if (tableName.Trim() == "") throw new Exception("没有表名定义!");
            if (keyFieldName.Trim() == "") throw new Exception("没有关键字段名定义!");

            SqlCommand cmd = new SqlCommand();
            StringBuilder sb = new StringBuilder();
            foreach (string f in fs)
            {
                string fname = f.Trim();//截取字段名左右空格！！！
                cmd.Parameters.Add(CreateParam(dtFields, fname)); //创建参数
                sb.Append(fname + "=@" + fname + ","); //组合参数SQL字串.如: AccountName=@AccountName,Sex=@Sex
            }

            string cmdtext = sb.ToString();
            if (cmdtext.Trim().EndsWith(",")) cmdtext = cmdtext.Substring(0, cmdtext.Length - 1); //截尾部','

            cmdtext = " UPDATE " + tableName + " SET " + cmdtext;
            cmdtext = cmdtext + " WHERE " + keyFieldName + "=@" + keyFieldName;

            cmd.Parameters.Add(CreateParam(dtFields, keyFieldName)); //创建关键字段参数

            cmd.CommandText = cmdtext;

            return new SqlUpdateCommand(cmd);
        }

        /// <summary>
        /// 创建SqlUpdateCommand对象
        /// </summary>
        /// <param name="tableName">插入数据的数据表名</param>
        /// <param name="fields">插入数据的字段列表</param>
        /// <returns>返回SqlUpdateCommand对象</returns>
        public static SqlUpdateCommand BuildInsertCommand(string tableName, string fields, DataTable dtfields)
        {
            string[] fs = fields.Split(new char[] { char.Parse(",") });
            if (fs.Length == 0) throw new Exception("没有字段定义!");
            if (tableName.Trim() == "") throw new Exception("没有表名定义!");
            if (dtfields == null || dtfields.Rows.Count == 0) throw new Exception("没有表定义!");

            SqlCommand cmd = new SqlCommand();
            StringBuilder sb = new StringBuilder();
            foreach (string f in fs)
            {
                string fname = f.Trim();//截取字段名左右空格！！！
                cmd.Parameters.Add(CreateParam(dtfields, fname));
                sb.Append("@" + fname + ",");
            }

            string param = sb.ToString();
            if (param.Trim().EndsWith(",")) param = param.Substring(0, param.Length - 1);

            string cmdtext = " INSERT INTO " + tableName + " (" + fields + ")" + " VALUES (" + param + ")";

            cmd.CommandText = cmdtext;

            return new SqlUpdateCommand(cmd);
        }

        /// <summary>
        /// 创建SqlParameter对象
        /// </summary>
        private static SqlParameter CreateParam(DataTable fields, string fieldName)
        {
            SqlParameter p;
            DataRow[] rows = fields.Select("FieldName='" + fieldName + "'");
            if (rows.Length <= 0) throw new Exception("无效的字段名:" + fieldName);
            SqlDbType type = DataConverter.SqlTypeString2SqlType(rows[0]["TypeName"].ToString());

            //大文本不需要设长度
            if (SqlDbType.NText == type || SqlDbType.Text == type || SqlDbType.Binary == type ||
                SqlDbType.Image == type || SqlDbType.VarBinary == type || SqlDbType.Variant == type)
                p = new SqlParameter("@" + fieldName, type);
            else
            {
                int size = int.Parse(rows[0]["Length"].ToString());
                p = new SqlParameter("@" + fieldName, type, size);
            }
            return p;
        }
    }

    /// <summary>
    /// 自定义SqlCommand的基类，组合SqlCommand对象.
    /// </summary>
    public class SqlCommandBase
    {
        protected SqlCommand _cmd = null;

        /// <summary>
        /// SqlCommand对象
        /// </summary>
        public SqlCommand SqlCommand { get { return _cmd; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="cmd">SqlCommand对象</param>
        public SqlCommandBase(SqlCommand cmd)
        { _cmd = cmd; }

        /// <summary>
        /// 增加参数
        /// </summary>
        /// <param name="parameterName">参数名称,带@符号</param>
        /// <param name="sqlDbType">SqlDbType类型</param>
        /// <param name="value">值</param>
        public void AddParam(string parameterName, SqlDbType sqlDbType, object value)
        {
            _cmd.Parameters.Add(parameterName, sqlDbType).Value = value;
        }

        /// <summary>
        /// 增加参数
        /// </summary>
        /// <param name="parameterName">参数名称,带@符号</param>
        /// <param name="sqlDbType">SqlDbType类型</param>
        /// <param name="size">长度</param>
        /// <param name="value">值</param>
        public void AddParam(string parameterName, SqlDbType sqlDbType, int size, object value)
        {
            _cmd.Parameters.Add(parameterName, sqlDbType, size).Value = value;
        }

        /// <summary>
        /// 给SqlCommand.Parameters赋值
        /// </summary>
        /// <param name="values">对象列表，顺序必须与Parameters集合内定义的参数相同</param>
        public void SetValue(object[] values)
        {
            if (_cmd.Parameters.Count != values.Length)
                throw new Exception("参数值与参数数量不一致！");

            for (int i = 0; i <= values.Length - 1; i++)
                _cmd.Parameters[i].Value = values[i];
        }

        /// <summary>
        ///  给SqlCommand.Parameters赋值
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="value">数值</param>
        public void SetValue(string paramName, object value)
        {
            SqlParameter p = this._cmd.Parameters[paramName];
            if (p == null) throw new Exception("参数不存在！");
            p.Value = value;
        }
    }

    /// <summary>
    /// 更新记录或新增记录的SqlUpdateCommand对象
    /// </summary>
    public class SqlUpdateCommand : SqlCommandBase
    {
        public SqlUpdateCommand(SqlCommand cmd)
            : base(cmd)
        {
            //
        }
    }

    /// <summary>
    /// 自定义存储过程对象
    /// </summary>
    public class SqlProcedure : SqlCommandBase
    {
        public SqlProcedure(SqlCommand cmd)
            : base(cmd)
        {
            //
        }
    }

}
