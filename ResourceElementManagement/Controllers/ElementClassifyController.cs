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
    public class ElementClassifyController : ControllerBase
    {
        /// <summary>
        /// 根据资源ID获取要素分类
        /// </summary>
        [HttpPost]
        public List<ElementClassify> GetAllElementClassifyByRID(string RID)
        {
            ElementClassifyBLL elementClassifyBLL = new ElementClassifyBLL();
            return elementClassifyBLL.GetAllByResourceID(RID);
        }
    }
}