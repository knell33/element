using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementBLL
    {
        /// <summary>
        /// 根据资源ID查找要素目录
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public List<Element> GetAllElementByResourceID(string RID)
        {
            ElementDAL elementDAL = new ElementDAL();
            return elementDAL.GetAllElementByResourceID(RID);
        }
        /// <summary>
        /// 要素目录新增
        /// </summary>
        /// <param name="element"></param>
        public void CreateElement(Element element)
        {
            DateTime dt = NewData.NewDate();
            string uid = NewData.NewGuid();
            ElementDAL elementDAL = new ElementDAL();
            elementDAL.CreateElement(element, dt, uid);
        }

        /// <summary>
        /// 根据要素ID修改要素信息
        /// </summary>
        /// <param name="element">要素目录实体</param>
        public void UpdateElementByEID(Element element)
        {
            DateTime dt = NewData.NewDate();
            ElementDAL elementDAL = new ElementDAL();
            elementDAL.UpdateElementByEID(element,dt);
        }

        /// <summary>
        /// 根据要素ID删除要素信息
        /// </summary>
        /// <param name="EID">要素ID</param>
        public void DeleteElementByEID(string EID)
        {
            ElementDAL elementDAL = new ElementDAL();
            elementDAL.DeleteElementByEID(EID);
        }
    }
}
