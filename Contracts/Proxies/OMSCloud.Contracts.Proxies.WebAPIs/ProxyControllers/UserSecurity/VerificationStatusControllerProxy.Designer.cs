using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class VerificationStatusControllerProxy : BaseControllerProxy//, IVerificationStatusController
	{
		public List<VerificationStatusModel> GetList()
		{
			string uri = "api/VerificationStatus/GetList";

			var result =  WebApiClient.Get<List<VerificationStatusModel>>(uri);
			return result;

		}
		public VerificationStatusModel GetById(Int64 Id)
		{
			string uri = "api/VerificationStatus/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<VerificationStatusModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(VerificationStatusModel model)
		{
			string uri = "api/VerificationStatus/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(VerificationStatusModel model)
		{
			string uri = "api/VerificationStatus/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(VerificationStatusModel model)
		{
			string uri = "api/VerificationStatus/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/VerificationStatus/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
