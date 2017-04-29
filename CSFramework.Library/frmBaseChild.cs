///*************************************************************************/
///*
///* 文件名    ：frmBaseChild.cs                              
///* 程序说明  : 所有MDI子窗体基类
///*              实现IMdiChildForm及ISystemButtons接口.frmBaseChild类非常重要，
///*              需要仔细研究该类在系统中的作用。
///
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
using CSFramework3.Interfaces;
using CSFramework.Common;
using CSFramework.Library;
using CSFramework.Core;

namespace CSFramework.Library
{
    /// <summary>
    /// 所有MDI子窗体基类.
    /// </summary>
    public partial class frmBaseChild : frmBase, IMdiChildForm, IPurviewControllable, ISystemButtons
    {
        /// <summary>
        /// 父窗体的Toolbar组件
        /// </summary>
        protected IToolbarRegister _ToolbarRegister = null; 

        /// <summary>
        /// 初始化子窗体的按钮数组
        /// </summary>
        protected IButtonList _buttons = new ButtonList();

        /// <summary>
        /// 子窗体的观察者
        /// </summary>
        protected IList _observers = new ArrayList();

        /// <summary>
        /// 子窗体的系统按钮
        /// </summary>
        protected IButtonInfo[] _SystemButtons = null;

        /// <summary>
        /// 窗体是否正在关闭状态
        /// </summary>
        protected bool _IsClosing = false; 

        /// <summary>
        /// 否只保留一个子窗体实例
        /// </summary>
        protected bool _AllowMultiInstatnce = false;

        /// <summary>
        /// 窗体的可用权限
        /// </summary>
        protected int _FormAuthorities = 0; 

        /// <summary>
        /// 打开窗体的菜单名
        /// </summary>
        protected string _FormMenuName = ""; 

        public frmBaseChild()
        {
            InitializeComponent();
        }

        #region IPurviewControllable 接口实现

        /// <summary>
        /// 窗体可用权限.为2^n方:1,2,4,8,16.....n^2
        /// 打开窗体时从数据库获取权限值保存在该变量
        /// </summary>
        public int FormAuthorities { get { return _FormAuthorities; } set { _FormAuthorities = value; } }

        /// <summary>
        ///  打开窗体的菜单名
        /// </summary>
        public string FormMenuName { get { return _FormMenuName; } set { _FormMenuName = value; } }

        /// <summary>
        /// 派生类通过重写该虚方法自定义每个按钮可用状态
        /// </summary>
        public virtual bool ButtonAuthorized(int authorityValue) { return false; }

        /// <summary>
        /// 系统是否只保留一个子窗体实例
        /// </summary>
        public bool AllowMultiInstatnce { get { return _AllowMultiInstatnce; } set { _AllowMultiInstatnce = value; } }

        /// <summary>
        /// 检查当前用户是否拥有本窗体的特定权限
        /// </summary>
        /// <param name="authorityValue">需要检查的权限值</param>
        /// <returns></returns>
        public bool HasPurview(int value)
        {
            return (value & _FormAuthorities) == value;
        }

        /// <summary>
        /// 可以通过外部调用该方法重新设置按钮权限.
        /// </summary>
        public virtual void SetButtonAuthority() { }

        #endregion

        #region IMdiChildForm 接口实现

        /// <summary>
        /// 主窗体的Toolbar按钮注册器
        /// </summary>
        public IToolbarRegister ToolbarRegister
        {
            get { return _ToolbarRegister; }
            set { _ToolbarRegister = value; }
        }

        public virtual void RegisterToolBar(IToolbarRegister toolBarRegister)
        {
            //this.Buttons是当前窗体的按钮数组。
            toolBarRegister.RegisteButton(this.Buttons.ToList());
        }

        /// <summary>
        /// 当前窗体是否正在关闭状态
        /// </summary>
        public bool IsClosing { get { return _IsClosing; } set { _IsClosing = value; } }

        /// <summary>
        /// 注册子窗体观察者
        /// </summary>        
        public void RegisterObserver(IObserver[] observers)
        {
            foreach (IObserver o in observers) _observers.Add(o);
        }

        /// <summary>
        /// 子窗体的按钮数组
        /// </summary>
        public IButtonList Buttons { get { return _buttons; } }

        /// <summary>
        /// 模板方法.初始化本窗体的按钮.
        ///  </summary>
        public virtual void InitButtons()
        {
            IButtonInfo[] bi = this.GetSystemButtons();
            _buttons.AddRange(bi);
        }

        /// <summary>
        /// 系统按钮列表。注：子窗体享用系统按钮，如帮助/关闭窗体常用功能。
        /// </summary>        
        public virtual IButtonInfo[] GetSystemButtons()
        {
            if (_SystemButtons == null)
            {
                _SystemButtons = new IButtonInfo[2];
                _SystemButtons[0] = this.ToolbarRegister.CreateButton("btnHelp", "帮助",
                    Globals.LoadBitmap("24_Help.ico"), new Size(57, 28), this.DoHelp);
                _SystemButtons[1] = this.ToolbarRegister.CreateButton("btnClose", "关闭",
                    Globals.LoadBitmap("24_Exit.ico"), new Size(57, 28), this.DoClose);
            }
            return _SystemButtons;
        }

        public virtual void DoHelp(IButtonInfo sender)
        {
            Msg.AskQuestion("帮助文档!");
        }

        public virtual void DoClose(IButtonInfo sender)
        {
            this.Close();
        }

        #endregion

        //当子窗体获得焦点时注册本窗体的按钮。
        //通过Form Activated事件可以看到主窗体的ToolBar状态变化。
        private void frmBaseChild_Activated(object sender, EventArgs e)
        {
            this.RegisterToolBar(this.ToolbarRegister);
            this.NotifyObserver(); //通过其它观察者
        }

        private void frmBaseChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotifyObserver(); //当关闭窗体，要通知所有子窗体观察者
        }

        //通知观察者进行更新
        private void NotifyObserver()
        {
            foreach (IObserver o in _observers) if (o != null) o.Notify();
        }

        private void frmBaseChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsClosing = true; //正在关闭状态
        }
    }
}