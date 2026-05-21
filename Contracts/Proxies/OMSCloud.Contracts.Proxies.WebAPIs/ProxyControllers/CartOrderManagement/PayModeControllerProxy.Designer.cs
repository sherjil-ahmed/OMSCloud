using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{    
    public partial class PayModeControllerProxy : BaseControllerProxy//, IPayModeController
	{
		public List<PayModeModel> GetList()
		{
			string uri = "api/PayMode/GetList";

			var result =  WebApiClient.Get<List<PayModeModel>>(uri);
			return result;

		}
        
        public List<PayModeModel> GetPayModeListByPayTypeId(long Id)
        {
            string uri = "api/PayMode/GetPayModeListByPayTypeId/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<PayModeModel>>(uri);
            return result;

        }

        public PayModeModel GetById(Int64 Id)
		{
			string uri = "api/PayMode/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<PayModeModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(PayModeModel model)
		{
			string uri = "api/PayMode/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(PayModeModel model)
		{
			string uri = "api/PayMode/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(PayModeModel model)
		{
			string uri = "api/PayMode/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/PayMode/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
