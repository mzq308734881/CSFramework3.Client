using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework.ORM;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_Base;

/*==========================================
 *   程序说明: Customer的数据访问层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:12:50
 *   最后修改: 2011-03-24 03:12:50
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Server.DataAccess.DAL_DataDict
{
    /// <summary>
    /// Customer的数据访问层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_Customer), true)]
    public class dalCustomer : dalBaseDataDict, IBridge_Customer
    {
        public dalCustomer(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_Customer.__KeyName; //主键字段
            _TableName = tb_Customer.__TableName;//表名
            _ModelType = typeof(tb_Customer);
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_Customer.__TableName) ORM = typeof(tb_Customer);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }


        public DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name, string Attribute)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tb_Customer WHERE 1=1 ");

            if (String.IsNullOrEmpty(CustomerFrom) == false)
                sb.Append(" AND CustomerCode>='" + CustomerFrom + "'");

            if (String.IsNullOrEmpty(CustomerTo) == false)
                sb.Append(" AND CustomerCode<='" + CustomerTo + "'");

            if (String.IsNullOrEmpty(Name) == false)
                sb.Append(" AND (NativeName LIKE '%" + Name + "%' OR NativeName LIKE '%" + Name + "%')");

            if (String.IsNullOrEmpty(Attribute) == false)
                sb.Append(" AND CHARINDEX('," + Attribute + ",',AttributeCodes)>0 ");

            sb.Append(" ORDER BY CustomerCode ");

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sb.ToString());
            return DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_Customer.__TableName);

        }

        public DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_GetCustomerByAttributeCodes");
            sp.AddParam("@AttributeCodes", SqlDbType.VarChar, attributeCodes);
            sp.AddParam("@NameWithCode", SqlDbType.VarChar, nameWithCode ? "Y" : "N");
            return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, "tb_Customer");
        }

        public DataTable FuzzySearch(string content)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_FuzzySearchCustomer");
            sp.AddParam("@Content", SqlDbType.VarChar, content);
            sp.AddParam("@AttributeCodes", SqlDbType.VarChar, "");
            return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, tb_Customer.__TableName);
        }

        public DataTable FuzzySearch(string attributeCodes, string content)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_FuzzySearchCustomer");
            sp.AddParam("@Content", SqlDbType.VarChar, content);
            sp.AddParam("@AttributeCodes", SqlDbType.VarChar, attributeCodes);
            return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, tb_Customer.__TableName);
        }
    }
}
