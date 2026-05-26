using System;
using System.Collections.Generic;

namespace OMSCloud.Services.WebAPIs.Models
{
    /// <summary>
    /// Model for Google OAuth configuration
    /// </summary>
    public class GoogleOAuthConfiguration
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserInfoEndpoint { get; set; }
    }

    /// <summary>
    /// Model to represent Google OAuth token request
    /// </summary>
    public class GoogleTokenRequest
    {
        public string code { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string redirect_uri { get; set; }
        public string grant_type { get; set; } = "authorization_code";
    }

    /// <summary>
    /// Model to represent Google OAuth token response
    /// </summary>
    public class GoogleTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public string id_token { get; set; }
    }

    /// <summary>
    /// Model to represent Google user information
    /// </summary>
    public class GoogleUserInfo
    {
        public string id { get; set; }
        public string email { get; set; }
        public string verified_email { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string picture { get; set; }
        public string locale { get; set; }
    }

    /// <summary>
    /// Model for Google OAuth signup/signin request
    /// </summary>
    public class GoogleOAuthSignupRequest
    {
        public string Code { get; set; }
        public string State { get; set; }
        public string RedirectUri { get; set; }
        public string DeviceToken { get; set; }
        public string NotificationTokenJson { get; set; }
    }

    /// <summary>
    /// Model for Google OAuth refresh token request
    /// </summary>
    public class GoogleOAuthRefreshTokenRequest
    {
        public string refresh_token { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; } = "refresh_token";
    }

    /// <summary>
    /// Model to store Google OAuth credentials for a user
    /// </summary>
    public class UserGoogleOAuthCredential
    {
        public long UserOAuthCredentialId { get; set; }
        public long UserId { get; set; }
        public string GoogleId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiryTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public string AuthenticationProvider { get; set; } = "Google"; // To distinguish from other OAuth providers
    }

    /// <summary>
    /// Extended login model to support Google OAuth
    /// </summary>
    public class GoogleOAuthLoginViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GoogleId { get; set; }
        public string GoogleAccessToken { get; set; }
        public string GoogleRefreshToken { get; set; }
        public DateTime TokenExpiryTime { get; set; }
        public string AuthenticationProvider { get; set; } = "Google";
    }

    /// <summary>
    /// Response model for authentication that indicates the provider
    /// </summary>
    public class AuthenticationSourceModel
    {
        public string Provider { get; set; } // "Google" or "Default"
        public bool IsGoogleOAuth { get; set; }
        public bool IsDefaultAuth { get; set; }
    }

    /// <summary>
    /// Model to track authentication method in claims
    /// </summary>
    public class AuthenticationMetadata
    {
        public const string GoogleOAuthProvider = "GoogleOAuth";
        public const string DefaultProvider = "DefaultAuth";
        public const string ClaimType = "AuthenticationProvider";
    }
}
