using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.Common;
using CSFramework3.Models;

using CSFramework3.Bridge;
using CSFramework3.Interfaces;
using CSFramework3.Bridge.DataDictModule;
using CSFramework3.Business.BLL_Base;

/*==========================================
 *   程序说明: AccountIDs的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-23 10:58:32
 *   最后修改: 2011-03-23 10:58:32
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Business
{
    public class bllAccountIDs : bllBaseDataDict
    {
        private IBridge_Product _MyBridge = null;

        public bllAccountIDs()
        {
            _KeyFieldName = tb_AccountIDs.__KeyName; //主键字段
            _SummaryTableName = tb_AccountIDs.__TableName;//表名
            _WriteDataLog = false;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_AccountIDs));
            _MyBridge = this.CreateBridge();
        }

        private IBridge_Product CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_Product().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_Product();

            return null;
        }

    }
}
