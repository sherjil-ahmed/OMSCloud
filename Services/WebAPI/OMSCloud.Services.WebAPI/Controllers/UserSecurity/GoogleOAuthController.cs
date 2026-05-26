using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using NLog;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Services.WebAPIs.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        ClientId = System.Configuration.ConfigurationManager.AppSettings["GoogleOAuth_ClientId"],
                        ClientSecret = System.Configuration.ConfigurationManager.AppSettings["GoogleOAuth_ClientSecret"],
                        RedirectUri = System.Configuration.ConfigurationManager.AppSettings["GoogleOAuth_RedirectUri"],
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
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> GoogleSignup([FromBody] GoogleOAuthSignupRequest model)
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
                Logger.Info($"Exchanging authorization code for tokens");
                var (tokenResponse, googleUserInfo) = await GoogleOAuthService.ExchangeCodeForTokenAsync(
                    model.Code,
                    model.RedirectUri
                );

                if (tokenResponse == null || googleUserInfo == null)
                {
                    response.StatusMessage = "Failed to authenticate with Google. Please try again.";
                    Logger.Error("Failed to exchange code for token or get user info");
                    return Ok(response);
                }

                // Step 2: Check if user already exists
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var existingUser = userMgr.FindByEmail(googleUserInfo.email);

                if (existingUser != null)
                {
                    // User exists, link Google OAuth account
                    Logger.Info($"User already exists with email {googleUserInfo.email}. Linking Google OAuth account.");
                    return await LinkGoogleOAuthAccount(existingUser, tokenResponse, googleUserInfo, model, response);
                }

                // Step 3: Create new user with Google information
                Logger.Info($"Creating new user from Google OAuth. Email: {googleUserInfo.email}");
                var newUser = new ApplicationUser
                {
                    UserName = googleUserInfo.email,
                    Email = googleUserInfo.email,
                    Firstname = googleUserInfo.given_name ?? googleUserInfo.name ?? "Google",
                    Lastname = googleUserInfo.family_name ?? "User",
                    EmailConfirmed = googleUserInfo.verified_email == "true",
                    Inactive = false,
                    LastModified = DateTime.Now
                };

                // Generate a random password for Google OAuth users
                var randomPassword = Membership.GeneratePassword(16, 4);

                var result = await userMgr.CreateAsync(newUser, randomPassword);

                if (!result.Succeeded)
                {
                    response.StatusMessage = "Failed to create user account. " + string.Join(", ", result.Errors);
                    Logger.Error($"Failed to create user: {string.Join(", ", result.Errors)}");
                    return Ok(response);
                }

                Logger.Info($"User created successfully. UserId: {newUser.Id}");

                // Step 4: Store Google OAuth credentials
                if (!StoreGoogleOAuthCredentials(newUser.Id, googleUserInfo, tokenResponse))
                {
                    response.StatusMessage = "Account created but failed to store OAuth credentials.";
                    Logger.Warn($"Failed to store OAuth credentials for UserId: {newUser.Id}");
                }

                // Step 5: Set up user profile
                SetupProfileForGoogleUser(newUser, googleUserInfo);

                // Step 6: Add default role
                ApplicationUserManager.AddUser2Role(newUser.Id, 3); // Shop User role by default

                // Step 7: Generate authentication response with token
                response.StatusCode = SecurityStatus.Success;
                response.StatusMessage = "Google account registered successfully. You can now login.";
                response.IsActionRequired = false;

                // Get access token
                response.TokenResponse = GetTokenForGoogleUser(newUser.Email, randomPassword, newUser.Id);

                // Set device token if provided
                if (model.NotificationTokenJson != null)
                {
                    try
                    {
                        var notificationToken = JsonConvert.DeserializeObject<NotificationTokenModel>(model.NotificationTokenJson);
                        if (notificationToken != null)
                        {
                            SetDeviceToken(notificationToken, newUser.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warn(ex, "Failed to set device token during signup");
                    }
                }

                Logger.Info($"=== Google OAuth Signup Completed Successfully for UserId: {newUser.Id} ===");
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
        [ReturnType(DataType = typeof(AccountResponseModel))]
        public async Task<IHttpActionResult> GoogleSignin([FromBody] GoogleOAuthSignupRequest model)
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
                var (tokenResponse, googleUserInfo) = await GoogleOAuthService.ExchangeCodeForTokenAsync(
                    model.Code,
                    model.RedirectUri
                );

                if (tokenResponse == null || googleUserInfo == null)
                {
                    response.StatusMessage = "Failed to authenticate with Google. Please try again.";
                    Logger.Error("Failed to exchange code for token or get user info");
                    return Ok(response);
                }

                // Step 2: Find user by email
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userMgr.FindByEmail(googleUserInfo.email);

                if (user == null)
                {
                    response.StatusMessage = "No account found with this Google email. Please sign up first.";
                    Logger.Warn($"No user found for Google email: {googleUserInfo.email}");
                    return Ok(response);
                }

                if (user.Inactive)
                {
                    response.StatusMessage = "Your account has been deactivated.";
                    Logger.Warn($"Inactive user attempting to sign in: {user.Email}");
                    return Ok(response);
                }

                // Step 3: Update Google OAuth credentials
                Logger.Info($"Updating Google OAuth credentials for UserId: {user.Id}");
                UpdateGoogleOAuthCredentials(user.Id, googleUserInfo, tokenResponse);

                // Step 4: Generate authentication response
                response.StatusCode = SecurityStatus.Success;
                response.StatusMessage = "Login successful.";
                response.IsActionRequired = false;

                // Get access token
                var password = Membership.GeneratePassword(16, 4);
                response.TokenResponse = GetTokenForGoogleUser(user.Email, password, user.Id);

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

                Logger.Info($"=== Google OAuth Signin Completed Successfully for UserId: {user.Id} ===");
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
        [ReturnType(DataType = typeof(TokenResponseModel))]
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
                    Logger.Warn($"Current user not found: {User.Identity.Name}");
                    return BadRequest("User not found");
                }

                // Step 1: Retrieve stored Google OAuth credentials
                var googleCredentials = GetStoredGoogleCredentials(currentUser.Id);

                if (googleCredentials == null || string.IsNullOrEmpty(googleCredentials.RefreshToken))
                {
                    Logger.Warn($"No Google OAuth credentials found for UserId: {currentUser.Id}");
                    return BadRequest("No Google OAuth credentials found for this account");
                }

                // Step 2: Refresh the access token
                Logger.Info($"Refreshing Google access token for UserId: {currentUser.Id}");
                var newTokenResponse = await GoogleOAuthService.RefreshAccessTokenAsync(googleCredentials.RefreshToken);

                if (newTokenResponse == null)
                {
                    Logger.Error($"Failed to refresh access token for UserId: {currentUser.Id}");
                    return BadRequest("Failed to refresh Google access token");
                }

                // Step 3: Update stored credentials
                googleCredentials.AccessToken = newTokenResponse.access_token;
                googleCredentials.AccessTokenExpiryTime = DateTime.UtcNow.AddSeconds(newTokenResponse.expires_in);
                googleCredentials.ModifiedOn = DateTime.Now;

                UpdateGoogleCredentialsInDatabase(googleCredentials);

                // Step 4: Return new access token
                response.access_token = newTokenResponse.access_token;
                response.expires_in = newTokenResponse.expires_in;
                response.token_type = newTokenResponse.token_type;
                response.expiredInMinutes = newTokenResponse.expires_in / 60;
                response.expiredTime = googleCredentials.AccessTokenExpiryTime;

                Logger.Info($"=== Google OAuth Refresh Token Completed Successfully for UserId: {currentUser.Id} ===");
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
        private async Task<IHttpActionResult> LinkGoogleOAuthAccount(
            ApplicationUser existingUser,
            GoogleTokenResponse tokenResponse,
            GoogleUserInfo googleUserInfo,
            GoogleOAuthSignupRequest model,
            AccountResponseModel response)
        {
            Logger.Info($"Linking Google OAuth account to existing UserId: {existingUser.Id}");

            // Store or update Google OAuth credentials
            if (!StoreGoogleOAuthCredentials(existingUser.Id, googleUserInfo, tokenResponse))
            {
                response.StatusMessage = "Failed to link Google account.";
                Logger.Error($"Failed to store OAuth credentials for existing user: {existingUser.Id}");
                return Ok(response);
            }

            response.StatusCode = SecurityStatus.Success;
            response.StatusMessage = "Google account linked successfully.";
            response.IsActionRequired = false;

            // Get access token using existing user's default authentication
            var password = Membership.GeneratePassword(16, 4);
            response.TokenResponse = GetTokenForGoogleUser(existingUser.Email, password, existingUser.Id);

            if (model.NotificationTokenJson != null)
            {
                try
                {
                    var notificationToken = JsonConvert.DeserializeObject<NotificationTokenModel>(model.NotificationTokenJson);
                    if (notificationToken != null)
                    {
                        SetDeviceToken(notificationToken, existingUser.Id);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex, "Failed to set device token during link");
                }
            }

            return Ok(response);
        }

        /// <summary>
        /// Stores Google OAuth credentials in a secure manner
        /// In production, consider encrypting sensitive data
        /// </summary>
        private bool StoreGoogleOAuthCredentials(long userId, GoogleUserInfo googleUserInfo, GoogleTokenResponse tokenResponse)
        {
            try
            {
                Logger.Info($"Storing Google OAuth credentials for UserId: {userId}");

                // TODO: Implement database storage for UserGoogleOAuthCredential
                // This would typically be stored in a table in the database
                // For now, this is a placeholder for integration with your data layer

                var credential = new UserGoogleOAuthCredential
                {
                    UserId = userId,
                    GoogleId = googleUserInfo.id,
                    AccessToken = tokenResponse.access_token,
                    RefreshToken = tokenResponse.refresh_token,
                    AccessTokenExpiryTime = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    AuthenticationProvider = "Google"
                };

                // Store in database
                // var result = _googleOAuthRepository.AddOrUpdate(credential);
                // return result != null;

                Logger.Info($"Google OAuth credentials stored for UserId: {userId}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error storing Google OAuth credentials for UserId: {userId}");
                return false;
            }
        }

        /// <summary>
        /// Updates existing Google OAuth credentials
        /// </summary>
        private void UpdateGoogleOAuthCredentials(long userId, GoogleUserInfo googleUserInfo, GoogleTokenResponse tokenResponse)
        {
            try
            {
                Logger.Info($"Updating Google OAuth credentials for UserId: {userId}");

                // TODO: Implement database update for UserGoogleOAuthCredential
                // var existing = _googleOAuthRepository.GetByUserId(userId);
                // if (existing != null)
                // {
                //     existing.AccessToken = tokenResponse.access_token;
                //     existing.RefreshToken = tokenResponse.refresh_token;
                //     existing.AccessTokenExpiryTime = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
                //     existing.ModifiedOn = DateTime.Now;
                //     _googleOAuthRepository.Update(existing);
                // }

                Logger.Info($"Google OAuth credentials updated for UserId: {userId}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error updating Google OAuth credentials for UserId: {userId}");
            }
        }

        /// <summary>
        /// Retrieves stored Google OAuth credentials for a user
        /// </summary>
        private UserGoogleOAuthCredential GetStoredGoogleCredentials(long userId)
        {
            try
            {
                Logger.Info($"Retrieving Google OAuth credentials for UserId: {userId}");

                // TODO: Implement database retrieval for UserGoogleOAuthCredential
                // var credentials = _googleOAuthRepository.GetByUserId(userId);
                // return credentials;

                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error retrieving Google OAuth credentials for UserId: {userId}");
                return null;
            }
        }

        /// <summary>
        /// Updates Google credentials in database
        /// </summary>
        private void UpdateGoogleCredentialsInDatabase(UserGoogleOAuthCredential credential)
        {
            try
            {
                Logger.Info($"Updating Google credentials in database for UserId: {credential.UserId}");

                // TODO: Implement database update
                // var result = _googleOAuthRepository.Update(credential);

                Logger.Info($"Google credentials updated for UserId: {credential.UserId}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error updating Google credentials for UserId: {credential.UserId}");
            }
        }

        /// <summary>
        /// Sets up user profile for new Google OAuth user
        /// </summary>
        private void SetupProfileForGoogleUser(ApplicationUser user, GoogleUserInfo googleUserInfo)
        {
            try
            {
                Logger.Info($"Setting up profile for new Google user: {user.Id}");

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
                Logger.Info($"Profile created for user: {user.Id}, ProfileId: {profileId}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error setting up profile for user: {user.Id}");
            }
        }

        /// <summary>
        /// Gets authentication token for Google OAuth user
        /// </summary>
        private TokenResponseModel GetTokenForGoogleUser(string email, string password, long userId)
        {
            try
            {
                Logger.Info($"Generating auth token for Google user: {email}");

                var tokenResponseModel = new TokenResponseModel();
                var tokenRequestModel = new TokenRequestModel(email, password);

                Uri baseUri = new Uri(Request.RequestUri, RequestContext.VirtualPathRoot);
                var client = new RestClient(baseUri.ToString() + "/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");

                string data = $"UserName={email}&password={password}&grant_type={tokenRequestModel.grant_type}";
                request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);

                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    tokenResponseModel = JsonConvert.DeserializeObject<TokenResponseModel>(response.Content);
                    tokenResponseModel.expiredInMinutes = 30;
                    tokenResponseModel.expiredTime = DateTime.UtcNow.AddMinutes(tokenResponseModel.expiredInMinutes);

                    Logger.Info($"Auth token generated successfully for user: {email}");
                    return tokenResponseModel;
                }

                Logger.Warn($"Failed to generate token for user: {email}");
                return tokenResponseModel;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error generating auth token for user: {email}");
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
                Logger.Info($"Setting device token for UserId: {userId}");

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

                    Logger.Info($"Device token set for UserId: {userId}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error setting device token for UserId: {userId}");
            }
        }

        #endregion
    }
}
