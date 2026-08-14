using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Newtonsoft.Json;

using NLog;

using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Common;
using OMSCloud.Services.WebAPIs.Models;

using RestSharp;

using System;
using System.Configuration;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    /// <summary>
    /// Controller to handle Google OAuth 2.0 authentication flows
    /// Supports signup, signin, and refresh token operations
    /// Works seamlessly with existing identity framework and database
    /// </summary>
    [RoutePrefix("api/GoogleOAuth")]
    public class GoogleOAuthController : ApiController
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private GoogleOAuthService _googleOAuthService;

        private GoogleOAuthService GoogleOAuthService
        {
            get
            {
                if (_googleOAuthService == null)
                {
                    var config = new GoogleOAuthConfiguration
                    {
                        ClientId = ConfigurationManager.AppSettings["GoogleOAuth_ClientId"],
                        ClientSecret = ConfigurationManager.AppSettings["GoogleOAuth_ClientSecret"],
                        RedirectUri = ConfigurationManager.AppSettings["GoogleOAuth_RedirectUri"],
                        TokenEndpoint = "https://oauth2.googleapis.com/token",
                        UserInfoEndpoint = "https://www.googleapis.com/oauth2/v1/userinfo"
                    };
                    _googleOAuthService = new GoogleOAuthService(config);
                }
                return _googleOAuthService;
            }
        }

        /// <summary>
        /// Google OAuth Signup/Registration Endpoint
        /// Accepts authorization code and creates or links Google account to existing user
        /// </summary>
        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        [ResponseType(typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> GoogleSignUp([FromBody] GoogleOAuthSignupRequestModel model)
        {
            Logger.Info("=== Google OAuth Signup Started ===");
            var response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.IsActionRequired = false;

            try
			{
				if (model == null || string.IsNullOrEmpty(model.Code))
				{
					response.StatusMessage = "Invalid request. Authorization code is required.";
					Logger.Warn("Invalid signup request: missing authorization code");
					return Ok(response);
				}

				// Step 1: Exchange authorization code for tokens and user info
				Logger.Info("Exchanging authorization code for tokens");
				var exchangeOutput = await GoogleOAuthService.ExchangeCodeForTokenAsync(
					model.Code,
					model.RedirectUri
				);

				if (!exchangeOutput.IsSuccessful || exchangeOutput.TokenResponse == null || exchangeOutput.UserInfo == null)
				{
					response.StatusMessage = "Failed to authenticate with Google. Please try again.";
					Logger.Error("Failed to exchange code for token or get user info");
					return Ok(response);
				}

				// Step 2: Check if user already exists
				var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
				var user = userMgr.FindByEmail(exchangeOutput.UserInfo.email);

				if (user == null)
				{
					user = await CreateUserFromGoogleOAuth(exchangeOutput, userMgr);
					if (user == null)
					{
						response.StatusMessage = "Failed to create user account. ";// + string.Join(", ", result.Errors);
						Logger.Error(string.Format("Failed to create user: {0}"));//, string.Join(", ", result.Errors)));
						return Ok(response);
					}
					Logger.Info(string.Format("User created successfully. UserId: {0}", user.Id));
				}

				// User exists, link Google OAuth account
				Logger.Info(string.Format("Linking Google OAuth account."));
				response = await LinkGoogleOAuthAccount(
                    user, 
                    userMgr, 
                    exchangeOutput, 
                    model);

				/*
				// Step 4: Store Google OAuth credentials
				if (!userMgr.StoreGoogleOAuthCredentials(user.Id, exchangeOutput.UserInfo, exchangeOutput.TokenResponse))
				{
					response.StatusMessage = "Account created but failed to store OAuth credentials.";
					Logger.Warn(string.Format("Failed to store OAuth credentials for UserId: {0}", user.Id));
				}

				// Step 5: Add authentication provider claim
				await AddAuthenticationProviderClaim(userMgr, user.Id, AuthenticationMetadata.GoogleOAuthProvider);
                
				// Step 6: Set up user profile
				SetupProfileForGoogleUser(user, exchangeOutput.UserInfo);

				// Step 7: Add default role
				ApplicationUserManager.AddUser2Role(user.Id, 3);

				// Step 8: Generate authentication response with token
				response.StatusCode = SecurityStatus.Success;
				response.StatusMessage = "Google account registered successfully. You can now login.";
				response.IsActionRequired = false;

				response.TokenResponse = SetToken(exchangeOutput.TokenResponse);

				// Set device token if provided
				if (model.NotificationTokenJson != null)
				{
					try
					{
						var notificationToken = JsonConvert.DeserializeObject<NotificationTokenModel>(model.NotificationTokenJson);
						if (notificationToken != null)
						{
							SetDeviceToken(notificationToken, user.Id);
						}
					}
					catch (Exception ex)
					{
						Logger.Warn(ex, "Failed to set device token during signup");
					}
				}
                */

                if(response.StatusCode != SecurityStatus.Success)
                {
                    Logger.Warn(string.Format("Google OAuth signup completed with warnings for UserId: {0}. StatusMessage: {1}", user.Id, response.StatusMessage));
                }
                else
                {
                    Logger.Info(string.Format("Google OAuth signup completed successfully for UserId: {0}", user.Id));
				}
				return Ok(response);
			}
			catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = "An error occurred during signup. Please try again.";
                response.IsActionRequired = false;
                Logger.Error(ex, "Exception in GoogleSignup");
                return Ok(response);
            }
        }

		/// <summary>
		/// Google OAuth Sign-In Endpoint
		/// Accepts authorization code and logs in the user
		/// </summary>
		[HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        [ResponseType(typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> GoogleSignIn([FromBody] GoogleOAuthSignupRequestModel model)
        {
            Logger.Info("=== Google OAuth Signin Started ===");
            var response = new AccountResponseModel();
            response.StatusCode = SecurityStatus.Failure;
            response.IsActionRequired = false;

            try
            {
                if (model == null || string.IsNullOrEmpty(model.Code))
                {
                    response.StatusMessage = "Invalid request. Authorization code is required.";
                    Logger.Warn("Invalid signin request: missing authorization code");
                    return Ok(response);
                }

                // Step 1: Exchange authorization code for tokens and user info
                Logger.Info("Exchanging authorization code for tokens");
                var exchangeOutput = await GoogleOAuthService.ExchangeCodeForTokenAsync(
                    model.Code,
                    model.RedirectUri
                );

                if (!exchangeOutput.IsSuccessful || exchangeOutput.TokenResponse == null || exchangeOutput.UserInfo == null)
                {
                    response.StatusMessage = "Failed to authenticate with Google. Please try again.";
                    Logger.Error("Failed to exchange code for token or get user info");
                    return Ok(response);
                }

                // Step 2: Find user by email
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userMgr.FindByEmail(exchangeOutput.UserInfo.email);

                if (user == null)
                {
                    response.StatusMessage = "No account found with this Google email. Please sign up first.";
                    Logger.Warn(string.Format("No user found for Google email: {0}", exchangeOutput.UserInfo.email));
                    return Ok(response);
                }

                if (user.Inactive)
                {
                    response.StatusMessage = "Your account has been deactivated.";
                    Logger.Warn(string.Format("Inactive user attempting to sign in: {0}", user.Email));
                    return Ok(response);
                }

                // Step 3: Update Google OAuth credentials
                Logger.Info(string.Format("Updating Google OAuth credentials for UserId: {0}", user.Id));
                userMgr.UpdateGoogleOAuthCredentials(user.Id, exchangeOutput.UserInfo, exchangeOutput.TokenResponse);

                // Step 4: Add authentication provider claim if not exists
                await AddAuthenticationProviderClaim(userMgr, user.Id, AuthenticationMetadata.GoogleOAuthProvider);

                // Step 5: Generate authentication response
                response.StatusCode =   SecurityStatus.Success;
                response.StatusMessage = "Login successful.";
                response.IsActionRequired = false;

                // Get access token
                response.TokenResponse = GetTokenForGoogleUser(exchangeOutput.TokenResponse);

                // Set device token if provided
                if (model.NotificationTokenJson != null)
                {
                    try
                    {
                        var notificationToken = JsonConvert.DeserializeObject<NotificationTokenModel>(model.NotificationTokenJson);
                        if (notificationToken != null)
                        {
                            SetDeviceToken(notificationToken, user.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warn(ex, "Failed to set device token during signin");
                    }
                }

                Logger.Info(string.Format("=== Google OAuth Signin Completed Successfully for UserId: {0} ===", user.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = SecurityStatus.Failure;
                response.StatusMessage = "An error occurred during signin. Please try again.";
                response.IsActionRequired = false;
                Logger.Error(ex, "Exception in GoogleSignin");
                return Ok(response);
            }
        }

        /// <summary>
        /// Refresh Google OAuth Access Token
        /// Uses stored refresh token to obtain new access token
        /// </summary>
        [HttpPost]
        [Route("refresh-token")]
        [Authorize]
        [ResponseType(typeof(TokenResponseModel))]
        public async Task<IHttpActionResult> RefreshGoogleToken()
        {
            Logger.Info("=== Google OAuth Refresh Token Started ===");
            var response = new TokenResponseModel();

            try
            {
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = userMgr.FindByEmail(User.Identity.Name);

                if (currentUser == null)
                {
                    Logger.Warn(string.Format("Current user not found: {0}", User.Identity.Name));
                    return BadRequest("User not found");
                }

				// Step 1: Retrieve stored Google OAuth credentials
				
				var googleCredentials = userMgr.GetStoredGoogleCredentials(currentUser.Id);

				if (googleCredentials == null || string.IsNullOrEmpty(googleCredentials.RefreshToken))
                {
                    Logger.Warn(string.Format("No Google OAuth credentials found for UserId: {0}", currentUser.Id));
                    return BadRequest("No Google OAuth credentials found for this account");
                }

                // Step 2: Refresh the access token
                Logger.Info(string.Format("Refreshing Google access token for UserId: {0}", currentUser.Id));
                var newTokenResponse = await GoogleOAuthService.RefreshAccessTokenAsync(googleCredentials.RefreshToken);

                if (newTokenResponse == null)
                {
                    Logger.Error(string.Format("Failed to refresh access token for UserId: {0}", currentUser.Id));
                    return BadRequest("Failed to refresh Google access token");
                }
				// Step 3: Update stored credentials
				googleCredentials.AccessToken = newTokenResponse.access_token;
                googleCredentials.AccessTokenExpiryTime = DateTime.UtcNow.AddSeconds(newTokenResponse.expires_in);
                googleCredentials.ModifiedOn = DateTime.Now;

				userMgr.UpdateGoogleCredentialsInDatabase(googleCredentials);

				// Step 4: Return new access token
				response.access_token = newTokenResponse.access_token;
                response.refresh_token = newTokenResponse.refresh_token ?? googleCredentials.RefreshToken;
                response.token_type = newTokenResponse.token_type;
                response.expires_in = newTokenResponse.expires_in / 60;
                response.expiredTime = googleCredentials.AccessTokenExpiryTime;

                Logger.Info(string.Format("=== Google OAuth Refresh Token Completed Successfully for UserId: {0} ===", currentUser.Id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception in RefreshGoogleToken");
                return InternalServerError(ex);
            }
        }

        #region Helper Methods

        /// <summary>
        /// Links Google OAuth account to existing user
        /// </summary>
        private async Task<AccountResponseModel> LinkGoogleOAuthAccount(
            ApplicationUser user,
			ApplicationUserManager userMgr,
			GoogleCodeExchangeOutput exchangeOutput,
            GoogleOAuthSignupRequestModel model
            )
        {
            Logger.Info(string.Format("Linking Google OAuth account to existing UserId: {0}", user.Id));

			var response = new AccountResponseModel();

            response.StatusCode = SecurityStatus.Failure;
            response.IsActionRequired = false;
			// Store or update Google OAuth credentials
			if (!userMgr.StoreGoogleOAuthCredentials(user.Id, exchangeOutput.UserInfo, exchangeOutput.TokenResponse))
            {
                response.StatusMessage = "Failed to link Google account.";
                Logger.Error(string.Format("Failed to store OAuth credentials for existing user: {0}", user.Id));
                return response;
            }

            // Add authentication provider claim if not exists
            await AddAuthenticationProviderClaim(userMgr, user.Id, AuthenticationMetadata.GoogleOAuthProvider);

			// Step 6: Set up user profile
			SetupProfileForGoogleUser(user, exchangeOutput.UserInfo);

			// Step 7: Add default role
			ApplicationUserManager.AddUser2Role(user.Id, 3);

			response.StatusCode = SecurityStatus.Success;
            response.StatusMessage = "Google account linked successfully.";
            response.IsActionRequired = false;

			response.TokenResponse = GetTokenForGoogleUser(exchangeOutput.TokenResponse);

			if (model.NotificationTokenJson != null)
            {
                try
                {
                    var notificationToken = JsonConvert.DeserializeObject<NotificationTokenModel>(model.NotificationTokenJson);
                    if (notificationToken != null)
                    {
                        SetDeviceToken(notificationToken, user.Id);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex, "Failed to set device token during link");
                }
            }

            return response;
        }

        /// <summary>
        /// Adds authentication provider claim to user identity
        /// Allows identification of whether user authenticated via Google OAuth or default auth
        /// </summary>
        private async Task AddAuthenticationProviderClaim(ApplicationUserManager userMgr, long userId, string provider)
        {
            try
            {
                Logger.Info(string.Format("Adding authentication provider claim for UserId: {0}, Provider: {1}", userId, provider));

                var existingUser = await userMgr.FindByIdAsync(userId);
                if (existingUser != null)
                {
                    var claims = await userMgr.GetClaimsAsync(userId);

                    // Check if claim already exists
                    Claim providerClaim = null;
                    foreach (var claim in claims)
                    {
                        if (claim.Type == AuthenticationMetadata.ClaimType)
                        {
                            providerClaim = claim;
                            break;
                        }
                    }

                    if (providerClaim == null)
                    {
                        await userMgr.AddClaimAsync(userId, new Claim(AuthenticationMetadata.ClaimType, provider));
                    }
                }

                Logger.Info(string.Format("Authentication provider claim added for UserId: {0}", userId));
            }
            catch (Exception ex)
            {
                Logger.Warn(ex, string.Format("Failed to add authentication provider claim for UserId: {0}", userId));
            }
        }

        /// <summary>
        /// Sets up user profile for new Google OAuth user
        /// </summary>
        private void SetupProfileForGoogleUser(ApplicationUser user, GoogleUserInfoModel googleUserInfo)
        {
            try
            {
                Logger.Info(string.Format("Setting up profile for new Google user: {0}", user.Id));

                var profileComponent = new ProfileBusinessComponent();
                var profile = new ProfileModel
                {
                    UserID = user.Id,
                    UserName = user.Email,
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    IsVerified = googleUserInfo.verified_email == "true",
                    UserTypeID = (long)DBUserTypeEnum.Buyer,
                    CreatedOn = DateTime.Now
                };

                var profileId = profileComponent.AddProfile(profile);
                Logger.Info(string.Format("Profile created for user: {0}, ProfileId: {1}", user.Id, profileId));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, string.Format("Error setting up profile for user: {0}", user.Id));
            }
        }
		
        private static TokenResponseModel GetTokenForGoogleUser(GoogleTokenResponseModel googleTokenResponse)
		{
			// Get access token
			TokenResponseModel tokenResponse = new TokenResponseModel();
			tokenResponse.access_token = googleTokenResponse.access_token;
			tokenResponse.refresh_token = googleTokenResponse.refresh_token;
			tokenResponse.token_type = googleTokenResponse.token_type;
			tokenResponse.expires_in = googleTokenResponse.expires_in;
			tokenResponse.expiredTime = DateTime.UtcNow.AddMinutes(googleTokenResponse.expires_in);
			//tokenResponse.id_token = googleTokenResponse.id_token;
			//tokenResponse.scope = tokenResponse.scope;
			return tokenResponse;
		}

		private static async Task<ApplicationUser> CreateUserFromGoogleOAuth(GoogleCodeExchangeOutput exchangeOutput, ApplicationUserManager userMgr)
		{
			// Step 3: Create new user with Google information
			Logger.Info(string.Format("Creating new user from Google OAuth. Email: {0}", exchangeOutput.UserInfo.email));
			var newUser = new ApplicationUser
			{
				UserName = exchangeOutput.UserInfo.email,
				Email = exchangeOutput.UserInfo.email,
				Firstname = exchangeOutput.UserInfo.given_name ?? exchangeOutput.UserInfo.name ?? "Google",
				Lastname = exchangeOutput.UserInfo.family_name ?? "User",
				EmailConfirmed = exchangeOutput.UserInfo.verified_email == "true",
				Inactive = false,
				LastModified = DateTime.Now,
                TwoFactorEnabled = false,
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = true,
                
			};

			// Generate a random password for Google OAuth users
			var randomPassword = Membership.GeneratePassword(16, 4);

			var result = await userMgr.CreateAsync(newUser, randomPassword);
			newUser = result.Succeeded ? newUser : null;
			return (newUser);
		}

		/// <summary>
		/// Gets authentication token for Google OAuth user
		/// </summary>
		private TokenResponseModel GetTokenForGoogleUser1(string email, string password, long userId)
        {
            try
            {
                Logger.Info(string.Format("Generating auth token for Google user: {0}", email));

                var tokenResponseModel = new TokenResponseModel();
                var tokenRequestModel = new TokenRequestModel(email, password);

                Uri baseUri = new Uri(Request.RequestUri, RequestContext.VirtualPathRoot);
                var client = new RestClient(baseUri.ToString() + "/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");

                string data = string.Format("UserName={0}&password={1}&grant_type={2}", email, password, tokenRequestModel.grant_type);
                request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    tokenResponseModel = JsonConvert.DeserializeObject<TokenResponseModel>(response.Content);
                    tokenResponseModel.expires_in = 30;
                    tokenResponseModel.expiredTime = DateTime.UtcNow.AddMinutes(tokenResponseModel.expires_in);

                    Logger.Info(string.Format("Auth token generated successfully for user: {0}", email));
                    return tokenResponseModel;
                }

                Logger.Warn(string.Format("Failed to generate token for user: {0}", email));
                return tokenResponseModel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, string.Format("Error generating auth token for user: {0}", email));
                return new TokenResponseModel();
            }
        }

        /// <summary>
        /// Sets device notification token for user
        /// </summary>
        private void SetDeviceToken(NotificationTokenModel model, long userId)
        {
            try
            {
                Logger.Info(string.Format("Setting device token for UserId: {0}", userId));

                var profileComponent = new ProfileBusinessComponent();
                var profile = profileComponent.GetProfileByUserId(userId);

                if (profile != null)
                {
                    model.ProfileId = profile.ProfileID;
                    var ntbc = new NotificationTokenBusinessComponent();
                    var dbToken = ntbc.GetByNotificationToken(model);

                    if (dbToken == null)
                    {
                        model.StatusId = (int)DBStatusEnum.Active;
                        ntbc.AddNotificationToken(model);
                    }
                    else if (dbToken.StatusId != (int)DBStatusEnum.Active)
                    {
                        dbToken.StatusId = (int)DBStatusEnum.Active;
                        ntbc.UpdateNotificationToken(dbToken);
                    }

                    Logger.Info(string.Format("Device token set for UserId: {0}", userId));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, string.Format("Error setting device token for UserId: {0}", userId));
            }
        }

        #endregion
    }
}
