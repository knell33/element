using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{

    /// <summary>
    /// 人员权限
    /// </summary>
    public class PersonnelAuthority
    {
        /// <summary>
        /// 人员权限ID
        /// </summary>
        public string PAID { get; set; }

        /// <summary>
        /// 主体权限ID
        /// </summary>
        public string MAID { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        public string MID { get; set; }

        /// <summary>
        /// 主体名称
        /// </summary>
        public string MName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public string AuthorityType { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModify { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }

        /// <summary>
        /// 关联资源ID
        /// </summary>
        public string ResourceID { get; set; }

        /// <summary>
        /// 关联资源明细ID
        /// </summary>
        public string DID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID { get; set; }
    }
}
