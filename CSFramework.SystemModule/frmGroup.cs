///*************************************************************************/
///*
///* 文件名    ：frmBaseDataForm.cs                   
///*
///* 程序说明  : 用户组及组权限设置窗体继承数据窗体基类frmBaseDataForm，
///*              用户组本身是字典数据，在权限管理内要作为业务窗体进行控制，
///*              因为组管理涉及到组用户和组权限及其它数据的管理。为了便于扩展自定义功能
///*              和优化代码结构，所以不继承frmBaseBusinessForm而是继承frmBaseDataForm。
///*              这样，可以控制不同的数据展示组件如TreeView. 
///*
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
using CSFramework.Library;
using CSFramework3.Business;
using DevExpress.XtraEditors;
using CSFramework3.Interfaces;
using CSFramework3.Models;
using CSFramework.Common;
using CSFramework3.Business.Security;
using CSFramework.Core;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 用户组及组权限设置窗体
    /// </summary>
    public partial class frmGroup : frmBaseDataForm
    {
        /// <summary>
        /// 当前正在处理的业务数据
        /// </summary>
        private DataSet _CurrentBusiness = null;

        /// <summary>
        /// 业务逻辑管理类
        /// </summary>
        private bllGroupAuthority _DataProxy = null;

        public frmGroup()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);            
            _ActiveEditor = txtGroupCode;
            _DataProxy = new bllGroupAuthority(this.treeAuthority, txtGroupCode);
            _DetailGroupControl = groupControl3;
            gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict
            this.BindingSummaryNavigator(this.controlNavigatorSummary, gcSummary);
            frmGridCustomize.RegisterGrid(gvSummary);
            DevStyle.SetGridControlLayout(gcSummary, false);//表格设置   
            DevStyle.SetSummaryGridViewLayout(gvSummary);
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            this.InitButtons(); //初始化按钮
            this.SetViewMode(); //预设为查看模式

            _DataProxy.InitAuthorityTree(); //初始化權限樹
            this.GetSummaryAndShow(); //下载显示数据.   
            this.ShowSummaryPage(true); //一切初始化完毕後显示SummaryPage     
        }

        /// <summary>
        /// 显示用户组数据
        /// </summary>
        private void GetSummaryAndShow()
        {
            try
            {
                DataTable summaryTable = _DataProxy.GetUserGroup();
                DoBindingSummaryGrid(summaryTable); //绑定主表的Grid
                ShowSummaryPage(true); //显示Summary页面. 
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        //新增操作
        public override void DoAdd(IButtonInfo sender)
        {
            try
            {
                _CurrentBusiness = _DataProxy.GetGroupDataByKey("--!"); //取空的业务数据
                DataTable binder = _CurrentBusiness.Tables[BusinessDataSetIndex.Groups];
                _DataProxy.AddSummary(binder);

                DoBindingSummaryEditor(binder); //显示主表记录详细资料                            

                //显示組的用戶
                _DataProxy.ShowUsers(lbSelectedUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupUsers]);

                //显示可选用户
                _DataProxy.ShowUsers(lbAvailableUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupAvailableUser]);
               
                //显示组权限
                _DataProxy.ShowGroupAutority(_CurrentBusiness.Tables[BusinessDataSetIndex.GroupAuthorities]);

                base.DoAdd(sender);
                ShowDetailPage(true);

            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        //当用户在Summary页选择一条记录. 显示当前记录的资料及明细表资料.
        public override void DoViewContent(IButtonInfo sender)
        {
            try
            {
                AssertFocusedRow();

                //取当前记录的主键
                string tmpGroupName = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle)[TUserGroup.GroupCode].ToString();

                //取组数据
                this._CurrentBusiness = _DataProxy.GetGroupDataByKey(tmpGroupName);

                DataTable summary = _CurrentBusiness.Tables[BusinessDataSetIndex.Groups];
                DoBindingSummaryEditor(summary); //显示主表记录详细资料                            

                _DataProxy.ShowUsers(lbSelectedUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupUsers]);
                _DataProxy.ShowUsers(lbAvailableUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupAvailableUser]);
                _DataProxy.ShowGroupAutority(_CurrentBusiness.Tables[BusinessDataSetIndex.GroupAuthorities]);

                base.DoViewContent(sender);
                ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        public override void DoSave(IButtonInfo sender)
        {
            try
            {
                UpdateLastControl();
                UpdateSummaryRowState(_CurrentBusiness.Tables[BusinessDataSetIndex.Groups].Rows[0]);

                if (!ValidatingData()) return; //检查数据合法性

                DataSet saveData = _DataProxy.CreateSaveData(_CurrentBusiness, lbAvailableUser, lbSelectedUser);

                //调用业务逻辑的方法保存数据
                bool ret = _DataProxy.SaveGroup(saveData);

                if (ret)
                {
                    //刷新表格內的數據.                    
                    UpdateSummaryRow(_CurrentBusiness.Tables[BusinessDataSetIndex.Groups].Rows[0]);

                    //重新获取数据
                    this._CurrentBusiness = _DataProxy.GetGroupDataByKey(txtGroupCode.Text);
                    DataTable binding = _CurrentBusiness.Tables[BusinessDataSetIndex.Groups];
                    DoBindingSummaryEditor(binding);
                    if (_UpdateType == UpdateType.Add)
                    {
                        int locatedID = gvSummary.LocateByValue(0, colGroupName, txtGroupCode.Text);
                        gvSummary.FocusedRowHandle = locatedID;
                    }
                    base.DoSave(sender); //此行代碼應該放較後位置.                    
                    Msg.ShowInformation("保存完成!");
                }
                else
                    Msg.Warning("保存失败!");
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        //修改操作
        public override void DoEdit(IButtonInfo sender)
        {
            try
            {
                AssertFocusedRow();
                base.DoEdit(sender);
                DoViewContent(sender);
                ShowDetailPage(true);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        /// <summary>
        /// 改变按钮状态
        /// </summary>
        /// <param name="currentState"></param>
        protected override void ButtonStateChanged(UpdateType currentState)
        {
            this.SetDetailEditorsAccessable(groupControl3, this.DataChanged);

            //新增状态下可输入组编号
            txtGroupCode.Enabled = UpdateType.Add == currentState;
        }

        protected override void SetDetailEditorsAccessable(Control panel, bool value)
        {
            base.SetDetailEditorsAccessable(panel, value);
            txtGroupCode.Enabled = (_UpdateType != UpdateType.Modify && value);//号码不充许修改.                     
            btnAllToLeft.Enabled = value;
            btnAllToRight.Enabled = value;
            btnSingleToLeft.Enabled = value;
            btnSingleToRight.Enabled = value;
        }

        protected void DoBindingSummaryEditor(object summaryData)
        {
            DataTable dt = summaryData as DataTable;
            if (summaryData == null) return;
            DataBinder.BindingTextEdit(txtGroupCode, summaryData, TUserGroup.GroupCode);
            DataBinder.BindingTextEdit(txtGroupName, summaryData, TUserGroup.GroupName);
        }

        //将一个用户加入用户组
        private void pbSingleToRight_Click(object sender, EventArgs e)
        {
            if (lbAvailableUser.SelectedIndex >= 0)
            {
                int curIndex = lbSelectedUser.Items.Add(lbAvailableUser.SelectedItem);
                lbSelectedUser.SelectedIndex = curIndex;

                int delIndex = lbAvailableUser.SelectedIndex;
                lbAvailableUser.Items.Remove(lbAvailableUser.SelectedItem);
                delIndex -= 1;
                lbAvailableUser.SelectedIndex = delIndex;
            }
        }

        //从用户组删除一个用户
        private void pbSingleToLeft_Click(object sender, EventArgs e)
        {
            if (lbSelectedUser.SelectedIndex >= 0)
            {
                int curIndex = lbAvailableUser.Items.Add(lbSelectedUser.SelectedItem);
                lbAvailableUser.SelectedIndex = curIndex;

                int delIndex = lbSelectedUser.SelectedIndex;
                lbSelectedUser.Items.Remove(lbSelectedUser.SelectedItem);
                delIndex -= 1;
                lbSelectedUser.SelectedIndex = delIndex;
            }
        }

        //将所有用户加入用户组
        private void pbAllToRight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbAvailableUser.Items.Count; i++)
                lbSelectedUser.Items.Add(lbAvailableUser.Items[i]);
            lbAvailableUser.Items.Clear();
        }

        //删除用户组内所有用户
        private void pbAllToLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbSelectedUser.Items.Count; i++)
                lbAvailableUser.Items.Add(lbSelectedUser.Items[i]);
            lbSelectedUser.Items.Clear();
        }

        //双击可选用户，将选中用户加入用户组
        private void lbAvailableUser_DoubleClick(object sender, EventArgs e)
        {
            if (lbAvailableUser.SelectedIndex >= 0)
                btnSingleToRight.PerformClick();
        }

        //双击组用户列表，将选中用户删除
        private void lbSelectedUser_DoubleClick(object sender, EventArgs e)
        {
            if (lbSelectedUser.SelectedIndex >= 0)
                btnSingleToLeft.PerformClick();
        }

        private void treeAuthority_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeAuthority.HitTest(e.Location);
            treeAuthority.SelectedNode = info.Node;
        }

        // 检查主表数据是否完整或合法
        private bool ValidatingData()
        {
            bool ret = true;
            if (txtGroupCode.Text == string.Empty)
            {
                Msg.Warning("组名称不能为空!");
                txtGroupCode.Focus();
                return false;
            }

            if (_UpdateType == UpdateType.Add)
            {
                if (_DataProxy.CheckNoExists(txtGroupCode.Text))
                {
                    Msg.Warning("组名称已经存在!");
                    txtGroupCode.Focus();
                    return false;
                }
            }
            return ret;
        }

        //取消修改
        public override void DoCancel(IButtonInfo sender)
        {
            try
            {
                if (!Msg.AskQuestion("要取消修改吗?")) return;

                if (_UpdateType == UpdateType.Add)
                {
                    base.DoCancel(sender);
                    this.ShowSummaryPage(true);
                }
                else
                {
                    base.DoCancel(sender);
                    this.DoViewContent(sender);
                }
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        //删除用户组
        public override void DoDelete(IButtonInfo sender)
        {
            try
            {
                if (!Msg.AskQuestion("真的要删除?")) return;

                AssertFocusedRow();

                DataRow row = this.GetFocusedRow();
                base.DoDelete(sender);
                string key = row[TUserGroup.GroupCode].ToString();
                if (key == string.Empty) return;

                bool ret = _DataProxy.DeleteGroupByKey(key);
                if (ret)
                {
                    this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行                    
                    row = this.GetFocusedRow();
                    if (row == null) return;

                    //获取下一条记录的数据
                    _CurrentBusiness = _DataProxy.GetGroupDataByKey(row[TUserGroup.GroupCode].ToString());
                    if (tcBusiness.SelectedTabPage == this.tpDetail)
                    {
                        //显示下一条记录的数据
                        this.DoBindingSummaryEditor(_CurrentBusiness.Tables[BusinessDataSetIndex.Groups]); //显示主表记录详细资料                                    

                        _DataProxy.ShowUsers(lbSelectedUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupUsers]);
                        _DataProxy.ShowUsers(lbAvailableUser, _CurrentBusiness.Tables[BusinessDataSetIndex.GroupAvailableUser]);
                        _DataProxy.ShowGroupAutority(_CurrentBusiness.Tables[BusinessDataSetIndex.GroupAuthorities]);
                    }

                    base.DoDelete(sender);
                    Msg.ShowInformation("删除成功!");
                }
                else
                    Msg.ShowError("删除发生错误!");
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        //刷新缓存记录的数据
        protected void UpdateSummaryRowState(DataRow dataRow)
        {
            dataRow.AcceptChanges();
            if (_UpdateType == UpdateType.Modify) dataRow.SetModified();
            if (_UpdateType == UpdateType.Add) dataRow.SetAdded();

        }

        //弹出菜单修改功能点名称
        private void menuChangeName_Click(object sender, EventArgs e)
        {
            if ((treeAuthority.SelectedNode != null) && (treeAuthority.SelectedNode.Tag is ActionNodeTag))
                if ((_UpdateType == UpdateType.Add) || (_UpdateType == UpdateType.Modify))
                    frmChangeTagName.Execute(treeAuthority.SelectedNode);
        }

        private void treeAuthority_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Node.Tag is ActionNodeTag) && ((_UpdateType == UpdateType.Add) || (_UpdateType == UpdateType.Modify)))
                    frmChangeTagName.Execute(e.Node);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((treeAuthority.SelectedNode != null) && (treeAuthority.SelectedNode.Tag is ActionNodeTag))
                menuChangeName.Enabled = true;
            else
                menuChangeName.Enabled = false;
        }

    }

}

