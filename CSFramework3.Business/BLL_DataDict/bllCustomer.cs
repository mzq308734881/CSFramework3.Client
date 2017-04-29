using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework3.Models;
using CSFramework.Common;

using CSFramework3.Bridge;
using CSFramework3.Interfaces;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Bridge.DataDictModule;

/*==========================================
 *   程序说明: Customer的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:12:05
 *   最后修改: 2011-03-24 03:12:05
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace CSFramework3.Business
{
    /// <summary>
    /// 客户资料管理业务逻辑层
    /// </summary>
    public class bllCustomer : bllBaseDataDict
    {
        private IBridge_Customer _MyBridge; //桥接/策略接口

        public bllCustomer()
        {
            _KeyFieldName = tb_Customer.__KeyName; //主键字段
            _SummaryTableName = tb_Customer.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_Customer));
            _MyBridge = this.CreateBridge();
        }

        /// <summary>
        /// 创建桥接通信通道
        /// </summary>
        /// <returns></returns>
        private IBridge_Customer CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_Customer().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_Customer();

            return null;
        }

        public DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name,
            string Attribute, bool resetCurrent)
        {
            DataTable data = _MyBridge.SearchBy(CustomerFrom, CustomerTo, Name, Attribute);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        public DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode)
        {
            return _MyBridge.GetCustomerByAttributeCodes(attributeCodes, nameWithCode);
        }

        public DataTable FuzzySearch(string content)
        {
            return _MyBridge.FuzzySearch(content);
        }

        public DataTable FuzzySearch(string attributeCodes, string content)
        {
            return _MyBridge.FuzzySearch(attributeCodes, content);
        }
    }
}
