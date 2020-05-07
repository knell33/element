using System;
using System.Collections.Generic;
using System.Text;

namespace REMModel
{
    /// <summary>
    /// 要素目录/资源目录/资源分类/统计指标定义/计算要素条件 联合查询
    /// </summary>
    ///
    public class Element
    {
        /// <summary>
        /// 要素ID
        /// </summary>
        public string EID { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public string RID { get; set; }

        /// <summary>
        /// 要素名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 要素类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

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
        /// 长度
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public long Precision { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string Defaulta { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public string CID { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public int IFRequired { get; set; }

        /// <summary>
        /// 选项类型
        /// </summary>
        public string OptionType { get; set; }

        /// <summary>
        /// 外部查找SQL
        /// </summary>
        /*public Clob WCSQL { get; set; }*/

        /// <summary>
        /// 序号
        /// </summary>
        public string Numbera { get; set; }

        /// <summary>
        /// 值域资源ID
        /// </summary>
        public string DRID { get; set; }

        /// <summary>
        /// 是否展示主目录
        /// </summary>
        public int IFZSZML { get; set; }

        /// <summary>
        /// 是否展示名称
        /// </summary>
        public int IFZSMC { get; set; }

        /// <summary>
        /// 编码目录ID
        /// </summary>
        public string CDID { get; set; }

        /// <summary>
        /// 要素分类
        /// </summary>
        public string ElementClassify { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassifyName { get; set; }

        /// <summary>
        /// 定义指标个数
        /// </summary>
        public decimal DYZBGS { get; set; }

        /// <summary>
        /// 表达式文本
        /// </summary>
        public string Text { get; set; }

    }
}
