///*************************************************************************/
///*
///* 文件名    ：frmBaseBusinessForm.cs                              
///* 程序说明  : 业务窗体基类
///*              业务窗体是指有主从表结构数据操作的窗体.
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
using DevExpress.XtraEditors;
using CSFramework.Common;
using CSFramework3.Interfaces;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CSFramework3.Business;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Business.BLL_Business;

namespace CSFramework.Library
{
    /// <summary>
    /// 业务窗体是指有主从表结构数据操作的窗体
    /// </summary>
    public partial class frmBaseBusinessForm : frmBaseDataForm, IBusinessSupportable
    {
        /// <summary>
        /// 业务单据窗体的业务逻辑层
        /// </summary>
        protected bllBaseBusiness _BLL = new bllUnknow();
        public bllBaseBusiness BLL { get { return _BLL; } }

        public frmBaseBusinessForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示单据
        /// </summary>
        /// <param name="docNo">单据号码</param>
        public virtual void ShowBusiness(string docNo)
        {
            if (_BLL != null)
            {
                _BLL.GetBusinessByKey(docNo, true);
                DataTable summary = _BLL.CurrentBusiness.Tables[_BLL.SummaryTableName];
                DoBindingSummaryEditor(summary); //显示主表记录详细资料                            
                this.DoBindingDetailGrid(_BLL.CurrentBusiness);//绑定明细表 

                base.DoViewContent(_buttons.GetButtonByName("btnView"));
                ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页  
            }
        }

        /// <summary>
        /// 绑定业务窗体搜索页面上的按钮
        /// </summary>
        /// <param name="search">搜索按钮</param>
        /// <param name="reset">清空按钮</param>
        /// <param name="searchPanel">搜索页面</param>
        protected void BindingSummarySearchPanel(SimpleButton search, SimpleButton reset, PanelControl searchPanel)
        {
            reset.Tag = searchPanel;
            search.Click += new EventHandler(OnSummarySearchClick);
            reset.Click += new EventHandler(OnSummarySearchClearClick);
        }

        /// <summary>
        /// 点击搜索按钮
        /// </summary>
        protected virtual void OnSummarySearchClick(object sender, EventArgs e)
        {
            CCursor.ShowWaitCursor();
            if (!DoSearchSummary()) Msg.Warning("没有找到数据!");
            CCursor.ShowDefaultCursor();
        }

        /// <summary>
        /// 模板方法，查找主表的数据
        /// </summary>
        /// <returns></returns>
        protected virtual bool DoSearchSummary() { return true; }

        /// <summary>
        /// 清空搜索区域的输入框.
        /// </summary>
        protected void OnSummarySearchClearClick(object sender, EventArgs e)
        {
            Control gc = (sender as SimpleButton).Tag as Control;
            if (gc != null) ClearContainerEditorText(gc); // 清空搜索功能的输入框
        }

        /// <summary>
        /// 获取当前记录的指定字段的值
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        protected string GetSummaryFieldValue(string fieldName)
        {
            if (_SummaryView == null) return "";
            if (_SummaryView.IsValidRowHandle(_SummaryView.FocusedRowHandle))
                return ConvertEx.ToString(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle)[fieldName]);
            else
                return "";
        }

        /// <summary>
        /// 初始化数据窗体的常用按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();
            this.Buttons.AddRange(GetBusinessButtons());
        }

        /// <summary>
        /// 明细表格内按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEmbeddedNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                GridControl gc = (GridControl)((GridControlNavigator)sender).Parent;
                GridView gridView = (GridView)gc.Views[0]; //每个GridControl只有一个GridView.
                if (e.Button.ImageIndex == DetailButtons.Add || e.Button.ImageIndex == DetailButtons.Insert)
                    CreateOneDetail(gridView, e.Button.ImageIndex);
                else if (e.Button == gc.EmbeddedNavigator.Buttons.CustomButtons[DetailButtons.Delete])
                {
                    if (Msg.AskQuestion("真的要删除这条记录?"))
                        gridView.DeleteRow(gridView.FocusedRowHandle);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 创建一条明细数据
        /// </summary>
        /// <param name="gridView">明细表格</param>
        /// <param name="buttonIndex">按钮编号</param>
        protected virtual void CreateOneDetail(GridView gridView, int buttonIndex) { }

        #region IBusinessSupportable 成员

        /// <summary>
        /// 返回业务单据窗体的按钮数组
        /// </summary>
        /// <returns></returns>
        public virtual IButtonInfo[] GetBusinessButtons()
        {
            ArrayList list = new ArrayList();

            if (this.ButtonAuthorized(ButtonAuthority.APPROVAL))
                list.Add(this.ToolbarRegister.CreateButton("btnApproval", "审核", ResImage._24_Approval.ToBitmap(), new Size(57, 28), this.DoApproval));

            if (this.ButtonAuthorized(ButtonAuthority.SHOW_MOD_HISTORY))
                list.Add(this.ToolbarRegister.CreateButton("btnShowModifyHistory", "查看修改日志", ResImage._24_DesignReport.ToBitmap(), new Size(57, 28), this.DoShowModifyHistory));

            IButtonInfo[] ii = (IButtonInfo[])list.ToArray(typeof(IButtonInfo));
            return ii;
        }

        /// <summary>
        /// 当改变按钮状态时调用此方法
        /// </summary>
        /// <param name="currentState">当前的状态</param>
        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
        }

        /// <summary>
        /// 设置为修改状态
        /// </summary>
        protected override void SetEditMode()
        {
            base.SetEditMode();

            _buttons.GetButtonByName("btnApproval").Enable = false;
            _buttons.GetButtonByName("btnVoid").Enable = false;
            _buttons.GetButtonByName("btnShowModifyHistory").Enable = false;
            _buttons.GetButtonByName("btnAttach").Enable = false;
        }

        /// <summary>
        /// 设置为查看状态
        /// </summary>
        protected override void SetViewMode()
        {
            base.SetViewMode();

            _buttons.GetButtonByName("btnApproval").Enable = _AllowDataOperate && this.ButtonAuthorized(ButtonAuthority.APPROVAL);
            _buttons.GetButtonByName("btnVoid").Enable = _AllowDataOperate && this.ButtonAuthorized(ButtonAuthority.VOID);
            _buttons.GetButtonByName("btnShowModifyHistory").Enable = _AllowDataOperate && this.ButtonAuthorized(ButtonAuthority.SHOW_MOD_HISTORY);
        }

        /// <summary>
        /// 审核单据     
        /// </summary>
        /// <param name="button"></param>
        public virtual void DoApproval(IButtonInfo button)
        {
            AssertFocusedRow();

            DataRow row = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            if (_BLL.IsApproved(row))
            {
                Msg.Warning("该单据已经审核！");
            }
            else
            {
                if (Msg.AskQuestion("确定要审核单据吗？"))
                {
                    _BLL.ApprovalBusiness(row); //审核单据                
                    _SummaryView.RefreshRow(_SummaryView.FocusedRowHandle);
                    this.DoViewContent(null);//显示单据明细
                }
            }
        }

        /// <summary>
        /// 查看单据的修改历史记录
        /// </summary>
        /// <param name="button"></param>
        public virtual void DoShowModifyHistory(IButtonInfo button) { }

        #endregion

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        public override void DoAdd(IButtonInfo sender)
        {
            _BLL.GetBusinessByKey("-", true);//下载一个空业务单据            
            _BLL.NewBusiness(); //增加一条主表记录

            DoBindingSummaryEditor(_BLL.DataBinder); //显示主表记录详细资料                            
            this.DoBindingDetailGrid(_BLL.CurrentBusiness);//绑定明细表 
            base.DoAdd(sender);
            this.ShowDetailPage(true);
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        public override void DoCancel(IButtonInfo sender)
        {
            if (!Msg.AskQuestion("要取消修改吗?")) return;

            if (_UpdateType == UpdateType.Add)
            {
                base.DoCancel(sender);
                this.ShowSummaryPage(true);//只显示Summary页面. 因为禁止使用DetailPage,所以并没有刷新Detail页面数据.
            }
            else
            {
                base.DoCancel(sender);
                this.DoViewContent(sender); //刷新Detail页面资料.
            }
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public override void DoDelete(IButtonInfo sender)
        {
            AssertFocusedRow();

            DataRow row = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            if (_BLL.IsApproved(row))
            {
                Msg.Warning("单据已经审核，不能删除！");
            }
            else
            {
                if (Msg.AskQuestion("真的要删除?"))
                {
                    bool b = _BLL.Delete(row[_BLL.KeyFieldName].ToString()); //删除数据
                    AssertEqual(b, true, "删除记录时发生错误!");

                    base.DoDelete(sender);
                    this.SetSummaryRowZero(row);//删除单据:只删除明细,主表金额清零!!!

                    this.ShowSummaryPage(true);
                    Msg.ShowInformation("删除成功！\r\n\r\n提示:仅删除明细数据，保留主表仅数量金额清零！");
                }
            }
        }

        /// <summary>
        /// 删除单据:只删除明细记录,主表金额清零!!!
        /// </summary>
        /// <param name="row"></param>
        protected virtual void SetSummaryRowZero(DataRow row) { }

        /// <summary>
        /// 修改单据
        /// </summary>
        /// <param name="sender"></param>
        public override void DoEdit(IButtonInfo sender)
        {
            this.AssertFocusedRow();
            DataRow row = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);

            if (_BLL.IsOwnerChange(row) == false)
            {
                Msg.Warning("您不能修改他人创建的单据！\r\n\r\n ***本单据已应用修改策略*** ");
                return;
            }

            if (_BLL.IsApproved(row))
            {
                Msg.Warning("单据已经审核，不能修改！");
                return;
            }

            base.DoEdit(sender);
            DoViewContent(sender);
            ShowDetailPage(true);
        }

        /// <summary>
        /// 当用户在Summary页选择一条记录. 显示当前记录的详细资料及明细表资料.
        /// </summary>
        /// <param name="sender"></param>
        public override void DoViewContent(IButtonInfo sender)
        {
            AssertFocusedRow();
            string docNo = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle)[_BLL.KeyFieldName].ToString();
            _BLL.GetBusinessByKey(docNo, true);

            DataTable summary = _BLL.CurrentBusiness.Tables[_BLL.SummaryTableName];
            DoBindingSummaryEditor(summary); //显示主表记录详细资料                            
            this.DoBindingDetailGrid(_BLL.CurrentBusiness);//绑定明细表 

            base.DoViewContent(sender);
            ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
        }

        /// <summary>
        /// 绑定明细表格的数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected virtual void DoBindingDetailGrid(DataSet dataSource) { }

        /// <summary>
        /// 绑定主表当前记录的所有输入控件的数据源
        /// </summary>
        /// <param name="dataSource"></param>
        protected virtual void DoBindingSummaryEditor(DataTable dataSource) { }
    }
}

