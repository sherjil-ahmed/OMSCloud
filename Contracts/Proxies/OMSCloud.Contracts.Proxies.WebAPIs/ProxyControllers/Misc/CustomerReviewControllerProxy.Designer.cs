using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class CustomerReviewControllerProxy : BaseControllerProxy//, ICustomerReviewController
    {
        public List<CustomerReviewDetailModel> GetCustomerReviewList(
            long? authorId = null,
            CustomerReviewSubjectEnum? subject = null,
            long? SubjectRowId = null,
            long? statusId = null)
        {
            string uri = "api/CustomerReview/GetCustomerReviewList?authorId=" + authorId + "&subject=" + subject + "&SubjectRowId=" + SubjectRowId + "&statusId=" + statusId;

            var result = WebApiClient.Get<List<CustomerReviewDetailModel>>(uri);
            return result;
        }

        public ReviewSearchResultAdminModel GetCustomerReviewList(int PageNum, int PageSize_RowCount, string searchString = "", string sortOrder = "")
        {
            string uri = "api/CustomerReview/GetCustomerReviewList?PageNum=" + PageNum + "&PageSize_RowCount=" + PageSize_RowCount + "&searchString=" + searchString + "&sortOrder=" + sortOrder;

            var result = WebApiClient.Get<ReviewSearchResultAdminModel>(uri);
            return result;
        }

        //ApproveReviewList
        public bool ApproveReviewList(string ReviewCSV)
        {
            string uri = "api/CustomerReview/ApproveReviewList?reviewCSV=" + ReviewCSV + "";

            var result = WebApiClient.Post<Boolean>(uri, ReviewCSV);
            return result;
        }
        public List<CustomerReviewModel> GetList()
        {
            string uri = "api/CustomerReview/GetList";

            var result = WebApiClient.Get<List<CustomerReviewModel>>(uri);
            return result;

        }
        public CustomerReviewModel GetById(Int64 Id)
        {
            string uri = "api/CustomerReview/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<CustomerReviewModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(CustomerReviewModel model)
        {
            string uri = "api/CustomerReview/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(CustomerReviewModel model)
        {
            string uri = "api/CustomerReview/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(CustomerReviewModel model)
        {
            string uri = "api/CustomerReview/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/CustomerReview/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
    }

}
