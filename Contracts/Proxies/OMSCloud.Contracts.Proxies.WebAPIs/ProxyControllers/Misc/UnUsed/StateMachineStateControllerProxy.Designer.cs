using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class StateMachineStateControllerProxy : BaseControllerProxy//, IStateMachineStateController
	{
		public List<StateMachineStateModel> GetList()
		{
			string uri = "api/StateMachineState/GetList";

			var result =  WebApiClient.Get<List<StateMachineStateModel>>(uri);
			return result;

		}
		public StateMachineStateModel GetById(Int64 Id)
		{
			string uri = "api/StateMachineState/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<StateMachineStateModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(StateMachineStateModel model)
		{
			string uri = "api/StateMachineState/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(StateMachineStateModel model)
		{
			string uri = "api/StateMachineState/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(StateMachineStateModel model)
		{
			string uri = "api/StateMachineState/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/StateMachineState/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
