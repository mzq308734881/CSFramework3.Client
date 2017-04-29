using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Common;
using System.Data;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 销售订单的桥接接口
    /// </summary>
    public interface IBridge_SO
    {
        DataSet GetBusinessByKey(string keyValue);
        DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);
        DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo);
        SaveResult Update(System.Data.DataSet saveData);

        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);
        void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate);        
    }
}
