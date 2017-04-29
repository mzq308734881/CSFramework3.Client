///*************************************************************************/
///*
///* 文件名    ：Observers.cs                              
///* 程序说明  : 观察者定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CSFramework3.Interfaces;


namespace CSFramework.Core
{

    /// <summary>
    /// 观察用户是否关闭所有子窗体, 如果用户关闭了所有子窗体，显示MDI主窗体的按钮.
    /// </summary>
    public class ObserverCloseAllChild : IObserver
    {
        private Form _mdi = null;

        public ObserverCloseAllChild(Form mdi)
        {
            _mdi = mdi;
        }

        //如果用户关闭所有子窗体，显示MDI主窗体上的按钮
        public void Notify()
        {
            if (_mdi.MdiChildren.Length == 0)
            {
                (_mdi as IMdiForm).RegisterMdiButtons();
            }
            else if (_mdi.MdiChildren.Length == 1)
            {
                if (_mdi.MdiChildren[0] is IMdiChildForm)
                {
                    if ((_mdi.MdiChildren[0] as IMdiChildForm).IsClosing)
                        (_mdi as IMdiForm).RegisterMdiButtons();
                }
            }
        }
    }

    /// <summary>
    /// 观察当前子窗体,在MDI主窗体内显示子窗体的标题
    /// </summary>
    public class ObserverFormState : IObserver
    {
        ToolStripStatusLabel _label = null;
        private Form _mdi = null;

        public ObserverFormState(Form mdi, ToolStripStatusLabel label)
        {
            _mdi = mdi;
            _label = label;
        }

        public void Notify()
        {
            Form child = _mdi.ActiveMdiChild;

            if (child != null)
            {
                if (child is IMdiChildForm)
                {
                    if ((child as IMdiChildForm).IsClosing)
                        _label.Text = _mdi.Text;
                    else
                        _label.Text = child.Text;
                }
                else
                    _label.Text = child.Text;
            }
            else
                _label.Text = "没有打开子窗体.";
        }
    }

    /// <summary>
    /// 观察打个的窗体个数.
    /// </summary>
    public class ObserverOpenForms : IObserver
    {
        ToolStripStatusLabel _label = null;
        private Form _mdi = null;

        public ObserverOpenForms(Form mdi, ToolStripStatusLabel label)
        {
            _mdi = mdi;
            _label = label;
        }

        public void Notify()
        {
            //计算打开的子窗体个数，因Application.OpenForms.Count是所有打开的窗体数量，要减掉MDI主窗体.
            int count = Application.OpenForms.Count - 1;
            if (count < 0) count = 1;
            _label.Text = string.Format("共打开{0}个窗体", count);
        }
    }
}
