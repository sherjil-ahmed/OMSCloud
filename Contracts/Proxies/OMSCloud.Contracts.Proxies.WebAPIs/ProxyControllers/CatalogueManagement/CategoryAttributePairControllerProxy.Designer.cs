using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class CategoryAttributePairControllerProxy : BaseControllerProxy//, ICategoryAttributePairController
	{
		public List<CategoryAttributePairModel> GetList()
		{
			string uri = "api/CategoryAttributePair/GetList";

			var result =  WebApiClient.Get<List<CategoryAttributePairModel>>(uri);
			return result;

		}
		public CategoryAttributePairModel GetById(Int64 Id)
		{
			string uri = "api/CategoryAttributePair/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<CategoryAttributePairModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(CategoryAttributePairModel model)
		{
			string uri = "api/CategoryAttributePair/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(CategoryAttributePairModel model)
		{
			string uri = "api/CategoryAttributePair/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(CategoryAttributePairModel model)
		{
			string uri = "api/CategoryAttributePair/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/CategoryAttributePair/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public List<CategoryAttributePairModel> GetCategoryAttributePairList()
		{
			string uri = "api/CategoryAttributePair/GetCategoryAttributePairList";

			var result =  WebApiClient.Get<List<CategoryAttributePairModel>>(uri);
			return result;

		}
		public List<CategoryAttributePairLookupModel> GetListByCategoryId(Int64 Id)
		{
			string uri = "api/CategoryAttributePair/GetListByCategoryId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<CategoryAttributePairLookupModel>>(uri);
			return result;

		}
		public List<AttributeValueResponseModel> GetCategoryAttrobutePairList(AttributeValueRequestModel model)
		{
			string uri = "api/CategoryAttributePair/GetCategoryAttrobutePairList";

			var result =  WebApiClient.Post<List<AttributeValueResponseModel>>(uri, model);
			return result;

		}
	}
}
