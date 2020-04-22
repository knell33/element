using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class PersonnelAuthorityBLL
    {
        /// <summary>
        /// 根据用户ID获取人员权限
        /// </summary>
        /// <param name="UID">用户ID</param>
        /// <returns></returns>
        public List<PersonnelAuthority> GetAllPersonnelAuthorityByUID(string UserID)
        {
            PersonnelAuthorityDAL personnelAuthorityDAL = new PersonnelAuthorityDAL();
            return personnelAuthorityDAL.GetAllPersonnelAuthorityByUID(UserID);
        }

        /// <summary>
        /// 根据主体权限ID同步人员权限
        /// </summary>
        /// <param name="MAID">主体权限ID</param>
        public void CreatePersonnelAuthority(string MAID)
        {
            PersonnelAuthorityDAL personnelAuthorityDAL = new PersonnelAuthorityDAL();
            personnelAuthorityDAL.CreatePersonnelAuthority(MAID);
        }

        /// <summary>
        /// 删除角色权限同步人员权限
        /// </summary>
        /// <param name="MAID">主体权限ID</param>
        public void DeletePerPersonnelAuthority(string MAID)
        {
            PersonnelAuthorityDAL personnelAuthorityDAL = new PersonnelAuthorityDAL();
            personnelAuthorityDAL.DeletePerPersonnelAuthority(MAID);
        }
    }
}
