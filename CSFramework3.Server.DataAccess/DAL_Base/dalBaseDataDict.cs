///*************************************************************************/
///*
///* 文件名    ：bllBaseDataDict.cs                                 
///* 程序说明  : 数据字典数据层基类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CSFramework.ORM;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_System;
using System.Reflection;
using System.Globalization;
using System.Collections;

namespace CSFramework3.Server.DataAccess.DAL_Base
{

    /// <summary>
    /// 数据字典数据层基类
    /// </summary>
    public class dalBaseDataDict : dalBase, IBridge_DataDict
    {
        /// <summary>
        /// ORM模型
        /// </summary>
        protected Type _ModelType = null;

        /// <summary>
        /// 字典表名
        /// </summary>
        protected string _TableName = string.Empty;

        /// <summary>
        /// 主键字段名
        /// </summary>
        protected string _KeyName = string.Empty;

        public Type ORM
        {
            get { return _ModelType; }
            set
            {
                _ModelType = value;

                if (_ModelType == null) throw new Exception("ORM为能为null!");

                object[] attrs = _ModelType.GetCustomAttributes(typeof(ORM_ObjectClassAttribute), false);
                if (attrs.Length == 0) throw new Exception("ORM模型没定义ORM_ObjectClassAttribute属性!");

                _TableName = (attrs[0] as ORM_ObjectClassAttribute).TableName;
                _KeyName = (attrs[0] as ORM_ObjectClassAttribute).PrimaryKey;
            }
        }

        public string TableName { get { return _TableName; } set { _TableName = value; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        public dalBaseDataDict(Loginer loginer) : base(loginer) { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="ORM">数据字典的ORM类</param>
        public dalBaseDataDict(Loginer loginer, Type ORM_Type)
            : base(loginer)
        {
            this.ORM = ORM_Type;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="tableName">字典表名</param>
        public dalBaseDataDict(Loginer loginer, string tableName)
            : base(loginer)
        {
            _TableName = tableName;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="tableName">字典表名</param>
        /// <param name="keyName">主键字段名</param>
        /// <param name="modelType">数据字典的ORM类</param>
        public dalBaseDataDict(Loginer loginer, string tableName, string keyName, Type modelType)
            : base(loginer)
        {
            _ModelType = modelType;
            _TableName = tableName;
            _KeyName = keyName;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="data">需要更新的数据集(只要指定表名与ORM,支持更新多个数据表)</param>
        /// <returns></returns>
        public virtual bool Update(DataSet data)
        {
            //非用户手动事务模式，预设启用事务
            if (_UserManualControlTrans == false) this.BeginTransaction();

            if (_CurrentTrans == null) throw new Exception("用户手动控制事务模式下，但您没有启用事务！");

            try
            {
                foreach (DataTable dt in data.Tables)
                {
                    if (dt.GetChanges() == null) continue; //没有数据更新

                    IGenerateSqlCommand gen = this.CreateSqlGenerator(dt.TableName);
                    if (gen == null) throw new Exception("创建IGenerateSqlCommand失败！");

                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.RowUpdating += new SqlRowUpdatingEventHandler(OnAdapterRowUpdating);
                    adp.UpdateCommand = GetUpdateCommand(gen, _CurrentTrans);
                    adp.InsertCommand = GetInsertCommand(gen, _CurrentTrans);
                    adp.DeleteCommand = GetDeleteCommand(gen, _CurrentTrans);
                    adp.Update(dt);
                }

                if (_UserManualControlTrans == false) this.CommitTransaction(); //提交事务

                return true;
            }
            catch (Exception ex)
            {
                if (_UserManualControlTrans == false) this.RollbackTransaction();//回滚事务

                throw new Exception("更新数据发生错误！Event:Update()\r\n\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// 更新数据的扩展方法，在dalBaseDataDict类作为模板方法，具体类需要重写此方法。
        /// </summary>
        /// <param name="data">需要更新的数据集(只要指定表名与ORM,支持更新多个数据表)</param>
        /// <returns></returns>
        public virtual SaveResultEx UpdateEx(DataSet data)
        {
            bool success = this.Update(data);//调用预设的保存方法

            //返回一个对象类型的结果
            return new SaveResultEx(success ? (int)ResultID.SUCCESS : (int)ResultID.FAILED, "");
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected virtual IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            if (_ModelType == null) throw new Exception("没绑定数据表结构定义!");

            if (tableName == _TableName)
                return new GenerateSqlCmdByTableFields(_ModelType); //预设
            else
                throw new Exception("创建IGenerateSqlCommand失败！");

            //支持两种SQL命令生成器
            //IGenerateSqlCommand gen = new GenerateSqlCmdByObjectClass(_ModelType);
        }

        /// <summary>
        /// 检查表名是否为空
        /// </summary>
        public void AssertTableName()
        {
            if (_TableName == string.Empty)
                throw new Exception("数据字典未指定表名!");
        }

        /// <summary>
        /// 检查主键是否为空
        /// </summary>
        public void AssertTableKey()
        {
            if ((_TableName == string.Empty) || (_KeyName == string.Empty))
                throw new Exception("数据字典未指定表名或主键!");
        }

        /// <summary>
        /// 获取主表数据
        /// </summary>
        /// <returns></returns>
        public virtual DataTable GetSummaryData()
        {
            this.AssertTableName();
            string sql = string.Format("SELECT * FROM [{0}]", _TableName);
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, _TableName);
        }

        /// <summary>
        /// 获取指定主键的数据
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public virtual DataTable GetDataByKey(string key)
        {
            string sql = string.Format("SELECT * FROM [{0}] WHERE [{1}]=@KEY", _TableName, _KeyName);
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@KEY", SqlDbType.VarChar, key);
            return DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, _TableName);
        }

        /// <summary>
        /// 跟据表名取数据字典
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <returns></returns>
        public virtual DataTable GetDataDictByTableName(string tableName)
        {
            if (String.IsNullOrEmpty(tableName)) throw new Exception("表名不能为空！");
            string sql = string.Format("SELECT * FROM [{0}]", tableName);
            return DataProvider.Instance.GetTable(_Loginer.DBName, sql, tableName);
        }

        /// <summary>
        /// 下载所有数据字典
        /// </summary>
        /// <returns></returns>
        public DataSet DownloadDicts()
        {
            SqlProcedure cmd = SqlBuilder.BuildSqlProcedure("sp_GetDataDicts");
            return DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
        }

        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual bool CheckNoExists(string keyValue)
        {
            string sql = string.Format("SELECT COUNT(*) C FROM [{0}] WHERE [{1}]=@KEY", _TableName, _KeyName);
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@KEY", SqlDbType.VarChar, keyValue);
            object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, cmd.SqlCommand);

            return ConvertEx.ToInt(o) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual bool Delete(string keyValue)
        {
            string sql = string.Format("Delete [{0}] where [{1}]=@KEY", _TableName, _KeyName);
            SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            cmd.AddParam("@KEY", SqlDbType.VarChar, keyValue);
            int i = DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

        #region CreateDataDictDAL

        /// <summary>
        /// 跟据DAL类名创建数据层实例
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        /// <param name="derivedClassName">DAL类名</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDalByClassName(Loginer loginer, string derivedClassName)
        {
            Type T = typeof(dalBaseDataDict).Assembly.GetType(derivedClassName, true, true);

            object[] args = new object[] { loginer }; //参数

            object dal = T.Assembly.CreateInstance(derivedClassName, true, BindingFlags.CreateInstance,
                null, args, CultureInfo.CurrentCulture, null);

            return dal as IBridge_DataDict;
        }

        //哈希表, 保存已加载的DAL类的引用地址
        private static Hashtable _LoadedDalTypes = null;

        /// <summary>
        /// 跟据ORM类全名自动创建DAL对象实例
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        /// <param name="ORM_TypeName">ORM类的命名空间</param>
        /// <returns></returns>
        public static dalBaseDataDict CreateDalByORM(Loginer loginer, string ORM_TypeName)
        {
            if (String.IsNullOrEmpty(ORM_TypeName)) throw new CustomException("ORM类名为空，无法创建实例！");
            if (_LoadedDalTypes == null) _LoadedDalTypes = new Hashtable(); //创建哈希表实例
            Type _DAL_Type = null; //DAL类定义

            //哈希表存在该类,从哈希表取出.
            if (_LoadedDalTypes.ContainsKey(ORM_TypeName))
                _DAL_Type = _LoadedDalTypes[ORM_TypeName] as Type;
            else
            {
                //
                //哈希表不存在,表示第一次加载,需要从CSFramework3.Server.DataAccess程序集中查询该类                
                //
                //获取DataAccess程序集中所有Public类  
                Type[] types = typeof(dalBaseDataDict).Assembly.GetExportedTypes();

                //枚举程序集中所有Public类  
                foreach (Type T in types)
                {
                    //只查找dalBaseDataDict的子类
                    if (false == T.IsSubclassOf(typeof(dalBaseDataDict))) continue;

                    //查找DefaultORM_UpdateMode特性
                    object[] atts = T.GetCustomAttributes(typeof(DefaultORM_UpdateMode), false);
                    if ((atts == null) || (atts.Length == 0)) continue;

                    //该类有定义DefaultORM_UpdateMode特性
                    DefaultORM_UpdateMode att = atts[0] as DefaultORM_UpdateMode;
                    if (false == att.IsOverrideClass) continue; //仅查找具体类(子类)

                    //比较ORM的全名是否相同
                    if (att.ORM.FullName.ToUpper() == ORM_TypeName.ToUpper())
                    {
                        _DAL_Type = T;
                        break;
                    }
                }

                //第一次加载后添加到哈希表中, 基于性能优化.
                if (_DAL_Type != null) _LoadedDalTypes.Add(ORM_TypeName, _DAL_Type);
            }

            //没有找到指定的数据层，预设为数据字典基类
            if (_DAL_Type == null) _DAL_Type = typeof(dalBaseDataDict);

            //创建DAL实例
            object instance = _DAL_Type.Assembly.CreateInstance(_DAL_Type.FullName, true,
                BindingFlags.CreateInstance, null,
                 new object[] { loginer }, CultureInfo.CurrentCulture, null);

            if (instance is dalBaseDataDict)
                return instance as dalBaseDataDict;
            else
                //查出的类非dalBaseDataDict派生类,重新生成dalBaseDataDict类实例
                return new dalBaseDataDict(loginer);
        }

        #endregion


    }
}
