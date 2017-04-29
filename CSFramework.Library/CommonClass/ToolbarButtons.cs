///*************************************************************************/
///*
///* 文件名    ：ToolbarButtons.cs                           
///* 程序说明  : Toolbar自定义按钮
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CSFramework3.Interfaces;
using CSFramework.Common;

namespace CSFramework.Library
{

    #region DevExpress样式的按钮

    /// <summary>
    /// DevExpress按钮
    /// </summary>
    public class DevBarButtonInfo : IButtonInfo
    {
        private BarButtonItem _btn = null;
        private OnButtonClick _clickEvent = null;

        public DevBarButtonInfo(BarManager barManager, string name, string caption, Image image, OnButtonClick clickEvent)
        {
            _btn = new BarButtonItem(barManager, caption);
            _btn.Glyph = image;
            _btn.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            _btn.Name = name;
            _clickEvent = clickEvent;
            _btn.ItemClick += new ItemClickEventHandler(OnBarItemClick);
        }

        private void OnBarItemClick(object sender, ItemClickEventArgs e)
        {
            if (_clickEvent != null) _clickEvent(this);
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (_clickEvent != null) _clickEvent(this);
        }

        public string Name { get { return _btn.Name; } set { _btn.Name = value; } }
        private int _Authority = ButtonAuthority.NONE;
        public int Authority { get { return _Authority; } set { _Authority = value; } }

        public string Caption { get { return _btn.Caption; } set { _btn.Caption = value; } }
        public Image Image { get { return null; } set { } }

        public object Button { get { return _btn; } }
        public object Tag { get { return _btn.Tag; } set { _btn.Tag = value; } }

        private int _Index = -1;
        public int Index { get { return _Index; } set { _Index = value; } }

        public bool Enable { get { return _btn.Enabled; } set { _btn.Enabled = value; } }

        private bool _ErrorOccurred = false;
        public bool ErrorOccurred { get { return _ErrorOccurred; } set { _ErrorOccurred = value; } }
    }
    #endregion

    #region  .Net自带的ToolStripButton按钮

    /// <summary>
    /// .Net自带的ToolStripButton按钮
    /// </summary>
    internal class ToolStripButtonInfo : IButtonInfo
    {
        private ToolStripButton _btn = null;
        private OnButtonClick _clickEvent = null;

        public ToolStripButtonInfo(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent)
        {
            _btn = new ToolStripButton();
            _btn.Name = name;
            _btn.Image = image;
            _btn.Text = caption;
            _btn.Size = size;
            _btn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            _btn.ImageTransparentColor = System.Drawing.Color.Magenta;

            _clickEvent = clickEvent;
            _btn.Click += new EventHandler(OnClick);
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (_clickEvent != null) _clickEvent(this);
        }
        public string Name { get { return _btn.Name; } set { _btn.Name = value; } }
        private int _Authority = ButtonAuthority.NONE;
        public int Authority { get { return _Authority; } set { _Authority = value; } }

        public string Caption { get { return _btn.Text; } set { _btn.Text = value; } }
        public Image Image { get { return _btn.Image; } set { _btn.Image = value; } }

        public object Button { get { return _btn; } }

        public object Tag { get { return _btn.Tag; } set { _btn.Tag = value; } }

        private int _Index = -1;
        public int Index { get { return _Index; } set { _Index = value; } }

        public bool Enable { get { return _btn.Enabled; } set { _btn.Enabled = value; } }

        private bool _ErrorOccurred = false;
        public bool ErrorOccurred { get { return _ErrorOccurred; } set { _ErrorOccurred = value; } }
    }

    /// <summary>
    /// 按钮分隔符
    /// </summary>
    internal class ToolStripButtonSeperator : IButtonInfo
    {
        private ToolStripSeparator _btn = null;
        public ToolStripButtonSeperator()
        {
            _btn = new ToolStripSeparator();
        }
        public string Name { get { return _btn.Name; } set { _btn.Name = value; } }
        private int _Authority = ButtonAuthority.NONE;
        public int Authority { get { return _Authority; } set { _Authority = value; } }

        public string Caption { get { return ""; } set { } }
        public Image Image { get { return null; } set { } }

        public object Button { get { return _btn; } }
        public object Tag { get { return _btn.Tag; } set { _btn.Tag = value; } }
        private int _Index = -1;
        public int Index { get { return _Index; } set { _Index = value; } }

        private bool _Enable = true;
        public bool Enable { get { return _Enable; } set { _Enable = value; } }

        private bool _ErrorOccurred = false;
        public bool ErrorOccurred { get { return _ErrorOccurred; } set { _ErrorOccurred = value; } }
    }

    #endregion

    #region 我的自定义按钮

    /// <summary>
    /// 自定义按钮
    /// </summary>
    internal class MyButton : IButtonInfo
    {
        private Button _btn = null;
        private OnButtonClick _clickEvent = null;

        public MyButton(Control owner, string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent)
        {
            _btn = new Button();
            _btn.AutoSize = true;
            _btn.Name = name;
            _btn.Image = image;
            _btn.Text = caption;
            _btn.FlatStyle = FlatStyle.Flat;
            _btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            _clickEvent = clickEvent;
            _btn.Click += new EventHandler(OnClick);
            owner.Controls.Add(_btn);
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (_clickEvent != null) _clickEvent(this);
        }
        public string Name { get { return _btn.Name; } set { _btn.Name = value; } }
        private int _Authority = ButtonAuthority.NONE;
        public int Authority { get { return _Authority; } set { _Authority = value; } }

        public string Caption { get { return _btn.Text; } set { _btn.Text = value; } }
        public Image Image { get { return _btn.Image; } set { _btn.Image = value; } }

        public object Button { get { return _btn; } }
        public object Tag { get { return _btn.Tag; } set { _btn.Tag = value; } }
        private int _Index = -1;
        public int Index { get { return _Index; } set { _Index = value; } }

        public bool Enable { get { return _btn.Enabled; } set { _btn.Enabled = value; } }

        private bool _ErrorOccurred = false;
        public bool ErrorOccurred { get { return _ErrorOccurred; } set { _ErrorOccurred = value; } }
    }

    /// <summary>
    /// 按钮分隔符
    /// </summary>
    internal class MyButtonSeperator : IButtonInfo
    {
        private Button _btn = null;
        public MyButtonSeperator(Control owner)
        {
            _btn = new Button();
            _btn.Size = new Size(2, 20);
            _btn.FlatStyle = FlatStyle.Flat;
            owner.Controls.Add(_btn);
        }

        public int Authority { get { return ButtonAuthority.NONE; } set { } }

        public string Name { get { return _btn.Name; } set { _btn.Name = value; } }

        public string Caption { get { return ""; } set { } }
        public Image Image { get { return null; } set { } }

        public object Button { get { return _btn; } }

        public object Tag { get { return _btn.Tag; } set { _btn.Tag = value; } }

        private int _Index = -1;
        public int Index { get { return _Index; } set { _Index = value; } }

        private bool _Enable = true;
        public bool Enable { get { return _Enable; } set { _Enable = value; } }

        private bool _ErrorOccurred = false;
        public bool ErrorOccurred { get { return _ErrorOccurred; } set { _ErrorOccurred = value; } }
    }

    #endregion


}
