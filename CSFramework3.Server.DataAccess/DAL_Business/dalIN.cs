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
    public class dalIN : dalBaseBusiness, IBridge_IN
    {
        public dalIN(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_IN.__TableName;
            _SummaryKeyName = tb_IN.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 返回数据表的类模型
        /// </summary>    
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_IN.__TableName) ORM = typeof(tb_IN);
            if (tableName == tb_INs.__TableName) ORM = typeof(tb_INs);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }


        /// <summary>
        /// 获取系统自动产生的流水号
        /// </summary>        
        protected override string GetNumber(SqlTransaction tran)
        {
            string docNo = DocNoTool.GetNumber(tran, "IN");
            return docNo;
        }

        /// <summary>
        /// 按条件从申购单主表获取数据
        /// </summary>
        public System.Data.DataTable GetSummaryByParam(string INNOFrom, string INNOTo, DateTime DocDateFrom, DateTime DocDateTo)
        {
            StringBuilder sql = new StringBuilder();

            //或者调用存储过程 usp_QuerySO @

            if (INNOFrom != string.Empty) sql.Append(" and " + tb_IN.INNO + ">='" + INNOFrom + "'");
            if (INNOTo != string.Empty) sql.Append(" and " + tb_IN.INNO + "<='" + INNOTo + "'");
            if (DocDateFrom > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_IN.DocDate + ",112) >='" + ConvertEx.ToCharYYYYMMDD(DocDateFrom) + "'");
            if (DocDateTo > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_IN.DocDate + ",112) <='" + ConvertEx.ToCharYYYYMMDD(DocDateTo) + "'");

            if (sql.ToString() != "") //有查询条件
            {
                string query = "select a.*,b.NativeName AS SupplierName from tb_IN a LEFT JOIN tb_Customer b ON a.SupplierCode=b.CustomerCode where 1=1 " + sql.ToString();
                SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);
                DataTable dt = DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_IN.__TableName);
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
        public System.Data.DataSet GetBusinessByKey(string INNO)
        {
            string sql1 = "select a.*,b.NativeName AS SupplierName from tb_IN a LEFT JOIN tb_Customer b ON a.SupplierCode=b.CustomerCode where [INNO]=@INNO ";
            string sql2 = " select * from [vw_INs] where [INNO]=@INNO1 order by ProductCode ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@INNO", SqlDbType.VarChar, INNO.Trim());
            cmd.AddParam("@INNO1", SqlDbType.VarChar, INNO.Trim());
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_IN.__TableName;
            ds.Tables[1].TableName = tb_INs.__TableName;

            return ds;
        }

        public System.Data.DataTable GetSummaryData()
        {
            string sql = "select * from [tb_IN]";
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_IN");
        }

        /// <summary>
        /// 删除单据方法. 单据不能全部删除否则单号会断号. 将主表的金额清零并删除所有明细数据。
        /// </summary> 
        public bool Delete(string INNO)
        {

            //删除单据:只删除明细及主表关键信息!!!
            string sql1 = "UPDATE [tb_IN] SET FlagApp='N' where [INNO]=@INNO ";
            string sql2 = "delete [tb_INs] where [INNO]=@INNO_1 ";

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@INNO", SqlDbType.VarChar, INNO.Trim());
            cmd.AddParam("@INNO_1", SqlDbType.VarChar, INNO.Trim());

            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

    }
}
