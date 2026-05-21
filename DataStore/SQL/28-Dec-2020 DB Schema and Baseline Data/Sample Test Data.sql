

SET IDENTITY_INSERT [dbo].[Tax] ON 
GO
INSERT [dbo].[Tax] ([TaxID], [TaxValue], [TaxTypeID], [Description], [StatusID], [IsPercentage], [LocationLevelId], [LocationId], [EffectiveDate], [LastModifiedDateTime], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime]) 
VALUES (1, 12, 1, N'GST', 2, 1, 1, 0, CAST(N'2020-12-08T15:52:00.000' AS DateTime), CAST(N'2020-12-05T15:52:51.523' AS DateTime), 1, 1, CAST(N'2020-12-05T15:52:51.523' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Tax] OFF
GO

--[Brand]

SET IDENTITY_INSERT [dbo].[Brand] ON 
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [ManufacturerName], [Description], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) 
VALUES (1, N'Test Brand', N'Test Brand', N'Test Brand', 2, 1, 1, CAST(N'2020-11-16T12:48:32.183' AS DateTime), CAST(N'2020-11-16T12:48:32.183' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO

--[Supplier]

SET IDENTITY_INSERT [dbo].[Supplier] ON 
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Logo], [Description], [StatusID], [StatusNotes], [BusinessAddressID], [IsBusinessAddressVisible], [LanguageID], [CurrencyID], [CountryID], [ProvinceID], [CityID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsCOD], [ProfileID], [ProcessingFee], [PaymentGatewayFee], [IsProcessingFeePercentage], [IsPaymentGatewayFeePercentage]) 
VALUES (1, N'GroceryShop', NULL, N'GroceryShop', 2, N'GroceryShop', 1, 1, NULL, NULL, 0, 2, 23, 1, 1, CAST(N'2020-12-27T02:27:11.560' AS DateTime), CAST(N'2020-12-27T02:27:11.560' AS DateTime), 0, 1, 5, 5, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO

--[Product]

SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductID], [ProductTitle], [BrifeDescription], [ProductActualImagePath], [ProductImagePath], [StockCount], [WebLink], [BasePrice], [DiscountValue], [IsDiscountPercentage], [SellingPrice], [OrderResponseTime], [OrderResponseTimeUnitID], [TaxTypeID], [UserRating], [AnalysisRank], [Description], [ProductTypeID], [BrandID], [SupplierID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) 
VALUES (1, N'Test Product', N'Test Product', N'', N'', 0, NULL, 49.5, 7, 1, 55, 2, N'4', 1, 0, 0, N'Test Product', 1, 1, 1, 2, 1, 1, CAST(N'2020-12-27T02:28:06.757' AS DateTime), CAST(N'2020-12-27T02:28:07.370' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

--[Attribute] 

SET IDENTITY_INSERT [dbo].[Attribute] ON 
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Color', N'Color', 1, 10, 1, N'White', 1, 1, 2, 1, 1, CAST(N'2020-12-22T19:56:15.553' AS DateTime), CAST(N'2020-12-22T19:56:15.553' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (2, N'Color', N'sdfsfsdf', 2, 11, 3, N'sfsf', 1, 1, 2, 1, 1, CAST(N'2020-12-27T02:31:25.020' AS DateTime), CAST(N'2020-12-27T02:31:25.020' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (3, N'ONE', N'Full Payment in Advance', 1, 11, 5, N'345345', 1, 1, 2, 1, 1, CAST(N'2020-12-27T02:32:19.963' AS DateTime), CAST(N'2020-12-27T02:32:19.963' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Attribute] OFF
GO

--[Category] 

SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) 
VALUES (1, N'Electronics', N'Electronics', N'', 1, NULL, 2, 1, 1, 1, CAST(N'2020-12-22T19:55:27.957' AS DateTime), CAST(N'2020-12-22T19:55:28.350' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO

-- [CategoryAttributePair]

SET IDENTITY_INSERT [dbo].[CategoryAttributePair] ON 
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (1, 1, 1, N'Black', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryAttributePair] OFF
GO
