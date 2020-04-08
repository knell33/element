using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class ElementClassifyBLL
    {
        public List<ElementClassify> GetAllByResourceID(string RID)
        {
            ElementClassifyDAL elementClassifyDAL = new ElementClassifyDAL();
            return elementClassifyDAL.GetAllByResourceID(RID);
        }
    }
}
