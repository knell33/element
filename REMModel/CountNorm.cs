using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 统计指标定义
    /// </summary>
    public class CountNorm
    {
        /// <summary>
        /// 指标定义ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 指标名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 计算类型
        /// </summary>
        public string CalculateType { get; set; }

        /// <summary>
        /// 运算符
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 运算值
        /// </summary>
        public string Ovalue { get; set; }

        /// <summary>
        /// 关联类型
        /// </summary>
        public string AssociationType { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>
        public string GLID { get; set; }

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
        /// 资源ID
        /// </summary>
        public string RID { get; set; }
    }
}
