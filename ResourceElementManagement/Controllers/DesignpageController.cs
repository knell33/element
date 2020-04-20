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
    public class DesignpageController : ControllerBase
    {
        /// <summary>
        /// 获取设计页面信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Designpage> GetAllDesignpage()
        {
            DesignpageBLL designpageBLL = new DesignpageBLL();
            return designpageBLL.GetAllDesignpage();
        }
    }
}