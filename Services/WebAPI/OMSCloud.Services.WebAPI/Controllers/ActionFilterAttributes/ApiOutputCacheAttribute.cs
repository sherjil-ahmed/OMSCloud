using System;
using System.Web.Http.Filters;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    internal class ApiOutputCacheAttribute : ActionFilterAttribute
    {
        public int Duration { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            //filterContext.Response.Headers.CacheControl = new CacheControlHeaderValue()
            //{
            //    MaxAge = TimeSpan.FromMinutes(Duration),
            //    MustRevalidate = true,
            //    Private = true
            //};
        }
        //public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken) { return null; }
        //public override void OnActionExecuting(HttpActionContext actionContext) { }
        //public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken) { return null; }

    }
}