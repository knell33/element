using System;
using System.Collections.Generic;
using System.Text;

namespace REMCommon
{
    public static class NewData
    {

        //获取新的GUID
        public static string NewGuid()
        {
            var guid = Guid.NewGuid().ToString();
            return  guid;
        }


        //获取yyyy-MM-dd HH:mm:ss 样式的当前日期时间
        public static DateTime NewDate()
        {
            DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return dt;
        }





    }
}
