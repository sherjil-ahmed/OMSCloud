using Microsoft.AspNet.Identity;

using Newtonsoft.Json;

using NLog;

using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Models;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Services.WebAPIs.Common
{//Security_IdentityExtendedMethods
	public static class Security_ExtendedMethods_4_Principal
    {
        //public static int GetUserId(this IIdentity _identity)
        //{
        //    int _retVal = 0;
        //    try
        //    {
        //        if (_identity != null && _identity.IsAuthenticated)
        //        {
        //            var ci = _identity as ClaimsIdentity;
        //            string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

        //            if (!string.IsNullOrEmpty(_userId))
        //            {
        //                _retVal = int.Parse(_userId);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return _retVal;
        //}

        public static bool HasPermission(this IPrincipal _principal, string _requiredPermission, string userId)
        {
            bool _retVal = false;
            try
            {
                if (_principal != null && _principal.Identity != null && _principal.Identity.IsAuthenticated)
                {
                    //var ci = _principal.Identity as ClaimsIdentity;
                    //string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(userId))
                    {
                        ApplicationUser _authenticatedUser = ApplicationUserManager.GetUser(int.Parse(userId));
                        _retVal = _authenticatedUser.IsPermissionInUserRoles(_requiredPermission);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }

        public static bool IsSysAdmin(this IPrincipal _principal)
        {
            bool _retVal = false;
            try
            {
                if (_principal != null && _principal.Identity != null && _principal.Identity.IsAuthenticated)
                {
                    var ci = _principal.Identity as ClaimsIdentity;
                    string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(_userId))
                    {
                        ApplicationUser _authenticatedUser = ApplicationUserManager.GetUser(int.Parse(_userId));
                        _retVal = _authenticatedUser.IsSysAdmin();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }

        //public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        //{
        //    string _retVal = string.Empty;
        //    try
        //    {
        //        if (identity != null)
        //        {
        //            var claim = identity.FindFirst(claimType);
        //            _retVal = claim != null ? claim.Value : null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return _retVal;
        //}
    }

	/// <summary>
	/// Service to handle Google OAuth 2.0 authentication flows
	/// Supports signup, signin, and refresh token operations
	/// Compatible with .NET 4.6.1 and C# 6.0
	/// </summary>
	public class GoogleOAuthService
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		private readonly GoogleOAuthConfiguration _config;
		private const string GoogleTokenEndpoint = "https://oauth2.googleapis.com/token";
		private const string GoogleUserInfoEndpoint = "https://www.googleapis.com/oauth2/v1/userinfo";

		public GoogleOAuthService(GoogleOAuthConfiguration config)
		{
			if (config == null)
			{
				throw new ArgumentNullException("config");
			}
			_config = config;
		}

		/// <summary>
		/// Exchanges authorization code for access token and user information
		/// Returns GoogleCodeExchangeOutput containing token and user info
		/// </summary>
		public async Task<GoogleCodeExchangeOutput> ExchangeCodeForTokenAsync(string code, string redirectUri)
		{
			try
			{
				Logger.Info(string.Format("Exchanging authorization code for token. Code: {0}", code));

				var tokenRequest = new GoogleTokenRequestModel
				{
					code = code,
					client_id = _config.ClientId,
					client_secret = _config.ClientSecret,
					redirect_uri = redirectUri,
					grant_type = "authorization_code"
				};

				var output = new GoogleCodeExchangeOutput();

				// Exchange code for tokens
				var tokenResponse = await GetTokenFromGoogle(tokenRequest);

				if (tokenResponse == null)
				{
					Logger.Error("Failed to get token response from Google");
					output.IsSuccessful = false;
					output.ErrorMessage = "Failed to get token response from Google";
					return output;
				}

				Logger.Info("Successfully obtained access token from Google");

				// Get user information using access token
				var userInfo = await GetUserInfoFromGoogle(tokenResponse.access_token);

				if (userInfo == null)
				{
					Logger.Error("Failed to get user info from Google");
					output.IsSuccessful = false;
					output.ErrorMessage = "Failed to get user info from Google";
					return output;
				}

				Logger.Info(string.Format("Successfully obtained user info from Google. GoogleId: {0}, Email: {1}", userInfo.id, userInfo.email));

				output.TokenResponse = tokenResponse;
				output.UserInfo = userInfo;
				output.IsSuccessful = true;

				return output;
			}
			catch (Exception ex)
			{
				Logger.Error(ex, "Error exchanging code for token");
				return new GoogleCodeExchangeOutput
				{
					IsSuccessful = false,
					ErrorMessage = ex.Message
				};
			}
		}

		/// <summary>
		/// Refreshes an expired access token using refresh token
		/// </summary>
		public async Task<GoogleTokenResponseModel> RefreshAccessTokenAsync(string refreshToken)
		{
			try
			{
				Logger.Info("Refreshing access token");

				var refreshRequest = new GoogleOAuthRefreshTokenRequestModel
				{
					refresh_token = refreshToken,
					client_id = _config.ClientId,
					client_secret = _config.ClientSecret,
					grant_type = "refresh_token"
				};

				var tokenResponse = await GetTokenFromGoogle(refreshRequest);

				if (tokenResponse == null)
				{
					Logger.Error("Failed to refresh access token");
					return null;
				}

				Logger.Info("Successfully refreshed access token");
				return tokenResponse;
			}
			catch (Exception ex)
			{
				Logger.Error(ex, "Error refreshing access token");
				return null;
			}
		}

		/// <summary>
		/// Validates an access token by attempting to get user info
		/// </summary>
		public async Task<GoogleUserInfoModel> ValidateAccessTokenAsync(string accessToken)
		{
			try
			{
				Logger.Info("Validating access token");

				var userInfo = await GetUserInfoFromGoogle(accessToken);

				if (userInfo != null)
				{
					Logger.Info($"Access token is valid. GoogleId: {userInfo.id}");
				}
				else
				{
					Logger.Warn("Access token validation failed");
				}

				return userInfo;
			}
			catch (Exception ex)
			{
				Logger.Error(ex, "Error validating access token");
				return null;
			}
		}

		/// <summary>
		/// Internal method to exchange tokens with Google
		/// </summary>
		private async Task<GoogleTokenResponseModel> GetTokenFromGoogle(object tokenRequest)
		{
			try
			{
				var client = new RestClient(GoogleTokenEndpoint);
				var request = new RestRequest(Method.POST);
				request.AddHeader("Content-Type", "application/json");
				request.AddJsonBody(tokenRequest);

				var response = await client.ExecuteAsync(request);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					var tokenResponse = JsonConvert.DeserializeObject<GoogleTokenResponseModel>(response.Content);
					return tokenResponse;
				}

				Logger.Error($"Google token endpoint returned status {response.StatusCode}: {response.Content}");
				return null;
			}
			catch (Exception ex)
			{
				Logger.Error(ex, "Error communicating with Google token endpoint");
				return null;
			}
		}

		/// <summary>
		/// Internal method to get user information from Google
		/// </summary>
		private async Task<GoogleUserInfoModel> GetUserInfoFromGoogle(string accessToken)
		{
			try
			{
				var client = new RestClient(GoogleUserInfoEndpoint);
				var request = new RestRequest(Method.GET);
				request.AddHeader("Authorization", $"Bearer {accessToken}");

				var response = await client.ExecuteAsync(request);

				if (response.StatusCode == HttpStatusCode.OK)
				{
					var userInfo = JsonConvert.DeserializeObject<GoogleUserInfoModel>(response.Content);
					return userInfo;
				}

				Logger.Error($"Google user info endpoint returned status {response.StatusCode}: {response.Content}");
				return null;
			}
			catch (Exception ex)
			{
				Logger.Error(ex, "Error getting user info from Google");
				return null;
			}
		}

		private async Task<GoogleTokenResponseModel> GoogleAuth(string authorizationCode)
		{
			// Step 1: User gets redirected to Google login
			// GET https://accounts.google.com/o/oauth2/v2/auth?
			//   client_id=YOUR_CLIENT_ID&
			//   scope=profile%20email&
			//   response_type=code&
			//   redirect_uri=YOUR_REDIRECT_URI

			// Step 2: Exchange authorization code for tokens
			var tokenRequest = new HttpClient();
			var response = await tokenRequest.PostAsync("https://oauth2.googleapis.com/token",
				new FormUrlEncodedContent(new Dictionary<string, string>
					{
						{ "client_id", "YOUR_CLIENT_ID" },
						{ "client_secret", "YOUR_CLIENT_SECRET" },
						{ "code", authorizationCode },
						{ "grant_type", "authorization_code" },
						{ "redirect_uri", "YOUR_REDIRECT_URI" }
					}
				));

			var tokenResponse = JsonConvert.DeserializeObject<dynamic>(
				await response.Content.ReadAsStringAsync());


			var googleTokenResponseModel = new GoogleTokenResponseModel
			{
				access_token = tokenResponse.access_token,
				refresh_token = tokenResponse.refresh_token,
				id_token = tokenResponse.id_token,
				expires_in = tokenResponse.expires_in,
				token_type = tokenResponse.token_type
			};
			return googleTokenResponseModel;
		}
	}
}