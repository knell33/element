using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 主体权限
    /// </summary>
    public class MainAuthority
    {
        /// <summary>
        /// 主体权限id
        /// </summary>
        public string AID { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 主体id
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 主体名称
        /// </summary>
        public string MainName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public string AuthorityType { get; set; }
        /// <summary>
        /// 关联资源ID
        /// </summary>
        public string RID { get; set; }
        /// <summary>
        /// 关联资源明细ID
        /// </summary>
        public string DID { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModify { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
