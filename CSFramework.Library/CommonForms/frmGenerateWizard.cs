using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSFramework.BLL;
using DevExpress.XtraEditors.Controls;
using CSFramework.Common;
using CSFramework3.Interfaces;

namespace CSFramework.Library
{

    /// <summary>
    /// 生成单据向导窗体
    /// </summary>
    public partial class frmGenerateWizard : Form
    {
        private List<IGenerateItem> _items;

        private bool _GenSuccess = false;//生成数据是否成功的标志

        private frmGenerateWizard()
        {
            InitializeComponent();
        }

        private IGenerateItem CurrentItem
        {
            get { return _items[rgItems.SelectedIndex]; }
        }

        public static void ExecuteWizard(List<IGenerateItem> items)
        {
            frmGenerateWizard form = new frmGenerateWizard();
            form.LoadItems(items);
            form.ShowDialog();
        }

        private void LoadItems(List<IGenerateItem> items)
        {
            _items = items;

            foreach (IGenerateItem item in items)
            {
                rgItems.Properties.Items.Add(new RadioGroupItem("N", item.ItemCaption));
            }

            rgItems.Height = 30 * items.Count;
            if (items.Count > 0) rgItems.SelectedIndex = 0;
        }

        private bool ValidateWizard()
        {
            //由其它单生成本单
            if (this.CurrentItem.IsDocNoRequired)
            {
                if (textEdit1.Text == "")
                {
                    Msg.Warning("请输入单据号码！");
                    textEdit1.Focus();
                    return false;
                }

                if (!this.CurrentItem.IsDocNoExists(textEdit1.Text))
                {
                    Msg.Warning("单据号码不存在！");
                    textEdit1.Focus();
                    return false;
                }

                this.CurrentItem.SetDocNo(textEdit1.Text); //设置单据号码
            }

            return true;
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (ValidateWizard())
            {
                //查找目标窗体是否打开
                Form targetForm = MdiTools.FindForm(this.CurrentItem.TargetFormType.FullName);

                if (targetForm == null) //没有打开目标窗体,程序自动打开
                {
                    IMdiForm mainForm = MdiTools.MdiMainForm as IMdiForm; //MDI主窗体                                        
                    targetForm = MdiTools.OpenChildForm(mainForm, this.CurrentItem.TargetFormType); //打开目标窗体
                }
                else
                {
                    if (!(targetForm is IBusinessSupportable))
                    {
                        Msg.Warning("不支持生成目标窗体的数据！");
                        return; //不是MDI子窗体，退出
                    }

                    if ((targetForm as IDataOperatable).DataChanged)
                    {
                        Msg.Warning("目标窗体 '" + this.CurrentItem.TargetFormName +
                            "' 正在修改数据！请保存或取消修改后才能生成！");
                        return;
                    }
                    targetForm.Activate(); //目标窗体已打开,激活显示
                }

                //调用目标窗体的新增方法
                (targetForm as IDataOperatable).DoAdd(null);

                //开始生成单据
                _GenSuccess = this.CurrentItem.Generate((targetForm as frmBaseBusinessForm).BLL);

                if (_GenSuccess)
                {
                    Msg.ShowInformation("生成单据成功,请修改相关数据然后保存！");
                    this.Close();
                    targetForm.Activate();//显示目标窗体
                }
                else
                {
                    Msg.ShowError("生成单据失败！");
                }
            }
        }

        private void rgItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDocNo.Visible = this.CurrentItem.IsDocNoRequired;
            if (pnlDocNo.Visible) textEdit1.Focus();
        }
    }
}
