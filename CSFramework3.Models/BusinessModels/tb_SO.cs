using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{

    ///<summary>
    /// ORM模型, 数据表:tb_SO,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_SO", "SONO", true)]
    public sealed class tb_SO
    {
        public static string __TableName = "tb_SO";

        public static string __KeyName = "SONO";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, true, false, true)]
        public static string SONO = "SONO";

        [ORM_FieldAttribute(SqlDbType.VarChar, 2, false, true, false, false, false)]
        public static string VerNo = "VerNo";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerCode = "CustomerCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, false, false, false, false)]
        public static string CustomerNativeName = "CustomerNativeName";
        
        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string ReceiveDay = "ReceiveDay";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string PayType = "PayType";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerOrderNo = "CustomerOrderNo";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string Salesman = "Salesman";

        [ORM_FieldAttribute(SqlDbType.VarChar, 4, false, true, false, false, false)]
        public static string Currency = "Currency";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Amount = "Amount";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string FinishingStatus = "FinishingStatus";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string OrderFinishDay = "OrderFinishDay";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 400, false, true, false, false, false)]
        public static string Remark = "Remark";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CreationDate = "CreationDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CreatedBy = "CreatedBy";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string LastUpdateDate = "LastUpdateDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string LastUpdatedBy = "LastUpdatedBy";

        [ORM_FieldAttribute(SqlDbType.Char, 1, false, true, false, false, false)]
        public static string FlagApp = "FlagApp";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string AppUser = "AppUser";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string AppDate = "AppDate";

    }
}