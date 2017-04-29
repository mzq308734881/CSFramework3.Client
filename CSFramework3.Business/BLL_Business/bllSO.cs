using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework.Core.Log;
using CSFramework.Core;

using CSFramework3.Bridge.SalesModule;
using CSFramework3.Bridge;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Business.BLL_Business;

/************************************************************************* 
 * 程序说明: 
 * 销售订单业务逻辑 作者：孙中吕
 **************************************************************************/
namespace CSFramework3.Business
{
    /// <summary>
    /// 销售订单的业务逻辑层
    /// </summary>
    public class bllSO : bllBaseBusiness, IFuzzySearchSupportable
    {
        private IBridge_SO _Bridge = null;

        public bllSO()
        {
            _KeyFieldName = tb_SO.__KeyName;
            _SummaryTableName = tb_SO.__TableName;
            _Bridge = this.CreateBridge();//实例化桥接功能
        }

        private IBridge_SO CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SO().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_SO();

            return null;
        }

        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = _Bridge.GetBusinessByKey(keyValue); //獲取單據數據
            this.SetNumericDefaultValue(ds); //設置預設值
            if (resetCurrent) _CurrentBusiness = ds; //保存當前對象引用
            return ds;
        }

        public override bool Delete(string keyValue)
        {
            return _Bridge.Delete(keyValue);
        }

        public bool CheckNoExists(string keyValue)
        {
            return _Bridge.CheckNoExists(keyValue);
        }

        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[tb_SO.__TableName];
            DataRow row = summaryTable.Rows.Add();
            row[tb_SO.ReceiveDay] = DateTime.Today;
            row[tb_SO.SONO] = "*自动生成*";
            row[tb_SO.VerNo] = "01";
            row[tb_SO.CreatedBy] = Loginer.CurrentUser.Account;
            row[tb_SO.CreationDate] = DateTime.Now;
            row[tb_SO.LastUpdatedBy] = Loginer.CurrentUser.Account;
            row[tb_SO.LastUpdateDate] = DateTime.Now;
        }

        public override void ApprovalBusiness(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            summaryRow[BusinessCommonFields.FlagApp] = "Y";

            string key = ConvertEx.ToString(summaryRow[tb_SO.SONO]);
            _Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            this.UpdateSummaryRowState(this.DataBindRow, currentType);

            //创建用于保存的临时数据,里面包含主表数据
            DataSet save = this.DoCreateTempData(currentBusiness, tb_SO.__TableName);
            DataTable summary = save.Tables[0];
            summary.Rows[0][BusinessCommonFields.LastUpdateDate] = DateTime.Now;
            summary.Rows[0][BusinessCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;

            DataTable detail = currentBusiness.Tables[tb_SOs.__TableName].Copy();
            this.UpdateDetailCommonValue(detail); //更新明细表的公共字段数据
            save.Tables.Add(detail); //加入明细数据 

            return save;
        }

        public override SaveResult Save(DataSet saveData)
        {
            return _Bridge.Update(saveData); //交给数据层处理          
        }

        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            return _Bridge.GetSummaryByParam(
                Globals.RemoveInjection(docNoFrom, 20),
                Globals.RemoveInjection(docNoTo, 20), docDateFrom, docDateTo);
        }

        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return _Bridge.GetReportData(DocNoFrom, DocNoTo, DateFrom, DateTo);
        }

        public override void WriteLog()
        {
            string key = this.DataBinder.Rows[0][tb_SO.SONO].ToString();//取单据号码
            DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.
            DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据
            this.WriteLog(dsOriginal, dsTemplate);//保存日志                                
        }

        public override void WriteLog(DataTable original, DataTable changes) { }

        public override void WriteLog(DataSet original, DataSet changes)
        {  //单独处理,即使错误,不向外抛出异常

            try
            {
                string logID = Guid.NewGuid().ToString().Replace("-", ""); //本次日志ID

                IBridge_EditLogHistory logBridge = bllBusinessLog.CreateEditLogHistoryBridge();

                logBridge.WriteLog(logID, original.Tables[0], changes.Tables[0], tb_SO.__TableName, tb_SO.__KeyName, true); //主表
                logBridge.WriteLog(logID, original.Tables[1], changes.Tables[1], tb_SOs.__TableName, tb_SOs.__KeyName, false);//明细
            }
            catch
            {
                Msg.Warning("写入日志发生错误！");
            }
        }


        #region IFuzzySearchSupportable Members

        public string FuzzySearchName
        {
            get { return "搜索产品资料"; }
        }

        public DataTable FuzzySearch(string content)
        {
            bllProduct bll = new bllProduct();
            return bll.FuzzySearch(content);
        }

        #endregion
    }
}
