using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LogControllerProxy : BaseControllerProxy//, ILogController
	{
		public List<LogModel> GetList()
		{
			string uri = "api/Log/GetList";

			var result =  WebApiClient.Get<List<LogModel>>(uri);
			return result;

		}
		public LogModel GetById(Int64 Id)
		{
			string uri = "api/Log/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LogModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(LogModel model)
		{
			string uri = "api/Log/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LogModel model)
		{
			string uri = "api/Log/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LogModel model)
		{
			string uri = "api/Log/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Log/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
