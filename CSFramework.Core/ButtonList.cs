///*************************************************************************/
///*
///* 文件名    ：ButtonList.cs                                
///* 程序说明  : 窗体的按钮列表.
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CSFramework3.Interfaces;
using System.Drawing;

namespace CSFramework.Core
{
    /// <summary>
    /// 窗体的按钮列表
    /// </summary>
    public class ButtonList : IButtonList
    {
        private IList _Buttons = new ArrayList();

        /// <summary>
        ///  添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象数组</param>
        public void AddRange(IButtonInfo[] buttons)
        {
            foreach (IButtonInfo btn in buttons) if (btn != null) this._Buttons.Add(btn);
        }

        /// <summary>
        /// 添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象集合</param>
        public void AddRange(IList buttons)
        {
            foreach (IButtonInfo btn in buttons) if (btn != null) this._Buttons.Add(btn);
        }

        /// <summary>
        /// 跟据名称获取某个按钮
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        public IButtonInfo GetButtonByName(string name)
        {
            foreach (IButtonInfo b in _Buttons)
                if (b.Name == name) return b;
            return new NullButton();
        }

        /// <summary>
        /// 转换为按钮数组
        /// </summary>
        /// <returns></returns>
        public IButtonInfo[] ToArray()
        {
            IButtonInfo[] ret = new IButtonInfo[_Buttons.Count];
            for (int i = 0; i <= _Buttons.Count - 1; i++)
                ret[i] = (IButtonInfo)_Buttons[i];
            return ret;
        }

        /// <summary>
        /// 转换为按钮对象集合
        /// </summary>
        /// <returns></returns>
        public IList ToList()
        {
            return _Buttons;
        }
    }

    /// <summary>
    /// 引用NullObject模式,避免程序因访问null对象引发异常
    /// </summary>
    public class NullButton : IButtonInfo
    {
        #region IButtonInfo 成員

        public string Name { get { return ""; } set { } }
        public string Caption { get { return ""; } set { } }
        public Image Image { get { return null; } set { } }
        public int Index { get { return 0; } set { } }
        public object Button { get { return null; } set { } }
        public bool Enable { get { return false; } set { } }
        public int Authority { get { return 0; } set { } }
        public object Tag { get { return null; } set { } }
        public bool ErrorOccurred { get { return false; } set { } }
        #endregion
    }
}
