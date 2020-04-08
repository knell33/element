using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementRangeBLL
    {
        /// <summary>
        /// 根据要素ID获取文本值域选项
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public List<ElementRange> GetAll(string EID)
        {
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            return elementRangeDAL.GetAll(EID);
        }
    }
}
