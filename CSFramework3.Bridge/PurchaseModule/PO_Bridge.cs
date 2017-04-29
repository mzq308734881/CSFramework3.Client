using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Server.DataAccess.DAL_Business;
using CSFramework.Common;
using CSFramework3.WebServiceReference.WCF_PurchaseModuleService;
using CSFramework3.WebServiceReference;
using CSFramework.Core;
using System.Data;

namespace CSFramework3.Bridge.SalesModule
{
    public class ADODirect_PO
    {
        private IBridge_PO _DAL_Instance = null;//数据层实例

        public ADODirect_PO()
        {
            _DAL_Instance = new dalPO(Loginer.CurrentUser);
        }

        public IBridge_PO GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_PO : IBridge_PO
    {

        public WebService_PO()
        {
        }

        #region IBridge_SO 成员

        public System.Data.DataSet GetBusinessByKey(string keyValue)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.PO_GetBusinessByKey(loginTicket, keyValue);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.PO_GetReportData(loginTicket, DocNoFrom, DocNoTo, DateFrom, DateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataSet GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.PO_GetSummaryByParam(loginTicket, docNoFrom, docNoTo, docDateFrom, docDateTo, StockCode, Customer);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public SaveResult Update(DataSet saveData)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(saveData);
                byte[] receivedData = client.PO_Update(loginTicket, bs);
                return ZipTools.DecompressionObject(receivedData) as SaveResult;
            }
        }

        public bool Delete(string keyValue)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.PO_Delete(loginTicket, keyValue);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.PO_CheckNoExists(loginTicket, keyValue);
            }
        }

        public void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate)
        {
            using (PurchaseModuleServiceClient client = SoapClientFactory.CreatePurchaseModuleClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.PO_ApprovalBusiness(loginTicket, keyValue, flagApp, appUser, appDate);
            }
        }

        #endregion
    }

}
