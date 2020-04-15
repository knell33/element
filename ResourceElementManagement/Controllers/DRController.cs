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
    public class DRController : ControllerBase
    {
        /// <summary>
        /// 获取v_要素值域资源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<DR> GetAllDR()
        {
            DRBLL dRBLL = new DRBLL();
            return dRBLL.GetAllDR();
        }
    }
}