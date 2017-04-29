using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{

    ///<summary>
    /// ORM模型, 数据表:tb_SOs,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_SOs", "ISID", false)]
    public sealed class tb_SOs
    {
        public static string __TableName = "tb_SOs";

        public static string __KeyName = "ISID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, true, false)]
        public static string SONO = "SONO";

        [ORM_FieldAttribute(SqlDbType.Decimal, 5, false, true, false, false, false)]
        public static string Queue = "Queue";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string StockCode = "StockCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string CustomerOrderNo = "CustomerOrderNo";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string ShipDay = "ShipDay";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string Unit = "Unit";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string Qty = "Qty";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Price = "Price";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Amount = "Amount";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string Remark = "Remark";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CreationDate = "CreationDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string CreatedBy = "CreatedBy";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string LastUpdateDate = "LastUpdateDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string LastUpdatedBy = "LastUpdatedBy";

    }
}