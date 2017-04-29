using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_AttachFile", "FileID", true)]
    public class tb_AttachFile
    {
        public static string __TableName = "tb_AttachFile";

        public static string __KeyName = "FileID"; //isid

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string FileID = "FileID";//isid

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, true, false)]
        public static string DocID = "DocID";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string FileTitle = "FileTitle";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string FileName = "FileName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 10, false, true, false, false, false)]
        public static string FileType = "FileType";

        [ORM_FieldAttribute(SqlDbType.Decimal, 18, false, true, false, false, false)]
        public static string FileSize = "FileSize";

        [ORM_FieldAttribute(SqlDbType.Image, 0, false, true, false, false, false)]
        public static string FileBody = "FileBody";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 1, false, true, false, false, false)]
        public static string IsDroped = "IsDroped";

        [ORM_FieldAttribute(SqlDbType.Image, 0, false, false, false, false, false)]
        public static string IconLarge = "IconLarge";

        [ORM_FieldAttribute(SqlDbType.Image, 0, false, false, false, false, false)]
        public static string IconSmall = "IconSmall";
    }
}
