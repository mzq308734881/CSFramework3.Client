///*************************************************************************/
///*
///* 文件名    ：SystemConfig.cs                                    
///* 程序说明  : 系统配置类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace CSFramework.Common
{
    /// <summary>
    /// 系统配置类.用户个性化设置
    /// </summary>
    public class SystemConfig
    {
        //成员变量
        private bool _AllowRunMultiInstance = false;
        private bool _DoubleClickIntoEditMode = false;
        private bool _WriteLocalLog = false;
        private string _SkinName = "Blue";
        private string _AttachmentStorageType = "SQL"; //SQL|DIR
        private string _AttachmentFolder = @"S:\_Attachment Shared\"; //附件文件的共享目录Path
        private int _LoginAuthType = 1;//登录用户验证类型 1.系统自定义权限验证 2.Novell网用户验证

        #region 版本升级服务器连接相关配置
        private string _UpgraderServerIP = "192.168.1.118";
        private string _UpgraderServerPort = "15137";
        private string _UpgraderSharedPath = @"S:\_Upgrader Shared";
        private int _UpgradeType = 1; //升级类型,1.tcp/ip 2.目录共享

        public string UpgraderServerIP { get { return _UpgraderServerIP; } set { _UpgraderServerIP = value; } }
        public string UpgraderServerPort { get { return _UpgraderServerPort; } set { _UpgraderServerPort = value; } }
        public int UpgradeType { get { return _UpgradeType; } set { _UpgradeType = value; } }

        private bool _AutoCheckVersion = true;
        private bool _ExitAppIfOldVersion = true;

        public bool AutoCheckVersion { get { return _AutoCheckVersion; } set { _AutoCheckVersion = value; } }
        public bool ExitAppIfOldVersion { get { return _ExitAppIfOldVersion; } set { _ExitAppIfOldVersion = value; } }

        #endregion

        #region 邮件服务器客户端配置
        private bool _UseEmailSystem = false;
        private string _MailHostIP = "192.168.1.118";
        private string _MailHostPort = "38138";

        /// <summary>
        /// 郵件代理服務器IP
        /// </summary>
        public string MailHostIP { get { return _MailHostIP; } set { _MailHostIP = value; } }

        /// <summary>
        /// 郵件代理服務器臨聽端口
        /// </summary>
        public string MailHostPort { get { return _MailHostPort; } set { _MailHostPort = value; } }

        /// <summary>
        /// 是否使用邮件功能
        /// </summary>
        public bool MailSystemSupportable { get { return _UseEmailSystem; } set { _UseEmailSystem = value; } }

        #endregion

        #region 当前系统配置
        private static SystemConfig _CurrentConfig;
        public static SystemConfig CurrentConfig
        {
            get
            {
                return _CurrentConfig;
            }
            set
            {
                _CurrentConfig = value;
            }
        }
        #endregion

        /// <summary>
        /// 将配置信息写入XML文件
        /// </summary>
        /// <param name="config"></param>
        public static void WriteSettings(SystemConfig config)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SystemConfig));
            Stream stream = new FileStream(GetConfigPath(), FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            xs.Serialize(stream, config);
            stream.Close();
        }

        /// <summary>
        /// 读取XML文件，反序列化转换为系统配置对象
        /// </summary>
        public static void ReadSettings()
        {
            string path = GetConfigPath();
            if (!File.Exists(path))
            {
                SystemConfig.CurrentConfig = new SystemConfig();
                WriteSettings(SystemConfig.CurrentConfig);
            }
            else
            {
                XmlSerializer xs = new XmlSerializer(typeof(SystemConfig));
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                CurrentConfig = (SystemConfig)xs.Deserialize(stream);
                stream.Close();
            }
        }

        /// <summary>
        ///还原成系统预设参数 
        /// </summary>
        public static void RestoreDefault()
        {
            SystemConfig.CurrentConfig = new SystemConfig();
            WriteSettings(SystemConfig.CurrentConfig);
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetConfigPath()
        {
            return Application.StartupPath + @"\config\SystemSettings.xml";
        }

        /// <summary>
        ///运行单个实例 
        /// </summary>
        public bool AllowRunMultiInstance
        {
            get { return _AllowRunMultiInstance; }
            set { _AllowRunMultiInstance = value; }
        }

        /// <summary>
        /// 双击表格进入编辑模式
        /// </summary>
        public bool DoubleClickIntoEditMode
        {
            get { return _DoubleClickIntoEditMode; }
            set { _DoubleClickIntoEditMode = value; }
        }

        /// <summary>
        /// 启用本地日志
        /// </summary>
        public bool WriteLocalLog
        {
            get { return _WriteLocalLog; }
            set { _WriteLocalLog = value; }
        }

        /// <summary>
        /// 皮肤名称
        /// </summary>
        public string SkinName
        {
            get { return _SkinName; }
            set { _SkinName = value; }
        }

        public int LoginAuthType { get { return _LoginAuthType; } set { _LoginAuthType = value; } }

        /// <summary>
        /// 附件资料存储类型
        /// </summary>
        public string AttachmentStorageType
        {
            get { return _AttachmentStorageType; }
            set { _AttachmentStorageType = value; }
        }

        /// <summary>
        ///附件文件的共享目录Path
        /// </summary>
        public string AttachmentFolder
        {
            get { return _AttachmentFolder; }
            set { _AttachmentFolder = value; }
        }

    }
}
