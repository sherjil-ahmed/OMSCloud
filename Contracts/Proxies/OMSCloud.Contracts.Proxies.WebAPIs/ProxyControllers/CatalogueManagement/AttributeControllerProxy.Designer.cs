using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AttributeControllerProxy : BaseControllerProxy//, IAttributeController
	{
        public AttributeSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            string uri = "api/Attribute/GetListByPage?PageNum=" + PageNum + "&PageSize_RowCount=" + PageSize_RowCount + "&searchString=" + searchString + "&sortOrder=" + sortOrder;

            var result = WebApiClient.Get<AttributeSearchResultAdminModel>(uri);
            return result;

        }

        public List<AttributeLookupModel> GetAttributeListNotAssociatedWithProductId(Int64 Id)
		{
			string uri = "api/Attribute/GetAttributeListNotAssociatedWithProductId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<AttributeLookupModel>>(uri);
			return result;

		}
		public List<AttributeLookupModel> GetAttributeListNotAssociatedWithCategoryId(Int64 Id)
		{
			string uri = "api/Attribute/GetAttributeListNotAssociatedWithCategoryId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<AttributeLookupModel>>(uri);
			return result;

		}
		public List<AttributeModel> GetAttributeList()
		{
			string uri = "api/Attribute/GetAttributeList";

			var result =  WebApiClient.Get<List<AttributeModel>>(uri);
			return result;

		}
        public List<AttributeLookupModel> GetAttributeLookupList()
        {
            string uri = "api/Attribute/GetAttributeLookupList";

            var result = WebApiClient.Get<List<AttributeLookupModel>>(uri);
            return result;

        }

        public AttributeModel GetAttributeByName(String Id)
		{
			string uri = "api/Attribute/GetAttributeByName/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AttributeModel>(uri);
			return result;

		}
		public List<AttributeModel> GetList()
		{
			string uri = "api/Attribute/GetList";

			var result =  WebApiClient.Get<List<AttributeModel>>(uri);
			return result;

		}
		public AttributeModel GetById(Int64 Id)
		{
			string uri = "api/Attribute/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AttributeModel>(uri);
			return result;

		}
        public AttributeModel GetAttributeById(Int64 Id)
        {
            string uri = "api/Attribute/GetAttributeById/" + Id.ToString() + "";

            var result = WebApiClient.Get<AttributeModel>(uri);
            return result;
        }
        public Nullable<Int64> Put(AttributeModel model)
		{
			string uri = "api/Attribute/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AttributeModel model)
		{
			string uri = "api/Attribute/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AttributeModel model)
		{
			string uri = "api/Attribute/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Attribute/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
