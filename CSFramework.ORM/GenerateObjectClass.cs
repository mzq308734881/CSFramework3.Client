///*************************************************************************/
///*
///* 文件名    ：GenerateObjectClass.cs    
///*
///* 程序说明  :  生成对象关系模型(ORM)
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework.ORM
{
    /// <summary>
    /// 生成对象关系模型(ORM)
    /// </summary>
    public sealed class GenerateObjectClass : IClassGenerator
    {
        /// <summary>
        /// ORM自定义类的特性(Attribute)
        /// </summary>
        const string _TableAttribute = "ORM_ObjectClassAttribute";

        /// <summary>
        ///  ORM自定义类的字段的特性
        /// </summary>
        const string _FieldAttribute = "ORM_FieldAttribute";

        /// <summary>
        /// ORM类所在命名空间
        /// </summary>
        const string _ORM_Namespace = "CSFramework.ORM";

        /// <summary>
        /// 断行符
        /// </summary>
        const string _NullLine = "\r\n";

        /// <summary>
        /// 是否生成字段名的常量
        /// </summary>
        private bool _genFields = false;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="genFields">是否生成字段名的常量</param>
        public GenerateObjectClass(bool genFields)
        {
            _genFields = genFields;
        }

        /// <summary>
        /// 生成对象关系模型(ORM)
        /// </summary>
        /// <param name="spaceName">命名空间</param>
        /// <param name="className">类名</param>
        /// <param name="tableName">对应的数据表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="isSummaryTable">是否主表</param>
        /// <param name="metal">表结构元数据</param>
        /// <returns></returns>
        public string Generate(string spaceName, string className, string comment, string tableName,
            string primaryKey, bool isSummaryTable, DataTable metal)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("using System;\r\n");
            builder.Append("using System.Collections.Generic;\r\n");
            builder.Append("using System.Text;\r\n");
            builder.Append("using System.Data;\r\n");
            builder.Append("using " + _ORM_Namespace + ";\r\n\r\n");

            //生成单元注释部分
            CreateComment(builder, className);

            builder.Append("namespace " + spaceName + "\r\n{\r\n");
            builder.Append("    ///<summary>\r\n");
            builder.Append("    /// " + comment + "\r\n");
            builder.Append("    /// </summary>\r\n");
            builder.Append(string.Format("    [{0}(\"{1}\", \"{2}\", {3})]", _TableAttribute, tableName, primaryKey, (isSummaryTable ? "true" : "false")) + "\r\n");
            builder.Append("    public sealed class " + className + "\r\n    {\r\n");

            //生成所有字段的局部变量
            builder.Append("    #region 所有字段的局部变量定义\r\n");

            foreach (DataRow row in metal.Rows)
            {
                string name = Convert.ToString(row["colName"]);
                string type = Convert.ToString(row["colType"]);

                builder.Append("        private " + ORMTools.SqlTypeName2DotNetType(type) + " F_" + name + ";\r\n");
            }
            builder.Append("    #endregion\r\n");

            builder.Append("\r\n");

            builder.Append("        public static string __TableName =\"" + tableName + "\";\r\n\r\n");
            builder.Append("        public static string __KeyName = \"" + primaryKey + "\";\r\n\r\n");

            //生成所有字段名常量
            if (_genFields)
            {
                builder.Append("    #region 所有字段名常量\r\n");
                foreach (DataRow row in metal.Rows)
                {
                    string name = Convert.ToString(row["colName"]);
                    builder.Append("        public const string _" + name + " = \"" + name + "\"; \r\n");
                }
                builder.Append("    #endregion\r\n");
            }

            //生成所有字段属性
            builder.Append("\r\n");
            builder.Append("    #region 所有字段属性\r\n");
            foreach (DataRow row in metal.Rows)
            {
                string name = Convert.ToString(row["colName"]);
                string type = Convert.ToString(row["colType"]);
                string length = Convert.ToString(row["colLength"]);
                string isLookup = Convert.ToString(row["colIsLookup"]).ToLower();
                string isAddOrUpdate = Convert.ToString(row["colIsAddOrUpdate"]).ToLower();
                string isPrimaryKey = Convert.ToString(row["colIsPrimaryKey"]).ToLower();
                string isForeignKey = Convert.ToString(row["colIsForeignKey"]).ToLower();
                string isDocFieldName = Convert.ToString(row["colIsNumberKey"]).ToLower();
                string sqlType = "SqlDbType." + ORMTools.SqlTypeName2SqlType(type).ToString();

                builder.Append("        [" + _FieldAttribute + "(");
                builder.Append(sqlType + "," + length + "," + isLookup + "," + isAddOrUpdate + "," + isPrimaryKey + "," + isForeignKey + "," + isDocFieldName + ")]\r\n");
                builder.Append("        public " + ORMTools.SqlTypeName2DotNetType(type) + "  " + name + "{get{return " + "F_" + name + ";}set{" + "F_" + name + "=value;}}\r\n");
                builder.Append(_NullLine);
            }
            builder.Append("    #endregion\r\n");
            builder.Append("    }\r\n}");

            return builder.ToString();
        }

        /// <summary>
        /// 生成注释部分
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="concretelyName"></param>
        private void CreateComment(StringBuilder builder, string concretelyName)
        {
            builder.AppendLine("");
            builder.AppendLine("/*==========================================");
            builder.AppendLine(" *   程序说明: " + concretelyName + "的ORM模型");
            builder.AppendLine(" *   作者姓名: C/S框架网 www.csframework.com");
            builder.AppendLine(" *   创建日期: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            builder.AppendLine(" *   最后修改: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            builder.AppendLine(" *   ");
            builder.AppendLine(" *   注: 本代码由ClassGenerator自动生成");
            builder.AppendLine(" *   版权所有 C/S框架网 www.csframework.com");
            builder.AppendLine(" *==========================================*/");
            builder.AppendLine("");
        }
    }
}
