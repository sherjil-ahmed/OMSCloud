using System;
using System.Collections.Generic;
using System.Web;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class SupplierControllerProxy : BaseControllerProxy//, ISupplierController
	{
        public long GetCountByFilter(ShopStatsModel statsRequestModel)
        {
            string uri = "api/Supplier/GetCountByFilter";

            var result = WebApiClient.Post<long>(uri, statsRequestModel);
            return result;

        }
        public SupplierSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            string uri = "api/Supplier/GetListByPage?PageNum=" + PageNum + "&PageSize_RowCount=" + PageSize_RowCount + "&searchString=" + searchString + "&sortOrder=" + sortOrder;

            var result = WebApiClient.Get<SupplierSearchResultAdminModel>(uri);
            return result;

        }
        public SupplierSearchResultAdminModel GetListByPage(SearchModel model)
        {
            string uri = "api/Supplier/GetListByPage";

            var result = WebApiClient.Post<SupplierSearchResultAdminModel>(uri, model);
            return result;

        }
        public bool PutImageByShopId(long Id, HttpPostedFileBase file)
        {
            string uri = "api/Supplier/PutImageByShopId/" + Id.ToString() + "";

            var result = WebApiClient.PostImage<Boolean>(uri, file);
            return result;
        }
        public bool ApproveSupplierList(string SupplierCSV)
        {
            string uri = "api/Supplier/ApproveSupplierList?SupplierCSV=" + SupplierCSV + "";

            var result = WebApiClient.Post<Boolean>(uri, SupplierCSV);
            return result;
        }
        public ShopTaxInfoModel GetShopTaxInfo(long Id)
        {
            string uri = "api/Supplier/GetShopTaxInfo/" + Id.ToString() + "";

            var result = WebApiClient.Get<ShopTaxInfoModel>(uri);
            return result;

        }

        public CategoryAttributeRequestModel GetCategoryAttributeRequestBySupplierId(long Id)
        {
            string uri = "api/Supplier/GetCategoryAttributeRequestBySupplierId/" + Id.ToString() + "";

            var result = WebApiClient.Get<CategoryAttributeRequestModel>(uri);
            return result;
        }

        public bool UpdateSupplierAttributeRequests(AttributeRequestModel model)
        {
            string uri = "api/Supplier/UpdateSupplierAttributeRequests";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;
        }

        public bool UpdateSupplierCategoryRequests(CategoryRequestModel model)
        {
            string uri = "api/Supplier/UpdateSupplierCategoryRequests";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;
        }
        public List<SupplierModel> GetList()
		{
			string uri = "api/Supplier/GetList";

			var result =  WebApiClient.Get<List<SupplierModel>>(uri);
			return result;

		}
		public SupplierModel GetById(Int64 Id)
		{
			string uri = "api/Supplier/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<SupplierModel>(uri);
			return result;

		}
		public SupplierViewModel GetSupplierById(long Id) 
		{
			string uri = "api/Supplier/GetSupplierById/" + Id.ToString() + "";
			var result = WebApiClient.Get<SupplierViewModel>(uri);
			return result;
		}
		public Nullable<Int64> Put(SupplierModel model)
		{
			string uri = "api/Supplier/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(SupplierModel model)
		{
			string uri = "api/Supplier/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(SupplierModel model)
		{
			string uri = "api/Supplier/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Supplier/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
