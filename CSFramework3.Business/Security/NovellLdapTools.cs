
///*************************************************************************/
///*
///* 文件名    ：NovellLdapTools.cs      
///
///* 程序说明  : Delphi封装Novell LDAP底层API, 由C#.Net程序调用
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;

namespace CSFramework3.Business.Security
{
    /// <summary>
    /// Delphi封装Novell LDAP底层API, 由C#.Net程序调用
    /// </summary>
    public class NovellLdapTools
    {
        const string LINE_SEPERATOR_1 = "\r\n";
        const string LINE_SEPERATOR = "||";
        const string COLUMN_SEPERATOR = "\t";
        const string DLL_NAME = "NovellLdapImp.dll";

        const int CHAR_LENGTH = 100000;

        /// <summary>
        /// 调用Delphi编译的DLL
        /// </summary>
        private class LDAP_DLL_DelphiComplied
        {
            [DllImport(DLL_NAME, EntryPoint = "NovellGetGroups", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern int NovellGetGroups(ref string CurrentAccount, StringBuilder ADestBuffer, int ADestSize);

            [DllImport(DLL_NAME, EntryPoint = "NovellIsMembership", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern string NovellIsMembership(string GroupName, ref string CurrentAccount);

            [DllImport(DLL_NAME, EntryPoint = "NovellHasClient", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern string NovellHasClient();

            [DllImport(DLL_NAME, EntryPoint = "NovellGetGroupByAccount", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern int NovellGetGroupByAccount(string CurrentAccount, StringBuilder ADestBuffer, int ADestSize);

            [DllImport(DLL_NAME, EntryPoint = "NovellGetObjects", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern int NovellGetObjects(string NovellPath, string ClassName, StringBuilder ADestBuffer, int ADestSize, int only3);

            [DllImport(DLL_NAME, EntryPoint = "NovellGetObjectProperties", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern int NovellGetObjectProperties(string NovellPath, string ClassName, StringBuilder ADestBuffer, int ADestSize);

            [DllImport(DLL_NAME, EntryPoint = "NovellGetAllUsers", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern int NovellGetAllUsers(string Country, int ReturnPath, StringBuilder ADestBuffer, int ADestSize);

            [DllImport(DLL_NAME, EntryPoint = "NovellWhoAmI", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern string NovellWhoAmI();

        }

        /// <summary>
        /// 获取当前登录的Novell用户
        /// </summary>
        /// <returns></returns>
        public static string NovellWhoAmI()
        {
            try
            {
                return LDAP_DLL_DelphiComplied.NovellWhoAmI();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取组织单元内所有用户
        /// </summary>
        /// <param name="Country">组织单元(.com .cn 等等)</param>
        /// <param name="ReturnPath">是否包含完整路径</param>
        /// <returns></returns>
        public static DataTable NovellGetAllUsers(string Country, bool ReturnPath)
        {
            try
            {
                StringBuilder sb = new StringBuilder(CHAR_LENGTH);
                int count = LDAP_DLL_DelphiComplied.NovellGetAllUsers(Country, ReturnPath ? 1 : 0, sb, CHAR_LENGTH);
                return GetStringTable(sb.ToString(), LINE_SEPERATOR_1, COLUMN_SEPERATOR, ReturnPath == false);
            }
            catch
            {
                return GetStringTable(" \t ", LINE_SEPERATOR_1, COLUMN_SEPERATOR, true);
            }
        }

        /// <summary>
        /// 获取Novell对象的属性
        /// </summary>
        /// <param name="NovellPath">Novell目录路径, 如:.edp.CSFRAMEWORK.mo 或 .CSFRAMEWORK.mo</param>
        /// <param name="ClassName">类名,如:Organizational Unit,Group,User</param>
        /// <returns></returns>
        public static DataTable NovellGetObjectProperties(string NovellPath, string ClassName)
        {
            try
            {
                StringBuilder sb = new StringBuilder(CHAR_LENGTH);
                int count = LDAP_DLL_DelphiComplied.NovellGetObjectProperties(NovellPath, ClassName, sb, CHAR_LENGTH);
                return GetStringTable(sb.ToString(), LINE_SEPERATOR, COLUMN_SEPERATOR, false);
            }
            catch
            {
                return GetStringTable(" \t ", LINE_SEPERATOR, COLUMN_SEPERATOR, false);
            }
        }

        /// <summary>
        /// 获取Novell网对象
        /// </summary>
        /// <param name="NovellPath">有效路径.如: .edp.CSFRAMEWORK.mo 或 .CSFRAMEWORK.mo</param>
        /// <param name="ClassName">取对象类型: Organizational Unit,Group,User </param>
        /// <returns></returns>
        public static DataTable NovellGetObjects(string NovellPath, string ClassName, bool only3)
        {
            try
            {
                StringBuilder sb = new StringBuilder(CHAR_LENGTH);
                int count = LDAP_DLL_DelphiComplied.NovellGetObjects(NovellPath, ClassName, sb, CHAR_LENGTH, only3 ? 1 : 0);
                return GetStringTable(sb.ToString(), LINE_SEPERATOR, COLUMN_SEPERATOR, false);
            }
            catch
            {
                return GetStringTable(" \t ", LINE_SEPERATOR, COLUMN_SEPERATOR, false);
            }
        }

        /// <summary>
        /// 调用API返回的字符串转换为DataTable
        /// </summary>
        /// <param name="content">调用API返回的字符串</param>
        /// <param name="lineSeperator">行分隔符</param>
        /// <param name="columnSeperator">列分隔符</param>
        /// <param name="onlyLine">仅返回行数据，转换DataTable时只处理行</param>
        /// <returns></returns>
        private static DataTable GetStringTable(string content, string lineSeperator, string columnSeperator, bool onlyLine)
        {
            //创建表结构
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            string[] lines = content.Split(new string[] { lineSeperator }, StringSplitOptions.RemoveEmptyEntries); //分开行
            if (lines.Length == 0) return dt;

            foreach (string line in lines)
            {
                if (onlyLine)
                {
                    DataRow temp = dt.NewRow();
                    temp[0] = line;
                    temp[1] = line;
                    dt.Rows.Add(temp);
                }
                else
                {
                    string[] items = line.Split(new string[] { columnSeperator }, StringSplitOptions.None); //分开列
                    if (items.Length >= 2)
                    {
                        DataRow temp = dt.NewRow();
                        temp[0] = items[0];
                        temp[1] = items[1];
                        dt.Rows.Add(temp);
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// 获取当前Novell用户及所在的组列表
        /// </summary>
        /// <param name="CurrentAccount">返回当前用户</param>
        /// <returns>返回所在的组列表</returns>
        public static string[] NovellGetGroups(ref string CurrentAccount)
        {
            StringBuilder sb = new StringBuilder(CHAR_LENGTH);
            int count = LDAP_DLL_DelphiComplied.NovellGetGroups(ref CurrentAccount, sb, sb.Capacity);
            string groups = sb.ToString();
            string[] groupList = groups.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return groupList;
        }

        /// <summary>
        /// 获取指定Novell帐号的用户组
        /// </summary>
        /// <param name="CurrentAccount">Novell帐号</param>
        /// <returns></returns>
        public static string[] NovellGetGroupByAccount(string CurrentAccount)
        {
            StringBuilder sb = new StringBuilder(CHAR_LENGTH);
            int count = LDAP_DLL_DelphiComplied.NovellGetGroupByAccount(CurrentAccount, sb, sb.Capacity);
            string groups = sb.ToString();
            string[] groupList = groups.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return groupList;
        }

        /// <summary>
        /// 当前登录的用户是否属于指定的组
        /// </summary>
        /// <param name="GroupName">指定的组</param>
        /// <returns></returns>
        public static bool NovellIsMembership(string GroupName, ref string CurrentAccount)
        {
            string result = LDAP_DLL_DelphiComplied.NovellIsMembership(GroupName, ref CurrentAccount);
            return result.ToLower() == "yes";
        }

        /// <summary>
        /// 是否安装Novell客户端
        /// </summary>
        /// <returns></returns>
        public static bool NovellHasClient()
        {
            string result = LDAP_DLL_DelphiComplied.NovellHasClient();
            return result.ToLower() == "yes";
        }

    }

}
