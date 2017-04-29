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
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Interfaces.Interfaces_Bridge;

/*==========================================
 *   程序说明: PO的数据访问层
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2011-05-07 07:09:53
 *   最后修改: 2011-05-07 07:09:53
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

namespace CSFramework3.Server.DataAccess.DAL_Business
{
    /// <summary>
    /// dalPO
    /// </summary>
    public class dalPO : dalBaseBusiness, IBridge_PO
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        public dalPO(Loginer loginer)
            : base(loginer)
        {
            _SummaryTableName = tb_PO.__TableName;
            _SummaryKeyName = tb_PO.__KeyName;
            _UpdateSummaryKeyMode = UpdateKeyMode.OnlyDocumentNo;
        }

        /// <summary>
        /// 提交采购订单资料。此方法演示用户自己控制事务。
        /// </summary>
        /// <param name="data">数据集</param>
        /// <returns></returns>
        public override SaveResult Update(DataSet data)
        {
            _UserManualControlTrans = true;//自己控制事务

            try
            {
                this.BeginTransaction(); //手工启用事务

                SaveResult mResult = base.Update(data); //调用基类的方法提交数据。

                //提交数据后，在同一事务内调用后台的存储过程更新库存信息。
                DataProvider.Instance.ExecuteSQL(_CurrentTrans, "usp_TestUpdateStock");

                //同一事务内处理更多的数据。
                DataProvider.Instance.ExecuteSQL(_CurrentTrans, "usp_TestUpdateOther");

                this.CommitTransaction();//提交事务

                return mResult;
            }
            catch (Exception ex)
            {
                this.RollbackTransaction();//事务回滚
                throw ex;
            }
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;
            if (tableName == tb_PO.__TableName) ORM = typeof(tb_PO);
            if (tableName == tb_POs.__TableName) ORM = typeof(tb_POs);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 查询功能，获取主表数据
        /// </summary>
        public DataSet GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer)
        {
            StringBuilder sql = new StringBuilder();
            //
            if (docNoFrom != string.Empty)
                sql.Append(" and " + tb_PO.PONO + ">='" + docNoFrom + "'");
            if (docNoTo != string.Empty)
                sql.Append(" and " + tb_PO.PONO + "<='" + docNoTo + "'");
            if (docDateFrom > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_PO.PODate + ",112) >='" + ConvertEx.ToCharYYYYMMDD(docDateFrom) + "'");
            if (docDateTo > DateTime.MinValue)
                sql.Append(" and Convert(varchar," + tb_PO.PODate + ",112) <='" + ConvertEx.ToCharYYYYMMDD(docDateTo) + "'");
            if (StockCode != string.Empty)
                sql.Append(" and PONO IN (SELECT PONO FROM tb_POs WHERE 1=1 AND " + tb_POs.ProductCode + "='" + StockCode + "')");
            if (Customer != string.Empty)
                sql.Append(" and " + tb_PO.CustomerCode + "='" + Customer + "'");
            if (sql.ToString() != "") //有查询条件
            {
                string query = "select a.*,b.NativeName AS CustomerName from tb_PO a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where 1=1 " + sql.ToString();
                SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(query);
                return DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);                
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
            //Class Generator有 Bug, 应该为：            
            string sql1 = " select a.*,b.NativeName AS CustomerName from [tb_PO] a LEFT JOIN tb_Customer b ON a.CustomerCode=b.CustomerCode where [PONO]=@DocNo1 ";
            string sql2 = " select * from [vw_POs]   where [" + tb_PO.__KeyName + "]=@DocNo2 ORDER BY Queue "; //明细表排序
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql1 + sql2);
            cmd.AddParam("@DocNo1", SqlDbType.VarChar, docNo.Trim());
            cmd.AddParam("@DocNo2", SqlDbType.VarChar, docNo.Trim());
            DataSet ds = DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            ds.Tables[0].TableName = tb_PO.__TableName;
            ds.Tables[1].TableName = tb_POs.__TableName;//明细表
            return ds;
        }

        /// <summary>
        ///删除一张单据:只删除明细,主表金额清零!!!
        /// </summary>
        public bool Delete(string docNo)
        {
            //删除单据:只删除明细,主表金额清零!!!
            string sql1 = "UPDATE [tb_PO] SET Amount=0 where [" + tb_PO.__KeyName + "]=@DocNo1 ";
            string sql2 = "delete [tb_POs] where [" + tb_PO.__KeyName + "]=@DocNo2 ";
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
            string docNo = DocNoTool.GetNumber(tran, "PO");
            return docNo;
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }

    }
}

