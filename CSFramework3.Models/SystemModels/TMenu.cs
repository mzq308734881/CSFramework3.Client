using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyMenu", "MenuName", true)]
    public class TMenu
    {
        public static string __TableName = "tb_MyMenu";

        public static string __KeyName = "MenuName";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string MenuName = "MenuName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string MenuCaption = "MenuCaption";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string Auths = "Auths";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string ModuleID = "ModuleID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string MenuType = "MenuType";
    }
}
