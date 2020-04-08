using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ResourceBLL
    {
        /// <summary>
        /// 获取资源目录
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetAll()
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            return resourceDAL.GetAll();
        }
    }
}
