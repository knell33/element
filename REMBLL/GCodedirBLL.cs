using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class GCodedirBLL
    {
        /// <summary>
        /// 获取通用编码目录
        /// </summary>
        /// <returns></returns>
        public List<GCodedir> GetAllGCodedir()
        {
            GCodedirDAL gCodedirDAL = new GCodedirDAL();
            return gCodedirDAL.GetAllGCodedir();
        }
    }
}
