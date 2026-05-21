using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ProfileModel : BaseModel
    {
        [Display(Name = "Profile ID")]
        public long ProfileID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User ID")]
        public long UserID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Mobile #")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Education")]
        public string Education { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Verified")]
        public bool IsVerified { get; set; }

        [Display(Name = "User Type ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value can not be empty")]
        public long UserTypeID { get; set; }

        [Display(Name = "User Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value can not be empty")]
        public DBUserTypePublicEnum PublicUserType { get; set; }

        [Display(Name = "User Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value can not be empty")]
        public DBUserTypeEnum AdminUserTypeID { get; set; }
                
        [Display(Name = "SMS Two Factor")]
        public bool SMS_2FA { get; set; }

        [Display(Name = "Email Two Factor")]
        public bool EMail_2FA { get; set; }
        public long? ShopId { get; set; }
        public long UnreadMessageCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLogin { get; set; }
    }

    public class ProfileModel_2FA : BaseModel
    {
        [Display(Name = "Profile ID")]
        public long ProfileID { get; set; }        

        [Display(Name = "SMS Two Factor")]
        public bool SMS_2FA { get; set; }

        [Display(Name = "Email Two Factor")]
        public bool EMail_2FA { get; set; }
    }

    public class ProfileUserModel : BaseModel
    {
        public DateTime LastModified { get; set; }
        public long UserId { get; set; }
        public long ProfileId { get; set; }
        public bool Inactive { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime UserCreatedOn { get; set; }
    }

    public class ShopUserModel : ProfileUserModel
    {
        public string ShopName { get; set; }
        public long ShopId { get; set; }
    }
}

