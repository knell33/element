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
    public class CountNormController : ControllerBase
    {
        /// <summary>
        /// 根据资源ID获取统计指标定义
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CountNorm> GetAllCountNormByRID(string RID)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            return countNormBLL.GetAllCountNormByRID(RID);
        }

        /// <summary>
        /// 根据指标定义ID获取统计指标定义
        /// </summary>
        /// <param name="ID">指标定义ID</param>
        /// <returns></returns>
        [HttpPost]
        public List<CountNorm> GetAllCountNormByID(string ID)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            return countNormBLL.GetAllCountNormByID(ID);
        }

        /// <summary>
        /// 新增统计指标定义
        /// </summary>
        /// <param name="CountNorm">统计指标定义JSON对象</param>
        [HttpPost]
        public void CreateCountNorm([FromBody]CountNorm countNorm)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            countNormBLL.CreateCountNorm(countNorm);
        }
        /// <summary>
        /// 修改统计指标定义
        /// </summary>
        /// <param name="CountNorm">统计指标JSON对象</param>
        [HttpPut]
        public void PutCountNormByID([FromBody]CountNorm countNorm)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            countNormBLL.PutCountNormByID(countNorm);
        }

        /// <summary>
        /// 删除统计指标定义
        /// </summary>
        /// <param name="countNormID">统计指标ID</param>
        [HttpDelete]
        public void DeleteCountNormByID(string countNormID)
        {
            CountNormBLL countNormBLL = new CountNormBLL();
            countNormBLL.DeleteCountNormByID(countNormID);
        }
    }
}