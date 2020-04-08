using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceElementManagement
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var strFirstMsg = context.Exception.GetBaseException().Message;
        
            var result = JsonResult(null, strFirstMsg, false);
            result.Value = strFirstMsg;
            result.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = result;
        }

        public static Microsoft.AspNetCore.Mvc.JsonResult JsonResult(object objData, string strMessage, bool blnSuccess = true)
        {
            object obj;
            if (blnSuccess)
                obj = new
                {
                    //success = blnSuccess,
                    message = strMessage,
                    data = objData
                };
            else
                obj = new
                {
                    //success = blnSuccess,
                    message = strMessage
                };


            return new Microsoft.AspNetCore.Mvc.JsonResult(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

    }
}
