using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework.Core.Log;
using CSFramework.Core;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Interfaces;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Bridge;
using CSFramework3.Bridge.SalesModule;
using CSFramework3.Business.BLL_Business;

/*==========================================
 *   程序说明: PO的业务逻辑层
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2011-05-07 07:08:19
 *   最后修改: 2011-05-07 07:08:19
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.csframework.com
 *==========================================*/

namespace CSFramework3.Business
{
    /// <summary>
    /// bllPO
    /// </summary>
    public class bllPO : bllBaseBusiness, IFuzzySearchSupportable
    {
        private IBridge_PO _Bridge = null;

        /// <summary>
        /// 构造器
        /// </summary>
        public bllPO()
        {
            _KeyFieldName = tb_PO.__KeyName; //主键字段
            _SummaryTableName = tb_PO.__TableName;//表名         
            _Bridge = this.CreateBridge();//实例化桥接功能
        }

        private IBridge_PO CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_PO().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_PO();

            return null;
        }

        /// <summary>
        ///根据单据号码取业务数据
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = _Bridge.GetBusinessByKey(keyValue); //獲取單據數據            
            this.SetNumericDefaultValue(ds); //设置预设值
            if (resetCurrent) _CurrentBusiness = ds; //保存当前业务数据的对象引用
            return ds;
        }

        /// <summary>
        ///删除单据
        /// </summary>
        public override bool Delete(string keyValue)
        {
            return _Bridge.Delete(keyValue);
        }

        /// <summary>
        ///检查单号是否存在
        /// </summary>
        public bool CheckNoExists(string keyValue)
        {
            return _Bridge.CheckNoExists(keyValue);
        }

        /// <summary>
        ///保存数据
        /// </summary>
        public override SaveResult Save(DataSet saveData)
        {
            return _Bridge.Update(saveData); //交给数据层处理
        }

        /// <summary>
        ///审核单据
        /// </summary>
        public override void ApprovalBusiness(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            summaryRow[BusinessCommonFields.FlagApp] = "Y";
            string key = ConvertEx.ToString(summaryRow[tb_PO.__KeyName]);
            _Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///新增一张业务单据
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[tb_PO.__TableName];
            DataRow row = summaryTable.Rows.Add();
            row[tb_PO.PONO] = "*自动生成*";
            row[tb_PO.PODate] = DateTime.Now;
            row[tb_PO.POUser] = Loginer.CurrentUser.Account;
            row[tb_PO.FlagApp] = "N";
            row[tb_PO.CreatedBy] = Loginer.CurrentUser.Account;
            row[tb_PO.CreationDate] = DateTime.Now;
            row[tb_PO.LastUpdatedBy] = Loginer.CurrentUser.Account;
            row[tb_PO.LastUpdateDate] = DateTime.Now;
        }

        /// <summary>
        ///创建用于保存的临时数据
        /// </summary>
        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            this.UpdateSummaryRowState(this.DataBindRow, currentType);

            //创建用于保存的临时数据,里面包含主表数据
            DataSet save = this.DoCreateTempData(currentBusiness, tb_PO.__TableName);
            DataTable summary = save.Tables[0];
            summary.Rows[0][BusinessCommonFields.LastUpdateDate] = DateTime.Now;
            summary.Rows[0][BusinessCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;

            DataTable detail = currentBusiness.Tables[tb_POs.__TableName].Copy();
            this.UpdateDetailCommonValue(detail); //更新明细表的公共字段数据
            save.Tables.Add(detail); //加入明细数据 

            //附件独立保存
            //if (currentBusiness.Tables[tb_AttachFile.TableName] != null)
            //{
            //    DataTable attach = currentBusiness.Tables[tb_AttachFile.TableName].Copy();
            //    save.Tables.Add(attach); //加入附件管理数据
            //}

            return save;
        }

        //查询数据
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer)
        {
            DataSet ds = _Bridge.GetSummaryByParam(
            Globals.RemoveInjection(docNoFrom, 20),
            Globals.RemoveInjection(docNoTo, 20),
            docDateFrom, docDateTo,
            Globals.RemoveInjection(StockCode, 20),
            Globals.RemoveInjection(Customer, 20));
            return ds.Tables[0];
        }

        /// <summary>
        ///获取报表数据
        /// </summary>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }

        #region Business Log

        /// <summary>
        /// 写入日志
        /// </summary>
        public override void WriteLog()
        {
            string key = this.DataBinder.Rows[0][tb_PO.__KeyName].ToString();//取单据号码
            DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.
            DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据
            this.WriteLog(dsOriginal, dsTemplate);//保存日志      
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="changes">修改后的数据</param>
        public override void WriteLog(DataTable original, DataTable changes) { }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="changes">修改后的数据</param>
        public override void WriteLog(DataSet original, DataSet changes)
        {  //单独处理,即使错误,不向外抛出异常
            try
            {
                string logID = Guid.NewGuid().ToString().Replace("-", ""); //本次日志ID
                IBridge_EditLogHistory logBridge = bllBusinessLog.CreateEditLogHistoryBridge();
                logBridge.WriteLog(logID, original.Tables[0], changes.Tables[0], tb_PO.__TableName, tb_PO.__KeyName, true); //主表
                //明细表的修改日志,系统不支持自动生成,请手工调整代码
                //SystemLog.WriteLog(logID, original.Tables[1], changes.Tables[1], tb_PO.__TableName, tb_PO.__KeyName, false);
            }
            catch
            {
                Msg.Warning("写入日志发生错误！");
            }

        }

        #endregion

        #region IFuzzySearchSupportable 成员

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
