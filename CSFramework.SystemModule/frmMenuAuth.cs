///*************************************************************************/
///*
///* 文件名    ：frmMenuAuth.cs                   
///* 程序说明  : 系统菜单管理窗体,定义菜单的权限
///* 原创作者  ：孙中吕 
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
using System.Collections;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using CSFramework3.Interfaces;
using CSFramework3.Business.Security;
using CSFramework.Common;
using CSFramework3.Business;
using CSFramework3.Models;
using CSFramework.Library.UserControls;
using CSFramework.SystemModule.Properties;
using CSFramework.Core;
using CSFramework.Library;

namespace CSFramework.SystemModule
{
    /// <summary>
    /// 系统菜单管理窗体,定义菜单的权限
    /// </summary>
    public partial class frmMenuAuth : CSFramework.Library.frmBaseDataForm
    {
        private bllMenuMgr _BLL = null;//业务逻辑

        public frmMenuAuth()
        {
            InitializeComponent();
        }

        private void frmMenuAuth_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作
            this.ButtonStateChanged(UpdateType.None);
            this.InitActionPanel();

            gvMenus_FocusedRowChanged(gvMenus, new FocusedRowChangedEventArgs(0, gvMenus.FocusedRowHandle));

            this.BindingSummaryNavigator(controlNavigatorSummary, gcMenus);
        }

        //初始化窗体
        protected override void InitializeForm()
        {
            _DetailGroupControl = pnlDetail;
            _SummaryView = new DevGridView(gvMenus);

            _BLL = new bllMenuMgr();
            _BLL.GetSummaryData(true);
            gcMenus.DataSource = _BLL.SummaryTable;

            tpSummary.PageVisible = true;
            tpDetail.PageVisible = false;
            tcBusiness.ShowTabHeader = DefaultBoolean.False;
            tcBusiness.SelectedTabPage = tpSummary;

            base.InitializeForm();
        }

        public override bool ButtonAuthorized(int authorityValue)
        {
            //禁用一些按钮
            if (authorityValue == ButtonAuthority.ADD) return false;
            if (authorityValue == ButtonAuthority.PRINT) return false;
            if (authorityValue == ButtonAuthority.PREVIEW) return false;

            //处理特殊权限
            if (authorityValue == ButtonAuthority.EX_01)
                return this.HasPurview(authorityValue); //检查单个权限

            return base.ButtonAuthorized(authorityValue);
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            _buttons.GetButtonByName("btnView").Enable = false;
            pcActions.Enabled = this.IsAddOrEditMode;
        }

        /// <summary>
        /// 初始化功能权限控制面板
        /// </summary>
        private void InitActionPanel()
        {
            int ROW = 11;
            int rowTop = 3;
            int colLeft = 2;
            int count = 0;

            pcActions.BeginInit();
            foreach (DataRow actionRow in _BLL.AuthorityItem.Rows)
            {
                int value = ConvertEx.ToInt(actionRow["AuthorityValue"]);
                if (value == 0) continue;

                ucCheckEdit checkEdit = new ucCheckEdit();
                checkEdit.Name = "ucCheckEdit_" + value.ToString();
                checkEdit.IsChecked = false;
                checkEdit.Location = new System.Drawing.Point(colLeft, rowTop);
                checkEdit.MaximumSize = new System.Drawing.Size(2333, 21);
                checkEdit.MinimumSize = new System.Drawing.Size(29, 21);
                checkEdit.Size = new System.Drawing.Size(88, 21);
                checkEdit.TabIndex = 0;
                checkEdit.CheckText = ConvertEx.ToString(actionRow["AuthorityName"]); //显示预设的名称
                checkEdit.Tag = actionRow; //标记
                pcActions.Controls.Add(checkEdit);

                rowTop += 21 + 2;
                count++;
                if (count > ROW)
                {
                    colLeft += checkEdit.Width - 8;
                    rowTop = 3;
                    count = 0;
                }
            }
            pcActions.EndInit();
        }

        protected override void SetEditMode()
        {
            base.SetEditMode();
            _buttons.GetButtonByName("btnImport").Enable = false;
        }

        protected override void SetViewMode()
        {
            base.SetViewMode();
            _buttons.GetButtonByName("btnImport").Enable = true;
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();

            ArrayList list = new ArrayList();
            list.Add(this.ToolbarRegister.CreateButton("btnImport", "导入菜单", Resources._24_Clone.ToBitmap(), new Size(57, 28), this.DoImportMenu));
            this.Buttons.AddRange(list);
        }

        public override void DoDelete(IButtonInfo sender)
        {
            AssertFocusedRow();//检查是否选择一条记录
            if (!Msg.AskQuestion("真的要删除?")) return;

            //调用业务逻辑类删除记录
            DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            bool b = _BLL.Delete(summary[_BLL.KeyFieldName].ToString());
            AssertEqual(b, true, "删除记录时发生错误!");

            base.DoDelete(sender);
            this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行
            if (_SummaryView.FocusedRowHandle < 0) //删除了最後一条记录. 显示Summary页面.
                ShowSummaryPage(true);
            else
            {
                _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                this.DoViewContent(sender);
                base.DoDelete(sender);
            }
        }

        public override void DoCancel(IButtonInfo sender)
        {
            base.DoCancel(sender);
        }

        public override void DoEdit(IButtonInfo sender)
        {
            base.DoEdit(sender);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        public override void DoSave(IButtonInfo sender)
        {
            if (!gvMenus.IsValidRowHandle(gvMenus.FocusedRowHandle)) return;
            DataTable summary = gcMenus.DataSource as DataTable;

            DataRow currentRow = gvMenus.GetDataRow(gvMenus.FocusedRowHandle);
            int temp = ConvertEx.ToInt(currentRow[TMenu.Auths]); //取当前菜单的权限
            string menuName = ConvertEx.ToString(currentRow[TMenu.MenuName]);//当前菜单名

            //取窗体的权限
            int auths = 0; int val = 0;
            ucCheckEdit ce;
            DataRow row;
            string filter;

            foreach (Control ctr in pcActions.Controls)
            {
                if (!(ctr is ucCheckEdit)) continue;

                ce = ctr as ucCheckEdit;
                row = ce.Tag as DataRow; //功能点的数据行
                val = ConvertEx.ToInt(row["AuthorityValue"]);
                if (ce.IsChecked) auths += val; //累加权限数值

                filter = "MenuName='" + menuName + "' and TagValue=" + val.ToString();
                DataRow[] rows = _BLL.FormTagCustomName.Select(filter);
                if (rows.Length > 0) //有自定义功能点名称
                {
                    string tagName = ConvertEx.ToString(rows[0]["TagName"]);
                    if (ce.IsChecked && (tagName.ToUpper() != ce.CheckText.ToUpper()))
                        rows[0]["TagName"] = ce.CheckText;//修改新功能点名称

                    if (ce.IsChecked == false) //删除了功能名称
                        rows[0].Delete();
                }
                else
                {
                    string authName = ConvertEx.ToString(row["AuthorityName"]);
                    if (authName.ToUpper() != ce.CheckText.ToUpper())
                    {
                        DataRow newrow = _BLL.FormTagCustomName.NewRow();
                        newrow["MenuName"] = menuName;
                        newrow["TagValue"] = val;
                        newrow["TagName"] = ce.CheckText; //新的名称
                        _BLL.FormTagCustomName.Rows.Add(newrow);
                    }
                }
            }

            if (auths != temp)
            {
                currentRow["Auths"] = auths;//修改新权限
            }

            //保存两种数据: 1.菜单  2.各窗体的功能点名称            
            if (_BLL.Update(_UpdateType))
            {
                base.DoSave(sender);
                Msg.ShowInformation("保存成功!");
            }
        }

        public void DoImportMenu(IButtonInfo sender)
        {
            //导入菜单数据
            bool success = _BLL.ImportMenu((this.MdiParent as IMdiForm).MainMenu, false);
            if (success)
            {
                string msg = string.Format("导入菜单数据成功！共更新{0}个，导入新菜单{1}个！",
                    _BLL.LastUpdated, _BLL.LastInserted);
                Msg.ShowInformation(msg);
            }
        }

        private void gvMenus_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvMenus.IsValidRowHandle(e.FocusedRowHandle))
                this.ShowCurrentRowActions(e.FocusedRowHandle);// 显示菜单的功能
        }

        /// <summary>
        /// 显示菜单的功能
        /// </summary>
        /// <param name="rowHandle"></param>
        private void ShowCurrentRowActions(int rowHandle)
        {
            DataRow row; int value;
            int Auths = ConvertEx.ToInt(gvMenus.GetDataRow(rowHandle)[TMenu.Auths]);
            string menu = ConvertEx.ToString(gvMenus.GetDataRow(rowHandle)[TMenu.MenuName]);
            foreach (Control c in pcActions.Controls)
            {
                if (c is ucCheckEdit)
                {
                    row = c.Tag as DataRow;
                    value = ConvertEx.ToInt(row["AuthorityValue"]);

                    (c as ucCheckEdit).IsChecked = (value & Auths) == value;

                    //显示自定义的功能点名称
                    string filter = "MenuName='" + menu + "' and TagValue=" + value.ToString();
                    DataRow[] rows = _BLL.FormTagCustomName.Select(filter);
                    if (rows.Length > 0)
                        (c as ucCheckEdit).CheckText = ConvertEx.ToString(rows[0][TFormTagName.TagName]);
                    else
                        (c as ucCheckEdit).CheckText = ConvertEx.ToString(row["AuthorityName"]);
                }
            }
        }
    }
}
