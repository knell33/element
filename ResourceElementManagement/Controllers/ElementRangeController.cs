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
    public class ElementRangeController : ControllerBase
    {

        /// <summary>
        /// 根据要素ID查询文本值域选项
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ElementRange> GetElementRangeByEID(string EID)
        {
            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            return elementRangeBLL.GetAll(EID);
        }
    }
}