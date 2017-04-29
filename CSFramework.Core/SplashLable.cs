///*************************************************************************/
///*
///* 文件名    ：StatusLable.cs                              
///* 程序说明  : 加载模块时进度显示
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CSFramework.Common;

namespace CSFramework.Core
{
    /// <summary>
    /// 加载模块时进度显示
    /// </summary>
    public class LoadStatus : IMsg
    {
        private Label _lbl = null;
        public LoadStatus(Label lbl)
        {
            _lbl = lbl;
        }

        public void UpdateMessage(string msg)
        {
            _lbl.Text = msg;
            _lbl.Update();
        }
    }
}
