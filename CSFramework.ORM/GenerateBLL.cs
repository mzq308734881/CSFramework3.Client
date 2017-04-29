///*************************************************************************/
///*
///* 文件名    ：GenerateBLL.cs    
///*
///* 程序说明  : 自动生成业务逻辑层的代码
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
    /// 生成BLL使用的参数基类
    /// </summary>
    public class ParamsBaseBLL
    {
        protected string _ConcretelyName;
        protected string _BLL_Name;
        protected string _DAL_Name;
        protected string _ORM_Name;
        protected string _BLL_Namespace;
        protected string[] _UsingNamespace;

        public string ConcretelyName { get { return _ConcretelyName; } set { _ConcretelyName = value; } }
        public string BLL_Name { get { return _BLL_Name; } set { _BLL_Name = value; } }
        public string DAL_Name { get { return _DAL_Name; } set { _DAL_Name = value; } }
        public string ORM_Name { get { return _ORM_Name; } set { _ORM_Name = value; } }
        public string BLL_Namespace { get { return _BLL_Namespace; } set { _BLL_Namespace = value; } }
        public string[] UsingNamespace { get { return _UsingNamespace; } set { _UsingNamespace = value; } }
    }

    /// <summary>
    /// 生成业务逻辑的参数
    /// </summary>
    public class Params4BusinessBLL : ParamsBaseBLL
    {
        string _BusinessFormName;
        bool _SupportBusinessLog;

        public string BusinessFormName { get { return _BusinessFormName; } set { _BusinessFormName = value; } }
        public bool SupportBusinessLog { get { return _SupportBusinessLog; } set { _SupportBusinessLog = value; } }
    }

    /// <summary>
    /// 生成数据字典的参数
    /// </summary>
    public class Params4DataDictBLL : ParamsBaseBLL { }

    /// <summary>
    /// 自动生成业务逻辑层的代码
    /// </summary>
    public class GenerateBLL
    {
        /// <summary>
        /// 生成数据字典的业务层
        /// </summary>
        public string GenerateDataDictBLL(Params4DataDictBLL param)
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

            builder.AppendLine("namespace " + param.BLL_Namespace); //当前业务层所在的名字空间
            builder.AppendLine("{");
            builder.AppendLine("    public class " + param.BLL_Name + " : bllBaseDataDict"); //基类
            builder.AppendLine("    {");
            builder.AppendLine("         public " + param.BLL_Name + "()"); //构造器
            builder.AppendLine("         {");
            builder.AppendLine("             _KeyFieldName = " + param.ORM_Name + ".__KeyName; //主键字段");
            builder.AppendLine("             _SummaryTableName = " + param.ORM_Name + ".__TableName;//表名");
            builder.AppendLine("             _WriteDataLog = true;//是否保存日志");
            builder.AppendLine("             _DAL = new " + param.DAL_Name + "(Loginer.CurrentUser);//数据层的实例"); //返回数据层的实例
            builder.AppendLine("         }");
            builder.AppendLine("     }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        /// <summary>
        /// 生成业务单据的业务层代码
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public string GenerateBusinessBLL(Params4BusinessBLL param)
        {
            StringBuilder builder = new StringBuilder();

            //.Net Framework的名字空间
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Collections;");

            //引用的自定义名字空间
            foreach (string space in param.UsingNamespace)
                builder.AppendLine("using " + space + ";");

            //生成单元注释部分
            CreateComment(builder, param.ConcretelyName);

            //当前业务层所在的名字空间
            builder.AppendLine("namespace " + param.BLL_Namespace);
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine("    /// " + param.BLL_Name);
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    public class " + param.BLL_Name + " : bllBaseBusiness" + (param.SupportBusinessLog ? ",IBusinessLogBLL" : "")); //基类,//支持BusinessLog接口
            builder.AppendLine("    {");
            builder.AppendLine("         /// <summary>");
            builder.AppendLine("         /// 构造器");
            builder.AppendLine("         /// </summary>");
            builder.AppendLine("         public " + param.BLL_Name + "()");
            builder.AppendLine("         {");
            builder.AppendLine("             _KeyFieldName = " + param.ORM_Name + ".__KeyName; //主键字段");
            builder.AppendLine("             _SummaryTableName = " + param.ORM_Name + ".__TableName;//表名");
            builder.AppendLine("             _SaveVersionLog = false;//是否启用版本控制");
            builder.AppendLine("         }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///根据单据号码和版本号获取版本历史记录");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override DataSet GetBusinessLog(string docNo, string verNo)");
            builder.AppendLine("          {");
            builder.AppendLine("             DataSet ds = new " + param.DAL_Name + "(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);");
            builder.AppendLine("             return ds;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///根据单据号码取业务数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)");
            builder.AppendLine("          {");
            builder.AppendLine("              DataSet ds = new " + param.DAL_Name + "(Loginer.CurrentUser).GetBusinessByKey(keyValue); ");
            builder.AppendLine("              this.SetNumericDefaultValue(ds); //设置预设值");
            builder.AppendLine("              if (resetCurrent) _CurrentBusiness = ds; //保存当前业务数据的对象引用");
            builder.AppendLine("              return ds;");
            builder.AppendLine("           }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///删除单据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override bool Delete(string keyValue)");
            builder.AppendLine("          {");
            builder.AppendLine("              return new " + param.DAL_Name + "(Loginer.CurrentUser).Delete(keyValue);");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///检查单号是否存在");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public bool CheckNoExists(string keyValue)");
            builder.AppendLine("          {");
            builder.AppendLine("              return new " + param.DAL_Name + "(Loginer.CurrentUser).CheckNoExists(keyValue);");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///保存数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override SaveResult Save(DataSet saveData)");
            builder.AppendLine("          {");
            builder.AppendLine("              return new " + param.DAL_Name + "(Loginer.CurrentUser).Update(saveData, this.OnChangeVersion); //交给数据层处理");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///审核单据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override void ApprovalBusiness(DataRow summaryRow)");
            builder.AppendLine("          {");
            builder.AppendLine("               summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;");
            builder.AppendLine("               summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;");
            builder.AppendLine("               summaryRow[BusinessCommonFields.FlagApp] = \"Y\";");
            builder.AppendLine("               string key = ConvertEx.ToString(summaryRow[" + param.ORM_Name + ".__KeyName]);");
            builder.AppendLine("               new " + param.DAL_Name + "(Loginer.CurrentUser).ApprovalBusiness(key, \"Y\", Loginer.CurrentUser.Account, DateTime.Now);");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///新增一张业务单据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override void NewBusiness()");
            builder.AppendLine("          {");
            builder.AppendLine("              DataTable summaryTable = _CurrentBusiness.Tables[" + param.ORM_Name + ".__TableName];");
            builder.AppendLine("              DataRow row = summaryTable.Rows.Add();     ");
            builder.AppendLine("              //row[" + param.ORM_Name + ".__KeyName] = \"*自动生成*\";");
            builder.AppendLine("              //row[" + param.ORM_Name + ".VerNo] = \"01\";");
            builder.AppendLine("              //row[" + param.ORM_Name + ".CreatedBy] = Loginer.CurrentUser.Account;");
            builder.AppendLine("              //row[" + param.ORM_Name + ".CreationDate] = DateTime.Now;");
            builder.AppendLine("              //row[" + param.ORM_Name + ".LastUpdatedBy] = Loginer.CurrentUser.Account;");
            builder.AppendLine("              //row[" + param.ORM_Name + ".LastUpdateDate] = DateTime.Now;");
            builder.AppendLine("           }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///创建用于保存的临时数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///查询数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          ///获取报表数据");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)");
            builder.AppendLine("          {");
            builder.AppendLine("              return null;");
            builder.AppendLine("          }");
            builder.AppendLine("");

            #region 生成IBusinessLogBLL Members

            //生成支持业务单据版本功能的相关代码
            if (param.SupportBusinessLog)
            {
                builder.AppendLine("");
                builder.AppendLine("          #region IBusinessLogBLL Members");
                builder.AppendLine("");
                builder.AppendLine("          /// <summary>");
                builder.AppendLine("          /// 当前业务单据的窗体名");
                builder.AppendLine("          /// </summary>");
                builder.AppendLine("          public string CurrentFormName");
                builder.AppendLine("          {");
                builder.AppendLine("              get { return \"" + param.BusinessFormName + "\"; }");
                builder.AppendLine("          }");
                builder.AppendLine("");
                builder.AppendLine("          /// <summary>");
                builder.AppendLine("          /// 系统内所有业务单据列表");
                builder.AppendLine("          /// </summary>");
                builder.AppendLine("          public DataTable BusinessNameList");
                builder.AppendLine("          {");
                builder.AppendLine("              get { return DataDictCache.Cache.BusinessTables; }");
                builder.AppendLine("          }");
                builder.AppendLine("");
                builder.AppendLine("          /// <summary>");
                builder.AppendLine("          /// 搜索变更历史记录");
                builder.AppendLine("          /// </summary>");
                builder.AppendLine("          public DataSet SearchBusinessLog(string docNo)");
                builder.AppendLine("          {");
                builder.AppendLine("              if (docNo != string.Empty) //没指定查询条件");
                builder.AppendLine("              {");
                builder.AppendLine("                  return new " + param.DAL_Name + "(Loginer.CurrentUser).GetBusinessLogs(docNo);");
                builder.AppendLine("              }");
                builder.AppendLine("              return null;");
                builder.AppendLine("          }");
                builder.AppendLine("");
                builder.AppendLine("          #endregion");
                builder.AppendLine("");
            }
            #endregion

            #region 重写Business Log相关方法

            //生成支持修改日志功能的相关代码
            builder.AppendLine("          #region Business Log");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 写入日志");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          public override void WriteLog()");
            builder.AppendLine("          {");
            builder.AppendLine("              string key = this.DataBinder.Rows[0][" + param.ORM_Name + ".__KeyName].ToString();//取单据号码");
            builder.AppendLine("              DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.");
            builder.AppendLine("              DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据");
            builder.AppendLine("              this.WriteLog(dsOriginal, dsTemplate);//保存日志      ");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 写入日志");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"original\">原始数据</param>");
            builder.AppendLine("          /// <param name=\"changes\">修改后的数据</param>");
            builder.AppendLine("          public override void WriteLog(DataTable original, DataTable changes) { }");
            builder.AppendLine("");
            builder.AppendLine("          /// <summary>");
            builder.AppendLine("          /// 写入日志");
            builder.AppendLine("          /// </summary>");
            builder.AppendLine("          /// <param name=\"original\">原始数据</param>");
            builder.AppendLine("          /// <param name=\"changes\">修改后的数据</param>");
            builder.AppendLine("          public override void WriteLog(DataSet original, DataSet changes)");
            builder.AppendLine("          {  //单独处理,即使错误,不向外抛出异常");
            builder.AppendLine("              if (_SaveVersionLog == false) return; //应用策略");
            builder.AppendLine("              try");
            builder.AppendLine("              {");
            builder.AppendLine("                  string logID = Guid.NewGuid().ToString().Replace(\"-\", \"\"); //本次日志ID");
            builder.AppendLine("                  SystemLog.WriteLog(logID, original.Tables[0], changes.Tables[0], " + param.ORM_Name + ".__TableName, " + param.ORM_Name + ".__KeyName, true); //主表");
            builder.AppendLine("                  //明细表的修改日志,系统不支持自动生成,请手工调整代码");
            builder.AppendLine("                  //SystemLog.WriteLog(logID, original.Tables[1], changes.Tables[1], " + param.ORM_Name + ".__TableName, " + param.ORM_Name + ".__KeyName, false);");
            builder.AppendLine("              }");
            builder.AppendLine("              catch");
            builder.AppendLine("              {");
            builder.AppendLine("                  Msg.Warning(\"写入日志发生错误！\");");
            builder.AppendLine("              }");
            builder.AppendLine("          }");
            builder.AppendLine("");
            builder.AppendLine("          #endregion");
            #endregion

            builder.AppendLine("     }");
            builder.AppendLine("}");
            return builder.ToString();
        }

        /// <summary>
        /// 生成注释
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="concretelyName"></param>
        private void CreateComment(StringBuilder builder, string concretelyName)
        {
            builder.AppendLine("");
            builder.AppendLine("/*==========================================");
            builder.AppendLine(" *   程序说明: " + concretelyName + "的业务逻辑层");
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
