using REMDAL;
using REMModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace REMBLL
{
    public class TestBLL
    {
        public object FunctionTest(string type)
        {
            TestDAL testDAL = new TestDAL();
            return testDAL.FunctionTest(type);
        }
    }
}
