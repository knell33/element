using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class RoleUserBLL
    {
        /// <summary>
        /// 根据角色ID获取角色用户信息
        /// </summary>
        /// <param name="RID">角色ID</param>
        /// <returns></returns>
        public List<RoleUesr> GetAllRoleUserByRID(string RID)
        {
            RoleUserDAL roleUserDAL = new RoleUserDAL();
            return roleUserDAL.GetAllRoleUserByRID(RID);
        }
    }
}
