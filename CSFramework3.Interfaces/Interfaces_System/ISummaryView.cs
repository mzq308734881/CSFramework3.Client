///*************************************************************************/
///*
///* 文件名    ：ISummaryView.cs                                
///* 程序说明  : 数据窗体主表资料显示视图
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces
{

    /// <summary>
    /// 数据窗体主表资料显示视图
    /// </summary>
    public interface ISummaryView
    {
        /// <summary>
        /// 记录数
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// 当前选中的资料行
        /// </summary>
        int FocusedRowHandle { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        object DataSource { get; set; }

        /// <summary>
        /// 关联的视图对象(如DataGridView,GridView,TreeView)
        /// </summary>
        object View { get; }

        /// <summary>
        /// 获取指定资料行
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        /// <returns></returns>
        DataRow GetDataRow(int rowHandle);

        /// <summary>
        /// 刷新数据源，重新显示数据
        /// </summary>
        void RefreshDataSource();

        /// <summary>
        /// 绑定双击事件
        /// </summary>
        /// <param name="eventHandler">事件</param>
        void BindingDoubleClick(EventHandler eventHandler);

        /// <summary>
        /// 设置焦点
        /// </summary>
        void SetFocus();

        /// <summary>
        /// 移动到第一条记录
        /// </summary>
        void MoveFirst();

        /// <summary>
        /// 移动到前一条记录
        /// </summary>
        void MovePrior();

        /// <summary>
        /// 移动到下一条记录
        /// </summary>
        void MoveNext();

        /// <summary>
        /// 移动到最后一条记录
        /// </summary>
        void MoveLast();

        /// <summary>
        /// 资料行索引是否有效
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        /// <returns></returns>
        bool IsValidRowHandle(int rowHandle);

        /// <summary>
        /// 刷新资料行的数据
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        void RefreshRow(int rowHandle);
    }
}
