using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class AppConfigController : ApiController, IAppConfigController
    {
        //private AppConfigBusinessComponent comp = new AppConfigBusinessComponent();
        [ReturnType(DataType = typeof(LocationPreference))]
        public IHttpActionResult GetShopPreferences()
        {
            if (AppSession.appConfigDictionary.Count() == 0)
            {
                var appConfigList = comp.GetAppConfigList();
                Dictionary<long, string> appConfigDictionary = new Dictionary<long, string>();
                foreach (var config in appConfigList)
                {
                    appConfigDictionary.Add(config.ConfigID, config.ConfigValue);
                }
                AppSession.appConfigDictionary = appConfigDictionary;
            }
            var result = new LocationPreference()
            {
                CountryID = AppSession.CountryID,
                CountryName = AppSession.CountryName,
                CurrencyCode = AppSession.CurrencyCode,
                CurrencyID = AppSession.CurrencyID,
                CurrencyName = AppSession.CurrencyName,
                CurrencySymbol = AppSession.CurrencySymbol,
                LanguageID = AppSession.LanguageID,
                LanguageName = AppSession.LanguageName,
                LanguageShortForm = AppSession.LanguageCode,
            };
            return Ok<LocationPreference>(result);
        }
    }
}
