using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.Services.WebAPIs.Common;
using OMSCloud.Services.WebAPIs.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

using static OMSCloud.Contracts.Common.NLogger;


namespace OMSCloud.Services.WebAPIs
{
    public class EmailService : IIdentityMessageService
    {
        private const string cKey_SmtpServer = "SmtpServer";
        private const string cKey_SmtpPort = "SmtpPort";
        private const string cKey_SmtpUsername = "SmtpUsername";
        private const string cKey_SmtpPassword = "SmtpPassword";
        private const string cKey_SmtpEMailFrom = "SmtpEMailFrom";
        private const string cKey_SmtpNetworkDeliveryMethodEnabled = "SmtpNetworkDeliveryMethodEnabled";
        private const string cKey_IsSSLRequired = "SSLRequired";

        private readonly string m_Server;
        private readonly int m_Port;
        private readonly string m_Username;
        private readonly string m_Password;
        private readonly string m_EMailFrom;
        private readonly bool m_IsSmtpNetworkDeliveryMethodEnabled;
        private readonly bool m_IsSSLRequired;

        //public Task SendAsync(IdentityMessage message)
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.           
            //bool IsSmtpServer = Security_ExtendedMethods.GetConfigSettingAsBool("");
            //await Send(message);
            Send2HotmailAccount(message);
        }

        public EmailService()
        {
            this.m_Server = Security_ExtendedMethods.GetConfigSetting(cKey_SmtpServer);
            this.m_Port = Security_ExtendedMethods.GetConfigSettingAsInt(cKey_SmtpPort);
            this.m_Username = Security_ExtendedMethods.GetConfigSetting(cKey_SmtpUsername);
            this.m_Password = Security_ExtendedMethods.GetConfigSetting(cKey_SmtpPassword);
            this.m_EMailFrom = Security_ExtendedMethods.GetConfigSetting(cKey_SmtpEMailFrom);
            this.m_IsSmtpNetworkDeliveryMethodEnabled = Security_ExtendedMethods.GetConfigSettingAsBool(cKey_SmtpNetworkDeliveryMethodEnabled);
            this.m_IsSSLRequired = Security_ExtendedMethods.GetConfigSettingAsBool(cKey_IsSSLRequired, true);
        }

        private async Task Send(IdentityMessage message)
        {
            Send2HotmailAccount(message);
            return;

            // Configure Email client.
            SmtpClient client = new SmtpClient(this.m_Server);
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Create credentials:
            NetworkCredential credentials = new NetworkCredential(this.m_Username, this.m_Password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            // WARNING: This switches of certificate validation!
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            // Create the message:
            var mail = new MailMessage(new MailAddress(this.m_Username, "Administator"), new MailAddress(message.Destination, message.Destination));
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            // Send:
            if (mail != null)
            {
                await client.SendMailAsync(mail);
            }
            else
            {
                //Trace.TraceError("Failed to send email.");
                await Task.FromResult(0);
            }
        }

        public bool Send2HotmailAccount(IdentityMessage message)
        {
            bool _retVal = false;
            string LogMsg = string.Empty;
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(this.m_EMailFrom);
                    mail.To.Add(message.Destination);
                    mail.Subject = message.Subject;
                    mail.Body = message.Body;
                    mail.IsBodyHtml = true;
                    //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Plain));
                    //mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));
                    //mail.ReplyToList.Add(new MailAddress(this.m_Username));

                    var smtp = new SmtpClient(this.m_Server, this.m_Port);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(this.m_Username, this.m_Password);
                    //smtp.Timeout = 60000; // 60 seconds
                    smtp.EnableSsl = this.m_IsSSLRequired;// true; // Outlook.com and Gmail require SSL


                    if (this.m_IsSmtpNetworkDeliveryMethodEnabled)
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    }
                    LogMsg = 
                        "FromEmail : " + this.m_EMailFrom + 
                        ", ToEmail : " + message.Destination + 
                        ", Subject : " + message.Subject + 
                        //", Credentials : " + this.m_Username + " / " + this.m_Password + 
                        "Server/Port : " + this.m_Server + " / " + this.m_Port;
                    //Log.Info(LogMsg);
                    smtp.Send(mail);

                    // email was accepted by the SMTP server
                    _retVal = true;
                }
            }
            catch (Exception ex)
            {
                // TODO: Log the exception message
                ErrorLog.Error(ex, "Error occured while sending email" + Environment.NewLine + "LogMsg : " + LogMsg);
                return false;
            }
            return _retVal;
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            SMSGatewayBusinessComponent comp = new SMSGatewayBusinessComponent();

            SMSRequestModel model = new SMSRequestModel();
            model.SMSText = message.Body;
            model.MobileNumber = message.Destination;

            comp.SendSMS(model);
            //var Twilio = new TwilioRestClient(ConfigurationManager.AppSettings["SMSSid"],
            //ConfigurationManager.AppSettings["SMSToken"]);
            //var result = Twilio.SendMessage(ConfigurationManager.AppSettings["SMSFromPhone"], message.Destination, message.Body, "");

            return Task.FromResult(0);
        }
    }

    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUserStore<ApplicationUser, long>
    {
        public ApplicationUserStore(SecurityDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser, long>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, long> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<SecurityDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = Security_ExtendedMethods.GetConfigSettingAsInt(Security_ExtendedMethods.cKey_PasswordRequiredLength, 6),
                RequireNonLetterOrDigit = Security_ExtendedMethods.GetConfigSettingAsBool(Security_ExtendedMethods.cKey_PasswordRequireNonLetterOrDigit, true),
                RequireDigit = Security_ExtendedMethods.GetConfigSettingAsBool(Security_ExtendedMethods.cKey_PasswordRequireDigit, true),
                RequireLowercase = Security_ExtendedMethods.GetConfigSettingAsBool(Security_ExtendedMethods.cKey_PasswordRequireLowercase, true),
                RequireUppercase = Security_ExtendedMethods.GetConfigSettingAsBool(Security_ExtendedMethods.cKey_PasswordRequireUppercase, true),
            };

            // Configure user lockout defaults          
            manager.UserLockoutEnabledByDefault = Security_ExtendedMethods.GetConfigSettingAsBool(Security_ExtendedMethods.cKey_UserLockoutEnabled);
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(Security_ExtendedMethods.GetConfigSettingAsDouble(Security_ExtendedMethods.cKey_AccountLockoutTimeSpan));
            manager.MaxFailedAccessAttemptsBeforeLockout = Security_ExtendedMethods.GetConfigSettingAsInt(Security_ExtendedMethods.cKey_MaxFailedAccessAttemptsBeforeLockout);

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, long>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, long>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

		public static ApplicationUser GetUser(long _userId)
        {
            return GetUser(SecurityDbContext.CreateInstance(), _userId);
        }

        public static ApplicationUser GetUser(SecurityDbContext db, long _userId)
        {
            ApplicationUser _retVal = null;
            try
            {
                _retVal = db.Users.Where(p => p.Id == _userId).Include("Roles").Include(x => x.Roles.Select(r => r.Role.PERMISSIONS)).FirstOrDefault();
            }
            catch (Exception)
            {
            }

            return _retVal;
        }

        public static List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.Users.Where(r => r.Inactive == false || r.Inactive == null).OrderBy(r => r.Lastname).ThenBy(r => r.Firstname).ToList();
                }
            }
            catch (Exception)
            {
            }

            return _retVal;
        }

        public static List<ApplicationUser> GetUsers4Surname(string _surname)
        {
            List<ApplicationUser> _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.Users.Where(r => r.Inactive == false || r.Inactive == null & r.Lastname == _surname).OrderBy(r => r.Lastname).ThenBy(r => r.Firstname).ToList();
                }
            }
            catch (Exception)
            {
            }

            return _retVal;
        }

        public static bool AddUser2Role(long _userId, long _roleId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationUser _user = GetUser(db, _userId);
                    if (_user.Roles.Where(p => p.RoleId == _roleId).Count() == 0)
                    {
                        //_user.UserRoles.Add(_role);

                        ApplicationUserRole _identityRole = new ApplicationUserRole { UserId = _userId, RoleId = _roleId };
                        if (!_user.Roles.Contains(_identityRole))
                            _user.Roles.Add(_identityRole);

                        _user.LastModified = DateTime.Now;
                        db.Entry(_user).State = EntityState.Modified;
                        db.SaveChanges();

                        _retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                NLogger.ErrorLog.Error(ex, "unable to assign roleId: " + _roleId + " to the userId: " + _userId);// to the newly registered user");
            }
            return _retVal;
        }

        public static bool RemoveUser4Role(long _userId, long _roleId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationUser _user = GetUser(db, _userId);
                    if (_user.Roles.Where(p => p.RoleId == _roleId).Count() > 0)
                    {
                        _user.Roles.Remove(_user.Roles.Where(p => p.RoleId == _roleId).FirstOrDefault());
                        _user.LastModified = DateTime.Now;
                        db.Entry(_user).State = EntityState.Modified;
                        db.SaveChanges();

                        _retVal = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static void SyncUserRole(DBUserTypePublicEnum enumValue, long userId)
        {
            string roleIds = enumValue.GetDefaultValue();
            if (string.IsNullOrEmpty(roleIds))
                return;
            string[] strRoleIds = roleIds.Split(new char[] { ',' });

            var newRoles = strRoleIds.ToList();
            ApplicationUser user = ApplicationUserManager.GetUser(userId);
            //foreach (var role in user.Roles)
            //{
            //    //if (!newRoles.Contains(role.RoleId))
            //    ApplicationUserManager.RemoveUser4Role(userId, role.RoleId);
            //}
            foreach (var roleId in newRoles)
            {
                long roleID = Convert.ToInt64(roleId);
                if (user.Roles.Where(r => r.RoleId == roleID).Any() == false)
                    ApplicationUserManager.AddUser2Role(userId, roleID);
            }
        }

        public static bool DeleteUser(long _userId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    //ApplicationUser _user = db.Users.Where(p => p.Id == _userId).Include("ROLES").FirstOrDefault();                 
                    ApplicationUser _user = GetUser(db, _userId);

                    _user.Roles.Clear();
                    db.Entry(_user).State = EntityState.Deleted;
                    db.SaveChanges();

                    _retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
        public static bool DeactivateUser(ApplicationUser _user)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    //ApplicationUser _user2Modify = GetUser(db, _user.Id);

                    db.Entry(_user).Entity.Inactive = true;
                    db.Entry(_user).State = EntityState.Modified;
                    db.SaveChanges();

                    _retVal = true;
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return _retVal;
        }
        public static bool UpdateUserPhone(UserViewModel _user)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationUser _user2Modify = GetUser(db, _user.Id);

                    //db.Entry(_user2Modify).Entity.UserName = _user.UserName;
                    //db.Entry(_user2Modify).Entity.Email = _user.Email;
                    db.Entry(_user2Modify).Entity.Firstname = _user.Firstname;
                    db.Entry(_user2Modify).Entity.Lastname = _user.Lastname;
                    db.Entry(_user2Modify).Entity.LastModified = System.DateTime.Now;
                    db.Entry(_user2Modify).Entity.PhoneNumber = _user.PhoneNumber;
                    db.Entry(_user2Modify).State = EntityState.Modified;
                    db.SaveChanges();

                    _retVal = true;
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return _retVal;
        }
        public static bool UpdateUser(UserViewModel _user)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationUser _user2Modify = GetUser(db, _user.Id);

                    db.Entry(_user2Modify).Entity.UserName = _user.UserName;
                    db.Entry(_user2Modify).Entity.Email = _user.Email;
                    db.Entry(_user2Modify).Entity.Firstname = _user.Firstname;
                    db.Entry(_user2Modify).Entity.Lastname = _user.Lastname;
                    db.Entry(_user2Modify).Entity.LastModified = System.DateTime.Now;
                    db.Entry(_user2Modify).Entity.PhoneNumber = _user.PhoneNumber;
                    db.Entry(_user2Modify).State = EntityState.Modified;
                    db.SaveChanges();

                    _retVal = true;
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return _retVal;
        }

		public static List<ApplicationUser> GetUsers4SelectList()
		{
			List<ApplicationUser> _retVal = null;
			try
			{
				using (SecurityDbContext db = SecurityDbContext.CreateInstance())
				{
					_retVal = db.Users.Where(r => r.Inactive == false || r.Inactive == null).ToList();
				}
			}
			catch (Exception)
			{
			}

			return _retVal;
		}

		#region Worker functions for Google OAuth credentials
		/// <summary>
		/// Retrieves stored Google OAuth credentials for a user
		/// </summary>
		public UserGoogleOAuthCredential GetStoredGoogleCredentials(long userId)
		{
			try
			{
				//Logger.Info(string.Format("Retrieving Google OAuth credentials for UserId: {0}", userId));
				var db = SecurityDbContext.CreateInstance();
				var credential = db.UserGoogleOAuthCredentials.Where(x => x.UserId == userId).FirstOrDefault();
				//var credential = new UserGoogleOAuthCredentialModel
				//{
				//	UserId = userId,
				//	GoogleId = o.GoogleId,
				//	AccessToken = o.AccessToken,
				//	RefreshToken = o.RefreshToken,
				//	AccessTokenExpiryTime = o.AccessTokenExpiryTime,
				//	CreatedOn = o.CreatedOn,
				//	ModifiedOn = o.ModifiedOn,
				//	IsActive = o.IsActive,
				//	AuthenticationProvider = o.AuthenticationProvider,
				//	UserOAuthCredentialId = o.Id,
				//};
				return credential;
			}
			catch (Exception ex)
			{
				//Logger.Error(ex, string.Format("Error retrieving Google OAuth credentials for UserId: {0}", userId));
				return null;
			}
		}

		/// <summary>
		/// Updates existing Google OAuth credentials
		/// </summary>
		public bool UpdateGoogleOAuthCredentials(long userId, GoogleUserInfoModel googleUserInfo, GoogleTokenResponseModel tokenResponse)
		{
			bool _retVal = false;
			try
			{
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationUser _user2Modify = GetUser(db, userId);

                    var existingCredentials = db.UserGoogleOAuthCredentials.Where(x => x.UserId == userId)
                        .FirstOrDefault();
                    if (existingCredentials != null)
                    {
                        existingCredentials.GoogleId = googleUserInfo.id;
                        existingCredentials.AccessToken = tokenResponse.access_token;
                        existingCredentials.RefreshToken = tokenResponse.refresh_token;
                        existingCredentials.AccessTokenExpiryTime = DateTime.Now.AddSeconds(tokenResponse.expires_in);
                        existingCredentials.IdToken = tokenResponse.id_token;
                        existingCredentials.Scope = tokenResponse.scope;
                        existingCredentials.TokenType = tokenResponse.token_type;
                        existingCredentials.AuthenticationProvider = "Google";
                        existingCredentials.ModifiedOn = DateTime.Now;
                        db.Entry(existingCredentials).State = EntityState.Modified;
                    }
                    else
                    {
                        UserGoogleOAuthCredential newCredential = new UserGoogleOAuthCredential
                        {
                            UserId = userId,
                            GoogleId = googleUserInfo.id,
                            AccessToken = tokenResponse.access_token,
                            RefreshToken = tokenResponse.refresh_token,
                            AccessTokenExpiryTime = DateTime.Now.AddSeconds(tokenResponse.expires_in),
                            IdToken = tokenResponse.id_token,
                            Scope = tokenResponse.scope,
                            TokenType = tokenResponse.token_type,
                            AuthenticationProvider = "Google",
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            ModifiedOn = DateTime.Now,
                            LastLoginOn = DateTime.Now
						};
                        db.UserGoogleOAuthCredentials.Add(newCredential);
					}
                    db.SaveChangesAsync();
					_retVal = true;
                }
			}
			catch (Exception ex)
			{
				//Logger.Error(ex, string.Format("Error updating Google OAuth credentials for UserId: {0}", userId));
				return false;
			}
            return _retVal;
		}
		/// <summary>
		/// Updates Google credentials in database
		/// </summary>
		public bool UpdateGoogleCredentialsInDatabase(UserGoogleOAuthCredential credential)
		{
			bool _retVal = false;
			try
			{
				using (SecurityDbContext db = SecurityDbContext.CreateInstance())
				{
					var existingCredentials = db.UserGoogleOAuthCredentials.Where(x => x.UserId == credential.UserId)
						.FirstOrDefault();
					if (existingCredentials != null)
					{
						existingCredentials.GoogleId = credential.GoogleId;
						existingCredentials.AccessToken = credential.AccessToken;
						existingCredentials.RefreshToken = credential.RefreshToken;
						existingCredentials.AccessTokenExpiryTime = credential.AccessTokenExpiryTime;
						existingCredentials.IdToken = credential.IdToken;
						existingCredentials.Scope = credential.Scope;
						existingCredentials.TokenType = credential.TokenType;
						existingCredentials.AuthenticationProvider = "Google";
						existingCredentials.ModifiedOn = DateTime.Now;
						db.Entry(existingCredentials).State = EntityState.Modified;
					}
					else
					{
						UserGoogleOAuthCredential newCredential = new UserGoogleOAuthCredential
						{
							UserId = credential.UserId,
							GoogleId = credential.GoogleId,
							AccessToken = credential.AccessToken,
							RefreshToken = credential.RefreshToken,
							AccessTokenExpiryTime = credential.AccessTokenExpiryTime,
							IdToken = credential.IdToken,
							Scope = credential.Scope,
							TokenType = credential.TokenType,
							AuthenticationProvider = "Google",
							ModifiedOn = DateTime.Now,
							IsActive = true,
							CreatedOn = DateTime.Now,
							//LastLoginOn = DateTime.Now
						};
						db.UserGoogleOAuthCredentials.Add(newCredential);
					}
					db.SaveChangesAsync();
					_retVal = true;
				}
			}
			catch (Exception ex)
			{
				//Logger.Error(ex, string.Format("Error updating Google OAuth credentials for UserId: {0}", userId));
				return false;
			}
			return _retVal;

		}

		public bool StoreGoogleOAuthCredentials(long userId, GoogleUserInfoModel googleUserInfo, GoogleTokenResponseModel tokenResponse)
		{
			try
			{
				//Logger.Info(string.Format("Storing Google OAuth credentials for UserId: {0}, GoogleId: {1}", userId, googleUserInfo.id));
				var db = SecurityDbContext.CreateInstance();
                db.UserGoogleOAuthCredentials.Add(new UserGoogleOAuthCredential
                {
                    UserId = userId,
                    GoogleId = googleUserInfo.id,
                    AccessToken = tokenResponse.access_token,
                    RefreshToken = tokenResponse.refresh_token,
                    AccessTokenExpiryTime = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in),
                    IdToken = tokenResponse.id_token,
                    Scope = tokenResponse.scope,
                    TokenType = tokenResponse.token_type,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    AuthenticationProvider = "Google"
                });
                var id = db.SaveChanges();
				return id > 0;
			}
			catch (Exception ex)
			{
				//Logger.Error(ex, string.Format("Error storing Google OAuth credentials for UserId: {0}", userId));
				return false;
			}
		}
		#endregion
	}

	public class ApplicationSignInManager : SignInManager<ApplicationUser, long>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleStore : RoleStore<ApplicationRole, long, ApplicationUserRole>
    {
        public ApplicationRoleStore(SecurityDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationRoleManager : RoleManager<ApplicationRole, long>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, long> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole, long, ApplicationUserRole>(context.Get<SecurityDbContext>()));
        }

        public static List<ApplicationRole> GetRoles()
        {
            List<ApplicationRole> _retVal = null;
            try
            {
                using (RoleStore<ApplicationRole, long, ApplicationUserRole> db = new RoleStore<ApplicationRole, long, ApplicationUserRole>(SecurityDbContext.CreateInstance()))
                {
                    _retVal = db.Roles.Include("PERMISSIONS").ToList();
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static ApplicationRole GetRole(long _roleId)
        {
            ApplicationRole _retVal = null;
            try
            {
                using (RoleStore<ApplicationRole, long, ApplicationUserRole> db = new RoleStore<ApplicationRole, long, ApplicationUserRole>(SecurityDbContext.CreateInstance()))
                {
                    _retVal = db.Roles.Where(p => p.Id == _roleId).Include("PERMISSIONS").FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool CreateRole(ApplicationRole _role)
        {
            bool _retVal = false;
            try
            {
                var roleManager = new RoleManager<ApplicationRole, long>(new RoleStore<ApplicationRole, long, ApplicationUserRole>(SecurityDbContext.CreateInstance()));
                if (!roleManager.RoleExists(_role.Name))
                {
                    //_role.Id = Guid.NewGuid().ToString();
                    _role.LastModified = DateTime.Now;
                    roleManager.Create(_role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retVal;
        }

        public static bool AddPermission2Role(long _roleId, long _permissionId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationRole role = db.Roles.Where(p => p.Id == _roleId).Include("PERMISSIONS").FirstOrDefault();
                    if (role != null)
                    {
                        PERMISSION _permission = db.PERMISSIONS.Where(p => p.PermissionId == _permissionId).Include("ROLES").FirstOrDefault();
                        if (!role.PERMISSIONS.Contains(_permission))
                        {
                            role.PERMISSIONS.Add(_permission);
                            role.LastModified = DateTime.Now;
                            db.Entry(role).State = EntityState.Modified;
                            db.SaveChanges();
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

        public static bool AddAllPermissions2Role(long _roleId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationRole role = db.Roles.Where(p => p.Id == _roleId).Include("PERMISSIONS").FirstOrDefault();
                    if (role != null)
                    {
                        List<PERMISSION> _permissions = db.PERMISSIONS.Include("ROLES").ToList();
                        foreach (PERMISSION _permission in _permissions)
                        {
                            if (!role.PERMISSIONS.Contains(_permission))
                            {
                                role.PERMISSIONS.Add(_permission);
                            }
                        }
                        role.LastModified = DateTime.Now;
                        db.Entry(role).State = EntityState.Modified;
                        db.SaveChanges();
                        _retVal = true;
                    }
                }
            }
            catch
            {
            }
            return _retVal;
        }

        public static bool UpdateRole(RoleViewModel _modifiedRole)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationRole _role2Modify = db.Roles.Where(p => p.Id == _modifiedRole.Id).Include("PERMISSIONS").FirstOrDefault();

                    db.Entry(_role2Modify).Entity.Name = _modifiedRole.Name;
                    db.Entry(_role2Modify).Entity.RoleDescription = _modifiedRole.RoleDescription;
                    db.Entry(_role2Modify).Entity.IsSysAdmin = _modifiedRole.IsSysAdmin;
                    db.Entry(_role2Modify).Entity.LastModified = System.DateTime.Now;
                    db.Entry(_role2Modify).State = EntityState.Modified;
                    db.SaveChanges();

                    _retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool DeleteRole(long _roleId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationRole _role2Delete = db.Roles.Where(p => p.Id == _roleId).Include("PERMISSIONS").FirstOrDefault();
                    if (_role2Delete != null)
                    {
                        _role2Delete.PERMISSIONS.Clear();
                        db.Entry(_role2Delete).State = EntityState.Deleted;
                        db.SaveChanges();
                        _retVal = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool RemovePermission4Role(long _roleId, long _permissionId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    ApplicationRole _role2Modify = db.Roles.Where(p => p.Id == _roleId).Include("PERMISSIONS").FirstOrDefault();
                    PERMISSION _permission = db.PERMISSIONS.Where(p => p.PermissionId == _permissionId).Include("ROLES").FirstOrDefault();

                    if (_role2Modify.PERMISSIONS.Contains(_permission))
                    {
                        _role2Modify.PERMISSIONS.Remove(_permission);
                        _role2Modify.LastModified = DateTime.Now;
                        db.Entry(_role2Modify).State = EntityState.Modified;
                        db.SaveChanges();

                        _retVal = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static List<ApplicationRole> GetRoles4SelectList()
        {
            List<ApplicationRole> _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.Roles.OrderBy(p => p.Name).ToList();
                }
            }
            catch (Exception)
            {
            }

            return _retVal;
        }

        public static List<PERMISSION> GetPermissions4SelectList()
        {
            List<PERMISSION> _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.PERMISSIONS.OrderBy(p => p.PermissionDescription).ToList();
                }
            }
            catch (Exception)
            {
            }

            return _retVal;
        }

        #region Worker functions for Permissions
        public static List<PERMISSION> GetPermissions()
        {
            List<PERMISSION> _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.PERMISSIONS.OrderBy(p => p.PermissionDescription).Include("ROLES").ToList();
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static PERMISSION GetPermission(long _permissionId)
        {
            PERMISSION _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.PERMISSIONS.Where(p => p.PermissionId == _permissionId).Include("ROLES").FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        /*public static PERMISSION GetPermission4Description(string _permDescription)
        {
            PERMISSION _retVal = null;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    _retVal = db.PERMISSIONS.Where(p => p.PermissionDescription == _permDescription).Include("ROLES").FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }*/


        public static bool AddPermission(PERMISSION _newPermission)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    db.PERMISSIONS.Add(_newPermission);
                    db.Entry(_newPermission).State = EntityState.Added;
                    db.SaveChanges();
                    _retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool UpdatePermission(PERMISSION _permission)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    db.Entry(_permission).State = EntityState.Modified;
                    db.SaveChanges();
                    _retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool DeletePermission(long _permissionId)
        {
            bool _retVal = false;
            try
            {
                using (SecurityDbContext db = SecurityDbContext.CreateInstance())
                {
                    PERMISSION _permission = db.PERMISSIONS.Where(p => p.PermissionId == _permissionId).Include("ROLES").FirstOrDefault();

                    _permission.ROLES.Clear();
                    db.Entry(_permission).State = EntityState.Deleted;
                    db.SaveChanges();
                    _retVal = true;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
        #endregion
    }



    //** Security ****
}