using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class CategoryTypeControllerProxy : BaseControllerProxy//, ICategoryTypeController
	{
		public List<CategoryTypeModel> GetList()
		{
			string uri = "api/CategoryType/GetList";

			var result =  WebApiClient.Get<List<CategoryTypeModel>>(uri,true);
			return result;

		}
		public CategoryTypeModel GetById(Int64 Id)
		{
			string uri = "api/CategoryType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<CategoryTypeModel>(uri,true);
			return result;

		}
		public Nullable<Int64> Put(CategoryTypeModel model)
		{
			string uri = "api/CategoryType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(CategoryTypeModel model)
		{
			string uri = "api/CategoryType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(CategoryTypeModel model)
		{
			string uri = "api/CategoryType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/CategoryType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
