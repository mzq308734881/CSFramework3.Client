using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CSFramework3.Business;
using CSFramework.Common;

namespace _Tester
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Tester().TestConn();
            //SystemConfig.ReadSettings();
            //SqlConfiguration.SetConnection(); //读取SQL连接配置

            //Application.Run(new Form1());

            //string pwd = CEncoder.Encode("csframework");
        }
    }
}
