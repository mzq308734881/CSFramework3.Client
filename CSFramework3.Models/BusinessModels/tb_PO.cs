using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


    /*==========================================
     *   程序说明: tb_PO的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2012-02-08 01:16:50
     *   最后修改: 2012-02-08 01:16:50
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 C/S框架网 www.csframework.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_PO,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_PO", "PONO", true)]
    public sealed class tb_PO
    {
        public static string __TableName = "tb_PO";

        public static string __KeyName = "PONO";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, true, false, true)]
        public static string PONO = "PONO";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string PODate = "PODate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string POUser = "POUser";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerCode = "CustomerCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerContact = "CustomerContact";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerTel = "CustomerTel";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string PayType = "PayType";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerOrderNo = "CustomerOrderNo";

        [ORM_FieldAttribute(SqlDbType.VarChar, 4, false, true, false, false, false)]
        public static string Currency = "Currency";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Amount = "Amount";

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