using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class PackagedProductControllerProxy : BaseControllerProxy//, IPackagedProductController
	{
		public List<PackagedProductModel> GetList()
		{
			string uri = "api/PackagedProduct/GetList";

			var result =  WebApiClient.Get<List<PackagedProductModel>>(uri);
			return result;

		}
		public PackagedProductModel GetById(Int64 Id)
		{
			string uri = "api/PackagedProduct/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<PackagedProductModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(PackagedProductModel model)
		{
			string uri = "api/PackagedProduct/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(PackagedProductModel model)
		{
			string uri = "api/PackagedProduct/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(PackagedProductModel model)
		{
			string uri = "api/PackagedProduct/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/PackagedProduct/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public List<PackagedProductModel> GetListByProductId(Int64 Id)
		{
			string uri = "api/PackagedProduct/GetListByProductId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<PackagedProductModel>>(uri);
			return result;

		}
	}
}
