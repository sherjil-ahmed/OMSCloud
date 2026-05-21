using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AttributeTypeControllerProxy : BaseControllerProxy//, IAttributeTypeController
	{
		public List<AttributeTypeModel> GetList()
		{
			string uri = "api/AttributeType/GetList";

			var result =  WebApiClient.Get<List<AttributeTypeModel>>(uri,true);
			return result;

		}
		public AttributeTypeModel GetById(Int64 Id)
		{
			string uri = "api/AttributeType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AttributeTypeModel>(uri,true);
			return result;

		}
		public Nullable<Int64> Put(AttributeTypeModel model)
		{
			string uri = "api/AttributeType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AttributeTypeModel model)
		{
			string uri = "api/AttributeType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AttributeTypeModel model)
		{
			string uri = "api/AttributeType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/AttributeType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
