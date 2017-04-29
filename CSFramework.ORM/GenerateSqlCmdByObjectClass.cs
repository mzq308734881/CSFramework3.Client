///*************************************************************************/
///*
///* 文件名    ：GenerateSqlCmdByObjectClass.cs    
///*
///* 程序说明  : 由对象实体类模型创建SQL命令生成器
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;
using System.Data;

namespace CSFramework.ORM
{
    /// <summary>
    /// 由对象实体类模型创建SQL命令生成器
    /// </summary>
    public class GenerateSqlCmdByObjectClass : GenerateSqlCmdBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="classType">对象实体类</param>
        public GenerateSqlCmdByObjectClass(Type classType)
        {
            object[] attrClass = classType.GetCustomAttributes(typeof(ORM_ObjectClassAttribute), false);
            if (attrClass != null && attrClass.Length == 0) throw new Exception("ORM_ObjectClassAttribute未定义!");
            ORM_ObjectClassAttribute classAttribute = attrClass[0] as ORM_ObjectClassAttribute;
            _IsSummary = classAttribute.IsSummaryTable;

            //生成一个新的对象
            object obj = classType.Assembly.CreateInstance(classType.FullName);

            //获取类中的所有属性
            PropertyInfo[] infosSelf = classType.GetProperties();
            PropertyInfo[] infosBase = classType.BaseType.GetProperties();

            PropertyInfo[] infos = null;
            if (infosBase.Length == 0)
                infos = infosSelf;
            else
            {
                //相加两数组
                int iLength = infosBase.Length;
                Array.Resize<PropertyInfo>(ref infosBase, infosBase.Length + infosSelf.Length);
                infosSelf.CopyTo(infosBase, iLength);
                infos = infosBase;
            }

            ArrayList fieldArr = new ArrayList();

            _cmdInsert = new SqlCommand();
            _cmdUpdate = new SqlCommand();
            _cmdDelete = new SqlCommand();

            _cmdInsert.CommandType = CommandType.Text;
            _cmdUpdate.CommandType = CommandType.Text;
            _cmdDelete.CommandType = CommandType.Text;

            foreach (PropertyInfo info in infos)
            {
                object[] attrField = info.GetCustomAttributes(typeof(ORM_FieldAttribute), false);
                string fieldName = info.Name;

                if (attrField != null && attrField.Length > 0)
                {
                    ORM_FieldAttribute cmasParameterAttr = attrField[0] as ORM_FieldAttribute;

                    //用作构造sql语句中的参数
                    if (cmasParameterAttr.IsAddOrUpdate)
                    {
                        //取得最多的参数，与生成的sql语句作匹配,构造SQL参数语句                                             
                        if (!_cmdInsert.Parameters.Contains("@" + fieldName)) _cmdInsert.Parameters.Add("@" + fieldName, cmasParameterAttr.Type, cmasParameterAttr.Size, fieldName);
                        if (!_cmdUpdate.Parameters.Contains("@" + fieldName)) _cmdUpdate.Parameters.Add("@" + fieldName, cmasParameterAttr.Type, cmasParameterAttr.Size, fieldName);

                        ColoumnProperty colProper = new ColoumnProperty(fieldName, cmasParameterAttr.IsPrimaryKey ? true : false);
                        fieldArr.Add(colProper);
                    }

                    if (cmasParameterAttr.IsPrimaryKey)
                    {
                        if (!_cmdUpdate.Parameters.Contains("@" + fieldName)) _cmdUpdate.Parameters.Add("@" + fieldName, cmasParameterAttr.Type, cmasParameterAttr.Size, fieldName);
                        if (!_cmdDelete.Parameters.Contains("@" + fieldName)) _cmdDelete.Parameters.Add("@" + fieldName, cmasParameterAttr.Type, cmasParameterAttr.Size, fieldName);
                        _PrimaryFieldName = fieldName;
                    }

                    if (cmasParameterAttr.IsDocFieldName) _DocNoFieldName = fieldName;
                    if (cmasParameterAttr.IsForeignKey) _ForeignFieldName = fieldName;
                }
            }

            _sqlInsert = GernerateInsertSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr);
            _sqlUpdate = GernerateUpdateSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr);
            _sqlDelete = GernerateDeleteSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr);

        }
    }

}
