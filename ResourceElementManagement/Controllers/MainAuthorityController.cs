using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMBLL;
using REMModel;

namespace MainAuthorityMainAuthorityManagement.Controllers
{
    [Route("api/[Action]")]
    public class MainAuthorityController : ControllerBase
    {
        /// <summary>
        /// 根据资源明细ID获取主体权限数据
        /// </summary>
        /// <param name="DID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MainAuthority> GetAllMainAuthorityByDetailID(string DID)
        {
            MainAuthorityBLL MainAuthorityBLL = new MainAuthorityBLL();
            return MainAuthorityBLL.GetAllMainAuthorityByDetailID(DID);
        }
        /// <summary>
        /// 新增主体权限
        /// </summary>
        /// <param name="MainAuthority">主体权限对象</param>
        [HttpPost]
        public void CreateMainAuthority([FromBody]MainAuthority mainAuthority)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.CreateMainAuthority(mainAuthority);
        }

        /// <summary>
        /// 修改主体权限
        /// </summary>
        /// <param name="MainAuthority">主体权限对象</param>
        [HttpPut]
        public void PutMainAuthorityByAID([FromBody]MainAuthority mainAuthority)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.PutMainAuthorityByAID(mainAuthority);
        }

        /// <summary>
        /// 删除主体权限
        /// </summary>
        /// <param name="AID">主体权限ID</param>
        [HttpDelete]
        public void DeleteMainAuthorityByAID(string AID)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.DeleteMainAuthorityByAID(AID);
        }

    }
}