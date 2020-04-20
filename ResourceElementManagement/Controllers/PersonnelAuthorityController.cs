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
    public class PersonnelAuthorityController : ControllerBase
    {
        /// <summary>
        /// 根据用户ID获取人员权限
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<PersonnelAuthority> GetAllPersonnelAuthorityByUID(string UserID)
        {
            PersonnelAuthorityBLL personnelAuthorityBLL = new PersonnelAuthorityBLL();
            return personnelAuthorityBLL.GetAllPersonnelAuthorityByUID(UserID);
        }
    }
}