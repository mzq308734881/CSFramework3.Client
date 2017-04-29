///*************************************************************************/
///*
///* 文件名    ：bllLocalLog.cs                                     
///* 程序说明  : 本地日志功能，保存在程序运行目录下。
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CSFramework.Common;

namespace CSFramework3.Business
{
    /// <summary>
    /// 本地日志功能
    /// </summary>
    public class bllLocalLog
    {
        /// <summary>
        /// 最大日志文件限制2MB
        /// </summary>
        const int MAX_LOG_SIZE = 1024 * 2;//2MB

        /// <summary>
        /// 日志文件名
        /// </summary>
        const string LOG_FILE_NAME = "log.dat";

        private string _LogFileName = "";

        /// <summary>
        /// 日志文件名
        /// </summary>
        public string LogFileName { get { return _LogFileName; } set { _LogFileName = value; } }

        private static bllLocalLog _Instance = null;

        /// <summary>
        /// 实例
        /// </summary>
        public static bllLocalLog Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new bllLocalLog();
                }
                return _Instance;
            }
        }

        /// <summary>
        /// 构造器
        /// </summary>
        public bllLocalLog()
        {
            _LogFileName = Application.StartupPath + @"\" + LOG_FILE_NAME;

            FileStream fs = new FileStream(_LogFileName, FileMode.OpenOrCreate);
            double size = fs.Length / double.Parse("1024.00"); //byte -> KB
            fs.Close();
            if (size > MAX_LOG_SIZE) this.BackupLog();
        }

        //当日志文件大于指定大小,备份日志
        public void BackupLog()
        {
            string newFile = "log_" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ".dat";
            newFile = newFile.Replace("-", "").Replace(" ", "").Replace(":", "");
            newFile = Application.StartupPath + @"\" + newFile;
            File.Move(_LogFileName, newFile);
            File.WriteAllText(_LogFileName, "", Encoding.UTF8); //清空文件
        }

        //日志格式：
        //1. 2010-09-09 13:21:123: 用户xxx登录
        //2. 2010-09-09 13:21:123: 异常,地址错
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log"></param>
        public void Write(string log)
        {
            if (SystemConfig.CurrentConfig.WriteLocalLog)
            {
                string user = Loginer.CurrentUser.Account;
                if (user == string.Empty) user = "unknow";
                log = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " : " + user + " : " + log + System.Environment.NewLine;
                File.AppendAllText(_LogFileName, log, Encoding.UTF8);
            }
        }

        /// <summary>
        /// 写系统异常日志
        /// </summary>
        /// <param name="ex">系统异常</param>
        public void Write(Exception ex)
        {
            if (SystemConfig.CurrentConfig.WriteLocalLog)
            {
                this.Write(ex.Message);
            }
        }

    }
}
