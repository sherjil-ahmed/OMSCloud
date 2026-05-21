using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class CustomerReviewBusinessComponent
    {
        public List<CustomerReviewDetailModel> GetCustomerReviewList(
            long? authorId = null,
            CustomerReviewSubjectEnum? subject = null,
            long? SubjectRowId = null,
            long? statusId = null)
        {
            return adapter.GetCustomerReviewList(authorId, subject, SubjectRowId, statusId);
        }

        public ReviewSearchResultAdminModel GetCustomerReviewList(int PageNum, int PageSize_RowCount, string searchString = "", string sortOrder = "")
        {
            return adapter.GetCustomerReviewList(PageNum, PageSize_RowCount, searchString , sortOrder);
        }

        public bool UpdateReviewStatusAuto()
        {
            return adapter.UpdateReviewStatusAuto();
        }

        public bool ApproveReviewList(List<long> ReviewList)
        {
            return adapter.ApproveReviewList(ReviewList);
        }
    }
}
