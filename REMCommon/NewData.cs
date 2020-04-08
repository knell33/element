using System;
using System.Collections.Generic;
using System.Text;

namespace REMCommon
{
    public static class NewData
    {
        //yyyy-MM-dd HH:mm:ss 样式的当前日期时间
        public static DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //获取新的GUID
        public static string nid = Guid.NewGuid().ToString();
       

    }
}
