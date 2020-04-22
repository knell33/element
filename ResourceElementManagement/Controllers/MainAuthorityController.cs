using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        /// <param name="DID">资源明细ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<MainAuthority> GetAllMainAuthorityByDetailID(string DID)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            return mainAuthorityBLL.GetAllMainAuthorityByDetailID(DID);
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<MainAuthority> GetAllRoleInfo()
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            return mainAuthorityBLL.GetAllRoleInfo();
        }

        /// <summary>
        /// 新增主体权限
        /// </summary>
        /// <param name="MainAuthority">主体权限对象</param>
        [HttpPost]
        public string CreateMainAuthority([FromBody]MainAuthority mainAuthority)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.CreateMainAuthority(mainAuthority);
            return "ok";
        }

        /// <summary>
        /// 修改主体权限
        /// </summary>
        /// <param name="MainAuthority">主体权限对象</param>
        [HttpPut]
        public string PutMainAuthorityByAID([FromBody]MainAuthority mainAuthority)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.PutMainAuthorityByAID(mainAuthority);
            return "ok";
        }

        /// <summary>
        /// 删除主体权限
        /// </summary>
        /// <param name="AID">主体权限ID</param>
        [HttpDelete]
        public string DeleteMainAuthorityByAID(string AID)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.DeleteMainAuthorityByAID(AID);
            return "ok";
        }

        /// <summary>
        /// 根据角色ID获取主体权限
        /// </summary>
        /// <param name="RID">角色ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<MainAuthority> GetAllMainAuthoritiesByRID(string RID)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            return mainAuthorityBLL.GetAllMainAuthoritiesByRID(RID);
        }

        /// <summary>
        /// 角色权限管理页新增主体权限 同步人员权限
        /// </summary>
        /// <param name="maJson">窗体权限字符串</param>
        /// <returns></returns>
        [HttpPost]
        public string CreateMainAuthorities(string maJson)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.CreateMainAuthoritirs(maJson);
            return "OK";
        }

        /// <summary>
        /// 角色权限管理页面其他权限管理新增主体权限 同步人员权限
        /// </summary>
        /// <param name="mainAuthority">主体权限实体</param>
        /// <param name="dt">最后修改时间</param>
        [HttpPost]
        public string CreateMainAuthorityByOthers([FromBody]MainAuthority mainAuthority)
        {
            MainAuthorityBLL mainAuthorityBLL = new MainAuthorityBLL();
            mainAuthorityBLL.CreateMainAuthorityByOthers(mainAuthority);
            return "OK";
        }

        }
}