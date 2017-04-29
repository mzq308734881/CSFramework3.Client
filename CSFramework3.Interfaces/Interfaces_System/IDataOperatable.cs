///*************************************************************************/
///*
///* 文件名    ：IDataOperatable.cs                                
///* 程序说明  : 支持数据操作的接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Common;
using CSFramework.Common;

namespace CSFramework3.Interfaces
{
    /// <summary>
    ///  支持数据操作的接口
    /// </summary>
    public interface IDataOperatable
    {
        /// <summary>
        /// 返回数据操作窗体的按钮
        /// </summary>
        /// <returns></returns>
        IButtonInfo[] GetDataOperatableButtons();

        /// <summary>
        /// 查看/显示数据
        /// </summary>
        /// <param name="button"></param>
        void DoViewContent(IButtonInfo button);//查看数据

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="button"></param>
        void DoAdd(IButtonInfo button);

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="button"></param>
        void DoEdit(IButtonInfo button);

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="button"></param>
        void DoCancel(IButtonInfo button);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="button"></param>
        void DoSave(IButtonInfo button);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="button"></param>
        void DoDelete(IButtonInfo button);

        /// <summary>
        /// 当前操作状态
        /// </summary>
        UpdateType UpdateType { get; }

        /// <summary>
        /// 是否修改了数据
        /// </summary>
        bool DataChanged { get; }

        /// <summary>
        /// 是否允许数据操作
        /// </summary>
        bool AllowDataOperate { get; set; }
    }
}
