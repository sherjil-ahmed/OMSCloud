SET IDENTITY_INSERT [dbo].[Currency] ON 
GO
INSERT [dbo].[Currency] ([CurrencyId], [Name], [CurrencyCode], [Rate], [DisplayLocale], [CustomFormatting], [LimitedToStores], [Published], [DisplayOrder], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [RoundingTypeId]) VALUES (7, N'Dollar', N'1', CAST(1.0000 AS Decimal(18, 4)), NULL, NULL, 1, 1, 1, CAST(N'2020-09-07T12:41:29.963' AS DateTime), 1, CAST(N'2020-09-07T12:41:29.963' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO

SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([Id], [Name], [AllowsBilling], [AllowsShipping], [TwoLetterIsoCode], [ThreeLetterIsoCode], [NumericIsoCode], [SubjectToVat], [Published], [DisplayOrder], [LimitedToStores]) VALUES (2, N'Canada', 1, 1, NULL, NULL, 12, 1, 1, 12, 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO


SET IDENTITY_INSERT [dbo].[Language] ON 
GO
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Rtl], [LimitedToStores], [DefaultCurrencyId], [Published], [DisplayOrder]) VALUES (1, N'English', N'English', NULL, NULL, 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
