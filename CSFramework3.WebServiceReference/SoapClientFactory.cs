using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using CSFramework3.WebServiceReference.WCF_CommonService;
using CSFramework3.WebServiceReference.WCF_SalesModuleService;
using CSFramework3.WebServiceReference.WCF_DataDictService;
using CSFramework3.WebServiceReference.WCF_SystemSecurityService;
using CSFramework.Common;
using CSFramework3.WebServiceReference.WCF_PurchaseModuleService;
using CSFramework3.WebServiceReference.WCF_InventoryModuleService;
using CSFramework3.WebServiceReference.WCF_AccountModuleService;
namespace CSFramework3.WebServiceReference
{

    /// <summary>
    /// WCF服务客户端实例工厂
    /// </summary>
    public class SoapClientFactory
    {

        /// <summary>
        /// 创建公共服务的SOAP Client对象
        /// </summary>
        /// <returns></returns>
        public static CommonServiceClient CreateCommonServiceClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_ICommonService");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_ICommonService");
            return new CommonServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建销售模块的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static SalesModuleServiceClient CreateSalesModuleClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_ISalesModuleService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_ISalesModuleService");
            return new SalesModuleServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建采购模块的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static PurchaseModuleServiceClient CreatePurchaseModuleClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_IPurchaseModuleService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_IPurchaseModuleService");
            return new PurchaseModuleServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建数据字典的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static DataDictServiceClient CreateDataDictClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_IDataDictService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_IDataDictService");
            return new DataDictServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建系统安全管理的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static SystemSecurityServiceClient CreateSecurityClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_ISystemSecurityService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_ISystemSecurityService");
            return new SystemSecurityServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建库存管理的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static InventoryModuleServiceClient CreateInventoryModuleServiceClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_IInventoryModuleService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_IInventoryModuleService");
            return new InventoryModuleServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

        /// <summary>
        /// 创建财务模块的WCF客户端实例
        /// </summary>
        /// <returns></returns>
        public static AccountModuleServiceClient CreateAccountModuleServiceClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_IAccountModuleService");//从配置文件(app.config)读取配置。

            string endpoint = SoapClientConfig.GetSoapRemoteAddress("WSHttpBinding_IAccountModuleService");
            return new AccountModuleServiceClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }

    }
}
