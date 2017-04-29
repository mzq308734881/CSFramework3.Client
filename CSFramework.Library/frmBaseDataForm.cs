///*************************************************************************/
///*
///* 文件名    ：frmBaseDataForm.cs                              
///* 程序说明  : 支持数据操作功能的窗体基类
///*              这个类很重要！定义数据操作的几个常用方法：增/删/改/查/保存/取消
///*              实现IDataOperatable及IPrintableForm接口
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
using System.Reflection;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using CSFramework.Library;
using CSFramework3.Interfaces;
using CSFramework.Common;

namespace CSFramework.Library
{
    /// <summary>
    /// 支持数据操作功能的窗体基类.
    /// </summary>
    public partial class frmBaseDataForm : frmBaseChild, IDataOperatable, IPrintableForm
    {
        #region 成员变量

        /// <summary>
        /// 当显示修改明细页时,首先获取焦点的编辑框.
        /// </summary>
        protected Control _ActiveEditor;

        /// <summary>
        /// 关键字段输入框,新增时不可修改
        /// </summary>
        protected Control _KeyEditor;

        /// <summary>
        /// 主表的数据表格对象,必须由派生类指定表格类型。
        /// 因Dev GridControl组件不可继承所以子类窗体Load的时候需要赋值.
        /// </summary>
        protected ISummaryView _SummaryView;

        /// <summary>
        /// 数据编辑页的主容器
        /// 因继承问题,需要在子类窗体Load的时候需要赋值
        /// </summary>
        protected Control _DetailGroupControl;

        /// <summary>
        /// 数据操作状态
        /// </summary>
        protected UpdateType _UpdateType = UpdateType.None;

        protected virtual string GetStateName()
        {
            if (UpdateType.Add == _UpdateType) return "(新增模式)";
            else if (UpdateType.Modify == _UpdateType) return "(修改模式)";
            else return "(查看模式)";
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        protected bool _AllowDataOperate = true;

        #endregion

        public frmBaseDataForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 自定义初始化窗体操作, 窗体的Load事件必须调用此方法
        /// </summary>
        protected virtual void InitializeForm() //此方法由基类的Load事件调用
        {
            this.InitButtons();//初始化本窗体的按钮
            this.SetViewMode();//预设为数据查看模式
            this.SetButtonAuthority();//设置按钮权限

            //无操作状态下不可输入数据
            SetDetailEditorsAccessable(_DetailGroupControl, false);
        }

        /// <summary>
        /// 表格是否有数据
        /// </summary>
        /// <returns></returns>
        public virtual bool HasData()
        {
            if (_SummaryView != null)
                return _SummaryView.RowCount > 0;
            else
                return false;
        }

        /// <summary>
        /// 是否数据发生改变
        /// </summary>
        public bool DataChanged
        {
            get { return this.IsAddOrEditMode; }
        }

        /// <summary>
        /// 是否允许用户操作数据
        /// </summary>
        public bool AllowDataOperate
        {
            get { return _AllowDataOperate; }
            set
            {
                _AllowDataOperate = value;
                this.SetViewMode();
            }
        }

        /// <summary>
        /// 是否修改了数据
        /// </summary>
        public bool IsDataChanged
        {
            get { return this.IsAddOrEditMode; }
        }

        /// <summary>
        /// 是否新增/修改模式
        /// </summary>
        public bool IsAddOrEditMode
        {
            get { return (_UpdateType == UpdateType.Add) || (_UpdateType == UpdateType.Modify); }
        }

        /// <summary>
        /// 数据操作状态
        /// </summary>
        public UpdateType UpdateType { get { return _UpdateType; } }

        public virtual string UpdateTypeName
        {
            get
            {
                if (UpdateType.Add == _UpdateType) return "(新增模式)";
                else if (UpdateType.Modify == _UpdateType) return "(修改模式)";
                else return "(查看模式)";
            }
        }

        /// <summary>
        /// 初始化数据窗体的按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();

            IButtonInfo[] dataButton = this.GetDataOperatableButtons();
            IButtonInfo[] printButton = this.GetPrintableButtons();

            this.Buttons.AddRange(dataButton);
            this.Buttons.AddRange(printButton);
        }

        /// <summary>        
        ///设置为编辑模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetEditMode()
        {
            _buttons.GetButtonByName("btnView").Enable = false;
            _buttons.GetButtonByName("btnAdd").Enable = false;
            _buttons.GetButtonByName("btnDelete").Enable = false;
            _buttons.GetButtonByName("btnEdit").Enable = false;
            _buttons.GetButtonByName("btnPrint").Enable = false;
            _buttons.GetButtonByName("btnPreview").Enable = false;
            _buttons.GetButtonByName("btnSave").Enable = true;
            _buttons.GetButtonByName("btnCancel").Enable = true;
        }

        /// <summary>        
        ///设置为查看模式
        ///数据操作两种状态.1：数据修改状态 2：查看数据状态 
        /// </summary>
        protected virtual void SetViewMode()
        {
            _buttons.GetButtonByName("btnView").Enable = _AllowDataOperate;
            _buttons.GetButtonByName("btnAdd").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.ADD);
            _buttons.GetButtonByName("btnDelete").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.DELETE);
            _buttons.GetButtonByName("btnEdit").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuthority.EDIT);
            _buttons.GetButtonByName("btnPrint").Enable = ButtonAuthorized(ButtonAuthority.PRINT);
            _buttons.GetButtonByName("btnPreview").Enable = ButtonAuthorized(ButtonAuthority.PREVIEW);
            _buttons.GetButtonByName("btnSave").Enable = false;
            _buttons.GetButtonByName("btnCancel").Enable = false;
        }

        /// <summary>
        /// 检查按钮的权限
        /// </summary>
        /// <param name="authorityValue">权限值</param>
        /// <returns></returns>
        public override bool ButtonAuthorized(int authorityValue)
        {
            //超级用户拥有所有权限
            //窗体可用权限=2^n= 1+2+4=7
            //比如新增功能点是2,那么检查新增按钮的方法是：  2 & 7 = 2，表示有权限。
            //
            bool isAuth = Loginer.CurrentUser.IsAdmin() || (authorityValue & this.FormAuthorities) == authorityValue;
            return isAuth;
        }

        /// <summary>
        /// 按钮状态发生变化
        /// </summary>        
        protected virtual void ButtonStateChanged(UpdateType currentState)
        {
            //
        }

        #region IPrintableForm 成员

        /// <summary>
        /// 打印操作按钮
        /// </summary>
        /// <returns></returns>
        public IButtonInfo[] GetPrintableButtons()
        {
            IButtonInfo[] b = new IButtonInfo[1];
            if (this.ButtonAuthorized(ButtonAuthority.PRINT))
                b[0] = this.ToolbarRegister.CreateButton("btnPrint", "打印", ResImage._24_Print.ToBitmap(), new Size(57, 28), this.DoPrint);
            return b;
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="button"></param>
        public virtual void DoPrint(IButtonInfo button) { }

        #endregion

        #region IDataOperatable接口的方法

        /// <summary>
        /// 数据操作按钮
        /// </summary>
        /// <returns></returns>
        public IButtonInfo[] GetDataOperatableButtons()
        {
            ArrayList list = new ArrayList();
            list.Add(this.ToolbarRegister.CreateButton("btnView", "查看", ResImage._24_ViewContent.ToBitmap(), new Size(57, 28), this.DoViewContent));
            list.Add(this.ToolbarRegister.CreateButton("btnAdd", "新增", ResImage._24_Add.ToBitmap(), new Size(57, 28), this.DoAdd));
            list.Add(this.ToolbarRegister.CreateButton("btnDelete", "删除", ResImage._24_Delete.ToBitmap(), new Size(57, 28), this.DoDelete));
            list.Add(this.ToolbarRegister.CreateButton("btnEdit", "修改", ResImage._24_Edit.ToBitmap(), new Size(57, 28), this.DoEdit));
            list.Add(this.ToolbarRegister.CreateButton("btnSave", "保存", ResImage._24_Save.ToBitmap(), new Size(57, 28), this.DoSave));
            list.Add(this.ToolbarRegister.CreateButton("btnCancel", "取消", ResImage._24_Cancel.ToBitmap(), new Size(57, 28), this.DoCancel));
            IButtonInfo[] ii = (IButtonInfo[])list.ToArray(typeof(IButtonInfo));
            return ii;
        }

        /// <summary>
        /// 查看选中记录的数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoViewContent(IButtonInfo sender)
        {
            this.ButtonStateChanged(_UpdateType);
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoAdd(IButtonInfo sender)
        {
            this._UpdateType = UpdateType.Add;
            this.SetEditMode();
            this.ButtonStateChanged(_UpdateType);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoEdit(IButtonInfo sender)
        {
            this._UpdateType = UpdateType.Modify;
            this.SetEditMode();
            this.ButtonStateChanged(_UpdateType);
        }

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoCancel(IButtonInfo sender)
        {
            try
            {
                this._UpdateType = UpdateType.None;
                this.SetViewMode();
                this.ButtonStateChanged(_UpdateType);

                if (_UpdateType == UpdateType.Add)
                    this.ShowSummaryPage(true);
                else if (_SummaryView.RowCount > 0)
                    this.DoViewContent(sender);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoSave(IButtonInfo sender)
        {
            this._UpdateType = UpdateType.None;
            this.SetViewMode();
            this.ShowDetailPage(false);
            this.ButtonStateChanged(_UpdateType);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoDelete(IButtonInfo sender) { }

        #endregion

        #region Set Editors Accessable

        /// <summary>
        /// 控制明细页面上的控件可被编辑.
        /// </summary>
        protected virtual void SetDetailEditorsAccessable(Control panel, bool value)
        {
            if (panel == null) return;

            for (int i = 0; i < panel.Controls.Count; i++)
            {
                SetControlAccessable(panel.Controls[i], value);
            }

            controlNavigatorSummary.Enabled = !value;
        }

        /// <summary>
        /// 设置控件状态.ReadOnly or Enable = false/true
        /// </summary>
        protected void SetControlAccessable(Control control, bool value)
        {
            try
            {
                if (control is Label) return;
                if (control is ControlNavigator) return;
                if (control is UserControl) return;

                if (control.Controls.Count > 0)
                {
                    foreach (Control c in control.Controls)
                        SetControlAccessable(c, value);
                }

                System.Type type = control.GetType();
                PropertyInfo[] infos = type.GetProperties();
                foreach (PropertyInfo info in infos)
                {
                    if (info.Name == "ReadOnly")//ReadOnly
                    {
                        info.SetValue(control, !value, null);
                        return;
                    }
                    if (info.Name == "Properties")//Properties.ReadOnly
                    {
                        object o = info.GetValue(control, null);
                        if (o is RepositoryItem)
                        {
                            ((RepositoryItem)o).ReadOnly = !value;
                        }
                        //解决日期控件和ButtonEdit在浏览状态下也能按button的问题
                        if ((o is RepositoryItemButtonEdit) && (((RepositoryItemButtonEdit)o).Buttons.Count > 0))
                            ((RepositoryItemButtonEdit)o).Buttons[0].Enabled = value;
                        if ((o is RepositoryItemDateEdit) && (((RepositoryItemDateEdit)o).Buttons.Count > 0))
                            ((RepositoryItemDateEdit)o).Buttons[0].Enabled = value;
                        return;
                    }
                    if (info.Name == "Views")//OptionsBehavior.Editable
                    {
                        object o = info.GetValue(control, null);
                        if (null == o) return;
                        foreach (object view in (GridControlViewCollection)o)
                        {
                            if (view is ColumnView)
                                ((ColumnView)view).OptionsBehavior.Editable = value;
                        }
                        return;
                    }

                }
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 设置Grid自定义按钮(Add,Insert,Delete)状态
        /// </summary>
        protected void SetGridCustomButtonAccessable(GridControl gridControl, bool value)
        {
            NavigatorCustomButtons custom = gridControl.EmbeddedNavigator.Buttons.CustomButtons;
            if (custom != null && custom.Count == 3)
            {
                custom[DetailButtons.Add].Enabled = value; //add
                custom[DetailButtons.Insert].Enabled = value;//insert
                custom[DetailButtons.Delete].Enabled = value;//del
            }
        }

        /// <summary>
        /// 设置某个编辑控件状态.ReadOnly or Enable . (递归)循环控制
        /// </summary>
        protected void SetControlAccessableCycle(Control control, bool value)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    //DevExpress的内部(Inner)控件
                    if (ctrl.Name == string.Empty)
                        SetControlAccessable(control, value);
                    else
                        SetControlAccessableCycle(ctrl, value);
                }
            }
            else SetControlAccessable(control, value);
        }

        /// <summary>
        /// 双击表格事件
        /// </summary>
        protected virtual void OnGridViewDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SystemConfig.CurrentConfig == null) return;
                if (!this.HasData()) return;

                IButtonInfo btn = _buttons.GetButtonByName("btnEdit");

                //双击表格进入修改状态
                if (SystemConfig.CurrentConfig.DoubleClickIntoEditMode)
                {
                    if (this.ButtonAuthorized(ButtonAuthority.EDIT)) //当前用户有修改权限
                    {
                        this.DoEdit(btn); //调用修改方法
                        return;
                    }
                }
                else //只能查看
                {
                    this.DoViewContent(btn);
                    SetDetailEditorsAccessable(_DetailGroupControl, false);
                }
            }
            catch { }
        }

        #endregion

        /// <summary>
        /// 获取Summary表的数据源.         
        /// </summary>
        protected DataTable SummaryTable
        {
            get
            {
                if (_SummaryView == null) return null;
                return (DataTable)_SummaryView.DataSource;
            }
        }

        /// <summary>
        ///获取指定的资料行
        /// </summary>
        protected DataRow GetDataRow(int rowIndex)
        {
            if (rowIndex < 0) return null;
            if (SummaryTable != null) return SummaryTable.Rows[rowIndex];
            return null;
        }

        #region Summary数据导航功能

        /// <summary>
        /// 移到第一条记录
        /// </summary>
        protected virtual void DoMoveFirst()
        {
            if (_SummaryView == null) return;
            _SummaryView.MoveFirst();
            if (tcBusiness.SelectedTabPage != tpSummary)
                DoViewContent(null);
        }

        /// <summary>
        /// 移到上一条记录
        /// </summary>
        protected virtual void DoMovePrior()
        {
            if (_SummaryView == null) return;
            _SummaryView.MovePrior();
            if (tcBusiness.SelectedTabPage != tpSummary)
                DoViewContent(null);
        }

        /// <summary>
        /// 移到下一条记录
        /// </summary>
        protected virtual void DoMoveNext()
        {
            if (_SummaryView == null) return;
            _SummaryView.MoveNext();
            if (tcBusiness.SelectedTabPage != tpSummary)
                DoViewContent(null);
        }

        /// <summary>
        /// 移到最后一条记录
        /// </summary>
        protected virtual void DoMoveLast()
        {
            if (_SummaryView == null) return;
            _SummaryView.MoveLast();
            if (tcBusiness.SelectedTabPage != tpSummary)
                DoViewContent(null);
        }

        #endregion

        /// <summary>
        /// 第一个编辑控件设置焦点.
        /// </summary>
        protected void FocusEditor()
        {
            if (_ActiveEditor != null)
            {
                if (_ActiveEditor.CanFocus)
                    _ActiveEditor.Focus();
                else
                    this.SelectNextControl(_ActiveEditor, true, false, true, true);
            }
        }

        /// <summary>
        /// 显示明细页
        /// </summary>
        protected void ShowDetailPage(bool disableSummaryPage)
        {
            try
            {
                this.SuspendLayout();
                this.tpDetail.PageEnabled = true;
                tcBusiness.SelectedTabPage = this.tpDetail;
                tpSummary.PageEnabled = !disableSummaryPage;
                FocusEditor(); //第一个编辑框获得焦点.
                this.ResumeLayout();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示主表页
        /// </summary>
        protected void ShowSummaryPage(bool disableDetailPage)
        {
            try
            {
                this.tpSummary.PageEnabled = true;
                tcBusiness.SelectedTabPage = this.tpSummary;
                tpDetail.PageEnabled = !disableDetailPage;
                if (_SummaryView != null) _SummaryView.SetFocus();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示当前操作消息
        /// </summary>
        protected void ShowTip(string tip)
        {
            lblPrompt.Text = tip;
            lblPrompt.Update();
        }

        /// <summary>
        ///获取当前光标所在的资料行. 
        /// </summary>
        protected DataRow GetFocusedRow()
        {
            if (_SummaryView.FocusedRowHandle < 0)
                return null;
            else
            {
                if (_SummaryView.DataSource is DataTable)
                    return _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
                else
                    return null;
            }
        }

        /// <summary>
        /// 关窗体中...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBaseDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DataChanged)
                e.Cancel = !Msg.AskQuestion("您修改了数据没有保存，确定要退出吗?");
        }

        /// <summary>
        /// 清空容器内输入框.
        /// </summary>
        public void ClearContainerEditorText(Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                if (container.Controls[i] is TextEdit)
                    ((TextEdit)container.Controls[i]).EditValue = null;
                else if (container.Controls[i] is TextBoxBase)
                    ((TextBoxBase)container.Controls[i]).Clear();
            }
        }


        /// <summary>
        /// 绑定Summary的导航按钮.
        /// </summary>        
        protected void BindingSummaryNavigator(ControlNavigator navigator, GridControl gc)
        {
            navigator.NavigatableControl = gc;
            navigator.ButtonClick += new NavigatorButtonClickEventHandler(OnSummaryNavigatorButtonClick);
        }

        /// <summary>
        /// 主表格导航按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSummaryNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            try
            {
                CCursor.ShowWaitCursor();
                NavigatorButton btn = (NavigatorButton)e.Button;
                ControlNavigatorButtons buttons = ((ControlNavigator)sender).Buttons;
                if (e.Button == buttons.First) DoMoveFirst();
                if (e.Button == buttons.Prev) DoMovePrior();
                if (e.Button == buttons.Next) DoMoveNext();
                if (e.Button == buttons.Last) DoMoveLast();
            }
            finally
            {
                e.Handled = true;
                CCursor.ShowDefaultCursor();
            }
        }

        #region 几个断言

        /// <summary>
        /// 检查对象是否为空
        /// </summary>
        /// <param name="obj">要检测的对象</param>
        /// <param name="errMsg">如果为空提示信息</param>
        protected void AssertNull(object obj, string errMsg)
        {
            if (null == obj) throw new Exception(errMsg);
        }

        /// <summary>
        /// 检查对象对等
        /// </summary>
        /// <param name="objA">对象A</param>
        /// <param name="objB">对象B</param>
        /// <param name="errMsg">如果不相等提示信息</param>
        protected void AssertEqual(object objA, object objB, string errMsg)
        {
            if (objA != null && objB != null)
            {
                if (!objA.Equals(objB))
                    throw new Exception(errMsg);
            }
        }
        /// <summary>
        /// 检查是否有选择一条记录.
        /// </summary>        
        protected void AssertFocusedRow()
        {
            bool ret = (_SummaryView == null) || (_SummaryView.IsValidRowHandle(_SummaryView.FocusedRowHandle) == false);
            if (ret) throw new Exception("您没有选择记录，操作取消!");
        }

        /// <summary>
        /// 检查数据集是否有数据
        /// </summary>
        /// <param name="data"></param>
        protected void AssertRowNull(DataSet data)
        {
            bool ret = (data == null) || (data.Tables.Count == 0) || (data.Tables[0].Rows.Count <= 0);
            if (ret) throw new Exception("该数据集没有数据!");
        }

        /// <summary>
        /// 检查数据集是否有数据
        /// </summary>
        /// <param name="data"></param>
        protected void AssertTableEmpty(DataSet ds)
        {
            if ((ds == null) || (ds.Tables.Count <= 0) || ds.Tables[0].Rows.Count <= 0)
                throw new Exception("该数据集没有数据!");
        }

        #endregion

        /// <summary>
        /// 给表格绑定数据
        /// </summary>
        /// <param name="dataSource"></param>
        protected void DoBindingSummaryGrid(DataTable dataSource)
        {
            if (_SummaryView != null)
            {
                _SummaryView.DataSource = null;
                _SummaryView.DataSource = dataSource;
            }
        }

        /// <summary>
        /// 删除表格内指定行号的记录
        /// </summary>
        /// <param name="rowHandle"></param>
        protected virtual void DeleteSummaryRow(int rowHandle)
        {
            if (rowHandle >= 0)
            {
                if (_SummaryView.DataSource is DataTable)
                {
                    DataTable dt = (DataTable)_SummaryView.DataSource;
                    dt.Rows.Remove(_SummaryView.GetDataRow(rowHandle));
                }
            }
        }

        /// <summary>
        /// 在保存时有此情况发生: 不会更新最后一个编辑框里的数据!
        /// 当移除焦点后会更新输入框的数据.
        /// </summary>
        protected void UpdateLastControl()
        {
            try
            {
                if (ActiveControl == null) return;
                Control ctl = ActiveControl;
                txtFocusForSave.Focus();
                ActiveControl = ctl;
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 替换记录对应字段的数据。
        /// </summary>
        /// <param name="sourceRow">数据源</param>
        /// <param name="destRow">需要替换的记录</param>
        protected void ReplaceDataRowChanges(DataRow sourceRow, DataRow destRow)
        {
            string fieldName;

            //循环处理当前记录的所有字段
            for (int i = 0; i <= sourceRow.Table.Columns.Count - 1; i++)
            {
                fieldName = sourceRow.Table.Columns[i].ColumnName;

                //如果字段名相同，替换对应字段的数据。
                if (destRow.Table.Columns.IndexOf(fieldName) >= 0)
                {
                    destRow[fieldName] = sourceRow[fieldName];
                }
            }
        }

        /// <summary>
        /// 更新当前操作的缓存记录
        /// 保存数据后更新Summary当前记录.
        /// 如果是修改后保存,将最新数据替换当前记录的数据.
        /// 如果是新增后保存,在表格内插入一条记录.
        /// </summary>
        protected virtual void UpdateSummaryRow(DataRow summary)
        {
            if (_SummaryView.DataSource == null) return;
            if (summary == null) return;
            try
            {
                DataTable dt = (DataTable)_SummaryView.DataSource;

                //如果是新增后保存,在表格内插入一条记录.
                if (_UpdateType == UpdateType.Add)
                {
                    DataRow newrow = dt.NewRow();//表格的数据源增加一条记录

                    this.ReplaceDataRowChanges(summary, newrow);//替换数据

                    dt.Rows.Add(newrow);
                    _SummaryView.RefreshDataSource();
                    _SummaryView.FocusedRowHandle = dt.Rows.Count - 1;
                    dt.AcceptChanges();
                }

                //如果是修改后保存,将最新数据替换当前记录的数据.
                if (_UpdateType == UpdateType.Modify || _UpdateType == UpdateType.None)
                {
                    int focusedRowHandle = _SummaryView.FocusedRowHandle;

                    DataRow dr = _SummaryView.GetDataRow(focusedRowHandle);

                    this.ReplaceDataRowChanges(summary, dr);//替换数据

                    dr.Table.AcceptChanges();
                    _SummaryView.RefreshRow(focusedRowHandle);//修改或新增要刷新Grid数据          
                }
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }


        /// <summary>
        /// 给绑定数据源的输入控件赋值
        /// </summary>
        protected void SetEditorBindingValue(Control bindingControl, object value)
        {
            try
            {
                object temp = null;
                if (value != DBNull.Value) temp = value;
                DataConverter.SetValueOfObject(bindingControl, "EditValue", temp);

                if (bindingControl.DataBindings.Count > 0)
                {
                    object dataSource = bindingControl.DataBindings[0].DataSource;
                    string field = bindingControl.DataBindings[0].BindingMemberInfo.BindingField;
                    if (dataSource is DataTable)
                    {
                        (dataSource as DataTable).Rows[0][field] = value;
                    }
                    else
                    {
                        DataConverter.SetValueOfObject(dataSource, field, value);
                    }

                    bindingControl.Focus();
                }
            }
            catch { } //这里不用显示异常信息. 
        }

        /// <summary>
        /// 设置输入组件只读及背景色
        /// </summary>
        /// <param name="editor">输入组件</param>
        /// <param name="enable">可写/只读</param>
        /// <param name="setBackgroundColor">是否设置背景色</param>
        protected void SetEditorEnable(TextEdit editor, bool enable, bool setBackgroundColor)
        {
            if (enable && setBackgroundColor)
                editor.BackColor = Color.White;
            if (!enable && setBackgroundColor)
                editor.BackColor = SystemColors.ButtonFace;

            editor.Properties.ReadOnly = !enable;
        }

    }
}