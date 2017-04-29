using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using CSFramework.Tools.ClassGenerator;

namespace CSFramework.Tools.ClassGenerator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);//捕获系统所产生的异常。

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmClassGenerator());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "警告",
              MessageBoxButtons.OK,
              MessageBoxIcon.Hand,
              MessageBoxDefaultButton.Button1);
        }
    }
}