using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{

/*==========================================
 *   程序说明: tb_PayType的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2011-04-05 12:45:33
 *   最后修改: 2011-04-05 12:45:33
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_PayType,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_PayType", "PayType", true)]
    public sealed class tb_PayType
    {
        public static string __TableName ="tb_PayType";

        public static string __KeyName = "PayType";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string isid = "isid"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,10,false,true,true,false,false)]
        public static string PayType = "PayType"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string TypeName = "TypeName"; 

    }
}