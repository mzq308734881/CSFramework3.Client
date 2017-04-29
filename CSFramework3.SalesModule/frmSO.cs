
///*************************************************************************/
///*
///* 文件名    ：frmSO.cs   
///* 程序说明  : 销售订单窗体完整版，实现全部功能
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

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
using CSFramework3.Business;
using CSFramework3.Models;
using CSFramework.Core;
using CSFramework.Common;
using CSFramework.Library;
using CSFramework3.Interfaces;

namespace CSFramework3.SalesModule
{
    /// <summary>
    /// 销售订单窗体完整版，实现全部功能
    /// 版权：C/S框架网 www.csframework.com
    /// </summary>
    public partial class frmSO : CSFramework.Library.frmBaseBusinessForm
    {
        public frmSO()
        {
            InitializeComponent();
        }

        private void frmSO_Load(object sender, EventArgs e)
        {
            this.InitializeForm(); //初始化主窗体                      
        }

        /// <summary>
        /// 初始化窗体///
        /// </summary>
        protected override void InitializeForm()
        {
            _BLL = new bllSO();// 业务逻辑管理类
            _SummaryView = new DevGridView(gvSummary);
            _ActiveEditor = txtSONO;
            _DetailGroupControl = panelControl1;

            base.InitializeForm(); //这行代码放到初始化变量后最好

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
            ucAttachment1.StorateStrategy = new AttachmentStorage_SQL(); //附件存储策略
            ucAttachment1.ImmediatelyPost = false;

            DataBinder.BindingLookupEditDataSource(txtCreatedBy, DataDictCache.Cache.User, "UserName", "Account");
            DataBinder.BindingLookupEditDataSource(txtAppUser, DataDictCache.Cache.User, "UserName", "Account");
            DataBinder.BindingLookupEditDataSource(txtSalesman, DataDictCache.Cache.Person, "SalesName", "SalesCode");
            DataBinder.BindingLookupEditDataSource(txtPayType, DataDictCache.Cache.PayType, "TypeName", "PayType");
            DataBinder.BindingLookupEditDataSource(txtCurrency, DataDictCache.Cache.Currency, "CurrencyName", "Currency");

            (colD_StockCode.ColumnEdit as RepositoryItemButtonEdit).ButtonClick += new ButtonPressedEventHandler(OnStockCode_ButtonClick);
            (colD_StockCode.ColumnEdit as RepositoryItemButtonEdit).Validating += new CancelEventHandler(OnStockCode_Validating);

            _BLL.GetBusinessByKey("-", true);//加载一个空的业务对象.

            ShowSummaryPage(true); //一切初始化完毕后显示SummaryPage        
        }

        private void OnStockCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {//打开产品查询窗体
            frmFuzzySearch.Execute(sender as ButtonEdit, this._BLL as IFuzzySearchSupportable, this.SearchStockCallBack);
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
        /// 选择产品资料，设置当前产品相关信息
        /// </summary>        
        private void SearchStockCallBack(DataRow resultRow)
        {
            if (resultRow == null) return;
            int H = gvDetail.FocusedRowHandle;

            gvDetail.SetRowCellValue(H, colD_StockCode, ConvertEx.ToString(resultRow[tb_Product.ProductCode]));
            gvDetail.SetRowCellValue(H, colD_StockName, ConvertEx.ToString(resultRow[tb_Product.ProductName]));
            gvDetail.SetRowCellValue(H, colD_Price, ConvertEx.ToString(resultRow[tb_Product.SellPrice]));
            gvDetail.SetRowCellValue(H, colD_Qty, 1);
            gvDetail.UpdateCurrentRow();
        }

        private void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //只要单价和数量栏位改动重新计算金额
            if ((e.Column == colD_Price) || (e.Column == colD_Qty))
            {
                this.UpdateDetailAmount();//重新计算金额
                this.UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {//更新金额合计
            decimal amt = ConvertEx.ToDecimal(colD_Amount.SummaryItem.SummaryValue);
            this.SetEditorBindingValue(txtAmount, amt);
        }

        /// <summary>
        /// 更新明细记录的总金额
        /// </summary>
        private void UpdateDetailAmount()
        {
            decimal price = ConvertEx.ToDecimal(gvDetail.GetDataRow(gvDetail.FocusedRowHandle)[tb_SOs.Price]);
            decimal qty = ConvertEx.ToDecimal(gvDetail.GetDataRow(gvDetail.FocusedRowHandle)[tb_SOs.Qty]);

            decimal amt = Math.Round(price * qty, 2, MidpointRounding.ToEven); //四舍五入
            gvDetail.SetFocusedRowCellValue(colD_Amount, amt);
            gvDetail.UpdateCurrentRow();
        }

        protected override void SetSummaryRowZero(DataRow summaryRow)
        {
            summaryRow[tb_SO.Amount] = 0;
        }

        public override void DoSave(IButtonInfo sender)// 保存数据
        {
            this.UpdateLastControl();//更新最后一个输入框的数据
            this.UpdateTotalAmount(); //保存时更新主表金额

            if (!ValidatingSummaryData(_BLL.CurrentBusiness.Tables[tb_SO.__TableName])) return; //检查主表数据合法性
            if (!ValidatingDetailData(_BLL.CurrentBusiness.Tables[tb_SOs.__TableName])) return; //检查从表数据合法性

            //注意:只有修改状态下保存修改日志
            if (_UpdateType == UpdateType.Modify) _BLL.WriteLog();

            //创建用于保存的临时数据
            DataSet dsTemplate = _BLL.CreateSaveData(_BLL.CurrentBusiness, _UpdateType);
            SaveResult result = _BLL.Save(dsTemplate);//调用业务逻辑保存数据方法

            if (result.Success) //保存成功, 不需要重新加载数据，更新当前的缓存数据就行．
            {
                this.PostAttachFiles(ucAttachment1.StorateStrategy.AttachmentStorage, result.DocNo); //保存附件

                if (_UpdateType == UpdateType.Add) _BLL.DataBindRow[tb_SO.__KeyName] = result.DocNo; //更新单据号码
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

        public override void DoShowModifyHistory(IButtonInfo button) //显示修改历史记录
        {
            this.AssertFocusedRow();
            Form form = MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmModifyLog));
            (form as frmModifyLog).ShowModifyLog(this.Name);
        }

        protected override void ButtonStateChanged(UpdateType currentState)// 按钮状态改变时触发的事件
        {
            //设置编辑明细页面的控件
            this.SetDetailEditorsAccessable(panelDetailPage, this.DataChanged);
            base.SetGridCustomButtonAccessable(gcDetail, this.DataChanged);
            this.SetEditorEnable(txtCustomerName, false, true);
            txtSONO.Properties.ReadOnly = true;//修改状态允许修改单号            
            txtAppDate.Enabled = false;
            txtAppUser.Enabled = false;
            txtAmount.Enabled = false;

            ucAttachment1.DoSetButtonState(currentState);
        }

        public override bool ButtonAuthorized(int authorityValue) //检查按钮权限,在这里可以定义隐藏某些按钮
        {
            if (authorityValue == ButtonAuthority.VOID) //隐藏作废按钮
                return false;
            return base.ButtonAuthorized(authorityValue);
        }

        protected override void SetDetailEditorsAccessable(Control panel, bool value)
        {
            base.SetDetailEditorsAccessable(panel, value);
            base.SetGridCustomButtonAccessable(gcDetail, value);
        }

        protected override void DoBindingSummaryEditor(DataTable dataSource)
        {
            if (dataSource == null) return;

            DataBinder.BindingTextEdit(txtReceiveDay, dataSource, tb_SO.ReceiveDay);
            DataBinder.BindingTextEdit(txtAmount, dataSource, tb_SO.Amount);
            DataBinder.BindingTextEdit(txtAppDate, dataSource, tb_SO.AppDate);
            DataBinder.BindingTextEdit(txtAppUser, dataSource, tb_SO.AppUser);
            DataBinder.BindingTextEdit(txtCreatedBy, dataSource, tb_SO.CreatedBy);
            DataBinder.BindingTextEdit(txtCreationDate, dataSource, tb_SO.CreationDate);
            DataBinder.BindingTextEdit(txtCurrency, dataSource, tb_SO.Currency);
            DataBinder.BindingTextEdit(txtCustomer, dataSource, tb_SO.CustomerCode);
            DataBinder.BindingTextEdit(txtCustomerName, dataSource, tb_SO.CustomerNativeName);
            DataBinder.BindingTextEdit(txtCustomerOrderNo, dataSource, tb_SO.CustomerOrderNo);
            DataBinder.BindingTextEdit(txtSONO, dataSource, tb_SO.SONO);
            DataBinder.BindingTextEdit(txtPayType, dataSource, tb_SO.PayType);
            DataBinder.BindingTextEdit(txtReceiveDay, dataSource, tb_SO.ReceiveDay);
            DataBinder.BindingTextEdit(txtRemark, dataSource, tb_SO.Remark);
            DataBinder.BindingTextEdit(txtSalesman, dataSource, tb_SO.Salesman);
        }

        protected override void CreateOneDetail(GridView gridView, int buttonIndex)
        {
            //因需要取OrderID,Append状态下要将光标移到最后一行方可获取正确OrderID
            if (buttonIndex == DetailButtons.Add) gvDetail.MoveLast();
            if (gvDetail.RowCount == 0) buttonIndex = DetailButtons.Add;

            DataRow row = _BLL.CurrentBusiness.Tables[tb_SOs.__TableName].NewRow();
            string order = new GenerateSortID().Generate(gvDetail, colD_Queue); //生成排序编号
            row[tb_SOs.Queue] = order; //排序编号

            if (buttonIndex == DetailButtons.Add)
            {
                _BLL.CurrentBusiness.Tables[tb_SOs.__TableName].Rows.Add(row); //增加一条明细记录
                gcDetail.RefreshDataSource();
                gvDetail.FocusedRowHandle = gvDetail.RowCount - 1;
            }
            else if (buttonIndex == DetailButtons.Insert)
            {
                //插入一条明细记录
                _BLL.CurrentBusiness.Tables[tb_SOs.__TableName].Rows.InsertAt(row, gvDetail.FocusedRowHandle);
                gvDetail.FocusedRowHandle = gvDetail.FocusedRowHandle - 1;
            }
            gvDetail.FocusedColumn = gvDetail.VisibleColumns[0];
        }

        /// <summary>
        /// 主表数据输入完整性检查
        /// </summary>
        /// <param name="summary">主表数据</param>
        /// <returns></returns>
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

        /// <summary>
        /// 明细表数据完整性检查
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private bool ValidatingDetailData(DataTable detail)
        {
            int i = 0;

            foreach (DataRow row in detail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (ConvertEx.ToString(row[tb_SOs.StockCode]) == string.Empty)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_StockCode;
                    Msg.Warning("产品编号不能为空!");
                    return false;
                }

                i++;
            }
            return true;
        }

        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <returns></returns>
        protected override bool DoSearchSummary()
        {
            DataTable dt = (_BLL as bllSO).GetSummaryByParam(txt_DocNoFrom.Text, txt_DocNoTo.Text, txt_DocDateFrom.DateTime, txt_DocDateTo.DateTime);
            DoBindingSummaryGrid(dt); //绑定主表的Grid
            ShowSummaryPage(true); //显示Summary页面.                         
            return dt != null && dt.Rows.Count > 0;
        }

        // 绑定单据的所有明细表. 
        protected override void DoBindingDetailGrid(DataSet dataSource)
        {
            //绑定明细表. 
            gcDetail.DataSource = null;
            gcDetail.DataSource = dataSource.Tables[tb_SOs.__TableName];

            //绑定单据的附件数据
            DataTable attachFiles = dataSource.Tables[tb_AttachFile.__TableName];
            ucAttachment1.StorateStrategy.AttachmentStorage = attachFiles;
            ucAttachment1.DoBindDataSource();
        }

        public override void DoPrint(IButtonInfo button)
        {
            string docNo = this.GetSummaryFieldValue(tb_SO.__KeyName);

            //DevExpress Report DEMO
            CSFramework3.ReportsDevExpress.frmRptSO.Execute(docNo, docNo);

            //FastReport DEMO
            CSFramework3.ReportsFastReport.frmReportSO.Execute(docNo, docNo);
        }

        //提交附件数据
        private void ucAttachment1_OnPostAttachmentData(object data)
        {
            this.AssertFocusedRow();
            if (_UpdateType == UpdateType.Add) return;//新增状态下无法获取单号,所以不能保存
            string docNo = this.GetSummaryFieldValue(tb_SO.__KeyName);
            this.PostAttachFiles(data as DataTable, docNo);
        }

        //提交附件数据
        private void PostAttachFiles(DataTable files, string docNo)
        {
            if (docNo == string.Empty) return;//新增状态下不能保存
            foreach (DataRow row in files.Rows)
            {
                if (row.RowState == DataRowState.Added)
                    row[tb_AttachFile.DocID] = docNo; //设置主键
            }
            _BLL.SaveAttachedFile(files); //附件单独保存
            files.AcceptChanges();
        }

        private void txtCustomer_OnSetResult(DataRow resultRow)
        {
            //在客户控件内输入编号，返回客户的资料行。
            //
            //在这里可以设置客户的联系人，送货地址等信息
            //
        }

    }
}
