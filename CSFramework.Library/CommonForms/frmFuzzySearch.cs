///*************************************************************************/
///*
///* 文件名    ：frmFuzzySearch.cs                              
///* 程序说明  : 数据字典模糊查询选择窗体
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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.Interfaces;

namespace CSFramework.Library
{
    /// <summary>
    /// 回调函数,当选择一个条记录后关闭窗体时调用
    /// </summary>
    /// <param name="resultRow">当前选择的条记</param>
    public delegate void SearchCallBack(DataRow resultRow);

    /// <summary>
    /// 数据字典模糊查询选择窗体
    /// </summary>
    public partial class frmFuzzySearch : frmBaseDialog
    {
        //打开查询窗体的业务逻辑层
        private IFuzzySearchSupportable _BLL;

        private DataRow _ReturnRow = null; //返回一条记录.

        //私有构造器
        private frmFuzzySearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开查询窗体
        /// </summary>
        /// <param name="Sender">事件发起人</param>
        /// <param name="callBack">回调函数,当选择一个条记录后关闭窗体时调用</param>
        public static void Execute(ButtonEdit Sender, IFuzzySearchSupportable BLL, SearchCallBack callBack)
        {
            frmFuzzySearch form = new frmFuzzySearch();
            form._BLL = BLL;
            form.txtValue.Text = Sender.Text;
            form.DoQuery(form.txtValue.Text);
            form.ShowDialog();
            if (callBack != null) callBack(form._ReturnRow);
        }

        /// <summary>
        ///  打开产品资料查询窗体．
        /// </summary>
        /// <returns></returns>
        public static DataRow Execute(IFuzzySearchSupportable BLL)
        {
            frmFuzzySearch form = new frmFuzzySearch();
            form._BLL = BLL;
            form.ShowDialog();
            return form._ReturnRow;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 关闭窗体返回当前选择的记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvSummary.FocusedRowHandle < 0) return;

                //返回当前选择的记录.
                _ReturnRow = gvSummary.GetDataRow(gvSummary.FocusedRowHandle);

                this.Close();
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        /// <summary>
        /// 搜索查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.DoQuery(txtValue.Text);
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="content">查询的内容</param>
        private void DoQuery(string content)
        {
            if (_BLL == null) throw new CustomException("没有指定业务层,无法执行查询!");

            try
            {
                btnQuery.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = _BLL.FuzzySearch(content);
                gvSummary.GridControl.DataSource = dt;
            }
            finally
            {
                btnQuery.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }
        
        /// <summary>
        /// 双击按钮关闭查询窗体并返回结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSummary_DoubleClick(object sender, EventArgs e)
        {
            if (gvSummary.RowCount > 0) btnOk.PerformClick();
        }
    }
}
