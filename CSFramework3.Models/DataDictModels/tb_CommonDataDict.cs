using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

/*==========================================
 *   程序说明: tb_CommonDataDict的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:08:45
 *   最后修改: 2011-03-24 03:08:45
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Models
{
    [ORM_ObjectClassAttribute("tb_CommonDataDict", "DataCode", true)]
    public class tb_CommonDataDict
    {
        public static string __TableName = "tb_CommonDataDict";

        public static string __KeyName = "DataCode";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string ISID = "ISID"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string DataType = "DataType"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,false)]
        public static string DataCode = "DataCode"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,200,false,true,false,false,false)]
        public static string NativeName = "NativeName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string EnglishName = "EnglishName"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string CreationDate = "CreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string CreatedBy = "CreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string LastUpdateDate = "LastUpdateDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string LastUpdatedBy = "LastUpdatedBy"; 

    }
}