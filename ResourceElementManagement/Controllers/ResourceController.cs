﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMBLL;
using REMModel;

namespace ResourceElementManagement.Controllers
{
 
    [Route("api/[Action]")]
    public class ResourceController : ControllerBase
    {
        /// <summary>
        /// 获取资源要素目录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Resource> GetAllResources()
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            return resourceBLL.GetAll();
        }

        /// <summary>
        /// 根据资源ID获取资源目录
        /// </summary>
        /// <param name="RID">资源ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<Resource> GetResourceByID(string RID)
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            return resourceBLL.GetResourceByID(RID);
        }

        /// <summary>
        /// 根据资源ID获取资源类型
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Resource> GetTypeByRID(string RID)
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            return resourceBLL.GetTypeByRID(RID);
        }

        /// <summary>
        /// 新增资源目录
        /// </summary>
        /// <param name="resource">资源目录JSON对象</param>
        [HttpPost]
        public void CreateResource([FromBody]Resource resource)
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            resourceBLL.CreateResource(resource);
        }

        /// <summary>
        /// 修改资源目录
        /// </summary>
        /// <param name="resource">资源目录JSON对象</param>
        [HttpPut]
        public void PutResourceByID([FromBody]Resource resource)
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            resourceBLL.PutResourceByID(resource);
        }

        /// <summary>
        /// 删除资源目录
        /// </summary>
        /// <param name="ResourceID">资源ID</param>
        [HttpDelete]
        public void DeleteResourceByID(string ResourceID)
        {
            ResourceBLL resourceBLL = new ResourceBLL();
            resourceBLL.DeleteResourceByID(ResourceID);
        }
    }
}