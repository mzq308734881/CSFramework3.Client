using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_MyFormTagName", "AUID", true)]
    public class TFormTagName
    {
        public static string __TableName = "tb_MyFormTagName";

        public static string __KeyName = "AUID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string AUID = "AUID";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string TagName = "TagName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string MenuName = "MenuName";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string TagValue = "TagValue";

    }
}
