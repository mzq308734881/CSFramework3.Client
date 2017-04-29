using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{
    /*==========================================
     *   程序说明: tb_AccountIDs的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2012-05-04 09:20:01
     *   最后修改: 2012-05-04 09:20:01
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 C/S框架网 www.csframework.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_AccountIDs,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_AccountIDs", "AccID", false)]
    public sealed class tb_AccountIDs
    {
        public static string __TableName = "tb_AccountIDs";

        public static string __KeyName = "AccID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, true, false, false)]
        public static string AccID = "AccID";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string AccName = "AccName";

    }
}