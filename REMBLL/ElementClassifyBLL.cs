using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementClassifyBLL
    {
        /// <summary>
        /// 根据资源ID获取要素分类
        /// </summary>
        /// <param name="RID">资源ID</param>
        /// <returns></returns>
        public List<ElementClassify> GetElementClassifyByRID(string RID)
        {
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            return elementClassifyDAL.GetElementClassifyByRID(RID);
        }

        /// <summary>
        /// 根据要素ID获取要素分类
        /// </summary>
        /// <param name="CID">分类ID</param>
        /// <returns></returns>
        public List<ElementClassify> GetElementClassifyByID(string CID)
        {
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            return elementClassifyDAL.GetElementClassifyByID(CID);
        }

        /// <summary>
        /// 新增要素分类
        /// </summary>
        /// <param name="elementClassify">要素分类对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateElementClassify(ElementClassify elementClassify)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            //获取新的GUID
            string nid = NewData.NewGuid();
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            elementClassifyDAL.CreateElementClassify(elementClassify, dt, nid);
        }

        /// <summary>
        /// 根据ID修改要素分类
        /// </summary>
        /// <param name="elementClassify">要素分类对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutElementClassifyByID(ElementClassify elementClassify)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            elementClassifyDAL.PutElementClassifyByID(elementClassify, dt);
        }

        /// <summary>
        /// 根据ID删除要素分类
        /// </summary>
        /// <param name="CID">分类ID</param>
        public void DeleteElementClassifyByID(string CID)
        {
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            elementClassifyDAL.DeleteElementClassifyByID(CID);
        }
    }
}
