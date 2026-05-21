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
SET IDENTITY_INSERT [dbo].[Profile] ON 
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID]) VALUES (1, 1, N'admin', NULL, NULL, NULL, NULL, NULL, NULL, N'', 0, 3)
GO
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 
GO
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeTitle], [ProductTypeDescription], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Physical Products', N'Physical Products', 1, 1, 1, CAST(N'2020-09-12T10:02:48.103' AS DateTime), CAST(N'2020-09-12T10:02:48.103' AS DateTime), 1)
GO
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeTitle], [ProductTypeDescription], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (2, N'Digital Product', N'Digital Product', 1, 1, 1, CAST(N'2020-09-12T10:03:14.357' AS DateTime), CAST(N'2020-09-12T10:03:14.357' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
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
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (1, N'Weekly', N'Recurring on every week day', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (2, N'Monthly', N'recuring on specified range of dates within a month', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (3, N'Yearly', N'Specific dates only within a year', 1)
GO
SET IDENTITY_INSERT [dbo].[DataType] ON 
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (0, N'System', N'System', N'int', N'Numeric Integer', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (1, N'System', N'System', N'Count', N'Numeric Integer', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (2, N'System', N'System', N'bool', N'Logical - True/False, Yes/No', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (3, N'System', N'System', N'float', N'Numeric Decimal (Currency, Measurments)', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (4, N'System', N'System', N'string', N'alpha numberic & misc symbols', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (5, N'System', N'System', N'Curerncy', N'Curerncy', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (6, N'System', N'System', N'Date Only', N'Date Only', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (7, N'System', N'System', N'Time Only', N'Time Only', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (8, N'System', N'System', N'Date and Time Both', N'Dat and Time (both)', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (9, N'System', N'System', N'Password', N'Password', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (10, N'System', N'System', N'Color', N'Color', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (11, N'System', N'System', N'Area', N'Dimention / Size ', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (12, N'System', N'System', N'Volume', N'Volume', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (13, N'System', N'System', N'Weight', N'Weight', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (14, N'System', N'System', N'Dozen', N'Dozen/Counting', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (15, N'System', N'System', N'Hours', N'Hours/Duration', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (16, N'System', N'System', N'Days', N'Days/Duration', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (17, N'System', N'System', N'Weeks', N'Weeks/Duration', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (18, N'System', N'System', N'Months', N'Months/Duration', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (19, N'System', N'System', N'Years', N'Years/Duration', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (20, N'System', N'System', N'Domain Name', N'Domain Name / URL / Web Link', 1)
GO
INSERT [dbo].[DataType] ([DataTypeID], [AssemblyName], [Namespace], [ClassName], [FriendlyName], [IsSystem]) VALUES (21, N'System', N'System', N'email', N'email', 1)
GO
SET IDENTITY_INSERT [dbo].[DataType] OFF
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
SET IDENTITY_INSERT [dbo].[CategoryType] ON 
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (1, N'Main Category', N'Home page display', 1, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (2, N'Sub category', N'Home Page Menu', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryType] OFF
GO
SET IDENTITY_INSERT [dbo].[AttributeType] ON 
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (1, N'Customization Attribute', N'Customization Attribute', 1)
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (2, N'Specification Attribute', N'Specification Attribute', 1)
GO
SET IDENTITY_INSERT [dbo].[AttributeType] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (0, N'Anonymous', N'Anonymous User', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (1, N'Buyer', N'default', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (2, N'Shop', N'optional', 1)
GO
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeTitle], [Description], [IsSystem]) VALUES (3, N'Admin', N'back end user', 1)
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO




SET IDENTITY_INSERT [dbo].[Country] ON 
GO
	INSERT [dbo].[Country] ([Id], [Name], [AllowsBilling], [AllowsShipping], [TwoLetterIsoCode], [ThreeLetterIsoCode], [NumericIsoCode], [SubjectToVat], [Published], [DisplayOrder], [LimitedToStores]) 
	VALUES (2, N'Canada', 1, 1, NULL, NULL, 12, 1, 1, 12, 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Currency] ON 
GO
	INSERT [dbo].[Currency] ([CurrencyId], [Name], [CurrencyCode], [Rate], [DisplayLocale], [CustomFormatting], [LimitedToStores], [Published], [DisplayOrder], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [RoundingTypeId]) 
	VALUES (7, N'Dollar', N'1', CAST(1.0000 AS Decimal(18, 4)), NULL, NULL, 1, 1, 1, CAST(N'2020-09-07T12:41:29.963' AS DateTime), 1, CAST(N'2020-09-07T12:41:29.963' AS DateTime), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[Language] ON 
GO
	INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Rtl], [LimitedToStores], [DefaultCurrencyId], [Published], [DisplayOrder]) 
	VALUES (1, N'English', N'English', NULL, NULL, 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
