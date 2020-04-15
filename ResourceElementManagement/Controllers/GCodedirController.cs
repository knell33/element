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
    public class GCodedirController : ControllerBase
    {
        /// <summary>
        /// 获取通用编码目录
        /// </summary>
        [HttpGet]
        public List<GCodedir> GetAllGCodedir()
        {
            GCodedirBLL gCodedirBLL = new GCodedirBLL();
            return gCodedirBLL.GetAllGCodedir();
        }
    }
}