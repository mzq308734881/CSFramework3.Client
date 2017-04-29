using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using CSFramework.Library;
using CSFramework3.Business;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Interfaces;
using CSFramework3.Business.BLL_Base;

/************************************************************************************************************* 
 *  应收款示例说明
 *  
 *  应收款AR，包含对销售单(tb_SO)及它项(tb_AccountIDs)进行收款。理论上不能直接对销售单进行收款，
 *  实际上开了销售单财务会开销售发票，销售发票是对应销售单的，正常的逻辑是对销售发票进行收款，
 *  因框架内没有提供销售发票的业务窗体，所以AR直接对销售单进行收款。看似逻辑不同，但效果完全相同。
 * 
 *  它项(tb_AccountIDs)表定义了不同类型的收款项目，在AR的明细表可以直接输入编号进行收款。
 * 
 *  Outstanding/Balance 帐款结余 = 本单的金额 - 本单的已付金额(审核的AR单)
 * 
 ************************************************************************************************************* */

namespace CSFramework3.AccountModule
{

    /// <summary>
    /// 应收款界面
    /// </summary>
    public partial class frmAR : frmBaseBusinessForm
    {

        public frmAR()
        {
            InitializeComponent();
        }

        private void frmAR_Load(object sender, EventArgs e)
        {
            InitializeForm(); //自定义方法:初始化窗体主方法
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        protected override void InitializeForm()
        {
            _BLL = new bllAR();// 业务逻辑层实例
            _SummaryView = new DevGridView(gvSummary);
            _ActiveEditor = txtReceivedDate;
            _DetailGroupControl = panel1;

            base.InitializeForm(); //这行代码放到初始化变量后最好

            frmGridCustomize.RegisterGrid(gvSummary);
            DevStyle.SetGridControlLayout(gcSummary, false);//表格设置   
            DevStyle.SetGridControlLayout(gcDetail, true);//表格设置   
            DevStyle.SetSummaryGridViewLayout(gvSummary);
            DevStyle.SetDetailGridViewLayout(gvDetail);

            BindingSummaryNavigator(controlNavigatorSummary, gcSummary); //Summary导航条.
            BindingSummarySearchPanel(btnQuery, btnEmpty, gcFindGroup);

            gcDetail.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(this.OnEmbeddedNavigatorButtonClick); //表格按钮事件

            txt_DocDateTo.DateTime = DateTime.Today; //查询条件截止日期

            DataBinder.BindingLookupEditDataSource(txtCreatedBy, DataDictCache.Cache.User, TUser.UserName, TUser.Account);
            DataBinder.BindingLookupEditDataSource(txtChequeBank, DataDictCache.Cache.Bank, tb_CommonDataDict.NativeName, tb_CommonDataDict.DataCode);
            DataBinder.BindingLookupEditDataSource(txtAppUser, DataDictCache.Cache.User, TUser.UserName, TUser.Account);
            DataBinder.BindingLookupEditDataSource((colD_Currency.ColumnEdit as RepositoryItemLookUpEdit), DataDictCache.Cache.Currency, tb_Currency.CurrencyName, tb_Currency.Currency);

            (colD_InvoiceNo.ColumnEdit as RepositoryItemButtonEdit).ButtonClick += new ButtonPressedEventHandler(OnInvoiceNo_ButtonClick);
            (colD_InvoiceNo.ColumnEdit as RepositoryItemButtonEdit).Validating += new CancelEventHandler(OnInvoiceNo_Validating);

            _BLL.GetBusinessByKey("-", true);//加载一个空的业务对象.

            ShowSummaryPage(true); //一切初始化完毕后显示SummaryPage        
        }

        #region 明细表项目输入功能处理

        //明细表格项目输入/选择事件
        private void OnInvoiceNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow result = frmQueryOutstanding.Execute_SelectRow(ConvertEx.ToString(txtCustomer.EditValue), OutstandingType.AR);
            if (result != null) SearchInvoiceCallBack(result);
        }

        //明细表格项目输入框校验事件
        private void OnInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            if (this.IsAddOrEditMode == false) return;
            if (string.IsNullOrEmpty((sender as ButtonEdit).Text)) return;

            string invoiceNo = (sender as ButtonEdit).Text.Trim();

            //输入的号码是特殊会计编号，不需要检查
            DataRow accID = DocNoIsSpecAccId(invoiceNo);
            if (accID != null)
            {
                gvDetail.SetRowCellValue(gvDetail.FocusedRowHandle, colD_ItemName, accID[tb_AccountIDs.AccName]);//显示项目名称
                return;
            }

            //可能是单据号码
            DataTable dt = CommonData.SearchOutstanding(invoiceNo, "", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, "AR");

            if (dt.Rows.Count > 0)
                this.SearchInvoiceCallBack(dt.Rows[0]);
            else
            {
                e.Cancel = true;
                Msg.Warning("编号不存在或者该单据已结清！");
            }

        }

        /// <summary>
        /// 是否特殊会计编号
        /// </summary>
        /// <param name="invoiceNo">输入的号码</param>
        /// <returns></returns>
        private DataRow DocNoIsSpecAccId(string docNo)
        {            
            DataTable dt = new bllAccountIDs().GetDataByKey(docNo);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// 选择销售订单资料，设置当前产品相关信息
        /// </summary>        
        private void SearchInvoiceCallBack(DataRow resultRow)
        {
            if (resultRow == null) return;
            int H = gvDetail.FocusedRowHandle;
            gvDetail.SetRowCellValue(H, colD_ItemName, "业务单据");//显示项目名称
            gvDetail.SetRowCellValue(H, colD_Currency, ConvertEx.ToString(resultRow["Currency"]));
            gvDetail.SetRowCellValue(H, colD_InvoiceNo, ConvertEx.ToString(resultRow["DocNo"]));
            gvDetail.SetRowCellValue(H, colD_SONO, ConvertEx.ToString(resultRow["RefNo"]));
            gvDetail.SetRowCellValue(H, colD_Amount, ConvertEx.ToString(resultRow["Balance"]));
            gvDetail.UpdateCurrentRow();
        }

        #endregion

        protected override void SetSummaryRowZero(DataRow summaryRow)
        {
            summaryRow[tb_AR.Amount] = 0;
        }

        public override void DoSave(IButtonInfo sender)// 保存数据
        {
            this.UpdateLastControl();//更新最后一个输入框的数据

            if (!ValidatingSummaryData(_BLL.CurrentBusiness.Tables[tb_AR.__TableName])) return; //检查主表数据合法性
            if (!ValidatingDetailData(_BLL.CurrentBusiness.Tables[tb_ARs.__TableName])) return; //检查从表数据合法性

            if (_UpdateType == UpdateType.Modify) _BLL.WriteLog(); //注意:只有修改状态下保存修改日志

            DataSet dsTemplate = _BLL.CreateSaveData(_BLL.CurrentBusiness, _UpdateType); //创建用于保存的临时数据

            SaveResult result = _BLL.Save(dsTemplate);//调用业务逻辑保存数据方法

            if (result.Success) //保存成功, 不需要重新加载数据，更新当前的缓存数据就行．
            {
                if (_UpdateType == UpdateType.Add) _BLL.DataBindRow[tb_AR.__KeyName] = result.DocNo; //更新单据号码
                if (_UpdateType == UpdateType.Modify) _BLL.NotifyUser();//修改后短信或Email通知制单人

                this.UpdateSummaryRow(_BLL.DataBindRow);//刷新表格内当前记录的缓存数据.
                this.DoBindingSummaryEditor(_BLL.DataBinder); //重新显示数据
                if (_UpdateType == UpdateType.Add) gvSummary.MoveLast(); //如是新增单据,移动到取后一条记录.
                base.DoSave(sender); //调用基类的方法. 此行代码应放较后位置.                    
                Msg.ShowInformation("保存成功!");
            }
            else
                Msg.Warning("保存失败!");
        }

        protected override void ButtonStateChanged(UpdateType currentState)// 按钮状态改变时触发的事件
        {
            //设置编辑明细页面的控件
            this.SetDetailEditorsAccessable(panelDetailPage, this.DataChanged);
            this.SetDetailEditorsAccessable(panelControl2, this.DataChanged);

            txtARNO.Enabled = false;
            txtAppDate.Enabled = false;
            txtAppUser.Enabled = false;
            txtCurrency.Enabled = false;
            lblStatus.Text = this.UpdateTypeName;

            this.SetEditorEnable(txtCustomerName, false, true);//禁用客户名称

            base.SetGridCustomButtonAccessable(gcDetail, this.DataChanged);
        }

        protected override void DoBindingSummaryEditor(DataTable dataSource)
        {
            if (dataSource == null) return;

            DataBinder.BindingTextEdit(txtARNO, dataSource, tb_AR.ARNO);
            DataBinder.BindingTextEdit(txtCreatedBy, dataSource, tb_AR.CreatedBy);
            DataBinder.BindingTextEdit(txtCreationDate, dataSource, tb_AR.CreationDate);
            DataBinder.BindingTextEdit(txtCurrency, dataSource, tb_AR.Currency);
            DataBinder.BindingTextEdit(txtRemark, dataSource, tb_AR.Remark);
            DataBinder.BindingTextEdit(txtAmount, dataSource, tb_AR.Amount);
            DataBinder.BindingTextEdit(txtCustomer, dataSource, tb_AR.CustomerCode);
            DataBinder.BindingTextEdit(txtCustomerName, dataSource, tb_AR.CustomerName);
            DataBinder.BindingTextEdit(txtChequeNo, dataSource, tb_AR.ChequeNo);
            DataBinder.BindingTextEdit(txtReceivedDate, dataSource, tb_AR.ReceivedDate);
            DataBinder.BindingTextEdit(txtChequeBank, dataSource, tb_AR.ChequeBank);
            DataBinder.BindingTextEdit(txtAppDate, dataSource, tb_AR.AppDate);
            DataBinder.BindingTextEdit(txtAppUser, dataSource, tb_AR.AppUser);
        }

        protected override void CreateOneDetail(GridView gridView, int buttonIndex)
        {
            //因需要取OrderID,Append状态下要将光标移到最后一行方可获取正确OrderID
            if (buttonIndex == DetailButtons.Add) gvDetail.MoveLast();
            if (gvDetail.RowCount == 0) buttonIndex = DetailButtons.Add;

            DataRow row = _BLL.CurrentBusiness.Tables[tb_ARs.__TableName].NewRow();
            string order = new GenerateSortID().Generate(gvDetail, colD_Queue); //生成排序编号
            row[tb_ARs.Queue] = order; //排序编号
            row[tb_ARs.Currency] = Globals.DEF_CURRENCY; //预设货币
            if (buttonIndex == DetailButtons.Add)
            {
                _BLL.CurrentBusiness.Tables[tb_ARs.__TableName].Rows.Add(row); //增加一条明细记录

                gcDetail.RefreshDataSource();
                gvDetail.FocusedRowHandle = gvDetail.RowCount - 1;
            }
            else if (buttonIndex == DetailButtons.Insert)
            {
                //插入一条明细记录

                _BLL.CurrentBusiness.Tables[tb_ARs.__TableName].Rows.InsertAt(row, gvDetail.FocusedRowHandle);
                gvDetail.FocusedRowHandle = gvDetail.FocusedRowHandle - 1;
            }
            gvDetail.FocusedColumn = gvDetail.VisibleColumns[0];
        }

        #region 主从表数据输入合法性检查

        private bool ValidatingSummaryData(DataTable summary)
        {
            if (string.IsNullOrEmpty(ConvertEx.ToString(txtCustomer.EditValue)))
            {
                Msg.Warning("客户不能为空!");
                txtCustomer.Focus();
                return false;
            }

            return true;
        }

        private bool ValidatingDetailData(DataTable detail)
        {
            int i = 0;
            string docNo;

            foreach (DataRow row in detail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                docNo = ConvertEx.ToString(row[tb_ARs.InvoiceNo]);

                if (docNo == string.Empty)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_InvoiceNo;
                    Msg.Warning("收款项目不能为空!");
                    return false;
                }

                i++;
            }

            decimal detailAmount = ConvertEx.ToDecimal(colD_Amount.SummaryItem.SummaryValue);
            decimal masterSAmount = ConvertEx.ToDecimal(txtAmount.EditValue);

            if (detailAmount != masterSAmount)
            {
                Msg.Warning("收款金额与明细表的金额帐目不平!");
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        #endregion

        protected override bool DoSearchSummary()
        {
            DataTable dt = (_BLL as bllAR).GetSummaryByParam(txt_DocNoFrom.Text, txt_DocNoTo.Text, txt_DocDateFrom.DateTime, txt_DocDateTo.DateTime);
            DoBindingSummaryGrid(dt); //绑定主表的Grid
            ShowSummaryPage(true); //显示Summary页面.                         
            return dt != null && dt.Rows.Count > 0;
        }

        protected override void DoBindingDetailGrid(DataSet dataSource)// 绑定单据的所有明细表. 
        {
            //绑定明细表. 
            gcDetail.DataSource = null;
            gcDetail.DataSource = dataSource.Tables[tb_ARs.__TableName];
        }

        public override void DoPrint(IButtonInfo button)
        {
            string docNo = this.GetSummaryFieldValue(tb_AR.__KeyName);

            //FastReport DEMO
            CSFramework3.ReportsFastReport.frmReportAR.Execute(docNo, docNo);
        }

    }
}
