using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyUser", "Account", true)]
    public class TUser
    {
        public static string __TableName = "tb_MyUser";

        public static string __KeyName = "Account";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string Account = "Account";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string UserName = "UserName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string Address = "Address";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string Tel = "Tel";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 40, false, true, false, false, false)]
        public static string Email = "Email";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string Password = "Password";

        [ORM_FieldAttribute(SqlDbType.DateTime, 4, false, true, false, false, false)]
        public static string LastLoginTime = "LastLoginTime";

        [ORM_FieldAttribute(SqlDbType.DateTime, 4, false, true, false, false, false)]
        public static string LastLogoutTime = "LastLogoutTime";

        [ORM_FieldAttribute(SqlDbType.Char, 1, false, true, false, false, false)]
        public static string IsLocked = "IsLocked";

        [ORM_FieldAttribute(SqlDbType.DateTime, 4, false, true, false, false, false)]
        public static string CreateTime = "CreateTime";

        [ORM_FieldAttribute(SqlDbType.Char, 1, false, true, false, false, false)]
        public static string FlagAdmin = "FlagAdmin";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string LoginCounter = "LoginCounter";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string NovellAccount = "NovellAccount";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string DomainName = "DomainName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 250, false, true, false, false, false)]
        public static string DataSets = "DataSets";



    }

}
