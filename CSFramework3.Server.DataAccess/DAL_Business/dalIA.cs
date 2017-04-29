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
    public class dalIA : dalBaseBusiness, IBridge_IA
    {
        public dalIA(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_IA.__TableName;
            _SummaryKeyName = tb_IA.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 返回数据表的类模型
        /// </summary>    
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_IA.__TableName) ORM = typeof(tb_IA);
            if (tableName == tb_IAs.__TableName) ORM = typeof(tb_IAs);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }


        /// <summary>
        /// 获取系统自动产生的流水号
        /// </summary>        
        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "IA");
            return docNo;
        }

        /// <summary>
        /// 按条件从申购单主表获取数据
        /// </summary>
        public System.Data.DataTable GetSummaryByParam(string IANOFrom, string IANOTo, DateTime DocDateFrom, DateTime DocDateTo)
        {
            StringBuilder sql = new StringBuilder();
            if (IANOFrom != string.Empty)
                sql.Append(" and " + tb_IA.IANO + ">=@IANOFrom ");
            if (IANOTo != string.Empty)
                sql.Append(" and " + tb_IA.IANO + "=@IANOTo ");

            if (DocDateFrom > DateTime.MinValue)
            {
                sql.Append(" and Convert(varchar," + tb_IA.CreationDate + ",112) >=");
                sql.Append("'" + ConvertEx.ToCharYYYYMMDD(DocDateFrom) + "'");
            }

            if (DocDateTo > DateTime.MinValue)
            {
                sql.Append(" and Convert(varchar," + tb_IA.CreationDate + ",112) <=");
                sql.Append("'" + ConvertEx.ToCharYYYYMMDD(DocDateTo) + "'");
            }

            SqlCommandBase cmd;

            if (sql.ToString() != "")
            {
                cmd = SqlBuilder.BuildSqlCommandBase("select * from " + tb_IA.__TableName + " where 1=1 " + sql.ToString());

                if (IANOFrom != string.Empty)
                    cmd.AddParam("@IANOFrom", SqlDbType.VarChar, IANOFrom.Trim());
                if (IANOTo != string.Empty)
                    cmd.AddParam("@IANOTo", SqlDbType.VarChar, IANOTo.Trim());
            }
            else
                cmd = SqlBuilder.BuildSqlCommandBase("select top 0 * from " + tb_IA.__TableName + " where 1=0 ");

            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_IA.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取单据
        /// </summary>
        public System.Data.DataSet GetBusinessByKey(string IANO)
        {
            string sql1 = " select * from [tb_IA] where [IANO]=@IANO ";
            string sql2 = " select * from [vw_IAs] where [IANO]=@IANO1 order by ProductCode ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@IANO", SqlDbType.VarChar, IANO.Trim());
            cmd.AddParam("@IANO1", SqlDbType.VarChar, IANO.Trim());            
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_IA.__TableName;
            ds.Tables[1].TableName = tb_IAs.__TableName;

            return ds;
        }

        public System.Data.DataTable GetSummaryData()
        {
            string sql = "select * from [tb_IA]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_IA");
        }

        /// <summary>
        /// 删除单据方法. 单据不能全部删除否则单号会断号. 将主表的金额清零并删除所有明细数据。
        /// </summary> 
        public bool Delete(string IANO)
        {

            //删除单据:只删除明细及主表关键信息!!!
            string sql1 = "UPDATE [tb_IA] SET Reason=NULL,FlagApp='N' where [IANO]=@IANO ";
            string sql2 = "delete [tb_IAs] where [IANO]=@IANO_1 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@IANO", SqlDbType.VarChar, IANO.Trim());
            cmd.AddParam("@IANO_1", SqlDbType.VarChar, IANO.Trim());

            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

    }
}
