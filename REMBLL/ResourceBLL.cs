using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ResourceBLL
    {
        /// <summary>
        /// 获取资源目录
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetAll()
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            return resourceDAL.GetAll();
        }

        /// <summary>
        /// 根据资源ID获取资源目录
        /// </summary>
        /// <param name="RID">资源ID</param>
        /// <returns></returns>
        public List<Resource> GetResourceByID(string RID)
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            return resourceDAL.GetResourceByID(RID);
        }

        /// <summary>
        /// 根据资源ID获取资源类型
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Resource> GetTypeByRID(string RID)
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            return resourceDAL.GetTypeByRID(RID);
        }

        /// <summary>
        /// 新增资源目录
        /// </summary>
        /// <param name="resource">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateResource(Resource resource)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            //获取新的GUID
            string nid = NewData.NewGuid();
            ResourceDAL resourceDAL = new ResourceDAL();
            resourceDAL.CreateResource(resource,dt,nid);
        }

        /// <summary>
        /// 根据ID修改资源目录
        /// </summary>
        /// <param name="resource">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutResourceByID(Resource resource)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            ResourceDAL resourceDAL = new ResourceDAL();
            resourceDAL.PutResourceByID(resource, dt);
        }

        /// <summary>
        /// 根据ID删除资源目录
        /// </summary>
        /// <param name="ID">资源ID</param>
        public void DeleteResourceByID(string ResourceID)
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            resourceDAL.DeleteResourceByID(ResourceID);
        }

        /// <summary>
        /// 根据资源ID获取资源类型
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Resource> GetTypeByRID(string RID)
        {
            ResourceDAL resourceDAL = new ResourceDAL();
            return resourceDAL.GetTypeByRID(RID);
        }
    }
}
