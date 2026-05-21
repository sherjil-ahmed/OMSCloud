using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OptionControllerProxy : BaseControllerProxy//, IOptionController
	{
		public List<OptionModel> GetList()
		{
			string uri = "api/Option/GetList";

			var result =  WebApiClient.Get<List<OptionModel>>(uri);
			return result;

		}
		public OptionModel GetById(Int64 Id)
		{
			string uri = "api/Option/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OptionModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(OptionModel model)
		{
			string uri = "api/Option/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(OptionModel model)
		{
			string uri = "api/Option/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(OptionModel model)
		{
			string uri = "api/Option/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Option/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
