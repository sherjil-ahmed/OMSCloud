using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class PayOptionMatrixControllerProxy : BaseControllerProxy//, IPayOptionMatrixController
	{
		public List<PayOptionMatrixModel> GetList()
		{
			string uri = "api/PayOptionMatrix/GetList";

			var result =  WebApiClient.Get<List<PayOptionMatrixModel>>(uri);
			return result;
		}
        public List<PayOptionMatrixModel> GetPayOptionMatrixList()
        {
            string uri = "api/PayOptionMatrix/GetPayOptionMatrixList";

            var result = WebApiClient.Get<List<PayOptionMatrixModel>>(uri);
            return result;
        }

        public long GetIdBy(long payTypeId, long payModeId)
        {
            string uri = "api/PayOptionMatrix/GetIdBy/" + payTypeId.ToString() + "/" + payModeId.ToString() + "";

            var result = WebApiClient.GetForValueType<long>(uri); // this need to be test 
            return result;
        }
        public PayOptionMatrixModel GetById(Int64 Id)
		{
			string uri = "api/PayOptionMatrix/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<PayOptionMatrixModel>(uri);
			return result;
		}
		public Nullable<Int64> Put(PayOptionMatrixModel model)
		{
			string uri = "api/PayOptionMatrix/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;
		}
		public Boolean Post(PayOptionMatrixModel model)
		{
			string uri = "api/PayOptionMatrix/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;
		}
		public Boolean Delete(PayOptionMatrixModel model)
		{
			string uri = "api/PayOptionMatrix/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;
		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/PayOptionMatrix/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;
		}
	}
}
