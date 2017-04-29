///*************************************************************************/
///*
///* 文件名    ：frmLogConfig.cs                   
///*
///* 程序说明  :Log字段配置窗体
///*
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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using CSFramework.Common;
using CSFramework.Core.Log;
using CSFramework.Library;
using DevExpress.XtraTreeList;
using CSFramework3.Business;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using CSFramework3.Business.BLL_Business;

namespace CSFramework.SystemModule
{

    /// <summary>
    /// Log字段配置窗体
    /// </summary>
    public partial class frmLogConfig : Form
    {
        private frmLogConfig()
        {
            InitializeComponent();
            this.LoadTreeList(this.treeWindows);// 加载窗体列表    
        }

        /// <summary>
        /// 加载窗体列表
        /// </summary>
        /// <param name="tree"></param>
        private void LoadTreeList(TreeList tree)
        {
            DataTable modules = CommonData.GetModules(); //取系统所有模块数据
            DataTable forms = CommonData.GetBusinessTables();//取系统所有业务数据表

            tree.BeginUnboundLoad();
            tree.Nodes.Clear();

            //创建模块根结点
            foreach (DataRow moduleRow in modules.Rows)
            {
                ItemObject itemModule = new ItemObject(moduleRow["ModuleName"].ToString(), moduleRow["ModuleID"]);
                TreeListNode moduleNode = tree.AppendNode(new object[] { itemModule }, null);
                moduleNode.Tag = itemModule;
                moduleNode.SelectImageIndex = 0;
                moduleNode.StateImageIndex = 0;

                //创建模块的窗体结点
                DataRow[] rows = forms.Select("ModuleID=" + moduleRow["ModuleID"].ToString());
                foreach (DataRow detailRow in rows)
                {
                    IList defs = new ArrayList();
                    ConfigDefine master = new ConfigDefine(detailRow["Table1"].ToString(), detailRow["Table1Name"].ToString()); //主表
                    defs.Add(master);

                    //增加明细结点                    
                    for (int i = 2; i <= 5; i++)
                    {
                        if (ConvertEx.ToString(detailRow["Table" + i.ToString()]) != "")
                        {
                            string detailName = detailRow["Table" + i.ToString() + "Name"].ToString();
                            string detailTable = detailRow["Table" + i.ToString()].ToString();
                            ConfigDefine detail = new ConfigDefine(detailTable, detailName);
                            defs.Add(detail);
                        }
                    }

                    ItemObject itemDetail = new ItemObject(detailRow["FormCaption"].ToString(), defs);
                    TreeListNode parentNode = tree.AppendNode(new object[] { detailRow["FormCaption"] }, moduleNode); //增加主表结点
                    parentNode.Tag = itemDetail;
                    parentNode.SelectImageIndex = 1;
                    parentNode.StateImageIndex = 1;
                }
            }

            tree.EndUnboundLoad();
            tree.ExpandAll();
        }

        /// <summary>
        /// 打开配置窗体
        /// </summary>
        public static void Execute(string windowName)
        {
            frmLogConfig form = new frmLogConfig();
            form.InitUI(null, windowName);
            form.ShowDialog();
        }

        //当移动结点时自动初始化当前业务数据的操作界面
        private void treeWindows_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag is ItemObject)
            {
                ItemObject item = e.Node.Tag as ItemObject;
                if (item.Value is IList)
                {
                    if (item.Tag != null)
                        this.InitUI(item.Tag as IList);
                    else
                    {
                        this.InitUI(item.Value as IList, "");
                        IList pages = new ArrayList();
                        foreach (XtraTabPage page in xtraTabControl1.TabPages)
                            pages.Add(page);
                        item.Tag = pages;//缓存的Page
                    }
                }
                else
                    xtraTabControl1.TabPages.Clear();
            }

        }

        /// <summary>
        /// 加载所有操作页面，单表只有一个TabPage,业务单据有多个(主表及明细表)
        /// </summary>
        /// <param name="pages"></param>
        private void InitUI(IList pages)
        {
            try
            {
                this.SuspendLayout();
                xtraTabControl1.TabPages.Clear();//清空
                foreach (ConfigPageData page in pages)
                    xtraTabControl1.TabPages.Add(page);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        //初始化界面
        private void InitUI(IList configDefList, string windowName)
        {
            try
            {
                this.SuspendLayout();
                xtraTabControl1.TabPages.Clear();//清空

                if (configDefList != null)
                {
                    foreach (ConfigDefine def in configDefList)
                    {
                        ConfigPageData page = this.LoadTabPage(def);
                        page.DoLoadData(); //显示数据
                    }
                }
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// 动态加载配置页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="displayName">显示名称</param>
        /// <returns></returns>
        private ConfigPageData LoadTabPage(ConfigDefine config)
        {
            string tableName = config.TableName;
            string displayName = config.TableDisplayName;

            //动态创建控件
            CheckedListBoxControl list = new CheckedListBoxControl();
            list.Dock = System.Windows.Forms.DockStyle.Fill;
            list.Location = new System.Drawing.Point(0, 0);
            list.Name = "list" + tableName;
            list.Size = new System.Drawing.Size(293, 270);
            list.Font = new Font("Courier New", 10);

            //动态创建控件
            ConfigPageData page = new ConfigPageData(tableName, list);
            page.Name = "page" + tableName;
            page.Size = new System.Drawing.Size(293, 270);
            page.Text = displayName;
            page.Controls.Add(list);

            this.xtraTabControl1.TabPages.Add(page);
            return page;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool success = true;
            foreach (ConfigPageData pageData in xtraTabControl1.TabPages)
            {
                success = success && pageData.DoSaveData(); //经典设计!!!保存数据
            }

            if (success) //全部保存成功
                MessageBox.Show("保存配置成功!");
            else
                MessageBox.Show("保存配置失败!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// 配置实体类定义
    /// </summary>
    public class ConfigDefine
    {
        private string _tableName;
        private string _tableDisplayName;

        public ConfigDefine(string tableName, string tableDisplayName)
        {
            _tableName = tableName;
            _tableDisplayName = tableDisplayName;
        }

        public string TableDisplayName { get { return _tableDisplayName; } }
        public string TableName { get { return _tableName; } }
    }

    /// <summary>
    /// 自定义的XtraTabPage控件
    /// </summary>
    public class ConfigPageData : XtraTabPage
    {
        private DataTable _fieldAll;
        private DataTable _fieldSelected;

        private string _tableName;
        private CheckedListBoxControl _fieldList;

        public ConfigPageData(string tableName, CheckedListBoxControl fieldList)
        {
            _tableName = tableName;
            _fieldList = fieldList;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool DoSaveData()
        {
            foreach (CheckedListBoxItem item in _fieldList.Items)
            {
                ItemObject o = item.Value as ItemObject;
                string fieldName = ConvertEx.ToString(o.Value);

                if (item.CheckState == CheckState.Checked)
                {
                    DataRow[] rows = _fieldSelected.Select("FieldName='" + fieldName + "'");
                    if (rows.Length == 0)//增加字段
                    {
                        DataRow row = _fieldSelected.NewRow();
                        row["TableName"] = _tableName;
                        row["FieldName"] = fieldName;
                        _fieldSelected.Rows.Add(row);
                    }
                }
                else if (item.CheckState == CheckState.Unchecked)
                {
                    DataRow[] rows = _fieldSelected.Select("FieldName='" + fieldName + "'");
                    if (rows.Length > 0) rows[0].Delete();//删除字段
                }
            }
            DataTable dt = _fieldSelected.GetChanges();
            if (dt == null)
                return true;//没有修改数据
            else
            {

                bool ret = bllBusinessLog.SaveFieldDef(dt);
                if (ret) _fieldSelected.AcceptChanges();
                return ret;
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void DoLoadData()
        {
            _fieldAll = CommonData.GetTableFieldsDef(_tableName, true);
            _fieldSelected = bllBusinessLog.GetLogFieldDef(_tableName);

            foreach (DataRow row in _fieldAll.Rows)
            {
                string name = row["FieldName"].ToString();
                string text = row["DisplayName"].ToString();
                string display = name.PadRight(22, char.Parse(" ")) + " - " + text;
                int i = _fieldList.Items.Add(new ItemObject(display, name)); // false=增加状态
                DataRow[] rows = _fieldSelected.Select("FieldName='" + name + "'");
                if (rows.Length > 0)
                    _fieldList.SetItemChecked(i, true);
                else
                    _fieldList.SetItemChecked(i, false);
            }
        }

    }

}
