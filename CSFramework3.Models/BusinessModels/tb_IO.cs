using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


/*==========================================
 *   程序说明: tb_IO的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2012-04-16 08:53:44
 *   最后修改: 2012-04-16 08:53:44
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_IO,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_IO", "IONO", true)]
    public sealed class tb_IO
    {
        public static string __TableName ="tb_IO";

        public static string __KeyName = "IONO";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string ISID = "ISID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,true)]
        public static string IONO = "IONO"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string DocDate = "DocDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string DocUser = "DocUser"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string RefNo = "RefNo"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CustomerCode = "CustomerCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 100, false, false, false, false, false)]
        public static string CustomerName = "CustomerName";

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string Department = "Department"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string Deliver = "Deliver"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string LocationID = "LocationID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,250,false,true,false,false,false)]
        public static string Remark = "Remark"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CreatedBy = "CreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string CreationDate = "CreationDate"; 

        [ORM_FieldAttribute(SqlDbType.Char,1,false,true,false,false,false)]
        public static string FlagApp = "FlagApp"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string AppUser = "AppUser"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string AppDate = "AppDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string LastUpdatedBy = "LastUpdatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string LastUpdateDate = "LastUpdateDate"; 

    }
}