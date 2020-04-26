using Newtonsoft.Json;
using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 新增角色用户 同步人员权限
        /// </summary>
        /// <param name="roleUesrJson">角色用户实体字符串</param>
        /// <returns></returns>
        public void CreateRoleUser(string roleUesrJson)
        {
            //获取当前时间
            DateTime dt = NewData.NewDate();
            var roleUesr = JsonConvert.DeserializeObject<List<RoleUesr>>(roleUesrJson);
            RoleUserDAL roleUserDAL = new RoleUserDAL();

            for (int i = 0; i < roleUesr.Count; i++)
            {
                //新增角色用户
                string ifsuccess = roleUserDAL.CreateRoleUser(roleUesr[i], dt);
                if (ifsuccess == "OK")
                {
                    MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
                    //根据角色ID获取主体权限ID
                    List<MainAuthority> mainAuthority = mainAuthorityDAL.GetAllAIDByRoleID(roleUesr[i].RID);
                    //同步人员权限
                    PersonnelAuthorityDAL personnelAuthorityDAL = new PersonnelAuthorityDAL();
                    for (int j = 0; j < mainAuthority.Count; j++)
                    {
                        personnelAuthorityDAL.CreatePersonnelAuthority(mainAuthority[j].AID);
                    }
                }
            }
        }

        /// <summary>
        /// 删除用户信息 同步人员权限
        /// </summary>
        /// <param name="RUID">角色用户ID</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        public void DeleteMainAuthorityByRUID(string RUID,string UserID, string RoleID)
        {
            RoleUserDAL roleUserDAL = new RoleUserDAL();
            roleUserDAL.DeleteMainAuthorityByRUID(RUID);
            PersonnelAuthorityDAL personnelAuthorityDAL = new PersonnelAuthorityDAL();
            personnelAuthorityDAL.DeletePA(UserID, RoleID);
        }
    }
}
