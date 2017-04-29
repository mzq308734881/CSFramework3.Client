using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Common;
using System.Data;

namespace CSFramework3.Interfaces
{
    public interface IBridge_AP
    {
        DataSet GetBusinessByKey(string keyValue);

        DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo);
        SaveResult Update(System.Data.DataSet saveData);

        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);
        void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate);

        DataSet GetReportData_Checklist(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);
        DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);
    }
}
