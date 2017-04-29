
///*************************************************************************/
///*
///* 文件名    ：frmMain.cs    
///* 程序说明  : 系统主窗体(MDI主窗体)
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
using System.Collections;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using CSFramework3.Interfaces;
using CSFramework.Common;
using CSFramework3.Business.Security;
using CSFramework.Core;
using CSFramework3.Business;
using CSFramework.Library;
using CSFramework3.Bridge;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;

namespace CSFramework3.Main
{
    /// <summary>
    /// 系统主窗体(MDI主窗体)
    /// </summary>
    public partial class frmMain : frmBase, IMdiForm
    {
        //注册不同类型的ToolBar,目录使用DevBarRegister注册器        
        private IToolbarRegister _MdiToolbar = null;

        //模块管理器实例
        private ModuleManager _ModuleManager;

        //模块主界面容器
        private frmModuleContainer _ModuleContainer;

        //保存各模块的主菜单
        private MenuStrip _moduleMenus = new MenuStrip();

        /// <summary>
        /// 所有模块主菜单的集合
        /// </summary>
        public MenuStrip MainMenu { get { return _moduleMenus; } }

        public frmMain()
        {
            InitializeComponent();
            SkinTools.LoadSkinList(btnSetSkin); //加载皮肤列表
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //显示程序名和公司名
            this.Text = Globals.DEF_PROGRAM_NAME +
                " 用户(" + Loginer.CurrentUser.Account + ")" +
                " 帐套(" + Loginer.CurrentUser.DataSetID + ")";

            barStaticItem1.Caption = Globals.DEF_PROGRAM_NAME;
            barStaticItem2.Caption = "帐套:" + Loginer.CurrentUser.DataSetID;

            //当前授权模式是否支持登出功能, 比如Novell,Domain模式不支持登出
            btnLogout.Enabled = SystemAuthentication.Current.SupportLogout;
            if (btnLogout.Enabled)
                btnLogout.Caption = "登出(" + Loginer.CurrentUser.Account + ")";
            else
                btnLogout.Caption = "用户:" + Loginer.CurrentUser.Account;

            btnConnStatus.Caption = "后台:" + BridgeFactory.BridgeType.ToString();
        }

        /// <summary>
        /// 显示模块容器窗体
        /// </summary>
        public void ShowModuleContainerForm()
        {
            _ModuleContainer.Activate();
        }

        /// <summary>
        /// 初始化MDI主窗体，在登录窗体显示加载状态。
        /// </summary>
        /// <param name="splash">登录窗体上的进度显示组件</param>
        public void InitUserInterface(IMsg splash)
        {
            try
            {
                this.SuspendLayout();

                splash.UpdateMessage("正在初始化用户界面...");
                this._MdiToolbar = new DevBarRegister(this, this.barToolButtons);
                this.RegisterMdiButtons();

                splash.UpdateMessage("正在初始化模块容器...");
                _ModuleContainer = (frmModuleContainer)MdiTools.OpenChildForm(this as IMdiForm, typeof(frmModuleContainer), null);
                _ModuleContainer.InitButtons();

                splash.UpdateMessage("正在加载模块...");
                _ModuleManager = new ModuleManager(this, _ModuleContainer.xtraTabControl1);//创建模块管理器
                _ModuleManager.LoadModules(splash, _moduleMenus); //加载可用模块

                splash.UpdateMessage("正在初始化用户权限...");
                SystemAuthentication.SetMenuAuthority(_moduleMenus);
                _ModuleManager.SetModuleSecurity(_moduleMenus);

                splash.UpdateMessage("正在加载工具栏(Toolbar)...");
                _ModuleManager.CreateToolButtons(barMainMenu, _moduleMenus);

                splash.UpdateMessage("正在加载导航面板(Navigator Panel)...");
                _ModuleManager.CreateNavBarButtons(this.navBarControl1, _moduleMenus, NavigatorStyle.BarContainer); //创建导航工具栏按钮

                splash.UpdateMessage("下载基础数据...");
                CommonData.GetCommonInfos(); //获取其它公共数据
                DataDictCache.RefreshCache();

                splash.UpdateMessage("加载完毕.");

                this.ResumeLayout();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示模块主窗体
        /// </summary>        
        public void ActiveModule(string moduleDisplayName)
        {
            foreach (XtraTabPage page in _ModuleContainer.xtraTabControl1.TabPages)
            {
                if (page.Text.Equals(moduleDisplayName))
                {
                    _ModuleContainer.xtraTabControl1.SelectedTabPage = page;
                    return;
                }
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        #region IMdiForm Members

        /// <summary>
        /// MDI主窗体的工具条按钮注册接口
        /// </summary>
        public IToolbarRegister MdiToolbar { get { return _MdiToolbar; } set { _MdiToolbar = value; } }

        /// <summary>
        /// MDI主窗体的观察者
        /// </summary>
        public IObserver[] MdiObservers
        {
            get
            {
                IObserver[] os = new IObserver[3];
                os[0] = new ObserverCloseAllChild(this);
                return os;
            }
        }

        /// <summary>
        /// 注册MDI主窗体的按钮
        /// </summary>
        public void RegisterMdiButtons()
        {
            this.MdiToolbar.RegisteButton(this.MdiButtons);
        }

        /// <summary>
        /// 主窗体的按钮
        /// </summary>
        public IList MdiButtons
        {
            get
            {
                IList btns = new ArrayList();

                btns.Add(this.MdiToolbar.CreateButton("btnHelp", "帮助",
                     Globals.LoadBitmap("24_Help.ico"), new Size(57, 28), this.DoHelp));

                btns.Add(this.MdiToolbar.CreateButton("btnAbout", "关于程序",
                     Globals.LoadBitmap("cslogo24.ico"), new Size(57, 28), this.DoAbout));

                return btns;
            }
        }

        #endregion

        public void DoHelp(IButtonInfo sender)
        {
            new frmAbout().ShowDialog();
        }

        public void DoAbout(IButtonInfo sender)
        {
            new frmAbout().ShowDialog();
        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!Msg.AskQuestion("真的要登出吗?")) return;
            try
            {
                if (this.AnyDataChanged())
                {
                    Msg.Warning("系统检测到有数据窗体没有保存，不能登出!");
                    return;
                }

                if (!Application.AllowQuit) return; //程序不允许退出

                SystemAuthentication.Current.Logout(); //登出

                this.Hide();

                //显示登录窗体
                Program.MainForm = null;
                if (frmLogin.Login() && Program.MainForm != null)
                    Program.MainForm.Show();

                GC.Collect();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }

        }

        /// <summary>
        /// 检查数据窗体是否没有保存数据
        /// </summary>
        private bool AnyDataChanged()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is IDataOperatable)
                {
                    //子窗体处于新增或修改模式.
                    if (((IDataOperatable)form).DataChanged) return true;
                }
            }
            return false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.AnyDataChanged())
            //{
            //    bool ok = Msg.AskQuestion("系统检测到有数据没有保存，真的要退出吗?");
            //    if (!ok) e.Cancel = true;
            //}
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//关闭主窗体，系统终止!
        }

        private void btnRefreshCache_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataDictCache.Cache.DownloadBaseCacheData(); //重新下载所有数据字典
            Msg.ShowInformation("更新缓存数据成功！");
        }

        private void menuCloseThis_Click(object sender, EventArgs e)
        {//关闭当前窗体
            int i = xtraTabbedMdiManager1.Pages.IndexOf(xtraTabbedMdiManager1.SelectedPage);//当前窗体的序号
            Form form = xtraTabbedMdiManager1.SelectedPage.MdiChild;
            if (form is frmModuleContainer) { }
            else
            {
                form.Close();//不关闭模块主窗体                
                if (xtraTabbedMdiManager1.Pages.Count - 1 >= i)
                {
                    //显示相邻的窗体                    
                    xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[i];
                }
            }
        }

        private void menuCloseAll_Click(object sender, EventArgs e)
        {//除此之外全部关闭
            Form currentForm = xtraTabbedMdiManager1.SelectedPage.MdiChild;//当前窗体
            IList list = new ArrayList();
            foreach (XtraMdiTabPage p in xtraTabbedMdiManager1.Pages) list.Add(p.MdiChild);//构建窗体列表
            foreach (Form form in list)
            {
                //不关闭当前窗体,模块主窗体及模块容器窗体
                if ((currentForm == form) || (form is frmModuleContainer) || (form is IModuleBase)) continue;
                form.Close();
            }
        }

        private void xtraTabbedMdiManager1_MouseUp(object sender, MouseEventArgs e)
        {
            //点左键无效, 必须是点右键弹出菜单
            if (e.Button != MouseButtons.Right) return;

            menuCloseThis.Enabled = !(xtraTabbedMdiManager1.SelectedPage.MdiChild is frmModuleContainer);//模块主窗体禁止关闭

            BaseTabHitInfo hint = xtraTabbedMdiManager1.CalcHitInfo(e.Location);

            //点击有效,且点击在TabPage标题上
            if (hint.IsValid && (hint.Page != null))
            {
                //有效子窗体
                if (xtraTabbedMdiManager1.SelectedPage.MdiChild != null)
                {
                    Point p = xtraTabbedMdiManager1.SelectedPage.MdiChild.PointToScreen(e.Location);
                    menuStripCloseForm.Show(p); //显示弹出菜单
                }
            }

        }


    }
}