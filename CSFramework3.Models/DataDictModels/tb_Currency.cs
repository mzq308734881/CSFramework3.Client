using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


/*==========================================
 *   程序说明: tb_Currency的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2012-04-17 12:41:18
 *   最后修改: 2012-04-17 12:41:18
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_Currency,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_Currency", "Currency", true)]
    public sealed class tb_Currency
    {
        public static string __TableName ="tb_Currency";

        public static string __KeyName = "Currency";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string isid = "isid"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,10,false,true,true,false,false)]
        public static string Currency = "Currency"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CurrencyName = "CurrencyName"; 

    }
}