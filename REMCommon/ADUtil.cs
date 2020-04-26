using Newtonsoft.Json;
using REMModel;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace REMCommon
{
    /// <summary>
    /// 获取中联用户信息连接类
    /// </summary>
    public class ADUtil
    {
        // LDAP地址 
        private const string LDAP_HOST = "LDAP://zl.zlsoft.cn:389";
        // 具有LDAP管理权限的特殊帐号
        private const string USER_NAME = "zlyzhdq@zlsoft.cn";
        // 具有LDAP管理权限的特殊帐号的密码
        private const string PASSWORD = "2020@zlsoft/";

        public ADUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /**
         * 向某个组添加人员
         * groupName 组名称
         * userName 人员域帐号
         **/
        public static void addGroupMember(string groupName, string userName)
        {
            DirectoryEntry group = getGroupByName(groupName);
            group.Username = USER_NAME;
            group.Password = PASSWORD;
            group.Properties["member"].Add(getUserDNByName(userName));
            group.CommitChanges();
        }

        /**
         * 从某个组移出指定的人员
         * groupName 组名称
         * userName 人员域帐号
         **/
        public static void removeGroupMember(string groupName, string userName)
        {
            DirectoryEntry group = getGroupByName(groupName);
            group.Username = USER_NAME;
            group.Password = PASSWORD;
            group.Properties["member"].Remove(getUserDNByName(userName));
            group.CommitChanges();
        }

        /**
         * 获取指定人员的域信息
         * name 人员域帐号 
         **/
        public static object getUserDNByName(string name)
        {
            DirectorySearcher userSearch = new DirectorySearcher(LDAP_HOST);
            userSearch.SearchRoot = new DirectoryEntry(LDAP_HOST, USER_NAME, PASSWORD);
            userSearch.Filter = "(SAMAccountName=" + name + ")";
            SearchResult user = userSearch.FindOne();
            if (user == null)
            {
                throw new Exception("请确认域用户是否正确");
            }
            return user.Properties["distinguishedname"][0];
        }

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string getAllUserByOU(string name)
        {
            DirectorySearcher mySearcher = new DirectorySearcher(LDAP_HOST);
            mySearcher.SearchRoot = new DirectoryEntry(LDAP_HOST, USER_NAME, PASSWORD).Children.Find("OU=" + name);

            mySearcher.Filter = ("(objectClass=user)"); //user表示用户，group表示组


            List<Users> list = new List<Users>();
            foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
            {
                Users users = new Users();


                DirectoryEntry user = resEnt.GetDirectoryEntry();
                if (user.Properties.Contains("sAMAccountName"))
                {
                    users.AccountName = user.Properties["sAMAccountName"][0].ToString();
                }
                if (user.Properties.Contains("Name"))
                {
                    users.UserName = user.Properties["Name"][0].ToString();
                }
                if (user.Properties.Contains("mail"))
                {
                    users.Email = user.Properties["mail"][0].ToString();
                }
                if (user.Parent.Name != string.Empty && user.Parent.Name.IndexOf('=') > -1)
                {
                    //获取用户所在的组织单位
                    users.OU = user.Parent.Name.Split('=')[1];
                }
                list.Add(users);
            }
            return JsonConvert.SerializeObject(list);

        }

        /// <summary>
        /// 获取中联信息事业部本部用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string getZLAllUser()
        {
            DirectorySearcher mySearcher = new DirectorySearcher(LDAP_HOST);
            mySearcher.SearchRoot = new DirectoryEntry(LDAP_HOST, USER_NAME, PASSWORD).Children.Find("OU=中联公司");

            mySearcher.Filter = ("(objectClass=user)"); //user表示用户，group表示组


            List<Users> list = new List<Users>();
            foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
            {
                Users users = new Users();


                DirectoryEntry user = resEnt.GetDirectoryEntry();
                if (user.Properties.Contains("sAMAccountName"))
                {
                    users.AccountName = user.Properties["sAMAccountName"][0].ToString();
                }
                if (user.Properties.Contains("Name"))
                {
                    users.UserName = user.Properties["Name"][0].ToString();
                }
                if (user.Properties.Contains("mail"))
                {
                    users.Email = user.Properties["mail"][0].ToString();
                }
                if (user.Parent.Name != string.Empty && user.Parent.Name.IndexOf('=') > -1)
                {
                    //获取用户所在的组织单位
                    users.OU = user.Parent.Name.Split('=')[1];
                }
                list.Add(users);
            }
            return JsonConvert.SerializeObject(list);

        }

        /**
         * 获取指定域组的信息
         * name 组名称 
         **/
        public static DirectoryEntry getGroupByName(string name)
        {
            DirectorySearcher search = new DirectorySearcher(LDAP_HOST);
            search.SearchRoot = new DirectoryEntry(LDAP_HOST, USER_NAME, PASSWORD);
            search.Filter = "(&(ou=" + name + ")(objectClass=group))";
            search.PropertiesToLoad.Add("objectClass");
            SearchResult result = search.FindOne();
            DirectoryEntry group;
            if (result != null)
            {
                group = result.GetDirectoryEntry();
            }
            else
            {
                throw new Exception("请确认AD组列表是否正确");
            }
            return group;
        }
    }
}
