using OMSCloud.Contracts.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                var flag = context.Request.ShouldIncludeErrorDetail();
                //context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                var LogMsg = CommonUtilities.GetExceptionDetails(context.Exception);
                
                Log.Error(context.Exception);
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, LogMsg);
            }
        }
    }
}