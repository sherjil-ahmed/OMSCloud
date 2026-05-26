-- SQL Migration Script for Google OAuth Support
-- This script adds the necessary table to store Google OAuth credentials for users
-- Execute this on your DefaultSecurityConnection database

-- Create table to store Google OAuth credentials
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'USER_GOOGLE_OAUTH_CREDENTIAL')
BEGIN
    CREATE TABLE [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL]
    (
        [UserOAuthCredentialId] [bigint] IDENTITY(1,1) NOT NULL,
        [UserId] [bigint] NOT NULL,
        [GoogleId] [nvarchar](255) NOT NULL,
        [AccessToken] [nvarchar](max) NOT NULL,
        [RefreshToken] [nvarchar](max) NULL,
        [AccessTokenExpiryTime] [datetime] NOT NULL,
        [CreatedOn] [datetime] NOT NULL,
        [ModifiedOn] [datetime] NOT NULL,
        [IsActive] [bit] NOT NULL DEFAULT 1,
        [AuthenticationProvider] [nvarchar](50) NOT NULL DEFAULT 'Google',
        
        CONSTRAINT [PK_USER_GOOGLE_OAUTH_CREDENTIAL] PRIMARY KEY CLUSTERED 
        (
            [UserOAuthCredentialId] ASC
        ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
        
        CONSTRAINT [FK_USER_GOOGLE_OAUTH_CREDENTIAL_USER] FOREIGN KEY([UserId]) 
        REFERENCES [dbo].[USERS] ([UserId]) ON DELETE CASCADE
    )

    -- Create index on UserId for faster lookups
    CREATE NONCLUSTERED INDEX [IX_USER_GOOGLE_OAUTH_CREDENTIAL_USERID] 
    ON [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL] ([UserId])

    -- Create unique index on GoogleId to prevent duplicate Google accounts
    CREATE UNIQUE NONCLUSTERED INDEX [IX_USER_GOOGLE_OAUTH_CREDENTIAL_GOOGLEID] 
    ON [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL] ([GoogleId])

    -- Create index on IsActive for querying active credentials
    CREATE NONCLUSTERED INDEX [IX_USER_GOOGLE_OAUTH_CREDENTIAL_ISACTIVE] 
    ON [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL] ([IsActive])

    PRINT 'USER_GOOGLE_OAUTH_CREDENTIAL table created successfully.'
END
ELSE
BEGIN
    PRINT 'USER_GOOGLE_OAUTH_CREDENTIAL table already exists.'
END

-- Add column to USERS table to track authentication provider if needed
-- This is optional but helpful for auditing
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('USERS') AND name = 'AuthenticationProvider')
BEGIN
    ALTER TABLE [dbo].[USERS]
    ADD [AuthenticationProvider] [nvarchar](50) NULL DEFAULT 'Default'
    
    PRINT 'AuthenticationProvider column added to USERS table.'
END
ELSE
BEGIN
    PRINT 'AuthenticationProvider column already exists in USERS table.'
END

-- Create stored procedure to get Google OAuth credentials
IF OBJECT_ID('sp_GetGoogleOAuthCredentials', 'P') IS NULL
BEGIN
    EXEC sp_executesql N'
    CREATE PROCEDURE [dbo].[sp_GetGoogleOAuthCredentials]
        @UserId BIGINT
    AS
    BEGIN
        SET NOCOUNT ON;
        
        SELECT TOP 1
            [UserOAuthCredentialId],
            [UserId],
            [GoogleId],
            [AccessToken],
            [RefreshToken],
            [AccessTokenExpiryTime],
            [CreatedOn],
            [ModifiedOn],
            [IsActive],
            [AuthenticationProvider]
        FROM [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL]
        WHERE [UserId] = @UserId
        AND [IsActive] = 1
        ORDER BY [ModifiedOn] DESC
    END'
    
    PRINT 'Stored procedure sp_GetGoogleOAuthCredentials created.'
END

-- Create stored procedure to update Google OAuth credentials
IF OBJECT_ID('sp_UpdateGoogleOAuthCredentials', 'P') IS NULL
BEGIN
    EXEC sp_executesql N'
    CREATE PROCEDURE [dbo].[sp_UpdateGoogleOAuthCredentials]
        @UserId BIGINT,
        @GoogleId NVARCHAR(255),
        @AccessToken NVARCHAR(MAX),
        @RefreshToken NVARCHAR(MAX),
        @AccessTokenExpiryTime DATETIME,
        @IsActive BIT = 1
    AS
    BEGIN
        SET NOCOUNT ON;
        
        IF EXISTS (SELECT 1 FROM [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL] WHERE [UserId] = @UserId AND [IsActive] = 1)
        BEGIN
            UPDATE [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL]
            SET 
                [GoogleId] = @GoogleId,
                [AccessToken] = @AccessToken,
                [RefreshToken] = ISNULL(@RefreshToken, [RefreshToken]),
                [AccessTokenExpiryTime] = @AccessTokenExpiryTime,
                [ModifiedOn] = GETDATE(),
                [IsActive] = @IsActive
            WHERE [UserId] = @UserId
        END
        ELSE
        BEGIN
            INSERT INTO [dbo].[USER_GOOGLE_OAUTH_CREDENTIAL]
            ([UserId], [GoogleId], [AccessToken], [RefreshToken], [AccessTokenExpiryTime], [CreatedOn], [ModifiedOn], [IsActive], [AuthenticationProvider])
            VALUES
            (@UserId, @GoogleId, @AccessToken, @RefreshToken, @AccessTokenExpiryTime, GETDATE(), GETDATE(), @IsActive, ''Google'')
        END
    END'
    
    PRINT 'Stored procedure sp_UpdateGoogleOAuthCredentials created.'
END

PRINT 'Google OAuth database migration completed successfully.'
