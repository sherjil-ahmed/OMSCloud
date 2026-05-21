SET IDENTITY_INSERT [dbo].[TaxType] ON 
GO
INSERT [dbo].[TaxType] ([TaxTypeID], [TaxTypeTitle], [Description], [IsSystem]) VALUES (1, N'GST', N'General Sales Tax', 1)
GO
SET IDENTITY_INSERT [dbo].[TaxType] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 
GO
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeTitle], [ProductTypeDescription], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Physical Products', N'Physical Products', 1, 1, 1, CAST(N'2020-09-12T10:02:48.103' AS DateTime), CAST(N'2020-09-12T10:02:48.103' AS DateTime), 1)
GO
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeTitle], [ProductTypeDescription], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (2, N'Digital Product', N'Digital Product', 1, 1, 1, CAST(N'2020-09-12T10:03:14.357' AS DateTime), CAST(N'2020-09-12T10:03:14.357' AS DateTime), 1)
GO
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeTitle], [ProductTypeDescription], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (3, N'Services', N'Services', 1, 1, 1, CAST(N'2020-09-12T10:02:48.103' AS DateTime), CAST(N'2020-09-12T10:02:48.103' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [ManufacturerName], [Description], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Test Brand', N'Test Brand', N'Test Brand', 2, 1, 1, CAST(N'2020-11-16T12:48:32.183' AS DateTime), CAST(N'2020-11-16T12:48:32.183' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Profile] ON 
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID]) VALUES (1, 1, N'admin', N'admin', N'admin', N'admin', N'admin', N'admin', N'admin', NULL, 0, 3)
GO
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[MediaContentType] ON 
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (1, N'Prograsive web images', N'image/webp', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (2, N'Portable Network Graphics', N'image/png', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (3, N'JPEG Image', N'image/jpeg', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (4, N'GIF Image', N'image/gif', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (5, N'Icon Image', N'image/x-icon', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (6, N'BMP Bitmap Image', N'image/bmp', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (7, N'Scalable Vector Graphics', N'image/svg+xml', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (8, N'PDF Files', N'text/pdf', N'', N'', 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (9, N'Adobe Flash', N'	application/x-shockwave-flash', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (10, N'MPEG Audio', N'audio/mpeg', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (11, N'MPEG Video', N'video/mpeg', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (12, N'JPEG Image', N'image/jpeg', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (13, N'GIF Image', N'image/gif', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (14, N'Flash Video', N'video/x-flv', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (15, N'Audio Video Interleave (AVI)', N'video/x-msvideo', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (16, N'3 GP', N'video/3gpp', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (17, N'HyperText Markup Language (HTML)', N'text/html', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (18, N' JavaScript', N'application/javascript', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (19, N'JavaScript Object Notation (JSON)', N'application/json', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (20, N'Microsoft Windows Media Video', N'video/x-ms-wmv', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (21, N'MS WORD', N'application/msword', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (22, N'MPEG-4 Video', N'video/mp4', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (23, N'MPEG4', N'application/mp4', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (24, N'MPEG-4 Audio', N'audio/mp4', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (25, N'Quicktime Video', N'video/quicktime', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (26, N'RAR Archive', N'application/x-rar-compressed', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (27, N'RealVNC', N'application/vnd.realvnc.bed', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (28, N'Rich Text Format', N'application/rtf', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (29, N'Rich Text Format (RTF)', N'text/richtext', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (30, N'Text File', N'text/plain', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (31, N'ZIP Compressed File', N'application/zip', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (32, N'XML', N'application/xml', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (33, N'XHTML - The Extensible HyperText Markup Language', N'application/xhtml+xml', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (34, N'MS Excel', N'application/vnd.ms-excel', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (35, N'bittorrent', N'application/x-bittorrent', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (36, N'Binary Data', N'application/octet-stream', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (37, N'7-Zip', N'application/x-7z-compressed', N'', NULL, 1)
GO
INSERT [dbo].[MediaContentType] ([MediaContentTypeID], [DisplayText], [HTMLContentTypeText], [Description], [IconPath], [IsSystem]) VALUES (38, N'CSS', N'text/css', N'', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[MediaContentType] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentType] ON 
GO
INSERT [dbo].[DocumentType] ([DocumentTypeID], [DocumentTypeTitle], [Description], [IsSystem]) VALUES (1, N'Passport', N'Passport', 1)
GO
INSERT [dbo].[DocumentType] ([DocumentTypeID], [DocumentTypeTitle], [Description], [IsSystem]) VALUES (2, N'Driving License', N'Driving License', 1)
GO
INSERT [dbo].[DocumentType] ([DocumentTypeID], [DocumentTypeTitle], [Description], [IsSystem]) VALUES (3, N'Nation Identify Card', N'Nation Identify Card', 1)
GO
INSERT [dbo].[DocumentType] ([DocumentTypeID], [DocumentTypeTitle], [Description], [IsSystem]) VALUES (4, N'Utility Bill', N'Utility Bill', 1)
GO
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[VerificationStatus] ON 
GO
INSERT [dbo].[VerificationStatus] ([VerificationStatusID], [VerificationStatusTitle], [Description], [IsSystem]) VALUES (1, N'UnVerified', N'UnVerified / New', 1)
GO
INSERT [dbo].[VerificationStatus] ([VerificationStatusID], [VerificationStatusTitle], [Description], [IsSystem]) VALUES (2, N'Verified', N'Verified / Active', 1)
GO
INSERT [dbo].[VerificationStatus] ([VerificationStatusID], [VerificationStatusTitle], [Description], [IsSystem]) VALUES (3, N'Rejected', N'Rejected / InActive', 1)
GO
INSERT [dbo].[VerificationStatus] ([VerificationStatusID], [VerificationStatusTitle], [Description], [IsSystem]) VALUES (4, N'BlackListed', N'BlackListed / Deleted', 1)
GO
SET IDENTITY_INSERT [dbo].[VerificationStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryType] ON 
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (1, N'Main Category', N'Home page display', 1, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (2, N'Sub category', N'Home Page Menu', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryType] OFF
GO
SET IDENTITY_INSERT [dbo].[OptionType] ON 
GO
INSERT [dbo].[OptionType] ([OptionTypeID], [OptionTypeTitle], [Description], [OptionLevel]) VALUES (1, N'Menu', N'Admin Menu Only', 1)
GO
SET IDENTITY_INSERT [dbo].[OptionType] OFF
GO
SET IDENTITY_INSERT [dbo].[Option] ON 
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (0, N'Root', N'Root', N'', N'', N'', 1, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.417' AS DateTime), CAST(N'2021-01-10T06:51:06.417' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (1, N'Dashboard', N'Dashboard', N'fa fa-home', N'/Admin/Index', N'', 1, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.417' AS DateTime), CAST(N'2021-01-10T06:51:06.417' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (2, N'Report', N'Report', N'', N'/Admin/Report', N'', 1, 1, 1, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (3, N'Chart', N'Chart', N'', N'/Admin/Chart', N'', 1, 1, 1, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (4, N'Stats', N'Stats', N'', N'/Admin/Stats', N'', 1, 1, 1, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (5, N'Catalogue Management', N'Catalogue Management', N'fa fa-columns', N'', N'', 1, 1, 0, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (6, N'Product', N'Product', N'', N'/Admin/Product', N'', 1, 1, 5, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (7, N'Category', N'Category', N'', N'/Admin/Category', N'', 1, 1, 5, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (8, N'Attribute', N'Attribute', N'', N'/Admin/Attribute', N'', 1, 1, 5, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (9, N'Shop Management', N'Shop Management', N'fa fa-columns', N'', N'', 1, 1, 0, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (10, N'Shop', N'Shop', N'', N'/Admin/Supplier', N'', 1, 1, 9, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (11, N'Shop Delivery Setup', N'Shop Delivery Setup', N'', N'/Admin/SupplierDeliveryOptionPair', N'', 1, 1, 9, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (12, N'Shop Delivery Schedule', N'Shop Delivery Schedule', N'', N'/Admin/ShopDeliverySchedule', N'', 1, 1, 9, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (13, N'Order Management', N'Order Management', N'fa fa-list-alt', N'', N'', 1, 1, 0, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.427' AS DateTime), CAST(N'2021-01-10T06:51:06.427' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (14, N'Order By Status', N'Order By Status', N'', N'', N'', 1, 1, 13, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.427' AS DateTime), CAST(N'2021-01-10T06:51:06.427' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (15, N'All Orders', N'All Orders', N'', N'/Admin/Order', N'', 1, 1, 14, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.427' AS DateTime), CAST(N'2021-01-10T06:51:06.427' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (16, N'Unpaid Orders', N'Unpaid Orders', N'', N'/Admin/Order?orderStatusID=3', N'', 1, 1, 14, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.427' AS DateTime), CAST(N'2021-01-10T06:51:06.427' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (17, N'New Orders', N'New Orders', N'', N'/Admin/Order?orderStatusID=4', N'', 1, 1, 14, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (18, N'Inprocess Orders ', N'Inprocess Orders ', N'', N'/Admin/Order?orderStatusID=5', N'', 1, 1, 14, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (19, N'Ready to Ship Orders', N'Ready to Ship Orders', N'', N'/Admin/Order?orderStatusID=6', N'', 1, 1, 14, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (20, N'Delivered Orders', N'Delivered Orders', N'', N'/Admin/Order?orderStatusID=8', N'', 1, 1, 14, 6, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (21, N'Completed Orders', N'Completed Orders', N'', N'/Admin/Order?orderStatusID=10', N'', 1, 1, 14, 7, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (22, N'Disputed Orders', N'Disputed Orders', N'', N'', N'', 1, 1, 13, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (23, N'Order Delivery Failed ', N'Order Delivery Failed ', N'', N'/Admin/Order?orderStatusID=11', N'', 1, 1, 22, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.430' AS DateTime), CAST(N'2021-01-10T06:51:06.430' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (24, N'Order Delivered with Issues', N'Order Delivered with Issues', N'', N'/Admin/Order?orderStatusID=12', N'', 1, 1, 22, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (25, N'Failed Orders', N'Failed Orders', N'', N'/Admin/Order?orderStatusID=13', N'', 1, 1, 22, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (26, N'User Management', N'User Management', N'fa fa-copy', N'', N'', 1, 1, 0, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (27, N'User Profile', N'User Profile', N'', N'/Admin/Profile', N'', 1, 1, 26, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (28, N'Profile Verification', N'Profile Verification', N'', N'/IndexAdmin/ProfileVerification', N'', 1, 1, 26, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (29, N'Address', N'Address', N'', N'/Admin/Address', N'', 1, 1, 26, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (30, N'Setup', N'Setup', N'', N'', N'', 1, 1, 0, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (31, N'Global Configuration', N'Global Configuration', N'', N'/Admin/AppConfig', N'', 1, 1, 30, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (32, N'General Status', N'General Status', N'', N'/Admin/Status', N'', 1, 1, 30, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (33, N'Product Type', N'Product Type', N'', N'/Admin/ProductType', N'', 1, 1, 30, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (34, N'Category Type', N'Category Type', N'', N'/Admin/CategoryType', N'', 1, 1, 30, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (35, N'Attribute Type', N'Attribute Type', N'', N'/Admin/AttributeType', N'', 1, 1, 30, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (36, N'Delivery Option', N'Delivery Option', N'', N'/Admin/DeliveryOption', N'', 1, 1, 30, 6, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (37, N'Tax Type', N'Tax Type', N'', N'/Admin/TaxType', N'', 1, 1, 30, 7, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (38, N'Tax', N'Tax', N'', N'/Admin/Tax', N'', 1, 1, 30, 8, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (39, N'Brand', N'Brand', N'', N'/Admin/Brand', N'', 1, 1, 30, 9, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (40, N'Data Type', N'Data Type', N'', N'/Admin/DataType', N'', 1, 1, 30, 10, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (41, N'Document Type', N'Document Type', N'', N'/Admin/DocumentType', N'', 1, 1, 30, 11, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (42, N'Order Status', N'Order Status', N'', N'/Admin/OrderStatus', N'', 1, 1, 30, 12, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.440' AS DateTime), CAST(N'2021-01-10T06:51:06.440' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (43, N'Order Status Map', N'Order Status Map', N'', N'/Admin/OrderStatusMap', N'', 1, 1, 30, 13, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (44, N'Security Management', N'Security Management', N'fa fa-key', N'', N'', 1, 1, 0, 6, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (45, N'User', N'User', N'', N'/Security/User', N'', 1, 1, 44, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (46, N'Role', N'Role', N'', N'/Security/Role', N'', 1, 1, 44, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (47, N'Permission', N'Permission', N'', N'/Security/Permission', N'', 1, 1, 44, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (48, N'Customer Review & Feedback', N'Customer Review & Feedback', N'', N'/Admin/Feedback', N'', 1, 1, 26, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (49, N'Chat', N'Chat', N'', N'/Admin/Chat', N'', 1, 1, 26, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.447' AS DateTime), CAST(N'2021-01-10T06:51:06.447' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (50, N'Cart Management', N'Cart Management', N'', N'/Admin/Cart', N'', 1, 1, 13, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.447' AS DateTime), CAST(N'2021-01-10T06:51:06.447' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleOptionPair] ON 
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (51, 1, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (52, 2, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (53, 3, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (54, 4, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (55, 5, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (56, 6, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (57, 7, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (58, 8, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (59, 9, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (60, 10, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (61, 11, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (62, 12, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (63, 13, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (64, 14, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (65, 15, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (66, 16, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (67, 17, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (68, 18, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (69, 19, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (70, 20, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (71, 21, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (72, 22, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (73, 23, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (74, 24, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (75, 25, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (76, 26, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (77, 27, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (78, 28, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (79, 29, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (80, 30, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (81, 31, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (82, 32, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (83, 33, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (84, 34, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (85, 35, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (86, 36, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (87, 37, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (88, 38, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (89, 39, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (90, 40, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (91, 41, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (92, 42, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (93, 43, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (94, 44, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (95, 45, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (96, 46, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (97, 47, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (98, 48, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (99, 49, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (100, 50, 5, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[RoleOptionPair] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (1, N'New Cart', N'New Cart', 1, 0)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (2, N'Cart Converted To Orders', N'Cart Converted To Orders', 1, 0)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (3, N'New Order', N'New Order', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (4, N'Order Placed', N'Order Placed', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (5, N'Order in Process', N'Order in Process', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (6, N'Order Dispatched / Ready for Pickup', N'Order Dispatched / Ready for Pickup', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (8, N'Order Delivered / Pickedup', N'Order Delivered / Pickedup', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (9, N'Order issue raised by Buyer', N'Order issue raised by Buyer', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (10, N'Order Completed (End/Closed)', N'Order Completed (End/Closed)', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (11, N'Order (Delivery / Puckup) Failed', N'Order (Delivery / Puckup) Failed', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (12, N'Order (Delivery / Puckup) Issues', N'Order (Delivery / Puckup) Issues', 1, 1)
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (13, N'Order Failed (End/Closed)', N'Order Failed (End/Closed)', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryOption] ON 
GO
INSERT [dbo].[DeliveryOption] ([DeliveryOptionID], [DeliveryOptionTitle], [Description], [IsSystem]) VALUES (1, N'Self Pickup', N'Self Pickup', 1)
GO
INSERT [dbo].[DeliveryOption] ([DeliveryOptionID], [DeliveryOptionTitle], [Description], [IsSystem]) VALUES (2, N'Deliver Within City', N'Deliver Within City', 1)
GO
INSERT [dbo].[DeliveryOption] ([DeliveryOptionID], [DeliveryOptionTitle], [Description], [IsSystem]) VALUES (3, N'Deliver Surrounding Cities', N'Deliver Surrounding Cities', 1)
GO
INSERT [dbo].[DeliveryOption] ([DeliveryOptionID], [DeliveryOptionTitle], [Description], [IsSystem]) VALUES (4, N'Deliver Across Country (Mail)', N'Deliver Across Country', 1)
GO
SET IDENTITY_INSERT [dbo].[DeliveryOption] OFF
GO
SET IDENTITY_INSERT [dbo].[AddressType] ON 
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [AddressTypeTitle], [Description], [IsSystem]) VALUES (1, N'Business Address', N'Commercial / Shop Address', 1)
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [AddressTypeTitle], [Description], [IsSystem]) VALUES (2, N'Personal Address', N'Non-Business Address: Shipping/Delivery or Billing Address etc.', 1)
GO
SET IDENTITY_INSERT [dbo].[AddressType] OFF
GO
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (1, N'Country', N'Country')
GO
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (2, N'Province', N'Province')
GO
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (3, N'City', N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (0, N'Canada', 0, 1, N'Country')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (1, N'Alberta', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (2, N'British Columbia', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (3, N'Manitoba', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (4, N' New Brunswick', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (5, N'Newfoundland and Labrador', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (6, N'Nova Scotia', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (7, N'Ontario', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (8, N'Prince Edward Island', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (9, N'Quebec', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (10, N'Saskatchewan', 0, 2, N'Province')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (11, N'Toronto', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (12, N'Ottawa', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (13, N'Mississauga', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (14, N'Brampton', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (15, N'Hamilton', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (16, N'London', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (17, N'Markham', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (18, N'Vaughan', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (19, N'Kitchener', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (20, N'Windsor', 7, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (21, N'Vancouver', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (22, N'Surrey', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (23, N'Burnaby', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (24, N'Richmond', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (25, N'Abbotsford', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (26, N'Coquitlam', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (27, N'Kelowna', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (28, N'Langley Township', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (29, N'Saanich', 2, 3, N'City')
GO
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (30, N'Delta', 2, 3, N'City')
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (0, N'Anonymous', N'Anonymous User', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (1, N'Buyer', N'Buyer', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (2, N'Shop', N'optional', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (3, N'Admin', N'back end user', 1)
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
SET IDENTITY_INSERT [dbo].[AttributeType] ON 
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (1, N'Customization Attribute', N'Customization Attribute', 1)
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (2, N'Specification Attribute', N'Specification Attribute', 1)
GO
SET IDENTITY_INSERT [dbo].[AttributeType] OFF
GO
SET IDENTITY_INSERT [dbo].[DataType] ON 
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (0, N'System', N'System', N'int', N'Numeric Integer', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (1, N'System', N'System', N'Count', N'Numeric Integer', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (2, N'System', N'System', N'bool', N'Logical - True/False, Yes/No', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (3, N'System', N'System', N'float', N'Numeric Decimal (Currency, Measurments)', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (4, N'System', N'System', N'string', N'alpha numberic & misc symbols', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (5, N'System', N'System', N'Curerncy', N'Curerncy', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (6, N'System', N'System', N'Date Only', N'Date Only', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (7, N'System', N'System', N'Time Only', N'Time Only', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (8, N'System', N'System', N'Date and Time Both', N'Dat and Time (both)', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (9, N'System', N'System', N'Password', N'Password', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (10, N'System', N'System', N'Color', N'Color', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (11, N'System', N'System', N'Area', N'Dimention / Size ', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (12, N'System', N'System', N'Volume', N'Volume', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (13, N'System', N'System', N'Weight', N'Weight', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (14, N'System', N'System', N'Dozen', N'Dozen/Counting', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (15, N'System', N'System', N'Hours', N'Hours/Duration', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (16, N'System', N'System', N'Days', N'Days/Duration', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (17, N'System', N'System', N'Weeks', N'Weeks/Duration', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (18, N'System', N'System', N'Months', N'Months/Duration', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (19, N'System', N'System', N'Years', N'Years/Duration', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (20, N'System', N'System', N'Domain Name', N'Domain Name / URL / Web Link', 1, NULL)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem], [SuggestedUIControl]) VALUES (21, N'System', N'System', N'email', N'email', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[DataType] OFF
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (1, N'Weekly', N'Recurring on every week day', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (2, N'Monthly', N'recuring on specified range of dates within a month', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (3, N'Yearly', N'Specific dates only within a year', 1)
GO
SET IDENTITY_INSERT [dbo].[PayType] ON 
GO
INSERT [dbo].[PayType] ([PayTypeID], [PayTypeTitle], [Description], [StatusID], [IsSystem]) VALUES (1, N'Cash', N'Cash Payment', 2, 1)
GO
INSERT [dbo].[PayType] ([PayTypeID], [PayTypeTitle], [Description], [StatusID], [IsSystem]) VALUES (2, N'Stripe', N'Stripe Payment', 2, 1)
GO
INSERT [dbo].[PayType] ([PayTypeID], [PayTypeTitle], [Description], [StatusID], [IsSystem]) VALUES (3, N'PayPal', N'PayPal Payment', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[PayType] OFF
GO
SET IDENTITY_INSERT [dbo].[AppConfig] ON 
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (1, N'Shop Preference', N'Shop Preference', N'Shop Preference', NULL, N'Shop Preference', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (2, N'CountryID', N'0', N'Default COUNTRY', 1, N'Country ID', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (3, N'Country Name', N'Canada', N'Canada', 1, N'Country Name', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (4, N'Zvonr Fees', N'Zvonr Fees', N'Zvonr Fees', NULL, N'Zvonr Fees', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (5, N'Currency Name', N'Canadian Dollar', N'Canadian Dollar', 1, N'Canadian Dollar', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (6, N'Currency Code', N'CAD', N'CAD', 1, N'Canadian Dollar', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (7, N'Currency Symbol', N'$', N'$', 1, N'$', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (8, N'Language Name', N'English (Canada)', N'English (Canada)', 1, N'English (Canada)', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (9, N'Language Code', N'en-ca', N'en-ca', 1, N'en-ca', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (10, N'ZvonrProcessingFee', N'5', N'5', 4, N'ZvonrProcessingFee', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (11, N'Is Processing Fee Percentage', N'true', N'true', 4, N'Is Processing Fee Percentage', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (12, N'Payment Gateway Fee', N'5', N'5', 4, N'Payment Gateway Fee', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (13, N'Is Payment Gateway Fee Percentage', N'true', N'true', 4, N'Is Payment Gateway Fee Percentage', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (14, N'Currency ID', N'0', N'Currency ID', 1, N'Currency ID', 1)
GO
INSERT [dbo].[AppConfig] ([ConfigID], [ConfigTitle], [ConfigValue], [DisplayText], [ParentConfigID], [Description], [IsSystem]) VALUES (15, N'Language ID', N'0', N'Language ID', 1, N'Language ID', 1)
GO
SET IDENTITY_INSERT [dbo].[AppConfig] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 
GO
INSERT [dbo].[Status] ([StatusID], [StatusName], [Description], [IsSystem]) VALUES (1, N'New', N'New', 1)
GO
INSERT [dbo].[Status] ([StatusID], [StatusName], [Description], [IsSystem]) VALUES (2, N'Active', N'Active, Approved, Enabled', 1)
GO
INSERT [dbo].[Status] ([StatusID], [StatusName], [Description], [IsSystem]) VALUES (3, N'In-Active', N'Disabled, Not Approved, Not available', 1)
GO
INSERT [dbo].[Status] ([StatusID], [StatusName], [Description], [IsSystem]) VALUES (4, N'Deleted', N'Mark-Deleted', 1)
GO
INSERT [dbo].[Status] ([StatusID], [StatusName], [Description], [IsSystem]) VALUES (5, N'Non', N'equivalent to Null', 1)
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
