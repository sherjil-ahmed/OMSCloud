using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OptionTypeControllerProxy : BaseControllerProxy//, IOptionTypeController
	{
		public List<OptionTypeModel> GetList()
		{
			string uri = "api/OptionType/GetList";

			var result =  WebApiClient.Get<List<OptionTypeModel>>(uri);
			return result;

		}
		public OptionTypeModel GetById(Int64 Id)
		{
			string uri = "api/OptionType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OptionTypeModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(OptionTypeModel model)
		{
			string uri = "api/OptionType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(OptionTypeModel model)
		{
			string uri = "api/OptionType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(OptionTypeModel model)
		{
			string uri = "api/OptionType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/OptionType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
