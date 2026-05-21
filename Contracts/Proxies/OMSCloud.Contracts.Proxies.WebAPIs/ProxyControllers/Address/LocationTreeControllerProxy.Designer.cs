using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LocationTreeControllerProxy : BaseControllerProxy//, ILocationTreeController
	{
		public List<LocationTreeModel> GetList()
		{
			string uri = "api/LocationTree/GetList";

			var result =  WebApiClient.Get<List<LocationTreeModel>>(uri, true);
			return result;

		}
        public LocationModel GetLocationTreeByLocationId(Int64 Id)
        {
            string uri = "api/LocationTree/GetLocationTreeByLocationId/" + Id.ToString() + "";

            var result = WebApiClient.Get<LocationModel>(uri, true);
            return result;
        }
		public List<LocationLookup> GetCountries() 
		{
			string uri = "api/LocationTree/GetCountries";
			var result = WebApiClient.Get<List<LocationLookup>>(uri, true);
			return result;
		}
		public List<LocationLookup> GetProvincesByCountryID(long Id) 
		{
			string uri = "api/LocationTree/GetProvincesByCountryId/" + Id.ToString()+ "";
			var result = WebApiClient.Get<List<LocationLookup>>(uri, true);
			return result;
		}
		public List<LocationLookup> GetCitiesByProvinceID(long Id)
		{
			string uri = "api/LocationTree/GetProvincesByCountryId/" + Id.ToString() + "";
			var result = WebApiClient.Get<List<LocationLookup>>(uri, true);
			return result;
		}
        public List<LocationTreeModel> GetLocationTreeList()
        {
            string uri = "api/LocationTree/GetLocationTreeList/";
            var result = WebApiClient.Get<List<LocationTreeModel>>(uri, true);
            return result;
        }
        public List<LocationLookup> GetLocationList(DBLocationLevelEnum LocationLevel, long ParentLocationId = 0)
		{
			string uri = "api/LocationTree/GetLocationList/" + ((long)LocationLevel).ToString() + "/" + ParentLocationId.ToString();
			var result = WebApiClient.Get<List<LocationLookup>>(uri, true);
			return result;
		}
        public List<LocationLookup> GetLocationListByParentName(DBLocationLevelEnum LocationLevel, string ParentName)        
        {
            string uri = "api/LocationTree/GetLocationList/" + ((long)LocationLevel).ToString() + "/" + ParentName;
            var result = WebApiClient.Get<List<LocationLookup>>(uri,true);
            return result;
        }
        public LocationTreeModel GetById(Int64 Id)
		{
			string uri = "api/LocationTree/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LocationTreeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(LocationTreeModel model)
		{
			string uri = "api/LocationTree/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LocationTreeModel model)
		{
			string uri = "api/LocationTree/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LocationTreeModel model)
		{
			string uri = "api/LocationTree/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/LocationTree/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
