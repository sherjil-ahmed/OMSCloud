SET IDENTITY_INSERT [dbo].[Profile] ON 
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID]) VALUES (2, 2, N'Shop Profile 1`g``', N'Shop Profile 1', N'Shop Profile 1', N'Shop Profile 1', N'Shop Profile 1', N'Shop Profile 1', N'Shop Profile 1', NULL, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Logo], [Description], [StatusID], [StatusNotes], [BusinessAddressID], [IsBusinessAddressVisible], [LanguageID], [CurrencyID], [CountryID], [ProvinceID], [CityID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsCOD], [ProfileID], [ProcessingFee], [PaymentGatewayFee], [IsProcessingFeePercentage], [IsPaymentGatewayFeePercentage]) VALUES (1, N'GroceryShop', NULL, N'GroceryShop', 2, N'GroceryShop', 2, 1, NULL, NULL, 0, 2, 23, 1, 1, CAST(N'2020-12-27T02:27:11.560' AS DateTime), CAST(N'2021-01-10T15:59:29.097' AS DateTime), 1, 1, 5, 5, 1, 1)
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Logo], [Description], [StatusID], [StatusNotes], [BusinessAddressID], [IsBusinessAddressVisible], [LanguageID], [CurrencyID], [CountryID], [ProvinceID], [CityID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsCOD], [ProfileID], [ProcessingFee], [PaymentGatewayFee], [IsProcessingFeePercentage], [IsPaymentGatewayFeePercentage]) VALUES (2, N'Test Shop1', NULL, N'Best shop in town', 2, N'Approved', 1, 1, NULL, NULL, 0, 2, 21, 1, 2, CAST(N'2021-01-10T13:30:47.487' AS DateTime), CAST(N'2021-01-10T15:51:11.077' AS DateTime), 0, 2, 5, 5, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductID], [ProductTitle], [BrifeDescription], [ProductActualImagePath], [ProductImagePath], [StockCount], [WebLink], [BasePrice], [DiscountValue], [IsDiscountPercentage], [SellingPrice], [OrderResponseTime], [OrderResponseTimeUnitID], [TaxTypeID], [UserRating], [AnalysisRank], [Description], [ProductTypeID], [BrandID], [SupplierID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (1, N'Test Product', N'Test Product', N'', N'', 0, NULL, 600, 5, 1, 540, 2, N'4', 1, 0, 0, N'Test Product', 1, 1, 1, 2, 1, 1, CAST(N'2020-12-27T02:28:06.757' AS DateTime), CAST(N'2021-01-10T16:05:31.657' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [ProductTitle], [BrifeDescription], [ProductActualImagePath], [ProductImagePath], [StockCount], [WebLink], [BasePrice], [DiscountValue], [IsDiscountPercentage], [SellingPrice], [OrderResponseTime], [OrderResponseTimeUnitID], [TaxTypeID], [UserRating], [AnalysisRank], [Description], [ProductTypeID], [BrandID], [SupplierID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (2, N'Dress Shirt', N'jhfhsfjdskf', NULL, NULL, 0, NULL, 150, 15, 1, 200, 2, N'4', 1, 0, 0, N'sdjhfgsjfghsf', 1, 1, 2, 2, 1, 1, CAST(N'2021-01-10T13:43:38.523' AS DateTime), CAST(N'2021-01-10T13:46:21.160' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [ProductTitle], [BrifeDescription], [ProductActualImagePath], [ProductImagePath], [StockCount], [WebLink], [BasePrice], [DiscountValue], [IsDiscountPercentage], [SellingPrice], [OrderResponseTime], [OrderResponseTimeUnitID], [TaxTypeID], [UserRating], [AnalysisRank], [Description], [ProductTypeID], [BrandID], [SupplierID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (3, N'Samsung Note 20 Ultra', N'sflnggnfsgdfbgdf', NULL, NULL, 0, NULL, 1740, 3, 1, 2000, 2, N'4', 1, 0, 0, N'dfgdgkdbgkdbg', 1, 1, 2, 2, 1, 1, CAST(N'2021-01-10T15:00:24.867' AS DateTime), CAST(N'2021-01-10T15:00:24.867' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductMediaDetail] ON 
GO
INSERT [dbo].[ProductMediaDetail] ([ProductMediaID], [ProductMediaTitle], [Description], [MediaContentTypeID], [MediaFilePath], [ProductID], [Width], [Height], [TransparencyLevel], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [ApprovedByUserID], [ApprovedDateTime]) VALUES (1, N'ImageFileName: JAMIL PROFILE PIC.jpg', N'default', 2, N'JAMIL PROFILE PIC.jpg', 1, 20, 20, 1, 2, 0, 0, CAST(N'2021-01-10T16:00:40.463' AS DateTime), CAST(N'2021-01-10T16:05:33.387' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductMediaDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (1, N'Electronics', N'Electronics', N'icon-category-electronics', 1, NULL, 2, 1, 1, 1, CAST(N'2020-12-22T19:55:27.957' AS DateTime), CAST(N'2021-01-10T10:51:21.000' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (2, N'Home Appliances ', N'Home Appliances ', N'', 2, 1, 2, 1, 1, 1, CAST(N'2021-01-10T09:16:05.720' AS DateTime), CAST(N'2021-01-10T09:16:05.873' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (3, N'Mobile Phone', N'Mobile Phone', N'', 2, 1, 2, 1, 1, 1, CAST(N'2021-01-10T09:18:26.870' AS DateTime), CAST(N'2021-01-10T09:18:26.987' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (4, N'Laptops', N'Laptops', N'', 2, 1, 2, 1, 1, 1, CAST(N'2021-01-10T09:20:58.350' AS DateTime), CAST(N'2021-01-10T09:20:58.460' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (5, N'Kitchen Appliances ', N'Kitchen Appliances ', N'', 2, 2, 2, 1, 1, 1, CAST(N'2021-01-10T09:23:06.430' AS DateTime), CAST(N'2021-01-10T09:23:06.547' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (6, N'Misc Appliances', N'Misc Appliances', N'', 2, 2, 2, 1, 1, 1, CAST(N'2021-01-10T09:25:03.823' AS DateTime), CAST(N'2021-01-10T09:29:49.363' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (7, N'Refrigerators', N'Refrigerators', N'', 2, 5, 2, 1, 1, 1, CAST(N'2021-01-10T09:25:52.460' AS DateTime), CAST(N'2021-01-10T09:25:52.610' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (8, N'Microwave Oven', N'Microwave Oven', N'', 2, 5, 2, 1, 1, 1, CAST(N'2021-01-10T09:27:08.663' AS DateTime), CAST(N'2021-01-10T09:27:08.787' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (9, N'Iron', N'Iron', N'', 2, 6, 2, 1, 1, 1, CAST(N'2021-01-10T09:27:51.920' AS DateTime), CAST(N'2021-01-10T09:27:52.067' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (10, N'Hair Dryer', N'Hair Dryer', N'', 2, 6, 2, 1, 1, 1, CAST(N'2021-01-10T09:29:07.947' AS DateTime), CAST(N'2021-01-10T09:29:08.083' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (11, N'2 in 1 Convertible Laptop', N'2 in 1 Convertible Laptop', N'', 2, 4, 2, 1, 1, 1, CAST(N'2021-01-10T09:31:03.783' AS DateTime), CAST(N'2021-01-10T09:31:03.927' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (12, N'Touch Screen Laptops', N'Touch Screen Laptops', N'', 2, 4, 2, 1, 1, 1, CAST(N'2021-01-10T09:31:37.300' AS DateTime), CAST(N'2021-01-10T09:31:37.457' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (13, N'Android Phones', N'Android Phones', N'', 2, 3, 2, 1, 1, 1, CAST(N'2021-01-10T09:32:21.553' AS DateTime), CAST(N'2021-01-10T09:32:21.723' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (14, N'Apple iPhone', N'Apple iPhone', N'', 2, 3, 2, 1, 1, 1, CAST(N'2021-01-10T09:33:48.587' AS DateTime), CAST(N'2021-01-10T09:33:48.720' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (15, N'Food and Drinks', N'Food and Drinks', N'icon-category-garden', 1, NULL, 2, 1, 1, 1, CAST(N'2021-01-10T10:08:56.377' AS DateTime), CAST(N'2021-01-10T10:08:56.527' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (16, N'Fast Food', N'Fast Food', N'', 2, 15, 2, 1, 1, 1, CAST(N'2021-01-10T10:11:15.653' AS DateTime), CAST(N'2021-01-10T10:11:15.763' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (17, N'Soft Drinks', N'Soft Drinks', N'', 2, 15, 2, 1, 1, 1, CAST(N'2021-01-10T10:11:42.367' AS DateTime), CAST(N'2021-01-10T10:11:42.470' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (18, N'Baked Items', N'Baked Items', N'', 2, 15, 2, 1, 1, 1, CAST(N'2021-01-10T10:12:33.493' AS DateTime), CAST(N'2021-01-10T10:12:33.607' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (19, N'Burgers', N'Burgers', N'', 2, 16, 2, 1, 1, 1, CAST(N'2021-01-10T10:13:12.363' AS DateTime), CAST(N'2021-01-10T10:13:12.503' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (20, N'Pizza', N'Pizza', N'', 2, 16, 2, 1, 1, 1, CAST(N'2021-01-10T10:14:08.547' AS DateTime), CAST(N'2021-01-10T10:14:08.673' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (21, N'Bread', N'Bread', N'', 2, 18, 2, 1, 1, 1, CAST(N'2021-01-10T10:15:01.717' AS DateTime), CAST(N'2021-01-10T10:15:01.860' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (22, N'Cake', N'Cake', N'', 2, 18, 2, 1, 1, 1, CAST(N'2021-01-10T10:15:37.460' AS DateTime), CAST(N'2021-01-10T10:15:37.567' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (23, N'Fashion and Dresses', N'Fashion and Dresses', N'icon-category-fashion', 1, NULL, 2, 1, 1, 1, CAST(N'2021-01-10T10:20:02.450' AS DateTime), CAST(N'2021-01-10T10:55:51.110' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (24, N'Men''s  Dresses', N'Men''s  Dresses', N'', 2, 23, 2, 1, 1, 1, CAST(N'2021-01-10T10:20:51.433' AS DateTime), CAST(N'2021-01-10T10:20:51.593' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (25, N'Women''s Dresses', N'Women''s Dresses', N'', 2, 23, 2, 1, 1, 1, CAST(N'2021-01-10T10:21:24.860' AS DateTime), CAST(N'2021-01-10T10:21:25.020' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (26, N'Men''s Shirts', N'Men''s Shirts', N'', 2, 24, 2, 1, 1, 1, CAST(N'2021-01-10T10:22:10.893' AS DateTime), CAST(N'2021-01-10T10:22:11.037' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (27, N'Men''s Caps', N'Men''s Caps', N'', 2, 24, 2, 1, 1, 1, CAST(N'2021-01-10T10:22:49.630' AS DateTime), CAST(N'2021-01-10T10:22:49.770' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (28, N'Women''s Tops', N'Women''s Tops', N'', 2, 25, 2, 1, 1, 1, CAST(N'2021-01-10T10:23:17.710' AS DateTime), CAST(N'2021-01-10T10:23:17.893' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (29, N'Jewelry ', N'Jewelry ', N'', 2, 25, 2, 1, 1, 1, CAST(N'2021-01-10T10:24:26.873' AS DateTime), CAST(N'2021-01-10T10:24:27.093' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategoryPair] ON 
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (1, 2, 26, 1)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (2, 2, 23, 0)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (3, 2, 24, 0)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (4, 3, 13, 1)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (5, 3, 1, 0)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (6, 3, 3, 0)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (9, 1, 11, 1)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (10, 1, 1, 0)
GO
INSERT [dbo].[ProductCategoryPair] ([ProductCategoryPairID], [ProductID], [CategoryID], [IsDefault]) VALUES (11, 1, 4, 0)
GO
SET IDENTITY_INSERT [dbo].[ProductCategoryPair] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierDeliveryOptionPair] ON 
GO
INSERT [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID], [SupplierID], [DeliveryOptionID], [DeliveryCharges], [MinOrderLimit], [SurroundingCitiesIDs]) VALUES (1, 1, 1, 0, 0, N'')
GO
INSERT [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID], [SupplierID], [DeliveryOptionID], [DeliveryCharges], [MinOrderLimit], [SurroundingCitiesIDs]) VALUES (2, 1, 2, 5, 100, N'')
GO
INSERT [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID], [SupplierID], [DeliveryOptionID], [DeliveryCharges], [MinOrderLimit], [SurroundingCitiesIDs]) VALUES (3, 1, 3, 8, 300, N'21,24')
GO
INSERT [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID], [SupplierID], [DeliveryOptionID], [DeliveryCharges], [MinOrderLimit], [SurroundingCitiesIDs]) VALUES (4, 1, 4, 20, 500, N'')
GO
SET IDENTITY_INSERT [dbo].[SupplierDeliveryOptionPair] OFF
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([AddressID], [ProfileID], [AddressTypeID], [PlotNumber], [StreetNumber], [CountryID], [ProvinceID], [CityID], [LocationID], [NearestLandmark], [PostalCode], [MapLink], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (1, 2, 1, N'sdhfgsdgsdlfg', N'slkfhgskfhskfhk', 0, 2, 21, 21, N'skjfhkdghkshskjh', N'12345', N'sdkfsfgsggfs', CAST(N'2021-01-10T13:30:47.373' AS DateTime), 1, CAST(N'2021-01-10T13:30:47.373' AS DateTime), 1)
GO
INSERT [dbo].[Address] ([AddressID], [ProfileID], [AddressTypeID], [PlotNumber], [StreetNumber], [CountryID], [ProvinceID], [CityID], [LocationID], [NearestLandmark], [PostalCode], [MapLink], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (2, 1, 1, N'sadasdad', N'53 Equator Crescent', 0, 2, 21, 0, N'sdfsdfsdfsfs', N'L6A2Y9', N'', CAST(N'2021-01-10T15:58:16.763' AS DateTime), 1, CAST(N'2021-01-10T15:58:16.763' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Tax] ON 
GO
INSERT [dbo].[Tax] ([TaxID], [TaxValue], [TaxTypeID], [Description], [StatusID], [IsPercentage], [LocationLevelId], [LocationId], [EffectiveDate], [LastModifiedDateTime], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime]) VALUES (1, 12, 1, N'GST', 2, 1, 1, 0, CAST(N'2020-12-08T15:52:00.000' AS DateTime), CAST(N'2020-12-05T15:52:51.523' AS DateTime), 1, 1, CAST(N'2020-12-05T15:52:51.523' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Tax] OFF
GO
SET IDENTITY_INSERT [dbo].[Attribute] ON 
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Color', N'Color', 1, 10, 1, N'White', 1, 1, 2, 1, 1, CAST(N'2020-12-22T19:56:15.553' AS DateTime), CAST(N'2020-12-22T19:56:15.553' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (4, N'Size', N'Size', 1, 11, 0, N'0', 1, 1, 2, 1, 1, CAST(N'2021-01-10T10:33:11.770' AS DateTime), CAST(N'2021-01-10T10:33:11.770' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (5, N'Material', N'Material', 2, 4, 0, N'Metal, Wood, Plastic etc.', 1, 1, 2, 1, 1, CAST(N'2021-01-10T10:36:13.463' AS DateTime), CAST(N'2021-01-10T10:36:13.463' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (6, N'Dimentions', N'Dimentions', 2, 12, 0, N'2x2x2', 1, 1, 2, 1, 1, CAST(N'2021-01-10T10:37:05.717' AS DateTime), CAST(N'2021-01-10T10:37:05.717' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (7, N'Weight', N'Weight', 2, 13, 0, N'Light, Heavy ', 1, 1, 2, 1, 1, CAST(N'2021-01-10T10:38:03.890' AS DateTime), CAST(N'2021-01-10T10:38:03.890' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (8, N'Taste', N'Taste', 2, 4, 0, N'Sweet, Spicy, Saltish', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:19:02.943' AS DateTime), CAST(N'2021-01-10T11:19:02.943' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (9, N'Origion', N'Origion', 2, 4, 0, N'Thai, Italian etc', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:21:44.223' AS DateTime), CAST(N'2021-01-10T11:21:44.223' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (10, N'Rated Power', N'Rated Power', 1, 4, 0, N'100 W', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:27:19.633' AS DateTime), CAST(N'2021-01-10T11:27:19.633' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (11, N'CAPACITY', N'CAPACITY', 1, 4, 0, N'100 L', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:28:34.783' AS DateTime), CAST(N'2021-01-10T11:28:34.783' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (12, N'Processor / CPU', N'Processor / CPU', 1, 4, 0, N'Intel', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:32:31.053' AS DateTime), CAST(N'2021-01-10T11:32:31.053' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (13, N'RAM / Memory', N'RAM / Memory', 1, 4, 0, N'16 GB', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:44:43.010' AS DateTime), CAST(N'2021-01-10T11:44:43.010' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (14, N'Form Facctor', N'Form Factor', 2, 4, 0, N'Laptop, Tablet, Mobile, Watch', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:46:17.447' AS DateTime), CAST(N'2021-01-10T11:46:17.447' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (15, N'Collar Type', N'Collar Type', 2, 4, 0, N'Straight, Classic, Modern ', 1, 1, 2, 1, 1, CAST(N'2021-01-10T11:58:23.867' AS DateTime), CAST(N'2021-01-10T11:58:23.867' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (16, N'Cuff Style', N'Cuff Style', 1, 4, 0, N'Rounded, Folded', 1, 1, 2, 1, 1, CAST(N'2021-01-10T12:05:18.890' AS DateTime), CAST(N'2021-01-10T12:05:18.890' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (17, N'Dress Occasion ', N'Dress Occasion ', 2, 4, 0, N'Fancy, Formal, Bridal ', 1, 1, 2, 1, 1, CAST(N'2021-01-10T12:07:54.570' AS DateTime), CAST(N'2021-01-10T12:07:54.570' AS DateTime), 1)
GO
INSERT [dbo].[Attribute] ([AttributeID], [AttributeTitle], [Description], [AttributeTypeID], [DataTypeID], [DataTypeSize], [DefaultValue], [IsMandatory], [IsMultiSelect], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (18, N'Fabric', N'Fabric', 2, 4, 0, N'Silk, Lawn, Khaddar', 1, 1, 2, 1, 1, CAST(N'2021-01-10T12:13:26.433' AS DateTime), CAST(N'2021-01-10T12:13:26.433' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Attribute] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryAttributePair] ON 
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (1, 1, 1, N'Black', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (2, 1, 1, N'White', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (4, 1, 6, N'3x6', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (5, 1, 6, N'4x8', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (6, 1, 6, N'2x7', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (7, 1, 7, N'100 KG', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (8, 1, 7, N'200 KG', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (9, 1, 7, N'10 KG', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (10, 1, 4, N'Small', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (11, 1, 4, N'Medium', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (12, 1, 4, N'Large', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (13, 1, 4, N'Extra Large', 4, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (14, 23, 1, N'Red', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (15, 23, 1, N'Green', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (16, 23, 1, N'Blue', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (17, 23, 1, N'Pink', 4, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (18, 23, 4, N'Kids', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (19, 23, 4, N'Adults', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (20, 15, 8, N'Sweet', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (21, 15, 8, N'Saltish', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (22, 15, 8, N'Spicy', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (23, 15, 9, N'Thai', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (24, 15, 9, N'Italian', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (25, 2, 10, N'100 W', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (26, 2, 10, N'250 W', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (27, 2, 11, N'100 L', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (28, 2, 11, N'300 L', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (29, 4, 12, N'Intel', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (30, 4, 12, N'Apple M1', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (31, 4, 12, N'ARM', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (32, 4, 13, N'8 GB', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (33, 4, 13, N'16 GB', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (34, 4, 13, N'64 GB ', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (35, 4, 14, N'Laptop', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (36, 4, 14, N'Tablet', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (37, 3, 12, N'Qualcomm', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (38, 3, 12, N'Broadcom', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (39, 3, 13, N'2 GB', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (40, 3, 13, N'3 GB', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (41, 3, 13, N'4 GB', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (42, 3, 14, N'Phone', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (43, 3, 14, N'Watch', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (44, 24, 15, N'Straight', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (45, 24, 15, N'Classic', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (46, 24, 15, N'Modern ', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (47, 24, 16, N'Rounded', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (48, 24, 16, N'Foldded', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (49, 25, 17, N'Fancy', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (50, 25, 17, N'Formal', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (51, 25, 17, N'Bridal', 3, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (52, 25, 18, N'Silk', 1, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (53, 25, 18, N'Lawn', 2, 1)
GO
INSERT [dbo].[CategoryAttributePair] ([CategoryAttributePairID], [CategoryID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned]) VALUES (54, 25, 18, N'Khaddar', 3, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryAttributePair] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 
GO
INSERT [dbo].[Schedule] ([ScheduleID], [SupplierID], [ScheduleTypeID], [IsException], [WeekDays], [FromDay], [ToDay], [Month], [MonthDay], [StatusID], [Notes], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (1, 1, 1, 1, N'Thu', NULL, NULL, NULL, NULL, 1, N'', 1, CAST(N'2021-01-10T16:06:24.427' AS DateTime), 1, CAST(N'2021-01-10T16:07:19.257' AS DateTime))
GO
INSERT [dbo].[Schedule] ([ScheduleID], [SupplierID], [ScheduleTypeID], [IsException], [WeekDays], [FromDay], [ToDay], [Month], [MonthDay], [StatusID], [Notes], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (2, 1, 1, 0, N'Sat,Sun', NULL, NULL, NULL, NULL, 1, N'', 1, CAST(N'2021-01-10T16:06:42.020' AS DateTime), 1, CAST(N'2021-01-10T16:06:57.653' AS DateTime))
GO
INSERT [dbo].[Schedule] ([ScheduleID], [SupplierID], [ScheduleTypeID], [IsException], [WeekDays], [FromDay], [ToDay], [Month], [MonthDay], [StatusID], [Notes], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (3, 1, 2, 1, N'', 5, 6, NULL, NULL, 1, N'', 1, CAST(N'2021-01-10T16:07:42.390' AS DateTime), 1, CAST(N'2021-01-10T16:07:42.390' AS DateTime))
GO
INSERT [dbo].[Schedule] ([ScheduleID], [SupplierID], [ScheduleTypeID], [IsException], [WeekDays], [FromDay], [ToDay], [Month], [MonthDay], [StatusID], [Notes], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (4, 1, 3, 0, N'', NULL, NULL, 10, 15, 1, N'', 1, CAST(N'2021-01-10T16:08:11.947' AS DateTime), 1, CAST(N'2021-01-10T16:08:11.947' AS DateTime))
GO
INSERT [dbo].[Schedule] ([ScheduleID], [SupplierID], [ScheduleTypeID], [IsException], [WeekDays], [FromDay], [ToDay], [Month], [MonthDay], [StatusID], [Notes], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (5, 1, 3, 0, N'', NULL, NULL, 4, 5, 1, N'', 1, CAST(N'2021-01-10T16:08:24.267' AS DateTime), 1, CAST(N'2021-01-10T16:08:24.267' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductAttributePair] ON 
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (1, 2, 1, N'Blue', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (2, 2, 1, N'Green', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (3, 2, 1, N'Pink', 0, 1, 1, 2)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (4, 2, 1, N'Red', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (5, 2, 4, N'Adults', 0, 1, 1, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (6, 2, 4, N'Kids', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (7, 2, 15, N'Classic', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (8, 2, 15, N'Modern ', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (9, 2, 15, N'Straight', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (10, 2, 16, N'Foldded', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (11, 2, 16, N'Rounded', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (12, 3, 1, N'Black', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (13, 3, 1, N'White', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (14, 3, 4, N'Extra Large', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (15, 3, 4, N'Large', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (16, 3, 4, N'Medium', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (17, 3, 4, N'Small', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (18, 3, 6, N'2x7', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (19, 3, 6, N'3x6', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (20, 3, 6, N'4x8', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (21, 3, 7, N'10 KG', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (22, 3, 7, N'100 KG', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (23, 3, 7, N'200 KG', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (24, 3, 12, N'Broadcom', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (25, 3, 12, N'Qualcomm', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (26, 3, 13, N'2 GB', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (27, 3, 13, N'3 GB', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (28, 3, 13, N'4 GB', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (29, 3, 14, N'Phone', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (30, 3, 14, N'Watch', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (36, 1, 1, N'Black', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (37, 1, 1, N'White', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (38, 1, 4, N'Extra Large', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (39, 1, 4, N'Large', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (40, 1, 4, N'Medium', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (41, 1, 4, N'Small', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (42, 1, 6, N'2x7', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (43, 1, 6, N'3x6', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (44, 1, 6, N'4x8', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (45, 1, 7, N'10 KG', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (46, 1, 7, N'100 KG', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (47, 1, 7, N'200 KG', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (48, 1, 12, N'Apple M1', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (49, 1, 12, N'ARM', 0, 1, 1, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (50, 1, 12, N'Intel', 0, 1, 1, 100)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (51, 1, 13, N'16 GB', 0, 1, 1, 80)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (52, 1, 13, N'64 GB ', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (53, 1, 13, N'8 GB', 0, 1, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (54, 1, 14, N'Laptop', 0, 0, 0, 0)
GO
INSERT [dbo].[ProductAttributePair] ([ProductAttributePairID], [ProductID], [AttributeID], [AttributeValue], [DisplayOrder], [IsAssigned], [IsSelectedForVariation], [VariationInPrice]) VALUES (55, 1, 14, N'Tablet', 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[ProductAttributePair] OFF
GO
