///*************************************************************************/
///*
///* 文件名    ：GenerateSortID.cs                              
///* 程序说明  : 自动生成明细表排序序号
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using CSFramework.Common;

namespace CSFramework.Library
{

    /// <summary>
    ///自动生成明细表排序序号 
    /// </summary>
    public class GenerateSortID
    {
        public readonly string DEF_FIRST_SORTING_PRIOR = "0.0";
        public readonly string DEF_SORTING_SEPRATOR = ".";
        public readonly string DEF_FIRST_SORTING = "1";//从1开始
        public readonly decimal DEF_STEP = (decimal)0.2; //步辐.
        public readonly int DEF_MAX_SORTING_LENGTH = 20;//生的在序号最大长度

        public GenerateSortID() { }

        /// <summary>
        /// 获取列的排序序号数组.
        /// </summary>
        /// <param name="view">表格控件</param>
        /// <param name="col">列</param>
        /// <returns></returns>
        public ArrayList GetMRUFilters(GridView view, GridColumn col)
        {
            ArrayList list = new ArrayList();
            try
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    object o = view.GetRowCellValue(i, col);
                    if (!list.Contains(o) && !o.ToString().Equals(string.Empty)) list.Add(o);
                }
                list.Sort(); //默认为Ascedent
                return list;
            }
            catch
            {
                return list;
            }
        }

        /// <summary>
        /// 获取最大的排序编号
        /// </summary>
        public int GetMaxSortingID(ArrayList sortingFilters)
        {
            try
            {
                sortingFilters.Sort();
                string str = ConvertEx.ToString(sortingFilters[sortingFilters.Count - 1]);
                string[] arr = str.Split(Convert.ToChar(DEF_SORTING_SEPRATOR));
                return Convert.ToInt16(arr[0]);
            }
            catch
            {
                return int.Parse(DEF_FIRST_SORTING);
            }
        }

        /// <summary>
        /// 生成一个新的排序编号
        /// </summary>
        /// <param name="currSortingID">当前行的Sort编号</param>
        /// <param name="prevSortingID">前一行的Sort编号</param>
        public string GetNewSortingID(string currSortingID, string prevSortingID)
        {
            try
            {
                if (prevSortingID == null) prevSortingID = DEF_FIRST_SORTING_PRIOR;
                decimal prefix = decimal.Parse(prevSortingID);
                decimal curr = decimal.Parse(currSortingID);
                decimal newid = (curr - prefix) / 2 + prefix;
                string ret = newid.ToString();
                return ret.Replace("5", "4");
            }
            catch
            {
                return currSortingID;
            }
        }

        /// <summary>
        /// 生成排序字符串.
        /// Insert方法生成规则,假设当前记录为n:
        /// Append方法生成规则:生成的排序字符串为max(n)+1
        /// </summary>
        public string Generate(GridView view, GridColumn sortingColumn)
        {
            try
            {
                ArrayList list = GetMRUFilters(view, sortingColumn);
                if (view.RowCount <= 0) return DEF_FIRST_SORTING; //设置默认排序ID
                int pos = view.FocusedRowHandle;
                int value = 0;
                if (pos < 0) //没有当前记录. 以Append方式生成排序字符串
                {
                    value = GetMaxSortingID(list);
                    return value.ToString() + DEF_SORTING_SEPRATOR;
                }
                else if (pos == view.RowCount - 1) // 视为Append.
                {
                    string currID = view.GetRowCellValue(pos, sortingColumn).ToString();
                    decimal append = decimal.Parse(currID) + DEF_STEP;
                    return append.ToString();
                }
                else
                {
                    object currobj = view.GetRowCellValue(pos, sortingColumn);
                    //Sorting最大长度为20. 如果生成的SortingID大於20.则取当前的SortingID
                    if (currobj.ToString().Length >= DEF_MAX_SORTING_LENGTH) return currobj.ToString();
                    object preobj = view.GetRowCellValue(pos - 1, sortingColumn);
                    if (ConvertEx.ToString(preobj) == "") preobj = (object)0; //如果当前记录是第一条, 那麽上一条记录为0.
                    return GetNewSortingID(currobj.ToString(), preobj.ToString());
                }
            }
            catch
            {
                return DEF_FIRST_SORTING;
            }
        }

    }
}
