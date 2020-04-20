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
    public class RoleInformationController : ControllerBase
    {
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<RoleInformation> GetAllRoleInformation()
        {
            RoleInformationBLL roleInformationBLL = new RoleInformationBLL();
            return roleInformationBLL.GetAllRoleInformation();
        }
    }
}