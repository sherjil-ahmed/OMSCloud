using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Services.WebAPIs.Hubs;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class CustomerReviewController //: ApiController, ICustomerReviewController
    {
        [ReturnType(DataType = typeof(List<CustomerReviewDetailModel>))]
        public IHttpActionResult GetCustomerReviewList(
            long? authorId = null,
            CustomerReviewSubjectEnum? subject = null,
            long? SubjectRowId = null,
            long? statusId = null)
        {
            return Ok<List<CustomerReviewDetailModel>>(comp.GetCustomerReviewList(authorId, subject, SubjectRowId, statusId));
        }

        [ReturnType(DataType = typeof(ReviewSearchResultAdminModel))]
        public IHttpActionResult GetCustomerReviewList(int PageNum, int PageSize_RowCount, string searchString = "", string sortOrder = "")
        {
            return Ok<ReviewSearchResultAdminModel>(comp.GetCustomerReviewList(PageNum, PageSize_RowCount, searchString, sortOrder));
        }

        //public bool ApproveReviewList(List<long> ReviewList)
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult ApproveReviewList(string reviewCSV)
        {
            if (string.IsNullOrEmpty(reviewCSV))
            {
                return BadRequest("reviewCSV is empty. No review is selected for approval");
            }
            var ListString = reviewCSV.Split(',');
            List<long> ReviewListLong = new List<long>();
            foreach (var id in ListString)
            {
                long x = 0;
                Int64.TryParse(id, out x);
                ReviewListLong.Add(x);
            }
            if (comp.ApproveReviewList(ReviewListLong))
            {
                foreach (var id in ReviewListLong)
                {
                    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Review, id);
                }
                return Ok<bool>(true);
            }
            return Conflict();

        }
    }
}