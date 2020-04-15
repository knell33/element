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
        public List<ElementRange> GetAllElementRangeByEID(string EID)
        {
            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            return elementRangeBLL.GetAllElementRangeByEID(EID);
        }

        /// <summary>
        /// 根据选项值域ID获取文本值域选项
        /// </summary>
        /// <param name="ID">选项值域ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<ElementRange> GetAllElementRangeByID(string ID)
        {
            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            return elementRangeBLL.GetAllElementRangeByID(ID);
        }

        /// <summary>
        /// 新增文本值域选项
        /// </summary>
        /// <param name="elementRange">文本值域选项对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        [HttpPost]
        public void CreateElementRange([FromBody]ElementRange elementRange)
        {

            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            elementRangeBLL.CreateElementRange(elementRange);
        }

        /// <summary>
        /// 根据ID修改文本值域选项
        /// </summary>
        /// <param name="elementRange">文本值域选项对象</param>
        /// <param name="dt">最后修改时间</param>
        [HttpPut]
        public void PutElementRangeByID([FromBody]ElementRange elementRange)
        {

            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            elementRangeBLL.PutElementRangeByID(elementRange);
        }

        /// <summary>
        /// 根据ID删除文本值域选项
        /// </summary>
        /// <param name="ID">值域选项ID</param>
        [HttpDelete]
        public void DeleteElementRangeByID(string ID)
        {
            ElementRangeBLL elementRangeBLL = new ElementRangeBLL();
            elementRangeBLL.DeleteElementRangeByID(ID);
        }
    }
}