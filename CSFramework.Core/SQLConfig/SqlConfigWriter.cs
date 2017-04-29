///*************************************************************************/
///*
///* 文件名    ：SqlConfigWriter.cs                                
///* 程序说明  : SQL连接配置存储策略
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using CSFramework.Common;
using System.IO;

namespace CSFramework.Core
{
    /// <summary>
    /// 将连接配置保存在INI文件
    /// </summary>
    public class IniFileWriter : IWriteSQLConfigValue
    {
        #region IWriteConfigValue Members

        private string _iniFile;
        private string _ServerName;
        private string _Password;
        private string _UserName;
        private string _InitialCatalog;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        public IniFileWriter(string iniFile)
        {
            _iniFile = iniFile;
            if (!System.IO.File.Exists(iniFile))
                Write();

            Read();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                _ServerName = cfg.IniReadValue("SQL Configuration", "SqlServer");
                _InitialCatalog = cfg.IniReadValue("SQL Configuration", "database");
                _UserName = cfg.IniReadValue("SQL Configuration", "SqlUser");
                _Password = CEncoder.Decode(cfg.IniReadValue("SQL Configuration", "SqlPwd")); //解密

            }
        }

        /// <summary>
        /// 将配置写入INI文件
        /// </summary>
        public void Write()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                cfg.IniWriteValue("SQL Configuration", "SqlServer", _ServerName);
                cfg.IniWriteValue("SQL Configuration", "Database", _InitialCatalog);
                cfg.IniWriteValue("SQL Configuration", "SqlUser", _UserName);
                cfg.IniWriteValue("SQL Configuration", "SqlPwd", CEncoder.Encode(_Password)); //加密
            }
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        public string BuildConnectionString()
        {
            return new SqlConfiguration().GetConnectionString(this);
        }

        /// <summary>
        /// 加载连接配置
        /// </summary>
        /// <param name="ConfigFile">配置文件</param>
        public static void LoadConfiguration(string ConfigFile)
        {
            if (System.IO.File.Exists(ConfigFile))
            {
                IWriteSQLConfigValue cfg = new IniFileWriter(ConfigFile);
                SqlConfiguration.SetSQLConfig(cfg);
            }
            else
                throw new Exception("Program cann't run without a SQL configuration.You should config the SQL connection by running CSFramework.Tools.SqlConnector.exe!");
        }

        public string InitialCatalog { get { return _InitialCatalog; } set { _InitialCatalog = value; } }
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }

        #endregion
    }

    /// <summary>
    /// 将连接配置保存在INI文件(开发环境使用)
    /// </summary>
    public class SQLExpressCfg : IWriteSQLConfigValue
    {
        private string _ConnectionString;
        private string _iniFile;

        public SQLExpressCfg(string iniFile)
        {
            _iniFile = iniFile;
            this.Read();
        }
        #region IWriteSQLConfigValue Members

        public void Write()
        {
            //
        }

        public void Read()
        {
            _ConnectionString = File.ReadAllText(_iniFile, Encoding.UTF8);
        }

        public string BuildConnectionString()
        {
            return _ConnectionString;
        }

        public string ServerName { get { return ""; } set { } }
        public string InitialCatalog { get { return ""; } set { } }
        public string UserName { get { return ""; } set { } }
        public string Password { get { return ""; } set { } }

        #endregion
    }

    /// <summary>
    /// 连接参数保存在系统注册表
    /// </summary>
    public class RegisterWriter : IWriteSQLConfigValue
    {
        #region IWriteConfigValue Members

        private string _keyPath;
        private string _ServerName;
        private string _Password;
        private string _UserName;
        private string _InitialCatalog;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="keyPath">注册表位置</param>
        public RegisterWriter(string keyPath)
        {
            _keyPath = keyPath;
            Read();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(_keyPath);
            if (key != null)
            {
                _ServerName = ConvertEx.ToString(key.GetValue("SqlServer", "."));
                _InitialCatalog = ConvertEx.ToString(key.GetValue("SqlDatabase", ""));
                _UserName = ConvertEx.ToString(key.GetValue("SqlUser", "sa"));
                _Password = ConvertEx.ToString(key.GetValue("SqlPwd", ""));
                if (_Password != string.Empty) _Password = CEncoder.Decode(_Password);
                key.Close();
            }
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        public void Write()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(_keyPath);
            if (key != null)
            {
                key.SetValue("SqlServer", _ServerName);
                key.SetValue("SqlDatabase", _InitialCatalog);
                key.SetValue("SqlUser", _UserName);
                key.SetValue("SqlPwd", CEncoder.Encode(_Password));
                key.Close();
            }
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        public string BuildConnectionString()
        {
            return new SqlConfiguration().GetConnectionString(this);
        }

        public string InitialCatalog { get { return _InitialCatalog; } set { _InitialCatalog = value; } }
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }

        #endregion
    }

    /// <summary>
    /// 将连接配置保存在INI文件(开发环境使用)
    /// </summary>
    public class WebConfigCfg : IWriteSQLConfigValue
    {
        private string _ConnectionString;

        public WebConfigCfg()
        {
            this.Read();
        }

        #region IWriteSQLConfigValue Members

        public void Write()
        {
            //
        }

        public void Read()
        {
            _ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["SystemConnectionString"];
        }

        public string BuildConnectionString()
        {
            return _ConnectionString;
        }

        public string ServerName { get { return ""; } set { } }
        public string InitialCatalog { get { return ""; } set { } }
        public string UserName { get { return ""; } set { } }
        public string Password { get { return ""; } set { } }

        #endregion
    }


}
