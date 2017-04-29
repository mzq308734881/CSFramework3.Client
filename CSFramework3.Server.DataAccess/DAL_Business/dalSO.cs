using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework.ORM;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_Business
{

    /// <summary>
    /// 销售订单的数据处理层
    /// </summary>
    public class dalSO : dalBaseBusiness, IBridge_SO
    {

        public dalSO(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_SO.__TableName;
            _SummaryKeyName = tb_SO.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_SO.__TableName) ORM = typeof(tb_SO);
            if (tableName == tb_SOs.__TableName) ORM = typeof(tb_SOs);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 查询功能，获取主表数据
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            StringBuilder sql = new StringBuilder();

            //或者调用存储过程 usp_QuerySO @

            if (docNoFrom != string.Empty)
                sql.Append(" and " + tb_SO.SONO + ">='" + docNoFrom + "'");
            if (docNoTo != string.Empty)
                sql.Append(" and " + tb_SO.SONO + "<='" + docNoTo + "'");
            if (docDateFrom > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_SO.ReceiveDay + ",112) >='" + ConvertEx.ToCharYYYYMMDD(docDateFrom) + "'");
            if (docDateTo > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_SO.ReceiveDay + ",112) <='" + ConvertEx.ToCharYYYYMMDD(docDateTo) + "'");

            if (sql.ToString() != "") //有查询条件
            {
                string query = "select a.*,b.NativeName AS CustomerNativeName from tb_SO a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where 1=1 " + sql.ToString();
                SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);
                DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_SO.__TableName);
                return dt;
            }
            else //无查询条件不返回数据
            {
                throw new Exception("没有指定查询条件!");                
            }
        }

        /// <summary>
        /// 获取一张业务单据的数据
        /// </summary>
        /// <param name="docNo">单据号码</param>
        /// <returns></returns>
        public System.Data.DataSet GetBusinessByKey(string docNo)
        {
            string sql1 = " select a.*,b.NativeName AS CustomerNativeName from [tb_SO] a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where [SONO]=@DocNo1 ";
            string sql2 = " select * from [vw_SOs]           where [SONO]=@DocNo2 ORDER BY Queue "; //明细表排序
            string sql3 = " select * from [tb_AttachFile]    where [DocID]  =@DocNo3 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2 + sql3);
            cmd.AddParam("@DocNo1", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo2", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo3", SqlDbType.VarChar, docNo.Trim());
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_SO.__TableName;
            ds.Tables[1].TableName = tb_SOs.__TableName;
            ds.Tables[2].TableName = tb_AttachFile.__TableName;
            return ds;
        }

        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="takeNo">单据号码</param>
        /// <returns></returns>
        public bool Delete(string docNo)
        {
            //删除单据:只删除明细,主表金额清零!!!
            string sql1 = "UPDATE [tb_SO] SET Amount=0 where [SONO]=@DocNo1 ";
            string sql2 = "delete [tb_SOs] where [SONO]=@DocNo2 ";
            string sql3 = "delete [tb_AttachFile] where [DocID]=@DocNo3 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2 + sql3);
            cmd.AddParam("@DocNo1", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo2", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo3", SqlDbType.VarChar, docNo.Trim());
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "SO");
            return docNo;
        }

        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_RptSO");
            sp.AddParam("@DocNoFrom", SqlDbType.VarChar, DocNoFrom.Trim());
            sp.AddParam("@DocNoTo", SqlDbType.VarChar, DocNoTo.Trim());
            sp.AddParam("@DateFrom", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateFrom));
            sp.AddParam("@DateTo", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(DateTo));
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, sp.SqlCommand);
            ds.Tables[0].TableName = tb_SO.__TableName;
            ds.Tables[1].TableName = tb_SOs.__TableName;
            return ds;
        }
    }
}
