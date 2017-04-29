using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


/*==========================================
 *   程序说明: tb_ARs的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2012-04-28 10:55:45
 *   最后修改: 2012-04-28 10:55:45
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_ARs,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_ARs", "ISID", false)]
    public sealed class tb_ARs
    {
        public static string __TableName ="tb_ARs";

        public static string __KeyName = "ISID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,true,false,false)]
        public static string ISID = "ISID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,true,false)]
        public static string ARNO = "ARNO"; 

        [ORM_FieldAttribute(SqlDbType.Decimal,9,false,true,false,false,false)]
        public static string Queue = "Queue"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string InvoiceNo = "InvoiceNo"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string SONO = "SONO"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string Currency = "Currency"; 

        [ORM_FieldAttribute(SqlDbType.Decimal,9,false,true,false,false,false)]
        public static string Amount = "Amount"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,200,false,true,false,false,false)]
        public static string Remark = "Remark"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string CreationDate = "CreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CreatedBy = "CreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string LastUpdateDate = "LastUpdateDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string LastUpdatedBy = "LastUpdatedBy"; 

    }
}