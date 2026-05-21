using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class StateMachineControllerProxy : BaseControllerProxy//, IStateMachineController
	{
		public List<StateMachineModel> GetList()
		{
			string uri = "api/StateMachine/GetList";

			var result =  WebApiClient.Get<List<StateMachineModel>>(uri);
			return result;

		}
		public StateMachineModel GetById(Int64 Id)
		{
			string uri = "api/StateMachine/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<StateMachineModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(StateMachineModel model)
		{
			string uri = "api/StateMachine/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(StateMachineModel model)
		{
			string uri = "api/StateMachine/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(StateMachineModel model)
		{
			string uri = "api/StateMachine/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/StateMachine/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
