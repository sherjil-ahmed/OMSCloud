using System;
using System.Collections.Generic;
using System.Web;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class CategoryControllerProxy : BaseControllerProxy//, ICategoryController
    {
        public List<CategoryModel> GetList()
        {
            string uri = "api/Category/GetList";

            var result = WebApiClient.Get<List<CategoryModel>>(uri);
            return result;

        }
        public CategoryModel GetById(Int64 Id)
        {
            string uri = "api/Category/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<CategoryModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(CategoryModel model)
        {
            string uri = "api/Category/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(CategoryModel model)
        {
            string uri = "api/Category/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean PostImage(long Id, HttpPostedFileBase file)
        {
            string uri = "api/Category/PutImageByCategoryId/" + Id.ToString() + "";

            var result = WebApiClient.PostImage<Boolean>(uri, file);
            return result;

        }
        public Boolean Delete(CategoryModel model)
        {
            string uri = "api/Category/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Category/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public List<CategoryLookupModel> GetCategoryListLookup()
        {
            string uri = "api/Category/GetCategoryListLookup";

            var result = WebApiClient.Get<List<CategoryLookupModel>>(uri);
            return result;

        }
        public List<CategoryLookupModel> GetCategoryListNotAssociatedWithProductId(Int64 Id)
        {
            string uri = "api/Category/GetCategoryListNotAssociatedWithProductId/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<CategoryLookupModel>>(uri);
            return result;

        }

        public CategorySearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            string uri = "api/Category/GetListByPage?PageNum=" + PageNum + "&PageSize_RowCount=" + PageSize_RowCount + "&searchString=" + searchString + "&sortOrder=" + sortOrder;
            var result = WebApiClient.Get<CategorySearchResultAdminModel>(uri);
            return result;
        }
    }
}
