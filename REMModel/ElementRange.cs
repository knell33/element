using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 文本选项值域
    /// </summary>
    public class ElementRange
    {

        /// <summary>
        /// 选项值域ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 选项名称
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
        /// 要素ID
        /// </summary>
        public string EID { get; set; }
    }
}
