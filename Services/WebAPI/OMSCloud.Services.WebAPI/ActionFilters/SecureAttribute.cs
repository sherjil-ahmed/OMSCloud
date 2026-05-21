using Microsoft.AspNet.Identity;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using static OMSCloud.Contracts.Common.NLogger;
using System.Linq;
using System.Web;
using System.Web.Http;
using OMSCloud.Services.WebAPIs.Common;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Net;
using System.Text;
using System.Security.Claims;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Services.WebAPIs
{
    public class SecureAttribute : AuthorizationFilterAttribute, IAuthorizationFilter, IFilter// AuthorizeAttribute
    {//AuthorizeAttribute : AuthorizationFilterAttribute
        //FilterAttribute, IAuthorizationFilter, IFilter
        public bool AuthenticateOnly { get; set; } = false;        

        private Dictionary<string, bool> AllowedAnonymousCached = new Dictionary<string, bool>();
        private Dictionary<string, bool> HasPermissionCached = new Dictionary<string, bool>();
        #region Authorization
        //public virtual Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken){}
        public override async Task OnAuthorizationAsync(HttpActionContext filterContext, CancellationToken cancellationToken)
        {
            //BaseControllerProxy.HttpCurrentContext = filterContext.HttpContext;//.Request.UrlReferrer;
            var info = MiscUtils.GetActionInfo(filterContext.ActionDescriptor);// If 'AREA' is empty or Null the it sets area = Admin_ as default value
            try
            {
                string key = info.SecurityKey;
                if (AllowedAnonymousCached.ContainsKey(key) && AllowedAnonymousCached[key] == true)
                    return;
                if (IsAllowAnonymous(filterContext, info.ControllerType))
                {
                    //No need to check, already checked aboves
                    //if( ! AllowedAnonymousCached.ContainsKey(key))
                    /**/
                    AllowedAnonymousCached.Add(key, true);
                    return;
                }
                this.AuthenticateOnly = IsAuthenticateOnly(filterContext, info.ControllerType);

                //NOT Anonymous Actions need to be checked for Authorized/Authenticated/RoleBasedSecurity/PermissionAssigned
                if (!filterContext.RequestContext.Principal.Identity.IsAuthenticated)
                {
                    //Redirect user to login page if not yet authenticated.  This is a protected resource!
                    filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Request requires to be from Authenticated user. But the called is not authenticated.");
                    //new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = filterContext.HttpContext.Request.FilePath }));
                }
                else if (AuthenticateOnly)
                {

                }
                else
                {
                    //Business Tables are completly unaware of Security-User-Login i.e. UserId
                    //Regardless of Business DB Schema, System passes profile Id for CreatedBy/ModifiedBy
                    //string userId = ((ClaimsIdentity)filterContext.RequestContext.Principal.Identity).Claims.FirstOrDefault().Value;//.FindFirstValue(ClaimTypes.NameIdentifier);
                    string userId = "1";
                    var claims = ((ClaimsIdentity)filterContext.RequestContext.Principal.Identity).Claims;
                    
                    foreach (var c in claims)
                    {
                        if (c.Type == MiscUtils.IdentityClaimForClientId)
                            userId = c.Value;
                    }
                    //.FindAll(filterContext.RequestContext.Principal.Identity.AuthenticationType);
                    //GetUserId<long>(); // to improve  performance
                    
                    
                    //var country = GetCountry(filterContext);

                    //Create permission string based on the requested controller name and action name in the format 'controllername-action'
                    // String.Format("{0}-{1}-{2}", info.Area, info.ControllerName, info.ActionName);
                    // already prepared above as KEY


                    //HasPermission & IsSysAdmin can be cached for performance improvement
                    string HasPermissionCachedKey = userId + "_" + key;
                    ////var redirectToUnAuthorized = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorised" } });
                    //filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                    bool HasPermission = false;
                    if (HasPermissionCached.ContainsKey(HasPermissionCachedKey))
                    {
                        if (HasPermissionCached[HasPermissionCachedKey] == true)
                        {
                            return;
                        }
                        else
                        {
                            filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User doesn't have the required permission");
                            ////filterContext.Result = redirectToUnAuthorized;
                            //redirect to unauthorised page
                        }
                    }
                    else
                    {
                        long UserId = 0;
                        if (long.TryParse(userId, out UserId))
                        {
                            HasPermission = filterContext.RequestContext.Principal.HasPermission(key, userId);
                            var pComp = new ProfileBusinessComponent();
                            if (!HasPermission)
                            {
                                var profile = pComp.GetProfileByUserId(UserId);
                                HasPermission = (profile != null && profile.UserTypeID == (int)DBUserTypeEnum.Seller);
                            }
                            HasPermissionCached.Add(HasPermissionCachedKey, HasPermission); // wether TRUE or FALSE
                        }
                    }
                    if (!HasPermission)
                    {   //User doesn't have the required permission and is not a SysAdmin, return our custom “401 Unauthorized” access error
                        //Since we are setting filterContext.Result to contain an ActionResult page, the controller's action will not be run.
                        //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
                        filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User doesn't have the required permission");
                    }
                    //If the user has the permission to run the controller's action, the filterContext.Result will be uninitialized and
                    //executing the controller's action is dependant on whether filterContext.Result is uninitialized.
                }
            }
            catch (AggregateException aex)
            { // Call to WebApi took too long and therefore Task was Cancled. -- Nothing to do with Authentication or Authorization failed
              // need to be redirected to Task Cancled Page to retry
              //throw aex;
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, aex.Message);
                ErrorLog.Error(aex);
            }
            catch (HttpResponseException ex)
            {
                //throw ex;
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                ErrorLog.Error(ex);
                // Need to Handle error or Redirection from here. It will be auto handled by BaseMvcController 
                // (Because it is "HttpResponseException" generated b/c of some Api Call, and 
                // responses/error in Api calls are handled by BaseMvcController - OnException
            }
            catch (Exception ex)
            {
                //var area = string.IsNullOrEmpty(info.Area) ? "Admin_" : info.Area;
                //, _errorMsg = ex.Message
                ////filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Unauthorised", action = "Error", _errorMsg = "ViewLogs" }));
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                ErrorLog.Error(ex);
            }

            return;// base.OnAuthorizationAsync(filterContext, cancellationToken);
        }
        public void OnAuthorization1(HttpActionContext filterContext)
        {
            //BaseControllerProxy.HttpCurrentContext = filterContext.HttpContext;//.Request.UrlReferrer;
            var info = MiscUtils.GetActionInfo(filterContext.ActionDescriptor);// If 'AREA' is empty or Null the it sets area = Admin_ as default value
            try
            {
                string key = info.SecurityKey;
                if (AllowedAnonymousCached.ContainsKey(key) && AllowedAnonymousCached[key] == true)
                    return;
                if (IsAllowAnonymous(filterContext, info.ControllerType))
                {
                    //No need to check, already checked aboves
                    //if( ! AllowedAnonymousCached.ContainsKey(key))
                    /**/
                    AllowedAnonymousCached.Add(key, true);
                    return;
                }
                this.AuthenticateOnly = IsAuthenticateOnly(filterContext, info.ControllerType);

                //NOT Anonymous Actions need to be checked for Authorized/Authenticated/RoleBasedSecurity/PermissionAssigned
                if (!filterContext.RequestContext.Principal.Identity.IsAuthenticated)
                {
                    //Redirect user to login page if not yet authenticated.  This is a protected resource!
                    filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                    //new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = filterContext.HttpContext.Request.FilePath }));
                }
                else if (AuthenticateOnly)
                {

                }
                else
                {
                    //Business Tables are completly unaware of Security-User-Login i.e. UserId
                    //Regardless of Business DB Schema, System passes profile Id for CreatedBy/ModifiedBy
                    string userId = ((ClaimsIdentity)filterContext.RequestContext.Principal.Identity).FindFirstValue(ClaimTypes.NameIdentifier);
                    //GetUserId<long>(); // to improve  performance
                    
                    //var country = GetCountry(filterContext);

                    //Create permission string based on the requested controller name and action name in the format 'controllername-action'
                    // String.Format("{0}-{1}-{2}", info.Area, info.ControllerName, info.ActionName);
                    // already prepared above as KEY


                    //HasPermission & IsSysAdmin can be cached for performance improvement
                    string HasPermissionCachedKey = userId + "_" + key;
                    ////var redirectToUnAuthorized = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorised" } });
                    //filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                    bool HasPermission = false;
                    if (HasPermissionCached.ContainsKey(HasPermissionCachedKey))
                    {
                        if (HasPermissionCached[HasPermissionCachedKey] == true)
                        {
                            return;
                        }
                        else
                        {
                            filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                            ////filterContext.Result = redirectToUnAuthorized;
                            //redirect to unauthorised page
                        }
                    }
                    else
                    {
                        HasPermission = filterContext.RequestContext.Principal.HasPermission(key, userId);
                        HasPermissionCached.Add(HasPermissionCachedKey, HasPermission); // wether TRUE or FALSE
                    }

                    if (!HasPermission)
                    {   //User doesn't have the required permission and is not a SysAdmin, return our custom “401 Unauthorized” access error
                        //Since we are setting filterContext.Result to contain an ActionResult page, the controller's action will not be run.
                        //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
                        filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                    }
                    //If the user has the permission to run the controller's action, the filterContext.Result will be uninitialized and
                    //executing the controller's action is dependant on whether filterContext.Result is uninitialized.
                }
            }
            catch (AggregateException aex)
            { // Call to WebApi took too long and therefore Task was Cancled. -- Nothing to do with Authentication or Authorization failed
              // need to be redirected to Task Cancled Page to retry
                throw aex;
            }
            catch (HttpResponseException ex)
            {
                throw ex;
                // Need to Handle error or Redirection from here. It will be auto handled by BaseMvcController 
                // (Because it is "HttpResponseException" generated b/c of some Api Call, and 
                // responses/error in Api calls are handled by BaseMvcController - OnException
            }
            catch (Exception ex)
            {
                //var area = string.IsNullOrEmpty(info.Area) ? "Admin_" : info.Area;
                //, _errorMsg = ex.Message
                ////filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Unauthorised", action = "Error", _errorMsg = "ViewLogs" }));
                filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Specialized msg");
                ErrorLog.Error(ex);
            }
        }

        #region Private Authorization Helper

        private bool IsAuthenticateOnly(HttpActionContext filterContext, Type controllerType)
        {
            bool returnValue = false;
            var actionSecureAttributeList = filterContext.ActionDescriptor.GetCustomAttributes<SecureAttribute>(true);
            if (actionSecureAttributeList != null && actionSecureAttributeList?.Count < 1)
            {
                var controllerSecureAttributeList = controllerType.GetCustomAttributes(typeof(SecureAttribute), true);
                if (controllerSecureAttributeList != null && controllerSecureAttributeList?.Length > 0)
                {
                    var secureAttrib = (SecureAttribute)controllerSecureAttributeList[0];
                    returnValue = secureAttrib.AuthenticateOnly;
                }
            }
            else
            {
                var secureAttribAction = (SecureAttribute)actionSecureAttributeList[0];
                returnValue = secureAttribAction.AuthenticateOnly;
            }
            return returnValue;
        }

        private static bool IsAllowAnonymous(HttpActionContext filterContext, Type controllerType)
        {
            //Allow Anonymous Actions - Do not check them for Authorized/Authenticated/RoleBasedSecurity/PermissionAssigned
            if (filterContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count > 0)
                return true;
            else if ((controllerType.GetCustomAttributes(typeof(AllowAnonymousAttribute), false)?.Length > 0) == true)//(null == true) ====>> always false
                if ((filterContext.ActionDescriptor.GetCustomAttributes<SecureAttribute>(true)?.Count < 1) == true)//(null == true) ====>> always false
                    return true;
            return false;
        }

        #endregion Private Authorization Helper
        #endregion Authorization
    }
}