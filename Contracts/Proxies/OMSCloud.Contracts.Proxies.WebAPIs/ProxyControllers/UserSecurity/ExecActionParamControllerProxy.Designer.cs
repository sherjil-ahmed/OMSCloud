using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ExecActionParamControllerProxy : BaseControllerProxy//, IExecActionParamController
	{
		public List<ExecActionParamModel> GetList()
		{
			string uri = "api/ExecActionParam/GetList";

			var result =  WebApiClient.Get<List<ExecActionParamModel>>(uri);
			return result;

		}
		public ExecActionParamModel GetById(Int64 Id)
		{
			string uri = "api/ExecActionParam/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ExecActionParamModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ExecActionParamModel model)
		{
			string uri = "api/ExecActionParam/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ExecActionParamModel model)
		{
			string uri = "api/ExecActionParam/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ExecActionParamModel model)
		{
			string uri = "api/ExecActionParam/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ExecActionParam/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
