using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMBLL;
using REMModel;

namespace ResourceDetailManagement.Controllers
{
    [Route("api/[Action]")]
    public class DetailController : ControllerBase
    {
        /// <summary>
        /// 根据资源ID获取资源明细数据
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Detail> GetAllDetailByResourceID(string RID)
        {
            DetailBLL DetailBLL = new DetailBLL();
            return DetailBLL.GetAllDetailByResourceID(RID);
        }
    
    }
}