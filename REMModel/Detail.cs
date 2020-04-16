using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 资源明细
    /// </summary>
    ///
    public class Detail
    {
        /// <summary>
        /// 资源明细ID
        /// </summary>
        public String DID { get; set; }
        /// <summary>
        /// 明细名称
        /// </summary>
        public String DetailName { get; set; }
        /// <summary>
        /// 资源ID
        /// </summary>
        public String RID { get; set; }
        /// <summary>
        /// 明细要素信息
        /// </summary>
        public String DetailInfo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public String LastModify { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }
        /// <summary>
        /// 明细关系id
        /// </summary>
        public String DetailRelationID { get; set; }
        /// <summary>
        /// 上级资源id
        /// </summary>
        public String PID { get; set; }
        /// <summary>
        /// 上级资源明细id
        /// </summary>
        public String PDID { get; set; }
        /// <summary>
        /// 上级明细名称
        /// </summary>
        public String PDetailName { get; set; }
        /// <summary>
        /// 事务时间
        /// </summary>
        public DateTime TransactionDate { get; set; }
    }
}
