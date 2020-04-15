using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class DRBLL
    {
        /// <summary>
        /// 获取v_要素值域资源
        /// </summary>
        /// <returns></returns>
        public List<DR> GetAllDR()
        {
            DRDAL dRDAL = new DRDAL();
            return dRDAL.GetAllDR();
        }
    }
}
