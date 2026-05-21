using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public partial class ProfileVerificationModel : BaseModel
    {
        [Display(Name = "Verification ID")]
        public long VerificationID { get; set; }
        [Display(Name = "Document Type")]
        public long DocumentTypeID { get; set; }
        [Display(Name = "Document Type")]
        public string DocumentTypeTitle { get; set; }
        [Display(Name = "Verified By")]
        public long? VerifiedBy { get; set; }
        [Display(Name = "Verified On")]
        public DateTime? VerifiedOn { get; set; }
        [Display(Name = "Comment")]
        public string Comments { get; set; }
        [Display(Name = "Verification Status")]
        public long? VerificationStatusID { get; set; }
        [Display(Name = "Verification Status")]
        public string VerificationStatusTitle { get; set; }
        [Display(Name = "Profile ID")]
        public long ProfileID { get; set; }
        [Display(Name = "User Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Document Number By User")]
        public string DocumentNumberByUser { get; set; }
        [Display(Name = "Document Number By Verifier")]
        public string DocumentNumberByVerifier { get; set; }
        [Display(Name = "Document Image")]
        public string DocumentImagePath { get; set; }
    }
    public partial class ProfileVerificationModelForUser : BaseModel
    {
        [Display(Name = "Verification ID")]
        public long VerificationID { get; set; }
        [Display(Name = "Profile ID")]
        public long ProfileID { get; set; }
        [Display(Name = "User Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Document Type")]
        public long DocumentTypeID { get; set; }
        [Display(Name = "Document Type")]
        public string DocumentTypeTitle { get; set; }
        [Display(Name = "Verification Status")]
        public string VerificationStatusTitle { get; set; }
        [Display(Name = "Document Number By User ")]
        public string DocumentNumberByUser { get; set; }
        [Display(Name = "Document Image")]
        public string DocumentImagePath { get; set; }
    }
    public partial class ProfileVerificationModelForAdmin : BaseModel
    {
        [Display(Name = "Verification ID")]
        public long VerificationID { get; set; }
        [Display(Name = "User Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Document Type")]
        public string DocumentTypeTitle { get; set; }
        [Display(Name = "Is Verified")]
        public bool Verified { get; set; }
        [Display(Name = "Comments By Admin/Verifier")]
        public string Comments { get; set; }
        [Display(Name = "Verification Status")]
        public DBVerificationStatusEnum VerificationStatus { get; set; }
        [Display(Name = "Verification Status")]
        public string VerificationStatusTitle { get; set; }
        [Display(Name = "Document Number By Verifier ")]
        public string DocumentNumberByVerifier { get; set; }
        [Display(Name = "Document Image")]
        public string DocumentImagePath { get; set; }
        [Display(Name = "Document Type")]
        public long DocumentTypeID { get; set; }
    }
}
