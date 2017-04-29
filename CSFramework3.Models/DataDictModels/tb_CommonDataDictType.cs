using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

/*==========================================
 *   程序说明: tb_CommDataDictType的ORM
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:08:45
 *   最后修改: 2011-03-24 03:08:45
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_CommDataDictType", "DataType", true)]
    public class tb_CommDataDictType
    {
        public static string __TableName = "tb_CommDataDictType";

        public static string __KeyName = "DataType";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string isid = "isid";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string DataType = "DataType";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 20, false, true, false, false, false)]
        public static string TypeName = "TypeName";

    }
}