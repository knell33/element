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
    public class ElementController : ControllerBase
    {
        /// <summary>
        /// 根据资源ID获取要素目录
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Element> GetAllELementByResourceID(string RID)
        {
            ElementBLL elementBLL = new ElementBLL();
            return elementBLL.GetAllByResourceID(RID);
        }
    }
}