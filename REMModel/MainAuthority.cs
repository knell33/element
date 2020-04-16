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
        public String AID { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public String RoleID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public String RoleName { get; set; }
        /// <summary>
        /// 主体id
        /// </summary>
        public String MID { get; set; }
        /// <summary>
        /// 主体名称
        /// </summary>
        public String MainName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public String AuthorityType { get; set; }
        /// <summary>
        /// 关联资源ID
        /// </summary>
        public String RID { get; set; }
        /// <summary>
        /// 关联资源明细ID
        /// </summary>
        public String DID { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public String LastModify { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
