using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class CountNormBLL
    {
        /// <summary>
        /// 根据资源ID获取统计指标定义
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<CountNorm> GetAll(string RID)
        {
            CountNormDAL countNormDAL = new CountNormDAL();
            return countNormDAL.GetAll(RID);
        }
    }
}
