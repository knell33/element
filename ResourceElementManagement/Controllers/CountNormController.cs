using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMBLL;
using REMModel;

namespace ResourceElementManagement.Controllers
{
    [Route("api/[Action]")]
    public class CountNormController : ControllerBase
    {
        /// <summary>
        /// 根据资源ID获取统计指标定义
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CountNorm> GetCountNormByRID(string RID)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            return countNormBLL.GetAll(RID);
        }
    }
}