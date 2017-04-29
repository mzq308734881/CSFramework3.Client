using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


    /*==========================================
     *   程序说明: tb_AR的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2012-04-28 10:55:16
     *   最后修改: 2012-04-28 10:55:16
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 C/S框架网 www.csframework.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_AR,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_AR", "ARNO", true)]
    public sealed class tb_AR
    {
        public static string __TableName = "tb_AR";

        public static string __KeyName = "ARNO";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string ISID = "ISID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, true, false, true)]
        public static string ARNO = "ARNO";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string ChequeNo = "ChequeNo";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string ReceivedDate = "ReceivedDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CustomerCode = "CustomerCode";

        [ORM_FieldAttribute(SqlDbType.VarChar, 200, false, false, false, false, false)]
        public static string CustomerName = "CustomerName";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string ChequeBank = "ChequeBank";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string Currency = "Currency";

        [ORM_FieldAttribute(SqlDbType.Decimal, 9, false, true, false, false, false)]
        public static string Amount = "Amount";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 200, false, true, false, false, false)]
        public static string Remark = "Remark";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CreationDate = "CreationDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string CreatedBy = "CreatedBy";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string LastUpdateDate = "LastUpdateDate";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string LastUpdatedBy = "LastUpdatedBy";

        [ORM_FieldAttribute(SqlDbType.Char, 1, false, true, false, false, false)]
        public static string FlagApp = "FlagApp";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public static string AppUser = "AppUser";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string AppDate = "AppDate";

    }
}