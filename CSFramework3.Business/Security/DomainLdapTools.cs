
///*************************************************************************/
///*
///* 文件名    ：DomainLdapTools.cs        
///
///* 程序说明  : Windows目录服务工具包
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.Collections;


namespace CSFramework3.Business.Security
{
    /// <summary>
    /// Windows目录服务工具包
    /// </summary>
    public class DomainLdapTools
    {
        /// <summary>
        /// UserPrincipalName:客户端进行身份验证的服务的用户主体名称 (UPN)
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUserPrincipalName()
        {
            SearchResult user = GetUser(Environment.UserName);
            if (user != null)
            {
                ResultPropertyValueCollection value = (ResultPropertyValueCollection)user.Properties["userprincipalname"];
                if ((value != null) && (value.Count > 0))
                    return value[0].ToString();
            }
            return "";
        }

        /// <summary>
        /// 从活动目录搜索用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static SearchResult GetUser(string account)
        {
            Domain domain = Domain.GetCurrentDomain();
            if (domain == null) throw new Exception("当前用户没有登录域！");

            IList<SearchResult> result = DomainLdapTools.SearchObjects(domain.Name, "objectClass=user", true);
            SearchResult currentUser = DomainLdapTools.LocateUser(result, Environment.UserName);
            return currentUser;
        }

        /// <summary>
        /// 从搜索结果中定位用户
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static SearchResult LocateUser(IList<SearchResult> objs, string account)
        {
            foreach (SearchResult p in objs)
            {
                ResultPropertyValueCollection temp = (ResultPropertyValueCollection)p.Properties["samaccountname"];
                if ((temp != null) && (temp.Count > 0))
                {
                    if (temp[0].ToString().ToLower() == account.ToLower()) return p;
                }
            }
            return null;
        }

        /// <summary>
        /// 从活动目录中搜索对象
        /// </summary>
        /// <param name="domainADPath">如：CSFRAMEWORK.mo</param>
        /// <param name="searchString">三种类型：objectClass=organizationalUnit, objectClass=group, objectClass=user </param>
        /// <param name="searchAllProperties">搜索所有属性</param>
        /// <returns></returns>
        public static IList<SearchResult> SearchObjects(string domainADPath, string searchString, bool searchAllProperties)
        {

            IList<SearchResult> objs = new List<SearchResult>();
            using (DirectoryEntry LDAPConnection = CreateDirectoryEntry(domainADPath))
            {
                using (DirectorySearcher SearchObj = new DirectorySearcher(LDAPConnection))
                {
                    SearchObj.Filter = searchString;
                    if (searchAllProperties == false)
                        SearchObj.PropertiesToLoad.AddRange(new string[] { "name", "Path", "displayname", "samaccountname", "userprincipalname", "mail" });
                    SearchResultCollection Result = SearchObj.FindAll();
                    foreach (SearchResult SR in Result) objs.Add(SR);
                }
            }
            return objs;
        }

        /// <summary>
        /// 创建一个目录入口．
        /// </summary>
        /// <param name="domainADPath">AD路径,如：CSFRAMEWORK.mo</param>
        /// <returns></returns>
        public static DirectoryEntry CreateDirectoryEntry(string domainADPath)
        {
            DirectoryEntry de = new DirectoryEntry(domainADPath); //CSFRAMEWORK.mo

            string[] DomainSplit = domainADPath.Split('.');

            de.Path = "LDAP://";

            foreach (string Part in DomainSplit)
                de.Path += "DC=" + Part + ",";

            int LastCommaInd = de.Path.LastIndexOf(',');

            de.Path = de.Path.Remove(LastCommaInd);
            de.AuthenticationType = AuthenticationTypes.Secure;
            return de;
        }

        /// <summary>
        /// 获取当前域所有组编号
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllGroups()
        {
            List<string> groups = new List<string>();
            Domain domain = Domain.GetCurrentDomain();
            if (domain == null) return groups;

            IList<SearchResult> result = SearchObjects(domain.Name, "objectClass=group", false);
            foreach (SearchResult SR in result)
            {
                ResultPropertyCollection Fields = SR.Properties;
                foreach (Object myCollection in Fields["samAccountName"])
                    groups.Add(myCollection.ToString());
            }
            return groups;
        }

        /// <summary>
        /// 获取当前域所有组对象
        /// </summary>
        /// <returns></returns>
        public static List<SearchResult> GetAllGroupObjects()
        {
            List<SearchResult> groups = new List<SearchResult>();
            Domain domain = Domain.GetCurrentDomain();
            if (domain == null) return groups;

            IList<SearchResult> result = SearchObjects(domain.Name, "objectClass=group", true);
            foreach (SearchResult SR in result) groups.Add(SR);
            return groups;
        }

        /// <summary>
        /// 获取当前域内的所有用户编号
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllUsers()
        {
            List<string> users = new List<string>();
            Domain domain = Domain.GetCurrentDomain();
            if (domain == null) return users;

            IList<SearchResult> result = SearchObjects(domain.Name, "objectClass=user", true);
            foreach (SearchResult SR in result)
            {
                ResultPropertyCollection Fields = SR.Properties;
                foreach (Object myCollection in Fields["samAccountName"])
                    users.Add(myCollection.ToString());
            }
            return users;
        }

        /// <summary>
        /// 获取当前域内的所有用户对象
        /// </summary>
        /// <returns></returns>
        public static List<SearchResult> GetAllUserObjects()
        {
            List<SearchResult> users = new List<SearchResult>();
            Domain domain = Domain.GetCurrentDomain();
            if (domain == null) return users;

            IList<SearchResult> result = SearchObjects(domain.Name, "objectClass=user", true);
            foreach (SearchResult SR in result) users.Add(SR);
            return users;
        }

        /// <summary>
        /// 获取指定用户的组
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<string> GroupsByUser(string account)
        {
            List<string> result = new List<string>();

            SearchResult user = GetUser(account);
            ResultPropertyValueCollection values = (ResultPropertyValueCollection)user.Properties["memberOf"];
            foreach (object o in values)
            {
                result.Add(o.ToString());
            }
            return result;
        }
    }
}
