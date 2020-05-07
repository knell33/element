using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REMCommon;

namespace ResourceElementManagement.Controllers
{
    [Route("api/[Action]")]
    public class ADController : ControllerBase
    {
        /// <summary>
        /// 获取中联用户信息
        /// </summary>
        [HttpPost]
        public object GetZLAllUser()
        {
            // ADHelper aDHelper = new ADHelper();
            DirectoryEntry directoryEntry1 = ADHelper.GetDirectoryEntry();
            object directory = ADUtil.getZLAllUser();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            return directory;
        }


        /// <summary>
        /// 获取中联用户信息1
        /// </summary>
        [HttpPost]
        public object GetZLAllUser1()
        {
            // ADHelper aDHelper = new ADHelper();
            DirectoryEntry directoryEntry1 = ADHelper.GetDirectoryEntry();
            object directory = ADUtil.getZLAllUser1();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            return directory;
        }
    }
}