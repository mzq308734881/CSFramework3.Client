///*************************************************************************/
///*
///* 文件名    ：ModuleLoader.cs                                
///* 程序说明  : 模块加载器
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using CSFramework.Common;
using CSFramework.Core;
using CSFramework3.Interfaces;

namespace CSFramework.Core
{
    #region 模块装载器

    /// <summary>
    /// 加载模块管理类(Load Module Manager)
    /// </summary>
    public class ModuleLoaderBase
    {
        /// <summary>
        /// 模块文件扩展名
        /// </summary>
        public static readonly string MODULE_FILTER = "模块文件 Modules|*.dll";

        /// <summary>
        /// 模块文件名(DLL文件外)
        /// </summary>
        protected string _ModuleFileName;

        /// <summary>
        /// 如果加载了模块. 返回该模块的主窗体对象.
        /// </summary>
        protected IModuleBase _ModuleMainForm;

        /// <summary>
        /// 模块所在的程序集
        /// </summary>
        protected Assembly _ModuleAssembly;

        /// <summary>
        /// 模块文件所在路径
        /// </summary>
        public static readonly string MODULE_PATH = Application.StartupPath;

        /// <summary>
        /// 模块所在的程序集
        /// </summary>
        public Assembly ModuleAssembly
        {
            get { return _ModuleAssembly; }
        }

        /// <summary>
        /// 返回AssemblyModuleEntry，自定义模块特性
        /// </summary>
        public string GetCurrentModuleName()
        {
            return ModuleLoaderBase.GetModuleEntry(_ModuleAssembly).ModuleName;
        }

        /// <summary>
        /// 模块主窗体
        /// </summary>
        public IModuleBase ModuleMainForm
        {
            get { return _ModuleMainForm; }
        }

        ///// <summary>
        ///// 加载模块的菜单
        ///// </summary>
        ///// <param name="menuStrip">程序主窗体的菜单</param>
        //public virtual void LoadMenu(MenuStrip moduleMenus)
        //{
        //    MenuStrip currentMenu = _ModuleMainForm.GetModuleMenu();
        //    if ((currentMenu == null) || (currentMenu.Items.Count == 0)) return;

        //    if (_ModuleMainForm != null)
        //    {
        //        int startIndex = moduleMenus.Items.Count == 0 ? 0 : moduleMenus.Items.Count;
        //        moduleMenus.Items.Insert(startIndex, _ModuleMainForm.GetModuleMenu().Items[0]);
        //    }
        //}

        /// <summary>
        /// 加载模块的菜单(支持一个模块内有多个顶级菜单)
        /// </summary>
        /// <param name="menuStrip">程序主窗体的菜单</param>
        public virtual void LoadMenu(MenuStrip moduleMenus)
        {
            MenuStrip moduleMenu = _ModuleMainForm.GetModuleMenu();//当前模块的菜单
            if ((moduleMenu == null) || (moduleMenu.Items.Count == 0)) return;

            if (_ModuleMainForm != null)
            {                
                while (moduleMenu.Items.Count > 0)//加载所有顶级菜单
                {
                    int startIndex = moduleMenus.Items.Count == 0 ? 0 : moduleMenus.Items.Count;
                    moduleMenus.Items.Insert(startIndex, moduleMenu.Items[0]);
                }
            }
        }

        /// <summary>
        /// 加载模块主方法
        /// </summary>
        /// <param name="moduleinfo">模块信息</param>
        /// <returns></returns>
        public virtual bool LoadModule(ModuleInfo moduleinfo)
        {
            _ModuleFileName = moduleinfo.ModuleFile;
            _ModuleAssembly = moduleinfo.ModuleAssembly;
            string entry = GetModuleEntryNameSpace(_ModuleAssembly);
            if (string.Empty == entry) return false;

            Form form = (Form)_ModuleAssembly.CreateInstance(entry);
            _ModuleMainForm = null;

            if (form is IModuleBase) _ModuleMainForm = (IModuleBase)form;

            return _ModuleMainForm != null;
        }

        /// <summary>        
        /// 获取模块列表，转换为ModuleInfo集合.
        /// </summary>        
        public virtual IList<ModuleInfo> GetModuleList()
        {
            try
            {
                string[] files = null; //模块文件(*.dll)
                IList<ModuleInfo> list = new List<ModuleInfo>();

                if (Directory.Exists(MODULE_PATH))
                    files = Directory.GetFiles(MODULE_PATH, "*.dll");

                foreach (string mod in files)
                {
                    Assembly asm = null;
                    try
                    {
                        //.net framework dll
                        asm = Assembly.LoadFile(mod);
                    }
                    catch { continue; }

                    ModuleID id = GetModuleID(asm);
                    string name = GetCurrentModuleName();
                    if (id != ModuleID.None)
                    {
                        ModuleInfo m = new ModuleInfo(asm, id, name, mod);
                        list.Add(m);
                    }
                }

                SortModule(list); //模块排序.

                return list;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return null;
            }
        }

        /// <summary>
        /// 获取程序集自定义特性。
        /// </summary>
        /// <returns></returns>
        public AssemblyModuleEntry GetModuleEntry()
        {
            return ModuleLoaderBase.GetModuleEntry(_ModuleAssembly);
        }

        /// <summary>
        /// 判断加载的文件是否模块文件，因目录下可能有不同类别的DLL文件。
        /// 判断DLL文件是否框架模块通过检查Assembly特性。
        /// </summary>
        public bool IsModuleFile(string moduleFile)
        {
            try
            {
                Assembly asm = Assembly.LoadFile(moduleFile);
                return (ModuleLoaderBase.GetModuleID(asm) != ModuleID.None);
            }
            catch { return false; }
        }

        /// <summary>
        /// 每一个模块对应一个TabPage, 将模块主窗体的Panel容器放置在TabPage内。
        /// 因此，所有加载的模块主窗体的Panel容器都嵌套在主窗体的TabControl内。
        /// </summary>
        public virtual void LoadGUI(object mainTabControl) { }

        /// <summary>
        /// 模块排序
        /// </summary>
        /// <param name="list"></param>
        public virtual void SortModule(IList<ModuleInfo> list)
        {
            int i, j;
            ModuleInfo temp;
            bool done = false;
            j = 1;
            while ((j < list.Count) && (!done))
            {
                done = true;
                for (i = 0; i < list.Count - j; i++)
                {
                    if ((list[i] as ModuleInfo).ModuleID > (list[i + 1] as ModuleInfo).ModuleID)
                    {
                        done = false;
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            }
        }

        #region 类公共静态方法

        /// <summary>
        /// 查找子菜单，深度搜索
        /// </summary>
        public static ToolStripMenuItem GetMenuItem(ToolStrip mainMenu, string menuName)
        {
            ToolStripItem[] items = mainMenu.Items.Find(menuName, true);
            if (items.Length > 0 && items[0] is ToolStripMenuItem)
                return (ToolStripMenuItem)items[0];
            else
                return null;
        }

        /// <summary>
        /// 获取程序集自定义特性。是否用户自定义模块由AssemblyModuleEntry特性确定。
        /// </summary>
        public static AssemblyModuleEntry GetModuleEntry(Assembly asm)
        {
            AssemblyModuleEntry temp = new AssemblyModuleEntry(ModuleID.None, "", "");
            if (asm == null) return temp;

            object[] list = asm.GetCustomAttributes(typeof(AssemblyModuleEntry), false);
            if (list.Length > 0)
                return (AssemblyModuleEntry)list[0];
            else
                return temp;
        }

        /// <summary>
        /// 获取模块主窗体名字空间
        /// </summary>
        public static string GetModuleEntryNameSpace(Assembly asm)
        {
            return GetModuleEntry(asm).ModuleEntryNameSpace;
        }

        /// <summary>
        /// 获取模块编号
        /// </summary>
        public static ModuleID GetModuleID(Assembly asm)
        {
            return ModuleLoaderBase.GetModuleEntry(asm).ModuleID;
        }

        #endregion

        /// <summary>
        /// 判断当前用户是否有该模块的权限
        /// </summary>
        /// <param name="userPermissions">用户权限</param>
        /// <returns></returns>
        public bool CanAccessModule(DataTable userRights)
        {
            if (Loginer.CurrentUser.IsAdmin()) return true;
            MenuStrip mainMenu = _ModuleMainForm.GetModuleMenu();
            DataRow[] rows = userRights.Select(string.Format("AuthorityID='{0}'", mainMenu.Items[0].Name));
            return rows != null && rows.Length > 0;
        }

        /// <summary>
        /// 程序集对象引用置空，优化GC回收内存
        /// </summary>
        public void ClearAssemble()
        {
            _ModuleAssembly = null;
            _ModuleMainForm = null;
        }
    }

    #endregion

}
