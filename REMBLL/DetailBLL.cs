using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class DetailBLL
    {
        /// <summary>
        /// 根据资源ID查找资源明细数据
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Detail> GetAllDetailByResourceID(string RID)
        {
            DetailDAL DetailDAL = new DetailDAL();
            return DetailDAL.GetAllDetailByResourceID(RID);
        }

    }
}
