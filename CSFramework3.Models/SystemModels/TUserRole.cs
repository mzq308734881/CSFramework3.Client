using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyUserRole", "isid", true)]
    public class TUserRole
    {
        public static string __TableName = "tb_MyUserRole";

        public static string __KeyName = "isid";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.VarChar, 30, false, true, false, false, false)]
        public static string GroupCode = "GroupCode";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string ModuleID = "ModuleID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string AuthorityID = "AuthorityID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string Authorities = "Authorities";

    }
}
