using REMCommon;
using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementRangeBLL
    {
        /// <summary>
        /// 根据要素ID获取文本值域选项
        /// </summary>
        /// <param name="EID"></param>
        /// <returns></returns>
        public List<ElementRange> GetAllElementRangeByEID(string EID)
        {
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            return elementRangeDAL.GetAllElementRangeByEID(EID);
        }

        /// <summary>
        /// 根据选项值域ID获取文本值域选项
        /// </summary>
        /// <param name="ID">选项值域ID</param>
        /// <returns></returns>
        public List<ElementRange> GetAllElementRangeByID(string ID)
        {
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            return elementRangeDAL.GetAllElementRangeByID(ID);
        }

        /// <summary>
        /// 新增文本值域选项
        /// </summary>
        /// <param name="elementRange">文本值域选项对象</param>
        /// <param name="dt">最后修改时间</param>
        /// <param name="nid">新GUID</param>
        public void CreateElementRange(ElementRange elementRange)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            //获取新的GUID
            string nid = NewData.NewGuid();
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            elementRangeDAL.CreateElementRange(elementRange, dt, nid);
        }

        /// <summary>
        /// 根据ID修改文本值域选项
        /// </summary>
        /// <param name="elementRange">文本值域选项对象</param>
        /// <param name="dt">最后修改时间</param>
        public void PutElementRangeByID(ElementRange elementRange)
        {
            ///获取当前时间
            DateTime dt = NewData.NewDate();
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            elementRangeDAL.PutElementRangeByID(elementRange, dt);
        }

        /// <summary>
        /// 根据ID删除文本值域选项
        /// </summary>
        /// <param name="ID">值域选项ID</param>
        public void DeleteElementRangeByID(string ID)
        {
            ElementRangeDAL elementRangeDAL = new ElementRangeDAL();
            elementRangeDAL.DeleteElementRangeByID(ID);
        }
    }
}
