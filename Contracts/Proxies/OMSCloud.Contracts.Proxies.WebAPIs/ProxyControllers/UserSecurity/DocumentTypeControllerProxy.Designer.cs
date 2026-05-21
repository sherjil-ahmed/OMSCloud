using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class DocumentTypeControllerProxy : BaseControllerProxy//, IDocumentTypeController
	{
		public List<DocumentTypeModel> GetList()
		{
			string uri = "api/DocumentType/GetList";

			var result =  WebApiClient.Get<List<DocumentTypeModel>>(uri, true);
			return result;

		}
		public DocumentTypeModel GetById(Int64 Id)
		{
			string uri = "api/DocumentType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<DocumentTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(DocumentTypeModel model)
		{
			string uri = "api/DocumentType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(DocumentTypeModel model)
		{
			string uri = "api/DocumentType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(DocumentTypeModel model)
		{
			string uri = "api/DocumentType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/DocumentType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
