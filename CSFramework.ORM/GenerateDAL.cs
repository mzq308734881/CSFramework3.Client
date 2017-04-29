///*************************************************************************/
///*
///* 文件名    ：GenerateDAL.cs    
///*
///* 程序说明  : 自动生成数据层的代码
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.ORM
{
    /// <summary>
    ///  生成DAL层使用的参数基类
    /// </summary>
    public class ParamsBaseDAL
    {
        protected string _ConcretelyName;
        protected string _DAL_Name;
        protected string _ORM_Name;
        protected string _DAL_Namespace;
        protected string[] _UsingNamespace;

        public string ConcretelyName { get { return _ConcretelyName; } set { _ConcretelyName = value; } }
        public string DAL_Name { get { return _DAL_Name; } set { _DAL_Name = value; } }
        public string ORM_Name { get { return _ORM_Name; } set { _ORM_Name = value; } }
        public string DAL_Namespace { get { return _DAL_Namespace; } set { _DAL_Namespace = value; } }
        public string[] UsingNamespace { get { return _UsingNamespace; } set { _UsingNamespace = value; } }
    }

    /// <summary>
    /// 生成数据字典数据层的参数类
    /// </summary>
    public class Params4DataDictDAL : ParamsBaseDAL { }

    /// <summary>
    /// 生成业务单据数据层的参数类
    /// </summary>
    public class Params4BusinessDAL : ParamsBaseDAL { }

    /// <summary>
    /// 自动生成数据层的代码
    /// </summary>
    public class GenerateDAL
    {
        /// <summary>
        /// 生成数据字典的数据层
        /// </summary>
        public string GenerateDataDictDAL(Params4DataDictDAL param)
        {
            StringBuilder builder = new StringBuilder();

            //.Net Framework的名字空间
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");

            //引用的自定义名字空间
            foreach (string space in param.UsingNamespace)
                builder.AppendLine("using " + space + ";");

            //生成单元注释部分
            CreateComment(builder, param.ConcretelyName);

            builder.AppendLine("namespace " + param.DAL_Namespace); //当前数据层所在的名字空间
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine("    /// " + param.DAL_Name);
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    public class " + param.DAL_Name + " : dalBaseDataDict"); //基类
            builder.AppendLine("    {");
            builder.AppendLine("         /// <summary>");
            builder.AppendLine("         /// 构造器");
            builder.AppendLine("         /// </summary>");
            builder.AppendLine("         /// <param name=\"loginer\">当前登录用户</param>");
            builder.AppendLine("         public " + param.DAL_Name + "(Loginer loginer): base(loginer)"); //构造器
            builder.AppendLine("         {");
            builder.AppendLine("             _KeyName = " + param.ORM_Name + ".__KeyName; //主键字段");
            builder.AppendLine("             _TableName = " + param.ORM_Name + ".__TableName;//表名");
            builder.AppendLine("             _ModelType = typeof(" + param.ORM_Name + ");");
            builder.AppendLine("         }");
            builder.AppendLine("");
            builder.AppendLine("         /// <summary>");
            builder.AppendLine("         /// 根据表名获取该表的SQL命令生成器");
            builder.AppendLine("         /// </summary>");
            builder.AppendLine("         /// <param name=\"tableName\">表名</param>");
            builder.AppendLine("         /// <returns></returns>");
            builder.AppendLine("         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)");
            builder.AppendLine("         {");
            builder.AppendLine("           Type ORM = null;");
            builder.AppendLine("           if (tableName == " + param.ORM_Name + ".__TableName) ORM = typeof(" + param.ORM_Name + ");");
            builder.AppendLine("           if (ORM == null) throw new Exception(tableName + \"表没有ORM模型！\");");
            builder.AppendLine("           return new GenerateSqlCmdByTableFields(ORM);");
            builder.AppendLine("         }");
            builder.AppendLine("");
            builder.AppendLine("     }");
            builder.AppendLine("}");

            return builder.ToString();
        }


        /// <summary>
        /// 生成业务单据的数据层
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public string GenerateBusinessDAL(Params4BusinessDAL param)
        {
            StringBuilder builder = new StringBuilder();

            //.Net Framework的名字空间
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("using System.Data.SqlClient;");

            //引用的自定义名字空间
            foreach (string space in param.UsingNamespace)
                builder.AppendLine("using " + space + ";");

            //生成单元注释部分
            CreateComment(builder, param.ConcretelyName);

            //当前业务层所在的名字空间
            builder.AppendLine("namespace " + param.DAL_Namespace);
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine("    /// " + param.DAL_Name);
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    public class " + param.DAL_Name + " : dalBaseBusiness");
            builder.AppendLine("    {");
            builder.AppendLine("         /// <summary>");
            builder.AppendLine("         /// 构造器");
            builder.AppendLine("         /// </summary>");
            builder.AppendLine("         /// <param name=\"loginer\">当前登录用户</param>");
            builder.AppendLine("         public " + param.DAL_Name + "(Loginer loginer): base(loginer)"); //构造器
            builder.AppendLine("         {");
            builder.AppendLine("             _SummaryKeyName = " + param.ORM_Name + ".__KeyName; //主表的主键字段");
            builder.AppendLine("             _SummaryTableName = " + param.ORM_Name + ".__TableName;//主表表名");
            builder.AppendLine("             _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;//单据号码生成模式");
            builder.AppendLine("         }");
            builder.AppendLine("");
            builder.AppendLine("         /// <summary>");
            builder.AppendLine("         /// 根据表名获取该表的ＳＱＬ命令生成器");
            builder.AppendLine("         /// </summary>");
            builder.AppendLine("         /// <param name=\"tableName\">表名</param>");
            builder.AppendLine("         /// <returns></returns>");
            builder.AppendLine("         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)");
            builder.AppendLine("         {");
            builder.AppendLine("             Type ORM = null;");
            builder.AppendLine("             if (tableName == " + param.ORM_Name + ".__TableName) ORM = typeof(" + param.ORM_Name + ");");
            builder.AppendLine("             //if (tableName == " + param.ORM_Name + "s.__TableName) ORM = typeof(" + param.ORM_Name + "s);"); //如有明细表请调整本行的代码
            builder.AppendLine("             if (ORM == null) throw new Exception(tableName + \"表没有ORM模型！\");");
            builder.AppendLine("             return new GenerateSqlCmdByTableFields(ORM);");
            builder.AppendLine("         }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 查询功能，获取主表数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)");
            builder.AppendLine("          {");
            builder.AppendLine("              StringBuilder sql = new StringBuilder();");
            builder.AppendLine("              //");
            builder.AppendLine("              //在这里生成SQL");
            builder.AppendLine("              //");
            builder.AppendLine("              if (sql.ToString() != \"\") //有查询条件");
            builder.AppendLine("              {");
            builder.AppendLine("                  string query = \"select * from \" + _SummaryTableName + \" where 1=1 \" + sql.ToString();");
            builder.AppendLine("                  SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);");
            builder.AppendLine("                  DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName,cmd.SqlCommand, " + param.ORM_Name + ".__TableName);");
            builder.AppendLine("                  return dt;");
            builder.AppendLine("              }");
            builder.AppendLine("              else //无查询条件不返回数据");
            builder.AppendLine("              {");
            builder.AppendLine("                  throw new Exception(\"没有指定查询条件!\");");
            builder.AppendLine("                  return null;");
            builder.AppendLine("              }");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 获取一张业务单据的数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"docNo\">单据号码</param>");
            builder.AppendLine("          /// <returns></returns>");
            builder.AppendLine("          public System.Data.DataSet GetBusinessByKey(string docNo)");
            builder.AppendLine("          {");
            builder.AppendLine("              string sql1 = \" select * from [tb_" + param.ConcretelyName + "]    where [\"+" + param.ORM_Name + ".__KeyName+\"]=@DocNo1 \";");
            builder.AppendLine("              string sql2 = \" select * from [vw_" + param.ConcretelyName + "s]   where [\"+" + param.ORM_Name + ".__KeyName+\"]=@DocNo2 ORDER BY Queue \"; //明细表排序");
            builder.AppendLine("              SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);");
            builder.AppendLine("              cmd.AddParam(\"@DocNo1\", SqlDbType.VarChar, docNo.Trim());");
            builder.AppendLine("              cmd.AddParam(\"@DocNo2\", SqlDbType.VarChar, docNo.Trim());");
            builder.AppendLine("              DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName,cmd.SqlCommand);");
            builder.AppendLine("              ds.Tables[0].TableName = " + param.ORM_Name + ".__TableName;");
            builder.AppendLine("              //ds.Tables[1].TableName =" + param.ORM_Name + "s.__TableName;//明细表");
            builder.AppendLine("              return ds;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///删除一张单据:只删除明细,主表金额清零!!!");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public bool Delete(string docNo)");
            builder.AppendLine("          {");
            builder.AppendLine("              //删除单据:只删除明细,主表金额清零!!!");
            builder.AppendLine("              string sql1 = \"UPDATE [tb_" + param.ConcretelyName + "] SET Amount=0 where [\"+" + param.ORM_Name + ".__KeyName+\"]=@DocNo1 \";");
            builder.AppendLine("              string sql2 = \"delete [tb_" + param.ConcretelyName + "] where [\"+" + param.ORM_Name + ".__KeyName+\"]=@DocNo2 \";");
            builder.AppendLine("              SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);");
            builder.AppendLine("              cmd.AddParam(\"@DocNo1\", SqlDbType.VarChar, docNo.Trim());");
            builder.AppendLine("              cmd.AddParam(\"@DocNo2\", SqlDbType.VarChar, docNo.Trim());");
            builder.AppendLine("              int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName,cmd.SqlCommand);");
            builder.AppendLine("              return i != 0;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          //保存数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public SaveResult Update(DataSet data, bool createBusinessLog)");
            builder.AppendLine("          {");
            builder.AppendLine("              //其它处理...");
            builder.AppendLine("              //调用基类的方法保存数据");
            builder.AppendLine("              return base.Update(data);");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          //获取单据流水号码");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          protected override string GetNumber(SqlTransaction tran)");
            builder.AppendLine("          {");
            builder.AppendLine("              string docNo = DocNoTool.GetNumber(tran, \"" + param.ConcretelyName + "\");");
            builder.AppendLine("              return docNo;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 创建业务单据的版本历史记录");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"key\">单据号码</param>");
            builder.AppendLine("          /// <param name=\"account\">当前用户</param>");
            builder.AppendLine("          /// <param name=\"newVerNo\">返回新的版本号</param>");
            builder.AppendLine("          public void CreateBusinessLog(string key, string account, out string newVerNo)");
            builder.AppendLine("          {");
            builder.AppendLine("              string sql = \"sp_Log_" + param.ConcretelyName + "'\" + key + \"','\" + account + \"'\";");
            builder.AppendLine("              SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);");
            builder.AppendLine("              object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName,cmd.SqlCommand);");
            builder.AppendLine("              newVerNo = ConvertEx.ToString(o);");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 获取指定版本号的历史记录");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"docNo\">单据号码</param>");
            builder.AppendLine("          /// <param name=\"verNo\">版本号</param>");
            builder.AppendLine("          /// <returns></returns>");
            builder.AppendLine("          public DataSet GetBusinessLog(string docNo, string verNo)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 获取单据的版本历史记录");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"docNo\">单据号码</param>");
            builder.AppendLine("          /// <returns></returns>");
            builder.AppendLine("          public DataSet GetBusinessLog(string docNo)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 获取报表数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <returns></returns>");
            builder.AppendLine("          public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("     }");
            builder.AppendLine("}");
            builder.AppendLine("");

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
            builder.AppendLine(" *   程序说明: " + concretelyName + "的数据访问层");
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
