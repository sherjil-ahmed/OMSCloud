using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CustomerReviewModel : ConcurrencyBaseModel
    {
        public long CustomerReviewID { get; set; }
        [Display(Name = "Reviewed Item")]
        public long SubjectRowID { get; set; }
        [Display(Name = "Reviewed On")]
        public long SubjectID { get; set; }
        [Display(Name = "Review Text")]
        public string ReviewText { get; set; }
        public short Rating { get; set; }
        [Display(Name = "Status")]
        public long StatusID { get; set; }
    }

    public class CustomerReviewDetailModel : CustomerReviewModel
    {
        [Display(Name = "Reviewer's Name")]
        public string ReviewerName { get; set; }
        public string ReviewerImage { get; set; }
    }
    public class ReviewSearchResultAdminModel : SearchResultModel
    {
        public List<CustomerReviewDetailModel> ReviewList { get; set; }
    }
}
