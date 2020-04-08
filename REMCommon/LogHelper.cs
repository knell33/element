using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMCommon
{
    public class LogHelper
    {
        public static string logpath = "";

        /// <summary>
        /// 正常记录
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void WriteLog(Exception ex, string message)
        {
            try
            {
                FileOperate.SaveStringToFile("------------------------------------开始记录-----------------------------------------", logpath, false, false);
                FileOperate.SaveStringToFile(message, logpath, false, true);

                if (ex != null)
                {
                    string exmess = "异常信息：" + ex.Message + "\n异常对象：" + ex.Source + "\n调用堆栈：\n" + ex.StackTrace.Trim() + "\n触发方法：" + ex.TargetSite;
                    FileOperate.SaveStringToFile(exmess, logpath, false, true);
                }
            }
            catch (Exception e)
            {
                message = (ex != null) ? message + ex.ToString() : message;
                FileOperate.SaveStringToFile(e.ToString() + "【详细信息】：" + message, logpath, false, true);
            }
            finally
            {
                FileOperate.SaveStringToFile("------------------------------------结束记录-----------------------------------------", logpath, false, false);
            }
        }
        /// <summary>
        /// 正常记录
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void WriteErrorLog(Exception ex, string message)
        {
            try
            {
                FileOperate.SaveStringToFile("------------------------------------开始记录【出现异常，请关注】-----------------------------------------", logpath, false, false);
                FileOperate.SaveStringToFile(message, logpath, false, true);
                if (ex != null)
                {
                    string exmess = "异常信息：" + ex.Message + "\n异常对象：" + ex.Source + "\n调用堆栈：\n" + ex.StackTrace.Trim() + "\n触发方法：" + ex.TargetSite;
                    FileOperate.SaveStringToFile(exmess, logpath, false, true);
                }
            }
            catch (Exception e)
            {
                message = (ex != null) ? message + ex.ToString() : message;
                FileOperate.SaveStringToFile(e.ToString() + "【详细信息】：" + message, logpath, false, true);
            }
            finally
            {
                FileOperate.SaveStringToFile("------------------------------------结束记录【异常信息结束】-----------------------------------------", logpath, false, false);
            }
        }
    }
}
