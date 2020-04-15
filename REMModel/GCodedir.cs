using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 通用编码目录
    /// </summary>
    public class GCodedir
    {
        /// <summary>
        /// 目录ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        public string Name { get; set; }

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
        /// 是否树形
        /// </summary>
        public int TreeForm { get; set; }
    }
}
