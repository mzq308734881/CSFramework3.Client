///*************************************************************************/
///*
///* 文件名    ：SkinTools.cs                            
///* 程序说明  : 设置皮肤工具
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using CSFramework.Common;
using CSFramework3.Interfaces;

namespace CSFramework.Library
{
    /// <summary>
    /// 设置皮肤工具
    /// </summary>
    public class SkinTools
    {
        private static BarSubItem _CurrentSkinList = null;

        /// <summary>
        /// 加载皮肤列表
        /// </summary>
        public static void LoadSkinList(BarSubItem owner)
        {
            _CurrentSkinList = owner;

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = new BarCheckItem(owner.Manager);
                item.Caption = skin.SkinName;
                item.Checked = skin.SkinName == SystemConfig.CurrentConfig.SkinName;
                item.ItemClick += new ItemClickEventHandler(OnSetSkinClick);
                owner.ItemLinks.Add(item);
            }
        }

        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnSetSkinClick(object sender, ItemClickEventArgs e)
        {
            SetSkin(e.Item.Caption);

            if (_CurrentSkinList != null)
            {
                foreach (BarItemLink item in _CurrentSkinList.ItemLinks)
                {
                    if (item.Item is BarCheckItem)
                        (item.Item as BarCheckItem).Checked = false;
                }
            }

            (e.Item as BarCheckItem).Checked = true;

            SystemConfig.CurrentConfig.SkinName = e.Item.Caption;
            SystemConfig.WriteSettings(SystemConfig.CurrentConfig);
        }

        /// <summary>
        /// 加载皮肤列表
        /// </summary>
        public static void LoadSkin(ComboBoxEdit owner)
        {
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                owner.Properties.Items.Add(skin.SkinName);
            }
        }

        private static void owner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBoxEdit).SelectedItem != null)
            {
                SetSkin((sender as ComboBoxEdit).SelectedItem.ToString());
            }
        }

        public static void SetSkin(string skinName)
        {
            //设置所有窗体的皮肤
            for (int i = 0; i < Application.OpenForms.Count - 1; i++)
            {
                Form form = Application.OpenForms[i];

                if (form is IFormBase) (form as IFormBase).SetSkin(skinName);
            }
        }
    }
}
