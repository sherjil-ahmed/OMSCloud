using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public enum FileType
    {
        [Description("jpg")]
        JPG = 1,
        [Description("png")]
        PNG = 2,
        [Description("gif")]
        GIF = 3,
    }

    public enum OrderType
    {
        [Description("Cart")]
        Cart = 1,
        [Description("Order")]
        Order = 2
    }

    public enum ImageRoute
    {
        [Description("Product\\{id}\\")]
        Product = 1,
        [Description("Category\\{id}\\")]
        Category = 2,
        [Description("ProductMediaDetail\\{id}\\")]
        ProductMediaDetail = 3,
        [Description("MediaContentType\\{id}\\")]
        MediaContentType = 4,
        [Description("Profile\\{id}\\")]
        Profile = 5,
        [Description("ProfileVerification\\{id}\\")]
        ProfileVerification = 6,
        [Description("Supplier\\{id}\\")]
        Supplier = 7,
    }
    public enum ResponseStatus
    {
        Success,
        Failure,
        Error
    }

    public enum StatusMessage
    {        
        [Description("None")]
        None,
        [Description("Successful")]
        Successful = 0,
        [Description("Failure")]
        Failure = 3,
        [Description("Error")]
        Error,
        [Description("User Not Found")]
        UserNotFound,
        [Description("Login Name Already Exists")]
        LoginNameAlreadyExists,
        [Description("Unexpected Error Occured")]
        UnexpectedErrorOccured,
        [Description("Entity Not Found")]
        EntityNotFound,
        [Description("Invalid Username Or Password")]
        InvalidUsernameOrPassword,
        [Description("Invalid Current Password. Enter correct Password")]
        InvalidCurrentPassword,

        [Description("User already logged-in")]
        UserAlreadyLoggedIn,
        [Description("User already logged-in")]
        UserNotLoggedIn,

        [Description("Login Name Available")]
        LoginNameAvailable,
        [Description("No Action Signature Found")]
        NoActionSignatureFound,
        [Description("Access Denied")]
        AccessDenied,
        [Description("AMT Access Denied")]
        AMTAccessDenied,
        [Description("AMT Network Access Failure")]
        AMTNetworkAccessFailure,
        [Description("ABN Already Exists")]
        ABNAlreadyExists,
        [Description("ACN Already Exists")]
        ACNAlreadyExists,
        [Description("GST Already Exists")]
        GSTAlreadyExists,
        [Description("TFN Already Exists")]
        TFNAlreadyExists,
        [Description("Name Already Exists")]
        NameAlreadyExists,
        [Description("User Login Already Exists")]
        UserLoginAlreadyExists,
        [Description("Entity Type Of \"Group\" Not Found")]
        EntityTypeOfGroupNotFound,
        [Description("Unable To Add")]
        UnableToAdd,
        [Description("Unable To Delete")]
        UnableToDelete,
        [Description("Record Added Successfully")]
        RecordAddedSuccessfully,
        [Description("Record Deleted Successfully")]
        RecordDeletedSuccessfully,
        [Description("Group with the same name already exists")]
        UserGroupAlreadyExists,
        [Description("The model proided is either Empty or Invalid")]
        EmptyOrInvalidModel,
        [Description("Unable to update the specified record(s)")]
        UnableToUpdate,
        [Description("Role with the same name already exists")]
        RoleAlreadyExists,
        [Description("Event is not assigned to an AMT Operation.")]
        EventNotAssignedInAMTComponent,
    }
    
    public enum NotificationTypeEnum
    {
        [Description("General")]
        General = 1,
        [Description("Chat")]
        Chat = 2,
        [Description("Order")]
        Order = 3,
        [Description("Review")]
        Review = 4,
        [Description("Shop")]
        Shop = 5,
        [Description("Product")]
        Product = 6,
        [Description("Cache Rebuild")]
        CacheRebuild = 7,
        [Description("Background Service")]
        BackgroundService = 8
    }

}
