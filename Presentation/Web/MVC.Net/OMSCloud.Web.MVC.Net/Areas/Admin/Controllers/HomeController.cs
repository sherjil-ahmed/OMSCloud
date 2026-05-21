using Microsoft.AspNet.Identity;
using OMSCloud.Contracts.Caching;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Proxies.WebAPIs.ProxyControllers.TokenManagement;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Web.MVC.Net.Areas.Security;
using OMSCloud.Web.MVC.Net.Areas.Security.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using x = System.Web.Http;
using System.Web.Mvc;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class HomeController : BaseMvcController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return RedirectToAction("Stats");
        }
        public ActionResult Stats()
        {
            StatsModel model = new StatsModel();
            #region ShopStats
            var shop = new SupplierControllerProxy();
            try
            {
                var ShopStatsRequestModel = new ShopStatsModel
                {
                    CountryId = 0,
                    ProvinceId = ApplicationSession.ProvinceId,
                    CityId = ApplicationSession.CityId,
                    SortBy = "1",
                };
                model.NewOpenedShops = shop.GetCountByFilter(ShopStatsRequestModel);
                ShopStatsRequestModel.SortBy = "2";
                model.TotalOpenedShops = shop.GetCountByFilter(ShopStatsRequestModel);
                ShopStatsRequestModel.SortBy = "3";
                model.InactiveShops = shop.GetCountByFilter(ShopStatsRequestModel);
                //model.InactiveShops = user.GetInactiveShopCount();
                ShopStatsRequestModel.SortBy = "4";
                model.ActiveShops = shop.GetCountByFilter(ShopStatsRequestModel);
                #endregion ShopStats
                #region UserStats
                var user = new ProfileControllerProxy();
                model.InactiveUsers = user.GetInactiveProfileCount();
                model.NewUsers = user.GetNewProfileCount();
                model.TotalUsers = user.GetAllProfileCount();
                #endregion
                #region OrderStats
                var order = new OrderControllerProxy();
                var OrderStatsRequestModel = new OrderAdminStatsModel
                {
                    CountryId = 0,
                    ProvinceId = ApplicationSession.ProvinceId,
                    CityId = ApplicationSession.CityId,
                    OrderStatusId = (long)DBOrderStatusEnum.OrderInProcess,
                };
                model.InProcessOrders = order.GetCountByFilter(OrderStatsRequestModel);
                OrderStatsRequestModel.OrderStatusId = (long)DBOrderStatusEnum.Order_Delivered_Pickedup;
                model.DeliveredOrders = order.GetCountByFilter(OrderStatsRequestModel);
                OrderStatsRequestModel.OrderStatusId = (long)DBOrderStatusEnum.OrderCompleted;
                model.CompletedOrders = order.GetCountByFilter(OrderStatsRequestModel);

                #endregion OrderStats
                #region Payment
                var pay = new PaymentControllerProxy();
                var payModel = new SearchModel
                {
                    CountryId = 0,
                    ProvinceId = ApplicationSession.ProvinceId,
                    CityId = ApplicationSession.CityId,
                    SortBy = "1" //New Payment
                };
                model.NewPaymentSum = pay.GetOrderSum(payModel);
                payModel.SortBy = "2";//All Payment
                model.AllPaymentSum = pay.GetOrderSum(payModel);
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangeCountry(CountryLookupModel model)
        {
            ApplicationSession.Country = model.CountryName.ToString();
            BaseControllerProxy.Country = model.CountryName.ToString();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeCountryDropDown(long Id)
        {
            CountryLookupModel model = new CountryLookupModel { CountryName = DBCountryEnum.Canada };
            switch (Id)
            {
                case 1:
                    model.CountryName = DBCountryEnum.Canada;
                    break;
                case 2:
                    model.CountryName = DBCountryEnum.USA;
                    break;
                case 3:
                    model.CountryName = DBCountryEnum.UK;
                    break;
                //case 4:
                //    model.CountryName = DBCountryEnum.Australia;
                //    break;
            }

            if (Id >= 1 && Id <= 3)
            {
                SecurityDbContext.CountryName = model.CountryName.ToString();
                ApplicationSession.Country = model.CountryName.ToString();
                BaseControllerProxy.Country = model.CountryName.ToString();
                ApplicationSession.ProvinceId = -1;
                ApplicationSession.CityId = -1;
                ClearCache();
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult GetBodyHeader()
        {
            string country = GetCountry();
            ViewBag.Country = country == "Canada" ? "canada" : country;
            return PartialView("~/Areas/Admin/Views/Partial/_BodyHeader.cshtml", new CountryLookupModel() { CountryName = (DBCountryEnum)(Enum.Parse(typeof(DBCountryEnum), country, true)) });

            /*new CountryLookupModel { CountryName = country }*/
        }

        public PartialViewResult GetUserBox()
        {
            var id = User.Identity.GetUserId<long>();
            var model = ApplicationUserManager.GetUser(id);
            var profileProxy = new ProfileControllerProxy();
            var profile = profileProxy.GetProfileByUserId(id);
            var defaultUserImage = "~/Areas/admin/Contents/assets/images/%21logged-user.jpg";
            if (!string.IsNullOrEmpty(profile.ImagePath?.Trim()))
            {
                ViewBag.UserImage = ImageFullPath(profile.ProfileID, profile.ImagePath);
            }
            else
            {
                ViewBag.UserImage = defaultUserImage;
            }
            
            return PartialView("~/Areas/Admin/Views/Partial/_UserBox.cshtml", model);

            /*new CountryLookupModel { CountryName = country }*/
         }

        private string ImageFullPath(long id, string filename)
        {
            string Imageurl = "";
            var country = GetCountry();
            if (!string.IsNullOrEmpty(country))
            {
                if (!String.IsNullOrEmpty(filename))
                {
                    Imageurl = 
                        Config.GetWebAPIHost(country) +
                        Config.DynamicContent +
                        ImageRoute.Profile.ToString() + "/" +
                        id.ToString() + "/" +
                        filename;
                }
            }
            return Imageurl;
        }


        private string GetCountry()
        {
            var obj = ApplicationSession.Country;
            var country = DBCountryEnum.Canada.ToString();
            if (obj == null)
            {
                obj = Config.DefaultCountry;
                ApplicationSession.Country = obj.ToString();
            }
            else
            {
                country = obj.ToString();
            }

            return country;
        }

        [HttpGet]
        public ActionResult ClearCache()
        {
            CacheManager.RemoveAllLike(GetCountry());// ClearCache();
            ApplicationSession.CityId = -1;
            ApplicationSession.ProvinceId = -1;
            SetupAppConfig();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ClearLocationFilter()
        {
            var returnUrl = ApplicationSession.ReturnURL;
            ApplicationSession.CityId = -1;
            ApplicationSession.ProvinceId = -1;
            if(!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index");
        }

        public static void SetupAppConfig()
        {
            try
            {
                BaseControllerProxy.Country = Config.DefaultCountry;
                AppConfigControllerProxy appConfig = new AppConfigControllerProxy();
                var appConfigList = appConfig.GetList();
                Dictionary<long, string> appConfigDictionary = new Dictionary<long, string>();
                foreach (var config in appConfigList)
                {
                    //Session[(int)config.ConfigID] = config.ConfigValue;
                    appConfigDictionary.Add(config.ConfigID, config.ConfigValue);
                }
                AppSession.appConfigDictionary = appConfigDictionary;
            }
            catch (x.HttpResponseException httpEx)
            {
                var additionalExceptionDetail = httpEx.Response.Content.ReadAsStringAsync().Result;
                ErrorLog.Error(httpEx, "Admin Portal MVC.NET SetupAppConfig() : " + additionalExceptionDetail);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin Portal MVC.NET SetupAppConfig()" );
            }
        }
    }
}
