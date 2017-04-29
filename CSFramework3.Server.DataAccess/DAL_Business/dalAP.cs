using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework.ORM;
using CSFramework3.Server.DataAccess.DAL_Base;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_System;

/*==========================================
 *   程序说明: AP的数据访问层
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2012-04-28 10:57:19
 *   最后修改: 2012-04-28 10:57:19
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

namespace CSFramework3.Server.DataAccess.DAL_Business
{
    /// <summary>
    /// dalAP
    /// </summary>
    public class dalAP : dalBaseBusiness, IBridge_AP
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        public dalAP(Loginer loginer)
            : base(loginer)
        {
            _SummaryKeyName = tb_AP.__KeyName; //主表的主键字段
            _SummaryTableName = tb_AP.__TableName;//主表表名
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;//单据号码生成模式
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;
            if (tableName == tb_AP.__TableName) ORM = typeof(tb_AP);
            if (tableName == tb_APs.__TableName) ORM = typeof(tb_APs);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 查询功能，获取主表数据
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            StringBuilder sql = new StringBuilder();

            if (docNoFrom != string.Empty) sql.Append(" and " + tb_AP.APNO + ">='" + docNoFrom + "'");
            if (docNoTo != string.Empty) sql.Append(" and " + tb_AP.APNO + "<='" + docNoTo + "'");

            if (docDateFrom > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_AP.ReceivedDate + ",112) >='" + ConvertEx.ToCharYYYYMMDD(docDateFrom) + "'");

            if (docDateTo > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_AP.ReceivedDate + ",112) <='" + ConvertEx.ToCharYYYYMMDD(docDateTo) + "'");

            if (sql.ToString() != "") //有查询条件
            {
                string query = "select a.*,b.NativeName AS SupplierName from tb_AP a LEFT JOIN tb_Customer b ON a.SupplierCode=b.CustomerCode where 1=1 " + sql.ToString();
                SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);
                DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_AP.__TableName);
                return dt;
            }
            else //无查询条件不返回数据
            {
                throw new Exception("没有指定查询条件!");
                return null;
            }
        }

        /// <summary>
        /// 获取一张业务单据的数据
        /// </summary>
        /// <param name="docNo">单据号码</param>
        /// <returns></returns>
        public System.Data.DataSet GetBusinessByKey(string docNo)
        {
            string sql1 = "select a.*,b.NativeName AS SupplierName from tb_AP a LEFT JOIN tb_Customer b ON a.SupplierCode=b.CustomerCode where [APNO]=@DocNo1 ";
            string sql2 = " select * from [vw_APs]   where [" + tb_AP.__KeyName + "]=@DocNo2 ORDER BY Queue "; //明细表排序
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@DocNo1", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo2", SqlDbType.VarChar, docNo.Trim());
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_AP.__TableName;
            ds.Tables[1].TableName = tb_APs.__TableName;//明细表
            return ds;
        }

        /// <summary>
        ///删除一张单据:只删除明细,主表金额清零!!!
        /// </summary>
        public bool Delete(string docNo)
        {
            //删除单据:只删除明细,主表金额清零!!!
            string sql1 = "UPDATE [tb_AP] SET Amount=0 where [" + tb_AP.__KeyName + "]=@DocNo1 ";
            string sql2 = "delete [tb_APs] where [" + tb_AP.__KeyName + "]=@DocNo2 ";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@DocNo1", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo2", SqlDbType.VarChar, docNo.Trim());
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

        /// <summary>
        //获取单据流水号码
        /// </summary>
        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "AP");
            return docNo;
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_RptAP");
            sp.AddParam("@DocNoFrom", SqlDbType.VarChar, DocNoFrom.Trim());
            sp.AddParam("@DocNoTo", SqlDbType.VarChar, DocNoTo.Trim());
            sp.AddParam("@DateFrom", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateFrom));
            sp.AddParam("@DateTo", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateTo));
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, sp.SqlCommand);
            ds.Tables[0].TableName = tb_AP.__TableName;
            ds.Tables[1].TableName = tb_APs.__TableName;
            return ds;
        }

        public DataSet GetReportData_Checklist(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_RptAP_Checklist");
            sp.AddParam("@DocNoFrom", SqlDbType.VarChar, DocNoFrom.Trim());
            sp.AddParam("@DocNoTo", SqlDbType.VarChar, DocNoTo.Trim());
            sp.AddParam("@DateFrom", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateFrom));
            sp.AddParam("@DateTo", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateTo));
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, sp.SqlCommand);
            ds.Tables[0].TableName = tb_AP.__TableName;
            return ds;
        }
    }
}

