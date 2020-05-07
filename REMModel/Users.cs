using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    public class Users
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 组织单位
        /// </summary>
        public string OU { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        public string ParentOU { get; set; }
        public List<Users> children { get; set; }
    }
}
