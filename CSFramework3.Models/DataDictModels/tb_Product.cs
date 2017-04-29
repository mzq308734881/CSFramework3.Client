using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{

    ///<summary>
    /// ORM模型, 数据表:tb_Product,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_Product", "ProductCode", true)]
    public sealed class tb_Product
    {
        public static string __TableName ="tb_Product";

        public static string __KeyName = "ProductCode";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string isid = "isid"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,false)]
        public static string ProductCode = "ProductCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string ProductName = "ProductName"; 

        [ORM_FieldAttribute(SqlDbType.Decimal,9,false,true,false,false,false)]
        public static string SellPrice = "SellPrice"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string Supplier = "Supplier"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string Remark = "Remark"; 

    }
}