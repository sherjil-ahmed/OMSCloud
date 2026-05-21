using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using static OMSCloud.Contracts.Common.NLogger;
using static System.Net.HttpStatusCode;

namespace OMSCloud.Web.MVC.Net
{
    public class BaseMvcController : Controller
    {
        private FilterAttributeInfoModel info { get; set; } = null;

        #region Overridden
        [System.Web.Mvc.AllowAnonymous]
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            info = MiscUtils.GetActionInfo(filterContext.ActionDescriptor/*, nameof(OnActionExecuted)*/);
            //MiscUtils.DebugActionInfo(info);
            ApplicationSession.ReturnURL = this.HttpContext.Request.FilePath;
            base.OnActionExecuted(filterContext);
        }

        [System.Web.Mvc.AllowAnonymous]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            info = MiscUtils.GetActionInfo(filterContext.ActionDescriptor/*, nameof(OnActionExecuting)*/);
            //MiscUtils.DebugActionInfo(info);

            base.OnActionExecuting(filterContext);
        }

        [System.Web.Mvc.AllowAnonymous]
        protected override void OnException(ExceptionContext filterContext)
        {
            if (info != null)
            {
                info.EventName = "OnException";
                MiscUtils.DebugActionInfo(info);
            }

            var referrer = filterContext.HttpContext.Request.UrlReferrer;
            TempData["UrlReferrer"] = referrer;
            TempData["Exception"] = filterContext.Exception;
            TempData["ExceptionDetail"] = CommonUtilities.GetExceptionDetails(filterContext.Exception);
            string ExceptionType = string.Empty;

            //ErrorLog.Error(filterContext.Exception);

            if (filterContext.Exception is HttpAntiForgeryException)
            {
                var ex = filterContext.Exception as HttpAntiForgeryException;
                // show some "Security Breach Page"
                ExceptionType = "HttpAntiForgeryException";
            }
            else if (filterContext.Exception is ArgumentException)
            {
                //Either "id" is not Int or not valid
                //Some times it occurs when img tag's source link has some invalid values... e..g. alt="IMAGE"
                // need to see how we can distinguish between real error and false error. or eleminate generation of False errors. 
                var ex = filterContext.Exception as ArgumentException;
                //Invalid URI - Param either not supplied or invalid type of param supplier to the action Method
                //Page Not Found - Error Page

                ExceptionType = "ArgumentException";
            }
            else if (filterContext.Exception is HttpRequestException)
            {
                var ex = (filterContext.Exception as HttpRequestException);
                //ex.
            }
            else if (filterContext.Exception is HttpResponseException)
            {
                var ex = filterContext.Exception as HttpResponseException;
                var additionalExceptionDetail = ex.Response.Content.ReadAsStringAsync().Result;
                TempData["AdditionalExceptionDetail"] = additionalExceptionDetail;
                ExceptionType = "HttpResponseException.ReasonPhrase = " + ex.Response.ReasonPhrase;
                var deleteError = "The DELETE statement conflicted with the REFERENCE constraint";
                if (additionalExceptionDetail.Contains(deleteError))
                {/*
                    //Handle Delete conflic errors here
                    var redirect = new RedirectToRouteResult(
                        "default", 
                        new RouteValueDictionary(
                            new {
                                controller = "Error",
                                action = "DeleteConflict"
                            }));*/
                }
                #region SwitchResponseCode
                switch (ex.Response.StatusCode)
                {
                    case Continue: break;
                    case SwitchingProtocols: break;
                    case OK: break;
                    case Created: break;
                    case Accepted: break;
                    case NonAuthoritativeInformation: break;
                    case NoContent: break;
                    case ResetContent: break;
                    case PartialContent: break;
                    case MultipleChoices: break;//                    case Ambiguous: break;
                    case MovedPermanently: break;//                    case Moved: break;
                    case Found: break; //                    case HttpStatusCode.Redirect: break;
                    case SeeOther: break;//                    case RedirectMethod: break;
                    case NotModified: break;
                    case UseProxy: break;
                    case Unused: break;
                    case TemporaryRedirect: break;//                    case RedirectKeepVerb: break;
                    case BadRequest: break;
                    case Unauthorized: break;
                    case PaymentRequired: break;
                    case Forbidden: break;
                    case NotFound:
                        //Set Errorr Info for User Popup
                        //Show  Error Popup to the User
                        //Send the referrer link to error page so that user can navigate back to last working page. 
                        //Also give him the link to Home or Dashboard Page.
                        break;
                    case MethodNotAllowed: break;
                    case NotAcceptable: break;
                    case ProxyAuthenticationRequired: break;
                    case RequestTimeout: break;
                    case Conflict:
                        //Set Errorr Info for User Popup
                        //Show  Error Popup to the User
                        break;
                    case Gone: break;
                    case LengthRequired: break;
                    case PreconditionFailed: break;
                    case RequestEntityTooLarge: break;
                    case RequestUriTooLong: break;
                    case UnsupportedMediaType: break;
                    case RequestedRangeNotSatisfiable: break;
                    case ExpectationFailed:

                        break;
                    case UpgradeRequired: break;
                    case InternalServerError: break;
                    case NotImplemented: break;
                    case BadGateway: break;
                    case ServiceUnavailable: break;
                    case GatewayTimeout: break;
                    case HttpVersionNotSupported: break;
                    default:

                        break;

                }
                #endregion SwitchResponseCode
            }
            else if (filterContext.Exception is AggregateException)
            {
                var ex = filterContext.Exception as AggregateException;
                var c = ex.InnerExceptions.Count;
                c++;
            }
            else
            {
                ExceptionType = filterContext.Exception.GetType().ToString();
            }
            TempData["ExceptionType"] = ExceptionType;
            var result = new RedirectToRouteResult("default", new RouteValueDictionary(new { controller = "Error", action = "Index" }));
            
            filterContext.ExceptionHandled = true;
            filterContext.Result = result;

            ErrorLog.Error(filterContext.Exception, TempData["ExceptionDetail"]?.ToString());
            
            #region ReferenceCode
            //var info = MiscExtenssions.GetActionInfo(filterContext.ActionDescriptor, "OnActionExecuted");
            //DebugActionInfo(info);
            //base.OnActionExecuted(filterContext);

            //filterContext.ExceptionHandled = true;

            // Redirect on error:
            //filterContext.Result = RedirectToAction("Index", "Error");

            // OR set the result without redirection:
            //filterContext.Result = new ViewResult
            //{
            //    ViewName = "~/Views/Error/Index.cshtml"
            //};
            #endregion ReferenceCode
        }
        #endregion Overridden

        #region Commented
        //protected override void Initialize(RequestContext requestContext) { }

        //protected override void OnAuthentication(AuthenticationContext filterContext) {}
        //protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {}

        //protected override void OnAuthorization(AuthorizationContext filterContext) {}

        //protected override void OnResultExecuted(ResultExecutedContext filterContext) {}
        //protected override void OnResultExecuting(ResultExecutingContext filterContext) {}
        #endregion Commented

        [System.Web.Mvc.AllowAnonymous]
        public static string RenderViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null || viewEngineResult?.View == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }

}