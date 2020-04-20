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
    }
}