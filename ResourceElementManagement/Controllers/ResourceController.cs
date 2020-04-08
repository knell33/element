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
    public class ResourceController : ControllerBase
    {
        /// <summary>
        /// 获取资源要素目录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Resource> GetAllResources()
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            return resourceBLL.GetAll();
        }
    }
}