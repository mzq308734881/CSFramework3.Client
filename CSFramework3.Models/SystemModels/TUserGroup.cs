using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyUserGroup", "GroupCode", true)]
    public class TUserGroup
    {
        public static string __TableName = "tb_MyUserGroup";

        public static string __KeyName = "GroupCode";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 30, false, true, false, false, false)]
        public static string GroupCode = "GroupCode";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string GroupName = "GroupName";

    }

    public class BusinessDataSetIndex
    {
        public const int Groups = 0;
        public const int GroupUsers = 1;
        public const int GroupAuthorities = 2;
        public const int GroupAvailableUser = 3;
    }
}
