using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using NLog;
using OMSCloud.Services.WebAPIs.Models;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.Services.WebAPIs.App_Code
{
    /// <summary>
    /// Service to handle Google OAuth 2.0 authentication flows
    /// Supports signup, signin, and refresh token operations
    /// </summary>
    public class GoogleOAuthService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        private readonly GoogleOAuthConfiguration _config;
        private const string GoogleTokenEndpoint = "https://oauth2.googleapis.com/token";
        private const string GoogleUserInfoEndpoint = "https://www.googleapis.com/oauth2/v1/userinfo";

        public GoogleOAuthService(GoogleOAuthConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Exchanges authorization code for access token and user information
        /// </summary>
        public async Task<(GoogleTokenResponse tokenResponse, GoogleUserInfo userInfo)> ExchangeCodeForTokenAsync(string code, string redirectUri)
        {
            try
            {
                Logger.Info($"Exchanging authorization code for token. Code: {code}");

                var tokenRequest = new GoogleTokenRequest
                {
                    code = code,
                    client_id = _config.ClientId,
                    client_secret = _config.ClientSecret,
                    redirect_uri = redirectUri,
                    grant_type = "authorization_code"
                };

                // Exchange code for tokens
                var tokenResponse = await GetTokenFromGoogle(tokenRequest);

                if (tokenResponse == null)
                {
                    Logger.Error("Failed to get token response from Google");
                    return (null, null);
                }

                Logger.Info($"Successfully obtained access token from Google");

                // Get user information using access token
                var userInfo = await GetUserInfoFromGoogle(tokenResponse.access_token);

                if (userInfo == null)
                {
                    Logger.Error("Failed to get user info from Google");
                    return (null, null);
                }

                Logger.Info($"Successfully obtained user info from Google. GoogleId: {userInfo.id}, Email: {userInfo.email}");

                return (tokenResponse, userInfo);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error exchanging code for token");
                return (null, null);
            }
        }

        /// <summary>
        /// Refreshes an expired access token using refresh token
        /// </summary>
        public async Task<GoogleTokenResponse> RefreshAccessTokenAsync(string refreshToken)
        {
            try
            {
                Logger.Info("Refreshing access token");

                var refreshRequest = new GoogleOAuthRefreshTokenRequest
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
        public async Task<GoogleUserInfo> ValidateAccessTokenAsync(string accessToken)
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
        private async Task<GoogleTokenResponse> GetTokenFromGoogle(object tokenRequest)
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
                    var tokenResponse = JsonConvert.DeserializeObject<GoogleTokenResponse>(response.Content);
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
        private async Task<GoogleUserInfo> GetUserInfoFromGoogle(string accessToken)
        {
            try
            {
                var client = new RestClient(GoogleUserInfoEndpoint);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {accessToken}");

                var response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var userInfo = JsonConvert.DeserializeObject<GoogleUserInfo>(response.Content);
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
    }
}
