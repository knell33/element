using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class CountNormBLL
    {
        /// <summary>
        /// 根据资源ID获取统计指标定义
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<CountNorm> GetAllCountNormByRID(string RID)
        {
            CountNormDAL countNormDAL = new CountNormDAL();
            return countNormDAL.GetAllCountNormByRID(RID);
        }

        /// <summary>
        /// 根据获取统计指标定义
        /// </summary>
        /// <param name="ID">指标定义ID</param>
        /// <returns></returns>
        public List<CountNorm> GetAllCountNormByID(string ID)
        {
            CountNormDAL countNormDAL = new CountNormDAL();
            return countNormDAL.GetAllCountNormByID(ID);
        }

        /// <summary>
        /// 新增统计指标
        /// </summary>
        /// <param name="countNorm">统计指标对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateCountNorm(CountNorm countNorm)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            //获取新的GUID
            string nid = NewData.NewGuid();
            CountNormDAL countNormDAL = new CountNormDAL();
            countNormDAL.CreateCountNorm(countNorm, dt, nid);
        }

        /// <summary>
        /// 根据ID修改资源目录
        /// </summary>
        /// <param name="countNorm">资源目录对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutCountNormByID(CountNorm countNorm)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            CountNormDAL countNormDAL = new CountNormDAL();
            countNormDAL.PutCountNormByID(countNorm, dt);
        }

        /// <summary>
        /// 根据ID删除统计指标
        /// </summary>
        /// <param name="ID">统计指标ID</param>
        public void DeleteCountNormByID(string countNormID)
        {
            CountNormDAL countNormDAL = new CountNormDAL();
            countNormDAL.DeleteCountNormByID(countNormID);
        }

    }
}
