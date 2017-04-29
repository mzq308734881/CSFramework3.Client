using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CSFramework3.Server.DataAccess.DAL_Base;
using CSFramework3.Models;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework.Common;
using CSFramework.ORM;
using CSFramework3.Interfaces;

namespace CSFramework3.Server.DataAccess.DAL_Business
{
    /// <summary>
    /// 库存调整数据层
    /// </summary>
    public class dalIO : dalBaseBusiness, IBridge_IO
    {
        public dalIO(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_IO.__TableName;
            _SummaryKeyName = tb_IO.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 返回数据表的类模型
        /// </summary>    
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_IO.__TableName) ORM = typeof(tb_IO);
            if (tableName == tb_IOs.__TableName) ORM = typeof(tb_IOs);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }


        /// <summary>
        /// 获取系统自动产生的流水号
        /// </summary>        
        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "IO");
            return docNo;
        }

        /// <summary>
        /// 按条件从申购单主表获取数据
        /// </summary>
        public System.Data.DataTable GetSummaryByParam(string IONOFrom, string IONOTo, DateTime DocDateFrom, DateTime DocDateTo)
        {
            StringBuilder sql = new StringBuilder();

            //或者调用存储过程 usp_QuerySO @

            if (IONOFrom != string.Empty) sql.Append(" and " + tb_IO.IONO + ">='" + IONOFrom + "'");
            if (IONOTo != string.Empty) sql.Append(" and " + tb_IO.IONO + "<='" + IONOTo + "'");
            if (DocDateFrom > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_IO.DocDate + ",112) >='" + ConvertEx.ToCharYYYYMMDD(DocDateFrom) + "'");
            if (DocDateTo > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_IO.DocDate + ",112) <='" + ConvertEx.ToCharYYYYMMDD(DocDateTo) + "'");

            if (sql.ToString() != "") //有查询条件
            {
                string query = "select a.*,b.NativeName AS CustomerName from tb_IO a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where 1=1 " + sql.ToString();
                SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);
                DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_IO.__TableName);
                return dt;
            }
            else //无查询条件不返回数据
            {
                throw new Exception("没有指定查询条件!");
            }

        }

        /// <summary>
        /// 获取单据
        /// </summary>
        public System.Data.DataSet GetBusinessByKey(string IONO)
        {
            string sql1 = "select a.*,b.NativeName AS CustomerName from tb_IO a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where [IONO]=@IONO ";
            string sql2 = " select * from [vw_IOs] where [IONO]=@IONO1 order by ProductCode ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@IONO", SqlDbType.VarChar, IONO.Trim());
            cmd.AddParam("@IONO1", SqlDbType.VarChar, IONO.Trim());
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_IO.__TableName;
            ds.Tables[1].TableName = tb_IOs.__TableName;

            return ds;
        }

        public System.Data.DataTable GetSummaryData()
        {
            string sql = "select * from [tb_IO]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_IO");
        }

        /// <summary>
        /// 删除单据方法. 单据不能全部删除否则单号会断号. 将主表的金额清零并删除所有明细数据。
        /// </summary> 
        public bool Delete(string IONO)
        {

            //删除单据:只删除明细及主表关键信息!!!
            string sql1 = "UPDATE [tb_IO] SET FlagApp='N' where [IONO]=@IONO ";
            string sql2 = "delete [tb_IOs] where [IONO]=@IONO_1 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@IONO", SqlDbType.VarChar, IONO.Trim());
            cmd.AddParam("@IONO_1", SqlDbType.VarChar, IONO.Trim());

            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

    }
}
