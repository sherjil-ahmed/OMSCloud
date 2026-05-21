using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ExecActionControllerProxy : BaseControllerProxy//, IExecActionController
	{
		public List<ExecActionModel> GetList()
		{
			string uri = "api/ExecAction/GetList";

			var result =  WebApiClient.Get<List<ExecActionModel>>(uri);
			return result;

		}
		public ExecActionModel GetById(Int64 Id)
		{
			string uri = "api/ExecAction/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ExecActionModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ExecActionModel model)
		{
			string uri = "api/ExecAction/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ExecActionModel model)
		{
			string uri = "api/ExecAction/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ExecActionModel model)
		{
			string uri = "api/ExecAction/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ExecAction/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
