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
        public List<Element> GetAllElementByResourceID(string RID)
        {
            ElementBLL elementBLL = new ElementBLL();
            return elementBLL.GetAllElementByResourceID(RID);
        }

        /// <summary>
        /// 根据要素ID获取要素目录
        /// </summary>
        /// <param name="RID">要素ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<Element> GetAllElementByEID(string EID)
        {
            ElementBLL elementBLL = new ElementBLL();
            return elementBLL.GetAllElementByEID(EID);
        }
        /// <summary>
        /// 新增资源目录
        /// </summary>
        /// <param name="element"></param>
        [HttpPost]
        public string CreateElement(Element element)
        {
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.CreateElement(element);
            return "要素目录新增成功";
        }

        /// <summary>
        /// 根据要素ID修改要素信息
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [HttpPut]
        public string UpdateElementByEID([FromBody]Element element)
        {
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.UpdateElementByEID(element);
            return "要素目录修改成功";
        }
        /// <summary>
        /// 根据要素ID删除要素信息
        /// </summary>
        /// <param name="EID">要素ID</param>
        /// <returns></returns>
        [HttpDelete]
        public String DeleteElementByEID(string EID)
        {
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.DeleteElementByEID(EID);
            return "要素信息删除成功";
        }
    }
}