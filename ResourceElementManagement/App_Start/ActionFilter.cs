
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using REMCommon;

namespace ResourceElementManagement
{
    public class ActionFilter : ActionFilterAttribute
    {
        private readonly string Key = "_thisWebApiOnActionMonitorLog_";
        private string logpath = AppDomain.CurrentDomain.BaseDirectory + "Log/log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            actionContext.HttpContext.Request.EnableBuffering();
            WebApiMonitorLog MonLog = new WebApiMonitorLog();
            MonLog.ExcuteStartTime = DateTime.Now;
            var controllerActionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;

            //获取Action 参数
            MonLog.ActionParams = actionContext.ActionArguments;
            MonLog.HttpRequestHeaders = actionContext.HttpContext.Request.Headers.ToString();
            MonLog.HttpMethod = actionContext.HttpContext.Request.Method;
            MonLog.IP = actionContext.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            byte[] arr = ObjectToBytes(MonLog);

            actionContext.HttpContext.Session.Set(Key, arr);
        }
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {

            base.OnActionExecuted(actionExecutedContext);
            LogHelper.logpath = logpath;
            byte[] vs;
            if (!actionExecutedContext.HttpContext.Session.TryGetValue(Key, out vs))
            {
                LogHelper.WriteErrorLog(null, "尝试获取值失败");
                return;
            }
            WebApiMonitorLog MonLog = BytesToObject(vs) as WebApiMonitorLog;
            actionExecutedContext.HttpContext.Session.Clear();
            MonLog.ExcuteEndTime = DateTime.Now;
            MonLog.ActionName = actionExecutedContext.RouteData.Values["Action"].ToString();
            MonLog.ControllerName = actionExecutedContext.RouteData.Values["Controller"].ToString();
            LogHelper.WriteLog(null, MonLog.GetLoginfo());

            if (actionExecutedContext.Exception != null)
            {
                IDictionary<string, object> redataList = MonLog.ActionParams;
                string redata = string.Empty;
                foreach (string key in redataList.Keys)
                {
                    redata += key + " , ";

                }
                string Msg = string.Format(@"
                请求【{0}Controller】的【{1}】产生异常：
                  Http请求头:{2}
                  客户端IP：{3},
                  请求方法：{4}
                  请求参数：{5}", MonLog.ControllerName, MonLog.ActionName, MonLog.HttpRequestHeaders, MonLog.IP, MonLog.HttpMethod, redata);
                LogHelper.WriteErrorLog(actionExecutedContext.Exception, Msg);
                // throw new Exception("发生异常：" + actionExecutedContext.Exception.Message);
            }
        }

        /// <summary>
        /// 标准返回
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult.Value == null)
                {
                    context.Result = new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
                }
                else
                {
                    context.Result = new ObjectResult(new { Success = true, Msg = "", Data = objectResult.Value });
                }
            }
            else if (context.Result is JsonResult)
            {
                var objectResult = context.Result as JsonResult;
                if (objectResult.Value == null)
                {
                    context.Result = new JsonResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
                }
                else
                {
                    context.Result = new ObjectResult(new { Success = true, Msg = "", Data = objectResult.Value });
                }
            }
            else if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
            }
            else if (context.Result is ContentResult)
            {
                context.Result = new ObjectResult(new { code = 200, msg = "", result = (context.Result as ContentResult).Content });
            }
            else if (context.Result is StatusCodeResult)
            {
                context.Result = new ObjectResult(new { code = (context.Result as StatusCodeResult).StatusCode, sub_msg = "", msg = "" });
            }
        }

        /// <summary>
        /// 对象转byte
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// byte转对象
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static object BytesToObject(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(ms);
            }
        }


    }
}