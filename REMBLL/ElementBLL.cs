using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementBLL
    {
        /// <summary>
        /// 根据资源ID查找要素目录
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Element> GetAllByResourceID(string RID)
        {
            ElementDAL elementDAL = new ElementDAL();
            return elementDAL.GetAllByResourceID(RID);
        }
    }
}
