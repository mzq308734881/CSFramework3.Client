using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_CompanyInfo", "ISID", true)]
    public class tb_CompanyInfo
    {
        public static string __TableName = "tb_CompanyInfo";

        public static string __KeyName = "ISID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 3, false, true, false, false, false)]
        public static string CompanyCode = "CompanyCode";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 40, false, true, false, false, false)]
        public static string NativeName = "NativeName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 40, false, true, false, false, false)]
        public static string EnglishName = "EnglishName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 40, false, true, false, false, false)]
        public static string ProgramName = "ProgramName";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string ReportHead = "ReportHead";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 200, false, true, false, false, false)]
        public static string Address = "Address";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string Tel = "Tel";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 50, false, true, false, false, false)]
        public static string Fax = "Fax";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CreationDate = "CreationDate";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string LastUpdateDate = "LastUpdateDate";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string CreatedBy = "CreatedBy";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string LastUpdatedBy = "LastUpdatedBy";
    }


}
