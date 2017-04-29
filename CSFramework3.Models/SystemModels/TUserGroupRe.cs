using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyUserGroupRe", "isid", true)]
    public class TUserGroupRe
    {
        public static string __TableName = "tb_MyUserGroupRe";

        public static string __KeyName = "isid";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string GroupCode = "GroupCode";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string Account = "Account";
    }
}
