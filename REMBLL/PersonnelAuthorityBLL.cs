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
    }
}
