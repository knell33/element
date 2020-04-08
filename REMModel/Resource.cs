using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 资源目录
    /// </summary>
   public class Resource
    {
        /// <summary>
        /// 资源ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 上级资源ID
        /// </summary>
        public string PID { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModify { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// 是否树形
        /// </summary>
        public int TreeForm { get; set; }

        /// <summary>
        /// 关系资源ID
        /// </summary>
        public string RelationID { get; set; }
    }
}
