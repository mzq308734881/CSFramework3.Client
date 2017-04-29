namespace CSFramework3.Main
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ilModule = new System.Windows.Forms.ImageList(this.components);
            this.ilModuleIcon = new System.Windows.Forms.ImageList(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMainMenu = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.menuDeveloper = new DevExpress.XtraBars.BarButtonItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.btnSetSkin = new DevExpress.XtraBars.BarSubItem();
            this.barToolButtons = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.btnConnStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnRefreshCache = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.menuStripCloseForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.menuStripCloseForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilModule
            // 
            this.ilModule.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilModule.ImageStream")));
            this.ilModule.TransparentColor = System.Drawing.Color.Transparent;
            this.ilModule.Images.SetKeyName(0, "32_Stock.ico");
            // 
            // ilModuleIcon
            // 
            this.ilModuleIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilModuleIcon.ImageStream")));
            this.ilModuleIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilModuleIcon.Images.SetKeyName(0, "m1.ico");
            this.ilModuleIcon.Images.SetKeyName(1, "submodule.ico");
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.Controller = this.barAndDockingController1;
            this.xtraTabbedMdiManager1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xtraTabbedMdiManager1_MouseUp);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "16_CustomerQuery.ico");
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMainMenu,
            this.barToolButtons,
            this.bar3});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barMdiChildrenListItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barStaticItem1,
            this.btnLogout,
            this.btnAbout,
            this.btnSetSkin,
            this.menuDeveloper,
            this.btnRefreshCache,
            this.barStaticItem2,
            this.btnDoHelp,
            this.btnConnStatus});
            this.barManager1.MainMenu = this.barMainMenu;
            this.barManager1.MaxItemId = 17;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barMainMenu
            // 
            this.barMainMenu.BarName = "Main menu";
            this.barMainMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMainMenu.DockCol = 0;
            this.barMainMenu.DockRow = 0;
            this.barMainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSetSkin)});
            this.barMainMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMainMenu.OptionsBar.DrawDragBorder = false;
            this.barMainMenu.OptionsBar.UseWholeRow = true;
            this.barMainMenu.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "关于";
            this.barSubItem1.Glyph = global::CSFramework3.Main.Properties.Resources.cslogo16;
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAbout),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDeveloper)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "关于C/S开发框架";
            this.btnAbout.Glyph = global::CSFramework3.Main.Properties.Resources.cslogo16;
            this.btnAbout.Id = 7;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            // 
            // menuDeveloper
            // 
            this.menuDeveloper.Caption = "开发人员";
            this.menuDeveloper.Glyph = global::CSFramework3.Main.Properties.Resources._2009011340768021;
            this.menuDeveloper.Id = 11;
            this.menuDeveloper.Name = "menuDeveloper";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "窗口";
            this.barMdiChildrenListItem1.Glyph = global::CSFramework3.Main.Properties.Resources.childforms1;
            this.barMdiChildrenListItem1.Id = 1;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnSetSkin
            // 
            this.btnSetSkin.Caption = "设置皮肤";
            this.btnSetSkin.Glyph = global::CSFramework3.Main.Properties.Resources.skin16;
            this.btnSetSkin.Id = 10;
            this.btnSetSkin.Name = "btnSetSkin";
            this.btnSetSkin.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barToolButtons
            // 
            this.barToolButtons.BarName = "Tools";
            this.barToolButtons.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barToolButtons.DockCol = 0;
            this.barToolButtons.DockRow = 1;
            this.barToolButtons.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barToolButtons.OptionsBar.AllowQuickCustomization = false;
            this.barToolButtons.OptionsBar.DisableClose = true;
            this.barToolButtons.OptionsBar.DisableCustomization = true;
            this.barToolButtons.OptionsBar.DrawDragBorder = false;
            this.barToolButtons.OptionsBar.UseWholeRow = true;
            this.barToolButtons.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLogout, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnStatus, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefreshCache),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDoHelp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "登出(Logout)";
            this.btnLogout.Id = 5;
            this.btnLogout.ImageIndex = 0;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "帐套";
            this.barStaticItem2.Id = 14;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnConnStatus
            // 
            this.btnConnStatus.Caption = "连接状态";
            this.btnConnStatus.Id = 16;
            this.btnConnStatus.Name = "btnConnStatus";
            this.btnConnStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnRefreshCache
            // 
            this.btnRefreshCache.Caption = "更新缓存数据";
            this.btnRefreshCache.Id = 13;
            this.btnRefreshCache.Name = "btnRefreshCache";
            this.btnRefreshCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefreshCache_ItemClick);
            // 
            // btnDoHelp
            // 
            this.btnDoHelp.Caption = "帮助";
            this.btnDoHelp.Id = 15;
            this.btnDoHelp.Name = "btnDoHelp";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "C/S框架|www.csframework.com";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("4b327cf4-2932-4385-8dbd-9a7f7b53dde9");
            this.dockPanel1.Location = new System.Drawing.Point(0, 52);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 608);
            this.dockPanel1.Text = "模块列表(Modules List)";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 580);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 194;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(194, 580);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "关于C/S结构系统框架";
            this.barSubItem2.Id = 2;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "孙中吕(Jonny Sun)";
            this.barSubItem3.Id = 3;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // menuStripCloseForm
            // 
            this.menuStripCloseForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCloseThis,
            this.menuCloseAll});
            this.menuStripCloseForm.Name = "menuStripCloseForm";
            this.menuStripCloseForm.Size = new System.Drawing.Size(179, 48);
            // 
            // menuCloseThis
            // 
            this.menuCloseThis.Name = "menuCloseThis";
            this.menuCloseThis.Size = new System.Drawing.Size(178, 22);
            this.menuCloseThis.Text = "关闭当前窗体";
            this.menuCloseThis.Click += new System.EventHandler(this.menuCloseThis_Click);
            // 
            // menuCloseAll
            // 
            this.menuCloseAll.Name = "menuCloseAll";
            this.menuCloseAll.Size = new System.Drawing.Size(178, 22);
            this.menuCloseAll.Text = "除此之外全部关闭";
            this.menuCloseAll.Click += new System.EventHandler(this.menuCloseAll_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(898, 687);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = ".Net快速开发框架 - 主窗体";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.menuStripCloseForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        protected System.Windows.Forms.ImageList ilModuleIcon;
        private System.Windows.Forms.ImageList ilModule;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barToolButtons;
        private DevExpress.XtraBars.Bar barMainMenu;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarSubItem btnSetSkin;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraBars.BarButtonItem menuDeveloper;
        private DevExpress.XtraBars.BarButtonItem btnRefreshCache;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem btnDoHelp;
        private DevExpress.XtraBars.BarStaticItem btnConnStatus;
        private System.Windows.Forms.ContextMenuStrip menuStripCloseForm;
        private System.Windows.Forms.ToolStripMenuItem menuCloseThis;
        private System.Windows.Forms.ToolStripMenuItem menuCloseAll;
    }
}

