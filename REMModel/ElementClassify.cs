using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 要素分类
    /// </summary>
    public class ElementClassify
    {
        /// <summary>
        /// 资源分类ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public string RID { get; set; }

        /// <summary>
        /// 分类名称
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

    }
}
