using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class MediaContentTypeControllerProxy : BaseControllerProxy//, IMediaContentTypeController
	{
		public List<MediaContentTypeModel> GetList()
		{
			string uri = "api/MediaContentType/GetList";

			var result =  WebApiClient.Get<List<MediaContentTypeModel>>(uri, true);
			return result;

		}
		public MediaContentTypeModel GetById(Int64 Id)
		{
			string uri = "api/MediaContentType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<MediaContentTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(MediaContentTypeModel model)
		{
			string uri = "api/MediaContentType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(MediaContentTypeModel model)
		{
			string uri = "api/MediaContentType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(MediaContentTypeModel model)
		{
			string uri = "api/MediaContentType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/MediaContentType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
