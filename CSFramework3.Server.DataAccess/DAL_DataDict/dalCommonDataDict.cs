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
 *   程序说明: CommonDataDict的数据访问层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:12:50
 *   最后修改: 2011-03-24 03:12:50
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Server.DataAccess.DAL_DataDict
{

    /// <summary>
    /// 公共数据字典数据层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_CommonDataDict), true)]
    public class dalCommonDataDict : dalBaseDataDict, IBridge_CommonDataDict
    {
        public dalCommonDataDict(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_CommonDataDict.__KeyName; //主键字段
            _TableName = tb_CommonDataDict.__TableName;//表名
            _ModelType = typeof(tb_CommonDataDict);//字典表ORM
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_CommonDataDict.__TableName) ORM = typeof(tb_CommonDataDict);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM);
        }

        /// <summary>
        /// 数据字典：手动控制事务及自动生成流水号
        /// </summary>
        /// <param name="data">用户提交的数据</param>
        /// <returns></returns>
        public override SaveResultEx UpdateEx(DataSet data)
        {
            SaveResultEx result = new SaveResultEx((int)ResultID.SUCCESS, "");

            try
            {
                this.BeginTransaction();//启动事务

                DataTable summary = data.Tables[tb_CommonDataDict.__TableName];//取出主表数据
                string dataType = ConvertEx.ToString(summary.Rows[0][tb_CommonDataDict.DataType]);//取数据类型
                string dataCode = DocNoTool.GetDataSN(_CurrentTrans, dataType, true);//在同一事务内取流水号
                summary.Rows[0][tb_CommonDataDict.DataCode] = dataCode;

                result = base.UpdateEx(data);//提交数据
                result.PrimaryKey = dataCode;//返回自动生成的主键

                this.CommitTransaction();//提交事务
            }
            catch
            {
                this.RollbackTransaction();//回滚
            }

            return result;
        }

        /// <summary>
        /// 搜索指定类型的数据
        /// </summary>
        /// <param name="DataType">数据类型</param>
        /// <returns></returns>
        public DataTable SearchBy(int DataType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tb_CommonDataDict WHERE 1=1 ");

            if (DataType > 0)
                sb.Append(" AND DataType=" + DataType.ToString());

            sb.Append(" ORDER BY DataType,DataCode ");

            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sb.ToString());
            return DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_CommonDataDict.__TableName);

        }

        /// <summary>
        /// 增加一项数据类型
        /// </summary>
        /// <param name="code">类型编号</param>
        /// <param name="name">类型名称</param>
        /// <returns></returns>
        public bool AddCommonType(int code, string name)
        {
            string sql = "INSERT INTO tb_CommDataDictType (DataType,TypeName) VALUES (@DataType,@TypeName)";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@DataType", SqlDbType.Int, code);
            cmd.AddParam("@TypeName", SqlDbType.NVarChar, name);
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i > 0;
        }

        /// <summary>
        /// 删除数据类型
        /// </summary>
        /// <param name="code">数据类型编号</param>
        /// <returns></returns>
        public bool DeleteCommonType(int code)
        {
            string sql = "DELETE tb_CommDataDictType WHERE DataType=@DataType";
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@DataType", SqlDbType.Int, code);
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i > 0;
        }

        /// <summary>
        /// 检查数据类型是否存在
        /// </summary>
        /// <param name="id">数据类型编号</param>
        /// <returns></returns>
        public bool IsExistsCommonType(int id)
        {
            string sql = "SELECT COUNT(*) C FROM tb_CommDataDictType WHERE DataType=" + id.ToString();
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, sql);
            return ConvertEx.ToInt(o) > 0;
        }


    }
}
