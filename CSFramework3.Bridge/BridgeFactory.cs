using System;
using System.Collections.Generic;
using System.Text;
using CSFramework3.Interfaces;
using CSFramework.Common;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Bridge.DataDictModule;
using CSFramework3.Bridge.SalesModule;
using CSFramework3.Bridge.SystemModule;
using CSFramework3.Bridge.CommonBridge;
using System.IO;
using CSFramework.Core;
using System.ServiceModel;
using System.Windows.Forms;
using CSFramework3.WebServiceReference;
using CSFramework3.WebServiceReference.WCF_CommonService;

namespace CSFramework3.Bridge
{
    /// <summary>
    /// 服务端桥接类型, 高级版支持ADO Direct与WebService层互换。
    /// </summary>
    public enum BridgeType
    {
        /// <summary>
        /// 未知桥接类型,用于初始化
        /// </summary>
        Unknow,

        /// <summary>        
        /// BLL层通过桥接方式调用数据层的接口
        /// BLL层直接调用数据层存取数据(ADO Direct)
        /// </summary>
        ADODirect,

        /// <summary>
        /// BLL层通过桥接方式调用WebService层的接口
        /// </summary>
        WebService
    }

    /// <summary>
    /// 数据层的桥接工厂
    /// </summary>
    public class BridgeFactory
    {
        public const string UNKNOW_BRIDGE_TYPE = "没有指定桥接类型(Bridge Type)，创建数据层桥接实例失败！";
        public const string TEST_BRIDGE_FAILED = "测试桥接功能失败，无法建立与后台数据层的连接！";
        public const string LOST_DAL_FILE = "数据访问层模块文件丢失！";

        /// <summary>
        /// 数据访问层模块文件名
        /// </summary>
        public const string DLL_FILE_NAME = "CSFramework3.Server.DataAccess.dll";

        /// <summary>
        /// 配置文件
        /// </summary>
        public const string INI_CFG = @"\config\user.ini";

        /// <summary>
        /// 动态配置桥接类型
        /// </summary>
        private static BridgeType _BridgeType = BridgeType.Unknow;

        /// <summary>
        /// 预设桥接类型
        /// </summary>
        private static BridgeType _DefaultBridgeType = BridgeType.WebService;

        /// <summary>
        /// 从配置文件获取桥接方式
        /// </summary>
        public static BridgeType BridgeType
        {
            get
            {
                if (_BridgeType == BridgeType.Unknow)
                {
                    string iniFile = Application.StartupPath + BridgeFactory.INI_CFG;

                    //有配置文件
                    if (File.Exists(iniFile))
                    {
                        IniFile ini = new IniFile(iniFile);
                        string bridgeType = ini.IniReadValue("BridgeType", "BridgeType");

                        if (Enum.IsDefined(typeof(BridgeType), bridgeType))
                            _BridgeType = (BridgeType)Enum.Parse(typeof(BridgeType), bridgeType);
                        else
                            return _DefaultBridgeType;//返回预设连接类型
                    }
                    else
                    {
                        _BridgeType = _DefaultBridgeType;//返回预设连接类型
                    }
                }

                return _BridgeType;
            }
        }

        /// <summary>
        /// 跟据ORM创建桥接功能
        /// </summary>
        /// <param name="ORM">ORM类</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(Type ORM)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_DataDict(ORM).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_DataDict(ORM);

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }


        /// <summary>
        /// 创建数据字典的数据层桥接实例
        /// </summary>
        /// <param name="tableName">数据字典表名</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(string tableName, string derivedClassName)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_DataDict(tableName, derivedClassName).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_DataDict(tableName);

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建数据字典的数据层桥接实例
        /// </summary>        
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(string derivedClassName)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_DataDict(derivedClassName).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_DataDict();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建用户组的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_UserGroup CreateUserGroupBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_UserGroup().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_UserGroup();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建公共数据层的桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_CommonData CreateCommonDataBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_CommonData().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_CommonData();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建公共数据字典数据层的桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_CommonDataDict CreateCommonDataDictBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_CommonDataDict().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_CommonDataDict();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建用户管理的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_User CreateUserBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_User().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_User();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 测试WebService连接
        /// </summary>
        /// <returns></returns>
        private static bool TestWebServiceConnection()
        {
            try
            {                
                CommonServiceClient commonService = SoapClientFactory.CreateCommonServiceClient();                                                
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return commonService.TestConnection(validationTicket);
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return false;
            }
        }

        /// <summary>
        /// 测试AdoDirect连接         
        /// </summary>
        /// <returns></returns>
        private static bool TestADOConnection()
        {
            // 数据访问层的模块文件
            string DalFile = Application.StartupPath + @"\" + DLL_FILE_NAME;

            bool exists = File.Exists(DalFile);
            if (false == exists)
                throw new CustomException(LOST_DAL_FILE + "\r\n\r\nFile:" + DalFile);
            return exists && SqlConfiguration.TestConnection();
        }

        /// <summary>
        /// 初始化桥接功能
        /// </summary>
        public static bool InitializeBridge()
        {
            bool connected = false;

            try
            {
                //ADODirect方式，从INI文件读配置信息
                if (BridgeType.ADODirect == BridgeType)
                {
                    //获取连接配置.支持4种连接配置:1.INI, 2.注册表 3.SQLExpress INI 4.Web.Config
                    //IWriteSQLConfigValue cfgRegistry = new RegisterWriter(SqlConfiguration.REG_SQL_CFG);

                    //开发环境，直接从INI文件读取SQL连接配置
                    //IWriteSQLConfigValue cfgSQLExpress = new SQLExpressCfg(Application.StartupPath + @"\CSFramework.ini");

                    //生产环境连接配置
                    IWriteSQLConfigValue cfgNormal = new IniFileWriter(Application.StartupPath + SqlConfiguration.INI_CFG_PATH);

                    //设置配置信息
                    SqlConfiguration.SetSQLConfig(cfgNormal);
                    connected = TestADOConnection();//测试AdoDirect连接                
                }

                if (BridgeType.WebService == BridgeType)
                {
                    //初始化服务端的SQL连接
                    connected = TestWebServiceConnection();//测试WebService连接
                }
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }

            //测试桥接是否成功
            if (false == connected)
            {
                Msg.Warning(TEST_BRIDGE_FAILED + "\r\n\r\nBridgeType:" + BridgeFactory.BridgeType.ToString());
            }

            return connected;
        }



    }
}
