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
    public class RoleUserController : ControllerBase
    {
        /// <summary>
        /// 根据角色ID获取角色用户信息
        /// </summary>
        /// <param name="RID">角色ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<RoleUesr> GetAllRoleUserByRID(string RID)
        {
            RoleUserBLL roleUserBLL = new RoleUserBLL();
            return roleUserBLL.GetAllRoleUserByRID(RID);
        }

        /// <summary>
        /// 新增角色用户 同步人员权限
        /// </summary>
        /// <param name="roleUesrJson">角色用户实体字符串</param>
        /// <returns></returns>
        [HttpPost]
        public string CreateRoleUser(string roleUesrJson)
        {
            RoleUserBLL roleUserBLL = new RoleUserBLL();
            roleUserBLL.CreateRoleUser(roleUesrJson);
            return "OK";
        }

        /// <summary>
        /// 删除用户信息 同步人员权限
        /// </summary>
        /// <param name="RUID">角色用户ID</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        [HttpDelete]
        public void DeleteMainAuthorityByRUID(string RUID, string UserID, string RoleID)
        {
            RoleUserBLL roleUserBLL = new RoleUserBLL();
            roleUserBLL.DeleteMainAuthorityByRUID(RUID, UserID, RoleID);
        }
    }
}