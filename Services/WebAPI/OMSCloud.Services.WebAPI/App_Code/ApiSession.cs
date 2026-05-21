using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace OMSCloud.Services.WebAPIs
{
    public static class ApiSession
    {
        public static HttpSessionState Session => HttpContext.Current.Session;

        public static IUserPrinciple User //=> Session["User"] != null ?  Session["User"] as IUserPrinciple : null;
        {
            get
            {
                try
                {
                    //var x = Session["User"] == null ? null : Session["User"] as IUserPrinciple;
                    IUserPrinciple user = null;
                    var seessionObj = Session["User"];
                    if (seessionObj != null && seessionObj is IUserPrinciple)
                        user = seessionObj as IUserPrinciple;
                    return user;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {

                }
            }
        }
    }

    public class IUserPrinciple {
        public int UserId { get; set; }
        public Guid UserSessionCode { get; set; }
    }
}