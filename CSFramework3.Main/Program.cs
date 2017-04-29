using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using CSFramework.Common;
using System.Diagnostics;
using CSFramework3.Business;
using DevExpress.UserSkins;
using DevExpress.Skins;
using CSFramework.Core;
using CSFramework3.Bridge;

/************************************************************************* 
 * 程序说明: 程序入口
 * 注意初始化程序的代码顺序!!! 
 * 作者：孙中吕
 **************************************************************************/

namespace CSFramework3.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);//捕获系统所产生的异常。
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            Program.CheckInstance();//检查程序是否运行多实例
            SystemConfig.ReadSettings(); //读取用户自定义设置

            if (false == BridgeFactory.InitializeBridge())//初始化桥接功能
            {
                Application.Exit();
                return;
            }

            BonusSkins.Register();//注册Dev酷皮肤
            OfficeSkins.Register();////注册Office样式的皮肤
            SkinManager.EnableFormSkins();//启用窗体支持换肤特性

            //注意：先打开登陆窗体,登陆成功后正式运行程序(MDI主窗体)            
            if (frmLogin.Login())
            {
                Program.MainForm.Show();
                Application.Run();
            }
            else//登录失败,退出程序
                Application.Exit();
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (SystemAuthentication.Current != null)
                SystemAuthentication.Current.Logout(); //登出
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Msg.ShowException(e.Exception);//处理系统异常
        }

        private static frmMain _mainForm = null;

        /// <summary>
        /// MDI主窗体
        /// </summary>        
        public static frmMain MainForm { get { return _mainForm; } set { _mainForm = value; } }

        /// <summary>
        ///检查程序是否运行多实例
        /// </summary>
        public static void CheckInstance()
        {
            Boolean createdNew; //返回是否赋予了使用线程的互斥体初始所属权
            Mutex instance = new Mutex(true, Globals.DEF_PROGRAM_NAME, out createdNew); //同步基元变量
            if (createdNew) //首次使用互斥体
            {
                instance.ReleaseMutex();
            }
            else
            {
                if (!SystemConfig.CurrentConfig.AllowRunMultiInstance)
                {
                    Msg.Warning("已经启动了一个程序，请先退出！");
                    Application.Exit();
                    return;
                }
            }
        }
    }
}