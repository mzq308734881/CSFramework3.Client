using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;

namespace CSFramework3.Models
{


/*==========================================
 *   程序说明: tb_DataSet的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2011-04-17 12:37:46
 *   最后修改: 2011-04-17 12:37:46
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:tb_DataSet,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_DataSet", "DataSetID", true)]
    public sealed class tb_DataSet
    {
        public static string __TableName ="tb_DataSet";

        public static string __KeyName = "DataSetID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,false,false,false,false)]
        public static string isid = "isid"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,true,false,false)]
        public static string DataSetID = "DataSetID"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,40,false,true,false,false,false)]
        public static string DataSetName = "DataSetName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string ServerIP = "ServerIP"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,250,false,true,false,false,false)]
        public static string DBName = "DBName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string DBUserName = "DBUserName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string DBUserPassword = "DBUserPassword"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,500,false,true,false,false,false)]
        public static string Remark = "Remark"; 

    }
}