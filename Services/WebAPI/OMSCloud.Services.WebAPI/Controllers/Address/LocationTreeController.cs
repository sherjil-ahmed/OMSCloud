using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
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
    public partial class LocationTreeController : ApiController, ILocationTreeController
    {
        [HttpGet]
        [AllowAnonymous]
        [ReturnType(DataType = typeof(List<CountrySelectionConfigModel>))]
        public IHttpActionResult GetCountrySelectionConfigList()
        {
            //[{'CountryId':0,'CountryName':'Canada','ApiUri':'https://zvonr.ca:7072/api/','CurrencySymbol':'$','CurrencyCode':'CAD','CurrencyName':'CAD','IBAN':'Transit / Routing Number','Banking':'banking','Province':'Province','PostalCode':'Postal Code','PhoneCountryCode':'+1','ZvonrAddress':'','RequestedByProfileId':0},{'CountryId':0,'CountryName':' UK','ApiUri':'https://zvonr.co.uk:7073/api/','CurrencySymbol':'$','CurrencyCode':'GBP','CurrencyName':'GBP','IBAN':'Transit / Routing Number','Banking':'banking','Province':'Region','PostalCode':'Postal Code','PhoneCountryCode':'+44','ZvonrAddress':'','RequestedByProfileId':0},{'CountryId':0,'CountryName':' USA','ApiUri':'https://zvonr.us:7074/api/','CurrencySymbol':'$','CurrencyCode':'USD','CurrencyName':'USD','IBAN':'Transit / Routing Number','Banking':'banking','Province':'State','PostalCode':'Postal Code','PhoneCountryCode':'+1','ZvonrAddress':'','RequestedByProfileId':0}]

            //[{"CountryId":0,"CountryName":"Canada","ApiUri":"https://zvonr.ca:7072/api/","CurrencySymbol":null,"CurrencyCode":null,"CurrencyName":null,"IBAN":"Transit / Routing Number","Banking":"banking","Province":"Province","PostalCode":"Postal Code","PhoneCountryCode":"+1","ZvonrAddress":"","RequestedByProfileId":0},{"CountryId":0,"CountryName":" UK","ApiUri":"https://zvonr.co.uk:7073/api/","CurrencySymbol":null,"CurrencyCode":null,"CurrencyName":null,"IBAN":"Transit / Routing Number","Banking":"banking","Province":"Province","PostalCode":"Postal Code","PhoneCountryCode":"+1","ZvonrAddress":"","RequestedByProfileId":0},{"CountryId":0,"CountryName":" USA","ApiUri":"https://zvonr.us:7074/api/","CurrencySymbol":null,"CurrencyCode":null,"CurrencyName":null,"IBAN":"Transit / Routing Number","Banking":"banking","Province":"Province","PostalCode":"Postal Code","PhoneCountryCode":"+1","ZvonrAddress":"","RequestedByProfileId":0}]
            var result = new List<CountrySelectionConfigModel>();
            var config = Config.CountrySelectionConfig;
            var list1 = config.Split(';');
            if (list1 == null || list1.Length <= 0)
                return Ok(result);
            result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountrySelectionConfigModel>>(config);
            return Ok(result);
        }

        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetCountries()
        {
            return Ok<List<LocationLookup>>(comp.GetCountries());
        }
        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetProvincesByCountryId(long Id)
        {
            return Ok<List<LocationLookup>>(comp.GetProvincesByCountryID(Id));
        }
        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetCitiesByProvinceID(long Id)
        {
            return Ok<List<LocationLookup>>(comp.GetCitiesByProvinceID(Id));
        }
        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetLocationList(long Id, long Id1 = 0)
        {
            DBLocationLevelEnum LocationLevel;
            try
            {
                LocationLevel = (DBLocationLevelEnum)Enum.ToObject(typeof(DBLocationLevelEnum), Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok<List<LocationLookup>>(comp.GetLocationList(LocationLevel, Id1));
        }
        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetLocationListByParentName(long Id, string ParentName)
        {
            DBLocationLevelEnum LocationLevel;
            try
            {
                LocationLevel = (DBLocationLevelEnum)Enum.ToObject(typeof(DBLocationLevelEnum), Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok<List<LocationLookup>>(comp.GetLocationListByParentName(LocationLevel, ParentName));
        }

    }
}
