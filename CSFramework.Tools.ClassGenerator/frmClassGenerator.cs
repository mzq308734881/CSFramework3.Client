///*************************************************************************/
///*
///* 文件名    ：frmClassGenerator.cs                   
///* 程序说明  : 快速开发框架的代码生成器,用于生成ORM,BLL,DAL,和部分窗体代码
///* 原创作者  ：孙中吕 
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
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.LookAndFeel;
using CSFramework.ORM;
using CSFramework.Common;

namespace CSFramework.Tools.ClassGenerator
{
    /// <summary>
    /// 快速开发框架的代码生成器主窗体
    /// </summary>
    public partial class frmClassGenerator : XtraForm
    {
        public DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;

        public frmClassGenerator()
        {
            InitializeComponent();

            DefaultLookAndFeel = new DefaultLookAndFeel();
            DefaultLookAndFeel.LookAndFeel.SkinName = "Pumpkin";//皮肤
        }

        private void frmClassGenerator_Load(object sender, EventArgs e)
        {
            this.LookAndFeel.SetSkinStyle("Pumpkin");//皮肤

            txtSolutionFolder_EditValueChanged(txtSolutionFolder, new EventArgs());

            tabControl2.SelectedTabPageIndex = 0;
        }

        /// <summary>
        /// 选择的物理表名
        /// </summary>
        private string SelectedTableName
        {
            get
            {
                return lbxTables.SelectedItem.ToString();
            }
        }

        private void btnGetStuct_Click(object sender, EventArgs e)
        { //取表结构
            try
            {
                DataTable dtColumns = ORMTools.GetTableStructure(txtConnString.Text, this.SelectedTableName);
                DataTable result = ORMTools.CreateMapList(dtColumns, cbxDbType.Checked);

                gcStuct.DataSource = null;
                gcStuct.DataSource = result;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            //生成实体类
            if (txtPrimaryKey.Text == "")
            {
                MessageBox.Show("主键不能为空!");
                txtPrimaryKey.Focus();
                return;
            }

            //生成器实例-GenerateObjectClass
            IClassGenerator generator = new GenerateObjectClass(chkGenFields.Checked);

            //生成代码
            string code = generator.Generate(txtSpaceName.Text, txtClassName.Text, txtComment.Text,
                this.SelectedTableName, txtPrimaryKey.Text, chkSummaryTable.Checked, gcStuct.DataSource as DataTable);

            //显示生成的代码
            if (chkPreviewCode.Checked) this.ShowCode(code);

            //输出cs文件
            if (chkExportToFileORM.Checked)
            {
                string fileName = txtOutpup_ORM.Text + txtClassName.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        private void btnTableFields_Click(object sender, EventArgs e)
        {
            if (txtPrimaryKey.Text == "")
            {
                MessageBox.Show("主键不能为空!");
                txtPrimaryKey.Focus();
                return;
            }

            //创建类生成器实例-GenerateTableFields
            IClassGenerator generator = new GenerateTableFields();

            //生成代码
            string code = generator.Generate(txtSpaceName.Text, txtClassName.Text, txtComment.Text,
                 this.SelectedTableName, txtPrimaryKey.Text, chkSummaryTable.Checked, gcStuct.DataSource as DataTable);

            //显示生成的代码
            if (chkPreviewCode.Checked) this.ShowCode(code);

            //输出cs文件
            if (chkExportToFileORM.Checked)
            {
                string fileName = txtOutpup_ORM.Text + txtClassName.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        //显示代码
        private void ShowCode(string code)
        {
            txtCode.Text = code;
            tabControl2.SelectedTabPageIndex = 3;
        }

        private void lbxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = lbxTables.SelectedItem.ToString();
            if (s.IndexOf("tb_") < 0)
                txtClassName.Text = "tb_" + s;
            else
                txtClassName.Text = s;

            //显示注释
            txtComment.Text = "ORM模型, 数据表:" + s + ",由ClassGenerator自动生成";
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            try
            {
                //获取用户表和视图
                DataTable dt = ORMTools.GetU_V(txtConnString.Text);

                if (dt.Rows.Count > 0)
                {
                    lbxTables.Properties.Items.Clear();

                    //显示表名
                    foreach (DataRow dr in dt.Rows)
                        lbxTables.Properties.Items.Add(dr["name"]);

                    if (lbxTables.Properties.Items.Count > 0) lbxTables.SelectedIndex = 0;
                    lbxTables.ShowPopup();
                }
                else
                {
                    MessageBox.Show("当前数据库没有用户表和视图!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);

            MessageBox.Show("已经复制到剪贴板!");
        }

        private void btnSaveCS_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.OverwritePrompt = true;
            dlg.Filter = "C# Class Library (*.cs)|*.cs";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, txtCode.Text, Encoding.UTF8);
                MessageBox.Show("保存文件成功!\r\n\r\n" + dlg.FileName);
            }
        }

        private void btnGenBLLDataDict_Click(object sender, EventArgs e)
        {
            if (false == Msg.AskQuestion("确认要生成吗?")) return;

            //创建参数对象
            Params4DataDictBLL param = new Params4DataDictBLL();
            param.BLL_Name = txtBLL.Text;
            param.BLL_Namespace = txtBllNamespace.Text;
            param.ConcretelyName = txtConcretelyName.Text;
            param.DAL_Name = txtDAL.Text;
            param.ORM_Name = txtORM.Text;
            param.UsingNamespace = txtUsingNamespace.Lines;

            //生成源码
            string code = new GenerateBLL().GenerateDataDictBLL(param);

            //显示代码
            if (chkPreviewBLL.Checked) this.ShowCode(code);

            //输出.cs文件
            if (chkExportToFileBLL.Checked)
            {
                string fileName = txtOutpup_BLL_DataDict.Text + txtBLL.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        private void btnGenBLLBusiness_Click(object sender, EventArgs e)
        {
            if (false == Msg.AskQuestion("确认要生成吗?")) return;

            //创建参数对象
            Params4BusinessBLL param = new Params4BusinessBLL();
            param.BLL_Name = txtBLL.Text;
            param.BLL_Namespace = txtBllNamespace.Text;
            param.ConcretelyName = txtConcretelyName.Text;
            param.DAL_Name = txtDAL.Text;
            param.ORM_Name = txtORM.Text;
            param.UsingNamespace = txtUsingNamespace.Lines;
            param.BusinessFormName = txtFormName.Text;
            param.SupportBusinessLog = chkBusinessLog.Checked;

            //生成源码
            string code = new GenerateBLL().GenerateBusinessBLL(param);

            //显示代码
            if (chkPreviewBLL.Checked) this.ShowCode(code);

            //输出.cs文件
            if (chkExportToFileBLL.Checked)
            {
                string fileName = txtOutpup_BLL_Business.Text + txtBLL.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        private void btnGenDALDataDict_Click(object sender, EventArgs e)
        {
            if (false == Msg.AskQuestion("确认要生成吗?")) return;

            //创建参数对象
            Params4DataDictDAL param = new Params4DataDictDAL();
            param.ConcretelyName = txtConcretelyName_DAL.Text;
            param.DAL_Name = txtDAL_DAL.Text;
            param.ORM_Name = txtORM_DAL.Text;
            param.DAL_Namespace = txtNamespace_DAL.Text;
            param.UsingNamespace = txtUsingNamespace_DAL.Lines;

            //生成源码
            string code = new GenerateDAL().GenerateDataDictDAL(param);

            //显示代码
            if (chkPreviewDAL.Checked) this.ShowCode(code);

            //输出.cs文件
            if (chkExportToFileDAL.Checked)
            {
                string fileName = txtOutpup_DAL_DataDict.Text + txtDAL_DAL.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        private void btnGenDALBusiness_Click(object sender, EventArgs e)
        {
            if (false == Msg.AskQuestion("确认要生成吗?")) return;

            Params4BusinessDAL param = new Params4BusinessDAL();
            param.ConcretelyName = txtConcretelyName_DAL.Text;
            param.DAL_Name = txtDAL_DAL.Text;
            param.ORM_Name = txtORM_DAL.Text;
            param.DAL_Namespace = txtNamespace_DAL.Text;
            param.UsingNamespace = txtUsingNamespace_DAL.Lines;

            //生成源码
            string code = new GenerateDAL().GenerateBusinessDAL(param);
            if (chkPreviewDAL.Checked) this.ShowCode(code);

            //输出cs文件
            if (chkExportToFileDAL.Checked)
            {
                string fileName = txtOutpup_DAL_Business.Text + txtDAL_DAL.Text + ".cs";
                File.WriteAllText(fileName, code, Encoding.UTF8);
                MessageBox.Show("输出文件:" + fileName);
            }
        }

        //输入具体名称自动组合BLL,DAL,ORM的类名
        private void txtConcretelyName_EditValueChanged(object sender, EventArgs e)
        {
            txtBLL.Text = "bll" + txtConcretelyName.Text;
            txtDAL.Text = "dal" + txtConcretelyName.Text;
            txtORM.Text = "tb_" + txtConcretelyName.Text;
        }

        //输入具体名称自动组合DAL,ORM的类名
        private void txtConcretelyName_DAL_EditValueChanged(object sender, EventArgs e)
        {
            txtDAL_DAL.Text = "dal" + txtConcretelyName_DAL.Text;
            txtORM_DAL.Text = "tb_" + txtConcretelyName_DAL.Text;
        }

        //输入项目路径自动组合BLL,DAL,ORM的源码路径
        private void txtSolutionFolder_EditValueChanged(object sender, EventArgs e)
        {
            txtOutpup_ORM.Text = txtSolutionFolder.Text + @"\CSFramework3.Models\";
            txtOutpup_BLL_DataDict.Text = txtSolutionFolder.Text + @"\CSFramework3.Business\BLL_DataDict\";
            txtOutpup_BLL_Business.Text = txtSolutionFolder.Text + @"\CSFramework3.Business\BLL_Business\";
            txtOutpup_DAL_DataDict.Text = txtSolutionFolder.Text + @"\CSFramework3.Server.DataAccess\DAL_DataDict\";
            txtOutpup_DAL_Business.Text = txtSolutionFolder.Text + @"\CSFramework3.Server.DataAccess\DAL_Business\";
        }

    }
}