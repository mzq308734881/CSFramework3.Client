///*************************************************************************/
///*
///* 文件名    ：ToolbarRegister.cs                           
///* 程序说明  : MDI主窗体上的工具条按钮注册器
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using CSFramework3.Interfaces;
using DevExpress.XtraBars;

namespace CSFramework.Library
{
    /// <summary>
    /// .Net自带的工具条按钮注册器.
    /// </summary>
    public class ToolStripRegister : IToolbarRegister
    {
        private ToolStrip _toolStrip = null;
        private Form _Owner = null;

        public ToolStripRegister(Form owner)
        {
            _Owner = owner;
            _toolStrip = new ToolStrip();
            owner.Controls.Add(_toolStrip);
            owner.Controls.SetChildIndex(_toolStrip, 1);
        }

        public ToolStripRegister(Form owner, ToolStrip toolStrip)
        {
            _Owner = owner;
            _toolStrip = toolStrip;
        }

        public void RegisteButton(IList buttons)
        {
            _toolStrip.SuspendLayout();
            _toolStrip.Items.Clear();
            foreach (IButtonInfo bi in buttons)
            {
                ToolStripButton btn = bi.Button as ToolStripButton;
                _toolStrip.Items.Add(btn);
            }
            _toolStrip.ResumeLayout();
        }

        public void Dispose()
        {
            _Owner.Controls.Remove(_toolStrip);
        }

        public IButtonInfo CreateSeperator()
        {
            return new ToolStripButtonSeperator();
        }

        public IButtonInfo CreateButton(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent)
        {
            return new ToolStripButtonInfo(name, caption, image, size, clickEvent);
        }
    }

    /// <summary>
    /// DevExpress按钮注册器
    /// </summary>
    public class DevBarRegister : IToolbarRegister
    {
        private DevExpress.XtraBars.Bar _bar;
        private Form _Owner;

        public DevBarRegister(Form owner, Bar bar)
        {
            _Owner = owner;
            _bar = bar;
        }

        public void RegisteButton(IList buttons)
        {
            _bar.BeginUpdate();
            _bar.ItemLinks.Clear();
            foreach (IButtonInfo bi in buttons)
            {
                BarItem btn = bi.Button as BarItem;
                _bar.ItemLinks.Add(btn);
            }
            _bar.EndUpdate();
        }

        public void Dispose()
        {
            //
        }

        public IButtonInfo CreateSeperator()
        {
            return null;
        }

        public IButtonInfo CreateButton(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent)
        {
            return new DevBarButtonInfo(_bar.Manager, name, caption, image, clickEvent);
        }
    }

    /// <summary>
    /// 我的自定义工具栏
    /// </summary>
    public class MyToolbarRegister : IToolbarRegister
    {
        Panel _pnl = null;
        Form _owner = null;

        public MyToolbarRegister(Form owner)
        {
            _owner = owner;
            _pnl = new Panel();
            _pnl.Height = 36;
            _pnl.Dock = DockStyle.Top;
            owner.Controls.Add(_pnl);
            owner.Controls.SetChildIndex(_pnl, 1);
        }

        public void RegisteButton(IList buttons)
        {
            _pnl.SuspendLayout();

            _pnl.Controls.Clear();

            int top = 2;
            int left = 3;
            int margen = 4;
            foreach (IButtonInfo b in buttons)
            {
                Control ctl = b.Button as Control;
                ctl.Left = left;
                ctl.Top = top;
                _pnl.Controls.Add(ctl);
                left += ctl.Width + margen;
            }
            _pnl.ResumeLayout();
        }

        public void Dispose()
        {
            _owner.Controls.Remove(_pnl);
        }

        public IButtonInfo CreateSeperator()
        {
            return new MyButtonSeperator(_pnl);
        }

        public IButtonInfo CreateButton(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent)
        {
            return new MyButton(_pnl, name, caption, image, size, clickEvent);
        }
    }
}
