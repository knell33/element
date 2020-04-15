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
            return elementClassifyBLL.GetAllElementClassifyByRID(RID);
        }

        /// <summary>
        /// 根据要素ID获取要素分类
        /// </summary>
        /// <param name="CID">分类ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<ElementClassify> GetElementClassifyByID(string CID)
        {
            ElementClassifyBLL elementClassifyBLL = new ElementClassifyBLL();
            return elementClassifyBLL.GetElementClassifyByID(CID);
        }

        /// <summary>
        /// 新增要素分类
        /// </summary>
        /// <param name="elementClassify">要素分类对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        [HttpPost]
        public void CreateElementClassify([FromBody]ElementClassify elementClassify)
        {
           
            ElementClassifyBLL elementClassifyBLL = new ElementClassifyBLL();
            elementClassifyBLL.CreateElementClassify(elementClassify);
        }

        /// <summary>
        /// 根据ID修改要素分类
        /// </summary>
        /// <param name="elementClassify">要素分类对象</param>
        /// <param name="dt">最后修改时间</param>
        [HttpPut]
        public void PutElementClassifyByID([FromBody]ElementClassify elementClassify)
        {
            
            ElementClassifyBLL elementClassifyBLL = new ElementClassifyBLL();
            elementClassifyBLL.PutElementClassifyByID(elementClassify);
        }

        /// <summary>
        /// 根据ID删除要素分类
        /// </summary>
        /// <param name="CID">分类ID</param>
        [HttpDelete]
        public void DeleteElementClassifyByID(string CID)
        {
            ElementClassifyBLL elementClassifyBLL = new ElementClassifyBLL();
            elementClassifyBLL.DeleteElementClassifyByID(CID);
        }
    }
}