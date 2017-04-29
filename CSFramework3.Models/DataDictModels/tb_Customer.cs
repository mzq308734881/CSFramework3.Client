using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

/*==========================================
 *   程序说明: tb_Customer的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:05:54
 *   最后修改: 2011-03-24 03:05:54
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_Customer", "CustomerCode", true)]
    public class tb_Customer
    {
        public static string __TableName = "tb_Customer";

        public static string __KeyName = "CustomerCode";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string ISID = "ISID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,false)]
        public static string CustomerCode = "CustomerCode"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,200,false,true,false,false,false)]
        public static string NativeName = "NativeName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string EnglishName = "EnglishName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string AttributeCodes = "AttributeCodes"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,100,false,true,false,false,false)]
        public static string Address1 = "Address1"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,100,false,true,false,false,false)]
        public static string Address2 = "Address2"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,100,false,true,false,false,false)]
        public static string Address3 = "Address3"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string Country = "Country"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string Region = "Region"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string City = "City"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,12,false,true,false,false,false)]
        public static string CountryCode = "CountryCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,6,false,true,false,false,false)]
        public static string CityCode = "CityCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string Tel = "Tel"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string Fax = "Fax"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string PostalCode = "PostalCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string ZipCode = "ZipCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string WebAddress = "WebAddress"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,400,false,true,false,false,false)]
        public static string Email = "Email"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string Bank = "Bank"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string BankAccount = "BankAccount"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,100,false,true,false,false,false)]
        public static string BankAddress = "BankAddress"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string ContactPerson = "ContactPerson"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,400,false,true,false,false,false)]
        public static string Remark = "Remark";

        [ORM_FieldAttribute(SqlDbType.VarChar, 10, false, true, false, false, false)]
        public static string InUse = "InUse"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string PaymentTerm = "PaymentTerm"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string CreationDate = "CreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string CreatedBy = "CreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string LastUpdateDate = "LastUpdateDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string LastUpdatedBy = "LastUpdatedBy"; 

    }
}