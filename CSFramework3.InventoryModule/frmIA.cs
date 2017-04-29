using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.Business;
using CSFramework3.Models;
using DevExpress.XtraGrid.Views.Grid;
using CSFramework3.Interfaces;

namespace CSFramework3.InventoryModule
{
    /// <summary>
    /// 库存调整界面代码
    /// </summary>
    public partial class frmIA : frmBaseBusinessForm
    {
        public frmIA()
        {
            InitializeComponent();
        }

        private void frmIA_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        protected override void InitializeForm()
        {
            _BLL = new bllIA(); //业务逻辑层实例
            _SummaryView = new DevGridView(gvSummary);
            _ActiveEditor = txtIANO;
            _DetailGroupControl = pcEdit;

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

            DataBinder.BindingLookupEditDataSource(txtDocUser, DataDictCache.Cache.User, TUser.UserName, TUser.Account);
            DataBinder.BindingLookupEditDataSource(txtAppUser, DataDictCache.Cache.User, TUser.UserName, TUser.Account);
            DataBinder.BindingLookupEditDataSource(colD_LocationID.ColumnEdit as RepositoryItemLookUpEdit, DataDictCache.Cache.Location, tb_Location.LocationName, tb_Location.LocationID);

            (colD_StockCode.ColumnEdit as RepositoryItemButtonEdit).ButtonClick += new ButtonPressedEventHandler(OnStockCode_ButtonClick);
            (colD_StockCode.ColumnEdit as RepositoryItemButtonEdit).Validating += new CancelEventHandler(OnStockCode_Validating);

            _BLL.GetBusinessByKey("-", true);//加载一个空的业务对象.

            ShowSummaryPage(true); //一切初始化完毕后显示SummaryPage        
        }


        private void OnStockCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {//打开产品查询窗体
            frmFuzzySearch.Execute(sender as ButtonEdit, this._BLL as bllIA, this.SearchStockCallBack);
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

            gvDetail.SetRowCellValue(H, colD_StockCode, ConvertEx.ToString(resultRow[tb_Product.ProductCode]));//产品编号
            gvDetail.SetRowCellValue(H, colD_StockName, ConvertEx.ToString(resultRow[tb_Product.ProductName]));//产品名称
            gvDetail.SetRowCellValue(H, colD_Quantity, 1);//预设数量
            gvDetail.UpdateCurrentRow();
        }

        /// <summary>
        /// 改变按钮状态
        /// </summary>
        protected override void ButtonStateChanged(UpdateType currentState)
        {
            //自动赋值的字段，不能手动更改
            txtIANO.Enabled = false;
            chkFlagApp.Enabled = false;
            txtAppDate.Enabled = false;
            txtAppUser.Enabled = false;

            //设置编辑明细页面的控件
            this.SetDetailEditorsAccessable(panelDetailPage, this.DataChanged);
            base.SetGridCustomButtonAccessable(gcDetail, this.DataChanged);

            lbStateName.Text = this.GetStateName();//单据操作状态名称
        }

        protected override void SetDetailEditorsAccessable(Control panel, bool value)
        {
            base.SetDetailEditorsAccessable(panel, value);
            base.SetGridCustomButtonAccessable(gcDetail, value);
        }

        /// <summary>
        /// 显示主表数据,绑定输入框
        /// </summary>
        protected override void DoBindingSummaryEditor(DataTable dataSource)
        {
            if (dataSource == null) return;

            DataBinder.BindingTextEdit(txtIANO, dataSource, tb_IA.IANO);
            DataBinder.BindingTextEdit(txtReason, dataSource, tb_IA.Reason);
            DataBinder.BindingTextEdit(txtDocDate, dataSource, tb_IA.DocDate);
            DataBinder.BindingTextEdit(txtDocUser, dataSource, tb_IA.DocUser);
            DataBinder.BindingTextEdit(txtRemark, dataSource, tb_IA.Remark);
            DataBinder.BindingTextEdit(txtAppUser, dataSource, tb_IA.AppUser);
            DataBinder.BindingTextEdit(txtAppDate, dataSource, tb_IA.AppDate);
            DataBinder.BindingCheckEdit(chkFlagApp, dataSource, tb_IA.FlagApp);
        }

        public override void DoSave(IButtonInfo sender)// 保存数据
        {
            this.UpdateLastControl();//更新最后一个输入框的数据

            if (!ValidatingSummaryData(_BLL.CurrentBusiness.Tables[tb_IA.__TableName])) return; //检查主表数据合法性
            if (!ValidatingDetailData(_BLL.CurrentBusiness.Tables[tb_IAs.__TableName])) return; //检查从表数据合法性

            //注意:只有修改状态下保存修改日志
            if (_UpdateType == UpdateType.Modify) _BLL.WriteLog();

            //创建用于保存的临时数据
            DataSet dsTemplate = _BLL.CreateSaveData(_BLL.CurrentBusiness, _UpdateType);
            SaveResult result = _BLL.Save(dsTemplate);//调用业务逻辑保存数据方法

            if (result.Success) //保存成功, 不需要重新加载数据，更新当前的缓存数据就行．
            {
                if (_UpdateType == UpdateType.Add) _BLL.DataBindRow[tb_IA.__KeyName] = result.DocNo; //更新单据号码
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

        protected override void CreateOneDetail(GridView gridView, int buttonIndex)
        {
            //因需要取OrderID,Append状态下要将光标移到最后一行方可获取正确OrderID
            if (buttonIndex == DetailButtons.Add) gvDetail.MoveLast();
            if (gvDetail.RowCount == 0) buttonIndex = DetailButtons.Add;

            DataRow row = _BLL.CurrentBusiness.Tables[tb_IAs.__TableName].NewRow();
            string order = new GenerateSortID().Generate(gvDetail, colD_Queue); //生成排序编号
            row[tb_IAs.Queue] = order; //排序编号

            if (buttonIndex == DetailButtons.Add)
            {
                _BLL.CurrentBusiness.Tables[tb_IAs.__TableName].Rows.Add(row); //增加一条明细记录
                gcDetail.RefreshDataSource();
                gvDetail.FocusedRowHandle = gvDetail.RowCount - 1;
            }
            else if (buttonIndex == DetailButtons.Insert)
            {
                //插入一条明细记录
                _BLL.CurrentBusiness.Tables[tb_IAs.__TableName].Rows.InsertAt(row, gvDetail.FocusedRowHandle);
                gvDetail.FocusedRowHandle = gvDetail.FocusedRowHandle - 1;
            }

            gvDetail.FocusedColumn = gvDetail.VisibleColumns[0];//设焦点为第一列

        }

        /// <summary>
        /// 检查主表资料输入合法
        /// </summary>
        private bool ValidatingSummaryData(DataTable summary)
        {
            if (string.IsNullOrEmpty(txtDocUser.Text))
            {
                Msg.Warning("制单人不能为空!");
                txtDocUser.Focus();
                return false;
            }

            if (txtDocDate.DateTime == DateTime.MinValue)
            {
                Msg.Warning("调整日期不能为空!");
                txtDocDate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtReason.Text))
            {
                Msg.Warning("调整原因不能为空!");
                txtReason.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查所有明细表，参数details为所有表，Index=0为主表，1..n为明细
        /// </summary>
        private bool ValidatingDetailData(DataTable detail)
        {
            int i = 0;

            foreach (DataRow row in detail.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (ConvertEx.ToString(row[tb_IAs.LocationID]) == string.Empty)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_LocationID;
                    Msg.Warning("仓库不能为空!");
                    return false;
                }

                if (ConvertEx.ToString(row[tb_IAs.ProductCode]) == string.Empty)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_StockCode;
                    Msg.Warning("货品编号不能为空!");
                    return false;
                }

                if (ConvertEx.ToInt(row[tb_IAs.Quantity]) == 0)
                {
                    gcDetail.Focus();
                    gvDetail.FocusedRowHandle = i;
                    gvDetail.FocusedColumn = colD_Quantity;
                    Msg.Warning("数量不正确！");
                    return false;
                }

                i++;
            }
            return true;
        }

        /// <summary>
        /// 搜索数据
        /// </summary> 
        protected override bool DoSearchSummary()
        {
            try
            {
                if (txt_IANOFrom.Text.Trim() == "" &&
                    txt_IANOTo.Text.Trim() == "" &&
                    txt_DocDateFrom.DateTime == DateTime.MinValue &&
                    txt_DocDateTo.DateTime == DateTime.MinValue)
                {
                    Msg.Warning("请输入条件再查询!");
                    return true;
                }

                DataTable dt = (_BLL as bllIA).GetSummaryByParam(txt_IANOFrom.Text, txt_IANOTo.Text, txt_DocDateFrom.DateTime, txt_DocDateTo.DateTime);
                DoBindingSummaryGrid(dt); //绑定主表的Grid
                ShowSummaryPage(true); //显示Summary页面.                         
                return dt != null && dt.Rows.Count > 0;
            }
            catch (Exception ex) { Msg.ShowException(ex); return false; }
        }

        /// <summary>
        /// 绑定明细表格的数据源
        /// </summary>
        protected override void DoBindingDetailGrid(DataSet dataSource)
        {
            gcDetail.DataSource = null;
            gcDetail.DataSource = dataSource.Tables[tb_IAs.__TableName];
        }

        /// <summary>
        ///当子表表格数据更改时，如果是单价或数量改变，重新计算合计
        /// </summary>        
        private void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if ((e.Column == colD_StockCode) || (e.Column == colD_Quantity))
            {
                //
            }
        }

    }
}
