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
 *   程序说明: Product的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-23 10:58:32
 *   最后修改: 2011-03-23 10:58:32
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Business
{
    public class bllProduct : bllBaseDataDict
    {
        private IBridge_Product _MyBridge = null;

        public bllProduct()
        {
            _KeyFieldName = tb_Product.__KeyName; //主键字段
            _SummaryTableName = tb_Product.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_Product));
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

        public DataTable FuzzySearch(string content)
        {
            return _MyBridge.FuzzySearch(content);
        }
    }
}
