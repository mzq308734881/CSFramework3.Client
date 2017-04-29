using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    public class ServerLibrary
    {

        /// <summary>
        /// 数据表转换为DataSet
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns></returns>
        public static DataSet TableToDataSet(DataTable table)
        {
            if (table.DataSet != null)
                return table.DataSet;
            else
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                return ds;
            }
        }
    }
}
