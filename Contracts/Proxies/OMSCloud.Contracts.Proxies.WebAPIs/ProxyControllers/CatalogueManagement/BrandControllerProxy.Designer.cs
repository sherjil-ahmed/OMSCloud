using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System.Reflection;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class BrandControllerProxy : BaseControllerProxy//, IBrandController
	{
		//WebAPI methods will have Cacheable attribute,
		//Proxy Generator will take care of Cacheable attribute via WebApi Explorer
		//and generate code for "return WebApiClient.Get<List<BrandModel>>(uri, true);"
		//with either true or without true 
		//without true mean use default value of WebApiClinet.Get i.e. false by default
		public List<BrandModel> GetList()
		{
			string uri = "api/Brand/GetList";

			var result =  WebApiClient.Get<List<BrandModel>>(uri, true);
			return result;

		}
		public BrandModel GetById(Int64 Id)
		{
			string uri = "api/Brand/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<BrandModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(BrandModel model)
		{
			string uri = "api/Brand/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(BrandModel model)
		{
			string uri = "api/Brand/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(BrandModel model)
		{
			string uri = "api/Brand/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Brand/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
