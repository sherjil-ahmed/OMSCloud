using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public partial class OMSContext : DbContext
    {
        public virtual int Address_Insert(Address address, ObjectParameter addressID, long? exisitng_SupplierId = null)
        {
            var new_ProfileIDParameter = address.ProfileID > -1 ?
                new ObjectParameter("New_ProfileID", address.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_AddressTypeIDParameter = address.AddressTypeID > -1 ?
                new ObjectParameter("New_AddressTypeID", address.AddressTypeID) :
                new ObjectParameter("New_AddressTypeID", typeof(long));

            var new_PlotNumberParameter = address.PlotNumber != null ?
                new ObjectParameter("New_PlotNumber", address.PlotNumber) :
                new ObjectParameter("New_PlotNumber", typeof(string));

            var new_StreetNumberParameter = address.StreetNumber != null ?
                new ObjectParameter("New_StreetNumber", address.StreetNumber) :
                new ObjectParameter("New_StreetNumber", typeof(string));

            var new_CountryIDParameter = address.CountryID.HasValue ?
                new ObjectParameter("New_CountryID", address.CountryID) :
                new ObjectParameter("New_CountryID", typeof(long));

            var new_ProvinceIDParameter = address.ProvinceID.HasValue ?
                new ObjectParameter("New_ProvinceID", address.ProvinceID) :
                new ObjectParameter("New_ProvinceID", typeof(long));

            var new_CityIDParameter = address.CityID.HasValue ?
                new ObjectParameter("New_CityID", address.CityID) :
                new ObjectParameter("New_CityID", typeof(long));

            var new_LocationIDParameter = address.LocationID > -1 ?
                new ObjectParameter("New_LocationID", address.LocationID) :
                new ObjectParameter("New_LocationID", typeof(long));

            var new_NearestLandmarkParameter = address.NearestLandmark != null ?
                new ObjectParameter("New_NearestLandmark", address.NearestLandmark) :
                new ObjectParameter("New_NearestLandmark", typeof(string));

            var new_PostalCodeParameter = address.PostalCode != null ?
                new ObjectParameter("New_PostalCode", address.PostalCode) :
                new ObjectParameter("New_PostalCode", typeof(string));

            var new_MapLinkParameter = address.MapLink != null ?
                new ObjectParameter("New_MapLink", address.MapLink) :
                new ObjectParameter("New_MapLink", typeof(string));

            var exisitng_SupplierIdParameter =  exisitng_SupplierId.HasValue ?
                new ObjectParameter("Exisitng_SupplierId", exisitng_SupplierId.Value) :
                new ObjectParameter("Exisitng_SupplierId", typeof(long));

            var spProfileIDParameter = address.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", address.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("Address_Insert", 
                new_ProfileIDParameter, 
                new_AddressTypeIDParameter, 
                new_PlotNumberParameter, 
                new_StreetNumberParameter,
                new_CountryIDParameter, 
                new_ProvinceIDParameter, 
                new_CityIDParameter, 
                new_LocationIDParameter, 
                new_NearestLandmarkParameter, 
                new_PostalCodeParameter, 
                new_MapLinkParameter,
                exisitng_SupplierIdParameter,
                spProfileIDParameter, 
                addressID);
        }

        public virtual int Address_Update(Address address)
        {
            var original_AddressIDParameter = address.AddressID > -1 ?
                new ObjectParameter("Original_AddressID", address.AddressID) :
                new ObjectParameter("Original_AddressID", typeof(long));

            var new_ProfileIDParameter = address.ProfileID > -1 ?
                new ObjectParameter("New_ProfileID", address.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_AddressTypeIDParameter = address.AddressTypeID > -1 ?
                new ObjectParameter("New_AddressTypeID", address.AddressTypeID) :
                new ObjectParameter("New_AddressTypeID", typeof(long));

            var new_PlotNumberParameter = address.PlotNumber != null ?
                new ObjectParameter("New_PlotNumber", address.PlotNumber) :
                new ObjectParameter("New_PlotNumber", typeof(string));

            var new_StreetNumberParameter = address.StreetNumber != null ?
                new ObjectParameter("New_StreetNumber", address.StreetNumber) :
                new ObjectParameter("New_StreetNumber", typeof(string));

            var new_CountryIDParameter = address.CountryID.HasValue ?
                new ObjectParameter("New_CountryID", address.CountryID) :
                new ObjectParameter("New_CountryID", typeof(long));

            var new_ProvinceIDParameter = address.ProvinceID.HasValue ?
                new ObjectParameter("New_ProvinceID", address.ProvinceID) :
                new ObjectParameter("New_ProvinceID", typeof(long));

            var new_CityIDParameter = address.CityID.HasValue ?
                new ObjectParameter("New_CityID", address.CityID) :
                new ObjectParameter("New_CityID", typeof(long));

            var new_LocationIDParameter = address.LocationID > -1 ?
                new ObjectParameter("New_LocationID", address.LocationID) :
                new ObjectParameter("New_LocationID", typeof(long));

            var new_NearestLandmarkParameter = address.NearestLandmark != null ?
                new ObjectParameter("New_NearestLandmark", address.NearestLandmark) :
                new ObjectParameter("New_NearestLandmark", typeof(string));

            var new_PostalCodeParameter = address.PostalCode != null ?
                new ObjectParameter("New_PostalCode", address.PostalCode) :
                new ObjectParameter("New_PostalCode", typeof(string));
            
            var new_MapLinkParameter = address.MapLink != null ?
                new ObjectParameter("New_MapLink", address.MapLink) :
                new ObjectParameter("New_MapLink", typeof(string));

            var spProfileIDParameter = address.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", address.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = address.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", address.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("Address_Update", 
                original_AddressIDParameter,
                new_ProfileIDParameter, 
                new_AddressTypeIDParameter, 
                new_PlotNumberParameter, 
                new_StreetNumberParameter,
                new_CountryIDParameter,
                new_ProvinceIDParameter,
                new_CityIDParameter,
                new_LocationIDParameter, 
                new_NearestLandmarkParameter, 
                new_PostalCodeParameter, 
                new_MapLinkParameter, 
                spProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int AddressType_Insert(AddressType addressType, ObjectParameter addressTypeID)
        {
            var new_AddressTypeTitleParameter = addressType.AddressTypeTitle != null ?
                new ObjectParameter("New_AddressTypeTitle", addressType.AddressTypeTitle) :
                new ObjectParameter("New_AddressTypeTitle", typeof(string));

            var new_DescriptionParameter = addressType.Description != null ?
                new ObjectParameter("New_Description", addressType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", addressType.IsSystem);


            return ObjectContext.ExecuteFunction("AddressType_Insert", new_AddressTypeTitleParameter, new_DescriptionParameter, addressTypeID, new_IsSystemParameter);
        }

        public virtual int AddressType_Update(AddressType addressType)
        {
            var original_AddressTypeIDParameter = addressType.AddressTypeID > -1 ?
                new ObjectParameter("Original_AddressTypeID", addressType.AddressTypeID) :
                new ObjectParameter("Original_AddressTypeID", typeof(long));

            var new_AddressTypeTitleParameter = addressType.AddressTypeTitle != null ?
                new ObjectParameter("New_AddressTypeTitle", addressType.AddressTypeTitle) :
                new ObjectParameter("New_AddressTypeTitle", typeof(string));

            var new_DescriptionParameter = addressType.Description != null ?
                new ObjectParameter("New_Description", addressType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", addressType.IsSystem);


            return ObjectContext.ExecuteFunction("AddressType_Update", original_AddressTypeIDParameter, new_AddressTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int AppConfig_Insert(AppConfig appConfig, ObjectParameter configID)
        {
            var new_ConfigTitleParameter = appConfig.ConfigTitle != null ?
                new ObjectParameter("New_ConfigTitle", appConfig.ConfigTitle) :
                new ObjectParameter("New_ConfigTitle", typeof(string));

            var new_ConfigValueParameter = appConfig.ConfigValue != null ?
                new ObjectParameter("New_ConfigValue", appConfig.ConfigValue) :
                new ObjectParameter("New_ConfigValue", typeof(string));

            var new_DisplayTextParameter = appConfig.DisplayText != null ?
                new ObjectParameter("New_DisplayText", appConfig.DisplayText) :
                new ObjectParameter("New_DisplayText", typeof(string));

            var new_ParentConfigIDParameter = appConfig.ParentConfigID > -1 ?
                new ObjectParameter("New_ParentConfigID", appConfig.ParentConfigID) :
                new ObjectParameter("New_ParentConfigID", typeof(long));

            var new_DescriptionParameter = appConfig.Description != null ?
                new ObjectParameter("New_Description", appConfig.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", appConfig.IsSystem);

            return ObjectContext.ExecuteFunction("AppConfig_Insert", new_ConfigTitleParameter, new_ConfigValueParameter, new_DisplayTextParameter, new_ParentConfigIDParameter, new_DescriptionParameter, configID, new_IsSystemParameter);
        }

        public virtual int AppConfig_Update(AppConfig appConfig)
        {
            var original_ConfigIDParameter = appConfig.ConfigID > -1 ?
                new ObjectParameter("Original_ConfigID", appConfig.ConfigID) :
                new ObjectParameter("Original_ConfigID", typeof(long));

            var new_ConfigTitleParameter = appConfig.ConfigTitle != null ?
                new ObjectParameter("New_ConfigTitle", appConfig.ConfigTitle) :
                new ObjectParameter("New_ConfigTitle", typeof(string));

            var new_ConfigValueParameter = appConfig.ConfigValue != null ?
                new ObjectParameter("New_ConfigValue", appConfig.ConfigValue) :
                new ObjectParameter("New_ConfigValue", typeof(string));

            var new_DisplayTextParameter = appConfig.DisplayText != null ?
                new ObjectParameter("New_DisplayText", appConfig.DisplayText) :
                new ObjectParameter("New_DisplayText", typeof(string));

            var new_ParentConfigIDParameter = appConfig.ParentConfigID.HasValue ?
                new ObjectParameter("New_ParentConfigID", appConfig.ParentConfigID) :
                new ObjectParameter("New_ParentConfigID", typeof(long));

            var new_DescriptionParameter = appConfig.Description != null ?
                new ObjectParameter("New_Description", appConfig.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", appConfig.IsSystem);

            return ObjectContext.ExecuteFunction("AppConfig_Update", original_ConfigIDParameter, new_ConfigTitleParameter, new_ConfigValueParameter, new_DisplayTextParameter, new_ParentConfigIDParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int Attribute_Insert(Attribute attribute, ObjectParameter attributeID)
        {
            var new_AttributeTitleParameter = attribute.AttributeTitle != null ?
                new ObjectParameter("New_AttributeTitle", attribute.AttributeTitle) :
                new ObjectParameter("New_AttributeTitle", typeof(string));

            var new_DescriptionParameter = attribute.Description != null ?
                new ObjectParameter("New_Description", attribute.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_AttributeTypeIDParameter = attribute.AttributeTypeID > -1 ?
                new ObjectParameter("New_AttributeTypeID", attribute.AttributeTypeID) :
                new ObjectParameter("New_AttributeTypeID", typeof(long));

            var new_DataTypeIDParameter = attribute.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", attribute.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            var new_DataTypeSizeParameter = attribute.DataTypeSize > -1 ?
                new ObjectParameter("New_DataTypeSize", attribute.DataTypeSize) :
                new ObjectParameter("New_DataTypeSize", typeof(int));

            var new_DefaultValueParameter = attribute.DefaultValue != null ?
                new ObjectParameter("New_DefaultValue", attribute.DefaultValue) :
                new ObjectParameter("New_DefaultValue", typeof(string));

            var new_IsMandatoryParameter = new ObjectParameter("New_IsMandatory", attribute.IsMandatory);

            var new_IsMultiSelectParameter = new ObjectParameter("New_IsMultiSelect", attribute.IsMultiSelect);

            var new_StatusIDParameter = attribute.StatusID > -1 ?
                new ObjectParameter("New_StatusID", attribute.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = attribute.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", attribute.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", attribute.IsSystem);

            return ObjectContext.ExecuteFunction("Attribute_Insert", new_AttributeTypeIDParameter, new_AttributeTitleParameter, new_DescriptionParameter, new_DataTypeIDParameter, new_DataTypeSizeParameter, new_DefaultValueParameter, new_IsMandatoryParameter, new_StatusIDParameter, SpProfileIDParameter, attributeID, new_IsSystemParameter, new_IsMultiSelectParameter);
        }

        public virtual int Attribute_Update(Attribute attribute)
        {
            var original_AttributeIDParameter = attribute.AttributeID > -1 ?
                new ObjectParameter("Original_AttributeID", attribute.AttributeID) :
                new ObjectParameter("Original_AttributeID", typeof(long));

            var new_AttributeTitleParameter = attribute.AttributeTitle != null ?
                new ObjectParameter("New_AttributeTitle", attribute.AttributeTitle) :
                new ObjectParameter("New_AttributeTitle", typeof(string));

            var new_DescriptionParameter = attribute.Description != null ?
                new ObjectParameter("New_Description", attribute.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_DataTypeIDParameter = attribute.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", attribute.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            var new_DataTypeSizeParameter = attribute.DataTypeSize > -1 ?
                new ObjectParameter("New_DataTypeSize", attribute.DataTypeSize) :
                new ObjectParameter("New_DataTypeSize", typeof(int));

            var new_DefaultValueParameter = attribute.DefaultValue != null ?
                new ObjectParameter("New_DefaultValue", attribute.DefaultValue) :
                new ObjectParameter("New_DefaultValue", typeof(string));

            var new_IsMandatoryParameter = new ObjectParameter("New_IsMandatory", attribute.IsMandatory);
            var new_IsMultiSelectParameter = new ObjectParameter("New_IsMultiSelect", attribute.IsMultiSelect);
            
            var new_StatusIDParameter = attribute.StatusID > -1 ?
                new ObjectParameter("New_StatusID", attribute.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = attribute.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", attribute.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var new_AttributeTypeIDParameter = attribute.AttributeTypeID > -1 ?
                new ObjectParameter("New_AttributeTypeID", attribute.AttributeTypeID) :
                new ObjectParameter("New_AttributeTypeID", typeof(long));

            var lastModifiedDateTimeParameter = attribute.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", attribute.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", attribute.IsSystem);

            return ObjectContext.ExecuteFunction(
                "Attribute_Update", 
                original_AttributeIDParameter, 
                new_AttributeTitleParameter, 
                new_AttributeTypeIDParameter, 
                new_DescriptionParameter, 
                new_DataTypeIDParameter, 
                new_DataTypeSizeParameter, 
                new_DefaultValueParameter, 
                new_IsMandatoryParameter,
                new_IsMultiSelectParameter,
                new_StatusIDParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter, 
                new_IsSystemParameter);
        }

        public virtual int Brand_Insert(Brand brand, ObjectParameter brandID)
        {
            var new_BrandNameParameter = brand.BrandName != null ?
                new ObjectParameter("New_BrandName", brand.BrandName) :
                new ObjectParameter("New_BrandName", typeof(string));

            var new_ManufacturerNameParameter = brand.ManufacturerName != null ?
                new ObjectParameter("New_ManufacturerName", brand.ManufacturerName) :
                new ObjectParameter("New_ManufacturerName", typeof(string));

            var new_DescriptionParameter = brand.Description != null ?
                new ObjectParameter("New_Description", brand.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = brand.StatusID > -1 ?
                new ObjectParameter("New_StatusID", brand.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = brand.LastModifiedByUserID > -1 ? 
                new ObjectParameter("SpProfileID", brand.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", brand.IsSystem);

            return ObjectContext.ExecuteFunction("Brand_Insert", new_BrandNameParameter, new_ManufacturerNameParameter, new_DescriptionParameter, new_StatusIDParameter, SpProfileIDParameter, brandID, new_IsSystemParameter);
        }

        public virtual int Brand_Update(Brand brand)
        {
            var original_BrandIDParameter = brand.BrandID > -1 ?
                new ObjectParameter("Original_BrandID", brand.BrandID) :
                new ObjectParameter("Original_BrandID", typeof(long));

            var new_BrandNameParameter = brand.BrandName != null ?
                new ObjectParameter("New_BrandName", brand.BrandName) :
                new ObjectParameter("New_BrandName", typeof(string));

            var new_ManufacturerNameParameter = brand.ManufacturerName != null ?
                new ObjectParameter("New_ManufacturerName", brand.ManufacturerName) :
                new ObjectParameter("New_ManufacturerName", typeof(string));

            var new_DescriptionParameter = brand.Description != null ?
                new ObjectParameter("New_Description", brand.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = brand.StatusID > -1 ?
                new ObjectParameter("New_StatusID", brand.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = brand.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", brand.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = brand.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", brand.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", brand.IsSystem);

            return ObjectContext.ExecuteFunction("Brand_Update", original_BrandIDParameter, new_BrandNameParameter, new_ManufacturerNameParameter, new_DescriptionParameter, new_StatusIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter, new_IsSystemParameter);
        }

        #region Cart-Order-LineItems

        public virtual int CartItem_Insert(CartItem cartItem, ObjectParameter cartItemID)
        {
            var new_CartOrderIDParameter = cartItem.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", cartItem.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            var new_ProductIDParameter = cartItem.ProductID > -1 ?
                new ObjectParameter("New_ProductID", cartItem.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_StatusIDParameter = cartItem.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cartItem.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_UnitPriceParameter = new ObjectParameter("New_UnitPrice", cartItem.UnitPrice);
            var new_QuantityParameter = new ObjectParameter("New_Quantity", cartItem.Quantity);
            var new_TaxRateAppliedParameter = new ObjectParameter("New_TaxRateApplied", cartItem.TaxRateApplied);
            var new_TaxAmountAppliedParameter = new ObjectParameter("New_TaxAmount", cartItem.TaxAmount);
            var new_DiscountAmountParameter = new ObjectParameter("New_DiscountAmount", cartItem.DiscountAmount);
            var new_ItemTotalPriceParameter = new ObjectParameter("New_ItemTotalPrice", cartItem.ItemTotalPrice) ;

            var new_SpProfileIDParameter = cartItem.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cartItem.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "CartItem_Insert", 
                new_CartOrderIDParameter, 
                new_ProductIDParameter, 
                new_StatusIDParameter,
                new_UnitPriceParameter,
                new_TaxRateAppliedParameter,
                new_TaxAmountAppliedParameter,
                new_DiscountAmountParameter,
                new_QuantityParameter, 
                new_ItemTotalPriceParameter, 
                new_SpProfileIDParameter, 
                cartItemID);
        }

        public virtual int CartItem_Update(CartItem cartItem)
        {
            var original_CartItemIDParameter = cartItem.CartItemID > -1 ?
                new ObjectParameter("Original_CartItemID", cartItem.CartItemID) :
                new ObjectParameter("Original_CartItemID", typeof(long));

            var new_CartOrderIDParameter = cartItem.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", cartItem.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            var new_ProductIDParameter = cartItem.ProductID > -1 ?
                new ObjectParameter("New_ProductID", cartItem.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_StatusIDParameter = cartItem.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cartItem.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_UnitPriceParameter = new ObjectParameter("New_UnitPrice", cartItem.UnitPrice);
            var new_QuantityParameter = new ObjectParameter("New_Quantity", cartItem.Quantity);
            var new_ItemTotalPriceParameter = new ObjectParameter("New_ItemTotalPrice", cartItem.ItemTotalPrice) ;
            var new_TaxRateAppliedParameter = new ObjectParameter("New_TaxRateApplied", cartItem.TaxRateApplied);
            var new_TaxAmountAppliedParameter = new ObjectParameter("New_TaxAmount", cartItem.TaxAmount);
            var new_DiscountAmountParameter = new ObjectParameter("New_DiscountAmount", cartItem.DiscountAmount);


            var new_ProfileIDParameter = cartItem.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cartItem.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = cartItem.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", cartItem.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));


            return ObjectContext.ExecuteFunction(
                "CartItem_Update", 
                original_CartItemIDParameter, 
                new_CartOrderIDParameter, 
                new_ProductIDParameter, 
                new_StatusIDParameter,
                new_UnitPriceParameter,
                new_QuantityParameter, 
                new_ProfileIDParameter, 
                new_ItemTotalPriceParameter,
                new_TaxRateAppliedParameter,
                new_TaxAmountAppliedParameter,
                new_DiscountAmountParameter,
                lastModifiedDateTimeParameter);
        }

        public virtual int CartOrder_Insert(CartOrder cartOrder, ObjectParameter cartOrderID)
        {
            var new_BuyerProfileIDParameter = cartOrder.BuyerProfileID > -1 ?
                new ObjectParameter("New_ProfileID", cartOrder.BuyerProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_ParentCartIDParameter = cartOrder.ParentCartID > -1 ?
                new ObjectParameter("New_ParentCartID", cartOrder.ParentCartID) :
                new ObjectParameter("New_ParentCartID", typeof(long));

            var new_OrderStatusIDParameter = cartOrder.OrderStatusID > -1 ?
                new ObjectParameter("New_OrderStatusID", cartOrder.OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(long));

            var new_DeliveryAddressID = cartOrder.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", cartOrder.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            var new_DeliveryAddress = cartOrder.DeliveryAddress != null ?
                new ObjectParameter("New_DeliveryAddress", cartOrder.DeliveryAddress) :
                new ObjectParameter("New_DeliveryAddress", typeof(string));

            var new_OrderSupplierID = cartOrder.OrderSupplierId > -1 ?
                new ObjectParameter("New_OrderSupplierId", cartOrder.OrderSupplierId) :
                new ObjectParameter("New_OrderSupplierId", typeof(long));
            
            var new_SupplierDeliveryOptionPairID = cartOrder.SupplierDeliveryOptionPairID > -1 ?
                new ObjectParameter("New_SupplierDeliveryOptionPairID", cartOrder.SupplierDeliveryOptionPairID) :
                new ObjectParameter("New_SupplierDeliveryOptionPairID", typeof(long));

            var new_StatusIDParameter = cartOrder.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cartOrder.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_OrderTotalParameter =new ObjectParameter("New_OrderTotal", cartOrder.OrderTotal);

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", cartOrder.TaxTotal);

            var new_SpProfileIDParameter = cartOrder.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cartOrder.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "CartOrder_Insert",
                new_BuyerProfileIDParameter,
                new_ParentCartIDParameter,
                new_OrderStatusIDParameter,
                new_StatusIDParameter,
                new_DeliveryAddressID,
                new_DeliveryAddress,
                new_OrderSupplierID,
                new_SupplierDeliveryOptionPairID,
                new_OrderTotalParameter,
                new_TaxTotalParameter,
                new_SpProfileIDParameter,
                cartOrderID);
        }

        public virtual int CartOrder_Update(CartOrder cartOrder)
        {
            var original_CartOrderIDParameter = cartOrder.CartOrderID > -1 ?
                new ObjectParameter("Original_CartOrderID", cartOrder.CartOrderID) :
                new ObjectParameter("Original_CartOrderID", typeof(long));

            var new_BuyerProfileIDParameter = cartOrder.BuyerProfileID > -1 ?
                new ObjectParameter("New_BuyerProfileID", cartOrder.BuyerProfileID) :
                new ObjectParameter("New_BuyerProfileID", typeof(long));

            var new_ParentCartIDParameter = cartOrder.ParentCartID > -1 ?
                new ObjectParameter("New_ParentCartID", cartOrder.ParentCartID) :
                new ObjectParameter("New_ParentCartID", typeof(long));

            var new_OrderStatusIDParameter = cartOrder.OrderStatusID > -1 ?
                new ObjectParameter("New_OrderStatusID", cartOrder.OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(long));

            var new_StatusIDParameter = cartOrder.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cartOrder.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_DeliveryAddressID = cartOrder.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", cartOrder.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            var new_DeliveryAddress = cartOrder.DeliveryAddress != null ?
                new ObjectParameter("New_DeliveryAddress", cartOrder.DeliveryAddress) :
                new ObjectParameter("New_DeliveryAddress", typeof(string));

            var new_OrderSupplierID = cartOrder.OrderSupplierId > -1 ?
                new ObjectParameter("New_OrderSupplierId", cartOrder.OrderSupplierId) :
                new ObjectParameter("New_OrderSupplierId", typeof(long));

            var new_SupplierDeliveryOptionPairID = cartOrder.SupplierDeliveryOptionPairID > 0 ?
                new ObjectParameter("New_SupplierDeliveryOptionPairID", cartOrder.SupplierDeliveryOptionPairID) :
                new ObjectParameter("New_SupplierDeliveryOptionPairID", typeof(long));

            var new_OrderTotalParameter = new ObjectParameter("New_OrderTotal", cartOrder.OrderTotal);

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", cartOrder.TaxTotal);

            var new_DeliveryTotalParameter = new ObjectParameter("New_DeliveryTotal", cartOrder.DeliveryTotal);

            var new_DiscountTotalParameter = new ObjectParameter("New_DiscountTotal", cartOrder.DiscountTotal);

            var new_PaymentTotalParameter = new ObjectParameter("New_PaymentTotal", cartOrder.PaymentTotal);

            var new_CalculatedPayoutParameter = new ObjectParameter("New_CalculatedPayout", cartOrder.CalculatedPayout);

            var new_ActualPayoutParameter = new ObjectParameter("New_ActualPayout", cartOrder.ActualPayout);

            var new_CalculatedPayInParameter = new ObjectParameter("New_CalculatedPayIn", cartOrder.CalculatedPayIn);

            var new_ActualPayInParameter = new ObjectParameter("New_ActualPayIn", cartOrder.ActualPayIn);

            var new_SpProfileIDParameter = cartOrder.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cartOrder.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = cartOrder.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", cartOrder.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "CartOrder_Update",
                original_CartOrderIDParameter,
                new_BuyerProfileIDParameter,
                new_ParentCartIDParameter,
                new_OrderStatusIDParameter,
                new_StatusIDParameter,
                new_DeliveryAddressID,
                new_DeliveryAddress,
                new_OrderSupplierID,
                new_SupplierDeliveryOptionPairID,
                new_OrderTotalParameter,
                new_TaxTotalParameter,
                new_DeliveryTotalParameter,
                new_DiscountTotalParameter,
                new_PaymentTotalParameter,
                new_CalculatedPayoutParameter,
                new_ActualPayoutParameter,
                new_CalculatedPayInParameter,
                new_ActualPayInParameter,
                new_SpProfileIDParameter,
                lastModifiedDateTimeParameter);
        }

        public virtual int Cart_Insert(CartOrder cart, ObjectParameter cartID)
        {
            var new_BuyerProfileIDParameter = cart.BuyerProfileID > -1 ?
                new ObjectParameter("New_BuyerProfileID", cart.BuyerProfileID) :
                new ObjectParameter("New_BuyerProfileID", typeof(long));

            var new_CartStatusIDParameter = cart.OrderStatusID > -1 ?
                new ObjectParameter("New_CartStatusID", cart.OrderStatusID) :
                new ObjectParameter("New_CartStatusID", typeof(long));

            var new_StatusIDParameter = cart.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cart.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_CartTotalParameter = new ObjectParameter("New_CartTotal", cart.OrderTotal);

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", cart.TaxTotal) ;

            var new_DiscountTotalParameter = new ObjectParameter("New_DiscountTotal", cart.DiscountTotal) ;

            var new_SpProfileIDParameter = cart.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cart.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Cart_Insert",
                new_BuyerProfileIDParameter,
                new_CartStatusIDParameter,
                new_StatusIDParameter,
                new_CartTotalParameter,
                new_TaxTotalParameter,
                new_DiscountTotalParameter,
                new_SpProfileIDParameter,
                cartID);
        }

        public virtual int Cart_Update(CartOrder cart)
        {
            var original_CartIDParameter = cart.CartOrderID > -1 ?
                new ObjectParameter("Original_CartID", cart.CartOrderID) :
                new ObjectParameter("Original_CartID", typeof(long));

            var new_CartStatusIDParameter = cart.OrderStatusID > -1 ?
                new ObjectParameter("New_CartStatusID", cart.OrderStatusID) :
                new ObjectParameter("New_CartStatusID", typeof(long));

            var new_StatusIDParameter = cart.StatusID > -1 ?
                new ObjectParameter("New_StatusID", cart.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_CartTotalParameter = new ObjectParameter("New_CartTotal", cart.OrderTotal) ;

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", cart.TaxTotal);

            var new_DiscountTotalParameter = new ObjectParameter("New_DiscountTotal", cart.DiscountTotal);
            //var new_DeliveryTotalParameter = new ObjectParameter("New_DeliveryTotal", cart.DeliveryTotal);
            //var new_PaymentTotalParameter = new ObjectParameter("New_PaymentTotal", cart.PaymentTotal);
            
            var new_SpProfileIDParameter = cart.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", cart.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = cart.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", cart.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Cart_Update",
                original_CartIDParameter,
                new_CartStatusIDParameter,
                new_StatusIDParameter,
                new_CartTotalParameter,
                new_TaxTotalParameter,
                new_DiscountTotalParameter,
                //new_DeliveryTotalParameter,
                //new_PaymentTotalParameter,
                new_SpProfileIDParameter,
                lastModifiedDateTimeParameter);
        }
        public virtual ObjectResult<sp_ConvertCartToOrders_Result> Sp_ConvertCartToOrders(ConvertCartToOrders_SpParamsEntity param )
        {
            return sp_ConvertCartToOrders(param.existing_CartId, param.new_DeliveryAddressID, param.new_SupplierDeliveryOptionPairID, param.spProfileId);
        }
        public virtual int Order_Insert(CartOrder Order, ObjectParameter OrderID)
        {
            var new_BuyerProfileIDParameter = Order.BuyerProfileID > -1 ?
                new ObjectParameter("New_BuyerProfileID", Order.BuyerProfileID) :
                new ObjectParameter("New_BuyerProfileID", typeof(long));

            var new_ParentCartIDParameter = Order.ParentCartID > -1 ?
                new ObjectParameter("New_ParentCartID", Order.ParentCartID) :
                new ObjectParameter("New_ParentCartID", typeof(long));

            var new_OrderStatusIDParameter = Order.OrderStatusID > -1 ?
                new ObjectParameter("New_OrderStatusID", Order.OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(long));

            var new_StatusIDParameter = Order.StatusID > -1 ?
                new ObjectParameter("New_StatusID", Order.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_DeliveryAddressID = Order.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", Order.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            var new_DeliveryAddress = Order.DeliveryAddress != null ?
                new ObjectParameter("New_DeliveryAddress", Order.DeliveryAddress) :
                new ObjectParameter("New_DeliveryAddress", typeof(string));

            var new_OrderSupplierID = Order.OrderSupplierId > -1 ?
                new ObjectParameter("New_OrderSupplierId", Order.OrderSupplierId) :
                new ObjectParameter("New_OrderSupplierId", typeof(long));

            var new_SupplierDeliveryOptionPairID = Order.SupplierDeliveryOptionPairID > -1 ?
                new ObjectParameter("New_SupplierDeliveryOptionPairID", Order.SupplierDeliveryOptionPairID) :
                new ObjectParameter("New_SupplierDeliveryOptionPairID", typeof(long));

            var new_OrderTotalParameter = new ObjectParameter("New_OrderTotal", Order.OrderTotal);

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", Order.TaxTotal );
	
            var new_DeliveryTotalParameter = new ObjectParameter("New_DeliveryTotal", Order.DeliveryTotal );

            var new_DiscountTotalParameter = new ObjectParameter("New_DiscountTotal", Order.DiscountTotal) ;

            var new_PaymentTotalParameter = new ObjectParameter("New_PaymentTotal", Order.PaymentTotal );

            var new_SpProfileIDParameter = Order.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", Order.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Order_Insert",
                new_BuyerProfileIDParameter,
                new_ParentCartIDParameter,
                new_OrderStatusIDParameter,
                new_StatusIDParameter,
                new_DeliveryAddressID,
                new_DeliveryAddress,
                new_OrderSupplierID,
                new_SupplierDeliveryOptionPairID,
                new_OrderTotalParameter,
                new_TaxTotalParameter,
                new_DeliveryTotalParameter,
                new_DiscountTotalParameter,
                new_PaymentTotalParameter,
                new_SpProfileIDParameter,
                OrderID);
        }

        public virtual int Order_Update(CartOrder Order)
        {
            var original_OrderIDParameter = Order.CartOrderID > -1 ?
                new ObjectParameter("Original_OrderID", Order.CartOrderID) :
                new ObjectParameter("Original_OrderID", typeof(long));

            var new_BuyerProfileIDParameter = Order.BuyerProfileID > -1 ?
                new ObjectParameter("New_BuyerProfileID", Order.BuyerProfileID) :
                new ObjectParameter("New_BuyerProfileID", typeof(long));

            var new_ParentCartIDParameter = Order.ParentCartID > -1 ?
                new ObjectParameter("New_ParentCartID", Order.ParentCartID) :
                new ObjectParameter("New_ParentCartID", typeof(long));

            var new_OrderStatusIDParameter = Order.OrderStatusID > -1 ?
                new ObjectParameter("New_OrderStatusID", Order.OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(long));

            var new_StatusIDParameter = Order.StatusID > -1 ?
                new ObjectParameter("New_StatusID", Order.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_DeliveryAddressID = Order.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", Order.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            var new_DeliveryAddress = Order.DeliveryAddress != null ?
                new ObjectParameter("New_DeliveryAddress", Order.DeliveryAddress) :
                new ObjectParameter("New_DeliveryAddress", typeof(string));

            var new_OrderSupplierID = Order.OrderSupplierId > -1 ?
                new ObjectParameter("New_OrderSupplierId", Order.OrderSupplierId) :
                new ObjectParameter("New_OrderSupplierId", typeof(long));

            var new_SupplierDeliveryOptionPairID = Order.SupplierDeliveryOptionPairID > -1 ?
                new ObjectParameter("New_SupplierDeliveryOptionPairID", Order.SupplierDeliveryOptionPairID) :
                new ObjectParameter("New_SupplierDeliveryOptionPairID", typeof(long));

            var new_OrderTotalParameter = new ObjectParameter("New_OrderTotal", Order.OrderTotal);

            var new_TaxTotalParameter = new ObjectParameter("New_TaxTotal", Order.TaxTotal > 0) ;

            var new_DeliveryTotalParameter = new ObjectParameter("New_DeliveryTotal", Order.DeliveryTotal) ;

            var new_DiscountTotalParameter = new ObjectParameter("New_DiscountTotal", Order.DiscountTotal) ;

            var new_PaymentTotalParameter = new ObjectParameter("New_PaymentTotal", Order.PaymentTotal) ;

            var new_CalculatedPayoutParameter = new ObjectParameter("New_CalculatedPayout", Order.CalculatedPayout) ;

            var new_ActualPayoutParameter = new ObjectParameter("New_ActualPayout", Order.ActualPayout) ;

            var new_CalculatedPayInParameter = new ObjectParameter("New_CalculatedPayIn", Order.CalculatedPayIn);

            var new_ActualPayInParameter = new ObjectParameter("New_ActualPayIn", Order.ActualPayIn);

            var new_SpProfileIDParameter = Order.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", Order.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = Order.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", Order.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Order_Update",
                original_OrderIDParameter,
                new_BuyerProfileIDParameter,
                new_ParentCartIDParameter,
                new_OrderStatusIDParameter,
                new_StatusIDParameter,
                new_DeliveryAddressID,
                new_DeliveryAddress,
                new_OrderSupplierID,
                new_SupplierDeliveryOptionPairID,
                new_OrderTotalParameter,
                new_TaxTotalParameter,
                new_DeliveryTotalParameter,
                new_DiscountTotalParameter,
                new_PaymentTotalParameter,
                new_CalculatedPayoutParameter,
                new_ActualPayoutParameter,
                new_CalculatedPayInParameter,
                new_ActualPayInParameter,
                new_SpProfileIDParameter,
                lastModifiedDateTimeParameter);
        }

        public virtual int Order_Update_Status(CartOrder Order)
        {
            var original_OrderIDParameter = Order.CartOrderID > -1 ?
                new ObjectParameter("Original_OrderID", Order.CartOrderID) :
                new ObjectParameter("Original_OrderID", typeof(long));
            
            var new_OrderStatusIDParameter = Order.OrderStatusID > -1 ?
                new ObjectParameter("New_OrderStatusID", Order.OrderStatusID) :
                new ObjectParameter("New_OrderStatusID", typeof(long));

            var new_SpProfileIDParameter = Order.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", Order.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Order_Update_Status",
                original_OrderIDParameter,
                new_OrderStatusIDParameter,
                new_SpProfileIDParameter
                );
        }

        #endregion Cart-Order-LineItems

        public virtual int Category_Insert(Category category, ObjectParameter categoryID)
        {
            var new_CategoryTitleParameter = category.CategoryTitle != null ?
                new ObjectParameter("New_CategoryTitle", category.CategoryTitle) :
                new ObjectParameter("New_CategoryTitle", typeof(string));

            var new_DescriptionParameter = category.Description != null ?
                new ObjectParameter("New_Description", category.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_LogoPathParameter = category.LogoPath != null ?
                new ObjectParameter("New_LogoPath", category.LogoPath) :
                new ObjectParameter("New_LogoPath", typeof(string));

            var new_CategoryTypeIDParameter = category.CategoryTypeID > -1 ?
                new ObjectParameter("New_CategoryTypeID", category.CategoryTypeID) :
                new ObjectParameter("New_CategoryTypeID", typeof(long));

            var new_CategoryParentIDParameter = category.CategoryParentID.HasValue ?
                new ObjectParameter("New_CategoryParentID", category.CategoryParentID) :
                new ObjectParameter("New_CategoryParentID", typeof(long));

            var new_StatusIDParameter = category.StatusID > -1 ?
                new ObjectParameter("New_StatusID", category.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", category.IsSystem);

            var SpProfileIDParameter = category.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", category.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("Category_Insert", new_CategoryTitleParameter, new_DescriptionParameter, new_LogoPathParameter, new_CategoryTypeIDParameter, new_CategoryParentIDParameter, new_StatusIDParameter, new_IsSystemParameter, SpProfileIDParameter, categoryID);
        }

        public virtual int Category_Update(Category category)
        {
            //Nullable<int> original_CategoryID, string new_CategoryTitle, string new_Description, string new_LogoPath, Nullable<int> new_CategoryTypeID, Nullable<int> new_CategoryParentID, Nullable<int> new_StatusID, Nullable<bool> new_IsSystem
            var original_CategoryIDParameter = category.CategoryID > -1 ?
                new ObjectParameter("Original_CategoryID", category.CategoryID) :
                new ObjectParameter("Original_CategoryID", typeof(long));

            var new_CategoryTitleParameter = category.CategoryTitle != null ?
                new ObjectParameter("New_CategoryTitle", category.CategoryTitle) :
                new ObjectParameter("New_CategoryTitle", typeof(string));

            var new_DescriptionParameter = category.Description != null ?
                new ObjectParameter("New_Description", category.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_LogoPathParameter = category.LogoPath != null ?
                new ObjectParameter("New_LogoPath", category.LogoPath) :
                new ObjectParameter("New_LogoPath", typeof(string));

            var new_CategoryTypeIDParameter = category.CategoryTypeID > -1 ?
                new ObjectParameter("New_CategoryTypeID", category.CategoryTypeID) :
                new ObjectParameter("New_CategoryTypeID", typeof(long));

            var new_CategoryParentIDParameter = category.CategoryParentID.HasValue ?
                new ObjectParameter("New_CategoryParentID", category.CategoryParentID) :
                new ObjectParameter("New_CategoryParentID", typeof(long));

            var new_StatusIDParameter = category.StatusID > -1 ?
                new ObjectParameter("New_StatusID", category.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", category.IsSystem);


            var SpProfileIDParameter = category.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", category.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = category.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", category.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("Category_Update", original_CategoryIDParameter, new_CategoryTitleParameter, new_DescriptionParameter, new_LogoPathParameter, new_CategoryTypeIDParameter, new_CategoryParentIDParameter, new_StatusIDParameter, new_IsSystemParameter, SpProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int CategoryAttributePair_Insert(CategoryAttributePair categoryAttributePair, ObjectParameter categoryAttributePairID)
        {
            var new_CategoryIDParameter = categoryAttributePair.CategoryID > -1 ?
                new ObjectParameter("New_CategoryID", categoryAttributePair.CategoryID) :
                new ObjectParameter("New_CategoryID", typeof(long));

            var new_AttributeIDParameter = categoryAttributePair.AttributeID > -1 ?
                new ObjectParameter("New_AttributeID", categoryAttributePair.AttributeID) :
                new ObjectParameter("New_AttributeID", typeof(long));


            var new_AttributeValueParameter = categoryAttributePair.AttributeValue != null ?
                new ObjectParameter("New_AttributeValue", categoryAttributePair.AttributeValue) :
                new ObjectParameter("New_AttributeValue", typeof(string));

            var new_DisplayOrderParameter = categoryAttributePair.DisplayOrder.HasValue ?
                new ObjectParameter("New_DisplayOrder", categoryAttributePair.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));
            
            var new_IsAssignedParameter = categoryAttributePair.IsAssigned ?
                new ObjectParameter("New_IsAssigned", categoryAttributePair.IsAssigned) :
                new ObjectParameter("New_IsAssigned", typeof(bool));

            return ObjectContext.ExecuteFunction("CategoryAttributePair_Insert", new_CategoryIDParameter, new_AttributeIDParameter, categoryAttributePairID, new_AttributeValueParameter, new_DisplayOrderParameter, new_IsAssignedParameter);
        }

        public virtual int CategoryAttributePair_Update(CategoryAttributePair categoryAttributePair)
        {
            var original_CategoryAttributePairIDParameter = categoryAttributePair.CategoryAttributePairID > -1 ?
                new ObjectParameter("Original_CategoryAttributePairID", categoryAttributePair.CategoryAttributePairID) :
                new ObjectParameter("Original_CategoryAttributePairID", typeof(long));

            var new_CategoryIDParameter = categoryAttributePair.CategoryID > -1 ?
                new ObjectParameter("New_CategoryID", categoryAttributePair.CategoryID) :
                new ObjectParameter("New_CategoryID", typeof(long));

            var new_AttributeIDParameter = categoryAttributePair.AttributeID > -1 ?
                new ObjectParameter("New_AttributeID", categoryAttributePair.AttributeID) :
                new ObjectParameter("New_AttributeID", typeof(long));

            var new_AttributeValueParameter = categoryAttributePair.AttributeValue != null ?
                new ObjectParameter("New_AttributeValue", categoryAttributePair.AttributeValue) :
                new ObjectParameter("New_AttributeValue", typeof(string));

            var new_DisplayOrderParameter = categoryAttributePair.DisplayOrder.HasValue ?
                new ObjectParameter("New_DisplayOrder", categoryAttributePair.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", categoryAttributePair.IsAssigned);

            return ObjectContext.ExecuteFunction("CategoryAttributePair_Update", original_CategoryAttributePairIDParameter, new_CategoryIDParameter, new_AttributeIDParameter, new_AttributeValueParameter, new_DisplayOrderParameter, new_IsAssignedParameter);
        }

        public virtual int CategoryType_Insert(CategoryType categoryType, ObjectParameter categoryTypeID)
        {
            var new_TitleParameter = categoryType.Title != null ?
                new ObjectParameter("New_Title", categoryType.Title) :
                new ObjectParameter("New_Title", typeof(string));

            var new_DescriptionParameter = categoryType.Description != null ?
                new ObjectParameter("New_Description", categoryType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = categoryType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", categoryType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", categoryType.IsSystem);

            return ObjectContext.ExecuteFunction("CategoryType_Insert", new_TitleParameter, new_DescriptionParameter, new_StatusIDParameter, categoryTypeID, new_IsSystemParameter);
        }

        public virtual int CategoryType_Update(CategoryType categoryType)
        {
            var original_CategoryTypeIDParameter = categoryType.CategoryTypeID > -1 ?
                new ObjectParameter("Original_CategoryTypeID", categoryType.CategoryTypeID) :
                new ObjectParameter("Original_CategoryTypeID", typeof(long));

            var new_TitleParameter = categoryType.Title != null ?
                new ObjectParameter("New_Title", categoryType.Title) :
                new ObjectParameter("New_Title", typeof(string));

            var new_DescriptionParameter = categoryType.Description != null ?
                new ObjectParameter("New_Description", categoryType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = categoryType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", categoryType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", categoryType.IsSystem);

            return ObjectContext.ExecuteFunction("CategoryType_Update", original_CategoryTypeIDParameter, new_TitleParameter, new_DescriptionParameter, new_StatusIDParameter, new_IsSystemParameter);
        }

        public virtual int DataType_Insert(DataType dataType, ObjectParameter dataTypeID)
        {
            var new_AssemblyNameParameter = dataType.AssemblyName != null ?
                new ObjectParameter("New_AssemblyName", dataType.AssemblyName) :
                new ObjectParameter("New_AssemblyName", typeof(string));

            var new_NamespaceParameter = dataType.Namespace != null ?
                new ObjectParameter("New_Namespace", dataType.Namespace) :
                new ObjectParameter("New_Namespace", typeof(string));

            var new_ClassNameParameter = dataType.ClassName != null ?
                new ObjectParameter("New_ClassName", dataType.ClassName) :
                new ObjectParameter("New_ClassName", typeof(string));

            var new_FriendlyNameParameter = dataType.FriendlyName != null ?
                new ObjectParameter("New_FriendlyName", dataType.FriendlyName) :
                new ObjectParameter("New_FriendlyName", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", dataType.IsSystem);

            var new_SuggestedUIControlParameter = dataType.SuggestedUIControl != null ?
                new ObjectParameter("New_SuggestedUIControl", dataType.SuggestedUIControl) :
                new ObjectParameter("New_SuggestedUIControl", typeof(string));

            return ObjectContext.ExecuteFunction("DataType_Insert", new_AssemblyNameParameter, new_NamespaceParameter, new_ClassNameParameter, new_FriendlyNameParameter, dataTypeID, new_IsSystemParameter, new_SuggestedUIControlParameter);
        }

        public virtual int DataType_Update(DataType dataType)
        {
            var original_DataTypeIDParameter = dataType.DataTypeID > -1 ?
                new ObjectParameter("Original_DataTypeID", dataType.DataTypeID) :
                new ObjectParameter("Original_DataTypeID", typeof(long));

            var new_AssemblyNameParameter = dataType.AssemblyName != null ?
                new ObjectParameter("New_AssemblyName", dataType.AssemblyName) :
                new ObjectParameter("New_AssemblyName", typeof(string));

            var new_NamespaceParameter = dataType.Namespace != null ?
                new ObjectParameter("New_Namespace", dataType.Namespace) :
                new ObjectParameter("New_Namespace", typeof(string));

            var new_ClassNameParameter = dataType.ClassName != null ?
                new ObjectParameter("New_ClassName", dataType.ClassName) :
                new ObjectParameter("New_ClassName", typeof(string));

            var new_FriendlyNameParameter = dataType.FriendlyName != null ?
                new ObjectParameter("New_FriendlyName", dataType.FriendlyName) :
                new ObjectParameter("New_FriendlyName", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", dataType.IsSystem);

            var new_SuggestedUIControlParameter = dataType.SuggestedUIControl != null ?
                new ObjectParameter("New_SuggestedUIControl", dataType.SuggestedUIControl) :
                new ObjectParameter("New_SuggestedUIControl", typeof(string));

            return ObjectContext.ExecuteFunction("DataType_Update", original_DataTypeIDParameter, new_AssemblyNameParameter, new_NamespaceParameter, new_ClassNameParameter, new_FriendlyNameParameter, new_IsSystemParameter, new_SuggestedUIControlParameter);
        }

        public virtual int DeliveryOption_Insert(DeliveryOption deliveryOption, ObjectParameter deliveryOptionID)
        {
            var new_DeliveryOptionTitleParameter = deliveryOption.DeliveryOptionTitle != null ?
                new ObjectParameter("New_DeliveryOptionTitle", deliveryOption.DeliveryOptionTitle) :
                new ObjectParameter("New_DeliveryOptionTitle", typeof(string));

            var new_DescriptionParameter = deliveryOption.Description != null ?
                new ObjectParameter("New_Description", deliveryOption.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("DeliveryOption_Insert", new_DeliveryOptionTitleParameter, new_DescriptionParameter, deliveryOptionID);
        }

        public virtual int DeliveryOption_Update(DeliveryOption deliveryOption)
        {
            var deliveryOption_DeliveryOptionIDParameter = deliveryOption.DeliveryOptionID > -1 ?
                new ObjectParameter("Original_DeliveryOptionID", deliveryOption.DeliveryOptionID) :
                new ObjectParameter("Original_DeliveryOptionID", typeof(long));

            var new_DeliveryOptionTitleParameter = deliveryOption.DeliveryOptionTitle != null ?
                new ObjectParameter("New_DeliveryOptionTitle", deliveryOption.DeliveryOptionTitle) :
                new ObjectParameter("New_DeliveryOptionTitle", typeof(string));

            var new_DescriptionParameter = deliveryOption.Description != null ?
                new ObjectParameter("New_Description", deliveryOption.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("DeliveryOption_Update", deliveryOption_DeliveryOptionIDParameter, new_DeliveryOptionTitleParameter, new_DescriptionParameter);
        }

        public virtual int ExecAction_Insert(ExecAction exacAction, ObjectParameter execActionID)
        {
            var new_DataTypeIDParameter = exacAction.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", exacAction.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            var new_MethodParameter = exacAction.Method != null ?
                new ObjectParameter("New_Method", exacAction.Method) :
                new ObjectParameter("New_Method", typeof(string));

            return ObjectContext.ExecuteFunction("ExecAction_Insert", new_DataTypeIDParameter, new_MethodParameter, execActionID);
        }

        public virtual int ExecAction_Update(ExecAction execAction)
        {
            var original_ExecActionIDParameter = execAction.ExecActionID > -1 ?
                new ObjectParameter("Original_ExecActionID", execAction.ExecActionID) :
                new ObjectParameter("Original_ExecActionID", typeof(long));

            var new_DataTypeIDParameter = execAction.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", execAction.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            var new_MethodParameter = execAction.Method != null ?
                new ObjectParameter("New_Method", execAction.Method) :
                new ObjectParameter("New_Method", typeof(string));

            return ObjectContext.ExecuteFunction("ExecAction_Update", original_ExecActionIDParameter, new_DataTypeIDParameter, new_MethodParameter);
        }

        public virtual int ExecActionParam_Insert(ExecActionParam exacActionParam, ObjectParameter execActionParamID)
        {
            var new_ExecActionIDParameter = exacActionParam.ExecActionID > -1 ?
                new ObjectParameter("New_ExecActionID", exacActionParam.ExecActionID) :
                new ObjectParameter("New_ExecActionID", typeof(long));

            var new_ParamNameParameter = exacActionParam.ParamName != null ?
                new ObjectParameter("New_ParamName", exacActionParam.ParamName) :
                new ObjectParameter("New_ParamName", typeof(string));

            var new_DataTypeIDParameter = exacActionParam.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", exacActionParam.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            return ObjectContext.ExecuteFunction("ExecActionParam_Insert", new_ExecActionIDParameter, new_ParamNameParameter, new_DataTypeIDParameter, execActionParamID);
        }

        public virtual int ExecActionParam_Update(ExecActionParam exacActionParam)
        {
            var original_ExecActionParamIDParameter = exacActionParam.ExecActionParamID > -1 ?
                new ObjectParameter("Original_ExecActionParamID", exacActionParam.ExecActionParamID) :
                new ObjectParameter("Original_ExecActionParamID", typeof(long));

            var new_ExecActionIDParameter = exacActionParam.ExecActionID > -1 ?
                new ObjectParameter("New_ExecActionID", exacActionParam.ExecActionID) :
                new ObjectParameter("New_ExecActionID", typeof(long));

            var new_ParamNameParameter = exacActionParam.ParamName != null ?
                new ObjectParameter("New_ParamName", exacActionParam.ParamName) :
                new ObjectParameter("New_ParamName", typeof(string));

            var new_DataTypeIDParameter = exacActionParam.DataTypeID > -1 ?
                new ObjectParameter("New_DataTypeID", exacActionParam.DataTypeID) :
                new ObjectParameter("New_DataTypeID", typeof(long));

            return ObjectContext.ExecuteFunction("ExecActionParam_Update", original_ExecActionParamIDParameter, new_ExecActionIDParameter, new_ParamNameParameter, new_DataTypeIDParameter);
        }

        public virtual int Group_Insert(Group group, ObjectParameter groupID)
        {
            var new_GroupTitleParameter = group.GroupTitle != null ?
                new ObjectParameter("New_GroupTitle", group.GroupTitle) :
                new ObjectParameter("New_GroupTitle", typeof(string));

            var new_DescriptionParameter = group.Description != null ?
                new ObjectParameter("New_Description", group.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = group.IconPath != null ?
                new ObjectParameter("New_IconPath", group.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_StatusIDParameter = group.StatusID > -1 ?
                new ObjectParameter("New_StatusID", group.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", group.IsSystem);


            return ObjectContext.ExecuteFunction("Group_Insert", new_GroupTitleParameter, new_DescriptionParameter, new_IconPathParameter, new_StatusIDParameter, new_IsSystemParameter, groupID);
        }

        public virtual int Group_Update(Group group)
        {
            var original_GroupIDParameter = group.GroupID > -1 ?
                new ObjectParameter("Original_GroupID", group.GroupID) :
                new ObjectParameter("Original_GroupID", typeof(long));

            var new_GroupTitleParameter = group.GroupTitle != null ?
                new ObjectParameter("New_GroupTitle", group.GroupTitle) :
                new ObjectParameter("New_GroupTitle", typeof(string));

            var new_DescriptionParameter = group.Description != null ?
                new ObjectParameter("New_Description", group.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = group.IconPath != null ?
                new ObjectParameter("New_IconPath", group.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_StatusIDParameter = group.StatusID > -1 ?
                new ObjectParameter("New_StatusID", group.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", group.IsSystem);



            return ObjectContext.ExecuteFunction("Group_Update", original_GroupIDParameter, new_GroupTitleParameter, new_DescriptionParameter, new_IconPathParameter, new_StatusIDParameter, new_IsSystemParameter);
        }

        public virtual int GroupRolePair_Insert(GroupRolePair groupRolePair, ObjectParameter groupRolePairID)
        {
            var new_GroupIDParameter = groupRolePair.GroupID > -1 ?
                new ObjectParameter("New_GroupID", groupRolePair.GroupID) :
                new ObjectParameter("New_GroupID", typeof(long));

            var new_RoleIDParameter = groupRolePair.RoleID > -1 ?
                new ObjectParameter("New_RoleID", groupRolePair.RoleID) :
                new ObjectParameter("New_RoleID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", groupRolePair.IsSystem);

            return ObjectContext.ExecuteFunction("GroupRolePair_Insert", new_GroupIDParameter, new_RoleIDParameter, new_IsSystemParameter, groupRolePairID);
        }

        public virtual int GroupRolePair_Update(GroupRolePair groupRolePair)
        {
            var original_GroupRolePairIDParameter = groupRolePair.GroupRolePairID > -1 ?
                new ObjectParameter("Original_GroupRolePairID", groupRolePair.GroupRolePairID) :
                new ObjectParameter("Original_GroupRolePairID", typeof(long));

            var new_GroupIDParameter = groupRolePair.GroupID > -1 ?
                new ObjectParameter("New_GroupID", groupRolePair.GroupID) :
                new ObjectParameter("New_GroupID", typeof(long));

            var new_RoleIDParameter = groupRolePair.RoleID > -1 ?
                new ObjectParameter("New_RoleID", groupRolePair.RoleID) :
                new ObjectParameter("New_RoleID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", groupRolePair.IsSystem);

            return ObjectContext.ExecuteFunction("GroupRolePair_Update", original_GroupRolePairIDParameter, new_GroupIDParameter, new_RoleIDParameter, new_IsSystemParameter);
        }

        public virtual int LocationLevel_Insert(LocationLevel locationLevel, ObjectParameter locationLevelID)
        {
            var new_LocationLevelTitleParameter = locationLevel.LocationLevelTitle != null ?
                new ObjectParameter("New_LocationLevelTitle", locationLevel.LocationLevelTitle) :
                new ObjectParameter("New_LocationLevelTitle", typeof(string));

            var new_DescriptionParameter = locationLevel.Description != null ?
                new ObjectParameter("New_Description", locationLevel.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("LocationLevel_Insert", new_LocationLevelTitleParameter, new_DescriptionParameter, locationLevelID);
        }

        public virtual int LocationLevel_Update(LocationLevel locationLevel)
        {
            var original_LocationLevelIDParameter = locationLevel.LocationLevelID > -1 ?
                new ObjectParameter("Original_LocationLevelID", locationLevel.LocationLevelID) :
                new ObjectParameter("Original_LocationLevelID", typeof(long));

            var new_LocationLevelTitleParameter = locationLevel.LocationLevelTitle != null ?
                new ObjectParameter("New_LocationLevelTitle", locationLevel.LocationLevelTitle) :
                new ObjectParameter("New_LocationLevelTitle", typeof(string));

            var new_DescriptionParameter = locationLevel.Description != null ?
                new ObjectParameter("New_Description", locationLevel.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("LocationLevel_Update", original_LocationLevelIDParameter, new_LocationLevelTitleParameter, new_DescriptionParameter);
        }

        public virtual int LocationTree_Insert(LocationTree locationTree, ObjectParameter locationID)
        {
            var new_LocationTitleParameter = locationTree.LocationTitle != null ?
                new ObjectParameter("New_LocationTitle", locationTree.LocationTitle) :
                new ObjectParameter("New_LocationTitle", typeof(string));

            var new_ParentLocationIDParameter = locationTree.ParentLocationID > -1 ?
                new ObjectParameter("New_ParentLocationID", locationTree.ParentLocationID) :
                new ObjectParameter("New_ParentLocationID", typeof(long));

            var new_LocationLevelIDParameter = locationTree.LocationLevelID > -1 ?
                new ObjectParameter("New_LocationLevelID", locationTree.LocationLevelID) :
                new ObjectParameter("New_LocationLevelID", typeof(long));

            var new_DescriptionParameter = locationTree.Description != null ?
                new ObjectParameter("New_Description", locationTree.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("LocationTree_Insert", new_LocationTitleParameter, new_ParentLocationIDParameter, new_LocationLevelIDParameter, new_DescriptionParameter, locationID);
        }

        public virtual int LocationTree_Update(LocationTree locationTree)
        {
            var original_LocationIDParameter = locationTree.LocationID > -1 ?
                new ObjectParameter("Original_LocationID", locationTree.LocationID) :
                new ObjectParameter("Original_LocationID", typeof(long));

            var new_LocationTitleParameter = locationTree.LocationTitle != null ?
                new ObjectParameter("New_LocationTitle", locationTree.LocationTitle) :
                new ObjectParameter("New_LocationTitle", typeof(string));

            var new_ParentLocationIDParameter = locationTree.ParentLocationID > -1 ?
                new ObjectParameter("New_ParentLocationID", locationTree.ParentLocationID) :
                new ObjectParameter("New_ParentLocationID", typeof(long));

            var new_LocationLevelIDParameter = locationTree.LocationLevelID > -1 ?
                new ObjectParameter("New_LocationLevelID", locationTree.LocationLevelID) :
                new ObjectParameter("New_LocationLevelID", typeof(long));

            var new_DescriptionParameter = locationTree.Description != null ?
                new ObjectParameter("New_Description", locationTree.Description) :
                new ObjectParameter("New_Description", typeof(string));

            return ObjectContext.ExecuteFunction("LocationTree_Update", original_LocationIDParameter, new_LocationTitleParameter, new_ParentLocationIDParameter, new_LocationLevelIDParameter, new_DescriptionParameter);
        }

        public virtual int MediaContentType_Insert(MediaContentType mediaContentType, ObjectParameter mediaContentTypeID)
        {
            var new_DisplayTextParameter = mediaContentType.DisplayText != null ?
                new ObjectParameter("New_DisplayText", mediaContentType.DisplayText) :
                new ObjectParameter("New_DisplayText", typeof(string));

            var new_HTMLContentTypeTextParameter = mediaContentType.HTMLContentTypeText != null ?
                new ObjectParameter("New_HTMLContentTypeText", mediaContentType.HTMLContentTypeText) :
                new ObjectParameter("New_HTMLContentTypeText", typeof(string));

            var new_DescriptionParameter = mediaContentType.Description != null ?
                new ObjectParameter("New_Description", mediaContentType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = mediaContentType.IconPath != null ?
                new ObjectParameter("New_IconPath", mediaContentType.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", mediaContentType.IsSystem);

            return ObjectContext.ExecuteFunction("MediaContentType_Insert", new_DisplayTextParameter, new_HTMLContentTypeTextParameter, new_DescriptionParameter, new_IconPathParameter, mediaContentTypeID, new_IsSystemParameter);
        }

        public virtual int MediaContentType_Update(MediaContentType mediaContentType)
        {
            var original_MediaContentTypeIDParameter = mediaContentType.MediaContentTypeID > -1 ?
                new ObjectParameter("Original_MediaContentTypeID", mediaContentType.MediaContentTypeID) :
                new ObjectParameter("Original_MediaContentTypeID", typeof(long));

            var new_DisplayTextParameter = mediaContentType.DisplayText != null ?
                new ObjectParameter("New_DisplayText", mediaContentType.DisplayText) :
                new ObjectParameter("New_DisplayText", typeof(string));

            var new_HTMLContentTypeTextParameter = mediaContentType.HTMLContentTypeText != null ?
                new ObjectParameter("New_HTMLContentTypeText", mediaContentType.HTMLContentTypeText) :
                new ObjectParameter("New_HTMLContentTypeText", typeof(string));

            var new_DescriptionParameter = mediaContentType.Description != null ?
                new ObjectParameter("New_Description", mediaContentType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = mediaContentType.IconPath != null ?
                new ObjectParameter("New_IconPath", mediaContentType.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", mediaContentType.IsSystem);

            return ObjectContext.ExecuteFunction("MediaContentType_Update", original_MediaContentTypeIDParameter, new_DisplayTextParameter, new_HTMLContentTypeTextParameter, new_DescriptionParameter, new_IconPathParameter, new_IsSystemParameter);
        }

        public virtual int Option_Insert(Option option, ObjectParameter optionID)
        {
            var new_OptionTitleParameter = option.OptionTitle != null ?
                new ObjectParameter("New_OptionTitle", option.OptionTitle) :
                new ObjectParameter("New_OptionTitle", typeof(string));

            var new_MenuTitleParameter = option.MenuTitle != null ?
                new ObjectParameter("New_MenuTitle", option.MenuTitle) :
                new ObjectParameter("New_MenuTitle", typeof(string));

            var new_ItemTitleParameter = option.ItemTitle != null ?
                new ObjectParameter("New_ItemTitle", option.ItemTitle) :
                new ObjectParameter("New_ItemTitle", typeof(string));

            var new_PageURLParameter = option.PageURL != null ?
                new ObjectParameter("New_PageURL", option.PageURL) :
                new ObjectParameter("New_PageURL", typeof(string));

            var new_NextPageURLParameter = option.NextPageURL != null ?
                new ObjectParameter("New_NextPageURL", option.NextPageURL) :
                new ObjectParameter("New_NextPageURL", typeof(string));

            var new_ModuleIDParameter = option.ModuleID > -1 ?
                new ObjectParameter("New_ModuleID", option.ModuleID) :
                new ObjectParameter("New_ModuleID", typeof(long));

            var new_OptionTypeIDParameter = option.OptionTypeID > -1 ?
                new ObjectParameter("New_OptionTypeID", option.OptionTypeID) :
                new ObjectParameter("New_OptionTypeID", typeof(long));

            var new_ParentOptionIDParameter = option.ParentOptionID > -1 ?
                new ObjectParameter("New_ParentOptionID", option.ParentOptionID) :
                new ObjectParameter("New_ParentOptionID", typeof(long));

            var new_DisplayOrderParameter = new ObjectParameter("New_DisplayOrder", option.DisplayOrder);

            var new_ExecActionIDParameter = option.ExecActionID > -1 ?
                new ObjectParameter("New_ExecActionID", option.ExecActionID) :
                new ObjectParameter("New_ExecActionID", typeof(long));

            var new_StatusIDParameter = option.StatusID > -1 ?
                new ObjectParameter("New_StatusID", option.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = option.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", option.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("Option_Insert", new_OptionTitleParameter, new_MenuTitleParameter, new_ItemTitleParameter, new_PageURLParameter, new_NextPageURLParameter, new_ModuleIDParameter, new_OptionTypeIDParameter, new_ParentOptionIDParameter, new_DisplayOrderParameter, new_ExecActionIDParameter, new_StatusIDParameter, SpProfileIDParameter, optionID);
        }

        public virtual int Option_Update(Option option)
        {
            var original_OptionIDParameter = option.OptionID > -1 ?
                new ObjectParameter("Original_OptionID", option.OptionID) :
                new ObjectParameter("Original_OptionID", typeof(long));

            var new_OptionTitleParameter = option.OptionTitle != null ?
                new ObjectParameter("New_OptionTitle", option.OptionTitle) :
                new ObjectParameter("New_OptionTitle", typeof(string));

            var new_MenuTitleParameter = option.MenuTitle != null ?
                new ObjectParameter("New_MenuTitle", option.MenuTitle) :
                new ObjectParameter("New_MenuTitle", typeof(string));

            var new_ItemTitleParameter = option.ItemTitle != null ?
                new ObjectParameter("New_ItemTitle", option.ItemTitle) :
                new ObjectParameter("New_ItemTitle", typeof(string));

            var new_PageURLParameter = option.PageURL != null ?
                new ObjectParameter("New_PageURL", option.PageURL) :
                new ObjectParameter("New_PageURL", typeof(string));

            var new_NextPageURLParameter = option.NextPageURL != null ?
                new ObjectParameter("New_NextPageURL", option.NextPageURL) :
                new ObjectParameter("New_NextPageURL", typeof(string));

            var new_ModuleIDParameter = option.ModuleID > -1 ?
                new ObjectParameter("New_ModuleID", option.ModuleID) :
                new ObjectParameter("New_ModuleID", typeof(long));

            var new_OptionTypeIDParameter = option.OptionTypeID > -1 ?
                new ObjectParameter("New_OptionTypeID", option.OptionTypeID) :
                new ObjectParameter("New_OptionTypeID", typeof(long));

            var new_ParentOptionIDParameter = option.ParentOptionID > -1 ?
                new ObjectParameter("New_ParentOptionID", option.ParentOptionID) :
                new ObjectParameter("New_ParentOptionID", typeof(long));

            var new_DisplayOrderParameter = new ObjectParameter("New_DisplayOrder", option.DisplayOrder);

            var new_ExecActionIDParameter = option.ExecActionID > -1 ?
                new ObjectParameter("New_ExecActionID", option.ExecActionID) :
                new ObjectParameter("New_ExecActionID", typeof(long));

            var new_StatusIDParameter = option.StatusID > -1 ?
                new ObjectParameter("New_StatusID", option.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = option.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", option.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = option.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", option.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("Option_Update", original_OptionIDParameter, new_OptionTitleParameter, new_MenuTitleParameter, new_ItemTitleParameter, new_PageURLParameter, new_NextPageURLParameter, new_ModuleIDParameter, new_OptionTypeIDParameter, new_ParentOptionIDParameter, new_DisplayOrderParameter, new_ExecActionIDParameter, new_StatusIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int OptionType_Insert(OptionType optionType, ObjectParameter optionTypeID)
        {
            var new_OptionTypeTitleParameter = optionType.OptionTypeTitle != null ?
                new ObjectParameter("New_OptionTypeTitle", optionType.OptionTypeTitle) :
                new ObjectParameter("New_OptionTypeTitle", typeof(string));

            var new_DescriptionParameter = optionType.Description != null ?
                new ObjectParameter("New_Description", optionType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_OptionLevelParameter = optionType.OptionLevel > -1 ?
                new ObjectParameter("New_OptionLevel", optionType.OptionLevel) :
                new ObjectParameter("New_OptionLevel", typeof(int));

            return ObjectContext.ExecuteFunction("OptionType_Insert", new_OptionTypeTitleParameter, new_DescriptionParameter, new_OptionLevelParameter, optionTypeID);
        }

        public virtual int OptionType_Update(OptionType optionType)
        {
            var original_OptionTypeIDParameter = optionType.OptionTypeID > -1 ?
                new ObjectParameter("Original_OptionTypeID", optionType.OptionTypeID) :
                new ObjectParameter("Original_OptionTypeID", typeof(long));

            var new_OptionTypeTitleParameter = optionType.OptionTypeTitle != null ?
                new ObjectParameter("New_OptionTypeTitle", optionType.OptionTypeTitle) :
                new ObjectParameter("New_OptionTypeTitle", typeof(string));

            var new_DescriptionParameter = optionType.Description != null ?
                new ObjectParameter("New_Description", optionType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_OptionLevelParameter = optionType.OptionLevel > -1 ?
                new ObjectParameter("New_OptionLevel", optionType.OptionLevel) :
                new ObjectParameter("New_OptionLevel", typeof(int));

            return ObjectContext.ExecuteFunction("OptionType_Update", original_OptionTypeIDParameter, new_OptionTypeTitleParameter, new_DescriptionParameter, new_OptionLevelParameter);
        }

        public virtual int OrderDeliveryDetail_Insert(OrderDeliveryDetail orderDeliveryDetail, ObjectParameter orderDeliveryDetailID)
        {
            var new_CartOrderIDParameter = orderDeliveryDetail.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", orderDeliveryDetail.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            //var new_DeliveryProductIDParameter = orderDeliveryDetail.DeliveryProductID > -1 ?
            //    new ObjectParameter("New_DeliveryProductID", orderDeliveryDetail.DeliveryProductID) :
            //    new ObjectParameter("New_DeliveryProductID", typeof(long));

            var new_AddressIDParameter = orderDeliveryDetail.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", orderDeliveryDetail.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            //var new_DeliverAtUserLocationParameter = new ObjectParameter("New_DeliverAtUserLocation", orderDeliveryDetail.DeliverAtUserLocation);

            //var new_EmailParameter = orderDeliveryDetail.Email != null ?
            //    new ObjectParameter("New_Email", orderDeliveryDetail.Email) :
            //    new ObjectParameter("New_Email", typeof(string));

            return ObjectContext.ExecuteFunction("OrderDeliveryDetail_Insert", new_CartOrderIDParameter, /*new_DeliveryProductIDParameter, */new_AddressIDParameter, orderDeliveryDetailID);
        }

        public virtual int OrderDeliveryDetail_Update(OrderDeliveryDetail orderDeliveryDetail)
        {
            var original_OrderDeliveryDetailIDParameter = orderDeliveryDetail.OrderDeliveryDetailID > -1 ?
                new ObjectParameter("Original_OrderDeliveryDetailID", orderDeliveryDetail.OrderDeliveryDetailID) :
                new ObjectParameter("Original_OrderDeliveryDetailID", typeof(long));

            var new_CartOrderIDParameter = orderDeliveryDetail.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", orderDeliveryDetail.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            //var new_DeliveryProductIDParameter = orderDeliveryDetail.DeliveryProductID > -1 ?
            //    new ObjectParameter("New_DeliveryProductID", orderDeliveryDetail.DeliveryProductID) :
            //    new ObjectParameter("New_DeliveryProductID", typeof(long));

            var new_AddressIDParameter = orderDeliveryDetail.DeliveryAddressID > -1 ?
                new ObjectParameter("New_DeliveryAddressID", orderDeliveryDetail.DeliveryAddressID) :
                new ObjectParameter("New_DeliveryAddressID", typeof(long));

            return ObjectContext.ExecuteFunction("OrderDeliveryDetail_Update", original_OrderDeliveryDetailIDParameter, new_CartOrderIDParameter, new_AddressIDParameter/*, new_DeliveryProductIDParameter*/);
        }

        public virtual int OrderPayment_Insert(OrderPayment orderPayment, ObjectParameter OrderPaymentID)
        {
            var new_CartOrderIDParameter = orderPayment.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", orderPayment.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            var new_PaymentIDParameter = orderPayment.PaymentID > -1 ?
                new ObjectParameter("New_PaymentID", orderPayment.PaymentID) :
                new ObjectParameter("New_PaymentID", typeof(long));

            var new_AmountParameter = orderPayment.Amount > -1 ?
                new ObjectParameter("New_Amount", orderPayment.Amount) :
                new ObjectParameter("New_Amount", typeof(long));

            var new_BillingAddressParameter = orderPayment.BillingAddressID > -1 ?
                new ObjectParameter("New_BillingAddressID", orderPayment.BillingAddressID) :
                new ObjectParameter("New_BillingAddressID", typeof(double));

            return ObjectContext.ExecuteFunction("OrderPayment_Insert", new_CartOrderIDParameter, new_PaymentIDParameter, new_AmountParameter, new_BillingAddressParameter, OrderPaymentID);
        }

        public virtual int OrderPayment_Update(OrderPayment orderPayment)
        {
            var original_PaymentIDParameter = orderPayment.OrderPaymentID > -1 ?
                new ObjectParameter("Original_OrderPaymentID", orderPayment.OrderPaymentID) :
                new ObjectParameter("Original_OrderPaymentID", typeof(long));

            var new_CartOrderIDParameter = orderPayment.CartOrderID > -1 ?
                new ObjectParameter("New_CartOrderID", orderPayment.CartOrderID) :
                new ObjectParameter("New_CartOrderID", typeof(long));

            var new_PaymentIDParameter = orderPayment.PaymentID > -1 ?
                           new ObjectParameter("New_PaymentID", orderPayment.PaymentID) :
                           new ObjectParameter("New_PaymentID", typeof(long));

            var new_AmountParameter = orderPayment.Amount > -1 ?
                new ObjectParameter("New_Amount", orderPayment.Amount) :
                new ObjectParameter("New_Amount", typeof(long));

            var new_BillingAddressParameter = orderPayment.BillingAddressID > -1 ?
                new ObjectParameter("New_BillingAddressID", orderPayment.BillingAddressID) :
                new ObjectParameter("New_BillingAddressID", typeof(double));

            return ObjectContext.ExecuteFunction("OrderPayment_Update", original_PaymentIDParameter, new_CartOrderIDParameter, new_PaymentIDParameter, new_AmountParameter, new_BillingAddressParameter);
        }

        public virtual int OrderStatus_Insert(OrderStatus orderStatus, ObjectParameter orderStatusID)
        {
            var new_OrderStatusTitleParameter = orderStatus.OrderStatusTitle != null ?
                new ObjectParameter("New_OrderStatusTitle", orderStatus.OrderStatusTitle) :
                new ObjectParameter("New_OrderStatusTitle", typeof(string));

            var new_DescriptionParameter = orderStatus.Description != null ?
                new ObjectParameter("New_Description", orderStatus.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", orderStatus.IsSystem);

            var new_IsOrderParameter = new ObjectParameter("New_IsOrder", orderStatus.IsOrder);


            return ObjectContext.ExecuteFunction("OrderStatus_Insert", new_OrderStatusTitleParameter, new_DescriptionParameter, orderStatusID, new_IsSystemParameter, new_IsOrderParameter);
        }

        public virtual int OrderStatus_Update(OrderStatus orderStatus)
        {
            var original_OrderStatusIDParameter = orderStatus.OrderStatusID > -1 ?
                new ObjectParameter("Original_OrderStatusID", orderStatus.OrderStatusID) :
                new ObjectParameter("Original_OrderStatusID", typeof(long));

            var new_OrderStatusTitleParameter = orderStatus.OrderStatusTitle != null ?
                new ObjectParameter("New_OrderStatusTitle", orderStatus.OrderStatusTitle) :
                new ObjectParameter("New_OrderStatusTitle", typeof(string));

            var new_DescriptionParameter = orderStatus.Description != null ?
                new ObjectParameter("New_Description", orderStatus.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", orderStatus.IsSystem);

            var new_IsOrderParameter = new ObjectParameter("New_IsOrder", orderStatus.IsOrder);

            return ObjectContext.ExecuteFunction("OrderStatus_Update", original_OrderStatusIDParameter, new_OrderStatusTitleParameter, new_DescriptionParameter, new_IsSystemParameter, new_IsOrderParameter);
        }

        public virtual int PackagedProduct_Insert(PackagedProduct packagedProduct, ObjectParameter packageID)
        {
            var new_ProductIDParameter = packagedProduct.ProductID > -1 ?
                new ObjectParameter("New_ProductID", packagedProduct.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_ChildProductIDParameter = packagedProduct.ChildProductID > -1 ?
                new ObjectParameter("New_ChildProductID", packagedProduct.ChildProductID) :
                new ObjectParameter("New_ChildProductID", typeof(long));

            var new_QuantityParameter = packagedProduct.Quantity > -1 ?
                new ObjectParameter("New_Quantity", packagedProduct.Quantity) :
                new ObjectParameter("New_Quantity", typeof(int));

            var new_IncludedByDefaultParameter = new ObjectParameter("New_IncludedByDefault", packagedProduct.IncludedByDefault);

            var new_PercentagePriceParameter = packagedProduct.PercentagePrice > -1 ?
                new ObjectParameter("New_PercentagePrice", packagedProduct.PercentagePrice) :
                new ObjectParameter("New_PercentagePrice", typeof(double));

            var new_OtherDetailsParameter = packagedProduct.OtherDetails != null ?
                new ObjectParameter("New_OtherDetails", packagedProduct.OtherDetails) :
                new ObjectParameter("New_OtherDetails", typeof(string));

            return ObjectContext.ExecuteFunction("PackagedProduct_Insert", new_ProductIDParameter, new_ChildProductIDParameter, new_QuantityParameter, new_IncludedByDefaultParameter, new_PercentagePriceParameter, new_OtherDetailsParameter, packageID);
        }

        public virtual int PackagedProduct_Update(PackagedProduct packagedProduct)
        {
            var original_PackageIDParameter = packagedProduct.PackageID > -1 ?
                new ObjectParameter("Original_PackageID", packagedProduct.PackageID) :
                new ObjectParameter("Original_PackageID", typeof(long));

            var new_ProductIDParameter = packagedProduct.ProductID > -1 ?
                new ObjectParameter("New_ProductID", packagedProduct.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_ChildProductIDParameter = packagedProduct.ChildProductID > -1 ?
                new ObjectParameter("New_ChildProductID", packagedProduct.ChildProductID) :
                new ObjectParameter("New_ChildProductID", typeof(long));

            var new_QuantityParameter = packagedProduct.Quantity > -1 ?
                new ObjectParameter("New_Quantity", packagedProduct.Quantity) :
                new ObjectParameter("New_Quantity", typeof(int));

            var new_IncludedByDefaultParameter = new ObjectParameter("New_IncludedByDefault", packagedProduct.IncludedByDefault);

            var new_PercentagePriceParameter = packagedProduct.PercentagePrice > -1 ?
                new ObjectParameter("New_PercentagePrice", packagedProduct.PercentagePrice) :
                new ObjectParameter("New_PercentagePrice", typeof(double));

            var new_OtherDetailsParameter = packagedProduct.OtherDetails != null ?
                new ObjectParameter("New_OtherDetails", packagedProduct.OtherDetails) :
                new ObjectParameter("New_OtherDetails", typeof(string));

            return ObjectContext.ExecuteFunction("PackagedProduct_Update", original_PackageIDParameter, new_ProductIDParameter, new_ChildProductIDParameter, new_QuantityParameter, new_IncludedByDefaultParameter, new_PercentagePriceParameter, new_OtherDetailsParameter);
        }

        public virtual int PayMode_Insert(PayMode payMode, ObjectParameter payModeID)
        {
            var new_PayModeTitleParameter = payMode.PayModeTitle != null ?
                new ObjectParameter("New_PayModeTitle", payMode.PayModeTitle) :
                new ObjectParameter("New_PayModeTitle", typeof(string));

            var new_DescriptionParameter = payMode.Description != null ?
                new ObjectParameter("New_Description", payMode.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payMode.IsSystem);

            return ObjectContext.ExecuteFunction("PayMode_Insert", new_PayModeTitleParameter, new_DescriptionParameter, payModeID, new_IsSystemParameter);
        }

        public virtual int PayMode_Update(PayMode payMode)
        {
            var original_PayModeIDParameter = payMode.PayModeID > -1 ?
                new ObjectParameter("Original_PayModeID", payMode.PayModeID) :
                new ObjectParameter("Original_PayModeID", typeof(long));

            var new_PayModeTitleParameter = payMode.PayModeTitle != null ?
                new ObjectParameter("New_PayModeTitle", payMode.PayModeTitle) :
                new ObjectParameter("New_PayModeTitle", typeof(string));

            var new_DescriptionParameter = payMode.Description != null ?
                new ObjectParameter("New_Description", payMode.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payMode.IsSystem);

            return ObjectContext.ExecuteFunction("PayMode_Update", original_PayModeIDParameter, new_PayModeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int PayType_Insert(PayType payType, ObjectParameter payTypeID)
        {
            var new_PayTypeTitleParameter = payType.PayTypeTitle != null ?
                new ObjectParameter("New_PayTypeTitle", payType.PayTypeTitle) :
                new ObjectParameter("New_PayTypeTitle", typeof(string));

            var new_DescriptionParameter = payType.Description != null ?
                new ObjectParameter("New_Description", payType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = payType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", payType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payType.IsSystem);

            return ObjectContext.ExecuteFunction("PayType_Insert", new_PayTypeTitleParameter, new_DescriptionParameter, new_StatusIDParameter, payTypeID, new_IsSystemParameter);
        }

        public virtual int PayType_Update(PayType payType)
        {
            var original_PayTypeIDParameter = payType.PayTypeID > -1 ?
                new ObjectParameter("Original_PayTypeID", payType.PayTypeID) :
                new ObjectParameter("Original_PayTypeID", typeof(long));

            var new_PayTypeTitleParameter = payType.PayTypeTitle != null ?
                new ObjectParameter("New_PayTypeTitle", payType.PayTypeTitle) :
                new ObjectParameter("New_PayTypeTitle", typeof(string));

            var new_DescriptionParameter = payType.Description != null ?
                new ObjectParameter("New_Description", payType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = payType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", payType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payType.IsSystem);

            return ObjectContext.ExecuteFunction("PayType_Update", original_PayTypeIDParameter, new_PayTypeTitleParameter, new_DescriptionParameter, new_StatusIDParameter, new_IsSystemParameter);
        }

        #region Product SPs

        public virtual int Product_Insert(Product product, ObjectParameter productID)
        {
            var new_ProductTitleParameter = product.ProductTitle != null ?
                new ObjectParameter("New_ProductTitle", product.ProductTitle) :
                new ObjectParameter("New_ProductTitle", typeof(string));

            var new_BrifeDescriptionParameter = product.BrifeDescription != null ?
                new ObjectParameter("New_BrifeDescription", product.BrifeDescription) :
                new ObjectParameter("New_BrifeDescription", typeof(string));

            var new_ProductActualImagePathParameter = product.ProductActualImagePath != null ?
                new ObjectParameter("New_ProductActualImagePath", product.ProductActualImagePath) :
                new ObjectParameter("New_ProductActualImagePath", typeof(string));

            var new_ProductImagePathParameter = product.ProductImagePath != null ?
                new ObjectParameter("New_ProductImagePath", product.ProductImagePath) :
                new ObjectParameter("New_ProductImagePath", typeof(string));

            var new_StockCountParameter = new ObjectParameter("New_StockCount", product.StockCount);

            var new_WebLinkParameter = product.WebLink != null ?
                new ObjectParameter("New_WebLink", product.WebLink) :
                new ObjectParameter("New_WebLink", typeof(string));

            var new_BasePriceParameter = new ObjectParameter("New_BasePrice", product.BasePrice);

            var new_SellingPriceParameter = new ObjectParameter("New_SellingPrice", product.SellingPrice);

            var new_OrderResponseTimeParameter = new ObjectParameter("New_OrderResponseTime", product.OrderResponseTime);

            var new_OrderResponseTimeUintIDParameter = ! string.IsNullOrEmpty(product.OrderResponseTimeUnitID)?
                new ObjectParameter("New_OrderResponseTimeUintID", product.OrderResponseTimeUnitID) :
                new ObjectParameter("New_OrderResponseTimeUintID", typeof(string));

            var new_DiscountValueParameter = product.DiscountValue.HasValue ?
                new ObjectParameter("New_DiscountValue", product.DiscountValue) :
                new ObjectParameter("New_DiscountValue", typeof(float));

            var new_IsDiscountPercentageParameter = product.IsDiscountPercentage.HasValue ?
                new ObjectParameter("New_IsDiscountPercentage", product.IsDiscountPercentage.Value ) :
                new ObjectParameter("New_IsDiscountPercentage", typeof(bool));

            var new_TaxTypeIDParameter = product.TaxTypeID > -1 ?
                new ObjectParameter("New_TaxTypeID", product.TaxTypeID) :
                new ObjectParameter("New_TaxTypeID", typeof(long));

            var new_UserRatingParameter = product.UserRating.HasValue ?
                new ObjectParameter("New_UserRating", product.UserRating.Value) :
                new ObjectParameter("New_UserRating", typeof(int)) ;

            var new_AnalysisRankParameter = product.AnalysisRank.HasValue ? 
                new ObjectParameter("New_AnalysisRank", product.AnalysisRank) :
                new ObjectParameter("New_AnalysisRank", typeof(int));

            var new_DescriptionParameter = ! string.IsNullOrEmpty(product.Description) ?
                new ObjectParameter("New_Description", product.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_ProductTypeIDParameter = product.ProductTypeID > -1 ?
                new ObjectParameter("New_ProductTypeID", product.ProductTypeID) :
                new ObjectParameter("New_ProductTypeID", typeof(long));

            var new_BrandIDParameter = product.BrandID > -1 ?
                new ObjectParameter("New_BrandID", product.BrandID) :
                new ObjectParameter("New_BrandID", typeof(long));

            var new_SupplierIDParameter = product.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", product.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_StatusIDParameter = product.StatusID > -1 ?
                new ObjectParameter("New_StatusID", product.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));


            return ObjectContext.ExecuteFunction(
                "Product_Insert", 
                new_ProductTitleParameter, 
                new_BrifeDescriptionParameter, 
                new_ProductActualImagePathParameter, 
                new_ProductImagePathParameter, 
                new_StockCountParameter, 
                new_WebLinkParameter, 
                new_BasePriceParameter, 
                new_SellingPriceParameter,
                new_DiscountValueParameter,
                new_IsDiscountPercentageParameter,
                new_OrderResponseTimeParameter, 
                new_OrderResponseTimeUintIDParameter, 
                new_TaxTypeIDParameter, 
                new_UserRatingParameter, 
                new_AnalysisRankParameter, 
                new_DescriptionParameter, 
                new_ProductTypeIDParameter, 
                new_BrandIDParameter, 
                new_SupplierIDParameter, 
                new_StatusIDParameter, 
                SpProfileIDParameter, 
                productID);
        }

        public virtual int Product_InsertBasicInfo(Product product, ObjectParameter productID)
        {
            var new_ProductTitleParameter = product.ProductTitle != null ?
                new ObjectParameter("New_ProductTitle", product.ProductTitle) :
                new ObjectParameter("New_ProductTitle", typeof(string));

            var new_BrifeDescriptionParameter = product.BrifeDescription != null ?
                new ObjectParameter("New_BrifeDescription", product.BrifeDescription) :
                new ObjectParameter("New_BrifeDescription", typeof(string));

            var new_DescriptionParameter = !string.IsNullOrEmpty(product.Description) ?
                new ObjectParameter("New_Description", product.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_ProductTypeIDParameter = product.ProductTypeID > -1 ?
                new ObjectParameter("New_ProductTypeID", product.ProductTypeID) :
                new ObjectParameter("New_ProductTypeID", typeof(long));

            var new_BrandIDParameter = product.BrandID > -1 ?
                new ObjectParameter("New_BrandID", product.BrandID) :
                new ObjectParameter("New_BrandID", typeof(long));

            var new_SupplierIDParameter = product.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", product.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_StatusIDParameter = product.StatusID > -1 ?
                new ObjectParameter("New_StatusID", product.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Product_InsertBasicInfo",
                new_ProductTitleParameter,
                new_BrifeDescriptionParameter,
                new_DescriptionParameter,
                new_ProductTypeIDParameter,
                new_BrandIDParameter,
                new_SupplierIDParameter,
                new_StatusIDParameter,
                SpProfileIDParameter,
                productID);
        }

        public virtual int Product_Update(Product product)
        {
            var original_ProductIDParameter = product.ProductID > -1 ?
                new ObjectParameter("Original_ProductID", product.ProductID) :
                new ObjectParameter("Original_ProductID", typeof(long));

            var new_ProductTitleParameter = product.ProductTitle != null ?
                new ObjectParameter("New_ProductTitle", product.ProductTitle) :
                new ObjectParameter("New_ProductTitle", typeof(string));

            var new_BrifeDescriptionParameter = product.BrifeDescription != null ?
                new ObjectParameter("New_BrifeDescription", product.BrifeDescription) :
                new ObjectParameter("New_BrifeDescription", typeof(string));

            var new_ProductActualImagePathParameter = product.ProductActualImagePath != null ?
                new ObjectParameter("New_ProductActualImagePath", product.ProductActualImagePath) :
                new ObjectParameter("New_ProductActualImagePath", typeof(string));

            var new_ProductImagePathParameter = product.ProductImagePath != null ?
                new ObjectParameter("New_ProductImagePath", product.ProductImagePath) :
                new ObjectParameter("New_ProductImagePath", typeof(string));

            var new_StockCountParameter = new ObjectParameter("New_StockCount", product.StockCount);

            var new_WebLinkParameter = product.WebLink != null ?
                new ObjectParameter("New_WebLink", product.WebLink) :
                new ObjectParameter("New_WebLink", typeof(string));

            var new_BasePriceParameter = new ObjectParameter("New_BasePrice", product.BasePrice);

            var new_SellingPriceParameter = new ObjectParameter("New_SellingPrice", product.SellingPrice);

            var new_DiscountValueParameter = product.DiscountValue.HasValue ?
                new ObjectParameter("New_DiscountValue", product.DiscountValue) :
                new ObjectParameter("New_DiscountValue", typeof(float));

            var new_IsDiscountPercentageParameter = product.IsDiscountPercentage.HasValue ?
                new ObjectParameter("New_IsDiscountPercentage", product.IsDiscountPercentage.Value) :
                new ObjectParameter("New_IsDiscountPercentage", typeof(bool));


            var new_OrderResponseTimeParameter = new ObjectParameter("New_OrderResponseTime", product.OrderResponseTime);

            var new_OrderResponseTimeUnitIDParameter = product.OrderResponseTimeUnitID != null ?
                new ObjectParameter("New_OrderResponseTimeUnitID", product.OrderResponseTimeUnitID) :
                new ObjectParameter("New_OrderResponseTimeUnitID", typeof(string));

            var new_TaxTypeIDParameter = product.TaxTypeID > -1 ?
                new ObjectParameter("New_TaxTypeID", product.TaxTypeID) :
                new ObjectParameter("New_TaxTypeID", typeof(long));

            var new_UserRatingParameter = product.UserRating.HasValue ?
                new ObjectParameter("New_UserRating", product.UserRating.Value) :
                new ObjectParameter("New_UserRating", typeof(int));

            var new_AnalysisRankParameter = product.AnalysisRank.HasValue ?
                new ObjectParameter("New_AnalysisRank", product.AnalysisRank) :
                new ObjectParameter("New_AnalysisRank", typeof(int));

            var new_DescriptionParameter = product.Description != null ?
                new ObjectParameter("New_Description", product.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_ProductTypeIDParameter = product.ProductTypeID > -1 ?
                new ObjectParameter("New_ProductTypeID", product.ProductTypeID) :
                new ObjectParameter("New_ProductTypeID", typeof(long));

            var new_BrandIDParameter = product.BrandID > -1 ?
                new ObjectParameter("New_BrandID", product.BrandID) :
                new ObjectParameter("New_BrandID", typeof(long));

            var new_SupplierIDParameter = product.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", product.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_StatusIDParameter = product.StatusID > -1 ?
                new ObjectParameter("New_StatusID", product.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = product.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", product.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Product_Update", 
                original_ProductIDParameter, 
                new_ProductTitleParameter, 
                new_BrifeDescriptionParameter, 
                new_ProductActualImagePathParameter, 
                new_ProductImagePathParameter, 
                new_StockCountParameter, 
                new_WebLinkParameter, 
                new_BasePriceParameter, 
                new_SellingPriceParameter,
                new_DiscountValueParameter,
                new_IsDiscountPercentageParameter,
                new_OrderResponseTimeParameter, 
	            new_OrderResponseTimeUnitIDParameter, 
                new_TaxTypeIDParameter, 
                new_UserRatingParameter, 
                new_AnalysisRankParameter, 
                new_DescriptionParameter, 
                new_ProductTypeIDParameter, 
                new_BrandIDParameter, 
                new_SupplierIDParameter, 
                new_StatusIDParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Product_UpdateBasicInfo(Product product)
        {
            var original_ProductIDParameter = product.ProductID > -1 ?
                new ObjectParameter("Original_ProductID", product.ProductID) :
                new ObjectParameter("Original_ProductID", typeof(long));

            var new_ProductTitleParameter = product.ProductTitle != null ?
                new ObjectParameter("New_ProductTitle", product.ProductTitle) :
                new ObjectParameter("New_ProductTitle", typeof(string));

            var new_BrifeDescriptionParameter = product.BrifeDescription != null ?
                new ObjectParameter("New_BrifeDescription", product.BrifeDescription) :
                new ObjectParameter("New_BrifeDescription", typeof(string));

            var new_DescriptionParameter = product.Description != null ?
                new ObjectParameter("New_Description", product.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_ProductTypeIDParameter = product.ProductTypeID > -1 ?
                new ObjectParameter("New_ProductTypeID", product.ProductTypeID) :
                new ObjectParameter("New_ProductTypeID", typeof(long));

            var new_BrandIDParameter = product.BrandID > -1 ?
                new ObjectParameter("New_BrandID", product.BrandID) :
                new ObjectParameter("New_BrandID", typeof(long));

            var new_SupplierIDParameter = product.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", product.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_StatusIDParameter = product.StatusID > -1 ?
                new ObjectParameter("New_StatusID", product.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = product.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", product.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Product_UpdateBasicInfo",
                original_ProductIDParameter,
                new_ProductTitleParameter,
                new_BrifeDescriptionParameter,
                new_DescriptionParameter,
                new_ProductTypeIDParameter,
                new_BrandIDParameter,
                new_SupplierIDParameter,
                new_StatusIDParameter,
                SpProfileIDParameter,
                lastModifiedDateTimeParameter);
        }

        public virtual int Product_UpdatePricing(Product product)
        {
            var original_ProductIDParameter = product.ProductID > -1 ?
                new ObjectParameter("Original_ProductID", product.ProductID) :
                new ObjectParameter("Original_ProductID", typeof(long));

            var new_BasePriceParameter = new ObjectParameter("New_BasePrice", product.BasePrice);

            var new_SellingPriceParameter = new ObjectParameter("New_SellingPrice", product.SellingPrice);

            var new_DiscountValueParameter = product.DiscountValue.HasValue ?
                new ObjectParameter("New_DiscountValue", product.DiscountValue) :
                new ObjectParameter("New_DiscountValue", typeof(float));

            var new_IsDiscountPercentageParameter = product.IsDiscountPercentage.HasValue ?
                new ObjectParameter("New_IsDiscountPercentage", product.IsDiscountPercentage.Value) :
                new ObjectParameter("New_IsDiscountPercentage", typeof(bool));

            var new_OrderResponseTimeParameter = new ObjectParameter("New_OrderResponseTime", product.OrderResponseTime);

            var new_OrderResponseTimeUnitIDParameter = product.OrderResponseTimeUnitID != null ?
                new ObjectParameter("New_OrderResponseTimeUnitID", product.OrderResponseTimeUnitID) :
                new ObjectParameter("New_OrderResponseTimeUnitID", typeof(string));

            var new_TaxTypeIDParameter = product.TaxTypeID > -1 ?
                new ObjectParameter("New_TaxTypeID", product.TaxTypeID) :
                new ObjectParameter("New_TaxTypeID", typeof(long));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = product.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", product.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Product_UpdatePricing",
                original_ProductIDParameter,
                new_BasePriceParameter,
                new_SellingPriceParameter,
                new_DiscountValueParameter,
                new_IsDiscountPercentageParameter,
                new_OrderResponseTimeParameter,
                new_OrderResponseTimeUnitIDParameter,
                new_TaxTypeIDParameter,
                SpProfileIDParameter);
        }

        public virtual int Product_UpdateImages(Product product)
        {
            var original_ProductIDParameter = product.ProductID > -1 ?
                new ObjectParameter("Original_ProductID", product.ProductID) :
                new ObjectParameter("Original_ProductID", typeof(long));

            var new_ProductActualImagePathParameter = product.ProductActualImagePath != null ?
                new ObjectParameter("New_ProductActualImagePath", product.ProductActualImagePath) :
                new ObjectParameter("New_ProductActualImagePath", typeof(string));

            var new_ProductImagePathParameter = product.ProductImagePath != null ?
                new ObjectParameter("New_ProductImagePath", product.ProductImagePath) :
                new ObjectParameter("New_ProductImagePath", typeof(string));

            var SpProfileIDParameter = product.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", product.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Product_UpdateImages",
                original_ProductIDParameter,
                new_ProductActualImagePathParameter,
                new_ProductImagePathParameter,
                SpProfileIDParameter);
        }

        public virtual int ProductAttributePair_Insert(ProductAttributePair productAttributePair, ObjectParameter productAttributePairID)
        {
            var new_ProductIDParameter = productAttributePair.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productAttributePair.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_AttributeIDParameter = productAttributePair.AttributeID > -1 ?
                new ObjectParameter("New_AttributeID", productAttributePair.AttributeID) :
                new ObjectParameter("New_AttributeID", typeof(long));

            var new_AttributeValueParameter = productAttributePair.AttributeValue != null ?
                new ObjectParameter("New_AttributeValue", productAttributePair.AttributeValue) :
                new ObjectParameter("New_AttributeValue", typeof(string));

            var new_DisplayOrderParameter = productAttributePair.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", productAttributePair.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", productAttributePair.IsAssigned);

            var new_IsSelectedForVariationParameter = new ObjectParameter("New_IsSelectedForVariation", productAttributePair.IsSelectedForVariation);

            var new_VariationInPriceParameter = productAttributePair.VariationInPrice > -1 ?
                new ObjectParameter("New_VariationInPrice", productAttributePair.VariationInPrice) :
                new ObjectParameter("New_VariationInPrice", typeof(double));

            return ObjectContext.ExecuteFunction("ProductAttributePair_Insert", new_ProductIDParameter, new_AttributeIDParameter, new_AttributeValueParameter, new_DisplayOrderParameter, new_IsAssignedParameter, new_IsSelectedForVariationParameter, new_VariationInPriceParameter, productAttributePairID);
        }

        public virtual int ProductAttributePair_Update(ProductAttributePair productAttributePair)
        {
            var original_ProductAttributePairIDParameter = productAttributePair.ProductAttributePairID > -1 ?
                new ObjectParameter("Original_ProductAttributePairID", productAttributePair.ProductAttributePairID) :
                new ObjectParameter("Original_ProductAttributePairID", typeof(long));

            var new_ProductIDParameter = productAttributePair.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productAttributePair.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_AttributeIDParameter = productAttributePair.AttributeID > -1 ?
                new ObjectParameter("New_AttributeID", productAttributePair.AttributeID) :
                new ObjectParameter("New_AttributeID", typeof(long));

            var new_AttributeValueParameter = productAttributePair.AttributeValue != null ?
                new ObjectParameter("New_AttributeValue", productAttributePair.AttributeValue) :
                new ObjectParameter("New_AttributeValue", typeof(string));

            var new_DisplayOrderParameter = productAttributePair.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", productAttributePair.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));
            
            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", productAttributePair.IsAssigned);

            var new_IsSelectedForVariationParameter = new ObjectParameter("New_IsSelectedForVariation", productAttributePair.IsSelectedForVariation);

            var new_VariationInPriceParameter = new ObjectParameter("New_VariationInPrice", productAttributePair.VariationInPrice);

            return ObjectContext.ExecuteFunction("ProductAttributePair_Update", original_ProductAttributePairIDParameter, new_ProductIDParameter, new_AttributeIDParameter, new_AttributeValueParameter, new_DisplayOrderParameter, new_IsAssignedParameter, new_IsSelectedForVariationParameter, new_VariationInPriceParameter);
        }

        public virtual int ProductAttributePair_UpdateIsAssigned(ProductAttributePair productAttributePair)
        {

            var new_ProductIDParameter = productAttributePair.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productAttributePair.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_AttributeIDParameter = productAttributePair.AttributeID > -1 ?
                new ObjectParameter("New_AttributeID", productAttributePair.AttributeID) :
                new ObjectParameter("New_AttributeID", typeof(long));

            var new_AttributeValueParameter = productAttributePair.AttributeValue != null ?
                new ObjectParameter("New_AttributeValue", productAttributePair.AttributeValue) :
                new ObjectParameter("New_AttributeValue", typeof(string));


            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", productAttributePair.IsAssigned);

            var new_IsSelectedForVariationParameter = new ObjectParameter("New_IsSelectedForVariation", productAttributePair.IsSelectedForVariation);

            var new_VariationInPriceParameter = new ObjectParameter("New_VariationInPrice", productAttributePair.VariationInPrice);

            return ObjectContext.ExecuteFunction("ProductAttributePair_UpdateIsAssigned", new_ProductIDParameter, new_AttributeIDParameter, new_AttributeValueParameter, new_IsAssignedParameter, new_IsSelectedForVariationParameter, new_VariationInPriceParameter);
        }

        public virtual int ProductMediaDetail_Insert(ProductMediaDetail productMediaDetail, ObjectParameter productMediaID)
        {
            var new_ProductMediaTitleParameter = productMediaDetail.ProductMediaTitle != null ?
                new ObjectParameter("New_ProductMediaTitle", productMediaDetail.ProductMediaTitle) :
                new ObjectParameter("New_ProductMediaTitle", typeof(string));

            var new_DescriptionParameter = productMediaDetail.Description != null ?
                new ObjectParameter("New_Description", productMediaDetail.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_MediaContentTypeIDParameter = productMediaDetail.MediaContentTypeID > -1 ?
                new ObjectParameter("New_MediaContentTypeID", productMediaDetail.MediaContentTypeID) :
                new ObjectParameter("New_MediaContentTypeID", typeof(long));

            var new_MediaFilePathParameter = productMediaDetail.MediaFilePath != null ?
                new ObjectParameter("New_MediaFilePath", productMediaDetail.MediaFilePath) :
                new ObjectParameter("New_MediaFilePath", typeof(string));

            var new_ProductIDParameter = productMediaDetail.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productMediaDetail.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_WidthParameter = productMediaDetail.Width > -1 ?
                new ObjectParameter("New_Width", productMediaDetail.Width) :
                new ObjectParameter("New_Width", typeof(int));

            var new_HeightParameter = productMediaDetail.Height > -1 ?
                new ObjectParameter("New_Height", productMediaDetail.Height) :
                new ObjectParameter("New_Height", typeof(int));

            var new_TransparencyLevelParameter = productMediaDetail.TransparencyLevel > -1 ?
                new ObjectParameter("New_TransparencyLevel", productMediaDetail.TransparencyLevel) :
                new ObjectParameter("New_TransparencyLevel", typeof(int));

            var new_StatusIDParameter = productMediaDetail.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productMediaDetail.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = productMediaDetail.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", productMediaDetail.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("ProductMediaDetail_Insert", new_ProductMediaTitleParameter, new_DescriptionParameter, new_MediaContentTypeIDParameter, new_MediaFilePathParameter, new_ProductIDParameter, new_WidthParameter, new_HeightParameter, new_TransparencyLevelParameter, new_StatusIDParameter, SpProfileIDParameter, productMediaID);
        }

        public virtual int ProductMediaDetail_Update(ProductMediaDetail productMediaDetail)
        {
            var original_ProductMediaIDParameter = productMediaDetail.ProductMediaID > -1 ?
                new ObjectParameter("Original_ProductMediaID", productMediaDetail.ProductMediaID) :
                new ObjectParameter("Original_ProductMediaID", typeof(long));

            var new_ProductMediaTitleParameter = productMediaDetail.ProductMediaTitle != null ?
                new ObjectParameter("New_ProductMediaTitle", productMediaDetail.ProductMediaTitle) :
                new ObjectParameter("New_ProductMediaTitle", typeof(string));

            var new_DescriptionParameter = productMediaDetail.Description != null ?
                new ObjectParameter("New_Description", productMediaDetail.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_MediaContentTypeIDParameter = productMediaDetail.MediaContentTypeID > -1 ?
                new ObjectParameter("New_MediaContentTypeID", productMediaDetail.MediaContentTypeID) :
                new ObjectParameter("New_MediaContentTypeID", typeof(long));

            var new_MediaFilePathParameter = productMediaDetail.MediaFilePath != null ?
                new ObjectParameter("New_MediaFilePath", productMediaDetail.MediaFilePath) :
                new ObjectParameter("New_MediaFilePath", typeof(string));

            var new_ProductIDParameter = productMediaDetail.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productMediaDetail.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_WidthParameter = productMediaDetail.Width > -1 ?
                new ObjectParameter("New_Width", productMediaDetail.Width) :
                new ObjectParameter("New_Width", typeof(int));

            var new_HeightParameter = productMediaDetail.Height > -1 ?
                new ObjectParameter("New_Height", productMediaDetail.Height) :
                new ObjectParameter("New_Height", typeof(int));

            var new_TransparencyLevelParameter = productMediaDetail.TransparencyLevel > -1 ?
                new ObjectParameter("New_TransparencyLevel", productMediaDetail.TransparencyLevel) :
                new ObjectParameter("New_TransparencyLevel", typeof(int));

            var new_StatusIDParameter = productMediaDetail.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productMediaDetail.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = productMediaDetail.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", productMediaDetail.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = productMediaDetail.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", productMediaDetail.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("ProductMediaDetail_Update", original_ProductMediaIDParameter, new_ProductMediaTitleParameter, new_DescriptionParameter, new_MediaContentTypeIDParameter, new_MediaFilePathParameter, new_ProductIDParameter, new_WidthParameter, new_HeightParameter, new_TransparencyLevelParameter, new_StatusIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int ProductType_Insert(ProductType productType, ObjectParameter productTypeID)
        {
            var new_ProductTypeTitleParameter = productType.ProductTypeTitle != null ?
                new ObjectParameter("New_ProductTypeTitle", productType.ProductTypeTitle) :
                new ObjectParameter("New_ProductTypeTitle", typeof(string));

            var new_ProductTypeDescriptionParameter = productType.ProductTypeDescription != null ?
                new ObjectParameter("New_ProductTypeDescription", productType.ProductTypeDescription) :
                new ObjectParameter("New_ProductTypeDescription", typeof(string));

            var new_StatusIDParameter = productType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = productType.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", productType.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", productType.IsSystem);

            return ObjectContext.ExecuteFunction("ProductType_Insert", new_ProductTypeTitleParameter, new_ProductTypeDescriptionParameter, new_StatusIDParameter, SpProfileIDParameter, productTypeID, new_IsSystemParameter);
        }

        public virtual int ProductType_Update(ProductType productType)
        {
            var original_ProductTypeIDParameter = productType.ProductTypeID > -1 ?
                new ObjectParameter("Original_ProductTypeID", productType.ProductTypeID) :
                new ObjectParameter("Original_ProductTypeID", typeof(long));

            var new_ProductTypeTitleParameter = productType.ProductTypeTitle != null ?
                new ObjectParameter("New_ProductTypeTitle", productType.ProductTypeTitle) :
                new ObjectParameter("New_ProductTypeTitle", typeof(string));

            var new_ProductTypeDescriptionParameter = productType.ProductTypeDescription != null ?
                new ObjectParameter("New_ProductTypeDescription", productType.ProductTypeDescription) :
                new ObjectParameter("New_ProductTypeDescription", typeof(string));

            var new_StatusIDParameter = productType.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productType.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = productType.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", productType.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = productType.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", productType.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", productType.IsSystem);

            return ObjectContext.ExecuteFunction("ProductType_Update", original_ProductTypeIDParameter, new_ProductTypeTitleParameter, new_ProductTypeDescriptionParameter, new_StatusIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter, new_IsSystemParameter);
        }

        public virtual int ProductView_Insert(ProductView productView, ObjectParameter productViewID)
        {
            var new_ProductViewTitleParameter = productView.ProductViewTitle != null ?
                new ObjectParameter("New_ProductViewTitle", productView.ProductViewTitle) :
                new ObjectParameter("New_ProductViewTitle", typeof(string));

            var new_DescriptionParameter = productView.Description != null ?
                new ObjectParameter("New_Description", productView.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = productView.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productView.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", productView.IsSystem);

            return ObjectContext.ExecuteFunction("ProductView_Insert", new_ProductViewTitleParameter, new_DescriptionParameter, new_StatusIDParameter, productViewID, new_IsSystemParameter);
        }

        public virtual int ProductView_Update(ProductView productView)
        {
            var original_ProductViewIDParameter = productView.ProductViewID > -1 ?
                new ObjectParameter("Original_ProductViewID", productView.ProductViewID) :
                new ObjectParameter("Original_ProductViewID", typeof(long));

            var new_ProductViewTitleParameter = productView.ProductViewTitle != null ?
                new ObjectParameter("New_ProductViewTitle", productView.ProductViewTitle) :
                new ObjectParameter("New_ProductViewTitle", typeof(string));

            var new_DescriptionParameter = productView.Description != null ?
                new ObjectParameter("New_Description", productView.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = productView.StatusID > -1 ?
                new ObjectParameter("New_StatusID", productView.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", productView.IsSystem);

            return ObjectContext.ExecuteFunction("ProductView_Update", original_ProductViewIDParameter, new_ProductViewTitleParameter, new_DescriptionParameter, new_StatusIDParameter, new_IsSystemParameter);
        }

        public virtual int ProductViewItem_Insert(ProductViewItem productViewItem, ObjectParameter productViewProductID)
        {
            var new_ProductViewIDParameter = productViewItem.ProductViewID > -1 ?
                new ObjectParameter("New_ProductViewID", productViewItem.ProductViewID) :
                new ObjectParameter("New_ProductViewID", typeof(long));

            var new_ProductIDParameter = productViewItem.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productViewItem.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_ProductMediaIDParameter = productViewItem.ProductMediaID > -1 ?
                new ObjectParameter("New_ProductMediaID", productViewItem.ProductMediaID) :
                new ObjectParameter("New_ProductMediaID", typeof(long));

            return ObjectContext.ExecuteFunction("ProductViewItem_Insert", new_ProductViewIDParameter, new_ProductIDParameter, new_ProductMediaIDParameter, productViewProductID);
        }

        public virtual int ProductViewItem_Update(ProductViewItem productViewItem)
        {
            var original_ProductViewProductIDParameter = productViewItem.ProductViewProductID > -1 ?
                new ObjectParameter("Original_ProductViewProductID", productViewItem.ProductViewProductID) :
                new ObjectParameter("Original_ProductViewProductID", typeof(long));

            var new_ProductViewIDParameter = productViewItem.ProductViewID > -1 ?
                new ObjectParameter("New_ProductViewID", productViewItem.ProductViewID) :
                new ObjectParameter("New_ProductViewID", typeof(long));

            var new_ProductIDParameter = productViewItem.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productViewItem.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_ProductMediaIDParameter = productViewItem.ProductMediaID > -1 ?
                new ObjectParameter("New_ProductMediaID", productViewItem.ProductMediaID) :
                new ObjectParameter("New_ProductMediaID", typeof(long));

            return ObjectContext.ExecuteFunction("ProductViewItem_Update", original_ProductViewProductIDParameter, new_ProductViewIDParameter, new_ProductIDParameter, new_ProductMediaIDParameter);
        }
        
        #endregion Product SPs

        public virtual int Profile_Insert(Profile profile, ObjectParameter profileID)
        {
            var new_UserIDParameter = profile.UserID > -1 ?
                new ObjectParameter("New_UserID", profile.UserID) :
                new ObjectParameter("New_UserID", typeof(long));

            var new_FirstNameParameter = profile.FirstName != null ?
                new ObjectParameter("New_FirstName", profile.FirstName) :
                new ObjectParameter("New_FirstName", typeof(string));

            var new_MiddleNameParameter = profile.MiddleName != null ?
                new ObjectParameter("New_MiddleName", profile.MiddleName) :
                new ObjectParameter("New_MiddleName", typeof(string));

            var new_LastNameParameter = profile.LastName != null ?
                new ObjectParameter("New_LastName", profile.LastName) :
                new ObjectParameter("New_LastName", typeof(string));

            var new_FatherNameParameter = profile.FatherName != null ?
                new ObjectParameter("New_FatherName", profile.FatherName) :
                new ObjectParameter("New_FatherName", typeof(string));

            var new_NationalityParameter = profile.Nationality != null ?
                new ObjectParameter("New_Nationality", profile.Nationality) :
                new ObjectParameter("New_Nationality", typeof(string));

            var new_OccupationParameter = profile.Occupation != null ?
                new ObjectParameter("New_Occupation", profile.Occupation) :
                new ObjectParameter("New_Occupation", typeof(string));

            var new_EducationParameter = profile.Education != null ?
                new ObjectParameter("New_Education", profile.Education) :
                new ObjectParameter("New_Education", typeof(string));

            var new_ImagePathParameter = profile.ImagePath != null ?
                new ObjectParameter("New_ImagePath", profile.ImagePath) :
                new ObjectParameter("New_ImagePath", typeof(string));

            var new_IsVerifiedParameter = new ObjectParameter("New_IsVerified", profile.IsVerified);           
            
            var new_UserTypeIDParameter = profile.UserTypeID > -1 ?
                new ObjectParameter("New_UserTypeID", profile.UserTypeID) :
                new ObjectParameter("New_UserTypeID", typeof(long));

            var new_SMS_2FAParameter = new ObjectParameter("New_SMS_2FA", profile.SMS_2FA);

            var new_EMail_2FAParameter = new ObjectParameter("New_EMail_2FA", profile.EMail_2FA);

            return ObjectContext.ExecuteFunction("Profile_Insert", new_UserIDParameter, new_FirstNameParameter, new_MiddleNameParameter, new_LastNameParameter, new_FatherNameParameter, new_NationalityParameter, new_OccupationParameter, new_EducationParameter, new_ImagePathParameter, new_IsVerifiedParameter, new_UserTypeIDParameter, new_SMS_2FAParameter, new_EMail_2FAParameter, profileID);
        }

        public virtual int Profile_Update(Profile profile)
        {
            var original_ProfileIDParameter = profile.ProfileID > -1 ?
                new ObjectParameter("Original_ProfileID", profile.ProfileID) :
                new ObjectParameter("Original_ProfileID", typeof(long));

            var new_UserIDParameter = profile.UserID > -1 ?
                new ObjectParameter("New_UserID", profile.UserID) :
                new ObjectParameter("New_UserID", typeof(long));

            var new_FirstNameParameter = profile.FirstName != null ?
                new ObjectParameter("New_FirstName", profile.FirstName) :
                new ObjectParameter("New_FirstName", typeof(string));

            var new_MiddleNameParameter = profile.MiddleName != null ?
                new ObjectParameter("New_MiddleName", profile.MiddleName) :
                new ObjectParameter("New_MiddleName", typeof(string));

            var new_LastNameParameter = profile.LastName != null ?
                new ObjectParameter("New_LastName", profile.LastName) :
                new ObjectParameter("New_LastName", typeof(string));

            var new_FatherNameParameter = profile.FatherName != null ?
                new ObjectParameter("New_FatherName", profile.FatherName) :
                new ObjectParameter("New_FatherName", typeof(string));

            var new_NationalityParameter = profile.Nationality != null ?
                new ObjectParameter("New_Nationality", profile.Nationality) :
                new ObjectParameter("New_Nationality", typeof(string));

            var new_OccupationParameter = profile.Occupation != null ?
                new ObjectParameter("New_Occupation", profile.Occupation) :
                new ObjectParameter("New_Occupation", typeof(string));

            var new_EducationParameter = profile.Education != null ?
                new ObjectParameter("New_Education", profile.Education) :
                new ObjectParameter("New_Education", typeof(string));

            var new_ImagePathParameter = profile.ImagePath != null ?
                new ObjectParameter("New_ImagePath", profile.ImagePath) :
                new ObjectParameter("New_ImagePath", typeof(string));

            var new_IsVerifiedParameter = new ObjectParameter("New_IsVerified", profile.IsVerified);

            var new_UserTypeIDParameter = profile.UserTypeID > -1 ?
                new ObjectParameter("New_UserTypeID", profile.UserTypeID) :
                new ObjectParameter("New_UserTypeID", typeof(long));

            var new_SMS_2FAParameter = new ObjectParameter("New_SMS_2FA", profile.SMS_2FA);

            var new_EMail_2FAParameter = new ObjectParameter("New_EMail_2FA", profile.EMail_2FA);

            return ObjectContext.ExecuteFunction("Profile_Update", original_ProfileIDParameter, new_UserIDParameter, new_FirstNameParameter, new_MiddleNameParameter, new_LastNameParameter, new_FatherNameParameter, new_NationalityParameter, new_OccupationParameter, new_EducationParameter, new_ImagePathParameter, new_IsVerifiedParameter, new_UserTypeIDParameter, new_SMS_2FAParameter, new_EMail_2FAParameter);
        }
        public virtual int Profile_Update_2FA(Profile profile)
        {
            var original_ProfileIDParameter = profile.ProfileID > -1 ?
                new ObjectParameter("Original_ProfileID", profile.ProfileID) :
                new ObjectParameter("Original_ProfileID", typeof(long));            

            var new_SMS_2FAParameter = new ObjectParameter("New_SMS_2FA", profile.SMS_2FA);

            var new_EMail_2FAParameter = new ObjectParameter("New_EMail_2FA", profile.EMail_2FA);

            return ObjectContext.ExecuteFunction("Profile_Update_2FA", original_ProfileIDParameter,  new_SMS_2FAParameter, new_EMail_2FAParameter);
        }

        public virtual int ProfileVerification_Insert(ProfileVerification profileVerification, ObjectParameter VerificationID)
        {
            var new_DocumentTypeIDParameter = profileVerification.DocumentTypeID > -1 ?
                new ObjectParameter("New_DocumentTypeID", profileVerification.DocumentTypeID) :
                new ObjectParameter("New_DocumentTypeID", typeof(long));

            var new_VerifiedByParameter = profileVerification.VerifiedBy.HasValue ?
                new ObjectParameter("New_VerifiedBy", profileVerification.VerifiedBy) :
                new ObjectParameter("New_VerifiedBy", typeof(int));

            var new_VerifiedOnParameter = profileVerification.VerifiedOn.HasValue ?
                new ObjectParameter("New_VerifiedOn", profileVerification.VerifiedOn) :
                new ObjectParameter("New_VerifiedOn", typeof(int));

            var new_CommentsParameter = profileVerification.Comments != null ?
                new ObjectParameter("New_Comments", profileVerification.Comments) :
                new ObjectParameter("New_Comments", typeof(string));

            var new_VerificationStatusIDParameter = profileVerification.VerificationStatusID.HasValue ?
                new ObjectParameter("New_VerificationStatusID", profileVerification.VerificationStatusID) :
                new ObjectParameter("New_VerificationStatusID", typeof(long));

            var new_ProfileIDParameter = profileVerification.ProfileID > -1 ?
                new ObjectParameter("New_ProfileID", profileVerification.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_DocumentNumberByUserParameter = profileVerification.DocumentNumberByUser != null ?
                new ObjectParameter("New_DocumentNumberByUser", profileVerification.DocumentNumberByUser) :
                new ObjectParameter("New_DocumentNumberByUser", typeof(string));

            var new_DocumentNumberByVerifierParameter = profileVerification.DocumentNumberByVerifier != null ?
                new ObjectParameter("New_DocumentNumberByVerifier", profileVerification.DocumentNumberByVerifier) :
                new ObjectParameter("New_DocumentNumberByVerifier", typeof(string));

            var new_DocumentImagePathParameter = profileVerification.DocumentImagePath != null ?
                new ObjectParameter("New_DocumentImagePath", profileVerification.DocumentImagePath) :
                new ObjectParameter("New_DocumentImagePath", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ProfileVerification_Insert",
                new_DocumentTypeIDParameter,
                new_VerifiedByParameter,
                new_VerifiedOnParameter,
                new_CommentsParameter,
                new_VerificationStatusIDParameter,
                new_ProfileIDParameter,
                new_DocumentNumberByUserParameter,
                new_DocumentNumberByVerifierParameter,
                new_DocumentImagePathParameter,
                VerificationID);
        }

        public virtual int ProfileVerification_Update(ProfileVerification profileVerification)
        {
            var original_VerificationIDParameter = profileVerification.VerificationID > -1 ?
                new ObjectParameter("Original_VerificationID", profileVerification.VerificationID) :
                new ObjectParameter("Original_VerificationID", typeof(long));

            var new_DocumentTypeIDParameter = profileVerification.DocumentTypeID > 0 ?
                new ObjectParameter("New_DocumentTypeID", profileVerification.DocumentTypeID) :
                new ObjectParameter("New_DocumentTypeID", typeof(long));

            var new_VerifiedByParameter = profileVerification.VerifiedBy.HasValue ?
                new ObjectParameter("New_VerifiedBy", profileVerification.VerifiedBy.Value) :
                new ObjectParameter("New_VerifiedBy", typeof(int));

            var new_VerifiedOnParameter = profileVerification.VerifiedOn.HasValue ?
                new ObjectParameter("New_VerifiedOn", profileVerification.VerifiedOn.Value) :
                new ObjectParameter("New_VerifiedOn", typeof(System.DateTime));

            var new_CommentsParameter = !string.IsNullOrEmpty(profileVerification.Comments) ?
                new ObjectParameter("New_Comments", profileVerification.Comments) :
                new ObjectParameter("New_Comments", typeof(string));

            var new_VerificationStatusIDParameter = profileVerification.VerificationStatusID.HasValue ?
                new ObjectParameter("New_VerificationStatusID", profileVerification.VerificationStatusID.Value) :
                new ObjectParameter("New_VerificationStatusID", typeof(long));


            var new_DocumentNumberByVerifierParameter = !string.IsNullOrEmpty(profileVerification.DocumentNumberByVerifier) ?
                new ObjectParameter("New_DocumentNumberByVerifier", profileVerification.DocumentNumberByVerifier) :
                new ObjectParameter("New_DocumentNumberByVerifier", typeof(string));

            var new_ProfileIDParameter = profileVerification.ProfileID > 0 ?
                new ObjectParameter("New_ProfileID", profileVerification.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(int));

            var new_DocumentNumberByUserParameter = ! string.IsNullOrEmpty(profileVerification.DocumentNumberByUser) ?
                new ObjectParameter("New_DocumentNumberByUser", profileVerification.DocumentNumberByUser) :
                new ObjectParameter("New_DocumentNumberByUser", typeof(int));

            var new_DocumentImagePathParameter = ! string.IsNullOrEmpty(profileVerification.DocumentImagePath) ?
                new ObjectParameter("New_DocumentImagePath", profileVerification.DocumentImagePath) :
                new ObjectParameter("New_DocumentImagePath", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ProfileVerification_Update",
                original_VerificationIDParameter,
                new_DocumentTypeIDParameter,
                new_VerifiedByParameter,
                new_VerifiedOnParameter,
                new_CommentsParameter,
                new_VerificationStatusIDParameter,
                new_DocumentNumberByVerifierParameter,
                new_ProfileIDParameter,
                new_DocumentNumberByUserParameter,
                new_DocumentImagePathParameter
                );
        }
        
        public virtual int ProfileVerification_ChangeVerificationStatus(ProfileVerification profileVerification)
        {
            var original_VerificationIDParameter = profileVerification.VerificationID > -1 ?
                new ObjectParameter("Original_VerificationID", profileVerification.VerificationID) :
                new ObjectParameter("Original_VerificationID", typeof(long));

            var new_VerifiedByParameter = profileVerification.VerifiedBy.HasValue ?
                new ObjectParameter("New_VerifiedBy", profileVerification.VerifiedBy.Value) :
                new ObjectParameter("New_VerifiedBy", typeof(int));

            var new_CommentsParameter = !string.IsNullOrEmpty(profileVerification.Comments) ?
                new ObjectParameter("New_Comments", profileVerification.Comments) :
                new ObjectParameter("New_Comments", typeof(string));

            var new_VerificationStatusIDParameter = profileVerification.VerificationStatusID.HasValue ?
                new ObjectParameter("New_VerificationStatusID", profileVerification.VerificationStatusID.Value) :
                new ObjectParameter("New_VerificationStatusID", typeof(long));

            var new_DocumentNumberByVerifierParameter = !string.IsNullOrEmpty(profileVerification.DocumentNumberByVerifier) ?
                new ObjectParameter("New_DocumentNumberByVerifier", profileVerification.DocumentNumberByVerifier) :
                new ObjectParameter("New_DocumentNumberByVerifier", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ProfileVerification_ChangeVerificationStatus",
                original_VerificationIDParameter,
                new_VerifiedByParameter,
                new_CommentsParameter,
                new_VerificationStatusIDParameter,
                new_DocumentNumberByVerifierParameter
                );
        }

        public virtual int ProfileVerification_UpdateByUser(ProfileVerification profileVerification)
        {
            var original_VerificationIDParameter = profileVerification.VerificationID > -1 ?
                new ObjectParameter("Original_VerificationID", profileVerification.VerificationID) :
                new ObjectParameter("Original_VerificationID", typeof(long));

            var new_DocumentTypeIDParameter = profileVerification.DocumentTypeID > -1 ?
                new ObjectParameter("New_DocumentTypeID", profileVerification.DocumentTypeID) :
                new ObjectParameter("New_DocumentTypeID", typeof(long));

            var new_DocumentNumberByUserParameter = string.IsNullOrEmpty(profileVerification.DocumentNumberByUser) == false ?
                new ObjectParameter("New_DocumentNumberByUser", profileVerification.DocumentNumberByUser) :
                new ObjectParameter("New_DocumentNumberByUser", typeof(string));

            var new_DocumentImagePathParameter = string.IsNullOrEmpty(profileVerification.DocumentImagePath) == false ?
                new ObjectParameter("New_DocumentImagePath", profileVerification.DocumentImagePath) :
                new ObjectParameter("New_DocumentImagePath", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ProfileVerification_UpdateByUser",
                new_DocumentTypeIDParameter,
                new_DocumentNumberByUserParameter,
                new_DocumentImagePathParameter,
                original_VerificationIDParameter);
        }

        public virtual int Role_Insert(Role role, ObjectParameter roleID)
        {
            var new_RoleTitleParameter = role.RoleTitle != null ?
                new ObjectParameter("New_RoleTitle", role.RoleTitle) :
                new ObjectParameter("New_RoleTitle", typeof(string));

            var new_DescriptionParameter = role.Description != null ?
                new ObjectParameter("New_Description", role.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = role.IconPath != null ?
                new ObjectParameter("New_IconPath", role.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_StatusIDParameter = role.StatusID > -1 ?
                new ObjectParameter("New_StatusID", role.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", role.IsSystem);

            return ObjectContext.ExecuteFunction("Role_Insert", new_RoleTitleParameter, new_DescriptionParameter, new_IconPathParameter, new_StatusIDParameter, new_IsSystemParameter, roleID);
        }

        public virtual int Role_Update(Role role)
        {
            var original_RoleIDParameter = role.RoleID > -1 ?
                new ObjectParameter("Original_RoleID", role.RoleID) :
                new ObjectParameter("Original_RoleID", typeof(long));

            var new_RoleTitleParameter = role.RoleTitle != null ?
                new ObjectParameter("New_RoleTitle", role.RoleTitle) :
                new ObjectParameter("New_RoleTitle", typeof(string));

            var new_DescriptionParameter = role.Description != null ?
                new ObjectParameter("New_Description", role.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IconPathParameter = role.IconPath != null ?
                new ObjectParameter("New_IconPath", role.IconPath) :
                new ObjectParameter("New_IconPath", typeof(string));

            var new_StatusIDParameter = role.StatusID > -1 ?
                new ObjectParameter("New_StatusID", role.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", role.IsSystem);

            return ObjectContext.ExecuteFunction("Role_Update", original_RoleIDParameter, new_RoleTitleParameter, new_DescriptionParameter, new_IconPathParameter, new_StatusIDParameter, new_IsSystemParameter);
        }

        public virtual int RoleOptionPair_Insert(RoleOptionPair roleOptionPair, ObjectParameter roleOptionPairID)
        {
            var new_OptionIDParameter = roleOptionPair.OptionID > -1 ?
                new ObjectParameter("New_OptionID", roleOptionPair.OptionID) :
                new ObjectParameter("New_OptionID", typeof(long));

            var new_RoleIDParameter = roleOptionPair.RoleID > -1 ?
                new ObjectParameter("New_RoleID", roleOptionPair.RoleID) :
                new ObjectParameter("New_RoleID", typeof(long));

            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", roleOptionPair.IsAssigned);

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", roleOptionPair.IsSystem);

            var new_StatusIDParameter = roleOptionPair.StatusID > -1 ?
                new ObjectParameter("New_StatusID", roleOptionPair.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = roleOptionPair.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", roleOptionPair.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("RoleOptionPair_Insert", new_OptionIDParameter, new_RoleIDParameter, new_IsAssignedParameter, new_IsSystemParameter, new_StatusIDParameter, SpProfileIDParameter, roleOptionPairID);
        }

        public virtual int RoleOptionPair_Update(RoleOptionPair roleOptionPair)
        {
            var original_RoleOptionPairIDParameter = roleOptionPair.RoleOptionPairID > -1 ?
                new ObjectParameter("Original_RoleOptionPairID", roleOptionPair.RoleOptionPairID) :
                new ObjectParameter("Original_RoleOptionPairID", typeof(long));

            var new_OptionIDParameter = roleOptionPair.OptionID > -1 ?
                new ObjectParameter("New_OptionID", roleOptionPair.OptionID) :
                new ObjectParameter("New_OptionID", typeof(long));

            var new_RoleIDParameter = roleOptionPair.RoleID > -1 ?
                new ObjectParameter("New_RoleID", roleOptionPair.RoleID) :
                new ObjectParameter("New_RoleID", typeof(long));

            var new_IsAssignedParameter = new ObjectParameter("New_IsAssigned", roleOptionPair.IsAssigned);

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", roleOptionPair.IsSystem);

            var new_StatusIDParameter = roleOptionPair.StatusID > -1 ?
                new ObjectParameter("New_StatusID", roleOptionPair.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = roleOptionPair.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", roleOptionPair.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = roleOptionPair.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", roleOptionPair.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("RoleOptionPair_Update", original_RoleOptionPairIDParameter, new_OptionIDParameter, new_RoleIDParameter, new_IsAssignedParameter, new_IsSystemParameter, new_StatusIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int StateMachine_Insert(StateMachine stateMachine, ObjectParameter stateMachineID)
        {
            var new_StartStateIDParameter = stateMachine.StartStateID > -1 ?
                new ObjectParameter("New_StartStateID", stateMachine.StartStateID) :
                new ObjectParameter("New_StartStateID", typeof(long));

            var new_StateMachineTitleParameter = stateMachine.StateMachineTitle != null ?
                new ObjectParameter("New_StateMachineTitle", stateMachine.StateMachineTitle) :
                new ObjectParameter("New_StateMachineTitle", typeof(string));

            var new_StateMachineDescriptionParameter = stateMachine.StateMachineDescription != null ?
                new ObjectParameter("New_StateMachineDescription", stateMachine.StateMachineDescription) :
                new ObjectParameter("New_StateMachineDescription", typeof(string));

            return ObjectContext.ExecuteFunction("StateMachine_Insert", new_StartStateIDParameter, new_StateMachineTitleParameter, new_StateMachineDescriptionParameter, stateMachineID);
        }

        public virtual int StateMachine_Update(StateMachine stateMachine)
        {
            var original_StateMachineIDParameter = stateMachine.StateMachineID > -1 ?
                new ObjectParameter("Original_StateMachineID", stateMachine.StateMachineID) :
                new ObjectParameter("Original_StateMachineID", typeof(long));

            var new_StartStateIDParameter = stateMachine.StartStateID > -1 ?
                new ObjectParameter("New_StartStateID", stateMachine.StartStateID) :
                new ObjectParameter("New_StartStateID", typeof(long));

            var new_StateMachineTitleParameter = stateMachine.StateMachineTitle != null ?
                new ObjectParameter("New_StateMachineTitle", stateMachine.StateMachineTitle) :
                new ObjectParameter("New_StateMachineTitle", typeof(string));

            var new_StateMachineDescriptionParameter = stateMachine.StateMachineDescription != null ?
                new ObjectParameter("New_StateMachineDescription", stateMachine.StateMachineDescription) :
                new ObjectParameter("New_StateMachineDescription", typeof(string));

            return ObjectContext.ExecuteFunction("StateMachine_Update", original_StateMachineIDParameter, new_StartStateIDParameter, new_StateMachineTitleParameter, new_StateMachineDescriptionParameter);
        }

        public virtual int StateMachineState_Insert(StateMachineState stateMachineState, ObjectParameter stateMachineStateID)
        {
            var new_StateIDParameter = stateMachineState.StateID > -1 ?
                new ObjectParameter("New_StateID", stateMachineState.StateID) :
                new ObjectParameter("New_StateID", typeof(long));

            var new_NextStateIDParameter = stateMachineState.NextStateID.HasValue ?
                new ObjectParameter("New_NextStateID", stateMachineState.NextStateID) :
                new ObjectParameter("New_NextStateID", typeof(long));

            var new_NextInputStringParameter = stateMachineState.NextInputString != null ?
                new ObjectParameter("New_NextInputString", stateMachineState.NextInputString) :
                new ObjectParameter("New_NextInputString", typeof(string));

            return ObjectContext.ExecuteFunction("StateMachineState_Insert", new_StateIDParameter, new_NextStateIDParameter, new_NextInputStringParameter, stateMachineStateID);
        }

        public virtual int StateMachineState_Update(StateMachineState stateMachineState)
        {
            var original_StateMachineStateIDParameter = stateMachineState.StateMachineStateID > -1 ?
                new ObjectParameter("Original_StateMachineStateID", stateMachineState.StateMachineStateID) :
                new ObjectParameter("Original_StateMachineStateID", typeof(long));

            var new_StateIDParameter = stateMachineState.StateID > -1 ?
                new ObjectParameter("New_StateID", stateMachineState.StateID) :
                new ObjectParameter("New_StateID", typeof(long));

            var new_NextStateIDParameter = stateMachineState.NextStateID > -1 ?
                new ObjectParameter("New_NextStateID", stateMachineState.NextStateID) :
                new ObjectParameter("New_NextStateID", typeof(long));

            var new_NextInputStringParameter = stateMachineState.NextInputString != null ?
                new ObjectParameter("New_NextInputString", stateMachineState.NextInputString) :
                new ObjectParameter("New_NextInputString", typeof(string));

            return ObjectContext.ExecuteFunction("StateMachineState_Update", original_StateMachineStateIDParameter, new_StateIDParameter, new_NextStateIDParameter, new_NextInputStringParameter);
        }

        public virtual int Status_Insert(Status status, ObjectParameter statusID)
        {
            var new_StatusNameParameter = status.StatusName != null ?
                new ObjectParameter("New_StatusName", status.StatusName) :
                new ObjectParameter("New_StatusName", typeof(string));

            var new_DescriptionParameter = status.Description != null ?
                new ObjectParameter("New_Description", status.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", status.IsSystem);

            return ObjectContext.ExecuteFunction("Status_Insert", new_StatusNameParameter, new_DescriptionParameter, statusID, new_IsSystemParameter);
        }

        public virtual int Status_Update(Status status)
        {
            var original_StatusIDParameter = status.StatusID > -1 ?
                new ObjectParameter("Original_StatusID", status.StatusID) :
                new ObjectParameter("Original_StatusID", typeof(long));

            var new_StatusNameParameter = status.StatusName != null ?
                new ObjectParameter("New_StatusName", status.StatusName) :
                new ObjectParameter("New_StatusName", typeof(string));

            var new_DescriptionParameter = status.Description != null ?
                new ObjectParameter("New_Description", status.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", status.IsSystem);

            return ObjectContext.ExecuteFunction("Status_Update", original_StatusIDParameter, new_StatusNameParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int SupplierDeliveryOptionPair_Insert(SupplierDeliveryOptionPair supplierDeliveryOptionPair, ObjectParameter supplierDeliveryOptionPairID) 
        {
            var new_supplierIDParamter = supplierDeliveryOptionPair.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", supplierDeliveryOptionPair.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));
            
            var new_DeliveryOptionID = supplierDeliveryOptionPair.DeliveryOptionID > -1 ?
                new ObjectParameter("New_DeliveryOptionID", supplierDeliveryOptionPair.DeliveryOptionID) :
                new ObjectParameter("New_DeliveryOptionID", typeof(long));

            var new_DeliveryCharges = supplierDeliveryOptionPair.DeliveryCharges > -1 ?
                new ObjectParameter("New_DeliveryCharges", supplierDeliveryOptionPair.DeliveryCharges) :
                new ObjectParameter("New_DeliveryCharges", 0);

            var new_MinOrderLimit = supplierDeliveryOptionPair.MinOrderLimit > -1 ?
                new ObjectParameter("New_MinOrderLimit", supplierDeliveryOptionPair.MinOrderLimit) :
                new ObjectParameter("New_MinOrderLimit", 0);

            var new_SurroundingCitiesIDs = supplierDeliveryOptionPair.SurroundingCitiesIDs != null ?
                new ObjectParameter("New_SurroundingCitiesIDs", supplierDeliveryOptionPair.SurroundingCitiesIDs) :
                new ObjectParameter("New_SurroundingCitiesIDs", typeof(string));

            var new_StatusIDParameter = supplierDeliveryOptionPair.StatusID > -1 ?
                new ObjectParameter("New_StatusID", supplierDeliveryOptionPair.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var spProfileIDParameter = supplierDeliveryOptionPair.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplierDeliveryOptionPair.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "SupplierDeliveryOptionPair_Insert",
                new_supplierIDParamter,
                new_DeliveryOptionID,
                new_DeliveryCharges,
                new_MinOrderLimit,
                new_SurroundingCitiesIDs,
                supplierDeliveryOptionPairID,
                new_StatusIDParameter,
                spProfileIDParameter
                );
        }

        public virtual int SupplierDeliveryOptionPair_Update(SupplierDeliveryOptionPair supplierDeliveryOptionPair)
        {
            var original_SupplierDeliveryOptionPairID = supplierDeliveryOptionPair.SupplierDeliveryOptionPairID > -1 ?
                new ObjectParameter("Original_SupplierDeliveryOptionPairID", supplierDeliveryOptionPair.SupplierDeliveryOptionPairID) :
                new ObjectParameter("Original_SupplierDeliveryOptionPairID", typeof(long));

            var new_supplierIDParamter = supplierDeliveryOptionPair.SupplierID > -1 ?
                new ObjectParameter("New_SupplierID", supplierDeliveryOptionPair.SupplierID) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_DeliveryOptionID = supplierDeliveryOptionPair.DeliveryOptionID > -1 ?
                new ObjectParameter("New_DeliveryOptionID", supplierDeliveryOptionPair.DeliveryOptionID) :
                new ObjectParameter("New_DeliveryOptionID", typeof(long));

            var new_DeliveryCharges = supplierDeliveryOptionPair.DeliveryCharges > -1 ?
                new ObjectParameter("New_DeliveryCharges", supplierDeliveryOptionPair.DeliveryCharges) :
                new ObjectParameter("New_DeliveryCharges", 0);

            var new_MinOrderLimit = supplierDeliveryOptionPair.MinOrderLimit > -1 ?
                new ObjectParameter("New_MinOrderLimit", supplierDeliveryOptionPair.MinOrderLimit) :
                new ObjectParameter("New_MinOrderLimit", 0);

            var new_SurroundingCitiesIDs = supplierDeliveryOptionPair.SurroundingCitiesIDs != null ?
                new ObjectParameter("New_SurroundingCitiesIDs", supplierDeliveryOptionPair.SurroundingCitiesIDs) :
                new ObjectParameter("New_SurroundingCitiesIDs", typeof(string));

            var new_StatusIDParameter = supplierDeliveryOptionPair.StatusID > -1 ?
                new ObjectParameter("New_StatusID", supplierDeliveryOptionPair.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var spProfileIDParameter = supplierDeliveryOptionPair.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplierDeliveryOptionPair.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplierDeliveryOptionPair.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplierDeliveryOptionPair.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "SupplierDeliveryOptionPair_Update",
                original_SupplierDeliveryOptionPairID,
                new_supplierIDParamter,
                new_DeliveryOptionID,
                new_DeliveryCharges,
                new_MinOrderLimit,
                new_SurroundingCitiesIDs,
                new_StatusIDParameter,
                spProfileIDParameter,
                lastModifiedDateTimeParameter
                );
        }

        public virtual int Schedule_Insert(Schedule schedule, ObjectParameter out_ScheduleIDParameter)
        {
            //var out_ScheduleIDParameter = new ObjectParameter("Original_ScheduleID", typeof(long));

            var new_SupplierIDParameter = schedule.SupplierID.HasValue ?
                new ObjectParameter("New_SupplierID", schedule.SupplierID.Value) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_ScheduleTypeIDParameter = schedule.ScheduleTypeID.HasValue ?
                new ObjectParameter("New_ScheduleTypeID", schedule.ScheduleTypeID.Value) :
                new ObjectParameter("New_ScheduleTypeID", typeof(long));

            var new_IsExceptionParameter = new ObjectParameter("New_IsException", schedule.IsException);

            var new_FromDayParameter = schedule.FromDay.HasValue ?
                new ObjectParameter("New_FromDay", schedule.FromDay.Value) :
                new ObjectParameter("New_FromDay", typeof(System.Int16));

            var new_ToDayParameter = schedule.ToDay.HasValue ?
                new ObjectParameter("New_ToDay", schedule.ToDay.Value) :
                new ObjectParameter("New_ToDay", typeof(System.Int16));

            var new_MonthParameter = schedule.Month != null ?
                new ObjectParameter("New_Month", schedule.Month) :
                new ObjectParameter("New_Month", typeof(Int16));

            var new_MonthDayParameter = schedule.MonthDay != null ?
                new ObjectParameter("New_MonthDay", schedule.MonthDay) :
                new ObjectParameter("New_MonthDay", typeof(Int16));

            var new_WeekDaysParameter = schedule.WeekDays != null ?
                new ObjectParameter("New_WeekDays", schedule.WeekDays) :
                new ObjectParameter("New_WeekDays", typeof(string));

            var new_StatusIDParameter = schedule.StatusID.HasValue ?
                new ObjectParameter("New_StatusID", schedule.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_NotesParameter = schedule.Notes != null ?
                new ObjectParameter("New_Notes", schedule.Notes) :
                new ObjectParameter("New_Notes", typeof(string));

            var spProfileIDParameter = new ObjectParameter("SpProfileID", schedule.LastModifiedByUserID);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Schedule_Insert",
                new_SupplierIDParameter,
                new_ScheduleTypeIDParameter,
                new_IsExceptionParameter,
                new_FromDayParameter,
                new_ToDayParameter,
                new_MonthParameter,
                new_MonthDayParameter,
                new_WeekDaysParameter,
                new_StatusIDParameter,
                new_NotesParameter,
                spProfileIDParameter,
                out_ScheduleIDParameter);
        }

        public virtual int Schedule_Update(Schedule schedule)
        {            
            //Nullable<long> original_ScheduleID, Nullable<long> new_ProfileID, Nullable<long> new_ScheduleTypeID, Nullable<bool> new_IsException, Nullable<System.DateTime> new_FromDate, Nullable<System.DateTime> new_ToDate, string new_WeekDays, Nullable<long> new_StatusID, string new_Notes, Nullable<System.DateTime> lastModifiedDateTime
            var original_ScheduleIDParameter = new ObjectParameter("Original_ScheduleID", schedule.ScheduleID);

            var new_SupplierIDParameter = schedule.SupplierID.HasValue?
                new ObjectParameter("New_SupplierID", schedule.SupplierID.Value) :
                new ObjectParameter("New_SupplierID", typeof(long));

            var new_ScheduleTypeIDParameter = schedule.ScheduleTypeID.HasValue ?
                new ObjectParameter("New_ScheduleTypeID", schedule.ScheduleTypeID.Value) :
                new ObjectParameter("New_ScheduleTypeID", typeof(long));

            var new_IsExceptionParameter = new ObjectParameter("New_IsException", schedule.IsException);

            var new_FromDayParameter = schedule.FromDay.HasValue ?
                new ObjectParameter("New_FromDay", schedule.FromDay.Value) :
                new ObjectParameter("New_FromDay", typeof(System.Int16));

            var new_ToDayParameter = schedule.ToDay.HasValue ?
                new ObjectParameter("New_ToDay", schedule.ToDay.Value) :
                new ObjectParameter("New_ToDay", typeof(System.Int16));

            var new_MonthParameter = schedule.Month != null ?
                new ObjectParameter("New_Month", schedule.Month) :
                new ObjectParameter("New_Month", typeof(Int16));

            var new_MonthDayParameter = schedule.MonthDay != null ?
                new ObjectParameter("New_MonthDay", schedule.MonthDay) :
                new ObjectParameter("New_MonthDay", typeof(Int16));

            var new_WeekDaysParameter = schedule.WeekDays != null ?
                new ObjectParameter("New_WeekDays", schedule.WeekDays) :
                new ObjectParameter("New_WeekDays", typeof(string));

            var new_StatusIDParameter = schedule.StatusID.HasValue ?
                new ObjectParameter("New_StatusID", schedule.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_NotesParameter = schedule.Notes != null ?
                new ObjectParameter("New_Notes", schedule.Notes) :
                new ObjectParameter("New_Notes", typeof(string));

            var spProfileIDParameter = new ObjectParameter("SpProfileID", schedule.LastModifiedByUserID);

            var lastModifiedDateTimeParameter = new ObjectParameter("LastModifiedDateTime", schedule.LastModifiedDateTime);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Schedule_Update", 
                original_ScheduleIDParameter,
                new_SupplierIDParameter, 
                new_ScheduleTypeIDParameter, 
                new_IsExceptionParameter, 
                new_FromDayParameter, 
                new_ToDayParameter,
                new_MonthParameter,
                new_MonthDayParameter,
                new_WeekDaysParameter, 
                new_StatusIDParameter, 
                new_NotesParameter, 
                spProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Insert(Supplier supplier, ObjectParameter supplierID)
        {
            var new_SupplierNameParameter = supplier.SupplierName != null ?
                new ObjectParameter("New_SupplierName", supplier.SupplierName) :
                new ObjectParameter("New_SupplierName", typeof(string));

            var new_LogoParameter = supplier.Logo != null ?
                new ObjectParameter("New_Logo", supplier.Logo) :
                new ObjectParameter("New_Logo", typeof(string));

            var new_DescriptionParameter = supplier.Description != null ?
                new ObjectParameter("New_Description", supplier.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = supplier.StatusID > -1 ?
                new ObjectParameter("New_StatusID", supplier.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_StatusNotesParameter = supplier.StatusNotes != null ?
                new ObjectParameter("New_StatusNotes", supplier.StatusNotes) :
                new ObjectParameter("New_StatusNotes", typeof(string));

            var new_BusinessAddressIDParameter = supplier.BusinessAddressID > - 1 ?
                new ObjectParameter("New_BusinessAddressID", supplier.BusinessAddressID) :
                new ObjectParameter("New_BusinessAddressID", typeof(long));

            var new_IsBusinessAddressVisibleParameter = new ObjectParameter("New_IsBusinessAddressVisible", supplier.IsBusinessAddressVisible);

            var new_LanguageIDParameter = supplier.LanguageID.HasValue ?
                new ObjectParameter("New_LanguageID", supplier.LanguageID) :
                new ObjectParameter("New_LanguageID", typeof(long));

            var new_CurrencyIDParameter = supplier.CurrencyID.HasValue ?
                new ObjectParameter("New_CurrencyID", supplier.CurrencyID) :
                new ObjectParameter("New_CurrencyID", typeof(long));

            var new_CountryIDParameter = supplier.CountryID.HasValue ?
                new ObjectParameter("New_CountryID", supplier.CountryID) :
                new ObjectParameter("New_CountryID", typeof(long));

            var new_ProvinceIDParameter = supplier.ProvinceID.HasValue ?
                new ObjectParameter("New_ProvinceID", supplier.ProvinceID) :
                new ObjectParameter("New_ProvinceID", typeof(long));

            var new_CityIDParameter = supplier.CityID.HasValue ?
                new ObjectParameter("New_CityID", supplier.CityID) :
                new ObjectParameter("New_CityID", typeof(long));

            var new_IsCODParameter = supplier.IsCOD ?
                new ObjectParameter("New_IsCOD", supplier.IsCOD) :
                new ObjectParameter("New_IsCOD", false);

            var new_ProfileIDParameter = supplier.ProfileID > - 1 ?
                new ObjectParameter("New_ProfileID", supplier.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_ProcessingFeeParameter = new ObjectParameter("New_ProcessingFee", supplier.ProcessingFee);

            var new_PaymentGatewayFeeParameter = new ObjectParameter("New_PaymentGatewayFee", supplier.PaymentGatewayFee);

            var new_IsProcessingFeePercentageParameter = supplier.IsProcessingFeePercentage ?
                new ObjectParameter("New_IsProcessingFeePercentage", supplier.IsProcessingFeePercentage) :
                new ObjectParameter("New_IsProcessingFeePercentage", typeof(bool));

            var new_IsPaymentGatewayFeePercentageParameter = supplier.IsPaymentGatewayFeePercentage ?
                new ObjectParameter("New_IsPaymentGatewayFeePercentage", supplier.IsPaymentGatewayFeePercentage) :
                new ObjectParameter("New_IsPaymentGatewayFeePercentage", typeof(bool));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction(
                "Supplier_Insert", 
                new_SupplierNameParameter, 
                new_LogoParameter, 
                new_DescriptionParameter, 
                new_StatusIDParameter, 
                new_StatusNotesParameter, 
                new_BusinessAddressIDParameter, 
                new_IsBusinessAddressVisibleParameter, 
                new_LanguageIDParameter, 
                new_CurrencyIDParameter,
                new_CountryIDParameter,
                new_ProvinceIDParameter,
                new_CityIDParameter,
                new_IsCODParameter, 
                new_ProfileIDParameter, 
                new_ProcessingFeeParameter, 
                new_PaymentGatewayFeeParameter, 
                new_IsProcessingFeePercentageParameter, 
                new_IsPaymentGatewayFeePercentageParameter, 
                SpProfileIDParameter, 
                supplierID);
        }

        public virtual int Supplier_Update(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_SupplierNameParameter = supplier.SupplierName != null ?
                new ObjectParameter("New_SupplierName", supplier.SupplierName) :
                new ObjectParameter("New_SupplierName", typeof(string));

            var new_LogoParameter = supplier.Logo != null ?
                new ObjectParameter("New_Logo", supplier.Logo) :
                new ObjectParameter("New_Logo", typeof(string));

            var new_DescriptionParameter = supplier.Description != null ?
                new ObjectParameter("New_Description", supplier.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = supplier.StatusID > -1 ?
                new ObjectParameter("New_StatusID", supplier.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_StatusNotesParameter = supplier.StatusNotes != null ?
                new ObjectParameter("New_StatusNotes", supplier.StatusNotes) :
                new ObjectParameter("New_StatusNotes", typeof(string));

            var new_BusinessAddressIDParameter = supplier.BusinessAddressID > - 1 ?
                new ObjectParameter("New_BusinessAddressID", supplier.BusinessAddressID) :
                new ObjectParameter("New_BusinessAddressID", typeof(long));

            var new_IsBusinessAddressVisibleParameter = new ObjectParameter("New_IsBusinessAddressVisible", supplier.IsBusinessAddressVisible);

            var new_LanguageIDParameter = supplier.LanguageID.HasValue ?
                new ObjectParameter("New_LanguageID", supplier.LanguageID) :
                new ObjectParameter("New_LanguageID", typeof(long));

            var new_CurrencyIDParameter = supplier.CurrencyID.HasValue ?
                new ObjectParameter("New_CurrencyID", supplier.CurrencyID) :
                new ObjectParameter("New_CurrencyID", typeof(long));

            var new_CountryIDParameter = supplier.CountryID.HasValue ?
                new ObjectParameter("New_CountryID", supplier.CountryID) :
                new ObjectParameter("New_CountryID", typeof(long));

            var new_ProvinceIDParameter = supplier.ProvinceID.HasValue ?
                new ObjectParameter("New_ProvinceID", supplier.ProvinceID) :
                new ObjectParameter("New_ProvinceID", typeof(long));

            var new_CityIDParameter = supplier.CityID.HasValue ?
                new ObjectParameter("New_CityID", supplier.CityID) :
                new ObjectParameter("New_CityID", typeof(long));

            var new_IsCODParameter = supplier.IsCOD ?
                new ObjectParameter("New_IsCOD", supplier.IsCOD) :
                new ObjectParameter("New_IsCOD", false);

            var new_ProfileIDParameter = supplier.ProfileID > -1 ?
                new ObjectParameter("New_ProfileID", supplier.ProfileID) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_ProcessingFeeParameter = new ObjectParameter("New_ProcessingFee", supplier.ProcessingFee);

            var new_PaymentGatewayFeeParameter = new ObjectParameter("New_PaymentGatewayFee", supplier.PaymentGatewayFee);

            var new_IsProcessingFeePercentageParameter = new ObjectParameter("New_IsProcessingFeePercentage", supplier.IsProcessingFeePercentage);

            var new_IsPaymentGatewayFeePercentageParameter = new ObjectParameter("New_IsPaymentGatewayFeePercentage", supplier.IsPaymentGatewayFeePercentage);

            var new_AnnouncementHTMLParameter = !string.IsNullOrEmpty(supplier.AnnouncementHTML) ?
                new ObjectParameter("New_AnnouncementHTML", supplier.AnnouncementHTML) :
                new ObjectParameter("New_AnnouncementHTML", typeof(string));

            var new_AttributeRequestsParameter = !string.IsNullOrEmpty(supplier.AttributeRequests) ?
                new ObjectParameter("New_AttributeRequests", supplier.AttributeRequests) :
                new ObjectParameter("New_AttributeRequests", typeof(string));

            var new_CategoryRequestsParameter = !string.IsNullOrEmpty(supplier.CategoryRequests) ?
                new ObjectParameter("New_CategoryRequests", supplier.CategoryRequests) :
                new ObjectParameter("New_CategoryRequests", typeof(string));

            var new_FAQHTMLParameter = !string.IsNullOrEmpty(supplier.FAQHTML) ?
                new ObjectParameter("New_FAQHTML", supplier.FAQHTML) :
                new ObjectParameter("New_FAQHTML", typeof(string));

            var new_PolicyHTMLParameter = !string.IsNullOrEmpty(supplier.PolicyHTML) ?
                new ObjectParameter("New_PolicyHTML", supplier.PolicyHTML) :
                new ObjectParameter("New_PolicyHTML", typeof(string));

            var new_WebLinksJSONParameter = !string.IsNullOrEmpty(supplier.WebLinksJSON) ?
                new ObjectParameter("New_WebLinksJSON", supplier.WebLinksJSON) :
                new ObjectParameter("New_WebLinksJSON", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction(
                "Supplier_Update", 
                original_SupplierIDParameter, 
                new_SupplierNameParameter, 
                new_LogoParameter, 
                new_DescriptionParameter, 
                new_StatusIDParameter, 
                new_StatusNotesParameter, 
                new_BusinessAddressIDParameter, 
                new_IsBusinessAddressVisibleParameter, 
                new_LanguageIDParameter, 
                new_CurrencyIDParameter,
                new_CountryIDParameter,
                new_ProvinceIDParameter,
                new_CityIDParameter,
                new_IsCODParameter, 
                new_ProfileIDParameter, 
                new_ProcessingFeeParameter, 
                new_PaymentGatewayFeeParameter, 
                new_IsProcessingFeePercentageParameter, 
                new_IsPaymentGatewayFeePercentageParameter,

                new_AnnouncementHTMLParameter,
                new_AttributeRequestsParameter,
                new_CategoryRequestsParameter,
                new_FAQHTMLParameter,
                new_PolicyHTMLParameter,
                new_WebLinksJSONParameter,

                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }
        public virtual int Supplier_Update_AnnouncementHTML(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_AnnouncementHTMLParameter = !string.IsNullOrEmpty(supplier.AnnouncementHTML) ?
                new ObjectParameter("New_AnnouncementHTML", supplier.AnnouncementHTML) :
                new ObjectParameter("New_AnnouncementHTML", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_AnnouncementHTML", 
                original_SupplierIDParameter, 
                new_AnnouncementHTMLParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_AttributeRequests(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_AttributeRequestsParameter = !string.IsNullOrEmpty(supplier.AttributeRequests )?
                new ObjectParameter("New_AttributeRequests", supplier.AttributeRequests) :
                new ObjectParameter("New_AttributeRequests", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_AttributeRequests", 
                original_SupplierIDParameter, 
                new_AttributeRequestsParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_CategoryRequests(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_CategoryRequestsParameter = !string.IsNullOrEmpty(supplier.CategoryRequests) ?
                new ObjectParameter("New_CategoryRequests", supplier.CategoryRequests) :
                new ObjectParameter("New_CategoryRequests", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_CategoryRequests", 
                original_SupplierIDParameter, 
                new_CategoryRequestsParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_FAQHTML(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_FAQHTMLParameter = !string.IsNullOrEmpty(supplier.FAQHTML) ?
                new ObjectParameter("New_FAQHTML", supplier.CategoryRequests) :
                new ObjectParameter("New_FAQHTML", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_FAQHTML", 
                original_SupplierIDParameter, 
                new_FAQHTMLParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_PolicyHTML(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_PolicyHTMLParameter = !string.IsNullOrEmpty(supplier.PolicyHTML ) ?
                new ObjectParameter("New_PolicyHTML", supplier.PolicyHTML) :
                new ObjectParameter("New_PolicyHTML", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_PolicyHTML", 
                original_SupplierIDParameter, 
                new_PolicyHTMLParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_WebLinksJSON(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
               new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
               new ObjectParameter("Original_SupplierID", typeof(long));

            var new_WebLinksJSONParameter = !string.IsNullOrEmpty(supplier.WebLinksJSON ) ?
                new ObjectParameter("New_WebLinksJSON", supplier.WebLinksJSON) :
                new ObjectParameter("New_WebLinksJSON", typeof(string));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_WebLinksJSON", 
                original_SupplierIDParameter, 
                new_WebLinksJSONParameter, 
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        //Nullable<long> original_SupplierID, Nullable<bool> new_TaxConcent, string new_TaxRegistration, Nullable<long> spProfileID, Nullable<System.DateTime> lastModifiedDateTime
        public virtual int Supplier_Update_TaxInfo(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
                new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
                new ObjectParameter("Original_SupplierID", typeof(long));

            var new_TaxConcentParameter = new ObjectParameter("New_TaxConcent", supplier.TaxConcent);

            var new_TaxRegistrationParameter = supplier.TaxRegistration != null ?
                new ObjectParameter("New_TaxRegistration", supplier.TaxRegistration) :
                new ObjectParameter("New_TaxRegistration", typeof(string));

            var spProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Supplier_Update_TaxInfo", original_SupplierIDParameter, new_TaxConcentParameter, new_TaxRegistrationParameter, spProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int Supplier_Update_Details(Supplier supplier)
        {
            var original_SupplierIDParameter = supplier.SupplierID > -1 ?
                new ObjectParameter("Original_SupplierID", supplier.SupplierID) :
                new ObjectParameter("Original_SupplierID", typeof(long));

            var new_AnnouncementHTMLParameter = !string.IsNullOrEmpty(supplier.AnnouncementHTML)?
                new ObjectParameter("New_AnnouncementHTML", supplier.AnnouncementHTML) :
                new ObjectParameter("New_AnnouncementHTML", typeof(string));

            var new_LogoParameter = !string.IsNullOrEmpty(supplier.Logo)?
                new ObjectParameter("New_Logo", supplier.Logo) :
                new ObjectParameter("New_Logo", typeof(string));

            //var new_CategoryRequestsParameter = !string.IsNullOrEmpty(supplier.CategoryRequests )?
            //    new ObjectParameter("New_CategoryRequests", supplier.CategoryRequests) :
            //    new ObjectParameter("New_CategoryRequests", typeof(string));

            var new_FAQHTMLParameter = !string.IsNullOrEmpty(supplier.FAQHTML )?
                new ObjectParameter("New_FAQHTML", supplier.FAQHTML) :
                new ObjectParameter("New_FAQHTML", typeof(string));

            var new_PolicyHTMLParameter = !string.IsNullOrEmpty(supplier.PolicyHTML) ?
                new ObjectParameter("New_PolicyHTML", supplier.PolicyHTML) :
                new ObjectParameter("New_PolicyHTML", typeof(string));

            var new_WebLinksJSONParameter = !string.IsNullOrEmpty(supplier.WebLinksJSON )?
                new ObjectParameter("New_WebLinksJSON", supplier.WebLinksJSON) :
                new ObjectParameter("New_WebLinksJSON", typeof(string));

            var new_StatusIDParameter = supplier.StatusID > -1 ?
                new ObjectParameter("New_StatusID", supplier.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var SpProfileIDParameter = supplier.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", supplier.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = supplier.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", supplier.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Supplier_Update_Details", 
                original_SupplierIDParameter, 
                new_AnnouncementHTMLParameter,
                new_LogoParameter,
                //new_AttributeRequestsParameter, 
                //new_CategoryRequestsParameter, 
                new_FAQHTMLParameter, 
                new_PolicyHTMLParameter, 
                new_WebLinksJSONParameter,
                new_StatusIDParameter,
                SpProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Tax_Insert(Tax tax, ObjectParameter taxID)
        {
            var new_TaxValueParameter = tax.TaxValue > -1 ?
                new ObjectParameter("New_TaxValue", tax.TaxValue) :
                new ObjectParameter("New_TaxValue", typeof(double));

            var new_TaxTypeIDParameter = tax.TaxTypeID > -1 ?
                new ObjectParameter("New_TaxTypeID", tax.TaxTypeID) :
                new ObjectParameter("New_TaxTypeID", typeof(long));

            var new_DescriptionParameter = tax.Description != null ?
                new ObjectParameter("New_Description", tax.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = tax.StatusID > -1 ?
                new ObjectParameter("New_StatusID", tax.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsPercentageParameter = new ObjectParameter("New_IsPercentage", tax.IsPercentage);
            
            var new_LocationIDParameter = tax.LocationId > -1 ?
                new ObjectParameter("New_LocationID", tax.LocationId) :
                new ObjectParameter("New_LocationID", typeof(long));

            var new_LocationLevelIdParameter = tax.LocationLevelId > -1 ?
                new ObjectParameter("New_LocationLevelId", tax.LocationLevelId) :
                new ObjectParameter("New_LocationLevelId", typeof(long));

            var new_EffectiveDateParameter = tax.EffectiveDate != null ?
                new ObjectParameter("New_EffectiveDate", tax.EffectiveDate) :
                new ObjectParameter("New_EffectiveDate", typeof(System.DateTime));

            var SpProfileIdParameter = //tax.LastModifiedByUserID != null ?
                new ObjectParameter("SpProfileId", tax.LastModifiedByUserID); //:
            //  new ObjectParameter("SpProfileId", typeof(long));

            return ObjectContext.ExecuteFunction("Tax_Insert", new_TaxValueParameter, new_TaxTypeIDParameter, new_DescriptionParameter, new_StatusIDParameter, new_IsPercentageParameter, new_LocationIDParameter, new_LocationLevelIdParameter, new_EffectiveDateParameter, SpProfileIdParameter, taxID);
        }

        public virtual int Tax_Update(Tax tax)
        {
            var original_TaxIDParameter = tax.TaxID > -1 ?
                new ObjectParameter("Original_TaxID", tax.TaxID) :
                new ObjectParameter("Original_TaxID", typeof(long));

            var new_TaxValueParameter = tax.TaxValue > -1 ?
                new ObjectParameter("New_TaxValue", tax.TaxValue) :
                new ObjectParameter("New_TaxValue", typeof(double));

            var new_TaxTypeIDParameter = tax.TaxTypeID > -1 ?
                new ObjectParameter("New_TaxTypeID", tax.TaxTypeID) :
                new ObjectParameter("New_TaxTypeID", typeof(long));

            var new_DescriptionParameter = tax.Description != null ?
                new ObjectParameter("New_Description", tax.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_StatusIDParameter = tax.StatusID > -1 ?
                new ObjectParameter("New_StatusID", tax.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsPercentageParameter = new ObjectParameter("New_IsPercentage", tax.IsPercentage);

            var new_LocationIdParameter = tax.LocationId > -1 ?
                new ObjectParameter("New_LocationId", tax.LocationId) :
                new ObjectParameter("New_LocationId", typeof(long));
            var new_LocationLevelIdParameter = tax.LocationLevelId > -1 ?
                new ObjectParameter("New_LocationLevelId", tax.LocationLevelId) :
                new ObjectParameter("New_LocationLevelId", typeof(long));

            var new_EffectiveDateParameter = tax.EffectiveDate != null ?
                new ObjectParameter("New_EffectiveDate", tax.EffectiveDate) :
                new ObjectParameter("New_EffectiveDate", typeof(System.DateTime));

            var new_LastModifiedDateTimeParameter = tax.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("New_LastModifiedDateTime", tax.LastModifiedDateTime) :
                new ObjectParameter("New_LastModifiedDateTime", typeof(System.DateTime));

            var SpProfileIdParameter = //tax.LastModifiedByUserID != null ?
                  new ObjectParameter("SpProfileId", tax.LastModifiedByUserID); //:
            //  new ObjectParameter("SpProfileId", typeof(long));

            return ObjectContext.ExecuteFunction("Tax_Update", original_TaxIDParameter, new_TaxValueParameter, new_TaxTypeIDParameter, new_DescriptionParameter, new_StatusIDParameter, new_IsPercentageParameter, new_LocationIdParameter, new_LocationLevelIdParameter, new_EffectiveDateParameter, new_LastModifiedDateTimeParameter, SpProfileIdParameter);
        }

        public virtual int TaxType_Insert(TaxType taxType, ObjectParameter taxTypeID)
        {
            var new_TaxTypeTitleParameter = taxType.TaxTypeTitle != null ?
                new ObjectParameter("New_TaxTypeTitle", taxType.TaxTypeTitle) :
                new ObjectParameter("New_TaxTypeTitle", typeof(string));

            var new_DescriptionParameter = taxType.Description != null ?
                new ObjectParameter("New_Description", taxType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", taxType.IsSystem);

            return ObjectContext.ExecuteFunction("TaxType_Insert", new_TaxTypeTitleParameter, new_DescriptionParameter, taxTypeID, new_IsSystemParameter);
        }

        public virtual int TaxType_Update(TaxType taxType)
        {
            var original_TaxTypeIDParameter = taxType.TaxTypeID > -1 ?
                new ObjectParameter("Original_TaxTypeID", taxType.TaxTypeID) :
                new ObjectParameter("Original_TaxTypeID", typeof(long));

            var new_TaxTypeTitleParameter = taxType.TaxTypeTitle != null ?
                new ObjectParameter("New_TaxTypeTitle", taxType.TaxTypeTitle) :
                new ObjectParameter("New_TaxTypeTitle", typeof(string));

            var new_DescriptionParameter = taxType.Description != null ?
                new ObjectParameter("New_Description", taxType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", taxType.IsSystem);

            return ObjectContext.ExecuteFunction("TaxType_Update", original_TaxTypeIDParameter, new_TaxTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int User_Insert(User user, ObjectParameter userID)
        {
            var new_UserNameParameter = user.UserName != null ?
                new ObjectParameter("New_UserName", user.UserName) :
                new ObjectParameter("New_UserName", typeof(string));

            var new_UserPasswordParameter = user.UserPassword != null ?
                new ObjectParameter("New_UserPassword", user.UserPassword) :
                new ObjectParameter("New_UserPassword", typeof(string));

            var new_UseremailParameter = user.Useremail != null ?
                new ObjectParameter("New_Useremail", user.Useremail) :
                new ObjectParameter("New_Useremail", typeof(string));

            var new_PasswordResetCodeParameter = user.PasswordResetCode != null ?
                new ObjectParameter("New_PasswordResetCode", user.PasswordResetCode) :
                new ObjectParameter("New_PasswordResetCode", typeof(string));

            var new_AcvtivationGUIDParameter = user.AcvtivationGUID != null ?
                new ObjectParameter("New_AcvtivationGUID", user.AcvtivationGUID) :
                new ObjectParameter("New_AcvtivationGUID", typeof(string));

            var new_StatusIDParameter = user.StatusID > -1 ?
                new ObjectParameter("New_StatusID", user.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsLoggedInParameter = new ObjectParameter("New_IsLoggedIn", user.IsLoggedIn);

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", user.IsSystem);

            var new_GroupIDParameter = user.GroupID > -1 ?
                new ObjectParameter("New_GroupID", user.GroupID) :
                new ObjectParameter("New_GroupID", typeof(long));

            var SpProfileIDParameter = user.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", user.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ObjectContext.ExecuteFunction("User_Insert", new_UserNameParameter, new_UserPasswordParameter, new_UseremailParameter, new_PasswordResetCodeParameter, new_AcvtivationGUIDParameter, new_StatusIDParameter, new_IsLoggedInParameter, new_IsSystemParameter, new_GroupIDParameter, SpProfileIDParameter, userID);
        }

        public virtual int User_Update(User user)
        {
            var original_UserIDParameter = user.UserID > -1 ?
                new ObjectParameter("Original_UserID", user.UserID) :
                new ObjectParameter("Original_UserID", typeof(long));

            var new_UserNameParameter = user.UserName != null ?
                new ObjectParameter("New_UserName", user.UserName) :
                new ObjectParameter("New_UserName", typeof(string));

            var new_UserPasswordParameter = user.UserPassword != null ?
                new ObjectParameter("New_UserPassword", user.UserPassword) :
                new ObjectParameter("New_UserPassword", typeof(string));

            var new_UseremailParameter = user.Useremail != null ?
                new ObjectParameter("New_Useremail", user.Useremail) :
                new ObjectParameter("New_Useremail", typeof(string));

            var new_PasswordResetCodeParameter = user.PasswordResetCode != null ?
                new ObjectParameter("New_PasswordResetCode", user.PasswordResetCode) :
                new ObjectParameter("New_PasswordResetCode", typeof(string));

            var new_AcvtivationGUIDParameter = user.AcvtivationGUID != null ?
                new ObjectParameter("New_AcvtivationGUID", user.AcvtivationGUID) :
                new ObjectParameter("New_AcvtivationGUID", typeof(string));

            var new_StatusIDParameter = user.StatusID > -1 ?
                new ObjectParameter("New_StatusID", user.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_IsLoggedInParameter = new ObjectParameter("New_IsLoggedIn", user.IsLoggedIn);


            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", user.IsSystem);


            var new_GroupIDParameter = user.GroupID > -1 ?
                new ObjectParameter("New_GroupID", user.GroupID) :
                new ObjectParameter("New_GroupID", typeof(long));

            var SpProfileIDParameter = user.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", user.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = user.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", user.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ObjectContext.ExecuteFunction("User_Update", original_UserIDParameter, new_UserNameParameter, new_UserPasswordParameter, new_UseremailParameter, new_PasswordResetCodeParameter, new_AcvtivationGUIDParameter, new_StatusIDParameter, new_IsLoggedInParameter, new_IsSystemParameter, new_GroupIDParameter, SpProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int UserType_Insert(UserType userType, ObjectParameter userTypeID)
        {
            var new_UserTypeTitleParameter = userType.UserTypeTitle != null ?
                new ObjectParameter("New_UserTypeTitle", userType.UserTypeTitle) :
                new ObjectParameter("New_UserTypeTitle", typeof(string));

            var new_DescriptionParameter = userType.Description != null ?
                new ObjectParameter("New_Description", userType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", userType.IsSystem);

            return ObjectContext.ExecuteFunction("UserType_Insert", new_UserTypeTitleParameter, new_DescriptionParameter, userTypeID, new_IsSystemParameter);
        }

        public virtual int UserType_Update(UserType userType)
        {
            var original_UserTypeIDParameter = userType.UserTypeID > -1 ?
                new ObjectParameter("Original_UserTypeID", userType.UserTypeID) :
                new ObjectParameter("Original_UserTypeID", typeof(long));

            var new_UserTypeTitleParameter = userType.UserTypeTitle != null ?
                new ObjectParameter("New_UserTypeTitle", userType.UserTypeTitle) :
                new ObjectParameter("New_UserTypeTitle", typeof(string));

            var new_DescriptionParameter = userType.Description != null ?
                new ObjectParameter("New_Description", userType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", userType.IsSystem);

            return ObjectContext.ExecuteFunction("UserType_Update", original_UserTypeIDParameter, new_UserTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int custom_UpdateTableStatus(string tableName, Nullable<int> statusID)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));

            var statusIDParameter = statusID.HasValue ?
                new ObjectParameter("StatusID", statusID) :
                new ObjectParameter("StatusID", typeof(long));

            return ObjectContext.ExecuteFunction("UpdateTableStatus", tableNameParameter, statusIDParameter);
        }

        public virtual int ProductCategoryPair_Insert(ProductCategoryPair productCategoryPair, ObjectParameter productCategoryPairID)
        {
            var new_ProductIDParameter = productCategoryPair.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productCategoryPair.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_CategoryIDParameter = productCategoryPair.CategoryID > -1 ?
                new ObjectParameter("New_CategoryID", productCategoryPair.CategoryID) :
                new ObjectParameter("New_CategoryID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductCategoryPair_Insert", new_ProductIDParameter, new_CategoryIDParameter, productCategoryPairID);
        }

        public virtual int ProductCategoryPair_Update(ProductCategoryPair productCategoryPair)
        {
            var original_ProductCategoryPairIDParameter = productCategoryPair.ProductCategoryPairID > -1 ?
                new ObjectParameter("Original_ProductCategoryPairID", productCategoryPair.ProductCategoryPairID) :
                new ObjectParameter("Original_ProductCategoryPairID", typeof(long));

            var new_ProductIDParameter = productCategoryPair.ProductID > -1 ?
                new ObjectParameter("New_ProductID", productCategoryPair.ProductID) :
                new ObjectParameter("New_ProductID", typeof(long));

            var new_CategoryIDParameter = productCategoryPair.CategoryID > -1 ?
                new ObjectParameter("New_CategoryID", productCategoryPair.CategoryID) :
                new ObjectParameter("New_CategoryID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductCategoryPair_Update", original_ProductCategoryPairIDParameter, new_ProductIDParameter, new_CategoryIDParameter);
        }

        public virtual int AttributeType_Insert(AttributeType attributeType, ObjectParameter attributeTypeID)
        {
            var new_AttributeTypeTitleParameter = attributeType.AttributeTypeTitle != null ?
                new ObjectParameter("New_AttributeTypeTitle", attributeType.AttributeTypeTitle) :
                new ObjectParameter("New_AttributeTypeTitle", typeof(string));

            var new_DescriptionParameter = attributeType.Description != null ?
                new ObjectParameter("New_Description", attributeType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", attributeType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AttributeType_Insert", new_AttributeTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter, attributeTypeID);
        }

        public virtual int AttributeType_Update(AttributeType attributeType)
        {
            var original_AttributeTypeIDParameter = attributeType.AttributeTypeID > -1 ?
                new ObjectParameter("Original_AttributeTypeID", attributeType.AttributeTypeID) :
                new ObjectParameter("Original_AttributeTypeID", typeof(long));

            var new_AttributeTypeTitleParameter = attributeType.AttributeTypeTitle != null ?
                new ObjectParameter("New_AttributeTypeTitle", attributeType.AttributeTypeTitle) :
                new ObjectParameter("New_AttributeTypeTitle", typeof(string));

            var new_DescriptionParameter = attributeType.Description != null ?
                new ObjectParameter("New_Description", attributeType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", attributeType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AttributeType_Update", original_AttributeTypeIDParameter, new_AttributeTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int DocumentType_Insert(DocumentType documentType, ObjectParameter documentTypeID)
        {
            var new_DocumentTypeTitleParameter = documentType.DocumentTypeTitle != null ?
                new ObjectParameter("New_DocumentTypeTitle", documentType.DocumentTypeTitle) :
                new ObjectParameter("New_DocumentTypeTitle", typeof(string));

            var new_DescriptionParameter = documentType.Description != null ?
                new ObjectParameter("New_Description", documentType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", documentType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DocumentType_Insert", new_DocumentTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter, documentTypeID);
        }

        public virtual int DocumentType_Update(DocumentType documentType)
        {
            var original_DocumentTypeIDParameter = documentType.DocumentTypeID > -1 ?
                new ObjectParameter("Original_DocumentTypeID", documentType.DocumentTypeID) :
                new ObjectParameter("Original_DocumentTypeID", typeof(long));

            var new_DocumentTypeTitleParameter = documentType.DocumentTypeTitle != null ?
                new ObjectParameter("New_DocumentTypeTitle", documentType.DocumentTypeTitle) :
                new ObjectParameter("New_DocumentTypeTitle", typeof(string));

            var new_DescriptionParameter = documentType.Description != null ?
                new ObjectParameter("New_Description", documentType.Description) :
                new ObjectParameter("New_Description", typeof(string));
            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", documentType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DocumentType_Update", original_DocumentTypeIDParameter, new_DocumentTypeTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int AddressContactInfoPair_Insert(AddressContactInfoPair addressContactInfoPair, ObjectParameter addressContactInfoPairID)
        {
            var new_AddressIDParameter = addressContactInfoPair.AddressID > -1 ?
                new ObjectParameter("New_AddressID", addressContactInfoPair.AddressID) :
                new ObjectParameter("New_AddressID", typeof(long));

            var new_ContactInfoIDParameter = addressContactInfoPair.ContactInfoID > -1 ?
                new ObjectParameter("New_ContactInfoID", addressContactInfoPair.ContactInfoID) :
                new ObjectParameter("New_ContactInfoID", typeof(long));

            var new_IsPrimaryParameter = new ObjectParameter("New_IsPrimary", addressContactInfoPair.IsPrimary);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddressContactInfoPair_Insert", new_AddressIDParameter, new_ContactInfoIDParameter, new_IsPrimaryParameter, addressContactInfoPairID);
        }

        public virtual int AddressContactInfoPair_Update(AddressContactInfoPair addressContactInfoPair)
        {
            var original_AddressContactInfoPairIDParameter = addressContactInfoPair.AddressContactInfoPairID > -1 ?
                new ObjectParameter("Original_AddressContactInfoPairID", addressContactInfoPair.AddressContactInfoPairID) :
                new ObjectParameter("Original_AddressContactInfoPairID", typeof(long));

            var new_AddressIDParameter = addressContactInfoPair.AddressID > -1 ?
                new ObjectParameter("New_AddressID", addressContactInfoPair.AddressID) :
                new ObjectParameter("New_AddressID", typeof(long));

            var new_ContactInfoIDParameter = addressContactInfoPair.ContactInfoID > -1 ?
                new ObjectParameter("New_ContactInfoID", addressContactInfoPair.ContactInfoID) :
                new ObjectParameter("New_ContactInfoID", typeof(long));

            var new_IsPrimaryParameter = new ObjectParameter("New_IsPrimary", addressContactInfoPair.IsPrimary);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddressContactInfoPair_Update", original_AddressContactInfoPairIDParameter, new_AddressIDParameter, new_ContactInfoIDParameter, new_IsPrimaryParameter);
        }

        public virtual int ContactInfo_Insert(ContactInfo contactInfo, ObjectParameter contactInfoID)
        {
            var new_ContactInfoParameter = contactInfo.ContactInfo1 != null ?
                new ObjectParameter("New_ContactInfo", contactInfo.ContactInfo1) :
                new ObjectParameter("New_ContactInfo", typeof(string));

            var new_ContactPersonParameter = string.IsNullOrEmpty(contactInfo.ContactPerson) == false ?
                new ObjectParameter("New_ContactPerson", contactInfo.ContactPerson) :
                new ObjectParameter("New_ContactPerson", typeof(string));

            var new_ContactTypeIDParameter = contactInfo.ContactTypeID > -1 ?
                new ObjectParameter("New_ContactTypeID", contactInfo.ContactTypeID) :
                new ObjectParameter("New_ContactTypeID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ContactInfo_Insert", new_ContactInfoParameter, new_ContactPersonParameter, new_ContactTypeIDParameter, contactInfoID);
        }

        public virtual int ContactInfo_Update(ContactInfo contactInfo)
        {
            var original_ContactInfoIDParameter = contactInfo.ContactInfoID > -1 ?
                new ObjectParameter("Original_ContactInfoID", contactInfo.ContactInfoID) :
                new ObjectParameter("Original_ContactInfoID", typeof(long));

            var new_ContactInfoParameter = contactInfo.ContactInfo1 != null ?
                new ObjectParameter("New_ContactInfo", contactInfo.ContactInfo1) :
                new ObjectParameter("New_ContactInfo", typeof(string));

            var new_ContactPersonParameter = string.IsNullOrEmpty(contactInfo.ContactPerson) == false ?
                new ObjectParameter("New_ContactPerson", contactInfo.ContactPerson) :
                new ObjectParameter("New_ContactPerson", typeof(string));

            var new_ContactTypeIDParameter = contactInfo.ContactTypeID > -1 ?
                new ObjectParameter("New_ContactTypeID", contactInfo.ContactTypeID) :
                new ObjectParameter("New_ContactTypeID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ContactInfo_Update", original_ContactInfoIDParameter, new_ContactInfoParameter, new_ContactPersonParameter, new_ContactTypeIDParameter);
        }

        public virtual int ContactType_Insert(ContactType contactType, ObjectParameter contactTypeID)
        {
            var new_TitleParameter = string.IsNullOrEmpty(contactType.Title) != false ?
                new ObjectParameter("New_Title", contactType.Title) :
                new ObjectParameter("New_Title", typeof(string));

            var new_DescriptionParameter = contactType.Description != null ?
                new ObjectParameter("New_Description", contactType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", contactType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ContactType_Insert", new_TitleParameter, new_DescriptionParameter, new_IsSystemParameter, contactTypeID);
        }

        public virtual int ContactType_Update(ContactType contactType)
        {
            var original_ContactTypeIDParameter = contactType.ContactTypeID > -1 ?
                new ObjectParameter("Original_ContactTypeID", contactType.ContactTypeID) :
                new ObjectParameter("Original_ContactTypeID", typeof(long));

            var new_TitleParameter = string.IsNullOrEmpty(contactType.Title) != false ?
                new ObjectParameter("New_Title", contactType.Title) :
                new ObjectParameter("New_Title", typeof(string));

            var new_DescriptionParameter = contactType.Description != null ?
                new ObjectParameter("New_Description", contactType.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", contactType.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ContactType_Update", original_ContactTypeIDParameter, new_TitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }
        public virtual int Country_Insert(Country country, ObjectParameter countryID)
        {
            var new_NameParameter = country.Name != null ?
                new ObjectParameter("New_Name", country.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_AllowsBillingParameter = new ObjectParameter("New_AllowsBilling", country.AllowsBilling);//bool value

            var new_AllowsShippingParameter = new ObjectParameter("New_AllowsShipping", country.AllowsShipping);//bool value

            var new_TwoLetterIsoCodeParameter = country.TwoLetterIsoCode != null ?
                new ObjectParameter("New_TwoLetterIsoCode", country.TwoLetterIsoCode) :
                new ObjectParameter("New_TwoLetterIsoCode", typeof(string));

            var new_ThreeLetterIsoCodeParameter = country.ThreeLetterIsoCode != null ?
                new ObjectParameter("New_ThreeLetterIsoCode", country.ThreeLetterIsoCode) :
                new ObjectParameter("New_ThreeLetterIsoCode", typeof(string));

            var new_NumericIsoCodeParameter = country.NumericIsoCode > -1 ?
                new ObjectParameter("New_NumericIsoCode", country.NumericIsoCode) :
                new ObjectParameter("New_NumericIsoCode", typeof(long));

            var new_SubjectToVatParameter = new ObjectParameter("New_SubjectToVat", country.SubjectToVat);

            var new_PublishedParameter = new ObjectParameter("New_Published", country.Published);

            var new_DisplayOrderParameter = country.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", country.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(long));

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", country.LimitedToStores);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Country_Insert", new_NameParameter, new_AllowsBillingParameter, new_AllowsShippingParameter, new_TwoLetterIsoCodeParameter, new_ThreeLetterIsoCodeParameter, new_NumericIsoCodeParameter, new_SubjectToVatParameter, new_PublishedParameter, new_DisplayOrderParameter, new_LimitedToStoresParameter, countryID);
        }

        public virtual int Country_Update(Country country)
        {
            var original_IdParameter = country.Id > -1 ?
                new ObjectParameter("Original_Id", country.Id) :
                new ObjectParameter("Original_Id", typeof(long));

            var new_NameParameter = country.Name != null ?
               new ObjectParameter("New_Name", country.Name) :
               new ObjectParameter("New_Name", typeof(string));

            var new_AllowsBillingParameter = new ObjectParameter("New_AllowsBilling", country.AllowsBilling);//bool value

            var new_AllowsShippingParameter = new ObjectParameter("New_AllowsShipping", country.AllowsShipping);//bool value

            var new_TwoLetterIsoCodeParameter = country.TwoLetterIsoCode != null ?
                new ObjectParameter("New_TwoLetterIsoCode", country.TwoLetterIsoCode) :
                new ObjectParameter("New_TwoLetterIsoCode", typeof(string));

            var new_ThreeLetterIsoCodeParameter = country.ThreeLetterIsoCode != null ?
                new ObjectParameter("New_ThreeLetterIsoCode", country.ThreeLetterIsoCode) :
                new ObjectParameter("New_ThreeLetterIsoCode", typeof(string));

            var new_NumericIsoCodeParameter = country.NumericIsoCode > -1 ?
                new ObjectParameter("New_NumericIsoCode", country.NumericIsoCode) :
                new ObjectParameter("New_NumericIsoCode", typeof(long));

            var new_SubjectToVatParameter = new ObjectParameter("New_SubjectToVat", country.SubjectToVat);

            var new_PublishedParameter = new ObjectParameter("New_Published", country.Published);

            var new_DisplayOrderParameter = country.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", country.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(long));

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", country.LimitedToStores);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Country_Update", original_IdParameter, new_NameParameter, new_AllowsBillingParameter, new_AllowsShippingParameter, new_TwoLetterIsoCodeParameter, new_ThreeLetterIsoCodeParameter, new_NumericIsoCodeParameter, new_SubjectToVatParameter, new_PublishedParameter, new_DisplayOrderParameter, new_LimitedToStoresParameter);
        }

        public virtual int Currency_Insert(Currency currency, ObjectParameter id)
        {
            var new_NameParameter = currency.Name != null ?
                new ObjectParameter("New_Name", currency.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_CurrencyCodeParameter = currency.CurrencyCode != null ?
                new ObjectParameter("New_CurrencyCode", currency.CurrencyCode) :
                new ObjectParameter("New_CurrencyCode", typeof(string));

            var new_RateParameter = currency.Rate > -1 ?
                new ObjectParameter("New_Rate", currency.Rate) :
                new ObjectParameter("New_Rate", typeof(decimal));

            var new_DisplayLocaleParameter = currency.DisplayLocale != null ?
                new ObjectParameter("New_DisplayLocale", currency.DisplayLocale) :
                new ObjectParameter("New_DisplayLocale", typeof(string));

            var new_CustomFormattingParameter = currency.CustomFormatting != null ?
                new ObjectParameter("New_CustomFormatting", currency.CustomFormatting) :
                new ObjectParameter("New_CustomFormatting", typeof(string));

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", currency.LimitedToStores);

            var new_PublishedParameter = new ObjectParameter("New_Published", currency.Published);

            var new_DisplayOrderParameter = currency.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", currency.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            var new_RoundingTypeIdParameter = currency.RoundingTypeId > -1 ?
                new ObjectParameter("New_RoundingTypeId", currency.RoundingTypeId) :
                new ObjectParameter("New_RoundingTypeId", typeof(long));

            var spProfileIDParameter = currency.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", currency.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Currency_Insert", new_NameParameter, new_CurrencyCodeParameter, new_RateParameter, new_DisplayLocaleParameter, new_CustomFormattingParameter, new_LimitedToStoresParameter, new_PublishedParameter, new_DisplayOrderParameter, new_RoundingTypeIdParameter, spProfileIDParameter, id);
        }

        public virtual int Currency_Update(Currency currency)
        {
            var original_IdParameter = currency.CurrencyId > -1 ?
                new ObjectParameter("Original_Id", currency.CurrencyId) :
                new ObjectParameter("Original_Id", typeof(int));

            var new_NameParameter = currency.Name != null ?
                new ObjectParameter("New_Name", currency.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_CurrencyCodeParameter = currency.CurrencyCode != null ?
                new ObjectParameter("New_CurrencyCode", currency.CurrencyCode) :
                new ObjectParameter("New_CurrencyCode", typeof(string));

            var new_RateParameter = currency.Rate > -1 ?
                new ObjectParameter("New_Rate", currency.Rate) :
                new ObjectParameter("New_Rate", typeof(decimal));

            var new_DisplayLocaleParameter = currency.DisplayLocale != null ?
                new ObjectParameter("New_DisplayLocale", currency.DisplayLocale) :
                new ObjectParameter("New_DisplayLocale", typeof(string));

            var new_CustomFormattingParameter = currency.CustomFormatting != null ?
                new ObjectParameter("New_CustomFormatting", currency.CustomFormatting) :
                new ObjectParameter("New_CustomFormatting", typeof(string));

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", currency.LimitedToStores);

            var new_PublishedParameter = new ObjectParameter("New_Published", currency.Published);

            var new_DisplayOrderParameter = currency.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", currency.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            var new_RoundingTypeIdParameter = currency.RoundingTypeId > -1 ?
                new ObjectParameter("New_RoundingTypeId", currency.RoundingTypeId) :
                new ObjectParameter("New_RoundingTypeId", typeof(int));

            var spProfileIDParameter = currency.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", currency.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = currency.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", currency.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Currency_Update", original_IdParameter, new_NameParameter, new_CurrencyCodeParameter, new_RateParameter, new_DisplayLocaleParameter, new_CustomFormattingParameter, new_LimitedToStoresParameter, new_PublishedParameter, new_DisplayOrderParameter, new_RoundingTypeIdParameter, spProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int CustomerReview_Insert(CustomerReview customerReview, ObjectParameter attributeID)
        {
            var new_SubjectRowIDParameter = customerReview.SubjectRowID > -1 ?
                new ObjectParameter("New_SubjectRowID", customerReview.SubjectRowID) :
                new ObjectParameter("New_SubjectRowID", typeof(long));

            var new_SubjectIDParameter = customerReview.SubjectID > -1 ?
                new ObjectParameter("New_SubjectID", customerReview.SubjectID) :
                new ObjectParameter("New_SubjectID", typeof(long));

            var new_ReviewTextParameter = !string.IsNullOrEmpty(customerReview.ReviewText) ?
                new ObjectParameter("New_ReviewText", customerReview.ReviewText) :
                new ObjectParameter("New_ReviewText", typeof(string));

            var new_RatingParameter = customerReview.Rating > -1 ?
                new ObjectParameter("New_Rating", customerReview.Rating) :
                new ObjectParameter("New_Rating", typeof(short));

            var new_StatusIDParameter = customerReview.StatusID > -1 ?
                new ObjectParameter("New_StatusID", customerReview.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var spProfileIDParameter = customerReview.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", customerReview.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "CustomerReview_Insert", 
                new_SubjectRowIDParameter, 
                new_SubjectIDParameter, 
                new_ReviewTextParameter, 
                new_RatingParameter, 
                new_StatusIDParameter, 
                spProfileIDParameter, attributeID);
        }

        public virtual int CustomerReview_Update(CustomerReview customerReview)
        {
            var original_CustomerReviewIDParameter = customerReview.CustomerReviewID > -1 ?
                new ObjectParameter("Original_CustomerReviewID", customerReview.CustomerReviewID) :
                new ObjectParameter("Original_CustomerReviewID", typeof(long));

            var new_SubjectRowIDParameter = customerReview.SubjectRowID > -1 ?
                new ObjectParameter("New_SubjectRowID", customerReview.SubjectRowID) :
                new ObjectParameter("New_SubjectRowID", typeof(long));

            var new_SubjectIDParameter = customerReview.SubjectID > -1 ?
                new ObjectParameter("New_SubjectID", customerReview.SubjectID) :
                new ObjectParameter("New_SubjectID", typeof(long));

            var new_ReviewTextParameter = !string.IsNullOrEmpty(customerReview.ReviewText) ?
                new ObjectParameter("New_ReviewText", customerReview.ReviewText) :
                new ObjectParameter("New_ReviewText", typeof(string));

            var new_RatingParameter = customerReview.Rating > -1 ?
                new ObjectParameter("New_Rating", customerReview.Rating) :
                new ObjectParameter("New_Rating", typeof(short));

            var new_StatusIDParameter = customerReview.StatusID > -1 ?
                new ObjectParameter("New_StatusID", customerReview.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var spProfileIDParameter = customerReview.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", customerReview.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = customerReview.LastModifiedDateTime != null ?
                new ObjectParameter("LastModifiedDateTime", customerReview.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "CustomerReview_Update", 
                original_CustomerReviewIDParameter,
                new_SubjectRowIDParameter,
                new_SubjectIDParameter,
                new_ReviewTextParameter,
                new_RatingParameter,
                new_StatusIDParameter, 
                spProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int Language_Insert(Language language, ObjectParameter id)
        {
            var new_NameParameter = language.Name != null ?
                new ObjectParameter("New_Name", language.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_LanguageCultureParameter = language.LanguageCulture != null ?
                new ObjectParameter("New_LanguageCulture", language.LanguageCulture) :
                new ObjectParameter("New_LanguageCulture", typeof(string));

            var new_UniqueSeoCodeParameter = language.UniqueSeoCode != null ?
                new ObjectParameter("New_UniqueSeoCode", language.UniqueSeoCode) :
                new ObjectParameter("New_UniqueSeoCode", typeof(string));

            var new_FlagImageFileNameParameter = language.FlagImageFileName != null ?
                new ObjectParameter("New_FlagImageFileName", language.FlagImageFileName) :
                new ObjectParameter("New_FlagImageFileName", typeof(string));

            var new_RtlParameter = new ObjectParameter("New_Rtl", language.Rtl);

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", language.LimitedToStores);

            var new_DefaultCurrencyIdParameter = language.DefaultCurrencyId > -1 ?
                new ObjectParameter("New_DefaultCurrencyId", language.DefaultCurrencyId) :
                new ObjectParameter("New_DefaultCurrencyId", typeof(int));

            var new_PublishedParameter = new ObjectParameter("New_Published", language.Published);

            var new_DisplayOrderParameter = language.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", language.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Language_Insert", new_NameParameter, new_LanguageCultureParameter, new_UniqueSeoCodeParameter, new_FlagImageFileNameParameter, new_RtlParameter, new_LimitedToStoresParameter, new_DefaultCurrencyIdParameter, new_PublishedParameter, new_DisplayOrderParameter, id);
        }

        public virtual int Language_Update(Language language)
        {
            var original_IdParameter = language.Id > -1 ?
                new ObjectParameter("Original_Id", language.Id) :
                new ObjectParameter("Original_Id", typeof(int));

            var new_NameParameter = language.Name != null ?
                new ObjectParameter("New_Name", language.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_LanguageCultureParameter = language.LanguageCulture != null ?
                new ObjectParameter("New_LanguageCulture", language.LanguageCulture) :
                new ObjectParameter("New_LanguageCulture", typeof(string));

            var new_UniqueSeoCodeParameter = language.UniqueSeoCode != null ?
                new ObjectParameter("New_UniqueSeoCode", language.UniqueSeoCode) :
                new ObjectParameter("New_UniqueSeoCode", typeof(string));

            var new_FlagImageFileNameParameter = language.FlagImageFileName != null ?
                new ObjectParameter("New_FlagImageFileName", language.FlagImageFileName) :
                new ObjectParameter("New_FlagImageFileName", typeof(string));

            var new_RtlParameter = new ObjectParameter("New_Rtl", language.Rtl);

            var new_LimitedToStoresParameter = new ObjectParameter("New_LimitedToStores", language.LimitedToStores);

            var new_DefaultCurrencyIdParameter = language.DefaultCurrencyId > -1 ?
                new ObjectParameter("New_DefaultCurrencyId", language.DefaultCurrencyId) :
                new ObjectParameter("New_DefaultCurrencyId", typeof(int));

            var new_PublishedParameter = new ObjectParameter("New_Published", language.Published);

            var new_DisplayOrderParameter = language.DisplayOrder > -1 ?
                new ObjectParameter("New_DisplayOrder", language.DisplayOrder) :
                new ObjectParameter("New_DisplayOrder", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Language_Update", original_IdParameter, new_NameParameter, new_LanguageCultureParameter, new_UniqueSeoCodeParameter, new_FlagImageFileNameParameter, new_RtlParameter, new_LimitedToStoresParameter, new_DefaultCurrencyIdParameter, new_PublishedParameter, new_DisplayOrderParameter);
        }

        public virtual int LocaleStringResource_Insert(LocaleStringResource localeStringResouce, ObjectParameter id)
        {
            var new_LanguageIdParameter = localeStringResouce.LanguageId > -1 ?
                new ObjectParameter("New_LanguageId", localeStringResouce.LanguageId) :
                new ObjectParameter("New_LanguageId", typeof(int));

            var new_ResourceNameParameter = localeStringResouce.ResourceName != null ?
                new ObjectParameter("New_ResourceName", localeStringResouce.ResourceName) :
                new ObjectParameter("New_ResourceName", typeof(string));

            var new_ResourceValueParameter = localeStringResouce.ResourceValue != null ?
                new ObjectParameter("New_ResourceValue", localeStringResouce.ResourceValue) :
                new ObjectParameter("New_ResourceValue", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LocaleStringResource_Insert", new_LanguageIdParameter, new_ResourceNameParameter, new_ResourceValueParameter, id);
        }

        public virtual int LocaleStringResource_Update(LocaleStringResource localeStringResouce)
        {
            var original_IdParameter = localeStringResouce.Id > -1 ?
                new ObjectParameter("Original_Id", localeStringResouce.Id) :
                new ObjectParameter("Original_Id", typeof(long));

            var new_LanguageIdParameter = localeStringResouce.LanguageId > -1 ?
                new ObjectParameter("New_LanguageId", localeStringResouce.LanguageId) :
                new ObjectParameter("New_LanguageId", typeof(int));

            var new_ResourceNameParameter = localeStringResouce.ResourceName != null ?
                new ObjectParameter("New_ResourceName", localeStringResouce.ResourceName) :
                new ObjectParameter("New_ResourceName", typeof(string));

            var new_ResourceValueParameter = localeStringResouce.ResourceValue != null ?
                new ObjectParameter("New_ResourceValue", localeStringResouce.ResourceValue) :
                new ObjectParameter("New_ResourceValue", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LocaleStringResource_Update", original_IdParameter, new_LanguageIdParameter, new_ResourceNameParameter, new_ResourceValueParameter);
        }

        public virtual int LocalizedProperty_Insert(LocalizedProperty localizedProperty, ObjectParameter id)
        {
            var new_EntityIdParameter = localizedProperty.EntityId > -1 ?
                new ObjectParameter("New_EntityId", localizedProperty.EntityId) :
                new ObjectParameter("New_EntityId", typeof(int));

            var new_LanguageIdParameter = localizedProperty.LanguageId > -1 ?
                new ObjectParameter("New_LanguageId", localizedProperty.LanguageId) :
                new ObjectParameter("New_LanguageId", typeof(int));

            var new_LocaleKeyGroupParameter = localizedProperty.LocaleKeyGroup != null ?
                new ObjectParameter("New_LocaleKeyGroup", localizedProperty.LocaleKeyGroup) :
                new ObjectParameter("New_LocaleKeyGroup", typeof(string));

            var new_LocaleKeyParameter = localizedProperty.LocaleKey != null ?
                new ObjectParameter("New_LocaleKey", localizedProperty.LocaleKey) :
                new ObjectParameter("New_LocaleKey", typeof(string));

            var new_LocaleValueParameter = localizedProperty.LocaleValue != null ?
                new ObjectParameter("New_LocaleValue", localizedProperty.LocaleValue) :
                new ObjectParameter("New_LocaleValue", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LocalizedProperty_Insert", new_EntityIdParameter, new_LanguageIdParameter, new_LocaleKeyGroupParameter, new_LocaleKeyParameter, new_LocaleValueParameter, id);
        }

        public virtual int LocalizedProperty_Update(LocalizedProperty localizedProperty)
        {
            var original_IdParameter = localizedProperty.Id > -1 ?
                new ObjectParameter("Original_Id", localizedProperty.Id) :
                new ObjectParameter("Original_Id", typeof(long));

            var new_EntityIdParameter = localizedProperty.EntityId > -1 ?
                 new ObjectParameter("New_EntityId", localizedProperty.EntityId) :
                 new ObjectParameter("New_EntityId", typeof(int));

            var new_LanguageIdParameter = localizedProperty.LanguageId > -1 ?
                new ObjectParameter("New_LanguageId", localizedProperty.LanguageId) :
                new ObjectParameter("New_LanguageId", typeof(int));

            var new_LocaleKeyGroupParameter = localizedProperty.LocaleKeyGroup != null ?
                new ObjectParameter("New_LocaleKeyGroup", localizedProperty.LocaleKeyGroup) :
                new ObjectParameter("New_LocaleKeyGroup", typeof(string));

            var new_LocaleKeyParameter = localizedProperty.LocaleKey != null ?
                new ObjectParameter("New_LocaleKey", localizedProperty.LocaleKey) :
                new ObjectParameter("New_LocaleKey", typeof(string));

            var new_LocaleValueParameter = localizedProperty.LocaleValue != null ?
                new ObjectParameter("New_LocaleValue", localizedProperty.LocaleValue) :
                new ObjectParameter("New_LocaleValue", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LocalizedProperty_Update", original_IdParameter, new_EntityIdParameter, new_LanguageIdParameter, new_LocaleKeyGroupParameter, new_LocaleKeyParameter, new_LocaleValueParameter);
        }

        public virtual int Log_Insert(Log log, ObjectParameter id)
        {
            var new_LogLevelIdParameter = log.LogLevelId > -1 ?
                new ObjectParameter("New_LogLevelId", log.LogLevelId) :
                new ObjectParameter("New_LogLevelId", typeof(int));

            var new_ShortMessageParameter = log.ShortMessage != null ?
                new ObjectParameter("New_ShortMessage", log.ShortMessage) :
                new ObjectParameter("New_ShortMessage", typeof(string));

            var new_FullMessageParameter = log.FullMessage != null ?
                new ObjectParameter("New_FullMessage", log.FullMessage) :
                new ObjectParameter("New_FullMessage", typeof(string));

            var new_IpAddressParameter = log.IpAddress != null ?
                new ObjectParameter("New_IpAddress", log.IpAddress) :
                new ObjectParameter("New_IpAddress", typeof(string));

            var new_CustomerIdParameter = log.CustomerId > -1 ?
                new ObjectParameter("New_CustomerId", log.CustomerId) :
                new ObjectParameter("New_CustomerId", typeof(int));

            var new_PageUrlParameter = log.PageUrl != null ?
                new ObjectParameter("New_PageUrl", log.PageUrl) :
                new ObjectParameter("New_PageUrl", typeof(string));

            var new_ReferrerUrlParameter = log.ReferrerUrl != null ?
                new ObjectParameter("New_ReferrerUrl", log.ReferrerUrl) :
                new ObjectParameter("New_ReferrerUrl", typeof(string));

            var spProfileIDParameter = log.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", log.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Log_Insert", new_LogLevelIdParameter, new_ShortMessageParameter, new_FullMessageParameter, new_IpAddressParameter, new_CustomerIdParameter, new_PageUrlParameter, new_ReferrerUrlParameter, spProfileIDParameter, id);
        }

        public virtual int Log_Update(Log log)
        {
            var original_IdParameter = log.Id > -1 ?
                new ObjectParameter("Original_Id", log.Id) :
                new ObjectParameter("Original_Id", typeof(long));

            var new_LogLevelIdParameter = log.LogLevelId > -1 ?
                new ObjectParameter("New_LogLevelId", log.LogLevelId) :
                new ObjectParameter("New_LogLevelId", typeof(int));

            var new_ShortMessageParameter = log.ShortMessage != null ?
                new ObjectParameter("New_ShortMessage", log.ShortMessage) :
                new ObjectParameter("New_ShortMessage", typeof(string));

            var new_FullMessageParameter = log.FullMessage != null ?
                new ObjectParameter("New_FullMessage", log.FullMessage) :
                new ObjectParameter("New_FullMessage", typeof(string));

            var new_IpAddressParameter = log.IpAddress != null ?
                new ObjectParameter("New_IpAddress", log.IpAddress) :
                new ObjectParameter("New_IpAddress", typeof(string));

            var new_CustomerIdParameter = log.CustomerId > -1 ?
                new ObjectParameter("New_CustomerId", log.CustomerId) :
                new ObjectParameter("New_CustomerId", typeof(int));

            var new_PageUrlParameter = log.PageUrl != null ?
                new ObjectParameter("New_PageUrl", log.PageUrl) :
                new ObjectParameter("New_PageUrl", typeof(string));

            var new_ReferrerUrlParameter = log.ReferrerUrl != null ?
                new ObjectParameter("New_ReferrerUrl", log.ReferrerUrl) :
                new ObjectParameter("New_ReferrerUrl", typeof(string));

            var spProfileIDParameter = log.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", log.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = log.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("LastModifiedDateTime", log.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Log_Update", original_IdParameter, new_LogLevelIdParameter, new_ShortMessageParameter, new_FullMessageParameter, new_IpAddressParameter, new_CustomerIdParameter, new_PageUrlParameter, new_ReferrerUrlParameter, spProfileIDParameter, lastModifiedDateTimeParameter);
        }

        public virtual int OrderStatusMap_Insert(OrderStatusMap orderStatusMap, ObjectParameter orderStatusMapID)
        {
            var new_ParentOrderStatusIDParameter = orderStatusMap.ParentOrderStatusID > -1 ?
                new ObjectParameter("New_ParentOrderStatusID", orderStatusMap.ParentOrderStatusID) :
                new ObjectParameter("New_ParentOrderStatusID", typeof(long));

            var new_ChildOrderStatusIDParameter = orderStatusMap.ChildOrderStatusID > -1 ?
                new ObjectParameter("New_ChildOrderStatusID", orderStatusMap.ChildOrderStatusID) :
                new ObjectParameter("New_ChildOrderStatusID", typeof(long));

            var new_StatusIDParameter = orderStatusMap.StatusID > -1 ?
                new ObjectParameter("New_StatusID", orderStatusMap.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_DescriptionParameter = orderStatusMap.Description != null ?
                new ObjectParameter("New_Description", orderStatusMap.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsDefault = orderStatusMap.IsDefault ?
                new ObjectParameter("New_IsDefault", orderStatusMap.IsDefault) :
                new ObjectParameter("New_IsDefault", false);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OrderStatusMap_Insert", new_ParentOrderStatusIDParameter, new_ChildOrderStatusIDParameter, new_StatusIDParameter, new_DescriptionParameter, new_IsDefault, orderStatusMapID);
        }

        public virtual int OrderStatusMap_Update(OrderStatusMap orderStatusMap)
        {
            var original_OrderStatusMapIDParameter = orderStatusMap.OrderStatusMapID > -1 ?
                new ObjectParameter("Original_OrderStatusMapID", orderStatusMap.OrderStatusMapID) :
                new ObjectParameter("Original_OrderStatusMapID", typeof(long));

            var new_ParentOrderStatusIDParameter = orderStatusMap.ParentOrderStatusID > -1 ?
                new ObjectParameter("New_ParentOrderStatusID", orderStatusMap.ParentOrderStatusID) :
                new ObjectParameter("New_ParentOrderStatusID", typeof(long));

            var new_ChildOrderStatusIDParameter = orderStatusMap.ChildOrderStatusID > -1 ?
                new ObjectParameter("New_ChildOrderStatusID", orderStatusMap.ChildOrderStatusID) :
                new ObjectParameter("New_ChildOrderStatusID", typeof(long));

            var new_StatusIDParameter = orderStatusMap.StatusID > -1 ?
                new ObjectParameter("New_StatusID", orderStatusMap.StatusID) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_DescriptionParameter = orderStatusMap.Description != null ?
                new ObjectParameter("New_Description", orderStatusMap.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsDefault = orderStatusMap.IsDefault ?
                new ObjectParameter("New_IsDefault", orderStatusMap.IsDefault) :
                new ObjectParameter("New_IsDefault", false);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OrderStatusMap_Update", original_OrderStatusMapIDParameter, new_ParentOrderStatusIDParameter, new_ChildOrderStatusIDParameter, new_StatusIDParameter, new_DescriptionParameter, new_IsDefault);
        }

        public virtual int Payment_Insert(Payment payment, ObjectParameter paymentID)
        {
            var new_OrderIDParameter = payment.OrderID > -1?
                new ObjectParameter("New_OrderID", payment.OrderID) :
                new ObjectParameter("New_OrderID", typeof(long));

            var new_PayTypeIDParameter = payment.PayTypeID > -1?
                new ObjectParameter("New_PayTypeID", payment.PayTypeID) :
                new ObjectParameter("New_PayTypeID", typeof(long));

            var new_AmountParameter = payment.Amount > -1 ?
                new ObjectParameter("New_Amount", payment.Amount) :
                new ObjectParameter("New_Amount", typeof(double));

            var new_PaymentGatewayTransactionIDParameter = !string.IsNullOrEmpty(payment.PaymentGatewayTransactionID.Trim()) ?
                new ObjectParameter("New_PaymentGatewayTransactionID", payment.PaymentGatewayTransactionID.Trim()) :
                new ObjectParameter("New_PaymentGatewayTransactionID", typeof(string));

            var new_PaymentTokenParameter = !string.IsNullOrEmpty(payment.PaymentToken.Trim())?
                new ObjectParameter("New_PaymentToken", payment.PaymentToken.Trim()) :
                new ObjectParameter("New_PaymentToken", typeof(string));

            var new_IsAmountVerifiedParameter = new ObjectParameter("New_IsAmountVerified", payment.IsAmountVerified);

            var SpProfileIDParameter = payment.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", payment.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Payment_Insert",
                new_OrderIDParameter,
                new_PayTypeIDParameter,
                new_AmountParameter, 
                new_PaymentGatewayTransactionIDParameter, 
                new_PaymentTokenParameter, 
                new_IsAmountVerifiedParameter,
                SpProfileIDParameter,
                paymentID);
        }

        public virtual int Payment_Update(Payment payment)
        {
            var original_PaymentIDParameter = payment.PaymentID > -1 ?
                new ObjectParameter("Original_PaymentID", payment.PaymentID) :
                new ObjectParameter("Original_PaymentID", typeof(long));

            var new_OrderIDParameter = payment.OrderID > -1 ?
                new ObjectParameter("New_OrderID", payment.OrderID) :
                new ObjectParameter("New_OrderID", typeof(long));

            var new_PayTypeIDParameter = payment.PayTypeID > -1 ?
                new ObjectParameter("New_PayTypeID", payment.PayTypeID) :
                new ObjectParameter("New_PayTypeID", typeof(long));

            var new_AmountParameter = payment.Amount > -1 ?
                new ObjectParameter("New_Amount", payment.Amount) :
                new ObjectParameter("New_Amount", typeof(double));

            var new_PaymentGatewayTransactionIDParameter = payment.PaymentGatewayTransactionID != null ?
                new ObjectParameter("New_PaymentGatewayTransactionID", payment.PaymentGatewayTransactionID) :
                new ObjectParameter("New_PaymentGatewayTransactionID", typeof(string));

            var new_PaymentTokenParameter = payment.PaymentToken != null ?
                new ObjectParameter("New_PaymentToken", payment.PaymentToken) :
                new ObjectParameter("New_PaymentToken", typeof(string));

            var new_IsAmountVerifiedParameter = new ObjectParameter("New_IsAmountVerified", payment.IsAmountVerified);

            var SpProfileIDParameter = payment.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", payment.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var new_LastModifiedDateTimeParameter = payment.LastModifiedDateTime > DateTime.MinValue ?
                new ObjectParameter("New_LastModifiedDateTime", payment.LastModifiedDateTime) :
                new ObjectParameter("New_LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Payment_Update", 
                original_PaymentIDParameter,
                new_OrderIDParameter,
                new_PayTypeIDParameter,
                new_AmountParameter, 
                new_PaymentGatewayTransactionIDParameter, 
                new_PaymentTokenParameter, 
                new_IsAmountVerifiedParameter,
                SpProfileIDParameter,
                new_LastModifiedDateTimeParameter);
        }

        public virtual int PayOptionMatrix_Insert(PayOptionMatrix payOptionMatrix, ObjectParameter payOptionMatrixID)
        {
            var new_PayModeIDParameter = payOptionMatrix.PayModeID > -1 ?
                new ObjectParameter("New_PayModeID", payOptionMatrix.PayModeID) :
                new ObjectParameter("New_PayModeID", typeof(long));

            var new_PayTypeIDParameter = payOptionMatrix.PayTypeID > -1 ?
                new ObjectParameter("New_PayTypeID", payOptionMatrix.PayTypeID) :
                new ObjectParameter("New_PayTypeID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payOptionMatrix.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayOptionMatrix_Insert", new_PayModeIDParameter, new_PayTypeIDParameter, new_IsSystemParameter, payOptionMatrixID);
        }

        public virtual int PayOptionMatrix_Update(PayOptionMatrix payOptionMatrix)
        {
            var original_PayOptionMatrixIDParameter = payOptionMatrix.PayOptionMatrixID > -1 ?
                new ObjectParameter("Original_PayOptionMatrixID", payOptionMatrix.PayOptionMatrixID) :
                new ObjectParameter("Original_PayOptionMatrixID", typeof(long));

            var new_PayModeIDParameter = payOptionMatrix.PayModeID > -1 ?
               new ObjectParameter("New_PayModeID", payOptionMatrix.PayModeID) :
               new ObjectParameter("New_PayModeID", typeof(long));

            var new_PayTypeIDParameter = payOptionMatrix.PayTypeID > -1 ?
                new ObjectParameter("New_PayTypeID", payOptionMatrix.PayTypeID) :
                new ObjectParameter("New_PayTypeID", typeof(long));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", payOptionMatrix.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayOptionMatrix_Update", original_PayOptionMatrixIDParameter, new_PayModeIDParameter, new_PayTypeIDParameter, new_IsSystemParameter);
        }

        public virtual int SearchTerm_Insert(SearchTerm searchTerm, ObjectParameter id)
        {
            var new_KeywordParameter = searchTerm.Keyword != null ?
                new ObjectParameter("New_Keyword", searchTerm.Keyword) :
                new ObjectParameter("New_Keyword", typeof(string));

            var new_StoreIdParameter = searchTerm.StoreId > -1 ?
                new ObjectParameter("New_StoreId", searchTerm.StoreId) :
                new ObjectParameter("New_StoreId", typeof(long));

            var new_CountParameter = searchTerm.Count > -1 ?
                new ObjectParameter("New_Count", searchTerm.Count) :
                new ObjectParameter("New_Count", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SearchTerm_Insert", new_KeywordParameter, new_StoreIdParameter, new_CountParameter, id);
        }

        public virtual int SearchTerm_Update(SearchTerm searchTerm)
        {
            var original_IdParameter = searchTerm.Id > -1 ?
                new ObjectParameter("Original_Id", searchTerm.Id) :
                new ObjectParameter("Original_Id", typeof(long));

            var new_KeywordParameter = searchTerm.Keyword != null ?
                new ObjectParameter("New_Keyword", searchTerm.Keyword) :
                new ObjectParameter("New_Keyword", typeof(string));

            var new_StoreIdParameter = searchTerm.StoreId > -1 ?
                new ObjectParameter("New_StoreId", searchTerm.StoreId) :
                new ObjectParameter("New_StoreId", typeof(long));

            var new_CountParameter = searchTerm.Count > -1 ?
                new ObjectParameter("New_Count", searchTerm.Count) :
                new ObjectParameter("New_Count", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SearchTerm_Update", original_IdParameter, new_KeywordParameter, new_StoreIdParameter, new_CountParameter);
        }

        public virtual int VerificationStatus_Insert(VerificationStatus verificationStatus, ObjectParameter verificationStatusID)
        {
            var new_VerificationStatusTitleParameter = verificationStatus.VerificationStatusTitle != null ?
                new ObjectParameter("New_VerificationStatusTitle", verificationStatus.VerificationStatusTitle) :
                new ObjectParameter("New_VerificationStatusTitle", typeof(string));

            var new_DescriptionParameter = verificationStatus.Description != null ?
                new ObjectParameter("New_Description", verificationStatus.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", verificationStatus.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VerificationStatus_Insert", new_VerificationStatusTitleParameter, new_DescriptionParameter, new_IsSystemParameter, verificationStatusID);
        }

        public virtual int VerificationStatus_Update(VerificationStatus verificationStatus)
        {
            var original_VerificationStatusIDParameter = verificationStatus.VerificationStatusID > -1 ?
                new ObjectParameter("Original_VerificationStatusID", verificationStatus.VerificationStatusID) :
                new ObjectParameter("Original_VerificationStatusID", typeof(long));

            var new_VerificationStatusTitleParameter = verificationStatus.VerificationStatusTitle != null ?
                new ObjectParameter("New_VerificationStatusTitle", verificationStatus.VerificationStatusTitle) :
                new ObjectParameter("New_VerificationStatusTitle", typeof(string));

            var new_DescriptionParameter = verificationStatus.Description != null ?
                new ObjectParameter("New_Description", verificationStatus.Description) :
                new ObjectParameter("New_Description", typeof(string));

            var new_IsSystemParameter = new ObjectParameter("New_IsSystem", verificationStatus.IsSystem);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VerificationStatus_Update", original_VerificationStatusIDParameter, new_VerificationStatusTitleParameter, new_DescriptionParameter, new_IsSystemParameter);
        }

        public virtual int Chat_Insert(Chat entity, ObjectParameter chatID)
        {
            var new_ChatCodeParameter = entity.ChatCode != null ?
                new ObjectParameter("New_ChatCode", entity.ChatCode) :
                new ObjectParameter("New_ChatCode", typeof(string));

            var new_ProfileId1Parameter = new ObjectParameter("New_ProfileId1", entity.ProfileId1);

            var new_ProfileId2Parameter = new ObjectParameter("New_ProfileId2", entity.ProfileId2);

            var new_StatusIDParameter = new ObjectParameter("New_StatusID", entity.StatusId);

            var spProfileIDParameter = new ObjectParameter("SpProfileID", entity.LastModifiedByUserID);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Chat_Insert", 
                new_ChatCodeParameter, new_ProfileId1Parameter, 
                new_ProfileId2Parameter, 
                new_StatusIDParameter,
                spProfileIDParameter, 
                chatID);
        }

        public virtual int Chat_Update(Chat entity)
        {
            var original_ChatIDParameter = new ObjectParameter("Original_ChatID", entity.ChatId);

            var new_ChatCodeParameter = entity.ChatCode != null ?
                new ObjectParameter("New_ChatCode", entity.ChatCode) :
                new ObjectParameter("New_ChatCode", typeof(string));

            var new_ProfileId1Parameter = entity.ProfileId1> -1 ?
                new ObjectParameter("New_ProfileId1", entity.ProfileId1) :
                new ObjectParameter("New_ProfileId1", typeof(long));

            var new_ProfileId2Parameter = entity.ProfileId2 > -1?
                new ObjectParameter("New_ProfileId2", entity.ProfileId2) :
                new ObjectParameter("New_ProfileId2", typeof(long));

            var new_StatusIDParameter = entity.StatusId > -1 ?
                new ObjectParameter("New_StatusID", entity.StatusId) :
                new ObjectParameter("New_StatusID", typeof(long));

            var spProfileIDParameter = entity.LastModifiedByUserID  > -1? 
                new ObjectParameter("SpProfileID", entity.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = entity.LastModifiedDateTime != null?
                new ObjectParameter("LastModifiedDateTime", entity.LastModifiedDateTime) :
                new ObjectParameter("LastModifiedDateTime", typeof(System.DateTime));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Chat_Update", 
                original_ChatIDParameter, 
                new_ChatCodeParameter, 
                new_ProfileId1Parameter, 
                new_ProfileId2Parameter, 
                new_StatusIDParameter, 
                spProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }

        public virtual int ChatMessage_MarkRead(ChatMessage entity)
        {
            var original_ChatIDParameter = entity.ChatId > -1 ?
                new ObjectParameter("Original_ChatID", entity.ChatId) :
                new ObjectParameter("Original_ChatID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ChatMessage_MarkRead", original_ChatIDParameter);
        }
        public virtual int ChatMessage_MarkReadByProfileID(ChatMessage entity)
        {
            var original_ChatIDParameter = entity.ChatId > -1 ?
                new ObjectParameter("Original_ChatID", entity.ChatId) :
                new ObjectParameter("Original_ChatID", typeof(long));

            var original_ProfileIDParameter = entity.ChatId > -1 ?
                new ObjectParameter("Original_ProfileID", entity.ReceiverProfileId) :
                new ObjectParameter("Original_ProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ChatMessage_MarkReadByProfileID", original_ChatIDParameter, original_ProfileIDParameter);
        }

        public virtual int ChatMessage_SendMessage(ChatMessage entity, ObjectParameter chatMessageID)
        {
            var original_ChatIdParameter = entity.ChatId > -1 ?
                new ObjectParameter("Original_ChatId", entity.ChatId) :
                new ObjectParameter("Original_ChatId", typeof(long));

            var new_MessageCodeParameter = entity.MessageCode != null ?
                new ObjectParameter("New_MessageCode", entity.MessageCode) :
                new ObjectParameter("New_MessageCode", typeof(string));

            var new_SenderProfileIdParameter = entity.SenderProfileId > -1 ?
                new ObjectParameter("New_SenderProfileId", entity.SenderProfileId) :
                new ObjectParameter("New_SenderProfileId", typeof(long));

            var new_ReceiverProfileIdParameter = entity.ReceiverProfileId > -1 ?
                new ObjectParameter("New_ReceiverProfileId", entity.ReceiverProfileId) :
                new ObjectParameter("New_ReceiverProfileId", typeof(long));

            var new_MessageParameter = entity.Message != null ?
                new ObjectParameter("New_Message", entity.Message) :
                new ObjectParameter("New_Message", typeof(string));

            var new_StatusIDParameter = entity.StatusId > -1 ?
                new ObjectParameter("New_StatusID", entity.StatusId) :
                new ObjectParameter("New_StatusID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "ChatMessage_SendMessage", 
                original_ChatIdParameter, 
                new_MessageCodeParameter, 
                new_SenderProfileIdParameter, 
                new_ReceiverProfileIdParameter, 
                new_MessageParameter, 
                new_StatusIDParameter, 
                chatMessageID);
        }

        public virtual int BankAccount_Insert(BankAccount bank, ObjectParameter new_BankId)
        {
            var new_SupplierIdParameter = bank.SupplierId > -1?
                new ObjectParameter("New_SupplierId", bank.SupplierId) :
                new ObjectParameter("New_SupplierId", typeof(long));

            var new_NameParameter = bank.Name != null ?
                new ObjectParameter("New_Name", bank.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_AddressParameter = bank.Address != null ?
                new ObjectParameter("New_Address", bank.Address) :
                new ObjectParameter("New_Address", typeof(string));

            var new_AccountTitleParameter = bank.AccountTitle != null ?
                new ObjectParameter("New_AccountTitle", bank.AccountTitle) :
                new ObjectParameter("New_AccountTitle", typeof(string));

            var new_AccountNumberParameter = bank.AccountNumber != null ?
                new ObjectParameter("New_AccountNumber", bank.AccountNumber) :
                new ObjectParameter("New_AccountNumber", typeof(string));

            var new_IBANParameter = bank.IBAN != null ?
                new ObjectParameter("New_IBAN", bank.IBAN) :
                new ObjectParameter("New_IBAN", typeof(string));

            var new_TypeIdParameter = bank.AccountTypeId.HasValue ?
                new ObjectParameter("New_TypeId", bank.AccountTypeId) :
                new ObjectParameter("New_TypeId", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "BankAccount_Insert", 
                new_SupplierIdParameter,
                new_NameParameter,
                new_AddressParameter,
                new_AccountTitleParameter,
                new_AccountNumberParameter,
                new_IBANParameter, 
                new_BankId,
                new_TypeIdParameter);
        }

        public virtual int BankAccount_Update(BankAccount bank)
        {
            var original_BankIdParameter = bank.BankId > -1 ?
                new ObjectParameter("Original_BankId", bank.BankId) :
                new ObjectParameter("Original_BankId", typeof(int));

            var new_SupplierIdParameter = bank.SupplierId > -1 ?
                new ObjectParameter("New_SupplierId", bank.SupplierId) :
                new ObjectParameter("New_SupplierId", typeof(long));

            var new_NameParameter = bank.Name != null ?
                new ObjectParameter("New_Name", bank.Name) :
                new ObjectParameter("New_Name", typeof(string));

            var new_AddressParameter = bank.Address != null ?
                new ObjectParameter("New_Address", bank.Address) :
                new ObjectParameter("New_Address", typeof(string));

            var new_AccountTitleParameter = bank.AccountTitle != null ?
                new ObjectParameter("New_AccountTitle", bank.AccountTitle) :
                new ObjectParameter("New_AccountTitle", typeof(string));

            var new_AccountNumberParameter = bank.AccountNumber != null ?
                new ObjectParameter("New_AccountNumber", bank.AccountNumber) :
                new ObjectParameter("New_AccountNumber", typeof(string));

            var new_IBANParameter = bank.IBAN != null ?
                new ObjectParameter("New_IBAN", bank.IBAN) :
                new ObjectParameter("New_IBAN", typeof(string));

            var new_TypeIdParameter = bank.AccountTypeId.HasValue ?
                new ObjectParameter("New_TypeId", bank.AccountTypeId) :
                new ObjectParameter("New_TypeId", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "BankAccount_Update", 
                original_BankIdParameter, 
                new_SupplierIdParameter, 
                new_NameParameter, 
                new_AddressParameter, 
                new_AccountTitleParameter, 
                new_AccountNumberParameter, 
                new_IBANParameter, 
                new_TypeIdParameter);
        }

        public virtual int Notify_Insert(Notify notify, ObjectParameter notificationId)
        {
            var new_NotificationTypeParameter = notify.NotificationType > -1 ?
                new ObjectParameter("New_NotificationType", notify.NotificationType) :
                new ObjectParameter("New_NotificationType", typeof(long));

            var new_SenderProfileIdParameter = notify.SenderProfileId > -1 ?
                new ObjectParameter("New_SenderProfileId", notify.SenderProfileId) :
                new ObjectParameter("New_SenderProfileId", typeof(long));

            var new_ReceiverProfileIdParameter = notify.ReceiverProfileId > -1 ?
                new ObjectParameter("New_ReceiverProfileId", notify.ReceiverProfileId) :
                new ObjectParameter("New_ReceiverProfileId", typeof(long));

            var new_StatusIDParameter = notify.StatusId > -1 ?
                new ObjectParameter("New_StatusID", notify.StatusId) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_MessageParameter = notify.Message != null ?
                new ObjectParameter("New_Message", notify.Message) :
                new ObjectParameter("New_Message", typeof(string));

            var new_SubjectRowIDParameter = notify.SubjectRowID > -1 ?
                new ObjectParameter("New_SubjectRowID", notify.SubjectRowID) :
                new ObjectParameter("New_SubjectRowID", 0);

            var spProfileIDParameter = notify.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", notify.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Notify_Insert", 
                new_NotificationTypeParameter, 
                new_SenderProfileIdParameter, 
                new_ReceiverProfileIdParameter, 
                new_StatusIDParameter, 
                new_MessageParameter, 
                new_SubjectRowIDParameter,
                spProfileIDParameter, 
                notificationId);
        }

        public virtual int Notify_Update(Notify notify)
        {
            var original_NotificationIDParameter = notify.NotificationId > -1 ?
                new ObjectParameter("Original_NotificationID", notify.NotificationId) :
                new ObjectParameter("Original_NotificationID", typeof(long));

            var new_NotificationTypeParameter = notify.NotificationType > -1 ?
                new ObjectParameter("New_NotificationType", notify.NotificationType) :
                new ObjectParameter("New_NotificationType", typeof(long));

            var new_SenderProfileIdParameter = notify.SenderProfileId > -1 ?
                new ObjectParameter("New_SenderProfileId", notify.SenderProfileId) :
                new ObjectParameter("New_SenderProfileId", typeof(long));

            var new_ReceiverProfileIdParameter = notify.ReceiverProfileId > -1 ?
                new ObjectParameter("New_ReceiverProfileId", notify.ReceiverProfileId) :
                new ObjectParameter("New_ReceiverProfileId", typeof(long));

            var new_StatusIDParameter = notify.StatusId > -1 ?
                new ObjectParameter("New_StatusID", notify.StatusId) :
                new ObjectParameter("New_StatusID", typeof(long));

            var new_MessageParameter = notify.Message != null ?
                new ObjectParameter("New_Message", notify.Message) :
                new ObjectParameter("New_Message", typeof(string));

            var new_SubjectRowIDParameter = notify.SubjectRowID > -1 ?
                new ObjectParameter("New_SubjectRowID", notify.SubjectRowID) :
                new ObjectParameter("New_SubjectRowID", 0);

            var spProfileIDParameter = notify.LastModifiedByUserID > -1 ?
                new ObjectParameter("SpProfileID", notify.LastModifiedByUserID) :
                new ObjectParameter("SpProfileID", typeof(long));

            var lastModifiedDateTimeParameter = new ObjectParameter("LastModifiedDateTime", notify.LastModifiedDateTime);

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "Notify_Update", 
                original_NotificationIDParameter, 
                new_NotificationTypeParameter, 
                new_SenderProfileIdParameter, 
                new_ReceiverProfileIdParameter, 
                new_StatusIDParameter, 
                new_MessageParameter, 
                new_SubjectRowIDParameter,
                spProfileIDParameter, 
                lastModifiedDateTimeParameter);
        }
        public virtual int NotificationToken_Insert(NotificationToken entity, ObjectParameter new_TokenId)
        {
            var new_TokenParameter = !String.IsNullOrEmpty(entity.Token) ?
                new ObjectParameter("New_Token", entity.Token) :
                new ObjectParameter("New_Token", typeof(string));

            var new_DevicePlatformParameter = !String.IsNullOrEmpty(entity.DevicePlatform) ?
                new ObjectParameter("New_DevicePlatform", entity.DevicePlatform) :
                new ObjectParameter("New_DevicePlatform", typeof(string));

            var new_NotificationServiceParameter = !String.IsNullOrEmpty(entity.NotificationService )?
                new ObjectParameter("New_NotificationService", entity.NotificationService) :
                new ObjectParameter("New_NotificationService", typeof(string));

            var new_ProfileIDParameter = entity.ProfileId > -1 ?
                new ObjectParameter("New_ProfileID", entity.ProfileId) :
                new ObjectParameter("New_ProfileID", typeof(long));

            var new_DeviceIdParameter = !String.IsNullOrEmpty(entity.DeviceId ) ?
                new ObjectParameter("New_DeviceId", entity.DeviceId) :
                new ObjectParameter("New_DeviceId", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction(
                "NotificationToken_Insert", 
                new_TokenParameter, 
                new_DevicePlatformParameter, 
                new_NotificationServiceParameter, 
                new_ProfileIDParameter, 
                new_DeviceIdParameter, 
                new_TokenId);
        }

        //public virtual int NotificationToken_Update(ObjectParameter original_TokenId, Nullable<long> new_StatusId)
        //{
        //    var new_StatusIdParameter = new_StatusId.HasValue ?
        //        new ObjectParameter("New_StatusId", new_StatusId) :
        //        new ObjectParameter("New_StatusId", typeof(long));

        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NotificationToken_Update", original_TokenId, new_StatusIdParameter);
        //}

    }
}

