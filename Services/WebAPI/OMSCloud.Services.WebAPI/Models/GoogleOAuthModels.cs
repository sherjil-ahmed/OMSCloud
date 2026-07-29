using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSCloud.Services.WebAPIs.Models
{
    /// <summary>
    /// Database model to store Google OAuth credentials for users
    /// Maps to AspNetUserLogins table via provider/providerkey
    /// Also stores additional Google-specific credentials like refresh tokens
    /// </summary>
    [Table("UserGoogleOAuthCredentials1")]
    public class UserGoogleOAuthCredential1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Reference to ApplicationUser
        /// </summary>
        [Required]
        [Index("IX_UserId", IsUnique = false)]
        public long UserId { get; set; }

        /// <summary>
        /// Google's unique identifier for the user (subject claim from Google's JWT)
        /// </summary>
        [Required]
        [StringLength(500)]
        [Index("IX_GoogleId", IsUnique = true)]
        public string GoogleId { get; set; }

        /// <summary>
        /// Google's access token for API calls
        /// </summary>
        [Required]
        public string AccessToken { get; set; }

        /// <summary>
        /// Google's refresh token for obtaining new access tokens
        /// </summary>
        [StringLength(1000)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Expiry time of the access token
        /// </summary>
        public DateTime AccessTokenExpiryTime { get; set; }

        /// <summary>
        /// Google's ID token (JWT) for additional claims validation
        /// </summary>
        public string IdToken { get; set; }

        /// <summary>
        /// Scope of permissions granted
        /// </summary>
        [StringLength(500)]
        public string Scope { get; set; }

        /// <summary>
        /// Token type (usually "Bearer")
        /// </summary>
        [StringLength(50)]
        public string TokenType { get; set; }

        /// <summary>
        /// Authentication provider name (always "Google" for this table)
        /// </summary>
        [Required]
        [StringLength(50)]
        [Index("IX_AuthProvider", IsUnique = false)]
        public string AuthenticationProvider { get; set; }

        /// <summary>
        /// Is this credential active and usable
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// When was this credential created
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// When was this credential last modified
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Last login time using this OAuth provider
        /// </summary>
        public DateTime? LastLoginOn { get; set; }

        /// <summary>
        /// Navigation property to ApplicationUser
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }

    /// <summary>
    /// Metadata constants for authentication
    /// </summary>
    public static class AuthenticationMetadata
    {
        public const string GoogleOAuthProvider = "Google";
        public const string StandardProvider = "Standard";
        public const string ClaimType = "AuthenticationProvider";
    }
}
