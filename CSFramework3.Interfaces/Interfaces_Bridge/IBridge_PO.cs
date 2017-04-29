using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSFramework.Common;

namespace CSFramework3.Interfaces.Interfaces_Bridge
{
    public interface IBridge_PO
    {
        DataSet GetBusinessByKey(string keyValue);
        DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

        DataSet GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer);
        SaveResult Update(System.Data.DataSet saveData);

        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);
        void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate);
    }
}
