using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class DesignpageBLL
    {
        /// <summary>
        /// 获取设计页面信息
        /// </summary>
        /// <returns></returns>
        public List<Designpage> GetAllDesignpage()
        {
            DesignpageDAL designpageDAL = new DesignpageDAL();
            return designpageDAL.GetAllDesignpage();
        }
    }
}
