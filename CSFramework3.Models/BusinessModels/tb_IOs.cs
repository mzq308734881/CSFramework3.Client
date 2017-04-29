using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


    /*==========================================
     *   程序说明: tb_IOs的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2012-04-16 08:54:18
     *   最后修改: 2012-04-16 08:54:18
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 C/S框架网 www.csframework.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_IOs,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_IOs", "ISID", false)]
    public sealed class tb_IOs
    {
        public static string __TableName = "tb_IOs";

        public static string __KeyName = "ISID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Queue = "Queue";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, true, false)]
        public static string IONO = "IONO";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string ProductCode = "ProductCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, false, false, false, false)]
        public static string ProductName = "ProductName";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string Quantity = "Quantity";

        [ORM_FieldAttribute(SqlDbType.VarChar, 250, false, true, false, false, false)]
        public static string Remark = "Remark";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CreationDate = "CreationDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CreatedBy = "CreatedBy";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string LastUpdateDate = "LastUpdateDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string LastUpdatedBy = "LastUpdatedBy";

    }
}