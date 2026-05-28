# Google OAuth Configuration Guide

## Overview
This document provides instructions on how to configure Google OAuth 2.0 authentication for the OMSCloud WebAPI.

## Prerequisites
1. Google Cloud Platform (GCP) Project
2. OAuth 2.0 Client ID credentials from Google Console
3. .NET Framework 4.6.1 with Web API 2

## Step 1: Set Up Google OAuth Credentials

### Create OAuth 2.0 Credentials
1. Go to [Google Cloud Console](https://console.cloud.google.com/)
2. Create a new project or select existing one
3. Enable the Google+ API
4. Go to "Credentials" → "Create Credentials" → "OAuth client ID"
5. Select "Web application"
6. Add authorized redirect URIs (e.g., `https://yourdomain.com/api/GoogleOAuth/callback`)
7. Copy the Client ID and Client Secret

## Step 2: Update Web.config

Add the following configuration entries to your `Web.config` file under the `<appSettings>` section:

```xml
<!-- Google OAuth Configuration -->
<add key="GoogleOAuth_ClientId" value="YOUR_GOOGLE_CLIENT_ID" />
<add key="GoogleOAuth_ClientSecret" value="YOUR_GOOGLE_CLIENT_SECRET" />
<add key="GoogleOAuth_RedirectUri" value="https://yourdomain.com/api/GoogleOAuth/callback" />
```

## Step 3: Database Migration

Execute the SQL migration script to create the necessary tables:

```sql
-- Run the following script on your DefaultSecurityConnection database
-- File: SQL/GoogleOAuth_Migration.sql
```

### Tables Created:
- `USER_GOOGLE_OAUTH_CREDENTIAL` - Stores Google OAuth credentials for each user
- Indexes for performance optimization
- Stored procedures for credential management

## Step 4: API Endpoints

### Google OAuth Signup
**Endpoint:** `POST /api/GoogleOAuth/signup`

**Request Body:**
```json
{
  "Code": "authorization_code_from_google",
  "State": "state_parameter",
  "RedirectUri": "https://yourdomain.com/api/GoogleOAuth/callback",
  "DeviceToken": "optional_device_token",
  "NotificationTokenJson": "{\"Token\":\"device_token\",\"Platform\":\"iOS\"}"
}
```

**Response:**
```json
{
  "StatusCode": "Success",
  "StatusMessage": "Google account registered successfully. You can now login.",
  "IsActionRequired": false,
  "TokenResponse": {
    "access_token": "your_access_token",
    "token_type": "Bearer",
    "expires_in": 1800,
    "expiredTime": "2026-05-26T08:30:00Z"
  }
}
```

### Google OAuth Sign-In
**Endpoint:** `POST /api/GoogleOAuth/signin`

**Request Body:**
```json
{
  "Code": "authorization_code_from_google",
  "State": "state_parameter",
  "RedirectUri": "https://yourdomain.com/api/GoogleOAuth/callback",
  "NotificationTokenJson": "{\"Token\":\"device_token\",\"Platform\":\"iOS\"}"
}
```

**Response:**
Same as signup endpoint

### Refresh Google OAuth Token
**Endpoint:** `POST /api/GoogleOAuth/refresh-token`

**Headers:**
```
Authorization: Bearer YOUR_ACCESS_TOKEN
```

**Response:**
```json
{
  "access_token": "new_access_token",
  "token_type": "Bearer",
  "expires_in": 1800,
  "expiredTime": "2026-05-26T08:30:00Z"
}
```

## Step 5: Frontend Integration

### Angular/React Example - Google Sign-In

```typescript
// Load Google API
<script src="https://accounts.google.com/gsi/client" async defer></script>

// Initialize Google Sign-In
function initializeGoogle() {
  google.accounts.id.initialize({
    client_id: 'YOUR_GOOGLE_CLIENT_ID',
    callback: handleCredentialResponse
  });
  
  google.accounts.id.renderButton(
    document.getElementById('googleSignInButton'),
    { theme: 'outline', size: 'large' }
  );
}

// Handle the response
function handleCredentialResponse(response) {
  const authorizationCode = response.credential;
  
  // Send to your backend
  fetch('/api/GoogleOAuth/signin', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      Code: authorizationCode,
      RedirectUri: window.location.origin + '/api/GoogleOAuth/callback',
      NotificationTokenJson: JSON.stringify({
        Token: YOUR_DEVICE_TOKEN,
        Platform: 'Web'
      })
    })
  })
  .then(response => response.json())
  .then(data => {
    if (data.StatusCode === 'Success') {
      // Store token
      localStorage.setItem('accessToken', data.TokenResponse.access_token);
      // Redirect to dashboard
      window.location.href = '/dashboard';
    }
  });
}

// Initialize on page load
window.addEventListener('load', initializeGoogle);
```

## Step 6: Implementation Details

### Authentication Flow

**Signup Flow:**
1. User clicks "Sign up with Google"
2. Frontend redirects to Google OAuth consent screen
3. User authorizes the application
4. Google sends authorization code to frontend
5. Frontend sends code to `POST /api/GoogleOAuth/signup`
6. Backend exchanges code for tokens
7. Backend retrieves Google user info
8. Backend checks if email exists in database
   - If new: Creates user account with Google info
   - If exists: Links Google account to existing user
9. Backend stores Google credentials in database
10. Backend returns access token to frontend

**Sign-In Flow:**
1. Similar to signup but expects user to already exist
2. Backend validates Google credentials
3. Backend updates stored tokens
4. Returns access token

**Token Refresh Flow:**
1. Frontend detects token expiration
2. Frontend calls `POST /api/GoogleOAuth/refresh-token`
3. Backend uses stored refresh token to get new access token
4. Backend updates stored credentials
5. Returns new access token

### Authentication Provider Identification

The system tracks authentication provider using:
- `AuthenticationProvider` field in `USERS` table
- `AuthenticationMetadata` class constants: `GoogleOAuthProvider` or `DefaultProvider`
- Claims in authentication token

**Example: Check Authentication Source**
```csharp
var claims = User.Claims;
var provider = claims.FirstOrDefault(c => c.Type == AuthenticationMetadata.ClaimType)?.Value;
bool isGoogleOAuth = provider == AuthenticationMetadata.GoogleOAuthProvider;
```

### Credential Storage

Google credentials are securely stored in `USER_GOOGLE_OAUTH_CREDENTIAL` table with:
- Access token (automatically refreshed)
- Refresh token (used to obtain new access tokens)
- Token expiry time
- Active status flag
- Creation and modification timestamps

### Error Handling

Common error scenarios:

**Invalid Authorization Code:**
```json
{
  "StatusCode": "Failure",
  "StatusMessage": "Failed to authenticate with Google. Please try again."
}
```

**User Not Found (Sign-In):**
```json
{
  "StatusCode": "Failure",
  "StatusMessage": "No account found with this Google email. Please sign up first."
}
```

**Token Refresh Failed:**
```json
{
  "error": "invalid_grant",
  "error_description": "Token has been revoked"
}
```

## Step 7: Security Considerations

1. **Encrypt Sensitive Data:** Consider encrypting tokens stored in database
2. **HTTPS Only:** Always use HTTPS in production
3. **Token Expiry:** Implement automatic token refresh before expiry
4. **Revocation:** Implement user logout to revoke tokens
5. **Rate Limiting:** Implement rate limiting on OAuth endpoints
6. **Audit Logging:** Log all authentication events for security audit
7. **Input Validation:** Always validate state parameter and authorization code

## Step 8: Testing

### Manual Testing

1. **Test Signup:**
   ```
   POST /api/GoogleOAuth/signup
   With valid Google authorization code
   Verify user is created in database
   Verify tokens are stored
   ```

2. **Test Sign-In:**
   ```
   POST /api/GoogleOAuth/signin
   With valid authorization code for existing user
   Verify credentials are updated
   ```

3. **Test Token Refresh:**
   ```
   POST /api/GoogleOAuth/refresh-token
   With valid Bearer token
   Verify new access token is returned
   ```

## Step 9: Troubleshooting

### Issue: "Invalid client_id"
- Verify Google Client ID is correct in Web.config
- Check Client ID matches your Google Console credentials

### Issue: "Redirect URI mismatch"
- Verify RedirectUri in request matches authorized redirect URI in Google Console
- Check for trailing slashes and protocol (http vs https)

### Issue: "Access token is invalid"
- Verify token hasn't expired
- Check token format is correct
- Verify Authorization header format: `Authorization: Bearer TOKEN`

### Issue: "User not found during sign-in"
- Confirm user exists in database
- Verify Google email matches email in database

## Deployment Checklist

- [ ] Update Web.config with Google OAuth credentials
- [ ] Run SQL migration script on production database
- [ ] Configure authorized redirect URIs in Google Console
- [ ] Enable HTTPS for all OAuth endpoints
- [ ] Implement encryption for token storage
- [ ] Set up audit logging
- [ ] Test all authentication flows
- [ ] Configure CORS if frontend is on different domain
- [ ] Implement rate limiting
- [ ] Set up monitoring and alerts for authentication failures

## Support and References

- [Google OAuth 2.0 Documentation](https://developers.google.com/identity/protocols/oauth2)
- [Web API 2 Authorization](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api)
- [ASP.NET Identity Documentation](https://docs.microsoft.com/en-us/aspnet/identity/)
