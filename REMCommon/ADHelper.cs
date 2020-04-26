using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace REMCommon
{
    /// <summary>
    /// 获取中联用户信息工具类
    /// </summary>
    public class ADHelper
    {
        #region 创建AD连接
        /// <summary>
        /// 创建AD连接
        /// </summary>
        /// <returns></returns>
        public static DirectoryEntry GetDirectoryEntry()
        {
            DirectoryEntry de = new DirectoryEntry();
            de.Path = "LDAP://zl.zlsoft.cn/DC=ZLSOFT,DC=CN";
            de.Username = @"zlyzhdq";
            de.Password = "2020@zlsoft/";
            return de;

            //DirectoryEntry entry = new DirectoryEntry("LDAP://testhr.com", "administrator", "litb20!!", AuthenticationTypes.Secure);
            //return entry;

        }
        #endregion

        #region 获取目录实体集合
        /// <summary>
        ///
        /// </summary>
        /// <param name="DomainReference"></param>
        /// <returns></returns>
        public static DirectoryEntry GetDirectoryEntry(string DomainReference)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://zl.zlsoft.cn" + DomainReference, "zlyzhdq", "2020@zlsoft/", AuthenticationTypes.Secure);
            return entry;
        }
        #endregion
    }
}
