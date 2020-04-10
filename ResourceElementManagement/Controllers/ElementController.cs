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
        public List<Element> GetAllElementByRID(string RID)
        {
            ElementBLL elementBLL = new ElementBLL();
            return elementBLL.GetAllElementByRID(RID);
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
        /// 新增要素目录
        /// </summary>
        /// <param name="element">要素目录对象</param>
        [HttpPost]
        public void CreateElement([FromBody]Element element)
        {
           
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.CreateElement(element);
        }

        /// <summary>
        /// 根据ID修改要素目录
        /// </summary>
        /// <param name="element">要素目录对象</param>
        [HttpPut]
        public void PutElementByID([FromBody]Element element)
        {
            
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.PutElementByID(element);
        }


        /// <summary>
        /// 根据ID删除要素目录
        /// </summary>
        /// <param name="EID">要素ID</param>
        [HttpDelete]
        public void DeleteElementByID(string EID)
        {
            ElementBLL elementBLL = new ElementBLL();
            elementBLL.DeleteElementByID(EID);
        }
    }
}