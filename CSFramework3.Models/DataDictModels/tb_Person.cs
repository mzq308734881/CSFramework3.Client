using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.ORM;


/*==========================================
 *   程序说明: tb_Person的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2011-04-05 01:50:09
 *   最后修改: 2011-04-05 01:50:09
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

namespace CSFramework3.Models
{
    ///<summary>
    /// ORM模型, 数据表:tb_Person,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("tb_Person", "SalesCode", true)]
    public sealed class tb_Person
    {
        #region 所有字段的局部变量定义
        private int F_ISID;
        private string F_SalesCode;
        private string F_SalesName;
        private string F_Department;
        private string F_InUse;
        private DateTime F_CreationDate;
        private string F_CreatedBy;
        private DateTime F_LastUpdateDate;
        private string F_LastUpdatedBy;
        #endregion

        public static string __TableName = "tb_Person";
        public static string __KeyName = "SalesCode";

        #region 所有字段名常量
        public const string _ISID = "ISID";
        public const string _SalesCode = "SalesCode";
        public const string _SalesName = "SalesName";
        public const string _Department = "Department";
        public const string _InUse = "InUse";
        public const string _CreationDate = "CreationDate";
        public const string _CreatedBy = "CreatedBy";
        public const string _LastUpdateDate = "LastUpdateDate";
        public const string _LastUpdatedBy = "LastUpdatedBy";
        #endregion

        #region 所有字段属性

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public int ISID { get { return F_ISID; } set { F_ISID = value; } }

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, true, false, false)]
        public string SalesCode { get { return F_SalesCode; } set { F_SalesCode = value; } }

        [ORM_FieldAttribute(SqlDbType.NVarChar, 40, false, true, false, false, false)]
        public string SalesName { get { return F_SalesName; } set { F_SalesName = value; } }

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public string Department { get { return F_Department; } set { F_Department = value; } }

        [ORM_FieldAttribute(SqlDbType.Char, 1, false, true, false, false, false)]
        public string InUse { get { return F_InUse; } set { F_InUse = value; } }

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public DateTime CreationDate { get { return F_CreationDate; } set { F_CreationDate = value; } }

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public string CreatedBy { get { return F_CreatedBy; } set { F_CreatedBy = value; } }

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public DateTime LastUpdateDate { get { return F_LastUpdateDate; } set { F_LastUpdateDate = value; } }

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, true, false, false, false)]
        public string LastUpdatedBy { get { return F_LastUpdatedBy; } set { F_LastUpdatedBy = value; } }

        #endregion
    }
}