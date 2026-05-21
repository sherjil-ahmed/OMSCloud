using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using NLog;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.Services.WebAPIs.Common;
using OMSCloud.Services.WebAPIs.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Security;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class AccountController : ApiController
    {
        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult SendContactUsEmail(EmailModel model)
        {
            EmailService e = new EmailService();
            var result = e.Send2HotmailAccount(
                new IdentityMessage
                {
                    Body = model.From_Email + 
                            Environment.NewLine + 
                            model.From_FullName + 
                            Environment.NewLine + 
                            model.Body + 
                            Environment.NewLine +
                            model.PhoneNumber + 
                            Environment.NewLine,
                            Destination = Config.SupportEmail,
                    Subject = "Contact Us from " + model.From_Email + " ("+ model.From_FullName + ")",
                });
            return Ok(result);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult LogoutAndDeleteUser(LoginViewModel model)
        {
            if (model == null || model.DeviceToken == null)
                throw new ArgumentNullException("LogoutAndDeleteUser: DeviceToken is null in LogoutAndDeleteUser call");
            var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userMgr.FindByEmail(model.eMail);
            if (user != null)
            {
                NLogger.Log.Debug("LogoutAndDeleteUser: User Found");
                var pc = new ProfileBusinessComponent();
                var profile = pc.GetProfileByUserId(user.Id);
                if (profile != null)
                {
                    NLogger.Log.Debug("LogoutAndDeleteUser: Profile Found");
                    model.DeviceToken.ProfileId = profile.ProfileID;
                    //Should change the status back to active
                    var ntbc = new NotificationTokenBusinessComponent();
                    var dbToken = ntbc.GetByNotificationToken(model.DeviceToken);
                    if (dbToken != null)//&& dbToken.StatusId != (int)DBStatusEnum.Active)
                    {
                        NLogger.Log.Debug("LogoutAndDeleteUser: token Found");
                        //Should change the status back to active
                        dbToken.StatusId = (int)DBStatusEnum.InActive;
                        bool IsLogout = ntbc.UpdateNotificationToken(dbToken);
                        if (IsLogout)
                        {
                            user.Inactive = true;
                            bool IsDeleted = ApplicationUserManager.DeactivateUser(user);
                            if (IsDeleted)
                                return Ok(true);
                            else
                                NLogger.Log.Debug("LogoutAndDeleteUser: User Logout but unable to Delete User");
                        }
                        else
                        {
                            NLogger.Log.Debug("LogoutAndDeleteUser: Unable to logout");
                        }
                    }
                    else
                    {
                        NLogger.Log.Debug("LogoutAndDeleteUser: Token NOT Found");
                    }
                }
                else
                {
                    NLogger.Log.Debug("LogoutAndDeleteUser: Profile NOT Found");
                }
            }
            else
            {
                NLogger.Log.Debug("LogoutAndDeleteUser: user NOT Found");
            }
            return Ok(false);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult Logout(LoginViewModel model)
        {
            if (model == null || model.DeviceToken == null)
                throw new ArgumentNullException("DeviceToken is null in Logout call");
            var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userMgr.FindByEmail(model.eMail);
            if (user != null)
            {
                NLogger.Log.Debug("Logout: User Found");
                var pc = new ProfileBusinessComponent();
                var profile = pc.GetProfileByUserId(user.Id);
                if (profile != null)
                {
                    NLogger.Log.Debug("Logout: Profile Found");
                    model.DeviceToken.ProfileId = profile.ProfileID;
                    //Should change the status back to active
                    var ntbc = new NotificationTokenBusinessComponent();
                    var dbToken = ntbc.GetByNotificationToken(model.DeviceToken);
                    if (dbToken != null )//&& dbToken.StatusId != (int)DBStatusEnum.Active)
                    {
                        NLogger.Log.Debug("Logout: token Found");
                        //Should change the status back to active
                        dbToken.StatusId = (int)DBStatusEnum.InActive;
                        return Ok(ntbc.UpdateNotificationToken(dbToken));
                    }
                    else
                    {
                        NLogger.Log.Debug("Logout: Token NOT Found");
                    }
                }
                else
                {
                    NLogger.Log.Debug("Logout: Profile NOT Found");
                }
            }
            else {
                NLogger.Log.Debug("Logout: user NOT Found");
            }
            return Ok(false);
        }

        [HttpGet]
        [ReturnType(DataType = typeof(List<NotificationTokenModel>))]
        public IHttpActionResult GetDeviceAllTokenList(long id) {

            var ntbc = new NotificationTokenBusinessComponent();
            var list = ntbc.GetDeviceAllTokenList(id);
            return Ok<List<NotificationTokenModel>>(list);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult LoginUser(LoginViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException("LoginViewModel is null in LoginUser call");
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "Login failed. User does not exists";
            response.IsActionRequired = false;
            try
            {
                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                AccountStatusModel accountStatus = Security_ExtendedMethods.Login(model, _userMgr, _signInManager, out _errors);
                SecurityStatus _retVal = accountStatus.StatusCode;
                switch (_retVal)
                {
                    case SecurityStatus.Success:
                        {
                            response.StatusCode = SecurityStatus.Success;
                            response.StatusMessage = "Login Success";
                            response.IsActionRequired = false;
                            response.TokenResponse = GetToken(model.eMail, model.Password);
                            if (model.DeviceToken != null && !string.IsNullOrEmpty(model.DeviceToken.Token))
                            {
                                NLogger.Log.Debug("model.DeviceToken.Token : " + model.DeviceToken.Token);
                                var appUser = _userMgr.FindByEmail(model.eMail);
                                if (appUser == null)
                                {
                                    NLogger.Log.Debug("User not found for model.DeviceToken"); // this case can never happen
                                    break;
                                }
                                var pc = new ProfileBusinessComponent();
                                var profile = pc.GetProfileByUserId(appUser.Id);
                                if (profile != null && profile.ProfileID > -1)
                                {
                                    NLogger.Log.Debug("profile.ProfileID : " + profile.ProfileID + ", " + profile.FirstName + " " + profile.LastName + " " + profile.UserName);
                                    model.DeviceToken.ProfileId = profile.ProfileID;
                                    NLogger.Log.Debug("SetDeviceToken BEFORE");
                                    SetDeviceToken(model.DeviceToken);
                                    NLogger.Log.Debug("SetDeviceToken AFTER");
                                }
                                else
                                {
                                    NLogger.Log.Debug("Profile not found for token provided");
                                }
                            }
                        
                            response.routeList = accountStatus.routeList;
                            break;
                        }
                    case SecurityStatus.EmailUnconfirmed:
                        {
                            //Do nothing, message will be display on login page...
                            response.StatusCode = SecurityStatus.EmailUnconfirmed;
                            response.StatusMessage = "Email does not confirmed";
                            response.IsActionRequired = false;
                            break;                            
                        }
                    case SecurityStatus.PhoneNumberUnconfirmed:
                        {
                            var user = _userMgr.FindByEmail(model.eMail);
                            if (user != null)
                            {
                                Security_ExtendedMethods.SendOTP2Phone(_userMgr, user.Id, user.PhoneNumber);
                                response.StatusCode = SecurityStatus.PhoneNumberUnconfirmed;
                                response.StatusMessage = "Phone does not confirmed";
                                response.IsActionRequired = false;
                            }
                            else
                            {
                                response.StatusCode = SecurityStatus.Failure;
                                response.StatusMessage = "User does not exits";
                                response.IsActionRequired = false;
                            }
                            break;
                        }
                    case SecurityStatus.RequiresVerification:
                    {
                        response.StatusCode = SecurityStatus.RequiresVerification;
                        response.StatusMessage = "User requires verification";
                        response.IsActionRequired = true;
                        //response.TokenResponse = GetToken(model.eMail, model.Password);

                        var user = _userMgr.FindByEmail(model.eMail);
                        if (user != null)
                        {
                            ProfileBusinessComponent comp = new ProfileBusinessComponent();
                            ProfileModel profile = comp.GetProfileByUserId(user.Id);
                            if (profile != null)
                            {
                                List<string> verificationMethods = new List<string>();

                                if (profile.SMS_2FA)
                                    verificationMethods.Add("Phone Code");
                                if (profile.EMail_2FA)
                                    verificationMethods.Add("Email Code");

                                response.VerificationMethod = verificationMethods;
                                var result = _userMgr.SetTwoFactorEnabledAsync(user.Id, false).Result;
                                response.TokenResponse = GetToken(model.eMail, model.Password);
                                var result1 = _userMgr.SetTwoFactorEnabledAsync(user.Id, true).Result;
                            }
                            else
                            {
                                response.StatusCode = SecurityStatus.Failure;
                                response.StatusMessage = "User Profile does not exits";
                                response.IsActionRequired = false;
                            }
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;                
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;                
            }
            return Ok<AccountResponseModel>(response);
        }

        private void SetDeviceToken(NotificationTokenModel model)
        {
            NLogger.Log.Debug("SetDeviceToken: trying to see if notification token already existed ");
            var ntbc = new NotificationTokenBusinessComponent();
            var dbToken = ntbc.GetByNotificationToken(model);
            if (dbToken == null)
            {
                NLogger.Log.Debug("SetDeviceToken: token is not present in DB ");
                model.StatusId = (int)DBStatusEnum.Active;
                NLogger.Log.Debug("SetDeviceToken: AddNotificationToken BEFORE");
                var result = ntbc.AddNotificationToken(model);
                NLogger.Log.Debug("SetDeviceToken: AddNotificationToken AFTER. Result: " + (string)(result.HasValue ? result.Value.ToString() : "null"));
            }
            else
            {
                NLogger.Log.Debug("SetDeviceToken: token is present in DB ");
                if (dbToken.StatusId != (int)DBStatusEnum.Active)
                {
                    model.TokenId = dbToken.TokenId;
                    NLogger.Log.Debug("SetDeviceToken: token is NOT active");
                    //Should change the status back to active
                    dbToken.StatusId = (int)DBStatusEnum.Active;
                    NLogger.Log.Debug("SetDeviceToken: UpdateNotificationToken BEFORE");
                    var result = ntbc.UpdateNotificationToken(dbToken);
                    NLogger.Log.Debug("SetDeviceToken: UpdateNotificationToken AFTER. Result: " + result );
                }
                else
                {
                    NLogger.Log.Debug("Active token already in DB no need to Update or Insert new token");
                    //NLogger.Log.Debug("SetDeviceToken: AddNotificationToken BEFORE");
                    //var result = ntbc.AddNotificationToken(model);
                    //NLogger.Log.Debug("SetDeviceToken: AddNotificationToken AFTER. Result: " + (string)(result.HasValue ? result.Value.ToString() : "null"));
                }
            }
        }

        public static List<string> GetDeviceTokenByProfileId(long profileId)
        {
            var ntbc = new NotificationTokenBusinessComponent();
            var dbToken = ntbc.GetNotificationTokenListByProfileId(profileId);
            //Same user could have multiple active device tokens
            return dbToken;
        }
        public static List<string> GetNotificationTokenList()
        {
            var ntbc = new NotificationTokenBusinessComponent();
            var dbToken = ntbc.GetNotificationTokenList();
            //Same user could have multiple active device tokens
            return dbToken;
        }

        private AccountResponseModel RegisterInternal(RegisterViewModel model, bool sendVerificationEmail = true)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "Registration failed.";
            response.IsActionRequired = false;
            if (model == null || string.IsNullOrEmpty(model.Email))
            {
                response.StatusMessage = "Invalid request data or email not provided.";
                return response;
            }
            try
            {
                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                SecurityStatus _retVal = Security_ExtendedMethods.Register(model, _userMgr, _signInManager, sendVerificationEmail, out _errors);
                
                //model.Id has be generated and assigned in above call to Security_ExtendedMethods.Register
                switch (_retVal)
                {
                    case SecurityStatus.Success:
                        {
                            response.StatusCode = SecurityStatus.Success;
                            response.StatusMessage = "Your account has been created successfully. You can now continue and login...";
                            response.IsActionRequired = false;
                            break;
                        }
                    case SecurityStatus.RequiresAccountActivation:
                        {
                            response.StatusCode = SecurityStatus.RequiresAccountActivation;
                            response.StatusMessage = "Your account is not activated. Please activate your account.";
                            response.IsActionRequired = true;
                            break;
                        }
                    case SecurityStatus.EmailVerification:
                        {
                            response.StatusCode = SecurityStatus.EmailVerification;
                            response.StatusMessage = "Your email is not verified. Please verify your email.";
                            response.IsActionRequired = true;
                            break;
                        }
                    case SecurityStatus.PhoneVerification:
                        {
                            response.StatusCode = SecurityStatus.PhoneVerification;
                            response.StatusMessage = "Your phone is not verified. Please verify";
                            response.IsActionRequired = true;
                            break;
                        }
                }
                if (model.Id > -1 && (
                                        _retVal == SecurityStatus.Success ||
                                        _retVal == SecurityStatus.RequiresAccountActivation ||
                                        _retVal == SecurityStatus.EmailVerification ||
                                        _retVal == SecurityStatus.PhoneVerification
                                     )
                    )
                {
                    SetupProfileForNewUser(model, response, _userMgr);
                    ApplicationUserManager.AddUser2Role(model.Id, 3);//Shop User (by default)
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return response;
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult RegisterGuest(RegisterViewModel model)
        {
            var response = new AccountResponseModel();
            if (model == null || string.IsNullOrEmpty(model.Email))
            {
                response.StatusCode = SecurityStatus.Failure;
                response.IsActionRequired = false;
                response.StatusMessage = "Invalid request data or email not provided.";
                return Ok<AccountResponseModel>(response);
            }
            else
            {
                var _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var appUser = _userMgr.FindByEmail(model.Email);
                if (appUser != null)
                {
                    if (appUser.Firstname == "Guest" && appUser.Lastname == "User" && appUser.PhoneNumber == "+1-9999999999" && ! appUser.EmailConfirmed)
                    {
                        
                        response.IsActionRequired = false;
                        response.StatusCode = SecurityStatus.Success;
                        response.StatusMessage = "Guest User already exists";

                        model.Id = appUser.Id;
                        model.UserName = model.Email;
                        model.Firstname = "Guest";
                        model.Lastname = "User";
                        model.Mobile = "+1-9999999999";

                        if (!SetupProfileForNewUser(model, response, _userMgr))
                        {
                            response.StatusCode = SecurityStatus.Failure;
                            response.StatusMessage = "email : '" + model.Email + "' already used by another guest user. " +
                                "if it belongs to you, then please try login  or user another email. " +
                                "If you don't have password, then try 'foreget/reset password' and 'resend verification link' from login screen.";
                        }
                        else {
                            ApplicationUserManager.AddUser2Role(model.Id, 3);//Shop User (by default)
                        }

                        return Ok<AccountResponseModel>(response);
                    }
                    else {
                        //some valid user already created with properly associated profile
                        response.StatusCode = SecurityStatus.Failure;
                        response.StatusMessage = "email : '" + model.Email + "' already accquired by another verified user. " +
                                "if it belong to you, then please try login or user another email. ";
                        response.IsActionRequired = false;
                    }
                }
                else
                {
                    var randomPassword = Membership.GeneratePassword(10, 2) + "T3$t";
                    model.UserName = model.Email;
                    model.Firstname = "Guest";
                    model.Lastname = "User";
                    model.Password = randomPassword;
                    model.ConfirmPassword = randomPassword;
                    model.Mobile = "+1-9999999999";
                    response = RegisterInternal(model, false);
                }
                return Ok<AccountResponseModel>(response);
            }
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult Register(RegisterViewModel model)
        {
            model.RequestedByProfileId = -1;
            var response = RegisterInternal(model);
            return Ok<AccountResponseModel>(response);
        }

        private static bool SetupProfileForNewUser(RegisterViewModel model, AccountResponseModel response, ApplicationUserManager _userMgr)
        {
            var comp = new ProfileBusinessComponent();
            bool createProfile = true;
            bool result = true;
            ProfileModel profile = null;

            profile = comp.GetProfileByUserId(model.Id);
            if (profile != null)
            {
                if (model.RequestedByProfileId != profile.ProfileID)
                {
                    //response.ValidProfileId = profile.ProfileID;
                    result = false;
                    createProfile = false;
                }
                else
                {
                    createProfile = false;
                }
            }
            else if (model.RequestedByProfileId > 0)
            {
                profile = comp.GetById(model.RequestedByProfileId);

                if (profile != null)
                {
                    var user = _userMgr.FindById(profile.UserID); //User should not exists becuase dummy user id is exists against Anonyomus profile
                    if (user == null || profile.UserID != model.Id)
                    {
                        profile.UserID = model.Id; // update the user id. i.e. Replace the Old Dummy/Random UserId with the newly created real UserId
                        profile.UserName = model.UserName;
                        profile.FirstName = model.Firstname;
                        profile.LastName = model.Lastname;
                        profile.FatherName = model.Mobile;
                        profile.IsVerified = false;
                        profile.UserTypeID = (long)DBUserTypeEnum.Buyer;

                        if (comp.UpdateProfile(profile))
                            createProfile = false;
                        else
                            createProfile = false;
                    }
                    else
                    {
                        createProfile = false;
                    }
                }
            }

            if(createProfile)
            {
                var profileId = comp.AddProfile(new ProfileModel
                {
                    UserID = model.Id,
                    UserName = model.UserName,
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    FatherName = model.Mobile,
                    IsVerified = false,
                    UserTypeID = (long)DBUserTypeEnum.Seller,
                });
                response.StatusMessage = profileId.HasValue ? response.StatusMessage : response.StatusMessage + " But there is problem when creating User Profile.";
            }
            return result;
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                var user = _userMgr.FindByEmailAsync(model.Email).Result;
                if (user == null || !(_userMgr.IsEmailConfirmedAsync(user.Id).Result))
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "User is invalid.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = _userMgr.GeneratePasswordResetTokenAsync(user.Id).Result;
                string a = Request.Headers.Host;
                var callbackUrl = Config.PublicSiteURL + "updatepassword?q=" + WebUtility.UrlEncode(CommonUtilities.Encrypt(user.Email + ";" + WebUtility.UrlEncode(code) + ";" + DateTime.Now.ToString("ddMMyyyyHHmmss")));
                _userMgr.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");

                response.StatusCode = SecurityStatus.Success;
                response.StatusMessage = "Verification email has been sent.";
                response.IsActionRequired = false;

                return Ok<AccountResponseModel>(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult ResetPassword(ResetPasswordViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                string decText = CommonUtilities.Decrypt(WebUtility.UrlDecode(model.encText));
                string[] data = decText.Split(';');
                DateTime ts;
                if (DateTime.TryParseExact(data[2], "ddMMyyyyHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out ts))
                {
                    if (ts.AddMinutes(30) >= DateTime.Now)
                    {
                        model.Email = data[0];
                        model.Code = data[1];

                        ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                        var user = _userMgr.FindByEmailAsync(model.Email).Result;
                        if (user == null)
                        {
                            response.StatusCode = SecurityStatus.Failure;
                            response.StatusMessage = "User is invalid.";
                            response.IsActionRequired = false;
                            return Ok<AccountResponseModel>(response);
                        }
                        if(model.ConfirmPassword != model.Password)
                        {
                            response.StatusCode = SecurityStatus.Failure;
                            response.StatusMessage = "Password and Confirm Password does not match";
                            response.IsActionRequired = false;
                            return Ok<AccountResponseModel>(response);
                        }
                        var result = _userMgr.ResetPasswordAsync(user.Id, WebUtility.UrlDecode(model.Code), model.Password).Result;
                        if (result.Succeeded)
                        {
                            response.StatusCode = SecurityStatus.Success;
                            response.StatusMessage = "Password has been reset successfully";
                            response.IsActionRequired = false;
                            return Ok<AccountResponseModel>(response);
                        }
                    }
                    else
                    {
                        response.StatusCode = SecurityStatus.Failure;
                        response.StatusMessage = "Invalid Request.";
                        response.IsActionRequired = false;
                        return Ok<AccountResponseModel>(response);
                    }
                }
                else
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Invalid Request.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult ConfirmEmail(ResetPasswordViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                string decText = CommonUtilities.Decrypt(WebUtility.UrlDecode(model.encText));
                string[] data = decText.Split(';');
                DateTime ts;
                if (DateTime.TryParseExact(data[2], "ddMMyyyyHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out ts))
                {
                    if (ts.AddMinutes(30) >= DateTime.Now)
                    {
                        model.Email = data[0];
                        model.Code = data[1];

                        ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                        var user = _userMgr.FindByEmailAsync(model.Email).Result;
                        if (user == null)
                        {
                            response.StatusCode = SecurityStatus.Failure;
                            response.StatusMessage = "User is invalid.";
                            response.IsActionRequired = false;
                            return Ok<AccountResponseModel>(response);
                        }
                        var result = _userMgr.ConfirmEmailAsync(user.Id, WebUtility.UrlDecode(model.Code)).Result;
                        if (result.Succeeded)
                        {
                            response.StatusCode = SecurityStatus.Success;
                            response.StatusMessage = "Email has been confirmed";
                            response.IsActionRequired = false;
                            return Ok<AccountResponseModel>(response);
                        }
                        else
                        {
                            response.StatusCode = SecurityStatus.Failure;
                            response.StatusMessage = "Email has not been confirmed. Either invalid token or the token has beenn expired. Kindly try to resend verification token again or contact your system admin.";
                            response.IsActionRequired = true;
                            return Ok<AccountResponseModel>(response);
                        }
                    }
                    else
                    {
                        response.StatusCode = SecurityStatus.Failure;
                        response.StatusMessage = "Invalid Request.";
                        response.IsActionRequired = false;
                        return Ok<AccountResponseModel>(response);
                    }
                }
                else
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Invalid Request.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult ChangePassword(ChangePasswordViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                var user = _userMgr.FindByEmailAsync(model.Email).Result;
                if (user == null)
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "User is invalid.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
                var _retVal = _userMgr.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword).Result;
                if (_retVal.Succeeded)
                {
                    response.StatusCode = SecurityStatus.Success;
                    response.StatusMessage = "Password has been changed successfully";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
                else
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = _retVal.Errors.First();
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public IHttpActionResult ResendConfirmationEmail(ResetPasswordViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                var user = _userMgr.FindByEmailAsync(model.Email).Result;
                if (user == null)
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "User is invalid.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                if (_userMgr.IsEmailConfirmedAsync(user.Id).Result)
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Your Email is already confirmed.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                bool result = Security_ExtendedMethods.SendOTP2Email(_userMgr, user.Id, user.Email);

                if(result)
                {
                    response.StatusCode = SecurityStatus.Success;
                    response.StatusMessage = "Verification email has been sent.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
                else
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Something went wrong. Please try again";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        private SecurityDbContext database = SecurityDbContext.CreateInstance();
        [HttpGet]
        public IHttpActionResult GetPermissionsImport()
        {
            var _controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t != null
                    && t.IsPublic
                    && t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                    && !t.IsAbstract
                    && typeof(ApiController).IsAssignableFrom(t));

            var _controllerMethods = _controllerTypes.ToDictionary(controllerType => controllerType,
                    controllerType => controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m => typeof(IHttpActionResult).IsAssignableFrom(m.ReturnType)));
            List<string> perm = new List<string>();
            foreach (var _controller in _controllerMethods)
            {
                string _controllerName = _controller.Key.Name;

                foreach (var _controllerAction in _controller.Value)
                {
                    string _controllerActionName = _controllerAction.Name;

                    var area = "api";/* string.Empty;
                    var parts = _controllerAction.DeclaringType.Namespace.Split('.').ToList();
                    var areaIndex = parts.IndexOf("Controllers");
                    if (areaIndex > -1)
                        area = parts[areaIndex - 1];*/
                    if (_controllerName.EndsWith("Controller"))
                    {
                        _controllerName = _controllerName.Substring(0, _controllerName.LastIndexOf("Controller"));
                    }

                    string _permissionDescription = string.Format("{0}-{1}-{2}", area, _controllerName, _controllerActionName);
                    
                    //perm.Add(_permissionDescription);/*
                    PERMISSION _permission = database.PERMISSIONS.Where(p => p.PermissionDescription.ToLower() == _permissionDescription.ToLower()).FirstOrDefault();
                    if (_permission == null)
                    {
                        if (ModelState.IsValid)
                        {
                            PERMISSION _perm = new PERMISSION();
                            _perm.PermissionDescription = _permissionDescription;

                            database.PERMISSIONS.Add(_perm);
                            database.SaveChanges();
                        }
                    }
                }
            }
            return Ok<List<string>>(perm);
        }

        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(TokenResponseModel))]
        public IHttpActionResult GetAnonymousToken()
        {
            TokenResponseModel responeModel = GetToken(Config.WebAPIAnonymousUser, Config.WebAPIAnonymousUserPassword);            
            return Ok<TokenResponseModel>(responeModel);
        }

        private TokenResponseModel GetToken(string UserName, string Password)
        {
            var IP = CommonUtilities.GetClientIp(Request);
            TokenResponseModel responeModel = new TokenResponseModel();
            TokenRequestModel requestModel = new TokenRequestModel(UserName, Password);
            Uri baseUri = new Uri(Request.RequestUri, RequestContext.VirtualPathRoot);
            var client = new RestClient(baseUri.ToString() + "/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("RemoteIP", IP);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            string data = "UserName=" + requestModel.UserName + "&password=" + requestModel.Password + "&grant_type=" + requestModel.grant_type;
            request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responeModel = JsonConvert.DeserializeObject<TokenResponseModel>(response.Content);
                //Add token expiry date into response model
                responeModel.expiredInMinutes = 30;
                responeModel.expiredTime = DateTime.UtcNow.AddMinutes(responeModel.expiredInMinutes);
                return responeModel;
            }

            return responeModel;
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> SendSecurityCode(SendCodeViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                if (string.IsNullOrEmpty(model.VerificationMethod) || string.IsNullOrEmpty(model.Email))
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Invalid Values.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                var user = _userMgr.FindByEmailAsync(model.Email).Result;
                
                if (user == null)
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "User is invalid.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }               

                var code = await _userMgr.GenerateTwoFactorTokenAsync(user.Id, model.VerificationMethod);
                IdentityResult notificationResult = await _userMgr.NotifyTwoFactorTokenAsync(user.Id, model.VerificationMethod, code);
                if (notificationResult.Succeeded)
                {
                    response.StatusCode = SecurityStatus.Success;

                    if (model.VerificationMethod == Security_ExtendedMethods.c_PhoneCode)
                        response.StatusMessage = "Code has been sent to your registered phone number";
                    else
                        response.StatusMessage = "Code has been sent to your registered email address";

                    response.IsActionRequired = false;
                }              

                return Ok<AccountResponseModel>(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> VerifySecurityCode(VerifyCodeViewModel model)
        {
            List<string> _errors = new List<string>();
            AccountResponseModel response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.StatusMessage = "User is invalid.";
            response.IsActionRequired = false;
            try
            {
                if (string.IsNullOrEmpty(model.VerificationMethod) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Code))
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "Invalid Values.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

                var user = _userMgr.FindByEmailAsync(model.Email).Result;

                if (user == null)
                {
                    response.StatusCode = SecurityStatus.Failure;
                    response.StatusMessage = "User is invalid.";
                    response.IsActionRequired = false;
                    return Ok<AccountResponseModel>(response);
                }

                bool verified = await _userMgr.VerifyTwoFactorTokenAsync(user.Id, model.VerificationMethod, model.Code);
                if (verified)
                {                    
                    response.StatusCode = SecurityStatus.Success;
                    response.StatusMessage = "Code has been verified";                    
                    response.IsActionRequired = false;                    
                }

                return Ok<AccountResponseModel>(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = ex.Message;
                response.IsActionRequired = false;
            }

            if (_errors.Count() > 0)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = _errors[0];
                response.IsActionRequired = false;
            }

            return Ok<AccountResponseModel>(response);
        }

        [HttpGet]
        [ReturnType(DataType = typeof(List<ShopUserModel>))]
        public IHttpActionResult GetInactiveShopList()
        {
            var listOfusers = this.GetInactiveShopUserEnumeration().ToList();
            if (listOfusers != null)
                return Ok<List<ShopUserModel>>(listOfusers);
            else
                return Conflict();
        }

        [HttpGet]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetInactiveShopCount()
        {
            var InactiveShopCount = this.GetInactiveShopUserEnumeration().Count();
            return Ok<long>(InactiveShopCount);
        }


        [HttpGet]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetInactiveProfileCount()
        {
            DateTime dt = DateTime.Now.AddDays(-1 * Config.InactiveShopDays);
            var profile = this.GetProfileUserEnumeration();
            profile = profile.Where(p => p.LastModified <= dt);
            var InactiveProfileCount = profile.Count();
            return Ok<long>(InactiveProfileCount);
        }

        [HttpGet]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetNewProfileCount()
        {
            DateTime dt = DateTime.Now.AddDays(-1 * Config.NewUserThresholdDays);
            var profile = this.GetProfileUserEnumeration();
            profile = profile.Where(p => p.UserCreatedOn <= dt);
            var InactiveProfileCount = profile.Count();
            return Ok<long>(InactiveProfileCount);
        }

        [HttpGet]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetAllProfileCount()
        {
            var profile = this.GetProfileUserEnumeration();
            var InactiveProfileCount = profile.Count();
            return Ok<long>(InactiveProfileCount);
        }
        private IEnumerable<ShopUserModel> GetInactiveShopUserEnumeration()
        {
            SupplierBusinessComponent sbc = new SupplierBusinessComponent();
            List<ShopUserModel> suppliers = sbc.GetSupplierUserIds();
            List<long> supplierUserIds = new List<long>();
            foreach (var s in suppliers)
            {
                supplierUserIds.Add(s.UserId);
            }
            DateTime dt = DateTime.Now.AddDays(-1 * Config.InactiveShopDays);
            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userList = _userMgr.Users.ToList();
            var listOfusers = (from u in userList
                                               join s in suppliers on u.Id equals s.UserId
                                               where u.LastModified <= dt &&
                                               supplierUserIds.Contains(u.Id)
                                               orderby u.LastModified
                                               select new ShopUserModel
                                               {
                                                   UserId = u.Id,
                                                   ProfileId = s.ProfileId,
                                                   Firstname = s.Firstname,
                                                   Lastname = s.Lastname,
                                                   ShopId = s.ShopId,
                                                   ShopName = s.ShopName,
                                                   LastModified = u.LastModified,
                                                   UserCreatedOn = s.UserCreatedOn,
                                                   Inactive = true,
                                               });
            return listOfusers;
        }

        private IEnumerable<ProfileUserModel> GetProfileUserEnumeration()
        {
            //DateTime dt = DateTime.Now.AddDays(-1 * Config.InactiveShopDays);

            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userList = _userMgr.Users.ToList();

            ProfileBusinessComponent profile = new ProfileBusinessComponent();
            var profileList = profile.GetProfileList();

            var listOfusers = (from u in userList
                               join p in profileList on u.Id equals p.UserID
                               //where u.LastModified <= dt 
                               orderby u.LastModified
                               select new ProfileUserModel
                               {
                                   UserId = u.Id,
                                   ProfileId = p.ProfileID,
                                   Firstname = p.FirstName,
                                   Lastname = p.LastName,
                                   LastModified = u.LastModified,
                                   UserCreatedOn = p.CreatedOn,
                                   Inactive = true,
                               });
            return listOfusers;
        }

    }
}
