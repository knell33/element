using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class MainAuthorityBLL
    {
        /// <summary>
        /// 根据资源明细ID查找主体权限数据
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<MainAuthority> GetAllMainAuthorityByDetailID(string DID)
        {
            MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
            return mainAuthorityDAL.GetAllMainAuthorityByDetailID(DID);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<MainAuthority> GetAllRoleInfo()
        {
            MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
            return mainAuthorityDAL.GetAllRoleInfo();
        }

        /// <summary>
        /// 新增主体权限
        /// </summary>
        /// <param name="mainAuthority">主体权限对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateMainAuthority(MainAuthority mainAuthority)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            //获取新的GUID
            string nid = NewData.NewGuid();
            MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
            mainAuthorityDAL.CreateMainAuthority(mainAuthority, dt, nid);
        }

        /// <summary>
        /// 根据AID修改主体权限
        /// </summary>
        /// <param name="mainAuthority">主体权限对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutMainAuthorityByAID(MainAuthority mainAuthority)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
            mainAuthorityDAL.PutMainAuthorityByAID(mainAuthority, dt);
        }

        /// <summary>
        /// 根据AID删除主体权限
        /// </summary>
        /// <param name="AID">主体权限ID</param>
        public void DeleteMainAuthorityByAID(string AID)
        {
            MainAuthorityDAL mainAuthorityDAL = new MainAuthorityDAL();
            mainAuthorityDAL.DeleteMainAuthorityByAID(AID);
        }

    }
}
