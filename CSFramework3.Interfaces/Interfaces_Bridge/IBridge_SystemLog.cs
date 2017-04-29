using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces.Interfaces_Bridge
{
    public interface IBridge_EditLogHistory
    {
        DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo);
        DataTable GetLogFieldDef(string tableName);
        string[] GetTracedFields(string tableName);
        bool SaveFieldDef(DataTable data);
        void WriteLog(string logID, DataTable originalData, DataTable changes, string tableName, string keyFieldName, bool isMaster);
    }
}
