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
    
    public class TestController : ControllerBase
    {
        [HttpPost]
        public object FunctionTest(string type)
        {
            TestBLL testBLL = new TestBLL();
            return testBLL.FunctionTest(type);
        }
    }
}