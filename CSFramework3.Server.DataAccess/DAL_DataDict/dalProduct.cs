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
 *   程序说明: Product的数据访问层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-27 04:04:54
 *   最后修改: 2011-03-27 04:04:54
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Server.DataAccess.DAL_DataDict
{
    /// <summary>
    /// Product的数据访问层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_Product), true)]
    public class dalProduct : dalBaseDataDict, IBridge_Product
    {
        public dalProduct(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_Product.__KeyName; //主键字段
            _TableName = tb_Product.__TableName;//表名
            _ModelType = typeof(tb_Product);
        }


        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_Product.__TableName) ORM = typeof(tb_Product);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }

        public DataTable FuzzySearch(string content)
        {
            SqlProcedure sp = SqlBuilder.BuildSqlProcedure("sp_FuzzySearchProduct");
            sp.AddParam("@Content", SqlDbType.NVarChar, content);
            return DataProvider.Instance.GetTable(_Loginer.DBName, sp.SqlCommand, tb_Product.__TableName);

        }
    }
}
