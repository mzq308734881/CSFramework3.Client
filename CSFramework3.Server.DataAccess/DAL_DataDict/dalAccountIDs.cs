using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework.ORM;
using CSFramework3.Interfaces;
using CSFramework3.Server.DataAccess.DAL_Base;

namespace CSFramework3.Server.DataAccess.DAL_DataDict
{
    [DefaultORM_UpdateMode(typeof(tb_AccountIDs), true)]
    public class dalAccountIDs : dalBaseDataDict
    {
        public dalAccountIDs(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_AccountIDs.__KeyName; //主键字段
            _TableName = tb_AccountIDs.__TableName;//表名
            _ModelType = typeof(tb_AccountIDs);
        }
    }
}
