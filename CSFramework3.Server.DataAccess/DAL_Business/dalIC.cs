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
    public class dalIC : dalBaseBusiness, IBridge_IC
    {
        public dalIC(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_IC.__TableName;
            _SummaryKeyName = tb_IC.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 返回数据表的类模型
        /// </summary>    
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_IC.__TableName) ORM = typeof(tb_IC);
            if (tableName == tb_ICs.__TableName) ORM = typeof(tb_ICs);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }


        /// <summary>
        /// 获取系统自动产生的流水号
        /// </summary>        
        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "IC");
            return docNo;
        }

        /// <summary>
        /// 按条件从申购单主表获取数据
        /// </summary>
        public System.Data.DataTable GetSummaryByParam(string ICNOFrom, string ICNOTo, DateTime DocDateFrom, DateTime DocDateTo)
        {
            StringBuilder sql = new StringBuilder();
            if (ICNOFrom != string.Empty)
                sql.Append(" and " + tb_IC.ICNO + ">=@ICNOFrom ");
            if (ICNOTo != string.Empty)
                sql.Append(" and " + tb_IC.ICNO + "=@ICNOTo ");

            if (DocDateFrom > DateTime.MinValue)
            {
                sql.Append(" and Convert(varchar," + tb_IC.CreationDate + ",112) >=");
                sql.Append("'" + ConvertEx.ToCharYYYYMMDD(DocDateFrom) + "'");
            }

            if (DocDateTo > DateTime.MinValue)
            {
                sql.Append(" and Convert(varchar," + tb_IC.CreationDate + ",112) <=");
                sql.Append("'" + ConvertEx.ToCharYYYYMMDD(DocDateTo) + "'");
            }

            SqlCommandBase cmd;

            if (sql.ToString() != "")
            {
                cmd = SqlBuilder.BuildSqlCommandBase("select * from " + tb_IC.__TableName + " where 1=1 " + sql.ToString());

                if (ICNOFrom != string.Empty)
                    cmd.AddParam("@ICNOFrom", SqlDbType.VarChar, ICNOFrom.Trim());
                if (ICNOTo != string.Empty)
                    cmd.AddParam("@ICNOTo", SqlDbType.VarChar, ICNOTo.Trim());
            }
            else
                cmd = SqlBuilder.BuildSqlCommandBase("select top 0 * from " + tb_IC.__TableName + " where 1=0 ");

            DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_IC.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取单据
        /// </summary>
        public System.Data.DataSet GetBusinessByKey(string ICNO)
        {
            string sql1 = " select * from [tb_IC] where [ICNO]=@ICNO ";
            string sql2 = " select * from [vw_ICs] where [ICNO]=@ICNO1 order by ProductCode ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@ICNO", SqlDbType.VarChar, ICNO.Trim());
            cmd.AddParam("@ICNO1", SqlDbType.VarChar, ICNO.Trim());            
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_IC.__TableName;
            ds.Tables[1].TableName = tb_ICs.__TableName;

            return ds;
        }

        public System.Data.DataTable GetSummaryData()
        {
            string sql = "select * from [tb_IC]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_IC");
        }

        /// <summary>
        /// 删除单据方法. 单据不能全部删除否则单号会断号. 将主表的金额清零并删除所有明细数据。
        /// </summary> 
        public bool Delete(string ICNO)
        {

            //删除单据:只删除明细及主表关键信息!!!
            string sql1 = "UPDATE [tb_IC] SET FlagApp='N' where [ICNO]=@ICNO ";
            string sql2 = "delete [tb_ICs] where [ICNO]=@ICNO_1 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@ICNO", SqlDbType.VarChar, ICNO.Trim());
            cmd.AddParam("@ICNO_1", SqlDbType.VarChar, ICNO.Trim());

            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

    }
}
