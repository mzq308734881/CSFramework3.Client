///*************************************************************************/
///*
///* 文件名    ：ModuleManager.cs                              
///* 程序说明  : 模块管理器
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using CSFramework.Common;
using CSFramework.Library;
using CSFramework3.Interfaces;
using CSFramework.Core;

namespace CSFramework.Library
{
    #region NavigatorBar管理器

    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager
    {
        private XtraTabControl _tabControlModules = null;

        /// <summary>
        /// 主窗体的XtraTabControl控件, 用于集成模块的主窗体
        /// </summary>        
        public XtraTabControl TabControlModules { get { return _tabControlModules; } }

        /// <summary>
        ///MDI主窗体对象引用
        /// </summary>
        private Form _MDIMainForm = null;

        /// <summary>
        /// 已加载成功的模块
        /// </summary>
        private IList<IModuleBase> _ModulesLoadSucceed = new List<IModuleBase>();

        /// <summary>
        /// 已加载成功的模块
        /// </summary>
        public IList<IModuleBase> ModulesLoadSucceed
        {
            get { return _ModulesLoadSucceed; }
        }

        /// <summary>
        /// 程序目录下面搜索到的模块列表
        /// </summary>
        private static IList<ModuleInfo> _Modules = null;

        /// <summary>
        /// 程序目录下面搜索到的模块列表
        /// </summary>
        public static IList<ModuleInfo> GetAvailableModules()
        {
            return _Modules;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="mdiMainForm">MDI主窗体</param>
        /// <param name="tabControlModules">主窗体的XtraTabControl控件</param>
        public ModuleManager(Form mdiMainForm, XtraTabControl tabControlModules)
        {
            _tabControlModules = tabControlModules;
            _MDIMainForm = mdiMainForm;
        }

        /// <summary>
        /// 加载模块方法
        /// </summary>
        /// <param name="msg">加载进度</param>
        /// <param name="moduleMenus">模块的菜单</param>
        public void LoadModules(IMsg msg, MenuStrip moduleMenus)
        {
            try
            {
                //加载Dev组件
                ModuleLoadDevComponent loader = new ModuleLoadDevComponent();

                _Modules = loader.GetModuleList();//从运行目录中搜索模块文件
                foreach (ModuleInfo m in _Modules) //枚举模块文件
                {
                    if (!loader.LoadModule(m)) continue; //加载失败,继续Load下一个模块

                    //当前模块是否分配了权限.(当前用户是否有这个模块的权限).
                    //没有权限继续Load下一个模块
                    if (!loader.CanAccessModule(SystemAuthentication.UserAuthorities))
                    {
                        loader.ClearAssemble();
                        continue;
                    }

                    _ModulesLoadSucceed.Add(loader.ModuleMainForm);//保存已加载的模块

                    msg.UpdateMessage("正在加载:" + loader.GetCurrentModuleName());//显示加载进度
                    loader.LoadGUI(_tabControlModules); //将模块的功能按钮容器集成到主窗体的TabControl内
                    loader.LoadMenu(moduleMenus); //加载模块的菜单,集成到主窗体的主菜单内                    
                    (loader.ModuleMainForm as Form).MdiParent = _MDIMainForm; //模块的主窗体也作为一个子窗体, 设置父窗体.                    
                }

                GC.Collect();//加载模块消耗内存,及时回收部分内存
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 跟据菜单创建Bar按钮
        /// </summary>
        /// <param name="menuBar">Bar按钮</param>
        /// <param name="mainMenu">主菜单(各模块主菜单的组合)</param>
        public void CreateToolButtons(Bar menuBar, ToolStrip moduleMainMenu)
        {
            foreach (ToolStripMenuItem moduleTopMenu in moduleMainMenu.Items)
            {
                if (!moduleTopMenu.Enabled) continue;//菜单是禁止使用状态表示无权限

                //模块主菜单名称(一级菜单)
                BarSubItem menuOwner = new BarSubItem(menuBar.Manager, moduleTopMenu.Text);
                menuOwner.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                menuOwner.Glyph = moduleTopMenu.Image;
                menuOwner.Tag = moduleTopMenu;
                menuOwner.ItemClick += new ItemClickEventHandler(menuOwner_ItemClick);
                menuBar.ItemLinks.Add(menuOwner);

                //递归加载
                foreach (ToolStripItem item in moduleTopMenu.DropDownItems)
                {
                    if (item is ToolStripSeparator) continue;
                    if (!item.Enabled) continue;//菜单是禁止使用状态，无权限

                    if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        BarSubItem itemOwner = new BarSubItem(menuBar.Manager, item.Text);
                        menuOwner.ItemLinks.Add(itemOwner);
                        this.LoadBarSubItems(itemOwner, item as ToolStripMenuItem);
                    }
                    else
                    {
                        this.LoadBarButtonItem(menuOwner, item);
                    }
                }
            }
        }

        //模块顶级菜单的Click事件
        void menuOwner_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((e.Item.Tag != null) && (e.Item.Tag is ToolStripItem))
                (e.Item.Tag as ToolStripItem).PerformClick();
        }

        /// <summary>
        /// 将菜单项转换为BarButtonItem对象
        /// </summary>
        /// <param name="owner">按钮的父级拥有者</param>
        /// <param name="item">当前菜单项,每个菜单项对应一个BarButtonItem对象</param>
        private void LoadBarButtonItem(BarSubItem owner, ToolStripItem item)
        {
            BarButtonItem button = new BarButtonItem();
            button.Caption = item.Text;
            button.Tag = item;
            button.ItemClick += new ItemClickEventHandler(OnBarButtonItemClick);
            owner.ItemLinks.Add(button);
        }

        /// <summary>
        /// BarButtonItem对象的Click事件
        /// </summary>
        /// <param name="sender">BarButtonItem对象</param>
        /// <param name="e">参数</param>
        private void OnBarButtonItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null && e.Item.Tag is ToolStripItem)
                (e.Item.Tag as ToolStripItem).PerformClick();
        }

        /// <summary>
        /// 将菜单项转换为BarButtonItem对象
        /// </summary>
        /// <param name="itemOwner">按钮的父级拥有者</param>
        /// <param name="menuItem"></param>
        private void LoadBarSubItems(BarSubItem itemOwner, ToolStripMenuItem menuItem)
        {
            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripSeparator) continue;
                if (!item.Enabled) continue; //菜单是禁止使用状态，无权限

                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                {
                    BarSubItem subItem = new BarSubItem(itemOwner.Manager, item.Text);
                    itemOwner.ItemLinks.Add(subItem);
                    this.LoadBarSubItems(subItem, item as ToolStripMenuItem);
                }
                else
                {
                    this.LoadBarButtonItem(itemOwner, item);
                }
            }
        }

        /// <summary>
        /// 跟据菜单创建导航组件
        /// </summary>
        /// <param name="navBarControl">导航控件</param>
        /// <param name="mainMenu">主菜单</param>
        /// <param name="style">导航控件的自定义显示类型</param>
        public void CreateNavBarButtons(NavBarControl navBarControl, MenuStrip mainMenu, NavigatorStyle style)
        {
            //跟据用户选择样式创建不同类型的Navigator
            NavigatorBase creator;

            //支持两种策略
            if (NavigatorStyle.BarItem == style)
                creator = new NavigatorBarList(this);
            else
                creator = new NavigatorTreeView(this);

            navBarControl.BeginUpdate();
            creator.CreateNavigator(mainMenu, navBarControl);
            navBarControl.EndUpdate();
        }

        /// <summary>
        /// 显示指定的模块窗体
        /// </summary>
        /// <param name="moduleDisplayName">模块名称</param>
        public void ActiveModule(string moduleDisplayName)
        {
            //显示模块容器窗体
            (_MDIMainForm as IMdiForm).ShowModuleContainerForm();

            //显示当前模块页面
            foreach (XtraTabPage page in this._tabControlModules.TabPages)
            {
                if (page.Text.Equals(moduleDisplayName))
                    _tabControlModules.SelectedTabPage = page;
            }
        }

        /// <summary>
        /// 设置模块的权限
        /// </summary>
        /// <param name="menuStrip">系统主菜单</param>
        public void SetModuleSecurity(MenuStrip menuStrip)
        {
            try
            {
                foreach (XtraTabPage page in this._tabControlModules.TabPages)
                {
                    Form activeForm = (Form)page.Tag;
                    if (null != activeForm)
                        (activeForm as IModuleBase).SetSecurity(menuStrip);//处理权限
                }
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }
    }

    #endregion
}
