///*************************************************************************/
///*
///* 文件名    ：frmBaseDataDictionary.cs                              
///* 程序说明  : 数据字典窗体基类
///*               基础数据,如货币，产品定义，客户/供应商等基础数据。 
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
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CSFramework3.Business;
using CSFramework.Library;
using CSFramework.Common;
using CSFramework3.Interfaces;
using CSFramework3.Business.BLL_Base;
using System.ServiceModel;

namespace CSFramework.Library
{
    /// <summary>
    /// 数据字典窗体基类
    /// </summary>
    public partial class frmBaseDataDictionary : frmBaseDataForm
    {
        /// <summary>
        /// 数据字典业务逻辑
        /// </summary>
        protected bllBaseDataDict _BLL = new bllNullObjectDataDict(); //临时实例

        public frmBaseDataDictionary()
        {
            InitializeComponent();
        }

        public override bool ButtonAuthorized(int authorityValue)
        {
            if (authorityValue == ButtonAuthority.PRINT) //数据字典隐藏打印按钮
                return false;
            else
                return base.ButtonAuthorized(authorityValue);
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            this.SetDetailEditorsAccessable(_DetailGroupControl, this.DataChanged);

            //仅新增状态可修改主键输入框
            if (_KeyEditor != null) _KeyEditor.Enabled = UpdateType.Add == currentState;
        }

        /// <summary>
        /// 初始化操作
        /// </summary>
        protected override void InitializeForm()
        {
            if ((_SummaryView != null) && (_SummaryView.View is GridView))
            {
                GridView gridView = _SummaryView.View as GridView;

                frmGridCustomize.RegisterGrid(gridView);//注册表格配置功能
                DevStyle.SetGridControlLayout(gridView.GridControl, false);//设置表格样式
                DevStyle.SetSummaryGridViewLayout(gridView);

                gridView.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict
                this.BindingSummaryNavigator(controlNavigatorSummary, gridView.GridControl); //Summary导航条.
            }

            this.ShowSummary(); //下载显示数据.               
            this.ShowSummaryPage(true); //一切初始化完毕後显示SummaryPage        

            base.InitializeForm();
        }

        /// <summary>
        /// 显示数据字典, 一次性全部下载。
        /// </summary>
        protected void ShowSummary()
        {
            _BLL.GetSummaryData(true);//调用业务逻辑类的GetSummaryData()方法获取数据
            DoBindingSummaryGrid(_BLL.SummaryTable); //绑定主表的Grid
            ShowSummaryPage(true); //显示Summary页面. 
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        public override void DoAdd(IButtonInfo sender)
        {
            _BLL.CreateDataBinder(null);
            DoBindingSummaryEditor(_BLL.DataBinder); //绑定数据输入控件
            base.DoAdd(sender);
            ShowDetailPage(true);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public override void DoDelete(IButtonInfo sender)
        {
            AssertFocusedRow();//检查是否选择一条记录
            if (!Msg.AskQuestion("真的要删除?")) return;

            //调用业务逻辑类删除记录
            DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            bool b = _BLL.Delete(summary[_BLL.KeyFieldName].ToString());
            AssertEqual(b, true, "删除记录时发生错误!");

            base.DoDelete(sender);
            this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行
            if (_SummaryView.FocusedRowHandle < 0) //删除了最後一条记录. 显示Summary页面.
                ShowSummaryPage(true);
            else
            {
                _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                DoBindingSummaryEditor(_BLL.DataBinder); //显示主表记录详细资料                                                                            
                base.DoDelete(sender);
            }
        }

        /// <summary>
        /// 虚方法,用于绑定当前记录的数据到输入框
        /// </summary>
        /// <param name="dataBinder">数据源</param>
        protected virtual void DoBindingSummaryEditor(DataTable dataBinder) { }


        public override void DoEdit(IButtonInfo sender)
        {
            AssertFocusedRow();
            base.DoEdit(sender);
            DoViewContent(sender);
            ShowDetailPage(true);
        }

        /// <summary>
        /// 用户在Summary页选择一条记录. 显示当前记录的详细资料
        /// </summary>
        /// <param name="sender"></param>
        public override void DoViewContent(IButtonInfo sender)
        {
            AssertFocusedRow(); //检查有无记录.                
            _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
            base.DoViewContent(sender);
            DoBindingSummaryEditor(_BLL.DataBinder); //绑定数据输入控件
            ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
        }

        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
                base.DoCancel(sender);
        }

        public override void DoSave(IButtonInfo sender)
        {
            UpdateLastControl(); //更新最后一个输入控件的数据

            if (!ValidatingData()) return; //检查输入完整性

            //string key = _BLL.DataBinder.Rows[0][_BLL.KeyFieldName].ToString();
            //DataTable original = _BLL.GetDataByKey(key); //取保存前的原始数据

            bool ret = _BLL.Update(_UpdateType);//调用业务逻辑层的Update方法提交数据
            if (ret)
            {
                //只有修改状态才生成日志
                //if (_UpdateType == UpdateType.Modify) _BLL.WriteLog(original, _BLL.DataBinder); //保存修改日志

                this.UpdateSummaryRow(_BLL.DataBinder.Rows[0]); //刷新表格内的数据.                                    
                base.DoSave(sender);
                Msg.ShowInformation("保存成功!");
            }
            else
                Msg.Warning("保存失败!");
        }

        /// <summary>
        /// 检查输入完整性
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidatingData()
        {
            return false;
        }

    }
}