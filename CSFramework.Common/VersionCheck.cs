///*************************************************************************/
///*
///* 文件名    ：VersionCheck.cs                                   
///* 程序说明  : 版本检测工具
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using CSFramework.Common;

namespace CSFramework.Common
{

    /// <summary>
    /// 版本检测工具
    /// </summary>
    public class VersionCheck
    {
        private const string Arg_CheckVersion = "CheckVersion";// 主程序调用升级程序检查是否有版本更新
        private const string Arg_MainEXECall = "MainEXECall";// 主程序调用升级程序
        private const string UpgraderProgram = "CSFramework3.AutoUpgrade.exe"; //升级程序文件名

        /// <summary>
        /// 检查版本
        /// </summary>
        /// <param name="AppExit">退出应用程序</param>
        public static void CheckVersion(ref bool AppExit)
        {
            AppExit = false;

            string checkResultFile = Application.StartupPath + "\\" + Guid.NewGuid().ToString().Replace("-", "") + ".ver"; //临时文件            
            string upgrader = Application.StartupPath + "\\" + UpgraderProgram;

            File.WriteAllText(checkResultFile, ""); //创建空文件

            checkResultFile = ShellPathNameConvert.ToShortPathName(checkResultFile); //转换为DOS文件名

            Process pro = new Process();
            pro.StartInfo = new ProcessStartInfo(upgrader, Arg_CheckVersion + " " + checkResultFile);
            pro.StartInfo.UseShellExecute = false;
            pro.Start();
            pro.WaitForExit(); //等待检查

            if (File.Exists(checkResultFile))
            {
                string result = File.ReadAllText(checkResultFile);
                File.Delete(checkResultFile); //删除临时文件

                if ((result != "") && (int.Parse(result) > 0))//有新版本
                {
                    if (Msg.AskQuestion("服务器上有新版本下载, 需要下载吗?"))
                    {
                        AppExit = true;
                        Process.Start(upgrader, Arg_MainEXECall);
                    }
                    else
                    {
                        Msg.ShowInformation("您没有升级版本，不能运行程序！");
                        AppExit = true;
                    }
                    return;
                }
            }
        }
    }
}
