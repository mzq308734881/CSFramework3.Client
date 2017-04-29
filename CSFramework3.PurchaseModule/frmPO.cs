using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Interfaces;
using CSFramework3.Business;
using CSFramework.BLL;
using System.Reflection;

namespace CSFramework3.PurchaseModule
{
    /// <summary>
    /// 采购订单
    /// by xiaoli 
    /// </summary>
    public partial class frmPO : frmBaseBusinessForm
    {
        public frmPO()
        {
            InitializeComponent();
        }

        private void frmPO_Load(object sender, EventArgs e)
        {
            InitializeForm(); //自定义方法:初始化窗体主方法
        }
        /// <summary>
        /// 初始化窗体///
        /// </summary>
        protected override void InitializeForm()
        {
            _BLL = new bllPO();// 业务逻辑管理类

            _SummaryView = new DevGridView(gvSummary);
            _ActiveEditor = txtPONo;
            _DetailGroupControl = panelControl3;

            base.InitializeForm();

            frmGridCustomize.RegisterGrid(gvSummary);
            DevStyle.SetGridControlLayout(gcSummary, false);//表格设置   
            DevStyle.SetGridControlLayout(gcDetail, true);//表格设置   
            DevStyle.SetSummaryGridViewLayout(gvSummary);
            DevStyle.SetDetailGridViewLayout(gvDetail);

            BindingSummaryNavigator(controlNavigatorSummary, gcSummary); //Summary导航条.
            BindingSummarySearchPanel(btnQuery, btnEmpty, gcFindGroup);

            gcDetail.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(this.OnEmbeddedNavigatorButtonClick); //表格按钮事件
            gvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(OnCellValueChanged); //表格值改变
            gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict

            txt_DocDateTo.DateTime = DateTime.Today; //查询条件

            DataBinder.BindingLookupEditDataSource(txtCreatedBy, DataDictCache.Cache.User, "UserName", "Account");
            DataBinder.BindingLookupEditDataSource(txtPayType, DataDictCache.Cache.PayType, "TypeName", "PayType");
            DataBinder.BindingLookupEditDataSource(txtAppUser, DataDictCache.Cache.User, "UserName", "Account");
            DataBinder.BindingLookupEditDataSource(txtPOUser, DataDictCache.Cache.Person, "SalesName", "SalesCode");
            DataBinder.BindingLookupEditDataSource(txtCurrency, DataDictCache.Cache.Currency, "CurrencyName", "Currency");

            (colD_ProductCode.ColumnEdit as RepositoryItemButtonEdit).ButtonClick += new ButtonPressedEventHandler(OnStockCode_ButtonClick);
            (colD_ProductCode.ColumnEdit as RepositoryItemButtonEdit).Validating += new CancelEventHandler(OnStockCode_Validating);

            _BLL.GetBusinessByKey("-", true);//加载一个空的业务对象.

            ShowSummaryPage(true); //一切初始化完毕后显示SummaryPage          
        }

        private void OnStockCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //打开产品查询窗体
            frmFuzzySearch.Execute(sender as ButtonEdit, this._BLL as IFuzzySearchSupportable, this.SearchStockCallBack);
        }

        private void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if ((e.Column == colD_Price) || (e.Column == colD_Quantity))
            {
                this.UpdateDetailAmount();
                this.UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            colD_Amount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum; //设置列为合计模式
            decimal amt = ConvertEx.ToDecimal(colD_Amount.SummaryItem.SummaryValue);
            this.SetEditorBindingValue(txtAmount, amt);
        }

        private void UpdateDetailAmount()
        {
            decimal price = ConvertEx.ToDecimal(gvDetail.GetDataRow(gvDetail.FocusedRowHandle)[tb_POs.Price]);
            decimal quantity = ConvertEx.ToDecimal(gvDetail.GetDataRow(gvDetail.FocusedRowHandle)[tb_POs.Quantity]);
            decimal amt = Math.Round(price * quantity, 2, MidpointRounding.ToEven);
            gvDetail.SetFocusedRowCellValue(colD_Amount, amt);//采购金额
            gvDetail.UpdateCurrentRow();
        }

        protected override bool DoSearchSummary()//查询功能
        {
            DataTable dt = (_BLL as bllPO).GetSummaryByParam(txt_DocNoFrom.Text, txt_DocNoTo.Text,
                txt_DocDateFrom.DateTime, txt_DocDateTo.DateTime, txt_StockCode.Text, txt_Supplier.Text);
            DoBindingSummaryGrid(dt); //绑定主表的Grid
            ShowSummaryPage(true); //显示Summary页面.                         
            return dt != null && dt.Rows.Count > 0;
        }

        protected override void SetDetailEditorsAccessable(Control gc, bool value)
        {
            base.SetDetailEditorsAccessable(gc, value);       //控制明细页面上的控件可被编辑.
            base.SetGridCustomButtonAccessable(gcDetail, value); /// 设置Grid自定义按钮(Add,Insert,Delete)状态
        }

        protected override void ButtonStateChanged(UpdateType currentState)// 按钮状态改变时触发的事件
        {
            //设置编辑明细页面的控件
            this.SetDetailEditorsAccessable(panelControl2, this.DataChanged);
            this.SetDetailEditorsAccessable(panelControl3, this.DataChanged);
            base.SetGridCustomButtonAccessable(gcDetail, this.DataChanged);

            txtPONo.Properties.ReadOnly = true;//修改状态允许修改单号
            txtAppDate.Enabled = false;
            txtAppUser.Enabled = false;

            this.SetEditorEnable(txtCustomerName, false, true);

        }

        protected override void DoBindingDetailGrid(DataSet dataSource)// 绑定单据的所有明细表. 
        {
            //绑定明细表. 
            gcDetail.DataSource = null;
            gcDetail.DataSource = dataSource.Tables[tb_POs.__TableName];

        }
        protected override void DoBindingSummaryEditor(DataTable dataSource)//绑定主表数据
        {
            if (dataSource == null) return;

            DataBinder.BindingTextEdit(txtOrderDate, dataSource, tb_PO.PODate);
            DataBinder.BindingTextEdit(txtPONo, dataSource, tb_PO.PONO);
            DataBinder.BindingTextEdit(txtCustomer, dataSource, tb_PO.CustomerCode);
            DataBinder.BindingTextEdit(txtCustomerName, dataSource, "CustomerName");
            DataBinder.BindingTextEdit(txtATTN, dataSource, tb_PO.CustomerContact);
            DataBinder.BindingTextEdit(txtTEL, dataSource, tb_PO.CustomerTel);
            DataBinder.BindingTextEdit(txtPayType, dataSource, tb_PO.PayType);
            DataBinder.BindingTextEdit(txtCurrency, dataSource, tb_PO.Currency);
            DataBinder.BindingTextEdit(txtCreatedBy, dataSource, tb_PO.CreatedBy);
            DataBinder.BindingTextEdit(txtCreationDate, dataSource, tb_PO.CreationDate);
            DataBinder.BindingTextEdit(txtAppUser, dataSource, tb_PO.AppUser);
            DataBinder.BindingTextEdit(txtPOUser, dataSource, tb_PO.POUser);
            DataBinder.BindingTextEdit(txtAppDate, dataSource, tb_PO.AppDate);
            DataBinder.BindingTextEdit(txtRemark, dataSource, tb_PO.Remark);
            DataBinder.BindingTextEdit(txtAmount, dataSource, tb_PO.Amount);
        }

        protected override void CreateOneDetail(GridView gridView, int buttonIndex)
        {
            //因需要取OrderID,Append状态下要将光标移到最后一行方可获取正确OrderID
            if (buttonIndex == DetailButtons.Add) gvDetail.MoveLast();
            if (gvDetail.RowCount == 0) buttonIndex = DetailButtons.Add;

            DataRow row = _BLL.CurrentBusiness.Tables[tb_POs.__TableName].NewRow();
            string order = new GenerateSortID().Generate(gvDetail, colD_Queue); //生成排序编号
            //   row[tb_POs.Queue] = order; //排序编号

            if (buttonIndex == DetailButtons.Add)//增加一条明细记录
            {
                _BLL.CurrentBusiness.Tables[tb_POs.__TableName].Rows.Add(row);
                gcDetail.RefreshDataSource();
                gvDetail.FocusedRowHandle = gvDetail.RowCount - 1;
            }
            else if (buttonIndex == DetailButtons.Insert)//插入一条明细记录
            {
                _BLL.CurrentBusiness.Tables[tb_POs.__TableName].Rows.InsertAt(row, gvDetail.FocusedRowHandle);
                gvDetail.FocusedRowHandle = gvDetail.FocusedRowHandle - 1;
            }
            gvDetail.FocusedColumn = gvDetail.VisibleColumns[0];
        }

        private bool ValidatingSummaryData(DataTable summary)
        {
            if (string.IsNullOrEmpty(ConvertEx.ToString(txtCustomer.EditValue)))
            {
                Msg.Warning("供货商不能为空!");
                txtCustomer.Focus();
                return false;
            }

            return true;
        }

        private void OnStockCode_Validating(object sender, CancelEventArgs e)
        {
            if (this.IsAddOrEditMode == false) return;
            if (string.IsNullOrEmpty((sender as ButtonEdit).Text)) return;

            string stockCode = (sender as ButtonEdit).Text.Trim();
            DataTable dt = new bllProduct().GetDataByKey(stockCode); //验证产品编号是否正确
            if (dt.Rows.Count > 0)
                this.SearchStockCallBack(dt.Rows[0]);
            else
            {
                e.Cancel = true;
                Msg.Warning("产品编号不存在！");
            }
        }

        /// <summary>
        /// 选择货品资料，设置当前货品相关栏位的资料
        /// </summary>        
        private void SearchStockCallBack(DataRow resultRow)
        {
            if (resultRow == null) return;

            int H = gvDetail.FocusedRowHandle;//当前记录号
            gvDetail.SetRowCellValue(H, colD_ProductCode, ConvertEx.ToString(resultRow[tb_Product.ProductCode]));//货品编码
            gvDetail.SetRowCellValue(H, colD_ProductName, ConvertEx.ToString(resultRow[tb_Product.ProductName]));//货品名称
            gvDetail.UpdateCurrentRow();
        }

        public override void DoSave(IButtonInfo sender)// 保存数据
        {
            this.UpdateLastControl();//更新最后一个输入框的数据
            this.UpdateTotalAmount(); //保存时更新主表金额

            if (!ValidatingSummaryData(_BLL.CurrentBusiness.Tables[tb_PO.__TableName])) return; //检查主表数据合法性
            if (!ValidatingDetailData(_BLL.CurrentBusiness.Tables[tb_POs.__TableName])) return; //检查从表数据合法性

            try
            {
                frmWaiting.ShowMe(this);
                if (_UpdateType == UpdateType.Modify) _BLL.WriteLog(); //注意:只有修改状态下保存修改日志

                DataSet dsTemplate = _BLL.CreateSaveData(_BLL.CurrentBusiness, _UpdateType); //创建用于保存的临时数据
                SaveResult result = _BLL.Save(dsTemplate);//调用业务逻辑保存数据方法

                if (result.Success) //保存成功, 不需要重新加载数据，更新当前的缓存数据就行．
                {
                    if (_UpdateType == UpdateType.Add) _BLL.DataBindRow[tb_PO.__KeyName] = result.DocNo; //更新单据号码
                    if (_UpdateType == UpdateType.Modify) _BLL.NotifyUser();//修改后短信或Email通知制单人
                    this.UpdateSummaryRow(_BLL.DataBindRow);//刷新表格内当前记录的缓存数据.
                    this.DoBindingSummaryEditor(_BLL.DataBinder); //重新显示数据
                    if (_UpdateType == UpdateType.Add) gvSummary.MoveLast(); //如是新增单据,移动到取后一条记录.
                    base.DoSave(sender); //调用基类的方法. 此行代码应放较后位置.                    
                    frmWaiting.HideMe(this);
                    Msg.ShowInformation("保存成功!");
                }
                else
                    Msg.Warning("保存失败!");
            }
            finally
            {
                frmWaiting.HideMe(this);
            }
        }

        public override void DoEdit(IButtonInfo sender)
        {
            base.DoEdit(sender);
        }

        private bool ValidatingDetailData(DataTable detail)
        {
            int i = 0;
            foreach (DataRow row in detail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (ConvertEx.ToString(row[tb_POs.ProductCode]) == string.Empty)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_ProductCode;
                    Msg.Warning("产品编号不能为空!");
                    return false;
                }
                i++;
            }
            return true;
        }

        public override void DoPrint(IButtonInfo button)
        {
            //string docNo = this.GetSummaryFieldValue(tb_PO.KeyName);
            //frmReportPO.Execute(docNo, docNo);
        }

        public override void DoShowModifyHistory(IButtonInfo button)//日志
        {
            this.AssertFocusedRow();
            Form form = MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmModifyLog));
            (form as frmModifyLog).ShowModifyLog(this.Name);
        }

        private void txtCustomer_OnSetResult(DataRow resultRow)
        {
            if ((this.IsAddOrEditMode) && (txtCustomer.Text != String.Empty))
            {
                if (resultRow != null)
                {
                    this.SetEditorBindingValue(txtCustomer, resultRow[tb_Customer.CustomerCode]);
                    this.SetEditorBindingValue(txtATTN, resultRow[tb_Customer.ContactPerson]);//自动加载供应商的联系人，电话
                    this.SetEditorBindingValue(txtTEL, resultRow[tb_Customer.Tel]);
                }
            }
        }

    }
}

