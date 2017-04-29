using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces.Interfaces_Bridge
{
    /// <summary>
    /// 共同数据层的桥接接口
    /// </summary>
    public interface IBridge_CommonData
    {
        DataTable GetSystemDataSet();
        DataTable GetTableFields(string tableName);
        DataTable GetBusinessTables();
        DataTable GetModules();
        DataTable GetTableFieldsDef(string tableName, bool onlyDisplayField);

        DataTable GetDB4Backup();

        DataTable GetBackupHistory(int topList);

        bool BackupDatabase(string DBNAME, string BKPATH);

        bool RestoreDatabase(string BKFILE, string DBNAME);

        string GetDataSN(string dataCode, bool asHeader);

        DataTable SearchOutstanding(string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType);
    }
}
