using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class CustomerReviewAdapter
    {
        #region Select
        public List<CustomerReviewDetailModel> GetCustomerReviewList(
            long? authorId = null, 
            CustomerReviewSubjectEnum? subject = null,
            long? SubjectRowId = null,
            long? statusId = null)
        {
            var result = (from cr in uow.OMSContext.CustomerReview
                          join p in uow.OMSContext.Profile on cr.CreatedByUserID equals p.ProfileID into xyz
                          from profile in xyz.DefaultIfEmpty()
                          orderby cr.CreatedDateTime descending
                          select new CustomerReviewDetailModel
                          {
                              CustomerReviewID = cr.CustomerReviewID,
                              SubjectID = cr.SubjectID,
                              SubjectRowID = cr.SubjectRowID,
                              ReviewText = cr.ReviewText,
                              Rating = cr.Rating,
                              StatusID = cr.StatusID,
                              ReviewerName = profile.FirstName + " " + profile.LastName,
                              ReviewerImage = profile.ImagePath,
                              ModifiedOn = cr.LastModifiedDateTime,
                              CreatedOn = cr.CreatedDateTime,
                              CreatedBy = cr.CreatedByUserID,
                              ModifiedBy = cr.LastModifiedByUserID,
                          });
            if (authorId.HasValue)
            {
                result = result.Where(cr => cr.CreatedBy == authorId);
            }
            if (subject.HasValue)
            {
                result = result.Where(cr => cr.SubjectID == (long)subject.Value);
                if (SubjectRowId.HasValue)
                {
                    result = result.Where(cr => cr.SubjectRowID == SubjectRowId.Value);
                }
            }
            if (statusId.HasValue)
            {
                result = result.Where(cr => cr.StatusID == (long)statusId.Value);
            }
            return result.ToList();
        }

    public ReviewSearchResultAdminModel GetCustomerReviewList(int PageNum, int PageSize_RowCount, string searchString = "", string sortOrder = "")
        {
            var reviewResult = new ReviewSearchResultAdminModel();
            var result = (from cr in uow.OMSContext.CustomerReview
                          join p in uow.OMSContext.Profile on cr.CreatedByUserID equals p.ProfileID into xyz
                          from profile in xyz.DefaultIfEmpty()
                          orderby cr.CreatedDateTime descending
                          select new CustomerReviewDetailModel
                          {
                              CustomerReviewID = cr.CustomerReviewID,
                              SubjectID = cr.SubjectID,
                              SubjectRowID = cr.SubjectRowID,
                              ReviewText = cr.ReviewText,
                              Rating = cr.Rating,
                              StatusID = cr.StatusID,
                              ReviewerName = profile.FirstName + " " + profile.LastName,
                              ReviewerImage = profile.ImagePath,
                              ModifiedOn = cr.LastModifiedDateTime,
                              CreatedOn = cr.CreatedDateTime,
                              CreatedBy = cr.CreatedByUserID,
                              ModifiedBy = cr.LastModifiedByUserID,
                          });

            result = SortReviews(sortOrder, result);

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.ReviewText.Contains(searchString));
            }

            var total = result.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = PageSize_RowCount * (PageNum - 1);
                if (skip > total)
                    skip = total;
                var reviewList = result.Skip(skip).Take(PageSize_RowCount).ToList();;

                reviewResult = new ReviewSearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = reviewList.Count + skip,
                    MaxPrice = 0.0d,
                    MinPrice = 0.0d,
                    ReviewList = reviewList,
                };
            }
            return reviewResult;
        }


        #endregion Select
        #region Update
        public bool UpdateReviewStatusAuto()
        {
            try
            {
                var recordsCount = uow.OMSContext.CustomerReview_AutoUpdateStatus();

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool ApproveReviewList(List<long> ReviewList)
        {
            try
            {
                var reviewIds = string.Join(",", ReviewList.Select(n => n.ToString()).ToArray());
                var recordsCount = uow.OMSContext.Bulk_Update("CustomerReview", "CustomerReviewID", reviewIds, "statusid", ((int)DBStatusEnum.Active).ToString());
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion
        #region Delete
        #endregion Delete
        #region Private

        private static IQueryable<CustomerReviewDetailModel> SortReviews(string sortOrder, IQueryable<CustomerReviewDetailModel> returnlist)
        {
            /*
             ViewBag.SubjectRowIDSortParm = sortOrder == "SubjectRowID" ? "SubjectRowID_desc" : "SubjectRowID";
             ViewBag.SubjectIDSortParm = sortOrder == "SubjectID" ? "SubjectID_desc" : "SubjectID";
             ViewBag.ReviewTextSortParm = sortOrder == "ReviewText" ? "ReviewText_desc" : "ReviewText";
             ViewBag.RatingSortParm = sortOrder == "Rating" ? "Rating_desc" : "Rating";
             ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
             ViewBag.ReviewerNameSortParm = sortOrder == "ReviewerName" ? "ReviewerName_desc" : "ReviewerName";
             */
            switch (sortOrder)
            {
                case "SubjectRowID":
                    returnlist = returnlist.OrderBy(s => s.SubjectRowID);
                    break;
                case "SubjectRowID_desc":
                    returnlist = returnlist.OrderByDescending(s => s.SubjectRowID);
                    break;
                case "SubjectID":
                    returnlist = returnlist.OrderBy(x => x.SubjectID);
                    break;
                case "SubjectID_desc":
                    returnlist = returnlist.OrderByDescending(x => x.SubjectID);
                    break;
                case "ReviewText":
                    returnlist = returnlist.OrderBy(s => s.ReviewText);
                    break;
                case "ReviewText_desc":
                    returnlist = returnlist.OrderByDescending(s => s.ReviewText);
                    break;
                case "Rating":
                    returnlist = returnlist.OrderBy(s => s.Rating);
                    break;
                case "Rating_desc":
                    returnlist = returnlist.OrderByDescending(s => s.Rating);
                    break;
                case "Status":
                    returnlist = returnlist.OrderBy(s => s.StatusID);
                    break;
                case "Status_desc":
                    returnlist = returnlist.OrderByDescending(s => s.StatusID);
                    break;
                case "ReviewerName":
                    returnlist = returnlist.OrderBy(s => s.ReviewerName);
                    break;
                case "ReviewerName_desc":
                    returnlist = returnlist.OrderByDescending(s => s.ReviewerName);
                    break;
                case "CreatedOn":
                    returnlist = returnlist.OrderBy(s => s.CreatedOn);
                    break;
                case "CreatedOn_desc":
                    returnlist = returnlist.OrderByDescending(s => s.CreatedOn);
                    break;
                default:
                    returnlist = returnlist.OrderBy(s => s.SubjectID);
                    break;
            }
            return returnlist;
        }


        private CustomerReviewModel GetCustomerReviewModel(CustomerReview customerReview)
        {
            return new CustomerReviewModel
            {
                CustomerReviewID = customerReview.CustomerReviewID,
                SubjectID = customerReview.SubjectID,
                SubjectRowID = customerReview.SubjectRowID,
                ReviewText = customerReview.ReviewText,
                Rating = customerReview.Rating,
                StatusID = customerReview.StatusID,
            };
        }
        private CustomerReview GetCustomerReviewEntity(CustomerReviewModel customerReviewModel)
        {
            return new CustomerReview
            {
                CustomerReviewID = customerReviewModel.CustomerReviewID,
                SubjectID = customerReviewModel.SubjectID,
                SubjectRowID = customerReviewModel.SubjectRowID,
                ReviewText = customerReviewModel.ReviewText,
                Rating = customerReviewModel.Rating,
                StatusID = customerReviewModel.StatusID,
                LastModifiedDateTime = customerReviewModel.ModifiedOn,
                CreatedDateTime = customerReviewModel.CreatedOn,
                CreatedByUserID = customerReviewModel.CreatedBy,
                LastModifiedByUserID = customerReviewModel.ModifiedBy,
            };
        }
        #endregion Private
    }
}
