USE [OMS_ZVONR_DB_16052021]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileID] [bigint] NOT NULL,
	[AddressTypeID] [int] NOT NULL,
	[PlotNumber] [nvarchar](100) NOT NULL,
	[StreetNumber] [nvarchar](100) NULL,
	[CountryID] [bigint] NULL,
	[ProvinceID] [bigint] NULL,
	[CityID] [bigint] NULL,
	[LocationID] [bigint] NOT NULL,
	[NearestLandmark] [nvarchar](200) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[MapLink] [varchar](1000) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED 
(
	[AddressTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppConfig]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfig](
	[ConfigID] [bigint] IDENTITY(1,1) NOT NULL,
	[ConfigTitle] [nvarchar](50) NOT NULL,
	[ConfigValue] [nvarchar](200) NOT NULL,
	[DisplayText] [nvarchar](50) NOT NULL,
	[ParentConfigID] [bigint] NULL,
	[Description] [nvarchar](500) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_AppConfig] PRIMARY KEY CLUSTERED 
(
	[ConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[AttributeID] [bigint] IDENTITY(1,1) NOT NULL,
	[AttributeTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[AttributeTypeID] [bigint] NOT NULL,
	[DataTypeID] [bigint] NOT NULL,
	[DataTypeSize] [bigint] NOT NULL,
	[DefaultValue] [nvarchar](500) NOT NULL,
	[IsMandatory] [bit] NOT NULL,
	[IsMultiSelect] [bit] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[AttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributeType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeType](
	[AttributeTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[AttributeTypeTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_AttributeType] PRIMARY KEY CLUSTERED 
(
	[AttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankAccount]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[BankId] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [bigint] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](max) NULL,
	[AccountTitle] [varchar](500) NOT NULL,
	[AccountNumber] [varchar](100) NOT NULL,
	[IBAN] [varchar](max) NULL,
 CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [bigint] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](100) NOT NULL,
	[ManufacturerName] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [bigint] NOT NULL,
	[BuyerProfileID] [bigint] NULL,
	[CartStatusID] [bigint] NULL,
	[StatusID] [bigint] NULL,
	[CartTotal] [float] NULL,
	[TaxTotal] [float] NULL,
	[DiscountTotal] [float] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[CartItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[CartOrderID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[TaxRateApplied] [float] NOT NULL,
	[TaxAmount] [float] NOT NULL,
	[DiscountAmount] [float] NOT NULL,
	[ItemTotalPrice] [float] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_CartProductPair] PRIMARY KEY CLUSTERED 
(
	[CartItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItemAttributePair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItemAttributePair](
	[CartItemAttributeId] [bigint] NOT NULL,
	[CartItemID] [bigint] NOT NULL,
	[AttributeID] [bigint] NOT NULL,
	[AttributeValue] [nvarchar](max) NOT NULL,
	[VariationInPrice] [float] NULL,
 CONSTRAINT [PK_CartItemAttribute] PRIMARY KEY CLUSTERED 
(
	[CartItemAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartOrder]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartOrder](
	[CartOrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [varchar](100) NULL,
	[ParentCartID] [bigint] NULL,
	[BuyerProfileID] [bigint] NOT NULL,
	[OrderStatusID] [bigint] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[DeliveryAddressID] [bigint] NULL,
	[DeliveryAddress] [varchar](5000) NULL,
	[OrderSupplierId] [bigint] NULL,
	[SupplierDeliveryOptionPairID] [bigint] NULL,
	[OrderTotal] [float] NOT NULL,
	[TaxTotal] [float] NOT NULL,
	[DeliveryTotal] [float] NOT NULL,
	[DiscountTotal] [float] NOT NULL,
	[PaymentTotal] [float] NOT NULL,
	[CalculatedPayout] [float] NOT NULL,
	[ActualPayout] [float] NOT NULL,
	[CalculatedPayIn] [float] NOT NULL,
	[ActualPayIn] [float] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[CartOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LogoPath] [nvarchar](max) NULL,
	[CategoryTypeID] [bigint] NOT NULL,
	[CategoryParentID] [bigint] NULL,
	[StatusID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Catagories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryAttributePair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryAttributePair](
	[CategoryAttributePairID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[AttributeID] [bigint] NOT NULL,
	[AttributeValue] [varchar](5000) NULL,
	[DisplayOrder] [bigint] NULL,
	[IsAssigned] [bit] NOT NULL,
 CONSTRAINT [PK_CategoryAttributePair] PRIMARY KEY CLUSTERED 
(
	[CategoryAttributePairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryType](
	[CategoryTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[StatusID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_CategoryTypes] PRIMARY KEY CLUSTERED 
(
	[CategoryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[ChatId] [bigint] IDENTITY(1,1) NOT NULL,
	[ChatCode] [nvarchar](max) NOT NULL,
	[ProfileId1] [bigint] NOT NULL,
	[ProfileId2] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[ChatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatMessage]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessage](
	[MessageId] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageCode] [varchar](50) NOT NULL,
	[ChatId] [bigint] NOT NULL,
	[SenderProfileId] [bigint] NOT NULL,
	[ReceiverProfileId] [bigint] NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[SentDateTime] [datetime] NOT NULL,
	[ReadDateTime] [nchar](10) NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[StatusId] [bigint] NOT NULL,
 CONSTRAINT [PK_ChatMessage] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerReview]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerReview](
	[CustomerReviewID] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectRowID] [bigint] NOT NULL,
	[SubjectID] [bigint] NOT NULL,
	[ReviewText] [nvarchar](max) NOT NULL,
	[Rating] [smallint] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerReview] PRIMARY KEY CLUSTERED 
(
	[CustomerReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataType](
	[DataTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[AssemblyName] [nvarchar](200) NOT NULL,
	[Namespace] [nvarchar](200) NOT NULL,
	[ClassName] [nvarchar](200) NOT NULL,
	[FriendlyName] [nvarchar](200) NULL,
	[IsSystem] [bit] NOT NULL,
	[SuggestedUIControl] [varchar](100) NULL,
 CONSTRAINT [PK_DataTypes] PRIMARY KEY CLUSTERED 
(
	[DataTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryOption]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryOption](
	[DeliveryOptionID] [bigint] IDENTITY(1,1) NOT NULL,
	[DeliveryOptionTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_DeliveryOptions] PRIMARY KEY CLUSTERED 
(
	[DeliveryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[DocumentTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentTypeTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationLevel]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationLevel](
	[LocationLevelID] [bigint] NOT NULL,
	[LocationLevelTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_LocationLevels] PRIMARY KEY CLUSTERED 
(
	[LocationLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationTree]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationTree](
	[LocationID] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationTitle] [nvarchar](50) NOT NULL,
	[ParentLocationID] [bigint] NULL,
	[LocationLevelID] [bigint] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_LocationTree] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaContentType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaContentType](
	[MediaContentTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[DisplayText] [nvarchar](100) NOT NULL,
	[HTMLContentTypeText] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IconPath] [nvarchar](500) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_MediaContentTypes] PRIMARY KEY CLUSTERED 
(
	[MediaContentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notify]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notify](
	[NotificationId] [bigint] IDENTITY(1,1) NOT NULL,
	[NotificationType] [bigint] NOT NULL,
	[SenderProfileId] [bigint] NOT NULL,
	[ReceiverProfileId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[SubjectRowID] [bigint] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[OptionID] [bigint] IDENTITY(1,1) NOT NULL,
	[OptionTitle] [varchar](50) NOT NULL,
	[MenuTitle] [varchar](50) NOT NULL,
	[ItemTitle] [varchar](50) NOT NULL,
	[PageURL] [varchar](100) NOT NULL,
	[NextPageURL] [varchar](50) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[OptionTypeID] [int] NOT NULL,
	[ParentOptionID] [bigint] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ExecActionID] [bigint] NOT NULL,
	[StatusID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[LastModifiedByUserID] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[OptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OptionType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OptionType](
	[OptionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[OptionTypeTitle] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[OptionLevel] [int] NOT NULL,
 CONSTRAINT [PK_OptionType] PRIMARY KEY CLUSTERED 
(
	[OptionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDeliveryDetail]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDeliveryDetail](
	[OrderDeliveryDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[CartOrderID] [bigint] NOT NULL,
	[DeliveryAddressID] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderDeliveryDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDeliveryDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderPayment]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPayment](
	[OrderPaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[CartOrderID] [bigint] NOT NULL,
	[PaymentID] [bigint] NOT NULL,
	[Amount] [float] NOT NULL,
	[BillingAddressID] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderPayment] PRIMARY KEY CLUSTERED 
(
	[OrderPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderStatusTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsSystem] [bit] NOT NULL,
	[IsOrder] [bit] NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatusMap]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatusMap](
	[OrderStatusMapID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentOrderStatusID] [bigint] NOT NULL,
	[ChildOrderStatusID] [bigint] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_OrderStatusMap] PRIMARY KEY CLUSTERED 
(
	[OrderStatusMapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackagedProduct]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackagedProduct](
	[PackageID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[ChildProductID] [bigint] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[IncludedByDefault] [bit] NOT NULL,
	[PercentagePrice] [float] NULL,
	[OtherDetails] [varchar](1000) NULL,
 CONSTRAINT [PK_ProductTree] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[PayTypeID] [bigint] NOT NULL,
	[Amount] [float] NOT NULL,
	[PaymentGatewayTransactionID] [nvarchar](1000) NOT NULL,
	[PaymentToken] [nvarchar](100) NOT NULL,
	[IsAmountVerified] [bit] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayMode]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayMode](
	[PayModeID] [bigint] IDENTITY(1,1) NOT NULL,
	[PayModeTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_PayModes] PRIMARY KEY CLUSTERED 
(
	[PayModeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayOptionMatrix]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayOptionMatrix](
	[PayOptionMatrixID] [bigint] IDENTITY(1,1) NOT NULL,
	[PayModeID] [bigint] NOT NULL,
	[PayTypeID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_PayOptionMatrix] PRIMARY KEY CLUSTERED 
(
	[PayOptionMatrixID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayType](
	[PayTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[PayTypeTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_PayType] PRIMARY KEY CLUSTERED 
(
	[PayTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductTitle] [nvarchar](200) NOT NULL,
	[BrifeDescription] [nvarchar](1000) NULL,
	[ProductActualImagePath] [nvarchar](max) NULL,
	[ProductImagePath] [nvarchar](max) NULL,
	[StockCount] [bigint] NULL,
	[WebLink] [nvarchar](max) NULL,
	[BasePrice] [float] NULL,
	[DiscountValue] [float] NULL,
	[IsDiscountPercentage] [bit] NULL,
	[SellingPrice] [float] NULL,
	[OrderResponseTime] [bigint] NOT NULL,
	[OrderResponseTimeUnitID] [varchar](50) NOT NULL,
	[TaxTypeID] [bigint] NOT NULL,
	[UserRating] [int] NULL,
	[AnalysisRank] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[ProductTypeID] [bigint] NOT NULL,
	[BrandID] [bigint] NOT NULL,
	[SupplierID] [bigint] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributePair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributePair](
	[ProductAttributePairID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[AttributeID] [bigint] NOT NULL,
	[AttributeValue] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsAssigned] [bit] NOT NULL,
	[IsSelectedForVariation] [bit] NOT NULL,
	[VariationInPrice] [float] NOT NULL,
 CONSTRAINT [PK_ProductAttributePairs] PRIMARY KEY CLUSTERED 
(
	[ProductAttributePairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategoryPair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategoryPair](
	[ProductCategoryPairID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_ProductCategoryPair] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryPairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMediaDetail]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMediaDetail](
	[ProductMediaID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductMediaTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[MediaContentTypeID] [bigint] NOT NULL,
	[MediaFilePath] [nvarchar](max) NULL,
	[ProductID] [bigint] NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[TransparencyLevel] [int] NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ApprovedByUserID] [bigint] NULL,
	[ApprovedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ProductMediaDetails] PRIMARY KEY CLUSTERED 
(
	[ProductMediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductTypeTitle] [nvarchar](100) NOT NULL,
	[ProductTypeDescription] [nvarchar](1000) NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_ProductTypes_1] PRIMARY KEY CLUSTERED 
(
	[ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductView]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductView](
	[ProductViewID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductViewTitle] [varchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[StatusID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_ProductViews] PRIMARY KEY CLUSTERED 
(
	[ProductViewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductViewItem]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductViewItem](
	[ProductViewProductID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductViewID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[ProductMediaID] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductViewProducts] PRIMARY KEY CLUSTERED 
(
	[ProductViewProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ProfileID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[FatherName] [nvarchar](100) NULL,
	[Nationality] [nvarchar](100) NULL,
	[Occupation] [nvarchar](100) NULL,
	[Education] [nvarchar](100) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[IsVerified] [bit] NULL,
	[UserTypeID] [bigint] NULL,
	[SMS_2FA] [bit] NOT NULL,
	[EMail_2FA] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileVerification]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileVerification](
	[VerificationID] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentTypeID] [bigint] NOT NULL,
	[VerifiedBy] [bigint] NULL,
	[VerifiedOn] [datetime] NULL,
	[Comments] [nvarchar](1000) NULL,
	[VerificationStatusID] [bigint] NULL,
	[ProfileID] [bigint] NOT NULL,
	[DocumentNumberByUser] [nvarchar](100) NULL,
	[DocumentNumberByVerifier] [nvarchar](100) NULL,
	[DocumentImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProfileVerification] PRIMARY KEY CLUSTERED 
(
	[VerificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[IconPath] [nvarchar](max) NULL,
	[StatusID] [bigint] NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_Roles_1] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleOptionPair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleOptionPair](
	[RoleOptionPairID] [bigint] IDENTITY(1,1) NOT NULL,
	[OptionID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL,
	[IsAssigned] [bit] NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_RoleOptionPairs] PRIMARY KEY CLUSTERED 
(
	[RoleOptionPairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierID] [bigint] NULL,
	[ScheduleTypeID] [bigint] NULL,
	[IsException] [bit] NOT NULL,
	[WeekDays] [nvarchar](500) NULL,
	[FromDay] [smallint] NULL,
	[ToDay] [smallint] NULL,
	[Month] [smallint] NULL,
	[MonthDay] [smallint] NULL,
	[StatusID] [bigint] NULL,
	[Notes] [nvarchar](500) NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleType](
	[ScheduleTypeID] [bigint] NOT NULL,
	[ScheduleTypeTitle] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[StatusID] [bigint] NULL,
 CONSTRAINT [PK_ScheduleType] PRIMARY KEY CLUSTERED 
(
	[ScheduleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchTerm]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchTerm](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Keyword] [nvarchar](max) NULL,
	[StoreId] [bigint] NOT NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](500) NOT NULL,
	[Logo] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[StatusID] [bigint] NOT NULL,
	[StatusNotes] [nvarchar](max) NULL,
	[BusinessAddressID] [bigint] NOT NULL,
	[IsBusinessAddressVisible] [bit] NOT NULL,
	[LanguageID] [bigint] NULL,
	[CurrencyID] [bigint] NULL,
	[CountryID] [bigint] NULL,
	[ProvinceID] [bigint] NULL,
	[CityID] [bigint] NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[IsCOD] [bit] NOT NULL,
	[ProfileID] [bigint] NOT NULL,
	[ProcessingFee] [float] NOT NULL,
	[PaymentGatewayFee] [float] NOT NULL,
	[IsProcessingFeePercentage] [bit] NOT NULL,
	[IsPaymentGatewayFeePercentage] [bit] NOT NULL,
	[WebLinksJSON] [nvarchar](max) NULL,
	[AnnouncementHTML] [ntext] NULL,
	[PolicyHTML] [ntext] NULL,
	[FAQHTML] [ntext] NULL,
	[CategoryRequests] [nvarchar](max) NULL,
	[AttributeRequests] [nvarchar](max) NULL,
	[TaxConcent] [bit] NOT NULL,
	[TaxRegistration] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierDeliveryOptionPair]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierDeliveryOptionPair](
	[SupplierDeliveryOptionPairID] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierID] [bigint] NOT NULL,
	[DeliveryOptionID] [bigint] NOT NULL,
	[DeliveryCharges] [float] NOT NULL,
	[MinOrderLimit] [float] NOT NULL,
	[SurroundingCitiesIDs] [varchar](500) NULL,
 CONSTRAINT [PK_SupplierDeliveryOptionPair] PRIMARY KEY CLUSTERED 
(
	[SupplierDeliveryOptionPairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[TaxID] [bigint] IDENTITY(1,1) NOT NULL,
	[TaxValue] [float] NOT NULL,
	[TaxTypeID] [bigint] NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[StatusID] [bigint] NOT NULL,
	[IsPercentage] [bit] NOT NULL,
	[LocationLevelId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
(
	[TaxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxType](
	[TaxTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[TaxTypeTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_TaxTypes] PRIMARY KEY CLUSTERED 
(
	[TaxTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [bigint] IDENTITY(2,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserPassword] [nvarchar](20) NOT NULL,
	[Useremail] [nvarchar](200) NOT NULL,
	[PasswordResetCode] [nvarchar](200) NULL,
	[AcvtivationGUID] [nvarchar](200) NULL,
	[UserTypeID] [bigint] NULL,
	[StatusID] [bigint] NOT NULL,
	[IsLoggedIn] [bit] NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[GroupID] [bigint] NOT NULL,
	[CreatedByUserID] [bigint] NOT NULL,
	[LastModifiedByUserID] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[ApprovedByUserID] [bigint] NULL,
	[ApprovedDateTime] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerificationStatus]    Script Date: 6/3/2021 10:25:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerificationStatus](
	[VerificationStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[VerificationStatusTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[IsSystem] [bit] NOT NULL,
 CONSTRAINT [PK_VerificationStatus] PRIMARY KEY CLUSTERED 
(
	[VerificationStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([AddressID], [ProfileID], [AddressTypeID], [PlotNumber], [StreetNumber], [CountryID], [ProvinceID], [CityID], [LocationID], [NearestLandmark], [PostalCode], [MapLink], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (1, 1, 1, N'SFSDF', N'53 Equator Crescent', 0, 7, 11, 11, N'asdadasd', N'12345', NULL, CAST(N'2021-05-30T10:57:42.793' AS DateTime), 1, CAST(N'2021-05-30T12:53:25.053' AS DateTime), 1)
GO
INSERT [dbo].[Address] ([AddressID], [ProfileID], [AddressTypeID], [PlotNumber], [StreetNumber], [CountryID], [ProvinceID], [CityID], [LocationID], [NearestLandmark], [PostalCode], [MapLink], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (2, 3, 1, N'SFSDF', N'53 Equator Crescent', 0, 2, 25, 25, N'asdadasd', N'12345', NULL, CAST(N'2021-05-31T23:22:21.067' AS DateTime), 1, CAST(N'2021-05-31T23:22:21.067' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[AddressType] ON 
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [AddressTypeTitle], [Description], [IsSystem]) VALUES (1, N'Shop Address', N'Commercial / Shop Address', 1)
GO
INSERT [dbo].[AddressType] ([AddressTypeID], [AddressTypeTitle], [Description], [IsSystem]) VALUES (2, N'Delivery Address', N'Non-Business Address: Shipping/Delivery or Billing Address etc.', 1)
GO
SET IDENTITY_INSERT [dbo].[AddressType] OFF
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
SET IDENTITY_INSERT [dbo].[AttributeType] ON 
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (1, N'Customization Attribute', N'Customization Attribute', 1)
GO
INSERT [dbo].[AttributeType] ([AttributeTypeID], [AttributeTypeTitle], [Description], [IsSystem]) VALUES (2, N'Specification Attribute', N'Specification Attribute', 1)
GO
SET IDENTITY_INSERT [dbo].[AttributeType] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName], [ManufacturerName], [Description], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsSystem]) VALUES (1, N'Default Brand', N'Default Brand', N'Default Brand', 2, 1, 1, CAST(N'2020-11-16T12:48:32.183' AS DateTime), CAST(N'2020-11-16T12:48:32.183' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[CartOrder] ON 
GO
INSERT [dbo].[CartOrder] ([CartOrderID], [OrderNumber], [ParentCartID], [BuyerProfileID], [OrderStatusID], [StatusID], [DeliveryAddressID], [DeliveryAddress], [OrderSupplierId], [SupplierDeliveryOptionPairID], [OrderTotal], [TaxTotal], [DeliveryTotal], [DiscountTotal], [PaymentTotal], [CalculatedPayout], [ActualPayout], [CalculatedPayIn], [ActualPayIn], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (1, NULL, NULL, 1, 1, 2, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, CAST(N'2021-05-30T10:56:23.760' AS DateTime), 1, CAST(N'2021-05-30T10:56:23.760' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[CartOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (1, N'My Kitchen', NULL, N'pexel homemade 01.jpg', 1, NULL, 2, 1, 1, 1, CAST(N'2021-05-19T20:02:07.257' AS DateTime), CAST(N'2021-05-23T05:05:09.863' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (2, N'Remote Services', NULL, N'pexel hair cutting 01.jpg', 1, NULL, 2, 1, 1, 1, CAST(N'2021-05-19T20:03:49.960' AS DateTime), CAST(N'2021-05-23T05:00:19.943' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (3, N'Private Services', NULL, N'pexel home business 02.jpg', 1, NULL, 2, 1, 1, 1, CAST(N'2021-05-19T20:05:17.050' AS DateTime), CAST(N'2021-05-23T05:03:57.453' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (4, N'Italian', NULL, N'pexels Italian food.jpg', 2, 1, 2, 0, 1, 1, CAST(N'2021-05-19T20:56:02.917' AS DateTime), CAST(N'2021-05-20T01:56:51.580' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (5, N'Korean Food', NULL, N'pexels Korean food.jpg', 2, 1, 2, 0, 1, 1, CAST(N'2021-05-19T20:59:13.997' AS DateTime), CAST(N'2021-05-20T01:57:02.663' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (6, N'Cakes and Bakery', NULL, N'pexels hands on dough 01.jpg', 2, 1, 2, 0, 1, 1, CAST(N'2021-05-19T21:13:06.447' AS DateTime), CAST(N'2021-05-20T01:43:21.690' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (7, N'Nail Arts and Manicure', NULL, N'pexels nail art 01.jpg', 2, 2, 2, 0, 1, 1, CAST(N'2021-05-19T21:44:44.933' AS DateTime), CAST(N'2021-05-20T01:58:52.993' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (8, N'Hair cut and styling', NULL, N'pexel hair cutting 01.jpg', 2, 2, 2, 0, 1, 1, CAST(N'2021-05-19T21:45:47.010' AS DateTime), CAST(N'2021-05-20T01:56:05.743' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (9, N'Home repairs', NULL, N'pexels home repair 01 .jpg', 2, 2, 2, 0, 1, 1, CAST(N'2021-05-19T22:02:59.833' AS DateTime), CAST(N'2021-05-20T01:56:18.537' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (10, N'Household Cleaning', NULL, N'pexels household cleaning 01.jpg', 2, 2, 4, 0, 1, 1, CAST(N'2021-05-19T22:03:43.030' AS DateTime), CAST(N'2021-05-20T01:56:25.587' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (11, N'Household Cleaning', NULL, N'pexels household cleaning 01.jpg', 2, 2, 2, 0, 1, 1, CAST(N'2021-05-19T22:04:01.680' AS DateTime), CAST(N'2021-05-20T01:56:36.037' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (12, N'Cantonese', NULL, N'pexels Cantonese food 01.jpg', 2, 1, 2, 0, 1, 1, CAST(N'2021-05-19T22:14:53.367' AS DateTime), CAST(N'2021-05-20T01:43:37.657' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (13, N'My Products ', NULL, N'pexels eggs on nest 01.jpg', 1, NULL, 2, 1, 1, 1, CAST(N'2021-05-19T22:38:58.767' AS DateTime), CAST(N'2021-05-23T05:05:37.040' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (14, N'Tattoo Service', NULL, N'pexels tattoo service 01.jpg', 2, 3, 2, 0, 1, 1, CAST(N'2021-05-19T22:42:45.963' AS DateTime), CAST(N'2021-05-20T02:00:31.677' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (15, N'Tailoring and Alteration ', NULL, N'pexel home tailoring 01.jpg', 2, 3, 2, 0, 1, 1, CAST(N'2021-05-19T22:43:50.230' AS DateTime), CAST(N'2021-05-20T01:00:13.367' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (16, N'makeup service', NULL, N'pexels makeup service 01.jpg', 2, 2, 2, 0, 1, 1, CAST(N'2021-05-19T23:18:57.217' AS DateTime), CAST(N'2021-05-20T01:57:14.870' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (17, N'waxing', NULL, N'pexels waxing legs 01.PNG', 2, 3, 2, 0, 1, 1, CAST(N'2021-05-19T23:19:56.133' AS DateTime), CAST(N'2021-05-20T01:59:56.803' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (18, N'Arts and Crafts', NULL, N'pexels arts and crafts 01.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:09:17.110' AS DateTime), CAST(N'2021-05-20T01:42:46.277' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (19, N'Accessories and Outfits', NULL, N'pexels accessories 01.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:10:08.460' AS DateTime), CAST(N'2021-05-20T01:42:34.710' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (20, N'Woodworks', NULL, N'pexels woodworks 01.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:16:59.157' AS DateTime), CAST(N'2021-05-20T01:59:39.290' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (21, N'Cosmetics and Fragrances', NULL, N'pexels florals 02.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:26:18.037' AS DateTime), CAST(N'2021-05-20T02:05:47.750' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (22, N'Bath and Beauty', NULL, N'pexels soothing candles 01.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:29:16.010' AS DateTime), CAST(N'2021-05-20T20:16:34.880' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (23, N'Gardening and Seeds', NULL, N'pexels gardening 02.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:30:18.647' AS DateTime), CAST(N'2021-05-20T01:55:54.573' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (24, N'Health and Personal Care', NULL, N'pexels florals 02.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:30:42.133' AS DateTime), CAST(N'2021-05-20T20:17:16.763' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (25, N'Florals and Plants', NULL, N'pexels florals 02.jpg', 2, 13, 3, 0, 1, 1, CAST(N'2021-05-20T00:31:03.320' AS DateTime), CAST(N'2021-05-20T01:47:22.830' AS DateTime))
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryTitle], [Description], [LogoPath], [CategoryTypeID], [CategoryParentID], [StatusID], [IsSystem], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (26, N'Florals and Plants', NULL, N'pexels florals 02 resized L.jpg', 2, 13, 2, 0, 1, 1, CAST(N'2021-05-20T00:31:13.380' AS DateTime), CAST(N'2021-05-20T02:08:32.930' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryType] ON 
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (1, N'Main Category', N'Home page display', 2, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (2, N'1st Level Sub category', N'1st Level Sub category', 2, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (3, N'2st Level Sub category', N'2st Level Sub category', 2, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (4, N'3st Level Sub category', N'3st Level Sub category', 2, 1)
GO
INSERT [dbo].[CategoryType] ([CategoryTypeID], [Title], [Description], [StatusID], [IsSystem]) VALUES (5, N'4th Level Sub category', N'4th Level Sub category', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryType] OFF
GO
SET IDENTITY_INSERT [dbo].[Chat] ON 
GO
INSERT [dbo].[Chat] ([ChatId], [ChatCode], [ProfileId1], [ProfileId2], [StatusId], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID]) VALUES (1, N'', 1, 1, 2, CAST(N'2021-05-30T12:54:10.117' AS DateTime), 1, CAST(N'2021-05-30T12:54:10.117' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Chat] OFF
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
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (1, N'Country', N'Country')
GO
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (2, N'Province', N'Province')
GO
INSERT [dbo].[LocationLevel] ([LocationLevelID], [LocationLevelTitle], [Description]) VALUES (3, N'City', N'City')
GO
SET IDENTITY_INSERT [dbo].[LocationTree] ON 
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
INSERT [dbo].[LocationTree] ([LocationID], [LocationTitle], [ParentLocationID], [LocationLevelID], [Description]) VALUES (31, N'Canada - east', 0, 2, N'test')
GO
SET IDENTITY_INSERT [dbo].[LocationTree] OFF
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
SET IDENTITY_INSERT [dbo].[Notify] ON 
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (1, 5, 3, 1, 2, N'Shop GroceryShop has been sent for approval', CAST(N'2021-05-30T10:57:13.480' AS DateTime), 3, CAST(N'2021-05-30T10:57:13.480' AS DateTime), 3, 1)
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (2, 5, 3, 3, 2, N'Shop GroceryShop has been received for approval', CAST(N'2021-05-30T10:57:15.893' AS DateTime), 3, CAST(N'2021-05-30T10:57:15.893' AS DateTime), 3, 1)
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (3, 5, 3, 1, 2, N'Shop GroceryShop has been sent for approval', CAST(N'2021-05-30T11:04:14.180' AS DateTime), 3, CAST(N'2021-05-30T11:04:14.180' AS DateTime), 3, 1)
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (4, 5, 3, 3, 2, N'Shop GroceryShop has been received for approval', CAST(N'2021-05-30T11:04:16.613' AS DateTime), 3, CAST(N'2021-05-30T11:04:16.613' AS DateTime), 3, 1)
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (5, 5, 3, 1, 2, N'Shop GroceryShop has been approved.', CAST(N'2021-05-30T12:53:31.280' AS DateTime), 3, CAST(N'2021-05-30T12:53:31.280' AS DateTime), 3, 1)
GO
INSERT [dbo].[Notify] ([NotificationId], [NotificationType], [SenderProfileId], [ReceiverProfileId], [StatusId], [Message], [CreatedDateTime], [CreatedByUserID], [LastModifiedDateTime], [LastModifiedByUserID], [SubjectRowID]) VALUES (6, 5, 3, 3, 2, N'Shop GroceryShop has been approved', CAST(N'2021-05-30T12:53:33.360' AS DateTime), 3, CAST(N'2021-05-30T12:53:33.360' AS DateTime), 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Notify] OFF
GO
SET IDENTITY_INSERT [dbo].[Option] ON 
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (0, N'Root', N'Root', N'', N'', N'', 1, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.417' AS DateTime), CAST(N'2021-01-10T06:51:06.417' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (1, N'Dashboard', N'Dashboard', N'fa fa-home', N'/Admin/Index', N'', 1, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.417' AS DateTime), CAST(N'2021-01-10T06:51:06.417' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (2, N'Report', N'Report', N'', N'/Admin/Report', N'', 1, 1, 1, 1, 2, 4, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (3, N'Chart', N'Chart', N'', N'/Admin/Chart', N'', 1, 1, 1, 2, 2, 4, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (4, N'Stats', N'Stats', N'', N'/Admin/Home/Stats', N'', 1, 1, 1, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.420' AS DateTime), CAST(N'2021-01-10T06:51:06.420' AS DateTime))
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
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (28, N'Profile Verification', N'Profile Verification', N'', N'/Admin/ProfileVerification/IndexAdmin', N'', 1, 1, 26, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (29, N'Address', N'Address', N'', N'/Admin/Address', N'', 1, 1, 26, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.433' AS DateTime), CAST(N'2021-01-10T06:51:06.433' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (30, N'Setup', N'Setup', N'fa fa-copy', N'', N'', 1, 1, 0, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.437' AS DateTime), CAST(N'2021-01-10T06:51:06.437' AS DateTime))
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
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (45, N'User', N'User', N'', N'/Security/Admin', N'', 1, 1, 44, 1, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (46, N'Role', N'Role', N'', N'/Security/Admin/RoleIndex', N'', 1, 1, 44, 2, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (47, N'Permission', N'Permission', N'', N'/Security/Admin/PermissionIndex', N'', 1, 1, 44, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (48, N'Customer Review & Feedback', N'Customer Review & Feedback', N'', N'/Admin/Review', N'', 1, 1, 26, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (49, N'Chat', N'Chat', N'', N'/Admin/Chat', N'', 1, 1, 26, 5, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.447' AS DateTime), CAST(N'2021-01-10T06:51:06.447' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (50, N'Cart Management', N'Cart Management', N'', N'/Admin/Cart', N'', 1, 1, 13, 3, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.447' AS DateTime), CAST(N'2021-01-10T06:51:06.447' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (51, N'Order Payments', N'Order Payments', N'', N'/Admin/Payment', N'', 1, 1, 13, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.447' AS DateTime), CAST(N'2021-01-10T06:51:06.447' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (52, N'/', N'/', N'', N'/', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.927' AS DateTime), CAST(N'2021-04-03T17:23:36.927' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (53, N'/home', N'/home', N'', N'/home', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (54, N'/CreateShop', N'/CreateShop', N'', N'/CreateShop', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (55, N'/ProductListing', N'/ProductListing', N'', N'/ProductListing', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (56, N'/EditInformation', N'/EditInformation', N'', N'/EditInformation', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (57, N'/search', N'/search', N'', N'/search', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (58, N'/productdetail', N'/productdetail', N'', N'/productdetail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (59, N'/PaymentSuccess', N'/PaymentSuccess', N'', N'/PaymentSuccess', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (60, N'/PaymentCancel', N'/PaymentCancel', N'', N'/PaymentCancel', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (61, N'/PaymentResponse', N'/PaymentResponse', N'', N'/PaymentResponse', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (62, N'/ShopSettings', N'/ShopSettings', N'', N'/ShopSettings', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (63, N'/CartDetail', N'/CartDetail', N'', N'/CartDetail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.930' AS DateTime), CAST(N'2021-04-03T17:23:36.930' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (64, N'/OrderDetail', N'/OrderDetail', N'', N'/OrderDetail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (65, N'/Shipping', N'/Shipping', N'', N'/Shipping', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (66, N'/ShopDetail', N'/ShopDetail', N'', N'/ShopDetail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (67, N'/ShopSearch', N'/ShopSearch', N'', N'/ShopSearch', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (68, N'/PaidOrderDetail', N'/PaidOrderDetail', N'', N'/PaidOrderDetail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (69, N'/chat', N'/chat', N'', N'/chat', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.933' AS DateTime), CAST(N'2021-04-03T17:23:36.933' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (70, N'/LoginSignup', N'/LoginSignup', N'', N'/LoginSignup', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (71, N'/ForgotPassword', N'/ForgotPassword', N'', N'/ForgotPassword', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (72, N'/UpdatePassword', N'/UpdatePassword', N'', N'/UpdatePassword', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (73, N'/ConfirmEmail', N'/ConfirmEmail', N'', N'/ConfirmEmail', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (74, N'/resendlink', N'/resendlink', N'', N'/resendlink', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (75, N'All Notification', N'All Notification', N'', N'/Admin/Notify', N'', 1, 1, 26, 6, 2, 2, 0, 0, CAST(N'2021-04-17T12:49:14.593' AS DateTime), CAST(N'2021-04-17T12:49:14.593' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (76, N'In-Active Shops', N'In-Active Shops', N'', N'/Admin/Profile/InActiveShops', N'', 1, 1, 26, 7, 2, 2, 0, 0, CAST(N'2021-04-17T16:18:48.443' AS DateTime), CAST(N'2021-04-17T16:18:48.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (77, N'/GuidePage', N'/GuidePage', N'', N'/GuidePage', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2021-04-17T16:18:48.443' AS DateTime), CAST(N'2021-04-17T16:18:48.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (78, N'/ZonvrTerms', N'/ZonvrTerms', N'', N'/ZonvrTerms', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2001-04-17T00:00:00.000' AS DateTime), CAST(N'2001-04-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (79, N'/ContactUs', N'/ContactUs', N'', N'/ContactUs', N'', 2, 1, 0, 1, 2, 2, 0, 0, CAST(N'2001-04-17T00:00:00.000' AS DateTime), CAST(N'2001-04-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (80, N'Location Tree', N'Location Tree', N'', N'/Admin/LocationTree', N'', 1, 1, 30, 14, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (81, N'Location Level', N'Location Level', N'', N'/Admin/LocationTree/LocationLevelList', N'', 1, 1, 30, 15, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.443' AS DateTime), CAST(N'2021-01-10T06:51:06.443' AS DateTime))
GO
INSERT [dbo].[Option] ([OptionID], [OptionTitle], [MenuTitle], [ItemTitle], [PageURL], [NextPageURL], [ModuleID], [OptionTypeID], [ParentOptionID], [DisplayOrder], [ExecActionID], [StatusID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime]) VALUES (82, N'Bank List', N'Bank List', N'', N'/Admin/Supplier/GetBankList', N'', 1, 1, 9, 4, 2, 2, 0, 0, CAST(N'2021-01-10T06:51:06.423' AS DateTime), CAST(N'2021-01-10T06:51:06.423' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
SET IDENTITY_INSERT [dbo].[OptionType] ON 
GO
INSERT [dbo].[OptionType] ([OptionTypeID], [OptionTypeTitle], [Description], [OptionLevel]) VALUES (1, N'Menu', N'Admin Menu Only', 1)
GO
SET IDENTITY_INSERT [dbo].[OptionType] OFF
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
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusTitle], [Description], [IsSystem], [IsOrder]) VALUES (7, N'skipped - by mistake', N'skipped - not in use', 1, 1)
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
SET IDENTITY_INSERT [dbo].[OrderStatusMap] ON 
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (2, 1, 2, 2, 1, N'System, Cart Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (3, 3, 4, 2, 1, N'System')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (4, 4, 5, 2, 1, N'Shop')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (5, 5, 6, 2, 1, N'Shop')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (6, 6, 8, 2, 1, N'Shop')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (7, 8, 10, 2, 1, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (9, 8, 9, 2, 0, N'Buyer')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (10, 6, 11, 2, 0, N'Shop')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (11, 6, 12, 2, 0, N'Shop')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (13, 9, 13, 2, 1, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (14, 9, 10, 2, 0, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (15, 11, 13, 2, 1, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (16, 11, 10, 2, 0, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (17, 12, 13, 2, 1, N'System, Order Final State')
GO
INSERT [dbo].[OrderStatusMap] ([OrderStatusMapID], [ParentOrderStatusID], [ChildOrderStatusID], [StatusID], [IsDefault], [Description]) VALUES (18, 12, 10, 2, 0, N'System, Order Final State')
GO
SET IDENTITY_INSERT [dbo].[OrderStatusMap] OFF
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
SET IDENTITY_INSERT [dbo].[Profile] ON 
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID], [SMS_2FA], [EMail_2FA], [CreatedOn]) VALUES (1, 1, N'Sherjil ', NULL, N'Ahmed', N'03333076655', NULL, NULL, NULL, N'Humboldt-State-University-library-Germany-Berlin_m.jpg', 0, 3, 0, 0, CAST(N'2021-06-03T18:12:56.593' AS DateTime))
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID], [SMS_2FA], [EMail_2FA], [CreatedOn]) VALUES (3, 3, N'Shop', NULL, N' Profile ', N'3', NULL, NULL, NULL, N'amrin-qureshi-3a.jpg', 0, 2, 0, 0, CAST(N'2021-06-03T18:12:56.593' AS DateTime))
GO
INSERT [dbo].[Profile] ([ProfileID], [UserID], [FirstName], [MiddleName], [LastName], [FatherName], [Nationality], [Occupation], [Education], [ImagePath], [IsVerified], [UserTypeID], [SMS_2FA], [EMail_2FA], [CreatedOn]) VALUES (4, 4, N'Sherjil', NULL, N'Ahmed', N'03333076655', NULL, NULL, NULL, NULL, 0, 2, 0, 0, CAST(N'2021-06-03T18:12:56.593' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Profile] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleOptionPair] ON 
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (51, 1, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (52, 2, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (53, 3, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (54, 4, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (55, 5, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (56, 6, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (57, 7, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (58, 8, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (59, 9, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (60, 10, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (61, 11, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (62, 12, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.623' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (63, 13, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (64, 14, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (65, 15, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (66, 16, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (67, 17, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (68, 18, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (69, 19, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (70, 20, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (71, 21, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (72, 22, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (73, 23, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (74, 24, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.627' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (75, 25, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (76, 26, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (77, 27, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (78, 28, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (79, 29, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (80, 30, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (81, 31, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (82, 32, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (83, 33, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (84, 34, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (85, 35, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (86, 36, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (87, 37, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (88, 38, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (89, 39, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (90, 40, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (91, 41, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (92, 42, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (93, 43, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (94, 44, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.630' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (95, 45, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (96, 46, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (97, 47, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (98, 48, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (99, 49, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (100, 50, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10051, 51, 6, 1, 1, 2, 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime), 0, CAST(N'2021-01-10T07:01:12.633' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10052, 52, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.937' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10053, 53, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10054, 54, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10055, 55, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10056, 56, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10057, 57, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10058, 58, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10059, 59, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10060, 60, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10061, 61, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10062, 62, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10063, 63, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10064, 64, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10065, 65, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10066, 66, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10067, 67, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10068, 68, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.940' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10069, 69, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10070, 72, 6, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10071, 52, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10072, 53, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10073, 54, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10074, 55, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10075, 56, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10076, 57, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10077, 58, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10078, 59, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.943' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10079, 60, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10080, 61, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10081, 62, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10082, 63, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10083, 64, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10084, 65, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10085, 66, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10086, 67, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10087, 68, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10088, 69, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10089, 72, 3, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10090, 52, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10091, 53, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.947' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10092, 56, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10093, 57, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10094, 58, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10095, 59, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10096, 60, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10097, 61, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10098, 63, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10099, 64, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10100, 65, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10101, 66, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10102, 67, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10103, 68, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10104, 69, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10105, 72, 2, 1, 1, 2, 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime), 0, CAST(N'2021-04-03T17:23:36.950' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10106, 75, 6, 1, 1, 2, 0, CAST(N'2021-04-17T16:29:35.430' AS DateTime), 0, CAST(N'2021-04-17T16:29:35.430' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10107, 76, 6, 1, 1, 2, 0, CAST(N'2021-04-17T16:29:35.433' AS DateTime), 0, CAST(N'2021-04-17T16:29:35.433' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10108, 71, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.690' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.690' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10109, 73, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.693' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.693' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10110, 74, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.693' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.693' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10111, 77, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10112, 78, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10113, 79, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10114, 80, 6, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10115, 81, 6, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10116, 71, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10117, 73, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10118, 74, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10119, 77, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.697' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10120, 78, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.700' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.700' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10121, 79, 2, 1, 1, 2, 0, CAST(N'2021-05-27T17:33:32.700' AS DateTime), 0, CAST(N'2021-05-27T17:33:32.700' AS DateTime))
GO
INSERT [dbo].[RoleOptionPair] ([RoleOptionPairID], [OptionID], [RoleID], [IsAssigned], [IsSystem], [StatusID], [CreatedByUserID], [CreatedDateTime], [LastModifiedByUserID], [LastModifiedDateTime]) VALUES (10122, 82, 6, 1, 1, 2, 0, CAST(N'2021-05-27T00:00:00.000' AS DateTime), 0, CAST(N'2021-05-27T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[RoleOptionPair] OFF
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (1, N'Weekly', N'Recurring on every week day', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (2, N'Monthly', N'recuring on specified range of dates within a month', 1)
GO
INSERT [dbo].[ScheduleType] ([ScheduleTypeID], [ScheduleTypeTitle], [Description], [StatusID]) VALUES (3, N'Yearly', N'Specific dates only within a year', 1)
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
SET IDENTITY_INSERT [dbo].[Supplier] ON 
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Logo], [Description], [StatusID], [StatusNotes], [BusinessAddressID], [IsBusinessAddressVisible], [LanguageID], [CurrencyID], [CountryID], [ProvinceID], [CityID], [CreatedByUserID], [LastModifiedByUserID], [CreatedDateTime], [LastModifiedDateTime], [IsCOD], [ProfileID], [ProcessingFee], [PaymentGatewayFee], [IsProcessingFeePercentage], [IsPaymentGatewayFeePercentage], [WebLinksJSON], [AnnouncementHTML], [PolicyHTML], [FAQHTML], [CategoryRequests], [AttributeRequests], [TaxConcent], [TaxRegistration]) VALUES (1, N'GroceryShop', NULL, N'GroceryShop', 2, NULL, 1, 0, NULL, NULL, 0, 7, 11, 1, 1, CAST(N'2021-05-30T10:57:05.260' AS DateTime), CAST(N'2021-05-30T12:53:25.123' AS DateTime), 1, 1, 5, 5, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'')
GO
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierDeliveryOptionPair] ON 
GO
INSERT [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID], [SupplierID], [DeliveryOptionID], [DeliveryCharges], [MinOrderLimit], [SurroundingCitiesIDs]) VALUES (1, 1, 2, 0, 0, N'')
GO
SET IDENTITY_INSERT [dbo].[SupplierDeliveryOptionPair] OFF
GO
SET IDENTITY_INSERT [dbo].[TaxType] ON 
GO
INSERT [dbo].[TaxType] ([TaxTypeID], [TaxTypeTitle], [Description], [IsSystem]) VALUES (1, N'GST', N'General Sales Tax', 1)
GO
SET IDENTITY_INSERT [dbo].[TaxType] OFF
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
/****** Object:  Index [UK_OrderPayment]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[OrderPayment] ADD  CONSTRAINT [UK_OrderPayment] UNIQUE NONCLUSTERED 
(
	[OrderPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_PayOptionMatrix]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[PayOptionMatrix] ADD  CONSTRAINT [UK_PayOptionMatrix] UNIQUE NONCLUSTERED 
(
	[PayModeID] ASC,
	[PayTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_ProductCategoryPair]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[ProductCategoryPair] ADD  CONSTRAINT [UK_ProductCategoryPair] UNIQUE NONCLUSTERED 
(
	[CategoryID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_ProductViewProducts]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[ProductViewItem] ADD  CONSTRAINT [UK_ProductViewProducts] UNIQUE NONCLUSTERED 
(
	[ProductViewProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_Profiles]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [UK_Profiles] UNIQUE NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UK_RoleID]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [UK_RoleID] UNIQUE NONCLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Users]    Script Date: 6/3/2021 10:25:44 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF_AddressType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_ConfigTitle]  DEFAULT ('') FOR [ConfigTitle]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_ConfigValue]  DEFAULT ('') FOR [ConfigValue]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfigs_DisplayText]  DEFAULT ('') FOR [DisplayText]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_ConfigDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[AppConfig] ADD  CONSTRAINT [DF_AppConfig_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_AttributeTitle]  DEFAULT ('') FOR [AttributeTitle]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attribute_AttributeTypeID]  DEFAULT ((1)) FOR [AttributeTypeID]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_Size]  DEFAULT ((50)) FOR [DataTypeSize]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_DefaultValue]  DEFAULT ('') FOR [DefaultValue]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_IsMandatory]  DEFAULT ((0)) FOR [IsMandatory]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attribute_IsMultiSelect]  DEFAULT ((0)) FOR [IsMultiSelect]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attributes_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF_Attribute_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF_AttributeType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_BrandName]  DEFAULT ('') FOR [BrandName]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_ManufacturerName]  DEFAULT ('') FOR [ManufacturerName]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_BrandDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brands_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brand_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Cart] ADD  CONSTRAINT [DF_Cart_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItem_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItems_Qualtity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItem_TaxRateApplied]  DEFAULT ((0)) FOR [TaxRateApplied]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItem_TaxAmount]  DEFAULT ((0)) FOR [TaxAmount]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItem_DiscountAmount]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItems_UnitPrice]  DEFAULT ((0)) FOR [ItemTotalPrice]
GO
ALTER TABLE [dbo].[CartItem] ADD  CONSTRAINT [DF_CartItem_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CartItemAttributePair] ADD  CONSTRAINT [DF_CartItemAttribute_VariationInPrice]  DEFAULT ((0)) FOR [VariationInPrice]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_ShoppingCart_UserID]  DEFAULT ((0)) FOR [BuyerProfileID]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_ShoppingCart_OrderStatusID]  DEFAULT ((1)) FOR [OrderStatusID]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_OrderTotal]  DEFAULT ((0)) FOR [OrderTotal]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_TaxTotal]  DEFAULT ((0)) FOR [TaxTotal]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_DeliveryTotal]  DEFAULT ((0)) FOR [DeliveryTotal]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_DiscountTotal]  DEFAULT ((0)) FOR [DiscountTotal]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_PaymentTotal]  DEFAULT ((0)) FOR [PaymentTotal]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_CalculatedPayout]  DEFAULT ((0)) FOR [CalculatedPayout]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_ActualPayout]  DEFAULT ((0)) FOR [ActualPayout]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_CalculatedPayIn]  DEFAULT ((0)) FOR [CalculatedPayIn]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_CartOrder_ActualPayIn]  DEFAULT ((0)) FOR [ActualPayIn]
GO
ALTER TABLE [dbo].[CartOrder] ADD  CONSTRAINT [DF_ShoppingCart_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CategoryTitle]  DEFAULT ('') FOR [CategoryTitle]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CategoryDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_LogoPath]  DEFAULT ('') FOR [LogoPath]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CategoryTypeID]  DEFAULT ((1)) FOR [CategoryTypeID]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CategoryParentID]  DEFAULT ((0)) FOR [CategoryParentID]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Catagories_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Categories_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[CategoryAttributePair] ADD  CONSTRAINT [DF_CategoryAttributePair_IsAssigned]  DEFAULT ((0)) FOR [IsAssigned]
GO
ALTER TABLE [dbo].[CategoryType] ADD  CONSTRAINT [DF_CategoryTypes_StatusID]  DEFAULT ((1)) FOR [StatusID]
GO
ALTER TABLE [dbo].[CategoryType] ADD  CONSTRAINT [DF_CategoryType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Chat] ADD  CONSTRAINT [DF_Chat_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Chat] ADD  CONSTRAINT [DF_Chat_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[CustomerReview] ADD  CONSTRAINT [DF_CustomerReview_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[CustomerReview] ADD  CONSTRAINT [DF_CustomerReview_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[CustomerReview] ADD  CONSTRAINT [DF_CustomerReview_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CustomerReview] ADD  CONSTRAINT [DF_CustomerReview_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataTypes_AssemblyName]  DEFAULT ('') FOR [AssemblyName]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataTypes_Namespace]  DEFAULT ('') FOR [Namespace]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataTypes_ClassName]  DEFAULT ('') FOR [ClassName]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataTypes_FriendlyName]  DEFAULT ('') FOR [FriendlyName]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[DeliveryOption] ADD  CONSTRAINT [DF_DeliveryOption_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[MediaContentType] ADD  CONSTRAINT [DF_MediaContentTypes_DisplayText]  DEFAULT ('') FOR [DisplayText]
GO
ALTER TABLE [dbo].[MediaContentType] ADD  CONSTRAINT [DF_MediaContentTypes_HTMLContentTypeText]  DEFAULT ('') FOR [HTMLContentTypeText]
GO
ALTER TABLE [dbo].[MediaContentType] ADD  CONSTRAINT [DF_MediaContentTypes_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[MediaContentType] ADD  CONSTRAINT [DF_MediaContentTypes_IconPath]  DEFAULT ('') FOR [IconPath]
GO
ALTER TABLE [dbo].[MediaContentType] ADD  CONSTRAINT [DF_MediaContentType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Notify] ADD  CONSTRAINT [DF_Notify_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Notify] ADD  CONSTRAINT [DF_Notify_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Notify] ADD  DEFAULT ((0)) FOR [SubjectRowID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_OptionTitle]  DEFAULT ('') FOR [OptionTitle]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_MenuTitle]  DEFAULT ('') FOR [MenuTitle]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_PageTitle]  DEFAULT ('') FOR [ItemTitle]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_PageURL]  DEFAULT ('') FOR [PageURL]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_NextPageURL]  DEFAULT ('') FOR [NextPageURL]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_ModuleID]  DEFAULT ((0)) FOR [ModuleID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_OptionTypeID]  DEFAULT ((1)) FOR [OptionTypeID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_ParentOptionID]  DEFAULT ((0)) FOR [ParentOptionID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Option_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_ExecActionID]  DEFAULT ((0)) FOR [ExecActionID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Option] ADD  CONSTRAINT [DF_Options_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[OptionType] ADD  CONSTRAINT [DF_OptionTypes_OptionTypeTitle]  DEFAULT ('') FOR [OptionTypeTitle]
GO
ALTER TABLE [dbo].[OptionType] ADD  CONSTRAINT [DF_OptionTypes_OptionTypeDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[OptionType] ADD  CONSTRAINT [DF_OptionTypes_OptionLevel]  DEFAULT ((0)) FOR [OptionLevel]
GO
ALTER TABLE [dbo].[OrderDeliveryDetail] ADD  CONSTRAINT [DF_OrderDeliveryDetails_AddressID]  DEFAULT ((1)) FOR [DeliveryAddressID]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_OrderStatus]  DEFAULT ('') FOR [OrderStatusTitle]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_OrderStatusDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_IsOrder]  DEFAULT ((1)) FOR [IsOrder]
GO
ALTER TABLE [dbo].[OrderStatusMap] ADD  CONSTRAINT [DF_OrderStatusMap_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  CONSTRAINT [DF_ProductTree_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  CONSTRAINT [DF_ProductTree_IncludedByDefault]  DEFAULT ((1)) FOR [IncludedByDefault]
GO
ALTER TABLE [dbo].[PackagedProduct] ADD  CONSTRAINT [DF_ProductTree_OtherDetails]  DEFAULT ('') FOR [OtherDetails]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_IsAmountReceived]  DEFAULT ((0)) FOR [IsAmountVerified]
GO
ALTER TABLE [dbo].[PayMode] ADD  CONSTRAINT [DF_PayModes_PayModeTitle]  DEFAULT ('') FOR [PayModeTitle]
GO
ALTER TABLE [dbo].[PayMode] ADD  CONSTRAINT [DF_PayModes_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[PayMode] ADD  CONSTRAINT [DF_PayMode_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[PayOptionMatrix] ADD  CONSTRAINT [DF_PayOptionMatrix_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[PayType] ADD  CONSTRAINT [DF_PayType_PayTypeTitle]  DEFAULT ('') FOR [PayTypeTitle]
GO
ALTER TABLE [dbo].[PayType] ADD  CONSTRAINT [DF_PayType_PayTypeDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[PayType] ADD  CONSTRAINT [DF_PayType_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[PayType] ADD  CONSTRAINT [DF_PayType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_ProductTitle]  DEFAULT ('') FOR [ProductTitle]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_BrifeDescription]  DEFAULT ('') FOR [BrifeDescription]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_ProductActualImagePath]  DEFAULT ('') FOR [ProductActualImagePath]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_ProductImage]  DEFAULT ('') FOR [ProductImagePath]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_StockCount]  DEFAULT ((0)) FOR [StockCount]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_BasePrice]  DEFAULT ((0)) FOR [BasePrice]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_SellingPrice]  DEFAULT ((0)) FOR [SellingPrice]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_OrderResponseTime]  DEFAULT ((0)) FOR [OrderResponseTime]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_OrderResponseTimeUnitID]  DEFAULT ((0)) FOR [OrderResponseTimeUnitID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_TaxTypeID]  DEFAULT ((1)) FOR [TaxTypeID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_UserRankID]  DEFAULT ((0)) FOR [UserRating]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_AnalysisRankID]  DEFAULT ((0)) FOR [AnalysisRank]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_BrandID]  DEFAULT ((0)) FOR [BrandID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_SupplierID]  DEFAULT ((3)) FOR [SupplierID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Products_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[ProductAttributePair] ADD  CONSTRAINT [DF_ProductAttributePairs_Value]  DEFAULT ('') FOR [AttributeValue]
GO
ALTER TABLE [dbo].[ProductAttributePair] ADD  CONSTRAINT [DF_ProductAttributePair_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[ProductAttributePair] ADD  CONSTRAINT [DF_ProductAttributePair_IsAssigned]  DEFAULT ((0)) FOR [IsAssigned]
GO
ALTER TABLE [dbo].[ProductAttributePair] ADD  CONSTRAINT [DF_ProductAttributePair_IsSelectedForVariation]  DEFAULT ((0)) FOR [IsSelectedForVariation]
GO
ALTER TABLE [dbo].[ProductAttributePair] ADD  CONSTRAINT [DF_ProductAttributePair_VariationInPrice]  DEFAULT ((0)) FOR [VariationInPrice]
GO
ALTER TABLE [dbo].[ProductCategoryPair] ADD  CONSTRAINT [DF_ProductCategoryPair_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_ProductMediaTitle]  DEFAULT ('') FOR [ProductMediaTitle]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_Media Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_ProductMediaContentType]  DEFAULT ((1)) FOR [MediaContentTypeID]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_MediaLocation]  DEFAULT ('') FOR [MediaFilePath]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_Width]  DEFAULT ((0)) FOR [Width]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_Height]  DEFAULT ((0)) FOR [Height]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_TransparencyLevel]  DEFAULT ((0)) FOR [TransparencyLevel]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_ApprovedbyUserID]  DEFAULT (NULL) FOR [ApprovedByUserID]
GO
ALTER TABLE [dbo].[ProductMediaDetail] ADD  CONSTRAINT [DF_ProductMediaDetails_ApprovedDateTime]  DEFAULT (NULL) FOR [ApprovedDateTime]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_ProductTypeTitle]  DEFAULT ('') FOR [ProductTypeTitle]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_ProductTypeDescription]  DEFAULT ('') FOR [ProductTypeDescription]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_IsApproved]  DEFAULT ((1)) FOR [StatusID]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductTypes_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF_ProductType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[ProductView] ADD  CONSTRAINT [DF_ProductViews_ProductViewTitle]  DEFAULT ('') FOR [ProductViewTitle]
GO
ALTER TABLE [dbo].[ProductView] ADD  CONSTRAINT [DF_ProductViews_ProductViewDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[ProductView] ADD  CONSTRAINT [DF_ProductViews_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[ProductView] ADD  CONSTRAINT [DF_ProductView_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_FirstName]  DEFAULT ('') FOR [FirstName]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_MiddleName]  DEFAULT ('') FOR [MiddleName]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_LastName]  DEFAULT ('') FOR [LastName]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_FatherName]  DEFAULT ('') FOR [FatherName]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_Nationality]  DEFAULT ('') FOR [Nationality]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_Occupation]  DEFAULT ('') FOR [Occupation]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_Education]  DEFAULT ('') FOR [Education]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_ImagePath]  DEFAULT ('') FOR [ImagePath]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profiles_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_SMS_2FA]  DEFAULT ((1)) FOR [SMS_2FA]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_EMail_2FA]  DEFAULT ((1)) FOR [EMail_2FA]
GO
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Roles_RoleTitle]  DEFAULT ('') FOR [RoleTitle]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Roles_RoleDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Roles_IconPath]  DEFAULT ('') FOR [IconPath]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Roles_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Roles_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_IsAssigned]  DEFAULT ((1)) FOR [IsAssigned]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_IsDeleted1]  DEFAULT ((2)) FOR [StatusID]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[RoleOptionPair] ADD  CONSTRAINT [DF_RoleOptionPairs_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Schedule] ADD  CONSTRAINT [DF_Schedule_IsException]  DEFAULT ((0)) FOR [IsException]
GO
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Suppliers_SupplierName]  DEFAULT ('') FOR [SupplierName]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Suppliers_SupplierDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Suppliers_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_IsShopAddressVisible]  DEFAULT ((0)) FOR [IsBusinessAddressVisible]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_IsCOD]  DEFAULT ((0)) FOR [IsCOD]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_ProcessingFee]  DEFAULT ((5)) FOR [ProcessingFee]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_PaymentGatewayFee]  DEFAULT ((5)) FOR [PaymentGatewayFee]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_IsProcessingFeePercentage]  DEFAULT ((1)) FOR [IsProcessingFeePercentage]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_IsPaymentGatewayFeePercentage]  DEFAULT ((1)) FOR [IsPaymentGatewayFeePercentage]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_TaxConcent]  DEFAULT ((0)) FOR [TaxConcent]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_TaxRegistration]  DEFAULT ('') FOR [TaxRegistration]
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair] ADD  CONSTRAINT [DF_SupplierDeliveryOptionPair_DeliveryCharges]  DEFAULT ((0)) FOR [DeliveryCharges]
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair] ADD  CONSTRAINT [DF_SupplierDeliveryOptionPair_MinOrderLimit]  DEFAULT ((0)) FOR [MinOrderLimit]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_TaxValue]  DEFAULT ((0)) FOR [TaxValue]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_IsDeleted]  DEFAULT ((0)) FOR [StatusID]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_IsPercentage]  DEFAULT ((1)) FOR [IsPercentage]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[TaxType] ADD  CONSTRAINT [DF_TaxTypes_TaxTypeTitle]  DEFAULT ('') FOR [TaxTypeTitle]
GO
ALTER TABLE [dbo].[TaxType] ADD  CONSTRAINT [DF_TaxTypes_TaxTypeDescription]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[TaxType] ADD  CONSTRAINT [DF_TaxType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_ActivationCode]  DEFAULT ((0)) FOR [PasswordResetCode]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_AcvtivationGUID]  DEFAULT ((0)) FOR [AcvtivationGUID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_StatusID]  DEFAULT ((6)) FOR [StatusID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_IsLoggedIn]  DEFAULT ((0)) FOR [IsLoggedIn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_GroupID]  DEFAULT ((0)) FOR [GroupID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_CreatedByUserID]  DEFAULT ((0)) FOR [CreatedByUserID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_LastModifiedByUserID]  DEFAULT ((0)) FOR [LastModifiedByUserID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_ApprovedByUserID]  DEFAULT (NULL) FOR [ApprovedByUserID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_Users_ApprovedDateTime]  DEFAULT (NULL) FOR [ApprovedDateTime]
GO
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [DF_UserType_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[VerificationStatus] ADD  CONSTRAINT [DF_VerificationStatus_IsSystem]  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Profiles]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_AddressTypes] FOREIGN KEY([AddressTypeID])
REFERENCES [dbo].[AddressType] ([AddressTypeID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Addresses_AddressTypes]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_LocationTree] FOREIGN KEY([LocationID])
REFERENCES [dbo].[LocationTree] ([LocationID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Addresses_LocationTree]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_Attribute_AttributeType] FOREIGN KEY([AttributeTypeID])
REFERENCES [dbo].[AttributeType] ([AttributeTypeID])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_Attribute_AttributeType]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_Attribute_DataType] FOREIGN KEY([DataTypeID])
REFERENCES [dbo].[DataType] ([DataTypeID])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_Attribute_DataType]
GO
ALTER TABLE [dbo].[BankAccount]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_BankAccount] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[BankAccount] CHECK CONSTRAINT [FK_Supplier_BankAccount]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_CartOrder] FOREIGN KEY([CartOrderID])
REFERENCES [dbo].[CartOrder] ([CartOrderID])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_CartOrder]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Product]
GO
ALTER TABLE [dbo].[CartItemAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_CartItemAttribute_Attribute] FOREIGN KEY([AttributeID])
REFERENCES [dbo].[Attribute] ([AttributeID])
GO
ALTER TABLE [dbo].[CartItemAttributePair] CHECK CONSTRAINT [FK_CartItemAttribute_Attribute]
GO
ALTER TABLE [dbo].[CartItemAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_CartItemAttribute_CartItem] FOREIGN KEY([CartItemID])
REFERENCES [dbo].[CartItem] ([CartItemID])
GO
ALTER TABLE [dbo].[CartItemAttributePair] CHECK CONSTRAINT [FK_CartItemAttribute_CartItem]
GO
ALTER TABLE [dbo].[CartOrder]  WITH CHECK ADD  CONSTRAINT [FK_CartOrder_CartOrder] FOREIGN KEY([ParentCartID])
REFERENCES [dbo].[CartOrder] ([CartOrderID])
GO
ALTER TABLE [dbo].[CartOrder] CHECK CONSTRAINT [FK_CartOrder_CartOrder]
GO
ALTER TABLE [dbo].[CartOrder]  WITH CHECK ADD  CONSTRAINT [FK_CartOrder_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([OrderStatusID])
GO
ALTER TABLE [dbo].[CartOrder] CHECK CONSTRAINT [FK_CartOrder_OrderStatus]
GO
ALTER TABLE [dbo].[CartOrder]  WITH CHECK ADD  CONSTRAINT [FK_CartOrder_Supplier] FOREIGN KEY([OrderSupplierId])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[CartOrder] CHECK CONSTRAINT [FK_CartOrder_Supplier]
GO
ALTER TABLE [dbo].[CartOrder]  WITH CHECK ADD  CONSTRAINT [FK_CartOrder_SupplierDeliveryOptionPair] FOREIGN KEY([SupplierDeliveryOptionPairID])
REFERENCES [dbo].[SupplierDeliveryOptionPair] ([SupplierDeliveryOptionPairID])
GO
ALTER TABLE [dbo].[CartOrder] CHECK CONSTRAINT [FK_CartOrder_SupplierDeliveryOptionPair]
GO
ALTER TABLE [dbo].[Category]  WITH NOCHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([CategoryParentID])
REFERENCES [dbo].[Category] ([CategoryID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Category] NOCHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_CategoryType] FOREIGN KEY([CategoryTypeID])
REFERENCES [dbo].[CategoryType] ([CategoryTypeID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_CategoryType]
GO
ALTER TABLE [dbo].[CategoryAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_CategoryAttributePair_Attribute] FOREIGN KEY([AttributeID])
REFERENCES [dbo].[Attribute] ([AttributeID])
GO
ALTER TABLE [dbo].[CategoryAttributePair] CHECK CONSTRAINT [FK_CategoryAttributePair_Attribute]
GO
ALTER TABLE [dbo].[CategoryAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_CategoryAttributePair_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[CategoryAttributePair] CHECK CONSTRAINT [FK_CategoryAttributePair_Category]
GO
ALTER TABLE [dbo].[ChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_Chat_ChatMessage] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chat] ([ChatId])
GO
ALTER TABLE [dbo].[ChatMessage] CHECK CONSTRAINT [FK_Chat_ChatMessage]
GO
ALTER TABLE [dbo].[LocationTree]  WITH CHECK ADD  CONSTRAINT [FK_LocationTree_LocationLevels] FOREIGN KEY([LocationLevelID])
REFERENCES [dbo].[LocationLevel] ([LocationLevelID])
GO
ALTER TABLE [dbo].[LocationTree] CHECK CONSTRAINT [FK_LocationTree_LocationLevels]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Options_Options] FOREIGN KEY([ParentOptionID])
REFERENCES [dbo].[Option] ([OptionID])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Options_Options]
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD  CONSTRAINT [FK_Options_OptionTypes] FOREIGN KEY([OptionTypeID])
REFERENCES [dbo].[OptionType] ([OptionTypeID])
GO
ALTER TABLE [dbo].[Option] CHECK CONSTRAINT [FK_Options_OptionTypes]
GO
ALTER TABLE [dbo].[OrderDeliveryDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDeliveryDetail_Address] FOREIGN KEY([DeliveryAddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[OrderDeliveryDetail] CHECK CONSTRAINT [FK_OrderDeliveryDetail_Address]
GO
ALTER TABLE [dbo].[OrderPayment]  WITH CHECK ADD  CONSTRAINT [FK_OrderPayment_CartOrder] FOREIGN KEY([CartOrderID])
REFERENCES [dbo].[CartOrder] ([CartOrderID])
GO
ALTER TABLE [dbo].[OrderPayment] CHECK CONSTRAINT [FK_OrderPayment_CartOrder]
GO
ALTER TABLE [dbo].[OrderPayment]  WITH CHECK ADD  CONSTRAINT [FK_OrderPayment_Payment] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([PaymentID])
GO
ALTER TABLE [dbo].[OrderPayment] CHECK CONSTRAINT [FK_OrderPayment_Payment]
GO
ALTER TABLE [dbo].[OrderStatusMap]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatusMap_OrderStatus] FOREIGN KEY([ParentOrderStatusID])
REFERENCES [dbo].[OrderStatus] ([OrderStatusID])
GO
ALTER TABLE [dbo].[OrderStatusMap] CHECK CONSTRAINT [FK_OrderStatusMap_OrderStatus]
GO
ALTER TABLE [dbo].[OrderStatusMap]  WITH CHECK ADD  CONSTRAINT [FK_OrderStatusMap_OrderStatus1] FOREIGN KEY([ChildOrderStatusID])
REFERENCES [dbo].[OrderStatus] ([OrderStatusID])
GO
ALTER TABLE [dbo].[OrderStatusMap] CHECK CONSTRAINT [FK_OrderStatusMap_OrderStatus1]
GO
ALTER TABLE [dbo].[PackagedProduct]  WITH CHECK ADD  CONSTRAINT [FK_ProductTree_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[PackagedProduct] CHECK CONSTRAINT [FK_ProductTree_Products]
GO
ALTER TABLE [dbo].[PackagedProduct]  WITH CHECK ADD  CONSTRAINT [FK_ProductTree_Products1] FOREIGN KEY([ChildProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[PackagedProduct] CHECK CONSTRAINT [FK_ProductTree_Products1]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_CartOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[CartOrder] ([CartOrderID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_CartOrder]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PayType] FOREIGN KEY([PayTypeID])
REFERENCES [dbo].[PayType] ([PayTypeID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PayType]
GO
ALTER TABLE [dbo].[PayOptionMatrix]  WITH CHECK ADD  CONSTRAINT [FK_PayOptionMatrix_PayMode] FOREIGN KEY([PayModeID])
REFERENCES [dbo].[PayMode] ([PayModeID])
GO
ALTER TABLE [dbo].[PayOptionMatrix] CHECK CONSTRAINT [FK_PayOptionMatrix_PayMode]
GO
ALTER TABLE [dbo].[PayOptionMatrix]  WITH CHECK ADD  CONSTRAINT [FK_PayOptionMatrix_PayType] FOREIGN KEY([PayTypeID])
REFERENCES [dbo].[PayType] ([PayTypeID])
GO
ALTER TABLE [dbo].[PayOptionMatrix] CHECK CONSTRAINT [FK_PayOptionMatrix_PayType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductType] ([ProductTypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_TaxType] FOREIGN KEY([TaxTypeID])
REFERENCES [dbo].[TaxType] ([TaxTypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_TaxType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Brands]
GO
ALTER TABLE [dbo].[ProductAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributePair_Attribute] FOREIGN KEY([AttributeID])
REFERENCES [dbo].[Attribute] ([AttributeID])
GO
ALTER TABLE [dbo].[ProductAttributePair] CHECK CONSTRAINT [FK_ProductAttributePair_Attribute]
GO
ALTER TABLE [dbo].[ProductAttributePair]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributePair_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductAttributePair] CHECK CONSTRAINT [FK_ProductAttributePair_Product]
GO
ALTER TABLE [dbo].[ProductCategoryPair]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryPair_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[ProductCategoryPair] CHECK CONSTRAINT [FK_ProductCategoryPair_Category]
GO
ALTER TABLE [dbo].[ProductCategoryPair]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoryPair_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductCategoryPair] CHECK CONSTRAINT [FK_ProductCategoryPair_Product]
GO
ALTER TABLE [dbo].[ProductMediaDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductMediaDetail_MediaContentType] FOREIGN KEY([MediaContentTypeID])
REFERENCES [dbo].[MediaContentType] ([MediaContentTypeID])
GO
ALTER TABLE [dbo].[ProductMediaDetail] CHECK CONSTRAINT [FK_ProductMediaDetail_MediaContentType]
GO
ALTER TABLE [dbo].[ProductMediaDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductMediaDetails_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductMediaDetail] CHECK CONSTRAINT [FK_ProductMediaDetails_Products]
GO
ALTER TABLE [dbo].[ProductViewItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductViewProducts_ProductMediaDetails] FOREIGN KEY([ProductMediaID])
REFERENCES [dbo].[ProductMediaDetail] ([ProductMediaID])
GO
ALTER TABLE [dbo].[ProductViewItem] CHECK CONSTRAINT [FK_ProductViewProducts_ProductMediaDetails]
GO
ALTER TABLE [dbo].[ProductViewItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductViewProducts_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ProductViewItem] CHECK CONSTRAINT [FK_ProductViewProducts_Products]
GO
ALTER TABLE [dbo].[ProductViewItem]  WITH CHECK ADD  CONSTRAINT [FK_ProductViewProducts_ProductViews] FOREIGN KEY([ProductViewID])
REFERENCES [dbo].[ProductView] ([ProductViewID])
GO
ALTER TABLE [dbo].[ProductViewItem] CHECK CONSTRAINT [FK_ProductViewProducts_ProductViews]
GO
ALTER TABLE [dbo].[ProfileVerification]  WITH CHECK ADD  CONSTRAINT [FK_ProfileVerification_DocumentType] FOREIGN KEY([DocumentTypeID])
REFERENCES [dbo].[DocumentType] ([DocumentTypeID])
GO
ALTER TABLE [dbo].[ProfileVerification] CHECK CONSTRAINT [FK_ProfileVerification_DocumentType]
GO
ALTER TABLE [dbo].[ProfileVerification]  WITH CHECK ADD  CONSTRAINT [FK_ProfileVerification_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ProfileVerification] CHECK CONSTRAINT [FK_ProfileVerification_Profile]
GO
ALTER TABLE [dbo].[ProfileVerification]  WITH CHECK ADD  CONSTRAINT [FK_ProfileVerification_VerificationStatus] FOREIGN KEY([VerificationStatusID])
REFERENCES [dbo].[VerificationStatus] ([VerificationStatusID])
GO
ALTER TABLE [dbo].[ProfileVerification] CHECK CONSTRAINT [FK_ProfileVerification_VerificationStatus]
GO
ALTER TABLE [dbo].[RoleOptionPair]  WITH CHECK ADD  CONSTRAINT [FK_RoleOptionPairs_Options] FOREIGN KEY([OptionID])
REFERENCES [dbo].[Option] ([OptionID])
GO
ALTER TABLE [dbo].[RoleOptionPair] CHECK CONSTRAINT [FK_RoleOptionPairs_Options]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_ScheduleType] FOREIGN KEY([ScheduleTypeID])
REFERENCES [dbo].[ScheduleType] ([ScheduleTypeID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_ScheduleType]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Supplier]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_Profile]
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDeliveryOptionPair_DeliveryOption] FOREIGN KEY([DeliveryOptionID])
REFERENCES [dbo].[DeliveryOption] ([DeliveryOptionID])
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair] CHECK CONSTRAINT [FK_SupplierDeliveryOptionPair_DeliveryOption]
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDeliveryOptionPair_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[SupplierDeliveryOptionPair] CHECK CONSTRAINT [FK_SupplierDeliveryOptionPair_Supplier]
GO
ALTER TABLE [dbo].[Tax]  WITH CHECK ADD  CONSTRAINT [FK_Tax_TaxType] FOREIGN KEY([TaxTypeID])
REFERENCES [dbo].[TaxType] ([TaxTypeID])
GO
ALTER TABLE [dbo].[Tax] CHECK CONSTRAINT [FK_Tax_TaxType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
/****** Object:  StoredProcedure [dbo].[Address_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Address_Insert] 
	 @New_ProfileID as bigint
	,@New_AddressTypeID as int
	,@New_PlotNumber as nvarchar(100)
	,@New_StreetNumber as nvarchar(100)
	,@New_CountryID as bigint
	,@New_ProvinceID as bigint
	,@New_CityID as bigint
	,@New_LocationID as bigint
	,@New_NearestLandmark as nvarchar(200)
	,@New_PostalCode as nvarchar(50)
	,@New_MapLink as varchar(1000)
	,@Exisitng_SupplierId as bigint null
	,@SpProfileID as bigint
	,@AddressID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Address] 
		(
		[ProfileID]
		,[AddressTypeID]
		,[PlotNumber]
		,[StreetNumber]
		,[CountryID]
		,[ProvinceID]
		,[CityID]
		,[LocationID]
		,[NearestLandmark]
		,[PostalCode]
		,[MapLink]
		,[CreatedDateTime]
		,[CreatedByUserID]
		,[LastModifiedDateTime]
		,[LastModifiedByUserID]
		)
	VALUES
		(
		  @New_ProfileID
		, @New_AddressTypeID
		, @New_PlotNumber
		, @New_StreetNumber
		, @New_CountryID
		, @New_ProvinceID
		, @New_CityID
		, @New_LocationID
		, @New_NearestLandmark
		, @New_PostalCode
		, @New_MapLink
		, GETDATE()
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		)

	SET @AddressID = SCOPE_IDENTITY();

	if(@New_AddressTypeID = 1 and @Exisitng_SupplierId is not null) -- Business Address
	Begin
		Update Supplier 
		Set BusinessAddressID = @AddressID
		where SupplierID = @Exisitng_SupplierId
	End
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Address_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Address_Update] 
	@Original_AddressID as bigint
	,@New_ProfileID as bigint
	,@New_AddressTypeID as int
	,@New_PlotNumber as nvarchar(100)
	,@New_StreetNumber as nvarchar(100)
	,@New_CountryID as bigint
	,@New_ProvinceID as bigint
	,@New_CityID as bigint
	,@New_LocationID as bigint
	,@New_NearestLandmark as nvarchar(200)
	,@New_PostalCode as nvarchar(50)
	,@New_MapLink as varchar(1000)

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Address] 
	SET
		[ProfileID]=@New_ProfileID
		,[AddressTypeID]=@New_AddressTypeID
		,[PlotNumber]=@New_PlotNumber
		,[StreetNumber]=@New_StreetNumber
		,[CountryID]=@New_CountryID 
		,[ProvinceID]=@New_ProvinceID 
		,[CityID]=@New_CityID 
		,[LocationID]=@New_LocationID
		,[NearestLandmark]=@New_NearestLandmark
		,[PostalCode]=@New_PostalCode
		,[MapLink]=@New_MapLink
		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[AddressID]=@Original_AddressID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- AddressContactInfoPair --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AddressType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddressType_Insert] 
	@New_AddressTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@AddressTypeID as int OUTPUT
AS
BEGIN
	INSERT INTO [AddressType] 
		(
		[AddressTypeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_AddressTypeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @AddressTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AddressType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddressType_Update] 
	@Original_AddressTypeID as int
	,@New_AddressTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [AddressType] 
	SET
		[AddressTypeTitle]=@New_AddressTypeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[AddressTypeID]=@Original_AddressTypeID

	RETURN @@RowCount
END

-- AppConfig --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AppConfig_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AppConfig_Insert] 
	@New_ConfigTitle as nvarchar(50)
	,@New_ConfigValue as nvarchar(200)
	,@New_DisplayText as nvarchar(50)
	,@New_ParentConfigID as bigint
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@ConfigID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [AppConfig] 
		(
		[ConfigTitle]
		,[ConfigValue]
		,[DisplayText]
		,[ParentConfigID]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_ConfigTitle
		, @New_ConfigValue
		, @New_DisplayText
		, @New_ParentConfigID
		, @New_Description
		, @New_IsSystem
		)

	SET @ConfigID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AppConfig_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AppConfig_Update] 
	@Original_ConfigID as bigint
	,@New_ConfigTitle as nvarchar(50)
	,@New_ConfigValue as nvarchar(200)
	,@New_DisplayText as nvarchar(50)
	,@New_ParentConfigID as bigint
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [AppConfig] 
	SET
		[ConfigTitle]=@New_ConfigTitle
		,[ConfigValue]=@New_ConfigValue
		,[DisplayText]=@New_DisplayText
		,[ParentConfigID]=@New_ParentConfigID
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[ConfigID]=@Original_ConfigID

	RETURN @@RowCount
END

-- Attribute --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Attribute_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attribute_Insert] 
	@New_AttributeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_AttributeTypeID as bigint
	,@New_DataTypeID as bigint
	,@New_DataTypeSize as bigint
	,@New_DefaultValue as nvarchar(500)
	,@New_IsMandatory as bit
	,@New_IsMultiSelect as bit
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@AttributeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Attribute] 
		(
		[AttributeTitle]
		,[Description]
		,[AttributeTypeID]
		,[DataTypeID]
		,[DataTypeSize]
		,[DefaultValue]
		,[IsMandatory]
		,[IsMultiSelect]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[IsSystem]
		)
	VALUES
		(
		@New_AttributeTitle
		, @New_Description
		, @New_AttributeTypeID
		, @New_DataTypeID
		, @New_DataTypeSize
		, @New_DefaultValue
		, @New_IsMandatory
		, @New_IsMultiSelect
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		, @New_IsSystem
		)

	SET @AttributeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Attribute_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attribute_Update] 
	@Original_AttributeID as bigint
	,@New_AttributeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_AttributeTypeID as bigint
	,@New_DataTypeID as bigint
	,@New_DataTypeSize as bigint
	,@New_DefaultValue as nvarchar(500)
	,@New_IsMandatory as bit
	,@New_IsMultiSelect as bit
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Attribute] 
	SET
		[AttributeTitle]=@New_AttributeTitle
		,[Description]=@New_Description
		,[AttributeTypeID]=@New_AttributeTypeID
		,[DataTypeID]=@New_DataTypeID
		,[DataTypeSize]=@New_DataTypeSize
		,[DefaultValue]=@New_DefaultValue
		,[IsMandatory]=@New_IsMandatory
		,[IsMultiSelect]=@New_IsMultiSelect
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
		,[IsSystem]=@New_IsSystem
	WHERE 
		[AttributeID]=@Original_AttributeID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- AttributeType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AttributeType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttributeType_Insert] 
	@New_AttributeTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@AttributeTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [AttributeType] 
		(
		[AttributeTypeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_AttributeTypeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @AttributeTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AttributeType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttributeType_Update] 
	@Original_AttributeTypeID as bigint
	,@New_AttributeTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [AttributeType] 
	SET
		[AttributeTypeTitle]=@New_AttributeTypeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[AttributeTypeID]=@Original_AttributeTypeID

	RETURN @@RowCount
END

-- Brand --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankAccount_Insert] 
	 @New_SupplierId as bigint
	,@New_Name as varchar(max)
	,@New_Address as varchar(max)
	,@New_AccountTitle as varchar(max)
	,@New_AccountNumber as varchar(max)
	,@New_IBAN as varchar(max)
	,@New_BankId as int OUTPUT
AS
BEGIN
	INSERT INTO [BankAccount] 
		(
		 [SupplierId]
		,[Name]
		,[Address]
		,[AccountTitle]
		,[AccountNumber]
		,[IBAN]
		)
	VALUES
		(
		
		 @New_SupplierId
		,@New_Name
		,@New_Address
		,@New_AccountTitle
		,@New_AccountNumber
		,@New_IBAN		
		)

	SET @New_BankId = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[BankAccount_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankAccount_Update] 
	 @Original_BankId as int
	,@New_SupplierId as bigint
	,@New_Name as varchar(max)
	,@New_Address as varchar(max)
	,@New_AccountTitle as varchar(max)
	,@New_AccountNumber as varchar(max)
	,@New_IBAN as varchar(max)
AS
BEGIN
	UPDATE [BankAccount] 
	SET
		 [SupplierId]=@New_SupplierId
		,[Name]=@New_Name
		,[Address]=@New_Address
		,[AccountTitle]=@New_AccountTitle
		,[AccountNumber]=@New_AccountNumber
		,[IBAN]=@New_IBAN
	WHERE 
		[BankId]=@Original_BankId

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Brand_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Brand_Insert] 
	@New_BrandName as nvarchar(100)
	,@New_ManufacturerName as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@BrandID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Brand] 
		(
		[BrandName]
		,[ManufacturerName]
		,[Description]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[IsSystem]
		)
	VALUES
		(
		@New_BrandName
		, @New_ManufacturerName
		, @New_Description
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		, @New_IsSystem
		)

	SET @BrandID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Brand_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Brand_Update] 
	@Original_BrandID as bigint
	,@New_BrandName as nvarchar(100)
	,@New_ManufacturerName as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Brand] 
	SET
		[BrandName]=@New_BrandName
		,[ManufacturerName]=@New_ManufacturerName
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
		,[IsSystem]=@New_IsSystem
	WHERE 
		[BrandID]=@Original_BrandID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- CartItem --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Bulk_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bulk_Update] 


	 @TableName as varchar(200)
	,@WhereField as varchar(200)
	,@WhereInClause as varchar(max)
	,@UpdateField as varchar(200)
	,@UpdateValue as varchar(200)	
AS
BEGIN

declare @sql nvarchar(Max)

Set @sql='UPDATE [' + @TableName + '] set [' + @UpdateField  + ']=' + @UpdateValue + ' WHERE [' + @WhereField + '] IN ('+@WhereInClause+')'

exec sp_executesql @sql

	RETURN @@RowCount
END

SET ANSI_NULLS ON



GO
/****** Object:  StoredProcedure [dbo].[Cart_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cart_Insert] 
	 @New_BuyerProfileID as bigint
	,@New_CartStatusID as bigint
	,@New_StatusID as bigint
	,@New_CartTotal as float
	,@New_TaxTotal as float
	,@New_DiscountTotal as float
	,@SpProfileID as bigint
	,@CartID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CartOrder] 
		(
		 [BuyerProfileID]
		,[ParentCartID]
		,[OrderStatusID]
		,[StatusID]

		,[DeliveryAddressID] -- null
		,[DeliveryAddress] -- null
		,[OrderSupplierId] -- null
		,[SupplierDeliveryOptionPairID] -- null

		,[OrderTotal]
		,[TaxTotal]
		,[DiscountTotal] 

		,[DeliveryTotal] -- 0
		,[PaymentTotal] -- 0
		,[CalculatedPayout] -- 0
		,[ActualPayout] -- 0
		,[CalculatedPayIn] -- 0
		,[ActualPayIn] -- 0


		,[CreatedDateTime]
		,[CreatedByUserID]
		,[LastModifiedDateTime]
		,[LastModifiedByUserID]
		)
	VALUES
		(
		  @New_BuyerProfileID
		, null --[ParentCartID] 
		, @New_CartStatusID
		, @New_StatusID
		, null -- [DeliveryAddressID]
		, null -- [DeliveryAddress]
		, null -- [OrderSupplierId]
		, null -- [SupplierDeliveryOptionPairID]
		, @New_CartTotal
		, @New_TaxTotal
		, @New_DiscountTotal
		, 0 					--[DeliveryTotal]
		, 0						--[PaymentTotal] 
		, 0						--[CalculatedPayout]
		, 0						--[ActualPayout]
		, 0						--[CalculatedPayIn] 
		, 0						--[ActualPayIn] 

		, GETDATE()
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		)

	SET @CartID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Cart_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cart_Update] 
	 @Original_CartID as bigint
	,@New_CartStatusID as bigint
	,@New_StatusID as bigint

	,@New_CartTotal as float
	,@New_TaxTotal as float
	--,@New_DeliveryTotal as float
	,@New_DiscountTotal as float
	--,@New_PaymentTotal as float

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [CartOrder] 
	SET
		 [OrderStatusID]=@New_CartStatusID
		,[StatusID]=@New_StatusID
		,[OrderTotal]=@New_CartTotal
		,[TaxTotal]=@New_TaxTotal
		--,[DeliveryTotal]=@New_DeliveryTotal
		,[DiscountTotal]=@New_DiscountTotal
		--,[PaymentTotal]=@New_PaymentTotal

		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[CartOrderID]=@Original_CartID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Category --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CartItem_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CartItem_Insert] 
	@New_CartOrderID as bigint
	,@New_ProductID as bigint
	,@New_UnitPrice as float
	,@New_Quantity as bigint
	,@New_TaxRateApplied as nchar(10)
	,@New_TaxAmount as float
	,@New_DiscountAmount as float
	,@New_ItemTotalPrice as float
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@CartItemID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CartItem] 
		(
		[CartOrderID]
		,[ProductID]
		,[UnitPrice]
		,[Quantity]
		,[TaxRateApplied]
		,[TaxAmount]
		,[DiscountAmount]
		,[ItemTotalPrice]
		,[StatusID]
		,[CreatedDateTime]
		,[CreatedByUserID]
		,[LastModifiedDateTime]
		,[LastModifiedByUserID]
		)
	VALUES
		(
		@New_CartOrderID
		, @New_ProductID
		, @New_UnitPrice
		, @New_Quantity
		, @New_TaxRateApplied
		, @New_TaxAmount
		, @New_DiscountAmount
		, @New_ItemTotalPrice
		, @New_StatusID
		, GETDATE()
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		)

	SET @CartItemID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CartItem_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CartItem_Update] 
	@Original_CartItemID as bigint
	,@New_CartOrderID as bigint
	,@New_ProductID as bigint
	,@New_UnitPrice as float
	,@New_Quantity as bigint
	,@New_TaxRateApplied as nchar(10)
	,@New_TaxAmount as float
	,@New_DiscountAmount as float
	,@New_ItemTotalPrice as float
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [CartItem] 
	SET
		[CartOrderID]=@New_CartOrderID
		,[ProductID]=@New_ProductID
		,[UnitPrice] = @New_UnitPrice
		,[Quantity]=@New_Quantity
		,[TaxRateApplied]=@New_TaxRateApplied
		,[TaxAmount]=@New_TaxAmount
		,[DiscountAmount]=@New_DiscountAmount
		,[ItemTotalPrice]=@New_ItemTotalPrice
		,[StatusID]=@New_StatusID
		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[CartItemID]=@Original_CartItemID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- CartOrder --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CartOrder_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CartOrder_Insert] 
	@New_ParentCartID as bigint
	,@New_BuyerProfileID as bigint
	,@New_OrderStatusID as bigint
	,@New_StatusID as bigint
	,@New_DeliveryAddressID as bigint
	,@New_DeliveryAddress as varchar(max)
	,@New_OrderSupplierID as bigint
	,@New_SupplierDeliveryOptionPairID as bigint
	,@New_OrderTotal as float
	,@New_TaxTotal as float
	,@SpProfileID as bigint
	,@CartOrderID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CartOrder] 
		(
		[ParentCartID]
		,[BuyerProfileID]
		,[OrderStatusID]
		,[StatusID]
		,[DeliveryAddressID]
		,[DeliveryAddress]
		,[OrderSupplierId]
		,[SupplierDeliveryOptionPairID]
		,[OrderTotal]
		,[TaxTotal]
		,[CreatedDateTime]
		,[CreatedByUserID]
		,[LastModifiedDateTime]
		,[LastModifiedByUserID]
		)
	VALUES
		(
		@New_ParentCartID
		, @New_BuyerProfileID
		, @New_OrderStatusID
		, @New_StatusID
		, @New_DeliveryAddressID
		, @New_DeliveryAddress
		, @New_OrderSupplierID
		, @New_SupplierDeliveryOptionPairID
		, @New_OrderTotal
		, @New_TaxTotal
		, GETDATE()
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		)

	SET @CartOrderID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CartOrder_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CartOrder_Update] 
	@Original_CartOrderID as bigint
	,@New_ParentCartID as bigint
	,@New_BuyerProfileID as bigint
	,@New_OrderStatusID as bigint
	,@New_StatusID as bigint
	,@New_DeliveryAddressID as bigint
	,@New_DeliveryAddress as varchar(max)
	,@New_OrderSupplierID as bigint
	,@New_SupplierDeliveryOptionPairID as bigint
	,@New_OrderTotal as float
	,@New_TaxTotal as float
	,@New_DeliveryTotal as float
	,@New_DiscountTotal as float
	,@New_PaymentTotal as float
	,@New_CalculatedPayout as float
	,@New_ActualPayout as float
	,@New_CalculatedPayIn as float
	,@New_ActualPayIn as float
	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [CartOrder] 
	SET
		 [ParentCartID]=@New_ParentCartID
		,[BuyerProfileID]=@New_BuyerProfileID
		,[OrderStatusID]=@New_OrderStatusID
		,[StatusID]=@New_StatusID
		,[DeliveryAddressID]=@New_DeliveryAddressID
		,[DeliveryAddress]=@New_DeliveryAddress
		,[OrderSupplierId]=@New_OrderSupplierID
		,[SupplierDeliveryOptionPairID]=@New_SupplierDeliveryOptionPairID
		,[OrderTotal]=@New_OrderTotal
		,[TaxTotal]=@New_TaxTotal
		,[DeliveryTotal]=@New_DeliveryTotal
		,[DiscountTotal]=@New_DiscountTotal
		,[PaymentTotal]=@New_PaymentTotal
		,[CalculatedPayout]=@New_CalculatedPayout
		,[ActualPayout]=@New_ActualPayout
		,[CalculatedPayIn]=@New_CalculatedPayIn
		,[ActualPayIn]=@New_ActualPayIn 
		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[CartOrderID]=@Original_CartOrderID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Category --
SET ANSI_NULLS ON

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Category_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Category_Insert] 
	@New_CategoryTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_LogoPath as nvarchar(4000)
	,@New_CategoryTypeID as bigint
	,@New_CategoryParentID as bigint
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@CategoryID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Category] 
		(
		[CategoryTitle]
		,[Description]
		,[LogoPath]
		,[CategoryTypeID]
		,[CategoryParentID]
		,[StatusID]
		,[IsSystem]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		@New_CategoryTitle
		, @New_Description
		, @New_LogoPath
		, @New_CategoryTypeID
		, @New_CategoryParentID
		, @New_StatusID
		, @New_IsSystem
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @CategoryID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Category_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Category_Update] 
	@Original_CategoryID as bigint
	,@New_CategoryTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_LogoPath as nvarchar(4000)
	,@New_CategoryTypeID as bigint
	,@New_CategoryParentID as bigint
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Category] 
	SET
		[CategoryTitle]=@New_CategoryTitle
		,[Description]=@New_Description
		,[LogoPath]=@New_LogoPath
		,[CategoryTypeID]=@New_CategoryTypeID
		,[CategoryParentID]=@New_CategoryParentID
		,[StatusID]=@New_StatusID
		,[IsSystem]=@New_IsSystem
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[CategoryID]=@Original_CategoryID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- CategoryAttributePair --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CategoryAttributePair_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CategoryAttributePair_Insert] 
	@New_CategoryID as bigint
	,@New_AttributeID as bigint
	,@New_AttributeValue as varchar(5000)
	,@New_DisplayOrder as bigint
	,@New_IsAssigned as bit

	,@CategoryAttributePairID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CategoryAttributePair] 
		(
		[CategoryID]
		,[AttributeID]
		,[AttributeValue]
		,[DisplayOrder]
		,[IsAssigned]
		)
	VALUES
		(
		@New_CategoryID
		, @New_AttributeID
		, @New_AttributeValue
		, @New_DisplayOrder
		, @New_IsAssigned
		)

	SET @CategoryAttributePairID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CategoryAttributePair_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CategoryAttributePair_Update] 
	@Original_CategoryAttributePairID as bigint
	,@New_CategoryID as bigint
	,@New_AttributeID as bigint
	,@New_AttributeValue as varchar(5000)
	,@New_DisplayOrder as bigint
	,@New_IsAssigned as bit
AS
BEGIN
	UPDATE [CategoryAttributePair] 
	SET
		[CategoryID]=@New_CategoryID
		,[AttributeID]=@New_AttributeID
		,[AttributeValue]=@New_AttributeValue
		,[DisplayOrder]=@New_DisplayOrder
		,[IsAssigned]=@New_IsAssigned
	WHERE 
		[CategoryAttributePairID]=@Original_CategoryAttributePairID

	RETURN @@RowCount
END

-- CategoryType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CategoryType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CategoryType_Insert] 
	@New_Title as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@CategoryTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CategoryType] 
		(
		[Title]
		,[Description]
		,[StatusID]
		,[IsSystem]
		)
	VALUES
		(
		@New_Title
		, @New_Description
		, @New_StatusID
		, @New_IsSystem
		)

	SET @CategoryTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CategoryType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CategoryType_Update] 
	@Original_CategoryTypeID as bigint
	,@New_Title as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [CategoryType] 
	SET
		[Title]=@New_Title
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[IsSystem]=@New_IsSystem
	WHERE 
		[CategoryTypeID]=@Original_CategoryTypeID

	RETURN @@RowCount
END

-- ContactInfo --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Chat_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chat_Insert] 
	 @New_ChatCode as nvarchar(max)
	,@New_ProfileId1 as bigint
	,@New_ProfileId2 as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@ChatID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Chat] 
		(
		 [ChatCode]
		,[ProfileId1]
		,[ProfileId2]
		,[StatusId]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_ChatCode
		, @New_ProfileId1
		, @New_ProfileId2
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @ChatID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Chat_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chat_Update] 
	 @Original_ChatID as bigint
	,@New_ChatCode as nvarchar(max)
	,@New_ProfileId1 as bigint
	,@New_ProfileId2 as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Chat] 
	SET
		 [ChatCode]=@New_ChatCode
		,[ProfileId1]=@New_ProfileId1
		,[ProfileId2]=@New_ProfileId2
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()

	WHERE 
		[ChatID]=@Original_ChatID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Chat --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ChatMessage_MarkRead]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChatMessage_MarkRead] 
	 @Original_ChatID as bigint
AS
BEGIN
	UPDATE [ChatMessage] 
	SET
		 [IsRead]=1
		,[IsReceived]=1
		,[ReadDateTime]=GETDATE()

	WHERE 
		[ChatID]=@Original_ChatID

	RETURN @@RowCount
END

-- Chat --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ChatMessage_MarkReadByProfileID]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ChatMessage_MarkReadByProfileID] 
	 @Original_ChatID as bigint,
	 @Original_ProfileID as bigint
AS
BEGIN
	UPDATE [ChatMessage] 
	SET
		 [IsRead]=1
		,[IsReceived]=1
		,[ReadDateTime]=GETDATE()

	WHERE 
		[ChatID]=@Original_ChatID
		and [ReceiverProfileId]=@Original_ProfileID

	RETURN @@RowCount
END

-- Chat --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ChatMessage_SendMessage]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChatMessage_SendMessage] 
	 @Original_ChatId as bigint
	,@New_MessageCode as nvarchar(max)
	,@New_SenderProfileId as bigint
	,@New_ReceiverProfileId as bigint
	,@New_Message as nvarchar(max)
	,@New_StatusID as bigint
	,@ChatMessageID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ChatMessage] 
		(
		 [MessageCode]
		,[ChatId]
		,[SenderProfileId]
		,[ReceiverProfileId]
		,[Message]
		,[SentDateTime]
		,[IsRead]
		,[IsReceived]
		,[ReadDateTime]
		,[StatusId]
		)
	VALUES
		(
		  @New_MessageCode
		, @Original_ChatId
		, @New_SenderProfileId
		, @New_ReceiverProfileId
		, @New_Message
		, GETDATE()
		,0
		,0
		, GETDATE()
		, @New_StatusID
		)
	SET @ChatMessageID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CustomerReview_AutoUpdateStatus]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerReview_AutoUpdateStatus] 
AS
BEGIN
DECLARE @rowCounter INT;

	UPDATE [CustomerReview]
	SET
		 StatusID=4,
		 LastModifiedDateTime = GETDATE()
	WHERE 
		 StatusID=1
		 AND 
		 LastModifiedDateTime < GETDATE()-90

SET @rowCounter =  @@RowCount

RETURN @rowCounter

END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[CustomerReview_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerReview_Insert] 
	 @New_SubjectRowID as bigint
	,@New_SubjectID as bigint
	,@New_ReviewText as nvarchar(max)
	,@New_Rating as smallint
	,@New_StatusID as bigint
	,@SpProfileID as bigint
	,@CustomerReviewId as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CustomerReview] 
		(
			 [SubjectRowID]
			,[SubjectID]
			,[ReviewText]
			,[Rating]
			,[StatusID]
			,[CreatedByUserID]
			,[LastModifiedByUserID]
			,[CreatedDateTime]
			,[LastModifiedDateTime]
		)
	VALUES
		(
		 @New_SubjectRowID
		,@New_SubjectID
		,@New_ReviewText
		,@New_Rating
		,@New_StatusID
		,@SpProfileID
		,@SpProfileID
		,GETDATE()
		,GETDATE()
		)

	SET @CustomerReviewId = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[CustomerReview_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerReview_Update] 
	 @Original_CustomerReviewID as bigint
	,@New_SubjectRowID as bigint
	,@New_SubjectID as bigint
	,@New_ReviewText as nvarchar(max)
	,@New_Rating as smallint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [CustomerReview] 
	SET
		 [SubjectRowID] = @New_SubjectRowID
		,[SubjectID] = @New_SubjectID
		,[ReviewText] = @New_ReviewText
		,[Rating] = @New_Rating
		,[StatusID] = @New_StatusID
		,[LastModifiedByUserID] = @SpProfileID
		,[LastModifiedDateTime] = GetDATE()
	WHERE 
		[CustomerReviewID] = @Original_CustomerReviewID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- AttributeType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DataType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DataType_Insert] 
	@New_AssemblyName as nvarchar(200)
	,@New_Namespace as nvarchar(200)
	,@New_ClassName as nvarchar(200)
	,@New_FriendlyName as nvarchar(200)
	,@New_IsSystem as bit
	,@New_SuggestedUIControl as varchar(100)
	,@DataTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [DataType] 
		(
		[AssemblyName]
		,[Namespace]
		,[ClassName]
		,[FriendlyName]
		,[IsSystem]
		,[SuggestedUIControl]
		)
	VALUES
		(
		@New_AssemblyName
		, @New_Namespace
		, @New_ClassName
		, @New_FriendlyName
		, @New_IsSystem
		, @New_SuggestedUIControl
		)

	SET @DataTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DataType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DataType_Update] 
	@Original_DataTypeID as bigint
	,@New_AssemblyName as nvarchar(200)
	,@New_Namespace as nvarchar(200)
	,@New_ClassName as nvarchar(200)
	,@New_FriendlyName as nvarchar(200)
	,@New_IsSystem as bit
	,@New_SuggestedUIControl as varchar(100)

AS
BEGIN
	UPDATE [DataType] 
	SET
		[AssemblyName]=@New_AssemblyName
		,[Namespace]=@New_Namespace
		,[ClassName]=@New_ClassName
		,[FriendlyName]=@New_FriendlyName
		,[IsSystem]=@New_IsSystem
		,[SuggestedUIControl]=@New_SuggestedUIControl
	WHERE 
		[DataTypeID]=@Original_DataTypeID

	RETURN @@RowCount
END

-- DeliveryOption --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DeliveryOption_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeliveryOption_Insert] 
	@New_DeliveryOptionTitle as nvarchar(100)
	,@New_Description as nvarchar(500)

	,@DeliveryOptionID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [DeliveryOption] 
		(
		[DeliveryOptionTitle]
		,[Description]
		)
	VALUES
		(
		@New_DeliveryOptionTitle
		, @New_Description
		)

	SET @DeliveryOptionID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DeliveryOption_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeliveryOption_Update] 
	@Original_DeliveryOptionID as bigint
	,@New_DeliveryOptionTitle as nvarchar(100)
	,@New_Description as nvarchar(500)

AS
BEGIN
	UPDATE [DeliveryOption] 
	SET
		[DeliveryOptionTitle]=@New_DeliveryOptionTitle
		,[Description]=@New_Description
	WHERE 
		[DeliveryOptionID]=@Original_DeliveryOptionID

	RETURN @@RowCount
END

-- DocumentType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DocumentType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DocumentType_Insert] 
	@New_DocumentTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@DocumentTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [DocumentType] 
		(
		[DocumentTypeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_DocumentTypeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @DocumentTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DocumentType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DocumentType_Update] 
	@Original_DocumentTypeID as bigint
	,@New_DocumentTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [DocumentType] 
	SET
		[DocumentTypeTitle]=@New_DocumentTypeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[DocumentTypeID]=@Original_DocumentTypeID

	RETURN @@RowCount
END

-- ExecAction --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ExecAction_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExecAction_Insert] 
	@New_DataTypeID as bigint
	,@New_Method as nvarchar(50)

	,@ExecActionID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ExecAction] 
		(
		[DataTypeID]
		,[Method]
		)
	VALUES
		(
		@New_DataTypeID
		, @New_Method
		)

	SET @ExecActionID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[LocationLevel_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocationLevel_Insert] 
	@New_LocationLevelTitle as nvarchar(50)
	,@New_Description as nvarchar(500)

	,@LocationLevelID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [LocationLevel] 
		(
		[LocationLevelTitle]
		,[Description]
		)
	VALUES
		(
		@New_LocationLevelTitle
		, @New_Description
		)

	SET @LocationLevelID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[LocationLevel_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocationLevel_Update] 
	@Original_LocationLevelID as bigint
	,@New_LocationLevelTitle as nvarchar(50)
	,@New_Description as nvarchar(500)

AS
BEGIN
	UPDATE [LocationLevel] 
	SET
		[LocationLevelTitle]=@New_LocationLevelTitle
		,[Description]=@New_Description
	WHERE 
		[LocationLevelID]=@Original_LocationLevelID

	RETURN @@RowCount
END

-- LocationTree --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[LocationTree_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocationTree_Insert] 
	@New_LocationTitle as nvarchar(50)
	,@New_ParentLocationID as bigint
	,@New_LocationLevelID as bigint
	,@New_Description as nvarchar(500)

	,@LocationID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [LocationTree] 
		(
		[LocationTitle]
		,[ParentLocationID]
		,[LocationLevelID]
		,[Description]
		)
	VALUES
		(
		@New_LocationTitle
		, @New_ParentLocationID
		, @New_LocationLevelID
		, @New_Description
		)

	SET @LocationID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[LocationTree_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocationTree_Update] 
	@Original_LocationID as bigint
	,@New_LocationTitle as nvarchar(50)
	,@New_ParentLocationID as bigint
	,@New_LocationLevelID as bigint
	,@New_Description as nvarchar(500)

AS
BEGIN
	UPDATE [LocationTree] 
	SET
		[LocationTitle]=@New_LocationTitle
		,[ParentLocationID]=@New_ParentLocationID
		,[LocationLevelID]=@New_LocationLevelID
		,[Description]=@New_Description
	WHERE 
		[LocationID]=@Original_LocationID

	RETURN @@RowCount
END

-- MediaContentType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MediaContentType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MediaContentType_Insert] 
	@New_DisplayText as nvarchar(100)
	,@New_HTMLContentTypeText as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IconPath as nvarchar(500)
	,@New_IsSystem as bit

	,@MediaContentTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [MediaContentType] 
		(
		[DisplayText]
		,[HTMLContentTypeText]
		,[Description]
		,[IconPath]
		,[IsSystem]
		)
	VALUES
		(
		@New_DisplayText
		, @New_HTMLContentTypeText
		, @New_Description
		, @New_IconPath
		, @New_IsSystem
		)

	SET @MediaContentTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MediaContentType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MediaContentType_Update] 
	@Original_MediaContentTypeID as bigint
	,@New_DisplayText as nvarchar(100)
	,@New_HTMLContentTypeText as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IconPath as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [MediaContentType] 
	SET
		[DisplayText]=@New_DisplayText
		,[HTMLContentTypeText]=@New_HTMLContentTypeText
		,[Description]=@New_Description
		,[IconPath]=@New_IconPath
		,[IsSystem]=@New_IsSystem
	WHERE 
		[MediaContentTypeID]=@Original_MediaContentTypeID

	RETURN @@RowCount
END

-- Option --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Notify_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Notify_Insert] 
	 @New_NotificationType as bigint
	,@New_SenderProfileId as bigint
	,@New_ReceiverProfileId as bigint
	,@New_StatusID as bigint
	,@New_Message as varchar(max)
	,@New_SubjectRowID as bigint	

	,@SpProfileID as bigint
	,@New_NotificationId as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Notify]
		(
		 [NotificationType]
		,[SenderProfileId]
		,[ReceiverProfileId]
		,[StatusId]
		,[Message]
		,[SubjectRowID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_NotificationType
		, @New_SenderProfileId
		, @New_ReceiverProfileId
		, @New_StatusID
		, @New_Message
		, @New_SubjectRowID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @New_NotificationId = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Notify_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Notify_Update] 
	 @Original_NotificationID as bigint
	,@New_NotificationType as bigint	
	,@New_SenderProfileId as bigint
	,@New_ReceiverProfileId as bigint
	,@New_StatusID as bigint
	,@New_Message as varchar(max)
	,@New_SubjectRowID as bigint	

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Notify] 
	SET	
		 [NotificationType]=@New_NotificationType	 
		,[SenderProfileId]=@New_SenderProfileId
		,[ReceiverProfileId]=@New_ReceiverProfileId
		,[StatusID]=@New_StatusID
		,[Message]=@New_Message
		,[SubjectRowID]=@New_SubjectRowID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()

	WHERE 
		[NotificationId] =@Original_NotificationID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Chat --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Option_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Option_Insert] 
	@New_OptionTitle as varchar(50)
	,@New_MenuTitle as varchar(50)
	,@New_ItemTitle as varchar(50)
	,@New_PageURL as varchar(100)
	,@New_NextPageURL as varchar(50)
	,@New_ModuleID as int
	,@New_OptionTypeID as int
	,@New_ParentOptionID as bigint
	,@New_DisplayOrder as int
	,@New_ExecActionID as bigint
	,@New_StatusID as int

	,@SpProfileID as bigint
	,@OptionID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Option] 
		(
		[OptionTitle]
		,[MenuTitle]
		,[ItemTitle]
		,[PageURL]
		,[NextPageURL]
		,[ModuleID]
		,[OptionTypeID]
		,[ParentOptionID]
		,[DisplayOrder]
		,[ExecActionID]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_OptionTitle
		, @New_MenuTitle
		, @New_ItemTitle
		, @New_PageURL
		, @New_NextPageURL
		, @New_ModuleID
		, @New_OptionTypeID
		, @New_ParentOptionID
		, @New_DisplayOrder
		, @New_ExecActionID
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @OptionID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Option_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Option_Update] 
	@Original_OptionID as bigint
	,@New_OptionTitle as varchar(50)
	,@New_MenuTitle as varchar(50)
	,@New_ItemTitle as varchar(50)
	,@New_PageURL as varchar(100)
	,@New_NextPageURL as varchar(50)
	,@New_ModuleID as int
	,@New_OptionTypeID as int
	,@New_ParentOptionID as bigint
	,@New_DisplayOrder as int
	,@New_ExecActionID as bigint
	,@New_StatusID as int

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Option] 
	SET
		[OptionTitle]=@New_OptionTitle
		,[MenuTitle]=@New_MenuTitle
		,[ItemTitle]=@New_ItemTitle
		,[PageURL]=@New_PageURL
		,[NextPageURL]=@New_NextPageURL
		,[ModuleID]=@New_ModuleID
		,[OptionTypeID]=@New_OptionTypeID
		,[ParentOptionID]=@New_ParentOptionID
		,[DisplayOrder] = @New_DisplayOrder
		,[ExecActionID]=@New_ExecActionID
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[OptionID]=@Original_OptionID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- OptionType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OptionType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OptionType_Insert] 
	@New_OptionTypeTitle as varchar(50)
	,@New_Description as varchar(500)
	,@New_OptionLevel as int

	,@OptionTypeID as int OUTPUT
AS
BEGIN
	INSERT INTO [OptionType] 
		(
		[OptionTypeTitle]
		,[Description]
		,[OptionLevel]
		)
	VALUES
		(
		@New_OptionTypeTitle
		, @New_Description
		, @New_OptionLevel
		)

	SET @OptionTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OptionType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OptionType_Update] 
	@Original_OptionTypeID as int
	,@New_OptionTypeTitle as varchar(50)
	,@New_Description as varchar(500)
	,@New_OptionLevel as int

AS
BEGIN
	UPDATE [OptionType] 
	SET
		[OptionTypeTitle]=@New_OptionTypeTitle
		,[Description]=@New_Description
		,[OptionLevel]=@New_OptionLevel
	WHERE 
		[OptionTypeID]=@Original_OptionTypeID

	RETURN @@RowCount
END

-- OrderDeliveryDetail --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Order_AutoUpdateStatus]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_AutoUpdateStatus] 
AS
BEGIN
DECLARE @rowCounter INT;

	UPDATE [CartOrder] 
	SET
		 [OrderStatusID]=10,
		 LastModifiedDateTime = GETDATE()
	WHERE 
		 OrderNumber is not null
		  and OrderStatusID=8
		  and LastModifiedDateTime < GETDATE()-2

SET @rowCounter =  @@RowCount

	UPDATE [CartOrder] 
	SET
		 [OrderStatusID]=13,
		 LastModifiedDateTime = GETDATE()
	WHERE 
		OrderNumber is not null
		  and (OrderStatusID=11 or OrderStatusID=12 )
		  and StatusID <> 4
		  and LastModifiedDateTime < GETDATE()-90

SET @rowCounter = @rowCounter + @@ROWCOUNT;


	UPDATE [CartOrder] 
	SET
		 [StatusID]=4,
		 LastModifiedDateTime = GETDATE()
	WHERE 
		OrderNumber is not null
		  and (OrderStatusID=1 or OrderStatusID=3)
		  and StatusID <> 4
		  and LastModifiedDateTime < GETDATE()-90

SET @rowCounter = @rowCounter + @@ROWCOUNT;

RETURN @rowCounter

END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Order_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Insert] 
	 @New_BuyerProfileID as bigint
	,@New_ParentCartID as bigint
	,@New_OrderStatusID as bigint
	,@New_StatusID as bigint
	,@New_DeliveryAddressID as bigint
	,@New_DeliveryAddress as varchar(max)
	,@New_OrderSupplierId as bigint
	,@New_SupplierDeliveryOptionPairID  as bigint

	,@New_OrderTotal as float
	,@New_TaxTotal as float
	,@New_DeliveryTotal as float
	,@New_DiscountTotal as float
	,@New_PaymentTotal as float

	,@SpProfileID as bigint
	,@OrderID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [CartOrder] 
		(
		 [BuyerProfileID]
		,[ParentCartID]
		,[OrderStatusID]
		,[StatusID]

		,[DeliveryAddressID]
		,[DeliveryAddress] 
		,[OrderSupplierId]
		,[SupplierDeliveryOptionPairID] 

		,[OrderTotal]
		,[TaxTotal]
		,[DeliveryTotal] 
		,[DiscountTotal]
		,[PaymentTotal] 

		,[CalculatedPayout] -- 0
		,[ActualPayout] -- 0
		,[CalculatedPayIn] -- 0
		,[ActualPayIn] -- 0


		,[CreatedDateTime]
		,[CreatedByUserID]
		,[LastModifiedDateTime]
		,[LastModifiedByUserID]
		)
	VALUES
		(
		  @New_BuyerProfileID
		, @New_ParentCartID
		, @New_OrderStatusID
		, @New_StatusID
		, @New_DeliveryAddressID 
		, @New_DeliveryAddress
		, @New_OrderSupplierId 
		, @New_SupplierDeliveryOptionPairID
		, @New_OrderTotal
		, @New_TaxTotal
		, @New_DeliveryTotal
		, @New_DiscountTotal
		, @New_PaymentTotal 

		, 0						--[CalculatedPayout]
		, 0						--[ActualPayout]
		, 0						--[CalculatedPayIn] 
		, 0						--[ActualPayIn] 

		, GETDATE()
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		)

	SET @OrderID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Order_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Update] 
	 @Original_OrderID as bigint
	,@New_BuyerProfileID as bigint
	,@New_ParentCartID as bigint
	,@New_OrderStatusID as bigint
	,@New_StatusID as bigint

	,@New_OrderTotal as float
	,@New_TaxTotal as float
	,@New_DeliveryTotal as float
	,@New_DiscountTotal as float
	,@New_PaymentTotal as float

	,@New_DeliveryAddressID as bigint
	,@New_DeliveryAddress as varchar(500)
	,@New_OrderSupplierId as bigint
	,@New_SupplierDeliveryOptionPairID as bigint

	,@New_CalculatedPayout as float
	,@New_ActualPayout as float
	,@New_CalculatedPayIn as float
	,@New_ActualPayIn as float

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [CartOrder] 
	SET
		 [OrderStatusID]=@New_OrderStatusID
		,[StatusID]=@New_StatusID

		,[BuyerProfileID]=@New_BuyerProfileID
		,[ParentCartID]=@New_ParentCartID

		,[OrderTotal]=@New_OrderTotal
		,[TaxTotal]=@New_TaxTotal
		,[DeliveryTotal]=@New_DeliveryTotal
		,[DiscountTotal]=@New_DiscountTotal
		,[PaymentTotal]=@New_PaymentTotal

		,[DeliveryAddressID]=@New_DeliveryAddressID 
		,[DeliveryAddress]=@New_DeliveryAddress 
		,[OrderSupplierId]=@New_OrderSupplierId 
		,[SupplierDeliveryOptionPairID]=@New_SupplierDeliveryOptionPairID 

		,[CalculatedPayout]=@New_CalculatedPayout
		,[ActualPayout]=@New_ActualPayout
		,[CalculatedPayIn]=@New_CalculatedPayIn
		,[ActualPayIn]=@New_ActualPayIn

		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[CartOrderID]=@Original_OrderID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Category --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Order_Update_Status]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Order_Update_Status] 
	 @Original_OrderID as bigint
	,@New_OrderStatusID as bigint
	,@SpProfileID as bigint
AS
BEGIN
	UPDATE [CartOrder] 
	SET
		 [OrderStatusID]=@New_OrderStatusID
		,[LastModifiedDateTime]=GETDATE()
		,[LastModifiedByUserID]=@SpProfileID
	WHERE 
		[CartOrderID]=@Original_OrderID

	RETURN @@RowCount
END

-- Category --
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[OrderDeliveryDetail_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDeliveryDetail_Insert] 
	@New_CartOrderID as bigint
	,@New_DeliveryAddressID as bigint

	,@OrderDeliveryDetailID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [OrderDeliveryDetail] 
		(
		[CartOrderID]
		,[DeliveryAddressID]
		)
	VALUES
		(
		@New_CartOrderID
		, @New_DeliveryAddressID
		)

	SET @OrderDeliveryDetailID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderDeliveryDetail_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDeliveryDetail_Update] 
	@Original_OrderDeliveryDetailID as bigint
	,@New_CartOrderID as bigint
	,@New_DeliveryAddressID as bigint

AS
BEGIN
	UPDATE [OrderDeliveryDetail] 
	SET
		[CartOrderID]=@New_CartOrderID
		,[DeliveryAddressID]=@New_DeliveryAddressID
	WHERE 
		[OrderDeliveryDetailID]=@Original_OrderDeliveryDetailID

	RETURN @@RowCount
END

-- OrderPayment --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderPayment_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderPayment_Insert] 
	@New_CartOrderID as bigint
	,@New_PaymentID as bigint
	,@New_Amount as float
	,@New_BillingAddressID as bigint

	,@OrderPaymentID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [OrderPayment] 
		(
		[CartOrderID]
		,[PaymentID]
		,[Amount]
		,[BillingAddressID]
		)
	VALUES
		(
		@New_CartOrderID
		, @New_PaymentID
		, @New_Amount
		, @New_BillingAddressID
		)

	SET @OrderPaymentID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderPayment_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderPayment_Update] 
	@Original_OrderPaymentID as bigint
	,@New_CartOrderID as bigint
	,@New_PaymentID as bigint
	,@New_Amount as float
	,@New_BillingAddressID as bigint

AS
BEGIN
	UPDATE [OrderPayment] 
	SET
		[CartOrderID]=@New_CartOrderID
		,[PaymentID]=@New_PaymentID
		,[Amount]=@New_Amount
		,[BillingAddressID]=@New_BillingAddressID
	WHERE 
		[OrderPaymentID]=@Original_OrderPaymentID

	RETURN @@RowCount
END

-- OrderStatus --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderStatus_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderStatus_Insert] 
	@New_OrderStatusTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit
	,@New_IsOrder as bit

	,@OrderStatusID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [OrderStatus] 
		(
		[OrderStatusTitle]
		,[Description]
		,[IsSystem]
		,[IsOrder]
		)
	VALUES
		(
		@New_OrderStatusTitle
		, @New_Description
		, @New_IsSystem
		, @New_IsOrder
		)

	SET @OrderStatusID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderStatus_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderStatus_Update] 
	@Original_OrderStatusID as bigint
	,@New_OrderStatusTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit
	,@New_IsOrder as bit

AS
BEGIN
	UPDATE [OrderStatus] 
	SET
		[OrderStatusTitle]=@New_OrderStatusTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
		,[IsOrder]=@New_IsOrder
	WHERE 
		[OrderStatusID]=@Original_OrderStatusID

	RETURN @@RowCount
END

-- OrderStatusMap --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderStatusMap_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderStatusMap_Insert] 
	@New_ParentOrderStatusID as bigint
	,@New_ChildOrderStatusID as bigint
	,@New_StatusID as bigint
	,@New_Description as nvarchar(1000)
	,@New_IsDefault as bit
	,@OrderStatusMapID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [OrderStatusMap] 
		(
		[ParentOrderStatusID]
		,[ChildOrderStatusID]
		,[StatusID]
		,[Description]
		,[IsDefault]
		)
	VALUES
		(
		@New_ParentOrderStatusID
		, @New_ChildOrderStatusID
		, @New_StatusID
		, @New_Description
		, @New_IsDefault
		)

	SET @OrderStatusMapID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[OrderStatusMap_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderStatusMap_Update] 
	@Original_OrderStatusMapID as bigint
	,@New_ParentOrderStatusID as bigint
	,@New_ChildOrderStatusID as bigint
	,@New_StatusID as bigint
	,@New_Description as nvarchar(1000)
	,@New_IsDefault as bit
AS
BEGIN
	UPDATE [OrderStatusMap] 
	SET
		[ParentOrderStatusID]=@New_ParentOrderStatusID
		,[ChildOrderStatusID]=@New_ChildOrderStatusID
		,[StatusID]=@New_StatusID
		,[Description]=@New_Description
		,[IsDefault]=@New_IsDefault
	WHERE 
		[OrderStatusMapID]=@Original_OrderStatusMapID

	RETURN @@RowCount
END

-- PackagedProduct --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PackagedProduct_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PackagedProduct_Insert] 
	@New_ProductID as bigint
	,@New_ChildProductID as bigint
	,@New_Quantity as bigint
	,@New_IncludedByDefault as bit
	,@New_PercentagePrice as float
	,@New_OtherDetails as varchar(1000)

	,@PackageID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [PackagedProduct] 
		(
		[ProductID]
		,[ChildProductID]
		,[Quantity]
		,[IncludedByDefault]
		,[PercentagePrice]
		,[OtherDetails]
		)
	VALUES
		(
		@New_ProductID
		, @New_ChildProductID
		, @New_Quantity
		, @New_IncludedByDefault
		, @New_PercentagePrice
		, @New_OtherDetails
		)

	SET @PackageID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PackagedProduct_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PackagedProduct_Update] 
	@Original_PackageID as bigint
	,@New_ProductID as bigint
	,@New_ChildProductID as bigint
	,@New_Quantity as bigint
	,@New_IncludedByDefault as bit
	,@New_PercentagePrice as float
	,@New_OtherDetails as varchar(1000)

AS
BEGIN
	UPDATE [PackagedProduct] 
	SET
		[ProductID]=@New_ProductID
		,[ChildProductID]=@New_ChildProductID
		,[Quantity]=@New_Quantity
		,[IncludedByDefault]=@New_IncludedByDefault
		,[PercentagePrice]=@New_PercentagePrice
		,[OtherDetails]=@New_OtherDetails
	WHERE 
		[PackageID]=@Original_PackageID

	RETURN @@RowCount
END

-- Payment --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Payment_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_Insert] 
	 @New_OrderID as bigint
	,@New_PayTypeID as bigint
	,@New_Amount as float
	,@New_PaymentGatewayTransactionID as nvarchar(100)
	,@New_PaymentToken as nvarchar(100)
	,@New_IsAmountVerified as bit

	,@SpProfileID as bigint
	,@PaymentID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Payment] 
		(
		 [OrderID]
		,[PayTypeID]
		,[Amount]
		,[PaymentGatewayTransactionID]
		,[PaymentToken]
		,[IsAmountVerified]
		,[CreatedByUserID]
		,[CreatedDateTime]
		,[LastModifiedByUserID]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_OrderID
		, @New_PayTypeID
		, @New_Amount
		, @New_PaymentGatewayTransactionID
		, @New_PaymentToken
		, @New_IsAmountVerified
		, @SpProfileID 
		, GETDATE()
		, @SpProfileID 
		, GETDATE()
		)

	SET @PaymentID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Payment_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_Update] 
	 @Original_PaymentID as bigint
	,@New_OrderID as bigint
	,@New_PayTypeID as bigint
	,@New_Amount as float
	,@New_PaymentGatewayTransactionID as nvarchar(100)
	,@New_PaymentToken as nvarchar(100)
	,@New_IsAmountVerified as bit

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime


AS
BEGIN
	UPDATE [Payment] 
	SET
		 [OrderID] = @New_OrderID
		,[PayTypeID] = @New_PayTypeID
		,[Amount]=@New_Amount
		,[PaymentGatewayTransactionID]=@New_PaymentGatewayTransactionID
		,[PaymentToken]=@New_PaymentToken
		,[IsAmountVerified] = @New_IsAmountVerified
		
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=@LastModifiedDateTime
	WHERE 
		[PaymentID]=@Original_PaymentID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- PayMode --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayMode_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayMode_Insert] 
	@New_PayModeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@PayModeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [PayMode] 
		(
		[PayModeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_PayModeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @PayModeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayMode_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayMode_Update] 
	@Original_PayModeID as bigint
	,@New_PayModeTitle as nvarchar(100)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [PayMode] 
	SET
		[PayModeTitle]=@New_PayModeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[PayModeID]=@Original_PayModeID

	RETURN @@RowCount
END

-- PayOptionMatrix --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayOptionMatrix_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayOptionMatrix_Insert] 
	@New_PayModeID as bigint
	,@New_PayTypeID as bigint
	,@New_IsSystem as bit

	,@PayOptionMatrixID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [PayOptionMatrix] 
		(
		[PayModeID]
		,[PayTypeID]
		,[IsSystem]
		)
	VALUES
		(
		@New_PayModeID
		, @New_PayTypeID
		, @New_IsSystem
		)

	SET @PayOptionMatrixID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayOptionMatrix_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayOptionMatrix_Update] 
	@Original_PayOptionMatrixID as bigint
	,@New_PayModeID as bigint
	,@New_PayTypeID as bigint
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [PayOptionMatrix] 
	SET
		[PayModeID]=@New_PayModeID
		,[PayTypeID]=@New_PayTypeID
		,[IsSystem]=@New_IsSystem
	WHERE 
		[PayOptionMatrixID]=@Original_PayOptionMatrixID

	RETURN @@RowCount
END

-- PayType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayType_Insert] 
	@New_PayTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@PayTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [PayType] 
		(
		[PayTypeTitle]
		,[Description]
		,[StatusID]
		,[IsSystem]
		)
	VALUES
		(
		@New_PayTypeTitle
		, @New_Description
		, @New_StatusID
		, @New_IsSystem
		)

	SET @PayTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[PayType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayType_Update] 
	@Original_PayTypeID as bigint
	,@New_PayTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [PayType] 
	SET
		[PayTypeTitle]=@New_PayTypeTitle
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[IsSystem]=@New_IsSystem
	WHERE 
		[PayTypeID]=@Original_PayTypeID

	RETURN @@RowCount
END

-- Product --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Insert] 
	@New_ProductTitle as nvarchar(200)
	,@New_BrifeDescription as nvarchar(1000)
	,@New_ProductActualImagePath as nvarchar(4000)
	,@New_ProductImagePath as nvarchar(4000)
	,@New_StockCount as bigint
	,@New_WebLink as nvarchar(4000)
	,@New_BasePrice as float
	,@New_SellingPrice as float

	,@New_DiscountValue as float
	,@New_IsDiscountPercentage as bit

	,@New_OrderResponseTime as bigint
	,@New_OrderResponseTimeUintID as varchar(50)
	,@New_TaxTypeID as bigint
	,@New_UserRating as int
	,@New_AnalysisRank as int
	,@New_Description as nvarchar(4000)
	,@New_ProductTypeID as bigint
	,@New_BrandID as bigint
	,@New_SupplierID as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@ProductID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Product] 
		(
		[ProductTitle]
		,[BrifeDescription]
		,[ProductActualImagePath]
		,[ProductImagePath]
		,[StockCount]
		,[WebLink]
		,[BasePrice]
		,[SellingPrice]
		,[DiscountValue]
		,[IsDiscountPercentage]
		,[OrderResponseTime]
		,[OrderResponseTimeUnitID]
		,[TaxTypeID]
		,[UserRating]
		,[AnalysisRank]
		,[Description]
		,[ProductTypeID]
		,[BrandID]
		,[SupplierID]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		@New_ProductTitle
		, @New_BrifeDescription
		, @New_ProductActualImagePath
		, @New_ProductImagePath
		, @New_StockCount
		, @New_WebLink
		, @New_BasePrice
		, @New_SellingPrice
		
		,@New_DiscountValue
		,@New_IsDiscountPercentage

		, @New_OrderResponseTime
		, @New_OrderResponseTimeUintID
		, @New_TaxTypeID
		, @New_UserRating
		, @New_AnalysisRank
		, @New_Description
		, @New_ProductTypeID
		, @New_BrandID
		, @New_SupplierID
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @ProductID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_InsertBasicInfo]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_InsertBasicInfo] 
	@New_ProductTitle as nvarchar(200)
	,@New_BrifeDescription as nvarchar(1000)
	,@New_Description as nvarchar(4000)
	,@New_ProductTypeID as bigint
	,@New_BrandID as bigint
	,@New_SupplierID as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@ProductID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Product] 
		(
		 [ProductTitle]
		,[BrifeDescription]
		,[Description]
		,[ProductTypeID]
		,[BrandID]
		,[SupplierID]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_ProductTitle
		, @New_BrifeDescription
		, @New_Description
		, @New_ProductTypeID
		, @New_BrandID
		, @New_SupplierID
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @ProductID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Update] 
	@Original_ProductID as bigint
	,@New_ProductTitle as nvarchar(200)
	,@New_BrifeDescription as nvarchar(1000)
	,@New_ProductActualImagePath as nvarchar(4000)
	,@New_ProductImagePath as nvarchar(4000)
	,@New_StockCount as bigint
	,@New_WebLink as nvarchar(4000)
	,@New_BasePrice as float
	,@New_SellingPrice as float
	,@New_DiscountValue as float
	,@New_IsDiscountPercentage as bit
	,@New_OrderResponseTime as bigint
	,@New_OrderResponseTimeUnitID as varchar(50)
	--,@New_DeliveryChargesByZvonr as float
	--,@New_DeliveryChargesByShop as nchar(10)
	,@New_TaxTypeID as bigint
	,@New_UserRating as int
	,@New_AnalysisRank as int
	,@New_Description as nvarchar(4000)
	,@New_ProductTypeID as bigint
	,@New_BrandID as bigint
	,@New_SupplierID as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Product] 
	SET
		[ProductTitle]=@New_ProductTitle
		,[BrifeDescription]=@New_BrifeDescription
		,[ProductActualImagePath]=@New_ProductActualImagePath
		,[ProductImagePath]=@New_ProductImagePath
		,[StockCount]=@New_StockCount
		,[WebLink]=@New_WebLink
		,[BasePrice]=@New_BasePrice
		,[SellingPrice]=@New_SellingPrice
		,[DiscountValue]=@New_DiscountValue 
		,[IsDiscountPercentage]=@New_IsDiscountPercentage 
		,[OrderResponseTime]=@New_OrderResponseTime
		,[OrderResponseTimeUnitID]=@New_OrderResponseTimeUnitID
		,[TaxTypeID]=@New_TaxTypeID
		,[UserRating]=@New_UserRating
		,[AnalysisRank]=@New_AnalysisRank
		,[Description]=@New_Description
		,[ProductTypeID]=@New_ProductTypeID
		,[BrandID]=@New_BrandID
		,[SupplierID]=@New_SupplierID
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[ProductID]=@Original_ProductID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_UpdateBasicInfo]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_UpdateBasicInfo] 
	@Original_ProductID as bigint
	,@New_ProductTitle as nvarchar(200)
	,@New_BrifeDescription as nvarchar(1000)
	,@New_Description as nvarchar(4000)
	,@New_ProductTypeID as bigint
	,@New_BrandID as bigint
	,@New_SupplierID as bigint
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Product] 
	SET 
		 [ProductTitle]=@New_ProductTitle
		,[BrifeDescription]=@New_BrifeDescription
		,[Description]=@New_Description
		,[ProductTypeID]=@New_ProductTypeID
		,[BrandID]=@New_BrandID
		,[SupplierID]=@New_SupplierID
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[ProductID]=@Original_ProductID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_UpdateForAnalysisRank]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_UpdateForAnalysisRank] 
	 
AS
BEGIN
	
DECLARE @ProductID bigint;
DECLARE @Rating BIGINT = 0;
 
DECLARE CUR_RATING CURSOR FAST_FORWARD FOR
    select i.ProductID as ProductID, 
	convert(bigint, 
	ROUND(
	(convert(decimal, sum(i.Quantity)) 
	/ 
	(ISNULL(
		(select sum(ii.Quantity) 
		  from [CartOrder] as oo, 
		  [CartItem] as ii
		  where 
		  oo.CartOrderID = ii.CartOrderID
		  and oo.ParentCartID is not null
		  and oo.OrderStatusID = 10),0)) /* Completed orders */
	 ) 
	 * 100,0)
	 ) as Rating  
   from 
   [CartOrder] as o, 
   [CartItem] as i
  where 
  o.CartOrderID = i.CartOrderID  
  and o.ParentCartID is not null
  and o.OrderStatusID = 10 /* Completed orders */
  group by i.ProductID;
 
OPEN CUR_RATING
FETCH NEXT FROM CUR_RATING INTO @ProductID, @Rating
 
WHILE @@FETCH_STATUS = 0
BEGIN
   UPDATE [Product] 
   SET AnalysisRank = @Rating
   WHERE ProductID = @ProductID;   

   FETCH NEXT FROM CUR_RATING INTO @ProductID, @Rating
END
CLOSE CUR_RATING
DEALLOCATE CUR_RATING

return @@rowcount	

END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_UpdateImages]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_UpdateImages] 
	@Original_ProductID as bigint
	,@New_ProductActualImagePath as nvarchar(4000)
	,@New_ProductImagePath as nvarchar(4000)

	,@SpProfileID as bigint
	--,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Product] 
	SET
		 [ProductActualImagePath]=@New_ProductActualImagePath
		,[ProductImagePath]=@New_ProductImagePath
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[ProductID]=@Original_ProductID
		--AND
		--[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Product_UpdatePricing]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_UpdatePricing] 
	 @Original_ProductID as bigint
	,@New_BasePrice as float
	,@New_SellingPrice as float
	,@New_DiscountValue as float
	,@New_IsDiscountPercentage as bit
	,@New_OrderResponseTime as bigint
	,@New_OrderResponseTimeUnitID as varchar(50)
	,@New_TaxTypeID as bigint
	,@SpProfileID as bigint
AS
BEGIN
	UPDATE [Product] 
	SET
		 [BasePrice]=@New_BasePrice
		,[SellingPrice]=@New_SellingPrice
		,[DiscountValue]=@New_DiscountValue 
		,[IsDiscountPercentage]=@New_IsDiscountPercentage 
		,[OrderResponseTime]=@New_OrderResponseTime
		,[OrderResponseTimeUnitID]=@New_OrderResponseTimeUnitID
		,[TaxTypeID]=@New_TaxTypeID
		--,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[ProductID]=@Original_ProductID


	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductAttributePair_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductAttributePair_Insert] 
	@New_ProductID as bigint
	,@New_AttributeID as bigint
	,@New_AttributeValue as nvarchar(4000)
	,@New_DisplayOrder as int
	,@New_IsAssigned as bit
	,@New_IsSelectedForVariation as bit
	,@New_VariationInPrice as float

	,@ProductAttributePairID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductAttributePair] 
		(
		[ProductID]
		,[AttributeID]
		,[AttributeValue]
		,[DisplayOrder]
		,[IsAssigned]
		,[IsSelectedForVariation]
		,[VariationInPrice]
		)
	VALUES
		(
		@New_ProductID
		, @New_AttributeID
		, @New_AttributeValue
		, @New_DisplayOrder
		, @New_IsAssigned
		, @New_IsSelectedForVariation
		,@New_VariationInPrice
		)

	SET @ProductAttributePairID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductAttributePair_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductAttributePair_Update] 
	@Original_ProductAttributePairID as bigint
	,@New_ProductID as bigint
	,@New_AttributeID as bigint
	,@New_AttributeValue as nvarchar(4000)
	,@New_DisplayOrder as int
	,@New_IsAssigned as bit
	,@New_IsSelectedForVariation as bit
	,@New_VariationInPrice as float

AS
BEGIN
	UPDATE [ProductAttributePair] 
	SET
		[ProductID]=@New_ProductID
		,[AttributeID]=@New_AttributeID
		,[AttributeValue]=@New_AttributeValue
		,[DisplayOrder]=@New_DisplayOrder
		,[IsAssigned]=@New_IsAssigned
		,[IsSelectedForVariation]=@New_IsSelectedForVariation
		,[VariationInPrice]=@New_VariationInPrice
	WHERE 
		[ProductAttributePairID]=@Original_ProductAttributePairID

	RETURN @@RowCount
END

-- ProductCategoryPair --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductAttributePair_UpdateIsAssigned]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductAttributePair_UpdateIsAssigned] 
	 @New_ProductID as bigint
	,@New_AttributeID as bigint
	,@New_AttributeValue as nvarchar(4000)
	,@New_IsAssigned as bit
	,@New_IsSelectedForVariation as bit
	,@New_VariationInPrice as float

AS
BEGIN
	UPDATE [ProductAttributePair] 
	SET
		 [IsAssigned]=@New_IsAssigned
		,[IsSelectedForVariation]=@New_IsSelectedForVariation
		,[VariationInPrice]=@New_VariationInPrice
	WHERE 
		[ProductID]=@New_ProductID AND
		[AttributeID]=@New_AttributeID AND
		[AttributeValue]=CONVERT(nvarchar,@New_AttributeValue)

	RETURN @@RowCount
END
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryPair_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductCategoryPair_Insert] 
	@New_ProductID as bigint
	,@New_CategoryID as bigint

	,@ProductCategoryPairID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductCategoryPair] 
		(
		[ProductID]
		,[CategoryID]
		)
	VALUES
		(
		@New_ProductID
		, @New_CategoryID
		)

	SET @ProductCategoryPairID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductCategoryPair_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductCategoryPair_Update] 
	@Original_ProductCategoryPairID as bigint
	,@New_ProductID as bigint
	,@New_CategoryID as bigint

AS
BEGIN
	UPDATE [ProductCategoryPair] 
	SET
		[ProductID]=@New_ProductID
		,[CategoryID]=@New_CategoryID
	WHERE 
		[ProductCategoryPairID]=@Original_ProductCategoryPairID

	RETURN @@RowCount
END

-- ProductMediaDetail --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductMediaDetail_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductMediaDetail_Insert] 
	@New_ProductMediaTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_MediaContentTypeID as bigint
	,@New_MediaFilePath as nvarchar(4000)
	,@New_ProductID as bigint
	,@New_Width as int
	,@New_Height as int
	,@New_TransparencyLevel as int
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@ProductMediaID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductMediaDetail] 
		(
		[ProductMediaTitle]
		,[Description]
		,[MediaContentTypeID]
		,[MediaFilePath]
		,[ProductID]
		,[Width]
		,[Height]
		,[TransparencyLevel]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[ApprovedByUserID]
		,[ApprovedDateTime]
		)
	VALUES
		(
		@New_ProductMediaTitle
		, @New_Description
		, @New_MediaContentTypeID
		, @New_MediaFilePath
		, @New_ProductID
		, @New_Width
		, @New_Height
		, @New_TransparencyLevel
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		, NULL
		, NULL
		)

	SET @ProductMediaID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductMediaDetail_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductMediaDetail_Update] 
	@Original_ProductMediaID as bigint
	,@New_ProductMediaTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_MediaContentTypeID as bigint
	,@New_MediaFilePath as nvarchar(4000)
	,@New_ProductID as bigint
	,@New_Width as int
	,@New_Height as int
	,@New_TransparencyLevel as int
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [ProductMediaDetail] 
	SET
		[ProductMediaTitle]=@New_ProductMediaTitle
		,[Description]=@New_Description
		,[MediaContentTypeID]=@New_MediaContentTypeID
		,[MediaFilePath]=@New_MediaFilePath
		,[ProductID]=@New_ProductID
		,[Width]=@New_Width
		,[Height]=@New_Height
		,[TransparencyLevel]=@New_TransparencyLevel
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[ProductMediaID]=@Original_ProductMediaID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- ProductType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductType_Insert] 
	@New_ProductTypeTitle as nvarchar(100)
	,@New_ProductTypeDescription as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@ProductTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductType] 
		(
		[ProductTypeTitle]
		,[ProductTypeDescription]
		,[StatusID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[IsSystem]
		)
	VALUES
		(
		@New_ProductTypeTitle
		, @New_ProductTypeDescription
		, @New_StatusID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		, @New_IsSystem
		)

	SET @ProductTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductType_Update] 
	@Original_ProductTypeID as bigint
	,@New_ProductTypeTitle as nvarchar(100)
	,@New_ProductTypeDescription as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [ProductType] 
	SET
		[ProductTypeTitle]=@New_ProductTypeTitle
		,[ProductTypeDescription]=@New_ProductTypeDescription
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
		,[IsSystem]=@New_IsSystem
	WHERE 
		[ProductTypeID]=@Original_ProductTypeID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- ProductView --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductView_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductView_Insert] 
	@New_ProductViewTitle as varchar(100)
	,@New_Description as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@ProductViewID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductView] 
		(
		[ProductViewTitle]
		,[Description]
		,[StatusID]
		,[IsSystem]
		)
	VALUES
		(
		@New_ProductViewTitle
		, @New_Description
		, @New_StatusID
		, @New_IsSystem
		)

	SET @ProductViewID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductView_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductView_Update] 
	@Original_ProductViewID as bigint
	,@New_ProductViewTitle as varchar(100)
	,@New_Description as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [ProductView] 
	SET
		[ProductViewTitle]=@New_ProductViewTitle
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[IsSystem]=@New_IsSystem
	WHERE 
		[ProductViewID]=@Original_ProductViewID

	RETURN @@RowCount
END

-- ProductViewItem --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductViewItem_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductViewItem_Insert] 
	@New_ProductViewID as bigint
	,@New_ProductID as bigint
	,@New_ProductMediaID as bigint

	,@ProductViewProductID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProductViewItem] 
		(
		[ProductViewID]
		,[ProductID]
		,[ProductMediaID]
		)
	VALUES
		(
		@New_ProductViewID
		, @New_ProductID
		, @New_ProductMediaID
		)

	SET @ProductViewProductID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProductViewItem_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductViewItem_Update] 
	@Original_ProductViewProductID as bigint
	,@New_ProductViewID as bigint
	,@New_ProductID as bigint
	,@New_ProductMediaID as bigint

AS
BEGIN
	UPDATE [ProductViewItem] 
	SET
		[ProductViewID]=@New_ProductViewID
		,[ProductID]=@New_ProductID
		,[ProductMediaID]=@New_ProductMediaID
	WHERE 
		[ProductViewProductID]=@Original_ProductViewProductID

	RETURN @@RowCount
END

-- Profile --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Profile_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Profile_Insert] 
	@New_UserID as bigint
	,@New_FirstName as nvarchar(100)
	,@New_MiddleName as nvarchar(100)
	,@New_LastName as nvarchar(100)
	,@New_FatherName as nvarchar(100)
	,@New_Nationality as nvarchar(100)
	,@New_Occupation as nvarchar(100)
	,@New_Education as nvarchar(100)
	,@New_ImagePath as nvarchar(4000)
	,@New_IsVerified as bit
	,@New_UserTypeID as bigint
	,@New_SMS_2FA as bit
	,@New_EMail_2FA as bit

	,@ProfileID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Profile] 
		(
		[UserID]
		,[FirstName]
		,[MiddleName]
		,[LastName]
		,[FatherName]
		,[Nationality]
		,[Occupation]
		,[Education]
		,[ImagePath]
		,[IsVerified]
		,[UserTypeID]
		,[SMS_2FA]
		,[EMail_2FA]
		,[CreatedOn]
		)
	VALUES
		(
		@New_UserID
		, @New_FirstName
		, @New_MiddleName
		, @New_LastName
		, @New_FatherName
		, @New_Nationality
		, @New_Occupation
		, @New_Education
		, @New_ImagePath
		, @New_IsVerified
		, @New_UserTypeID
		, @New_SMS_2FA
		, @New_EMail_2FA
		, GETDATE()
		)

	SET @ProfileID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON

/****** Object:  StoredProcedure [dbo].[Profile_Update]    Script Date: 1/30/2021 8:10:30 PM ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Profile_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Profile_Update] 
	@Original_ProfileID as bigint
	,@New_UserID as bigint
	,@New_FirstName as nvarchar(100)
	,@New_MiddleName as nvarchar(100)
	,@New_LastName as nvarchar(100)
	,@New_FatherName as nvarchar(100)
	,@New_Nationality as nvarchar(100)
	,@New_Occupation as nvarchar(100)
	,@New_Education as nvarchar(100)
	,@New_ImagePath as nvarchar(4000)
	,@New_IsVerified as bit
	,@New_UserTypeID as bigint
	,@New_SMS_2FA as bit
	,@New_EMail_2FA as bit

AS
BEGIN
	UPDATE [Profile] 
	SET
		[UserID]=@New_UserID
		,[FirstName]=@New_FirstName
		,[MiddleName]=@New_MiddleName
		,[LastName]=@New_LastName
		,[FatherName]=@New_FatherName
		,[Nationality]=@New_Nationality
		,[Occupation]=@New_Occupation
		,[Education]=@New_Education
		,[ImagePath]=@New_ImagePath
		,[IsVerified]=@New_IsVerified
		,[UserTypeID]=@New_UserTypeID
		,[SMS_2FA]=@New_SMS_2FA
		,[EMail_2FA]=@New_EMail_2FA
	WHERE 
		[ProfileID]=@Original_ProfileID

	RETURN @@RowCount
END

-- ProfileVerification --
SET ANSI_NULLS ON


/****** Object:  StoredProcedure [dbo].[Profile_Insert]    Script Date: 1/30/2021 8:07:56 PM ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Profile_Update_2FA]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Profile_Update_2FA] 
	@Original_ProfileID as bigint	
	,@New_SMS_2FA as bit
	,@New_EMail_2FA as bit

AS
BEGIN
	UPDATE [Profile] 
	SET
		[SMS_2FA]=@New_SMS_2FA
		,[EMail_2FA]=@New_EMail_2FA
	WHERE 
		[ProfileID]=@Original_ProfileID

	RETURN @@RowCount
END

-- ProfileVerification --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProfileVerification_ChangeVerificationStatus]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfileVerification_ChangeVerificationStatus] 
	@Original_VerificationID as bigint
	,@New_VerifiedBy as bigint
	,@New_Comments as nvarchar(1000)
	,@New_VerificationStatusID as bigint
	,@New_DocumentNumberByVerifier as nvarchar(100)
AS
BEGIN
	UPDATE [ProfileVerification] 
	SET
		 [VerifiedBy]=@New_VerifiedBy
		,[VerifiedOn]=GETDATE()
		,[Comments]=@New_Comments
		,[VerificationStatusID]=@New_VerificationStatusID
		,[DocumentNumberByVerifier]=@New_DocumentNumberByVerifier
	WHERE 
		[VerificationID]=@Original_VerificationID

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProfileVerification_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfileVerification_Insert] 
	@New_DocumentTypeID as bigint
	,@New_VerifiedBy as bigint
	,@New_VerifiedOn as datetime
	,@New_Comments as nvarchar(1000)
	,@New_VerificationStatusID as bigint
	,@New_ProfileID as bigint
	,@New_DocumentNumberByUser as nvarchar(100)
	,@New_DocumentNumberByVerifier as nvarchar(100)
	,@New_DocumentImagePath as nvarchar(4000)

	,@VerificationID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [ProfileVerification] 
		(
		[DocumentTypeID]
		,[VerifiedBy]
		,[VerifiedOn]
		,[Comments]
		,[VerificationStatusID]
		,[ProfileID]
		,[DocumentNumberByUser]
		,[DocumentNumberByVerifier]
		,[DocumentImagePath]
		)
	VALUES
		(
		@New_DocumentTypeID
		, @New_VerifiedBy
		, @New_VerifiedOn
		, @New_Comments
		, @New_VerificationStatusID
		, @New_ProfileID
		, @New_DocumentNumberByUser
		, @New_DocumentNumberByVerifier
		, @New_DocumentImagePath
		)

	SET @VerificationID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProfileVerification_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfileVerification_Update] 
	@Original_VerificationID as bigint
	,@New_DocumentTypeID as bigint
	,@New_VerifiedBy as bigint
	,@New_VerifiedOn as datetime
	,@New_Comments as nvarchar(1000)
	,@New_VerificationStatusID as bigint
	,@New_ProfileID as bigint
	,@New_DocumentNumberByUser as nvarchar(100)
	,@New_DocumentNumberByVerifier as nvarchar(100)
	,@New_DocumentImagePath as nvarchar(4000)

AS
BEGIN
	UPDATE [ProfileVerification] 
	SET
		[DocumentTypeID]=@New_DocumentTypeID
		,[VerifiedBy]=@New_VerifiedBy
		,[VerifiedOn]=@New_VerifiedOn
		,[Comments]=@New_Comments
		,[VerificationStatusID]=@New_VerificationStatusID
		,[ProfileID]=@New_ProfileID
		,[DocumentNumberByUser]=@New_DocumentNumberByUser
		,[DocumentNumberByVerifier]=@New_DocumentNumberByVerifier
		,[DocumentImagePath]=@New_DocumentImagePath
	WHERE 
		[VerificationID]=@Original_VerificationID

	RETURN @@RowCount
END

-- Role --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[ProfileVerification_UpdateByUser]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfileVerification_UpdateByUser] 
	@Original_VerificationID as bigint
	,@New_DocumentTypeID as bigint
	,@New_DocumentNumberByUser as nvarchar(100)
	,@New_DocumentImagePath as nvarchar(4000)

AS
BEGIN
	UPDATE [ProfileVerification] 
	SET
		[DocumentTypeID]=@New_DocumentTypeID
		,[DocumentNumberByUser]=@New_DocumentNumberByUser
		,[DocumentImagePath]=@New_DocumentImagePath
	WHERE 
		[VerificationID]=@Original_VerificationID

	RETURN @@RowCount
END

-- Role --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Role_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Insert] 
	@New_RoleTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IconPath as nvarchar(4000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

	,@RoleID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Role] 
		(
		[RoleTitle]
		,[Description]
		,[IconPath]
		,[StatusID]
		,[IsSystem]
		)
	VALUES
		(
		@New_RoleTitle
		, @New_Description
		, @New_IconPath
		, @New_StatusID
		, @New_IsSystem
		)

	SET @RoleID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Role_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Update] 
	@Original_RoleID as bigint
	,@New_RoleTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IconPath as nvarchar(4000)
	,@New_StatusID as bigint
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [Role] 
	SET
		[RoleTitle]=@New_RoleTitle
		,[Description]=@New_Description
		,[IconPath]=@New_IconPath
		,[StatusID]=@New_StatusID
		,[IsSystem]=@New_IsSystem
	WHERE 
		[RoleID]=@Original_RoleID

	RETURN @@RowCount
END

-- RoleOptionPair --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[RoleOptionPair_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleOptionPair_Insert] 
	@New_OptionID as bigint
	,@New_RoleID as bigint
	,@New_IsAssigned as bit
	,@New_IsSystem as bit
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@RoleOptionPairID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [RoleOptionPair] 
		(
		[OptionID]
		,[RoleID]
		,[IsAssigned]
		,[IsSystem]
		,[StatusID]
		,[CreatedByUserID]
		,[CreatedDateTime]
		,[LastModifiedByUserID]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		@New_OptionID
		, @New_RoleID
		, @New_IsAssigned
		, @New_IsSystem
		, @New_StatusID
		, @SpProfileID
		, GETDATE()
		, @SpProfileID
		, GETDATE()
		)

	SET @RoleOptionPairID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[RoleOptionPair_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleOptionPair_Update] 
	@Original_RoleOptionPairID as bigint
	,@New_OptionID as bigint
	,@New_RoleID as bigint
	,@New_IsAssigned as bit
	,@New_IsSystem as bit
	,@New_StatusID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [RoleOptionPair] 
	SET
		[OptionID]=@New_OptionID
		,[RoleID]=@New_RoleID
		,[IsAssigned]=@New_IsAssigned
		,[IsSystem]=@New_IsSystem
		,[StatusID]=@New_StatusID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[RoleOptionPairID]=@Original_RoleOptionPairID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- StateMachine --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Schedule_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Schedule_Insert] 
	 @New_SupplierID as bigint 
	,@New_ScheduleTypeID as bigint 
	,@New_IsException as bit
	,@New_FromDay  as smallint
	,@New_ToDay as smallint
	,@New_Month  as varchar(50)
	,@New_MonthDay as varchar(50)
	,@New_WeekDays as varchar(100)
	,@New_StatusID as bigint 
	,@New_Notes as varchar(1000)

	,@SpProfileID as bigint
	,@ScheduleID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Schedule] 
		(
		 [SupplierID]
		,[ScheduleTypeID]
		,[IsException]
		,[FromDay]
		,[ToDay]
		,[Month]
		,[MonthDay]
		,[WeekDays]
		,[StatusID]
		,[Notes]
		,[CreatedByUserID]
		,[CreatedDateTime]
		,[LastModifiedByUserID]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		 @New_SupplierID
		,@New_ScheduleTypeID
		,@New_IsException
		,@New_FromDay
		,@New_ToDay
		,@New_Month
		,@New_MonthDay
		,@New_WeekDays
		,@New_StatusID
		,@New_Notes
		,@SpProfileID
		,GETDATE()
		, @SpProfileID
		,GETDATE()
)
	SET @ScheduleID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Schedule_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Schedule_Update] 
	 @Original_ScheduleID as bigint
	,@New_SupplierID as bigint 
	,@New_ScheduleTypeID as bigint 
	,@New_IsException as bit
	,@New_FromDay  as smallint
	,@New_ToDay as smallint
	,@New_Month  as varchar(50)
	,@New_MonthDay as varchar(50)
	,@New_WeekDays as varchar(100)
	,@New_StatusID as bigint 
	,@New_Notes as varchar(1000)

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Schedule] 
	SET  
		 [SupplierID]			  = @New_SupplierID
		,[ScheduleTypeID]		  = @New_ScheduleTypeID
		,[IsException]			  = @New_IsException
		,[FromDay]				  = @New_FromDay
		,[ToDay]				  = @New_ToDay
		,[Month]				  = @New_Month
		,[MonthDay]				  = @New_MonthDay
		,[WeekDays]				  = @New_WeekDays
		,[StatusID]				  = @New_StatusID
		,[Notes]				  = @New_Notes
		,[LastModifiedByUserID]	  = @SpProfileID
		,[LastModifiedDateTime]	  = GETDATE()

		
	WHERE 
		[ScheduleID] = @Original_ScheduleID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SearchTerm_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchTerm_Insert] 
	@New_Keyword as nvarchar(4000)
	,@New_StoreId as bigint
	,@New_Count as int

	,@Id as bigint OUTPUT
AS
BEGIN
	INSERT INTO [SearchTerm] 
		(
		[Keyword]
		,[StoreId]
		,[Count]
		)
	VALUES
		(
		@New_Keyword
		, @New_StoreId
		, @New_Count
		)

	SET @Id = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SearchTerm_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchTerm_Update] 
	@Original_Id as bigint
	,@New_Keyword as nvarchar(4000)
	,@New_StoreId as bigint
	,@New_Count as int

AS
BEGIN
	UPDATE [SearchTerm] 
	SET
		[Keyword]=@New_Keyword
		,[StoreId]=@New_StoreId
		,[Count]=@New_Count
	WHERE 
		[Id]=@Original_Id

	RETURN @@RowCount
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CartItem_UpdateByCartItemID]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CartItem_UpdateByCartItemID] 
	@Original_CartItemID as int
AS
BEGIN
	UPDATE [CartItems] 
	SET
		[IsRemoved]= 0
	WHERE 
		[CartItemID]=@Original_CartItemID
		
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_CartOrder_UpdateByOrderStatusID]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CartOrder_UpdateByOrderStatusID] 
	@New_OrderStatusID as int,
	@Original_CartOrderID as int
AS
BEGIN
	UPDATE [CartOrder] 
	SET
		[OrderStatusID]=@New_OrderStatusID
	WHERE 
		[CartOrderID]=@Original_CartOrderID

	RETURN @@RowCount
END


SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Catalogue_AllInheritedAttributesByCategory]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_Catalogue_AllInheritedAttributesByCategory] 
	@CategoryID as int
AS
BEGIN
; with  categoryTree as
        (
        select  root.CategoryID, root.CategoryParentID, root.CategoryTitle
        from    category as root
        where   root.CategoryID = @CategoryID --in (9,19) --(Select parentid from @t where id = 8)
        union all
  
        select  child.CategoryID, child.CategoryParentID, child.CategoryTitle
        from    categoryTree as parent
        join    category as child
        on       parent.CategoryParentID= child.CategoryID
        )
        Select 
			ca.AttributeID,
			a.AttributeTitle,
			ca.AttributeValue
		from CategoryAttributePair ca
		join Attribute a on ca.AttributeID = a.AttributeID
		where 
			ca.CategoryID in (select  categoryTree.CategoryID from categoryTree)
			and
			a.AttributeTypeID = 1
			and
			ca.IsAssigned = 1


	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Catalogue_AllNonExistingParentsByChildCategory]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Catalogue_AllNonExistingParentsByChildCategory] 
	@CategoryID as int
	,@ProductID as int
AS
BEGIN
; with  categoryTree as
        (
        select  root.CategoryID, root.CategoryParentID, root.CategoryTitle
        from    category as root
        where   root.CategoryID = @CategoryID --in (9,19) --(Select parentid from @t where id = 8)
        union all
  
        select  child.CategoryID, child.CategoryParentID, child.CategoryTitle
        from    categoryTree as parent
        join    category as child
        on       parent.CategoryParentID= child.CategoryID
        )
		Insert INTO [dbo].[ProductCategoryPair]
		(
			ProductID,
			CategoryID
		)
		OUTPUT inserted.ProductID, inserted.CategoryID
		select @ProductID,CategoryID from Category where CategoryID in
		(
			select  categoryTree.CategoryID
			from    categoryTree
			except
			select CategoryID from ProductCategoryPair where ProductID = @ProductID
		)
		Insert Into [dbo].[ProductAttributePair]
		(
			ProductID,
			AttributeID,
			AttributeValue
		)
		OUTPUT inserted.ProductID, inserted.AttributeID, inserted.AttributeValue
		--Select @ProductID, AttributeID, AttributeValue from CategoryAttributePair 
		Select @ProductID, AttributeID, AttributeValue from	CategoryAttributePair 
		where CategoryID in (Select Categoryid from ProductCategoryPair where ProductID =@ProductID)
		except
		Select @ProductID, AttributeID, AttributeValue from ProductAttributePair where ProductID = @ProductID
		

	RETURN @@RowCount
END
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Catalogue_AllNonExistingParentsByChildCategory_Attributes]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Catalogue_AllNonExistingParentsByChildCategory_Attributes] 
	 @CategoryID as int
	,@ProductID as int
AS 
BEGIN
	BEGIN TRANSACTION ;
	SAVE TRANSACTION MySavePoint;
	BEGIN TRY
/*Make sure to cleanup categories and attributes for prodcut*/
		Delete FROM [dbo].[ProductCategoryPair] WHERE ProductId = @ProductID
		Delete FROM [dbo].[ProductAttributePair] WHERE ProductId = @ProductID
		Insert INTO [dbo].[ProductCategoryPair] (ProductID,CategoryID,[IsDefault]) values (@ProductID,@CategoryID,1)

		Declare @inserted Table (ProductID int, CategoryID int, AttributeID int, AttributeValue nvarchar(max));
/*Finding all parent categories*/
		; with  categoryTree as
				(
				select  root.CategoryID, root.CategoryParentID, root.CategoryTitle
				from    category as root
				where   root.CategoryID = @CategoryID 
				union all
				select  child.CategoryID, child.CategoryParentID, child.CategoryTitle
				from    categoryTree as parent
				join    category as child
				on       parent.CategoryParentID= child.CategoryID
				)
/*Step 1*/			
			Insert INTO [dbo].[ProductCategoryPair]
			(
				ProductID,
				CategoryID
			)
			OUTPUT inserted.ProductID, inserted.CategoryID
			INTO @inserted (ProductID, CategoryID )
			select @ProductID,CategoryID from Category where CategoryID in
			(
				select  categoryTree.CategoryID
				from    categoryTree
				except
				select CategoryID from ProductCategoryPair where ProductID = @ProductID
			)
/*Step 2*/			
			Insert Into [dbo].[ProductAttributePair]
			(
				ProductID,
				AttributeID,
				AttributeValue,
				IsAssigned
			)
			OUTPUT inserted.ProductID, inserted.AttributeID, inserted.AttributeValue
			--Select @ProductID, AttributeID, AttributeValue from CategoryAttributePair 
			INTO @inserted (ProductID, AttributeID, AttributeValue)
			Select @ProductID, AttributeID, AttributeValue, 0 from CategoryAttributePair 
			where CategoryID in (Select Categoryid from ProductCategoryPair where ProductID =@ProductID)
			except
			Select @ProductID, AttributeID, AttributeValue, 0 from ProductAttributePair where ProductID = @ProductID
		
			Insert into @inserted (ProductID, CategoryID) values (@ProductID, @CategoryID)
	
			Select ProductID, CategoryID, AttributeID, AttributeValue  from @inserted

		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION MySavePoint; -- rollback to MySavePoint
		END
	END CATCH
	RETURN @@RowCount
END
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[sp_Catalogue_AllParentsByChildCategory]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Catalogue_AllParentsByChildCategory] 
	@CategoryID as int
AS
BEGIN
; with  categoryTree as
        (
        select  root.CategoryID, root.CategoryParentID, root.CategoryTitle
        from    category as root
        where   root.CategoryID = @CategoryID --in (9,19) --(Select parentid from @t where id = 8)
        union all
  
        select  child.CategoryID, child.CategoryParentID, child.CategoryTitle
        from    categoryTree as parent
        join    category as child
        on       parent.CategoryParentID= child.CategoryID
        )
        
select  categoryTree.CategoryID, categoryTree.CategoryParentID, categoryTree.CategoryTitle
from    categoryTree


	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_ConvertCartToOrders]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_ConvertCartToOrders]
		 @Existing_CartId as bigint
		,@New_DeliveryAddressID as bigint
		--,@New_DeliveryAddress as varchar(max)
		,@New_SupplierDeliveryOptionPairID as bigint
		,@SpProfileId as bigint
AS
BEGIN

--Declare @Existing_CartId as bigint
--Declare @New_DeliveryAddressID as bigint
--Declare @New_SupplierDeliveryOptionPairID as bigint
--Declare @SpProfileId as bigint


--SET @Existing_CartId = 8
--SET @New_DeliveryAddressID = 34
--SET @New_SupplierDeliveryOptionPairID = 5
--SET @SpProfileId = 1


Declare @inserted_Orders Table (OrderId BIGint, ShopId BIGint);
Declare @New_DeliveryAddress as varchar(max)

Select @New_DeliveryAddress = A.PlotNumber + '' + A.StreetNumber + ' ' + A.PostalCode + ' ' + A.NearestLandmark from [dbo].[Address] a where a.AddressID = @New_DeliveryAddressID

Insert into CartOrder 
	(
		--CartOrderID (PK)
		 --OrderNumber
		 ParentCartID

		,BuyerProfileID
		,OrderStatusID
		,StatusID

		,DeliveryAddressID
		,DeliveryAddress

		,OrderSupplierId
		,SupplierDeliveryOptionPairID

		,OrderTotal
		,TaxTotal
		,DeliveryTotal
		,DiscountTotal
		,PaymentTotal


		,CalculatedPayout
		,ActualPayout
		,CalculatedPayIn
		,ActualPayIn


		,CreatedDateTime
		,CreatedByUserID
		,LastModifiedDateTime
		,LastModifiedByUserID
	)

OUTPUT inserted.CartOrderID, inserted.OrderSupplierId
INTO @inserted_Orders (OrderID, ShopId)

Select 
	 c.CartOrderID as ParentCartId
	,c.BuyerProfileID
	,3   -- c.OrderStatusID -- not-Paid
	,1   -- c.StatusID -- New (Not Paid)

	,@New_DeliveryAddressID
	,@New_DeliveryAddress

	,shop.SupplierID-- c.OrderSupplierId
	,c.SupplierDeliveryOptionPairID --@New_SupplierDeliveryOptionPairID

	,0 as OrderTotal
	,0 as TaxTotal
	,0 AS DeliveryTotal
	,0 as DiscountTotal
	,0 AS PaymentTotal


	,0 AS CalculatedPayout
	,0 AS ActualPayout
	,0 AS CalculatedPayIn
	,0 AS ActualPayIn

	,GetDate() AS CreatedDateTime
	,@SpProfileId
	,GetDate() as LastModifiedDataTime
	,@SpProfileId
from 
	cartorder c,
	(Select DISTINCT(P.SupplierID) 
	from cartitem i
	join product p on i.ProductID = p.ProductID
	where CartOrderID = @Existing_CartId) as shop

where 
	CartOrderID = @Existing_CartId

Declare @D as datetime
set @D = GETDATE()
Update [CartOrder] 
	set OrderNumber = 
		CONVERT(varchar, Year(GETDATE())) + '/' + 
		Convert( varchar, DATEPART(MILLISECOND,@D))+ 
		CONVERT(varchar, CartOrderID) +
		Convert( varchar, DATEPART(SECOND, @D))
	where ParentCartID = @Existing_CartId

Insert into CartItem
		(--CartItemID (PK)
				 CartOrderID
				,ProductID
				,UnitPrice
				,Quantity
				,TaxRateApplied
				,TaxAmount
				,DiscountAmount
				,ItemTotalPrice
				,StatusID
				,CreatedDateTime
				,CreatedByUserID
				,LastModifiedDateTime
				,LastModifiedByUserID
		)
Select 
				 --CartItemID (PK)
				 INS_Orders.OrderID
				,i.ProductID
				,i.UnitPrice
				,i.Quantity
				,i.TaxRateApplied
				,i.TaxAmount
				,i.DiscountAmount
				,i.ItemTotalPrice
				,1--StatusID
				,GETDATE()
				,@SpProfileId	--CreatedByUserID   
				,GETDATE()
				,@SpProfileId	--LastModifiedByUserID    
	--p.SupplierID
from 
	CartItem i
	join product p on i.ProductID = p.ProductID
	join @inserted_Orders INS_Orders ON INS_Orders.ShopId = p.SupplierID
where
	i.CartOrderID = @Existing_CartId
	and 
	i.StatusID = 2

	Declare @SumTable  Table (CartOrderId bigint, ItemTotalPrice  DEC(11,2), TaxAmount DEC(11,2), DeliveryTotal DEC(11,2), DiscountAmount DEC(11,2), PaymentTotal DEC(11,2) ); 
	Insert into @SumTable
	Select 
		INS_Orders.OrderId
		--,Sum(i.UnitPrice) as SumOfUnitPrice
		--,Sum(i.Quantity) as TotalQuantity
		--,AVG(i.TaxRateApplied)
		,Sum(i.ItemTotalPrice) --as OrderTotal
		,Sum(i.TaxAmount) --as TaxTotal
		,0 --AS DeliveryTotal
		,Sum(i.DiscountAmount) --as DiscountTotal
		,Sum(i.ItemTotalPrice) --as PaymentTotal
	from CartItem  i
		join @inserted_Orders INS_Orders ON INS_Orders.OrderId = i.CartOrderID
		Group By INS_Orders.OrderId

	Update CartOrder
	Set
		OrderTotal		= ItemTotalPrice,
		TaxTotal		= TaxAmount,
		DeliveryTotal	= st.DeliveryTotal,
		DiscountTotal	= DiscountAmount,
		PaymentTotal	= st.PaymentTotal
	From 
		@SumTable st
	WHERE 
		CartOrder.CartOrderID = st.CartOrderId


	Update CartOrder
	Set
		OrderStatusID = 2
	WHERE 
		CartOrder.CartOrderID = @Existing_CartId

	--GROUP BY I.CartOrderID

	Select * from @inserted_Orders
	RETURN @@RowCount


end;
GO
/****** Object:  StoredProcedure [dbo].[sp_LocationTree_GetByID]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LocationTree_GetByID]
	@OperatingCityID as bigint ,
	@OperatingProvinceID as bigint output,
	@OperatingCountryID as bigint output,
	@OperatingCityTitle as nvarchar(100) output,
	@OperatingProvinceTitle as nvarchar(100) output,
	@OperatingCountryTitle as nvarchar(100) output
AS
BEGIN
select 
	  @OperatingCityID=city.LocationID
	, @OperatingCityTitle=city.LocationTitle
	, @OperatingProvinceID=province.LocationID
	, @OperatingProvinceTitle=province.LocationTitle
	, @OperatingCountryID=country.LocationID
	, @OperatingCountryTitle=country.LocationTitle 
	
	from LocationTree city
	inner join LocationTree province
	on city.ParentLocationID = province.LocationID
	inner join LocationTree country
	on province.ParentLocationID = country.LocationID
	where city.LocationID = @OperatingCityID;
END






GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTableStatus]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateTableStatus] 
	 @TableName as varchar(50)
    ,@StatusID as int   
AS
BEGIN
	DECLARE @query as varchar(max)
	
	SET @query = '
	UPDATE ' + @TableName + '
	SET 
	[StatusID] = @StatusID'

	EXEC @query
	
	RETURN @@RowCount	
END
GO
/****** Object:  StoredProcedure [dbo].[StateMachine_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StateMachine_Insert] 
	@New_StartStateID as bigint
	,@New_StateMachineTitle as nvarchar(100)
	,@New_StateMachineDescription as nvarchar(1000)

	,@StateMachineID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [StateMachine] 
		(
		[StartStateID]
		,[StateMachineTitle]
		,[StateMachineDescription]
		)
	VALUES
		(
		@New_StartStateID
		, @New_StateMachineTitle
		, @New_StateMachineDescription
		)

	SET @StateMachineID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[StateMachine_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StateMachine_Update] 
	@Original_StateMachineID as bigint
	,@New_StartStateID as bigint
	,@New_StateMachineTitle as nvarchar(100)
	,@New_StateMachineDescription as nvarchar(1000)

AS
BEGIN
	UPDATE [StateMachine] 
	SET
		[StartStateID]=@New_StartStateID
		,[StateMachineTitle]=@New_StateMachineTitle
		,[StateMachineDescription]=@New_StateMachineDescription
	WHERE 
		[StateMachineID]=@Original_StateMachineID

	RETURN @@RowCount
END

-- StateMachineState --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[StateMachineState_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StateMachineState_Insert] 
	@New_StateID as bigint
	,@New_NextStateID as bigint
	,@New_NextInputString as nvarchar(100)

	,@StateMachineStateID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [StateMachineState] 
		(
		[StateID]
		,[NextStateID]
		,[NextInputString]
		)
	VALUES
		(
		@New_StateID
		, @New_NextStateID
		, @New_NextInputString
		)

	SET @StateMachineStateID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[StateMachineState_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StateMachineState_Update] 
	@Original_StateMachineStateID as bigint
	,@New_StateID as bigint
	,@New_NextStateID as bigint
	,@New_NextInputString as nvarchar(100)

AS
BEGIN
	UPDATE [StateMachineState] 
	SET
		[StateID]=@New_StateID
		,[NextStateID]=@New_NextStateID
		,[NextInputString]=@New_NextInputString
	WHERE 
		[StateMachineStateID]=@Original_StateMachineStateID

	RETURN @@RowCount
END

-- Status --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Status_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Insert] 
	@New_StatusName as varchar(100)
	,@New_Description as varchar(1000)
	,@New_IsSystem as bit

	,@StatusID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Status] 
		(
		[StatusName]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_StatusName
		, @New_Description
		, @New_IsSystem
		)

	SET @StatusID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Status_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Update] 
	@Original_StatusID as bigint
	,@New_StatusName as varchar(100)
	,@New_Description as varchar(1000)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [Status] 
	SET
		[StatusName]=@New_StatusName
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[StatusID]=@Original_StatusID

	RETURN @@RowCount
END

-- Supplier --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier_Insert] 
	@New_SupplierName as nvarchar(100)
	,@New_Logo as nvarchar(max) = NULL
	,@New_Description as nvarchar(1000) = NULL
	,@New_StatusID as bigint
	,@New_StatusNotes as nvarchar(max) = NULL

	,@New_BusinessAddressID as bigint
	,@New_IsBusinessAddressVisible as bit

	,@New_LanguageID as bigint = NULL
	,@New_CurrencyID as bigint = NULL
	
	,@New_CountryID as bigint = NULL
	,@New_ProvinceID as bigint = NULL
	,@New_CityID as bigint = NULL

	,@New_IsCOD as bit
	,@New_ProfileID as bigint
	,@New_ProcessingFee as float
	,@New_PaymentGatewayFee as float
	,@New_IsProcessingFeePercentage as bit
	,@New_IsPaymentGatewayFeePercentage as bit

	,@SpProfileID as bigint
	,@SupplierID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Supplier] 
		(
		[SupplierName]
		,[Logo]
		,[Description]
		,[StatusID]
		,[StatusNotes]
		,[BusinessAddressID]
		,[IsBusinessAddressVisible]
		,[LanguageID]
		,[CurrencyID]
		,[CountryID]
		,[ProvinceID]
		,[CityID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[IsCOD]
		,[ProfileID]
		,[ProcessingFee]
		,[PaymentGatewayFee]
		,[IsProcessingFeePercentage]
		,[IsPaymentGatewayFeePercentage]
		)
	VALUES
		(
		@New_SupplierName
		,@New_Logo
		,@New_Description
		,@New_StatusID
		,@New_StatusNotes
		,@New_BusinessAddressID 
		,@New_IsBusinessAddressVisible 
		,@New_LanguageID
		,@New_CurrencyID
		,@New_CountryID
		,@New_ProvinceID
		,@New_CityID
		,@SpProfileID
		,@SpProfileID
		,GETDATE()
		,GETDATE()
		,@New_IsCOD
		,@New_ProfileID
		,@New_ProcessingFee
		,@New_PaymentGatewayFee
		,@New_IsProcessingFeePercentage
		,@New_PaymentGatewayFee
		)

	SET @SupplierID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier_Update] 
	@Original_SupplierID as bigint
	,@New_SupplierName as nvarchar(100)
	,@New_Logo as nvarchar(max) = NULL
	,@New_Description as nvarchar(1000) = NULL
	,@New_StatusID as bigint
	,@New_StatusNotes as nvarchar(max) = NULL
	,@New_BusinessAddressID as bigint
	,@New_IsBusinessAddressVisible as bit
	,@New_LanguageID as bigint = NULL
	,@New_CurrencyID as bigint = NULL
	,@New_CountryID as bigint = NULL
	,@New_ProvinceID as bigint = NULL
	,@New_CityID as bigint = NULL
	,@New_IsCOD as bit
	,@New_ProfileID as bigint
	,@New_ProcessingFee as float
	,@New_PaymentGatewayFee as float
	,@New_IsProcessingFeePercentage as bit
	,@New_IsPaymentGatewayFeePercentage as bit

	,@New_AnnouncementHTML as nvarchar(max) = NULL
    ,@New_PolicyHTML as nvarchar(max) = NULL
    ,@New_FAQHTML as nvarchar(max) = NULL
    ,@New_WebLinksJSON as nvarchar(max) = NULL
    ,@New_AttributeRequests as nvarchar(max) = NULL
    ,@New_CategoryRequests as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		[SupplierName]=@New_SupplierName
		,[Logo]=@New_Logo
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[StatusNotes]=@New_StatusNotes

		,[BusinessAddressID]=@New_BusinessAddressID
		,[IsBusinessAddressVisible]=@New_IsBusinessAddressVisible

		,[LanguageID]=@New_LanguageID
		,[CurrencyID]=@New_CurrencyID
		
		,[CountryID]=@New_CountryID 
		,[ProvinceID]=@New_ProvinceID 
		,[CityID]=@New_CityID 

		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
		,[IsCOD]=@New_IsCOD
		,[ProfileID]=@New_ProfileID
		,[ProcessingFee]=@New_ProcessingFee
		,[PaymentGatewayFee]=@New_PaymentGatewayFee
		,[IsProcessingFeePercentage]=@New_IsProcessingFeePercentage
		,[IsPaymentGatewayFeePercentage]=@New_IsPaymentGatewayFeePercentage

		,[AnnouncementHTML] = @New_AnnouncementHTML
        ,[PolicyHTML] = @New_PolicyHTML
        ,[FAQHTML] = @New_FAQHTML
        ,[WebLinksJSON] = @New_WebLinksJSON
        ,[AttributeRequests] = @New_AttributeRequests
        ,[CategoryRequests] = @New_CategoryRequests

	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Tax --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_AddressVisibility]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_AddressVisibility] 
	@Original_SupplierID as bigint
	,@New_IsBusinessAddressVisible as bit
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [IsBusinessAddressVisible]=@New_IsBusinessAddressVisible
	WHERE 
		[SupplierID]=@Original_SupplierID

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_AnnouncementHTML]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_AnnouncementHTML] 
	@Original_SupplierID as bigint
	,@New_AnnouncementHTML as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [AnnouncementHTML]=@New_AnnouncementHTML
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_AttributeRequests]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_AttributeRequests] 
	@Original_SupplierID as bigint
	,@New_AttributeRequests as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [AttributeRequests]=@New_AttributeRequests
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_CategoryRequests]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_CategoryRequests] 
	@Original_SupplierID as bigint
	,@New_CategoryRequests as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [CategoryRequests]=@New_CategoryRequests
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_Details]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Supplier_Update_Details] 
	 @Original_SupplierID as bigint
	,@New_AnnouncementHTML as nvarchar(max)= NULL

	,@New_FAQHTML as nvarchar(max)= NULL
	,@New_PolicyHTML as nvarchar(max)= NULL
	,@New_WebLinksJSON as nvarchar(max)= NULL
	,@New_Logo as nvarchar(max) = NULL
	,@New_StatusID as bigint
	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [AnnouncementHTML]=@New_AnnouncementHTML
		,[FAQHTML]=@New_FAQHTML
		,[PolicyHTML]=@New_PolicyHTML
		,[WebLinksJSON]=@New_WebLinksJSON
		,[Logo] = @New_Logo
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
		,[StatusID] = @New_StatusID
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- Tax --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_FAQHTML]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_FAQHTML] 
	@Original_SupplierID as bigint
	,@New_FAQHTML as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [FAQHTML]=@New_FAQHTML
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_PolicyHTML]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_PolicyHTML] 
	@Original_SupplierID as bigint
	,@New_PolicyHTML as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [PolicyHTML]=@New_PolicyHTML
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_TaxInfo]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_TaxInfo] 
	@Original_SupplierID as bigint
	,@New_TaxConcent as bit
	,@New_TaxRegistration as nvarchar(100)

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [TaxConcent]=@New_TaxConcent
		,[TaxRegistration]=@New_TaxRegistration
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Supplier_Update_WebLinksJSON]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Supplier_Update_WebLinksJSON] 
	@Original_SupplierID as bigint
	,@New_WebLinksJSON as nvarchar(max) = NULL

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [Supplier] 
	SET
		 [WebLinksJSON]=@New_WebLinksJSON
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[SupplierID]=@Original_SupplierID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SupplierDeliveryOptionPair_DeleteBySupplierId]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SupplierDeliveryOptionPair_DeleteBySupplierId] 
	@New_SupplierID as bigint
AS
BEGIN
	Delete [SupplierDeliveryOptionPair]
	WHERE
		[SupplierID] = @New_SupplierID

	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SupplierDeliveryOptionPair_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[SupplierDeliveryOptionPair_Insert] 
	-- Add the parameters for the stored procedure here
	@New_SupplierID as bigint
	,@New_DeliveryOptionID as bigint
	,@New_DeliveryCharges as float
	,@New_MinOrderLimit as float
	,@New_SurroundingCitiesIDs as varchar(max)

	,@SupplierDeliveryOptionPairID as bigint OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO [SupplierDeliveryOptionPair]
	(
		[SupplierID]
		,[DeliveryOptionID]
		,[DeliveryCharges]
		,[MinOrderLimit]
		,[SurroundingCitiesIDs]
	)
	VALUES
	(
		@New_SupplierID
		,@New_DeliveryOptionID
		,@New_DeliveryCharges
		,@New_MinOrderLimit,
		@New_SurroundingCitiesIDs
	)

	SET @SupplierDeliveryOptionPairID = SCOPE_IDENTITY();
	RETURN @@ROWCOUNT
	
END
GO
/****** Object:  StoredProcedure [dbo].[SupplierDeliveryOptionPair_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SupplierDeliveryOptionPair_Update] 
	-- Add the parameters for the stored procedure here
	@Original_SupplierDeliveryOptionPairID as bigint
	,@New_SupplierID as bigint
	,@New_DeliveryOptionID as bigint
	,@New_DeliveryCharges as float
	,@New_MinOrderLimit as float
	,@New_SurroundingCitiesIDs as varchar(max)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	UPDATE [SupplierDeliveryOptionPair]
	SET
		[SupplierID]=@New_SupplierID
		,[DeliveryOptionID]=@New_DeliveryOptionID
		,[DeliveryCharges]=@New_DeliveryCharges
		,[MinOrderLimit]=@New_MinOrderLimit
		,[SurroundingCitiesIDs]=@New_SurroundingCitiesIDs
	WHERE
		[SupplierDeliveryOptionPairID]=@Original_SupplierDeliveryOptionPairID
    -- Insert statements for procedure here
END
GO
/****** Object:  StoredProcedure [dbo].[Tax_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Tax_Insert] 
	@New_TaxValue as float
	,@New_TaxTypeID as bigint
	,@New_Description as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsPercentage as bit
	,@New_LocationId as bigint
	,@New_LocationLevelId as bigint
	,@New_EffectiveDate as datetime

	,@SpProfileID as bigint
	,@TaxID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [Tax] 
		(
		 [TaxValue]
		,[TaxTypeID]
		,[Description]
		,[StatusID]
		,[IsPercentage]
		,[LocationID]
		,[LocationLevelId]
		,[EffectiveDate]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		)
	VALUES
		(
		  @New_TaxValue
		, @New_TaxTypeID
		, @New_Description
		, @New_StatusID
		, @New_IsPercentage
		, @New_LocationID
		, @New_LocationLevelId
		, @New_EffectiveDate
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		)

	SET @TaxID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Tax_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Tax_Update] 
	@Original_TaxID as bigint
	,@New_TaxValue as float
	,@New_TaxTypeID as bigint
	,@New_Description as nvarchar(1000)
	,@New_StatusID as bigint
	,@New_IsPercentage as bit
	,@New_LocationId as bigint
	,@New_LocationLevelId as bigint
	,@New_EffectiveDate as datetime
	,@New_LastModifiedDateTime as datetime
	,@SpProfileId as bigint
AS
BEGIN
	UPDATE [Tax] 
	SET
		[TaxValue]=@New_TaxValue
		,[TaxTypeID]=@New_TaxTypeID
		,[Description]=@New_Description
		,[StatusID]=@New_StatusID
		,[IsPercentage]=@New_IsPercentage
		,[LocationId]=@New_LocationId
		,[LocationLevelId]=@New_LocationLevelId
		,[EffectiveDate]=@New_EffectiveDate
		,[LastModifiedByUserID]=@SpProfileId
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[TaxID]=@Original_TaxID
		AND
		[LastModifiedDateTime] = @New_LastModifiedDateTime
	RETURN @@RowCount
END

-- TaxType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[TaxType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaxType_Insert] 
	@New_TaxTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IsSystem as bit

	,@TaxTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [TaxType] 
		(
		[TaxTypeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_TaxTypeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @TaxTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[TaxType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaxType_Update] 
	@Original_TaxTypeID as bigint
	,@New_TaxTypeTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [TaxType] 
	SET
		[TaxTypeTitle]=@New_TaxTypeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[TaxTypeID]=@Original_TaxTypeID

	RETURN @@RowCount
END

-- User --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[UpdateTableStatus]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTableStatus] 
	 @TableName as varchar(50)
    ,@StatusID as int   
AS
BEGIN
	DECLARE @query as varchar(max)
	
	SET @query = '
	UPDATE ' + @TableName + '
	SET 
	[StatusID] = @StatusID'

	EXEC @query
	
	RETURN @@RowCount	
END
GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Insert] 
	@New_UserName as nvarchar(100)
	,@New_UserPassword as nvarchar(20)
	,@New_Useremail as nvarchar(200)
	,@New_PasswordResetCode as nvarchar(200)
	,@New_AcvtivationGUID as nvarchar(200)
	,@New_UserTypeID as bigint
	,@New_StatusID as bigint
	,@New_IsLoggedIn as bit
	,@New_IsSystem as bit
	,@New_GroupID as bigint

	,@SpProfileID as bigint
	,@UserID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [User] 
		(
		[UserName]
		,[UserPassword]
		,[Useremail]
		,[PasswordResetCode]
		,[AcvtivationGUID]
		,[UserTypeID]
		,[StatusID]
		,[IsLoggedIn]
		,[IsSystem]
		,[GroupID]
		,[CreatedByUserID]
		,[LastModifiedByUserID]
		,[CreatedDateTime]
		,[LastModifiedDateTime]
		,[ApprovedByUserID]
		,[ApprovedDateTime]
		)
	VALUES
		(
		@New_UserName
		, @New_UserPassword
		, @New_Useremail
		, @New_PasswordResetCode
		, @New_AcvtivationGUID
		, @New_UserTypeID
		, @New_StatusID
		, @New_IsLoggedIn
		, @New_IsSystem
		, @New_GroupID
		, @SpProfileID
		, @SpProfileID
		, GETDATE()
		, GETDATE()
		, NULL
		, NULL
		)

	SET @UserID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update] 
	@Original_UserID as bigint
	,@New_UserName as nvarchar(100)
	,@New_UserPassword as nvarchar(20)
	,@New_Useremail as nvarchar(200)
	,@New_PasswordResetCode as nvarchar(200)
	,@New_AcvtivationGUID as nvarchar(200)
	,@New_UserTypeID as bigint
	,@New_StatusID as bigint
	,@New_IsLoggedIn as bit
	,@New_IsSystem as bit
	,@New_GroupID as bigint

	,@SpProfileID as bigint
	,@LastModifiedDateTime as datetime
AS
BEGIN
	UPDATE [User] 
	SET
		[UserName]=@New_UserName
		,[UserPassword]=@New_UserPassword
		,[Useremail]=@New_Useremail
		,[PasswordResetCode]=@New_PasswordResetCode
		,[AcvtivationGUID]=@New_AcvtivationGUID
		,[UserTypeID]=@New_UserTypeID
		,[StatusID]=@New_StatusID
		,[IsLoggedIn]=@New_IsLoggedIn
		,[IsSystem]=@New_IsSystem
		,[GroupID]=@New_GroupID
		,[LastModifiedByUserID]=@SpProfileID
		,[LastModifiedDateTime]=GETDATE()
	WHERE 
		[UserID]=@Original_UserID
		AND
		[LastModifiedDateTime] = @LastModifiedDateTime

	RETURN @@RowCount
END

-- UserType --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[UserType_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserType_Insert] 
	@New_UserTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

	,@UserTypeID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [UserType] 
		(
		[UserTypeTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_UserTypeTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @UserTypeID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[UserType_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserType_Update] 
	@Original_UserTypeID as bigint
	,@New_UserTypeTitle as nvarchar(50)
	,@New_Description as nvarchar(500)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [UserType] 
	SET
		[UserTypeTitle]=@New_UserTypeTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[UserTypeID]=@Original_UserTypeID

	RETURN @@RowCount
END

-- VerificationStatus --
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[VerificationStatus_Insert]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificationStatus_Insert] 
	@New_VerificationStatusTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IsSystem as bit

	,@VerificationStatusID as bigint OUTPUT
AS
BEGIN
	INSERT INTO [VerificationStatus] 
		(
		[VerificationStatusTitle]
		,[Description]
		,[IsSystem]
		)
	VALUES
		(
		@New_VerificationStatusTitle
		, @New_Description
		, @New_IsSystem
		)

	SET @VerificationStatusID = SCOPE_IDENTITY();
	RETURN @@RowCount
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[VerificationStatus_Update]    Script Date: 6/3/2021 10:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificationStatus_Update] 
	@Original_VerificationStatusID as bigint
	,@New_VerificationStatusTitle as nvarchar(100)
	,@New_Description as nvarchar(1000)
	,@New_IsSystem as bit

AS
BEGIN
	UPDATE [VerificationStatus] 
	SET
		[VerificationStatusTitle]=@New_VerificationStatusTitle
		,[Description]=@New_Description
		,[IsSystem]=@New_IsSystem
	WHERE 
		[VerificationStatusID]=@Original_VerificationStatusID

	RETURN @@RowCount
END


SET ANSI_NULLS ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System will automatically calc the tax amount based on either Shop Location or Delivery Location. (respective Tax Rate defined by the govt of that location). ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CartItem', @level2type=N'COLUMN',@level2name=N'TaxAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CartItem', @level2type=N'CONSTRAINT',@level2name=N'FK_CartItem_CartOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NULL if row is CART. otherwise it is Order. In case of Order this field will contain cart id for reference and tracking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CartOrder', @level2type=N'COLUMN',@level2name=N'ParentCartID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Only if Row is ORDER not CART' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CartOrder', @level2type=N'COLUMN',@level2name=N'OrderSupplierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Record ID of the Selected Subject. e.g. Product Id = 1 for Product 
or Shop Id = 3 for Shop' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerReview', @level2type=N'COLUMN',@level2name=N'SubjectRowID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier that define the entity (table-name) for which review is being posted. e.g. Product or Shop' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CustomerReview', @level2type=N'COLUMN',@level2name=N'SubjectID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Available Sytem DataTypes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FilePath/URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductMediaDetail', @level2type=N'COLUMN',@level2name=N'MediaFilePath'
GO
