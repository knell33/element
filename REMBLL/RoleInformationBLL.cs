using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class RoleInformationBLL
    {
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<RoleInformation> GetAllRoleInformation()
        {
            RoleInformationDAL roleInformationDAL = new RoleInformationDAL();
            return roleInformationDAL.GetAllRoleInformation(); ;
        }
    }
}
