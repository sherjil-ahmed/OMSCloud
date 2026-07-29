namespace OMSCloud.Services.WebAPIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Entity Framework Migration for Google OAuth Implementation
    /// Creates UserGoogleOAuthCredentials table for storing Google OAuth tokens and metadata
    /// 
    /// To apply this migration, run in Package Manager Console:
    ///   Add-Migration AddUserGoogleOAuthCredentials
    ///   Update-Database
    /// 
    /// To rollback:
    ///   Update-Database -TargetMigration: $InitialCreate
    /// </summary>
    public partial class AddUserGoogleOAuthCredentials : DbMigration
    {
        public override void Up()
        {
            // Create UserGoogleOAuthCredentials table
            CreateTable(
                "dbo.UserGoogleOAuthCredentials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        GoogleId = c.String(nullable: false, maxLength: 500, unicode: true),
                        AccessToken = c.String(nullable: false, unicode: true),
                        RefreshToken = c.String(maxLength: 1000, unicode: true),
                        AccessTokenExpiryTime = c.DateTime(nullable: false),
                        IdToken = c.String(unicode: true),
                        Scope = c.String(maxLength: 500, unicode: true),
                        TokenType = c.String(maxLength: 50, unicode: true),
                        AuthenticationProvider = c.String(nullable: false, maxLength: 50, unicode: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        LastLoginOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId, name: "IX_UserGoogleOAuthCredentials_UserId")
                .Index(t => t.GoogleId, unique: true, name: "IX_UserGoogleOAuthCredentials_GoogleId")
                .Index(t => t.AuthenticationProvider, name: "IX_UserGoogleOAuthCredentials_AuthProvider");
        }

        public override void Down()
        {
            // Drop indices
            DropIndex("dbo.UserGoogleOAuthCredentials", "IX_UserGoogleOAuthCredentials_AuthProvider");
            DropIndex("dbo.UserGoogleOAuthCredentials", "IX_UserGoogleOAuthCredentials_GoogleId");
            DropIndex("dbo.UserGoogleOAuthCredentials", "IX_UserGoogleOAuthCredentials_UserId");

            // Drop foreign key and table
            DropForeignKey("dbo.UserGoogleOAuthCredentials", "UserId", "dbo.USERS");
            DropTable("dbo.UserGoogleOAuthCredentials");
        }
    }
}
