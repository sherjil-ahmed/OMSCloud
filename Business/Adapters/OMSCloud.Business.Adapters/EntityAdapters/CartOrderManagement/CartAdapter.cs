using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class CartAdapter 
    {
        #region Custom GETs
        public CartModel GetCurrentUserCart(long ProfileId)
        {
            if(ProfileId == 0)
            {
                string newValue =  Guid.NewGuid().ToString().Replace("-",string.Empty).Substring(0, 5);

                ProfileModel profile = new ProfileModel()
                {
                    UserID = DateTime.Now.Ticks,
                    UserName = newValue, //Anonymous User has random UserName/FirstName/LastName
                    EMail_2FA = false,
                    SMS_2FA = false,
                    FirstName = newValue,//Anonymous User has random UserName/FirstName/LastName
                    LastName = newValue,//Anonymous User has random UserName/FirstName/LastName
                    Nationality = "1",
                    //1 - indicate user is anonymous
                    //2 - indicate user is subscribed
                    PublicUserType = DBUserTypePublicEnum.Buyer,
                    UserTypeID = (long)DBUserTypeEnum.Buyer,
                    IsVerified = false
                };

                ProfileAdapter profileAdapter = new ProfileAdapter();
                long? vProfileId = profileAdapter.AddProfile(profile);
                if (vProfileId.HasValue)
                    ProfileId = vProfileId.Value;
            }

            var result = (from co in uow.OMSContext.CartOrder
                          join os in uow.OMSContext.OrderStatus on co.OrderStatusID equals os.OrderStatusID
                          where
                          co.OrderStatusID == (long)DBCartStatusEnum.NewCart
                          &&
                          co.BuyerProfileID == ProfileId
                          && 
                          co.StatusID >= (int)DBStatusEnum.Active && co.ParentCartID == null
                          select new CartModel
                          {
                              CartID = co.CartOrderID,
                              CartStatusID = co.OrderStatusID,
                              StatusID = co.StatusID,
                              BuyerProfileID = co.BuyerProfileID,
                              CartTotal = co.OrderTotal,
                              DiscountTotal = co.DiscountTotal,
                              TaxTotal = co.TaxTotal,
                              //UserName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                              RequestedByProfileId = ProfileId,
                              CreatedBy = co.CreatedByUserID,
                              CreatedOn = co.CreatedDateTime,
                              ModifiedBy = co.LastModifiedByUserID,
                              ModifiedOn = co.LastModifiedDateTime
                          }).OrderByDescending(r => r.CreatedOn).ToList();
            
            if (result != null && result.Count() > 0)
            {
                return result.First();
            }
            else
            {
                CartModel model = new CartModel()
                {
                    CartStatusID = (long)DBCartStatusEnum.NewCart,
                    BuyerProfileID = ProfileId,
                    CreatedBy = ProfileId,
                    CreatedOn = DateTime.Now,
                    RequestedByProfileId = ProfileId,
                    StatusID = (int)DBStatusEnum.Active
                };
                var cartId = AddCart(model);
                if (cartId.HasValue)
                {
                    model.CartID = cartId.Value;
                    return model;
                }
            }
            return null;
        }

        //
        public CartDetailModel GetCartDetails(long ProfileId)
        {
            var result = (from co in uow.OMSContext.CartOrder
                          join os in uow.OMSContext.OrderStatus on co.OrderStatusID equals os.OrderStatusID
                          where
                          co.OrderStatusID == (long)DBCartStatusEnum.NewCart
                          &&
                          co.BuyerProfileID == ProfileId
                          &&
                          (co.StatusID >= (int)DBStatusEnum.Active || co.StatusID >= (int)DBStatusEnum.New)
                          && co.ParentCartID == null
                          select new CartDetailModel
                          {
                              CartID = co.CartOrderID,
                              CartStatusID = co.OrderStatusID,
                              StatusID = co.StatusID,
                              BuyerProfileID = co.BuyerProfileID,
                              RequestedByProfileId = ProfileId,
                              CartStatus = os.OrderStatusTitle,
                              CartTotal = co.PaymentTotal,
                              DiscountTotal = co.DiscountTotal,
                              TaxTotal = co.TaxTotal,
                              CartItemList = (from i in uow.OMSContext.CartItem
                                             join s in uow.OMSContext.Status on i.StatusID equals s.StatusID
                                             where i.CartOrderID == co.CartOrderID && i.StatusID <= (int)DBStatusEnum.Active
                                             select new CartItemWithAttributesModel
                                             {
                                                 CartItemID = i.CartItemID,
                                                 CartOrderID = i.CartOrderID,
                                                 ProductID = i.ProductID,
                                                 ProductTitle = i.Product.ProductTitle,
                                                 ProductDefaultImage = i.Product.ProductMediaDetail.Where(m => m.Description.ToLower() == "default").Select(m => m.MediaFilePath).FirstOrDefault(),
                                                 ShopId = i.Product.SupplierID,
                                                 ShopName = i.Product.Supplier.SupplierName,
                                                 ShopCountryId = i.Product.Supplier.CountryID ?? -1,
                                                 ShopProvinceId = i.Product.Supplier.ProvinceID  ?? -1,
                                                 ShopCityId = i.Product.Supplier.CityID ?? -1,                                                 
                                                 ShopStatusId = i.Product.Supplier.StatusID,
                                                 ProductTypeId = i.Product.ProductTypeID,
                                                 ProductTypeTitle = i.Product.ProductType.ProductTypeTitle,
                                                 UnitPrice = i.UnitPrice,
                                                 Quantity = i.Quantity,
                                                 TaxTypeID = i.Product.TaxTypeID,
                                                 TaxAmount = i.TaxAmount,
                                                 TaxRateApplied = i.TaxRateApplied,
                                                 DiscountAmount = i.DiscountAmount,
                                                 DiscountValue = i.Product.DiscountValue ?? 0,
                                                 IsDiscountPercentage = i.Product.IsDiscountPercentage ?? true,
                                                 ExpectedDeliveryTime = i.Product.OrderResponseTime,
                                                 ExpectedDeliveryUnit = i.Product.OrderResponseTimeUnitID,
                                                 
                                                 ItemTotalPrice = i.ItemTotalPrice,
                                                 StatusID = i.StatusID,
                                                 StatusTitle = s.StatusName,
                                                 ModifiedOn = i.LastModifiedDateTime,
                                                 AttributeList = i.CartItemAttributePair.Select(a => new CartItemAttributePairModel()
                                                 {
                                                     AttributeID = a.AttributeID,
                                                     AttributeName = a.Attribute.AttributeTitle,
                                                     AttributeValue = a.AttributeValue,
                                                     AttributeTypeName = a.Attribute.AttributeType.AttributeTypeTitle,
                                                     AttributeTypeId = a.Attribute.AttributeTypeID,
                                                     VariationInPrice = a.VariationInPrice.HasValue ? a.VariationInPrice.Value : 0,
                                                     CartItemAttributeID = a.CartItemAttributeId,
                                                     CartItemID = a.CartItemID,
                                                 }).ToList(),
                                             }).ToList(),
                                            //OrderCount = 
                              CreatedBy = co.CreatedByUserID,
                              CreatedOn = co.CreatedDateTime,
                              ModifiedBy = co.LastModifiedByUserID,
                              ModifiedOn = co.LastModifiedDateTime
                          }).OrderByDescending(r => r.CreatedOn).ToList();
            
            if (result != null && result.Count() > 0)
            {
                var order = result.First();

                ProductAdapter pd = new ProductAdapter();

                List<Tax> listOfTax = pd.GetTaxInfo();

                foreach (CartItemWithAttributesModel item in order.CartItemList)
                {                    
                    ProductTaxInfoModel productTaxInfo = new ProductTaxInfoModel
                    {
                        ShopCityId = item.ShopCityId,
                        ShopProvinceId = item.ShopProvinceId,
                        ShopCountryId = item.ShopCountryId,
                        TaxTypeID = item.TaxTypeID,
                    };

                    pd.GetProductTaxInfo(productTaxInfo, listOfTax);
                    //item.IsTaxPercentage = productTaxInfo.IsTaxPercentage;
                    item.TaxRateApplied = productTaxInfo.TaxRateApplied;

                }

                return order;
            }
            else
            {
                CartDetailModel model = new CartDetailModel()
                {
                    CartStatusID = (long)DBCartStatusEnum.NewCart,
                    BuyerProfileID = ProfileId,
                    CartItemList = null,
                    CreatedBy = ProfileId,
                    CreatedOn = DateTime.Now,
                    RequestedByProfileId = ProfileId,
                    StatusID = (int)DBStatusEnum.Active
                };
                var cartId = AddCart(model);
                if (cartId.HasValue)
                {
                    model.CartID = cartId.Value;
                    return model;
                }
            }
            return null;
        }

        public List<CartExtendedModel> GetCartList()
        {
            return GetCartEnumeration().ToList();
        }

        public CartExtendedModel GetCartById(long Id)
        {
            return GetCartEnumeration().Where(c => c.CartID == Id).First();
        }

        private IEnumerable<CartExtendedModel> GetCartEnumeration()
        {
            return (from c in uow.OMSContext.CartOrder
                    join s in uow.OMSContext.Status on c.StatusID equals s.StatusID
                    join os in uow.OMSContext.OrderStatus on c.OrderStatusID equals os.OrderStatusID
                    join p in uow.OMSContext.Profile on c.BuyerProfileID equals p.ProfileID
                    join o in uow.OMSContext.CartOrder on c.CartOrderID equals o.ParentCartID into orderGroup
                    where c.ParentCartID == null
                    select new CartExtendedModel {
                        CartID = c.CartOrderID
                        , StatusID = c.StatusID
                        , Status = s.StatusName
                        , CartStatusID = c.OrderStatusID
                        , CartStatus = os.OrderStatusTitle
                        , BuyerProfileID = c.BuyerProfileID
                        , Buyer = p.FirstName + " " + p.LastName
                        , CartTotal = c.OrderTotal
                        , DiscountTotal = c.DiscountTotal
                        , TaxTotal = c.TaxTotal
                        , OrderCount = orderGroup.Count()
                        , CreatedBy = c.CreatedByUserID
                        , ModifiedBy = c.LastModifiedByUserID
                        , CreatedOn = c.CreatedDateTime
                        , ModifiedOn = c.LastModifiedDateTime
                    });
        }
        #endregion Custom GETs

        #region Private
        private CartModel GetCartModel(CartOrder cartOrder)
        {
            return new CartModel
            {
                CartID = cartOrder.CartOrderID,
                BuyerProfileID = cartOrder.BuyerProfileID,
                CartStatusID = cartOrder.OrderStatusID,
                StatusID = cartOrder.StatusID,
                CartTotal = cartOrder.OrderTotal,
                TaxTotal = cartOrder.TaxTotal,
                DiscountTotal = cartOrder.DiscountTotal,
            };
        }
        private CartOrder GetCartEntity(CartModel cartModel)
        {
            return new CartOrder
            {
                CartOrderID = cartModel.CartID,
                BuyerProfileID = cartModel.BuyerProfileID,
                OrderStatusID = cartModel.CartStatusID,
                StatusID = cartModel.StatusID,
                OrderTotal = cartModel.CartTotal,
                TaxTotal = cartModel.TaxTotal,
                DiscountTotal = cartModel.DiscountTotal,
            };
        }
        /*
        private IEnumerable<CartOrderComposedModel> GetCart()
        {
            var ci_group = from ci in uow.OMSContext.CartItem
                           group ci by ci.CartOrderID into g
                           select new { cartOrderId = g.Key, OrderSum = g.Sum(x => x.ItemTotalPrice * x.Quantity) };

            var result = from co in uow.OMSContext.CartOrder
                         join p in uow.OMSContext.Profile on co.BuyerProfileID equals p.ProfileID
                         join s in uow.OMSContext.Status on co.StatusID equals s.StatusID
                         join os in uow.OMSContext.OrderStatus on co.OrderStatusID equals os.OrderStatusID
                         //join pm in uow.OMSContext.PayMode on co. equals pm.OrderStatusID
                         join ci in ci_group on co.CartOrderID equals ci.cartOrderId into leftouter
                         from ci in leftouter.DefaultIfEmpty()
                         where co.StatusID <= (long)DBStatusEnum.Active
                         select new CartOrderComposedModel
                         {
                             CartOrderID = co.CartOrderID,
                             ParentCartID = co.ParentCartID,
                             //CartName = co.CartName,
                             OrderStatusId = co.OrderStatusID,
                             BuyerProfileID = co.BuyerProfileID,
                             StatusId = co.StatusID,
                             UserName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                             IsOrder = os.IsOrder,
                             StatusTitle = s.StatusName,
                             OrderStatusTitle = os.OrderStatusTitle,

                             //IsPaid = false,
                             //PayOptionMatrixId = co.PayOptionMatrixID,
                             //PayModeId = co.PayOptionMatrix.PayModeID,
                             //PayModeTitle = co.PayOptionMatrix.PayMode.PayModeTitle,
                             //PayTypeId = co.PayOptionMatrix.PayTypeID,
                             //PayTypeTitle = co.PayOptionMatrix.PayType.PayTypeTitle,
                             SubTotal_ExclTax = ci.OrderSum,
                             //TaxTotal = -1,
                             //Totlal_InclTax = -1

                             //RequestedByProfileId = -1,
                             CreatedOn = co.CreatedDateTime,
                             ModifiedOn = co.LastModifiedDateTime,
                             CreatedBy = co.CreatedByUserID,
                             ModifiedBy = co.LastModifiedByUserID,
                         };

            return result;
        }
        */
        #endregion Private
    }
}
