using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using System.ServiceModel;

namespace CSFramework3.WebServiceReference
{

    /// <summary>
    /// 从config文件加载WCF服务配置。
    /// </summary>
    public class SoapClientConfig
    {

        public static string ConfigFile
        {
            get { return Application.StartupPath + @"\CSFramework3.WebServiceReference.dll.config"; }
        }

        /// <summary>
        /// 从config文件获取WebService的连接地址
        /// </summary>
        /// <param name="endPointName">SOAP endPointName</param>
        /// <returns></returns>
        public static string GetSoapRemoteAddress(string endPointName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(SoapClientConfig.ConfigFile);
            string xpath = "configuration/system.serviceModel/client/endpoint[@name='" + endPointName + "']";
            XmlNode node = xml.SelectSingleNode(xpath);
            return node.Attributes["address"].Value;
        }

        /// <summary>
        /// 设置BasicHttpBinding对象的配置信息
        /// </summary>
        /// <param name="BINDING">BasicHttpBinding对象</param>
        /// <param name="bindingName">bindingName</param>
        public static void ReadBindingConfig(System.ServiceModel.BasicHttpBinding BINDING, string bindingName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(SoapClientConfig.ConfigFile);

            string xpath;
            XmlNode node;

            xpath = "configuration/system.serviceModel/bindings/basicHttpBinding/binding[@name='" + bindingName + "']";
            node = xml.SelectSingleNode(xpath);

            BINDING.MaxBufferSize = Int32.Parse(node.Attributes["maxBufferSize"].Value);
            BINDING.MaxBufferPoolSize = Int32.Parse(node.Attributes["maxBufferPoolSize"].Value);
            BINDING.MaxReceivedMessageSize = Int32.Parse(node.Attributes["maxReceivedMessageSize"].Value);

            xpath = "configuration/system.serviceModel/bindings/basicHttpBinding/binding[@name='" + bindingName + "']/readerQuotas";
            node = xml.SelectSingleNode(xpath);
            BINDING.ReaderQuotas.MaxDepth = Int32.Parse(node.Attributes["maxDepth"].Value);
            BINDING.ReaderQuotas.MaxStringContentLength = Int32.Parse(node.Attributes["maxStringContentLength"].Value);
            BINDING.ReaderQuotas.MaxArrayLength = Int32.Parse(node.Attributes["maxArrayLength"].Value);
            BINDING.ReaderQuotas.MaxBytesPerRead = Int32.Parse(node.Attributes["maxBytesPerRead"].Value);
            BINDING.ReaderQuotas.MaxNameTableCharCount = Int32.Parse(node.Attributes["maxNameTableCharCount"].Value);
        }

        /// <summary>
        /// 设置WSHttpBinding对象的配置信息
        /// </summary>
        /// <param name="BINDING">WSHttpBinding</param>
        /// <param name="bindingName">名称</param>
        public static void ReadBindingConfig(WSHttpBinding BINDING, string bindingName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(SoapClientConfig.ConfigFile);

            string xpath;
            XmlNode node;

            xpath = "configuration/system.serviceModel/bindings/wsHttpBinding/binding[@name='" + bindingName + "']";
            node = xml.SelectSingleNode(xpath);

            BINDING.MaxBufferPoolSize = Int32.Parse(node.Attributes["maxBufferPoolSize"].Value);
            BINDING.MaxReceivedMessageSize = Int32.Parse(node.Attributes["maxReceivedMessageSize"].Value);
            BINDING.ReceiveTimeout = TimeSpan.Parse(node.Attributes["receiveTimeout"].Value);

            //数据包大小配额设置
            xpath = "configuration/system.serviceModel/bindings/wsHttpBinding/binding[@name='" + bindingName + "']/readerQuotas";
            node = xml.SelectSingleNode(xpath);
            BINDING.ReaderQuotas.MaxDepth = Int32.Parse(node.Attributes["maxDepth"].Value);
            BINDING.ReaderQuotas.MaxStringContentLength = Int32.Parse(node.Attributes["maxStringContentLength"].Value);
            BINDING.ReaderQuotas.MaxArrayLength = Int32.Parse(node.Attributes["maxArrayLength"].Value);
            BINDING.ReaderQuotas.MaxBytesPerRead = Int32.Parse(node.Attributes["maxBytesPerRead"].Value);
            BINDING.ReaderQuotas.MaxNameTableCharCount = Int32.Parse(node.Attributes["maxNameTableCharCount"].Value);

            //可靠性会话功能设置
            xpath = "configuration/system.serviceModel/bindings/wsHttpBinding/binding[@name='" + bindingName + "']/reliableSession";
            node = xml.SelectSingleNode(xpath);
            BINDING.ReliableSession.Enabled = Boolean.Parse(node.Attributes["enabled"].Value);
            BINDING.ReliableSession.InactivityTimeout = TimeSpan.Parse(node.Attributes["inactivityTimeout"].Value);
            BINDING.ReliableSession.Ordered = Boolean.Parse(node.Attributes["ordered"].Value);

            //安全配置
            xpath = "configuration/system.serviceModel/bindings/wsHttpBinding/binding[@name='" + bindingName + "']/security";
            node = xml.SelectSingleNode(xpath);
            BINDING.Security.Mode = (SecurityMode)Enum.Parse(typeof(SecurityMode), node.Attributes["mode"].Value);

            //xpath = "configuration/system.serviceModel/bindings/wsHttpBinding/binding[@name='" + bindingName + "']/security/message";
            //node = xml.SelectSingleNode(xpath);
            //BINDING.Security.Message.ClientCredentialType = (MessageCredentialType)Enum.Parse(typeof(MessageCredentialType), node.Attributes["clientCredentialType"].Value);
            
        }

    }
}
