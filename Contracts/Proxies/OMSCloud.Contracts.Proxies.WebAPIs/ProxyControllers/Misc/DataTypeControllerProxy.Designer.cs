using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class DataTypeControllerProxy : BaseControllerProxy//, IDataTypeController
	{
		public List<DataTypeModel> GetList()
		{
			string uri = "api/DataType/GetList";

			var result =  WebApiClient.Get<List<DataTypeModel>>(uri,true);
			return result;

		}
		public DataTypeModel GetById(Int64 Id)
		{
			string uri = "api/DataType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<DataTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(DataTypeModel model)
		{
			string uri = "api/DataType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(DataTypeModel model)
		{
			string uri = "api/DataType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(DataTypeModel model)
		{
			string uri = "api/DataType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/DataType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
