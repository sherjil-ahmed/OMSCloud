using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSCloud.Web.MVC.Net
{
    public class ApplicationSession
    {
        public static string Secure_ProfileId
        {
            get { return HttpContext.Current.Session["Secure_ProfileId"]?.ToString(); }
            set { HttpContext.Current.Session["Secure_ProfileId"] = value; }
        }
        public static string Secure_UserId
        {
            get { return HttpContext.Current.Session["Secure_UserId"]?.ToString(); }
            set { HttpContext.Current.Session["Secure_UserId"] = value; }
        }
        public static string Country
        {
            get { return HttpContext.Current.Session["Country"]?.ToString(); }
            set { HttpContext.Current.Session["Country"] = value; }
        }
 
        public static long ProvinceId {
            get {
                var ProvinceIdObj = HttpContext.Current.Session["ProvinceId"];
                long provinceId = -1;
                if (ProvinceIdObj != null)
                {
                    Int64.TryParse(ProvinceIdObj.ToString(), out provinceId);
                    //provinceId = Convert.ToInt64(provinceId);
                }
                return provinceId;
            }
            set { HttpContext.Current.Session["ProvinceId"] = value; }
        }
        public static long CityId
        {
            get
            {
                var cityIdObj = HttpContext.Current.Session["CityId"];
                long cityId = -1;
                if (cityIdObj != null)
                {
                    Int64.TryParse(cityIdObj.ToString(), out cityId);
                    //cityId = Convert.ToInt64(cityIdObj);
                }
                return cityId;
            }
            set { HttpContext.Current.Session["CityId"] = value; }
        }
        public static List<RoleOptionPairModel> RoleOptionPairModelList
        {
            get
            {
                if (HttpContext.Current.Session["RoleOptionPair"] != null)
                    return (List<RoleOptionPairModel>)HttpContext.Current.Session["RoleOptionPair"];
                else
                    return new List<RoleOptionPairModel>();
            }
            set
            {
                HttpContext.Current.Session["RoleOptionPair"] = value;
            }
        }
        public static string ReturnURL
        {
            get { return HttpContext.Current.Session["ReturnURL"]?.ToString(); }
            set { HttpContext.Current.Session["ReturnURL"] = value; }
        }
    }
}