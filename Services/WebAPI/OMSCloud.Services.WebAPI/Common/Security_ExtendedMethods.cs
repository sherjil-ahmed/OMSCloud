using System;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Security.Policy;
using System.Security.Claims;
using System.Net;
using OMSCloud.Services.WebAPIs.Models;
using OMSCloud.Contracts.Common;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.ViewModels;
using System.Linq;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.Services.WebAPIs.Common
{
    public enum SecurityStatus
    {
        Unknown = -1,
        Success = 0,
        LockedOut = 1,
        RequiresVerification = 2,
        Failure = 3,
        EmailVerification = 4,
        PhoneVerification = 5,
        RequiresAccountActivation = 6,
        EmailUnconfirmed = 7,
        PhoneNumberUnconfirmed = 8,
        InvalidToken = 9,
        ReRequiresAccountActivation = 10,
    }

    public static class Security_ExtendedMethods
    {
        public static string c_AccountLockout = "Your account has been locked out for {0} minutes due to multiple failed login attempts";
        //public static string c_InvalidCredentials = "Invalid credentials. You have {0} more attempt(s) before your account gets locked out";
        public static string c_InvalidCredentials = "The password entered is incorrect. Be sure you're using the correct password for this account. You have {0} more attempt(s) before your account gets locked out";
        public static string c_InvalidLogin = "Invalid login attempt";
        public static string c_InvalidUser = "This account doesn't exist. Please enter a registed email or create a new account.";
        public static string c_AccountEmailUnconfirmed = "Please verify your account using the email sent to your email address during account creation process.";
        // You must verify your account using the e-mail sent during the account registration process before being allowed to continue...";
        public static string c_AccountPhoneNumberUnconfirmed = "You must verify your account using the security code sent to the mobile number specified during the account registration process before being allowed to continue.  A new security code has been sent to the mobile number {0}.  Enter the security code sent to your mobile number into the input field below and click 'Verify My Identity' to verify your identity...";
        public static string c_AccountUnverified = "You have not verified your identify during the registration process.  Please request for a new security code to be sent...";

        public static string c_EmailCode = "Email Code";
        public static string c_PhoneCode = "Phone Code";

        public static string cKey_UserLockoutEnabled = "UserLockoutEnabled";
        public static string cKey_AccountLockoutTimeSpan = "AccountLockoutTimeSpan";
        public static string cKey_AccountSessionTimeSpan = "AccountSessionTimeSpan";
        public static string cKey_MaxFailedAccessAttemptsBeforeLockout = "MaxFailedAccessAttemptsBeforeLockout";
        public static string cKey_2FAEnabled = "2FAEnabled";
        public static string cKey_2FADeviceType = "2FADeviceType";
        public static string cKey_AccountVerificationRequired = "AccountVerificationRequired";
        public static string cKey_PasswordRequiredLength = "PasswordRequiredLength";
        public static string cKey_PasswordRequireNonLetterOrDigit = "PasswordRequireNonLetterOrDigit";
        public static string cKey_PasswordRequireDigit = "PasswordRequireDigit";
        public static string cKey_PasswordRequireLowercase = "PasswordRequireLowercase";
        public static string cKey_PasswordRequireUppercase = "PasswordRequireUppercase";

        #region Registration
        private static long RegisterUser(RegisterViewModel model, ApplicationUserManager userMngr, out List<string> _errors)
        {
            long _retVal = -1;
            _errors = new List<string>();
            try
            {
                bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    PhoneNumber = model.Mobile,
                    TwoFactorEnabled = Is2FAEnabled
                };

                if (userMngr != null)
                {
                    var userValidationResult = userMngr.UserValidator.ValidateAsync(user).Result;
                    if (!userValidationResult.Succeeded)
                    {
                        _errors.AddRange(userValidationResult.Errors);
                    }
                    var passwordValidationResult = userMngr.PasswordValidator.ValidateAsync(model.Password).Result;
                    if (!passwordValidationResult.Succeeded)
                    {
                        _errors.Add("Password should have at least one non-alphabet, one digit, and one uppercase (A-Z) aphabet.");
                    }
                    else
                    {
                        var result = userMngr.Create(user, model.Password);
                        if (result.Succeeded)
                        {
                            _retVal = user.Id;
                        }
                        else
                        {
                            _errors.AddRange(result.Errors);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retVal;
        }

        public static SecurityStatus Register(RegisterViewModel model, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, bool sendVerificationEmail, out List<string> _errors)
        {
            SecurityStatus _retVal = SecurityStatus.Failure;
            try
            {
                //Logic driven by settings defined in the application’s configuration file...
                long _userId = Security_ExtendedMethods.RegisterUser(model, userMngr, out _errors);
                if (_userId > -1)
                {
                    model.Id = _userId;
                    if (userMngr != null && sendVerificationEmail)
                    {
                        //Check if we require an Account Verification Email as part of our registration process...
                        bool IsAccountVerificationRequired = GetConfigSettingAsBool(cKey_AccountVerificationRequired);
                        bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
                        string DeviceType = GetConfigSetting(cKey_2FADeviceType);

                        //if ((IsAccountVerificationRequired) || (Is2FAEnabled && DeviceType == c_EmailCode))
                        if ((IsAccountVerificationRequired && DeviceType == c_EmailCode) || (Is2FAEnabled && DeviceType == c_EmailCode))
                        {
                            //Generate Email Confirmation Token                      
                            _retVal = SecurityStatus.Failure;
                            if (SendOTP2Email(userMngr, _userId, model.Email))
                                _retVal = SecurityStatus.RequiresAccountActivation;

                            return _retVal;
                        }
                        //else if (Is2FAEnabled && DeviceType == c_PhoneCode)
                        else if ((IsAccountVerificationRequired && DeviceType == c_PhoneCode) || (Is2FAEnabled && DeviceType == c_PhoneCode))
                        {
                            _retVal = SecurityStatus.Failure;
                            if (SendOTP2Phone(userMngr, _userId, model.Mobile))
                                _retVal = SecurityStatus.PhoneVerification;

                            return _retVal;
                        }
                    }
                    _retVal = SecurityStatus.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retVal;
        }
        #endregion

        #region Login
        public static AccountStatusModel Login(LoginViewModel model, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out List<string> _errors)
        {
            SecurityStatus _retVal = SecurityStatus.Failure;

            AccountStatusModel accountStatus = new AccountStatusModel();
            accountStatus.StatusCode = _retVal;
            accountStatus.routeList = new List<string>();

            _errors = new List<string>();
            try
            {
                var user = userMngr.FindByEmail(model.eMail);
                if (user != null)
                {
                    var validCredentials = userMngr.Find(user.UserName, model.Password);
                    if (userMngr.IsLockedOut(user.Id))
                    {
                        _errors.Add(string.Format(c_AccountLockout, GetConfigSettingAsDouble(cKey_AccountLockoutTimeSpan)));
                        accountStatus.StatusCode = SecurityStatus.LockedOut;
                        return accountStatus;
                    }
                    else if (userMngr.GetLockoutEnabled(user.Id) && validCredentials == null)
                    {
                        userMngr.AccessFailed(user.Id);
                        if (userMngr.IsLockedOut(user.Id))
                        {
                            _errors.Add(string.Format(c_AccountLockout, GetConfigSettingAsDouble(cKey_AccountLockoutTimeSpan)));
                            accountStatus.StatusCode = SecurityStatus.LockedOut;
                            return accountStatus;
                        }
                        else
                        {
                            int _attemptsLeftB4Lockout = (GetConfigSettingAsInt(cKey_MaxFailedAccessAttemptsBeforeLockout) - userMngr.GetAccessFailedCount(user.Id));
                            _errors.Add(string.Format(c_InvalidCredentials, _attemptsLeftB4Lockout));
                            accountStatus.StatusCode = _retVal;
                            return accountStatus;                            
                        }
                    }
                    else if (validCredentials == null)
                    {
                        _errors.Add(c_InvalidLogin);
                        accountStatus.StatusCode = _retVal;
                        return accountStatus;
                    }
                    else
                    {
                        //Valid credentials entered, we need to check whether email verification is required...
                        bool IsAccountVerificationRequired = GetConfigSettingAsBool(cKey_AccountVerificationRequired);
                        bool Is2FAEnabled = GetConfigSettingAsBool(cKey_2FAEnabled);
                        string DeviceType = GetConfigSetting(cKey_2FADeviceType);

                        if ((IsAccountVerificationRequired && DeviceType == c_EmailCode) || (Is2FAEnabled && DeviceType == c_EmailCode))
                        {
                            //Check if email verification has been confirmed!
                            if (!userMngr.IsEmailConfirmed(user.Id))
                            {
                                //Display error message on login page, take no further action...                         
                                _errors.Add(c_AccountEmailUnconfirmed);
                                accountStatus.StatusCode = SecurityStatus.EmailUnconfirmed;
                                return accountStatus;
                            }
                        }
                        //else if (Is2FAEnabled && DeviceType == c_PhoneCode)
                        else if ((IsAccountVerificationRequired && DeviceType == c_PhoneCode) || (Is2FAEnabled && DeviceType == c_PhoneCode))
                        {
                            if (!userMngr.IsPhoneNumberConfirmed(user.Id))
                            {
                                _errors.Add(c_AccountPhoneNumberUnconfirmed);                                
                                accountStatus.StatusCode = SecurityStatus.PhoneNumberUnconfirmed;
                                return accountStatus;
                            }
                        }

                        bool _userLockoutEnabled = GetConfigSettingAsBool(cKey_UserLockoutEnabled);

                        //Before we signin, check that our 2FAEnabled config setting agrees with the database setting for this user...
                        if (!Is2FAEnabled && Is2FAEnabled != userMngr.GetTwoFactorEnabled(user.Id))
                        {
                            userMngr.SetTwoFactorEnabled(user.Id, Is2FAEnabled);
                        }
                        //if (Is2FAEnabled)
                        //    Is2FAEnabled = userMngr.GetTwoFactorEnabled(user.Id);

                        _retVal = (SecurityStatus)signInMngr.PasswordSignIn(user.UserName, model.Password, model.RememberMe, shouldLockout: _userLockoutEnabled);
                        switch (_retVal)
                        {
                            case SecurityStatus.Success:
                            case SecurityStatus.RequiresVerification:
                            {
                                user.LastModified = DateTime.Now;
                                userMngr.Update(user);

                                ProfileBusinessComponent comp = new ProfileBusinessComponent();
                                var profile = comp.GetProfileByUserId(user.Id);
                                if (profile != null)
                                {
                                    if (user.Roles.Count > 0)
                                    {
                                        List<long> roleIds = user.Roles.Select(x => x.RoleId).ToList();

                                        RoleOptionPairBusinessComponent cropbc = new RoleOptionPairBusinessComponent();
                                        List<RoleOptionPairModel> roleOptionPairModel = cropbc.GetRoleOptionPairByRoleId(roleIds);
                                        roleOptionPairModel = roleOptionPairModel.Where(x => x.Option.ModuleID == 2).ToList(); //2 is for Public Site and 1 is for Admin
                                        if (roleOptionPairModel.Count > 0)
                                        {
                                            accountStatus.routeList = roleOptionPairModel.Select(x => x.Option.PageURL).Distinct().ToList();
                                        }
                                        userMngr.ResetAccessFailedCount(user.Id);
                                        break;
                                    }
                                    else
                                    {
                                        accountStatus.StatusCode = SecurityStatus.Failure;
                                        return accountStatus;
                                    }
                                }
                                else
                                {
                                    accountStatus.StatusCode = SecurityStatus.Failure;
                                    return accountStatus;
                                }
                            }
                            default:
                            {
                                _errors.Add(c_InvalidLogin);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    _errors.Add(c_InvalidUser);
                }
            }
            catch (Exception ex)
            {
                _errors.Add(ex.Message);
                //throw ex;
            }
            accountStatus.StatusCode = _retVal;
            return accountStatus;
        }

        #endregion

        #region Verification
        public static SecurityStatus VerifyOTP4Phone(long _userId, string _phoneNumber, string _token, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out IEnumerable<string> _errors)
        {
            SecurityStatus _retVal = SecurityStatus.Failure;
            try
            {
                IdentityResult result = userMngr.ChangePhoneNumber(_userId, _phoneNumber, _token);
                if (result == IdentityResult.Success)
                {
                    ApplicationUser user = userMngr.FindById(_userId);
                    if (user != null)
                    {
                        signInMngr.SignIn(user, isPersistent: false, rememberBrowser: false);
                    }
                    _retVal = SecurityStatus.Success;
                }
                _errors = result.Errors;
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }

        public static bool SendOTP2Phone(ApplicationUserManager _userMngr, long _userId, string _phoneNumber)
        {
            bool _retVal = false;

            if (string.IsNullOrEmpty(_phoneNumber))
                throw new Exception("No mobile number provided, unable to text notification...");

            if (_userMngr.SmsService != null)
            {
                //Generate security code for phone confirmation   
                var code = _userMngr.GenerateChangePhoneNumberToken(_userId, _phoneNumber);
                var message = new IdentityMessage
                {
                    Destination = _phoneNumber,
                    Body = "Your security code is: " + code
                };

                //Send the security code  
                _userMngr.SmsService.Send(message);
                _retVal = true;
            }
            else
            {
                throw new Exception("SMS Service has not been configured, unable to text notification...");
            }
            return _retVal;
        }

        public static bool SendOTP2Email(ApplicationUserManager _userMngr, long _userId, string _email)
        {
            bool _retVal = false;

            if (string.IsNullOrEmpty(_email))
                throw new Exception("No e-mail address provided, unable to send email notification...");

            if (_userMngr.EmailService != null)
            {
                //Generate security code for email confirmation
                string _code = _userMngr.GenerateEmailConfirmationToken(_userId);
                                
                var callbackUrl = Config.PublicSiteURL + "confirmemail?q=" + WebUtility.UrlEncode(CommonUtilities.Encrypt(_email + ";" + WebUtility.UrlEncode(_code) + ";" + DateTime.Now.ToString("ddMMyyyyHHmmss")));
                var message = new IdentityMessage {
                    Subject = "Your email verification at Zvonr",
                    Destination = _email,
                    Body = string.Format("Please <a href='{0}'>verify</a> your email address before first time long-in."
                    + Environment.NewLine +
                    "To delete your account, kindly send an email to support@zvonr.ca from this email address with the subject line \"Delete Account\". The Zvonr-Admin will delete your account from Zvonr Marketplace."
                    , callbackUrl) };
                //Email the security code  
                _userMngr.EmailService.Send(message);
                _retVal = true;
            }
            else
            {
                throw new Exception("Smtp Service has not been configured, unable to send email notification...");
            }
            return _retVal;
        }

        public static bool VerifyOTP4Email(long _userId, string _token, ApplicationUserManager userMngr, ApplicationSignInManager signInMngr, out IEnumerable<string> _errors)
        {
            bool _retVal = false;
            _errors = new List<string>();
            try
            {
                ApplicationUser user = userMngr.FindById(_userId);
                if (userMngr.VerifyTwoFactorToken(user.Id, c_EmailCode, _token))
                {
                    signInMngr.SignIn(user, isPersistent: false, rememberBrowser: false);
                    return true;
                }
                else
                {
                    _errors = _errors = new List<string> { "Invalid code..." };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retVal;
        }

        public static SecurityStatus RequestAccountVerification(long _userId, string _email, ApplicationUserManager userMngr, out IEnumerable<string> _errors)
        {
            SecurityStatus _retVal = SecurityStatus.Failure;
            _errors = new List<string>();

            try
            {
                if (userMngr.EmailService != null)
                {
                    string _code = userMngr.GenerateEmailConfirmationToken(_userId);

                    //var callbackUrl = new UrlHelper(controller.ControllerContext.RequestContext).Action("ConfirmEmail", "Account", new { userId = _userId, code = _code }, protocol: controller.ControllerContext.RequestContext.HttpContext.Request.Url.Scheme);
                    var callbackUrl = "";
                    var message = new IdentityMessage { Subject = "Account Verification", Destination = _email, Body = string.Format("Please <a href='{0}'>verify</a> your account before attempting to log in to the system.", callbackUrl) };
                    userMngr.EmailService.Send(message);

                    _retVal = SecurityStatus.RequiresAccountActivation;
                }
                else
                {
                    _errors = new List<string> { "Smtp Service has not been configured!", "Unable to send e-mail Confirmation Token..." };
                }
            }
            catch (Exception)
            {

                throw;
            }


            return _retVal;
        }

        #endregion

        #region Helper Functions
        public static bool GetConfigSettingAsBool(string _name, bool _defaultValue = false)
        {
            bool _retVal = _defaultValue;
            try
            {
                _retVal = Convert.ToBoolean(Config.GetConfig(_name, _defaultValue));
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static int GetConfigSettingAsInt(string _name, int _defaultValue = 0)
        {
            int _retVal = _defaultValue;
            try
            {
                _retVal = Convert.ToInt32(Config.GetConfig(_name, _defaultValue));
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static double GetConfigSettingAsDouble(string _name, double _defaultValue = 0)
        {
            double _retVal = _defaultValue;
            try
            {
                _retVal = Convert.ToDouble(Config.GetConfig(_name, _defaultValue));
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static string GetConfigSetting(string _name)
        {
            string _retVal = string.Empty;
            try
            {
                _retVal = Config.GetConfig(_name, "");
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
        #endregion
    }
}