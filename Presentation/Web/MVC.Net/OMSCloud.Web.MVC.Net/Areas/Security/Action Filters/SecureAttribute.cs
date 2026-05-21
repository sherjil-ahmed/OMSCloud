using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common;
using static OMSCloud.Contracts.Common.NLogger;

using OMSCloud.Web.MVC.Net;
using System.Collections.Generic;
using System.Configuration;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Web.MVC.Net.Areas.Security.Models;

public class SecureAttribute : ActionFilterAttribute, IAuthorizationFilter// AuthorizeAttribute
{
    #region Authorization
    private bool AuthenticateOnly { get; set; } = false;
    private Dictionary<string, bool> AllowedAnonymousCached  = new Dictionary<string, bool>();
    private Dictionary<string, bool> HasPermissionCached = new Dictionary<string, bool>();
    private bool ChangeCountryIfRequired(string SecurityKey , AuthorizationContext filterContext)
    {
        if (SecurityKey == "Admin-Home-ChangeCountryDropDown")
        {
            foreach (var pd in filterContext.ActionDescriptor.GetParameters())
            {
                if (pd.ParameterName.ToLower() == "Id".ToLower())
                {
                    //var TYPE = pd.ParameterType;
                    var valObj = filterContext.Controller.ValueProvider.GetValue(pd.ParameterName);// AttemptedValue;
                    if (valObj != null && pd.ParameterType == typeof(Int64))
                    {
                        var Id = (Int64)valObj.ConvertTo(pd.ParameterType);
                        string CountryName = "Canada";
                        switch (Id)
                        {
                            case 1:
                                CountryName = DBCountryEnum.Canada.ToString();
                                break;
                            case 2:
                                CountryName = DBCountryEnum.USA.ToString();
                                break;
                            case 3:
                                CountryName = DBCountryEnum.UK.ToString();
                                break;
                            case 4:
                                CountryName = DBCountryEnum.Australia.ToString();
                                break;
                        }
                        SecurityDbContext.CountryName = CountryName;
                        ApplicationSession.Country = CountryName;
                        BaseControllerProxy.Country = CountryName;
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void OnAuthorization(AuthorizationContext filterContext)
    {
        //BaseControllerProxy.HttpCurrentContext = filterContext.HttpContext;//.Request.UrlReferrer;
        var info = MiscUtils.GetActionInfo(filterContext.ActionDescriptor);// If 'AREA' is empty or Null the it sets area = Admin_ as default value
        try
        {
            string key = info.SecurityKey;
            ChangeCountryIfRequired(info.SecurityKey, filterContext);
            if (AllowedAnonymousCached.ContainsKey(key) && AllowedAnonymousCached[key] == true)
                return;
            if (IsAllowAnonymous(filterContext, info.ControllerType))
            {
                //No need to check, already checked aboves
                if (!AllowedAnonymousCached.ContainsKey(key))
                {
                    AllowedAnonymousCached.Add(key, true);
                }
                return;
            }
            this.AuthenticateOnly = IsAuthenticateOnly(filterContext, info.ControllerType);

            //NOT Anonymous Actions need to be checked for Authorized/Authenticated/RoleBasedSecurity/PermissionAssigned
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                //var area = string.IsNullOrEmpty(info.Area) ? "Admin_" : info.Area;

                //Redirect user to login page if not yet authenticated.  This is a protected resource!
                filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = filterContext.HttpContext.Request.FilePath }));
            }
            else if (AuthenticateOnly)
            {
                //Business Tables are completly unaware of Security-User-Login i.e. UserId
                //Regardless of Business DB Schema, System passes profile Id for CreatedBy/ModifiedBy
                SetProfileId(filterContext); // to improve performance
                var country = GetCountry(filterContext);
                //return;
            }
            else
            {
                //Business Tables are completly unaware of Security-User-Login i.e. UserId
                //Regardless of Business DB Schema, System passes profile Id for CreatedBy/ModifiedBy
                long userId = SetProfileId(filterContext); // to improve  performance
                var country = GetCountry(filterContext);

                //Create permission string based on the requested controller name and action name in the format 'controllername-action'
                // String.Format("{0}-{1}-{2}", info.Area, info.ControllerName, info.ActionName);
                // already prepared above as KEY


                //HasPermission & IsSysAdmin can be cached for performance improvement
                string HasPermissionCachedKey = userId + "_" + key;
                var redirectToUnAuthorized = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorised" } });
                bool HasPermission = false;
                if (HasPermissionCached.ContainsKey(HasPermissionCachedKey))
                {
                    if (HasPermissionCached[HasPermissionCachedKey] == true)
                    {
                        if(ApplicationSession.RoleOptionPairModelList.Count == 0)
                            filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "LogOff", returnUrl = filterContext.HttpContext.Request.FilePath }));

                        return;
                    }
                    else
                    {
                        //if Unauthorised, then Logoff the user and redirect to login page.
                        //No need to explicitly show that user is unauthorized. Let him/her understand that he/she has been kicked out of the system due to illegal means of access 
                        filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "LogOff", returnUrl = filterContext.HttpContext.Request.FilePath }));
                        //filterContext.Result = redirectToUnAuthorized;
                    }
                }
                else
                {
                    HasPermission = filterContext.HttpContext.User.HasPermission(key);// & !filterContext.HttpContext.User.IsSysAdmin())
                    HasPermissionCached.Add(HasPermissionCachedKey, HasPermission); // wether TRUE or FALSE

                    if (ApplicationSession.RoleOptionPairModelList.Count == 0)
                        filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "LogOff", returnUrl = filterContext.HttpContext.Request.FilePath }));

                    //return;
                    //Continue checking the permission 
                }

                //Below AND condition is really bit-wise and ? i.e. single & or should it be &&   ???
                //var HasPermission = filterContext.HttpContext.User.HasPermission(key);// & !filterContext.HttpContext.User.IsSysAdmin())
                //if (!HasPermissionCached.ContainsKey(HasPermissionCachedKey))
                //{
                //HasPermissionCached.Add(HasPermissionCachedKey, HasPermission); // wether TRUE or FALSE
                //return;
                //}
                //else //
                if (!HasPermission)
                {
                    //var area = string.IsNullOrEmpty(info.Area) ? "Admin_" : info.Area;

                    //User doesn't have the required permission and is not a SysAdmin, return our custom “401 Unauthorized” access error
                    //Since we are setting filterContext.Result to contain an ActionResult page, the controller's action will not be run.
                    //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
                    //--------filterContext.Result = redirectToUnAuthorized;
                    
                    //if Unauthorised, then Logoff the user and redirect to login page.
                    //No need to explicitly show that user is unauthorized. Let him/her understand that he/she has been kicked out of the system due to illegal means of access 
                    filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "LogOff", returnUrl = filterContext.HttpContext.Request.FilePath }));
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
            //filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Unauthorised", action = "Error", _errorMsg = "ViewLogs" }));
            
            
            //if Unauthorised, then Logoff the user and redirect to login page.
            //No need to explicitly show that user is unauthorized. Let him/her understand that he/she has been kicked out of the system due to illegal means of access 
            filterContext.Result = new RedirectToRouteResult(info.RouteName, new RouteValueDictionary(new { controller = "Account", action = "LogOff", returnUrl = filterContext.HttpContext.Request.FilePath }));

            ErrorLog.Error(ex);
        }
    }

    #region Private Authorization Helper

    private bool IsAuthenticateOnly(AuthorizationContext filterContext, Type controllerType)
    {
        bool returnValue = false;
        var actionSecureAttributeList = filterContext.ActionDescriptor.GetCustomAttributes(typeof(SecureAttribute), true);
        if (actionSecureAttributeList != null && actionSecureAttributeList?.Length < 1)
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

    private static bool IsAllowAnonymous(AuthorizationContext filterContext, Type controllerType)
    {
        //Allow Anonymous Actions - Do not check them for Authorized/Authenticated/RoleBasedSecurity/PermissionAssigned
        if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(System.Web.Mvc.AllowAnonymousAttribute), true).Length > 0)
            return true;
        else if ((controllerType.GetCustomAttributes(typeof(System.Web.Mvc.AllowAnonymousAttribute), false)?.Length > 0) == true)//(null == true) ====>> always false
            if ((filterContext.ActionDescriptor.GetCustomAttributes(typeof(SecureAttribute), true)?.Length < 1) == true)//(null == true) ====>> always false
                return true;
        return false;
    }
    private static string GetCountry(AuthorizationContext filterContext)
    {
        BaseControllerProxy.Country = filterContext.HttpContext.Session["Country"]?.ToString();
        if (string.IsNullOrEmpty(BaseControllerProxy.Country))
            BaseControllerProxy.Country = Config.DefaultCountry;
        return BaseControllerProxy.Country;
    }

    private static long SetProfileId(AuthorizationContext filterContext)
    {
        var userId = GetUserId(filterContext);

        BaseControllerProxy.ProfileId = GetProfile(filterContext, userId);
        return userId;
    }

    private static Int64 GetProfile(AuthorizationContext filterContext, long userId)
    {
        ProfileModel model = null;
        Int64 profileId = -1;

        var Obj = filterContext.HttpContext.Session["Secure_ProfileId"];
        if (Obj != null)
        {
            if (!Int64.TryParse((Obj ?? "").ToString(), out profileId))
            {
                profileId = -1;
            }

        }        
        if (profileId < 0)
        {
            var proxy = new ProfileControllerProxy();
            model = proxy.GetProfileByUserId(userId);
            profileId = model.ProfileID;
        }

        if (profileId < 0)
        {
            var proxy = new ProfileControllerProxy();
            ProfileModel p = new ProfileModel();
            p.UserID = userId;
            p.FirstName = filterContext.HttpContext.User.Identity.Name;
            p.IsVerified = false;
            var newId = proxy.Put(p);
            profileId = newId.HasValue ? newId.Value : -1;
        }
        if (profileId > -1)
        {
            filterContext.HttpContext.Session["Secure_ProfileId"] = profileId;
            return profileId;
        }
        else
            throw new ArgumentNullException("Unable to find the curret User ID or its associated Profile ID during security Check or Secure Attribute. System tried to insert a default Profile for the User but Profile Insert is also failed. System is unable to recover. Please consult your system administrator.");
    }

    private static Int64 GetUserId(AuthorizationContext filterContext)
    {
        bool fetch = true;
        Int64 id = -1;
        var Obj = filterContext.HttpContext.Session["Secure_UserId"];
        if (Int64.TryParse((Obj ?? "").ToString(), out id))
        {
            if (id > -1)
                fetch = false;
        }
        if (fetch)
        {
            id = filterContext.HttpContext.User.Identity.GetUserId<long>();
            filterContext.HttpContext.Session["Secure_UserId"] = id;
        }
        return id;
    }
    #endregion Private Authorization Helper

    #endregion Authorization

    #region Action Filter

    //public override void OnActionExecuted(ActionExecutedContext filterContext)
    //{
    //    //var info = MiscExtenssions.GetActionInfo(filterContext.ActionDescriptor, "OnActionExecuted");
    //    //MiscExtenssions.DebugActionInfo(info);
    //    base.OnActionExecuted(filterContext);
    //}
    //public override void OnActionExecuting(ActionExecutingContext filterContext)
    //{
    //    //var info = MiscExtenssions.GetActionInfo(filterContext.ActionDescriptor, "OnActionExecuting");
    //    //MiscExtenssions.DebugActionInfo(info);
    //    base.OnActionExecuting(filterContext);
    //}
    //public override void OnResultExecuted(ResultExecutedContext filterContext)
    //{
    //    //var info = MiscExtenssions.GetActionInfo(filterContext.RequestContext.HttpContext.`);
    //    //NLogger.DebugActionInfo(info);

    //    base.OnResultExecuted(filterContext);
    //}
    //public override void OnResultExecuting(ResultExecutingContext filterContext)
    //{
    //    //var info = MiscExtenssions.GetActionInfo(filterContext.ActionDescriptor);
    //    //NLogger.DebugActionInfo(info);
    //    base.OnResultExecuting(filterContext);
    //}

    #endregion Action Filter

}