using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


    /*==========================================
     *   程序说明: tb_POs的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2012-02-08 01:17:42
     *   最后修改: 2012-02-08 01:17:42
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 C/S框架网 www.csframework.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_POs,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_POs", "ISID", false)]
    public sealed class tb_POs
    {
        public static string __TableName = "tb_POs";

        public static string __KeyName = "ISID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, true, false)]
        public static string PONO = "PONO";

        [ORM_FieldAttribute(SqlDbType.Decimal, 5, false, true, false, false, false)]
        public static string Queue = "Queue";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string ProductCode = "ProductCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string Unit = "Unit";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string Quantity = "Quantity";

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