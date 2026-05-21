using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class WebApiExplorerControllerProxy : BaseControllerProxy, IWebApiExplorerController
	{
		public List<ApiDescriptorModel> Explore()
		{
			string uri = "api/WebApiExplorer/Explore";

			var result =  WebApiClient.Get<List<ApiDescriptorModel>>(uri);
			return result;

		}
	}
}
