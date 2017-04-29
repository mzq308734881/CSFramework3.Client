using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


/*==========================================
 *   程序说明: tb_IA的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2012-04-14 11:23:02
 *   最后修改: 2012-04-14 11:23:02
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_IA,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_IA", "IANO", true)]
    public sealed class tb_IA
    {
        public static string __TableName ="tb_IA";

        public static string __KeyName = "IANO";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string ISID = "ISID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,true)]
        public static string IANO = "IANO"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string DocDate = "DocDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string DocUser = "DocUser"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string Reason = "Reason"; 

        [ORM_FieldAttribute(SqlDbType.Char,1,false,true,false,false,false)]
        public static string FlagApp = "FlagApp"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,250,false,true,false,false,false)]
        public static string Remark = "Remark"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CreatedBy = "CreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string CreationDate = "CreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string AppUser = "AppUser"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string AppDate = "AppDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string LastUpdatedBy = "LastUpdatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string LastUpdateDate = "LastUpdateDate"; 

    }
}