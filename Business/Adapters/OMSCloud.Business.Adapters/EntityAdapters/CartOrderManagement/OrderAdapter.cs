using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{

    public partial class OrderAdapter
    {
        #region Select
        public List<ChangeOrderStatusModel> GetNextOrderStatusList(long profileId, long orderId, long currentOrderStatus, short RequestedBy)
        {
            long orderCount = 0;
            if (RequestedBy == 1)//Shop
            {
                orderCount = (from o in uow.OMSContext.CartOrder
                              join sp in uow.OMSContext.Supplier on o.OrderSupplierId equals sp.SupplierID
                              where o.CartOrderID == orderId && o.OrderStatusID == currentOrderStatus
                              && sp.ProfileID == profileId //Compare with ProfileId of Shop
                              select o.CartOrderID).Count();
            }
            else if (RequestedBy == 2)//Buyer
            {
                orderCount = (from o in uow.OMSContext.CartOrder

                              where o.CartOrderID == orderId && o.OrderStatusID == currentOrderStatus
                              && o.BuyerProfileID == profileId //Compare with Profile Id of Buyer
                              select o.CartOrderID).Count();
            }
            if (orderCount <= 0)
            {
                return new List<ChangeOrderStatusModel>();
            }
            var result = (from osm in uow.OMSContext.OrderStatusMap
                              //join op in uow.OMSContext.OrderStatus on m.ParentOrderStatusID equals op.OrderStatusID
                          join os in uow.OMSContext.OrderStatus on osm.ChildOrderStatusID equals os.OrderStatusID
                          where
                               osm.ParentOrderStatusID == currentOrderStatus
                               &&
                               osm.ChildOrderStatusID != currentOrderStatus
                               &&
                               osm.Description.Contains(RequestedBy == 1 ? "Shop" : RequestedBy == 2 ? "Buyer" : "none")
                          orderby osm.IsDefault
                          select new ChangeOrderStatusModel
                          {
                              OrderStatusID = osm.ChildOrderStatusID,
                              OrderStatusTitle = os.OrderStatusTitle,
                              IsCurrent = false,
                              IsDefault = osm.IsDefault
                          });
            return result.ToList();
        }

        public List<OrderDetailModel> GetOrderList(long? buyerProfileId = null, long? shopId = null, long? orderStatusId = null, long? parentCartId = null)
        {
            var result = this.GetOrderEnumeration(new OrderAdminSearchModel {
                BuyerProfileId = buyerProfileId,
                ShopId = shopId,
                OrderStatusId = orderStatusId,
                ParentCartId = parentCartId
            });
            return result.ToList();
        }

        public List<CartOrderLookupModel> GetCartOrderLookupList(long? OrderType = null)
        {
            var result = (from co in uow.OMSContext.CartOrder
                          where co.StatusID <= (long)DBStatusEnum.Active
                          select new CartOrderLookupModel
                          {
                              OrderNumber = co.OrderNumber,
                              CartOrderID = co.CartOrderID,
                          });
            return result.ToList();
        }

        public OrderDetailModel GetOrderByOrderId(long Id)
        {
            var orderList = this.GetOrderEnumeration(new OrderAdminSearchModel { });
            var order = orderList.
                Where(o => o.OrderID == Id).
                Select(o => o);
            var firstOrder = order.FirstOrDefault();
            return firstOrder;
        }

        public OrderDetailModel GetOrderDetailByOrderId(long Id)
        {
            var orderList = this.GetOrderEnumeration(new OrderAdminSearchModel { });
            var test = orderList.Where(x => x.ShopAllowCashPayment == true).ToList();
            var order = orderList.
                Where(o => o.OrderID == Id).
                Select(o =>
                {
                    o.ItemList = (from i in uow.OMSContext.CartItem
                                  join s in uow.OMSContext.Status on i.StatusID equals s.StatusID
                                  where i.CartOrderID == o.OrderID
                                  select new CartItemWithAttributesModel
                                  {
                                      CartItemID = i.CartItemID,
                                      CartOrderID = i.CartOrderID,
                                      ProductID = i.ProductID,
                                      ProductTitle = i.Product.ProductTitle,
                                      ProductDefaultImage = i.Product.ProductMediaDetail.Where(m => m.Description.ToLower() == "default").Select(m => m.MediaFilePath).FirstOrDefault(),
                                      ShopName = i.Product.Supplier.SupplierName,
                                      ShopCountryId = i.Product.Supplier.CountryID ?? -1,
                                      ShopProvinceId = i.Product.Supplier.ProvinceID ?? -1,
                                      ShopCityId = i.Product.Supplier.CityID ?? -1,
                                      ShopStatusId = i.Product.Supplier.StatusID,
                                      ShopId = i.Product.SupplierID,
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
                                  }).ToList();

                    return o;
                });


            var firstOrder = order.FirstOrDefault();

            if (firstOrder != null)
            {
                ProductAdapter pd = new ProductAdapter();

                List<Tax> listOfTax = pd.GetTaxInfo();

                foreach (CartItemWithAttributesModel item in firstOrder.ItemList)
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
            }


            return firstOrder;
        }
        public long GetCountByFilter(OrderAdminStatsModel statsRequestModel)
        {
            var result = this.GetOrderEnumeration(statsRequestModel);

            result = result.Where(x => x.CreatedOn >= statsRequestModel.From.Date && x.CreatedOn <= statsRequestModel.To.Date);
            var total = result.Count();
            return total;
        }

        public OrderSearchResultAdminModel GetListByPage(OrderAdminSearchModel searchRequestModel)
        {
            var orderResult = new OrderSearchResultAdminModel();
            var result = this.GetOrderEnumeration(searchRequestModel);
            result = SortOrder(searchRequestModel.SortBy, result);

            var total = result.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / searchRequestModel.PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = searchRequestModel.PageSize_RowCount * (searchRequestModel.PageNum - 1);
                if (skip > total)
                    skip = total;
                var ordertList = result.Skip(skip).Take(searchRequestModel.PageSize_RowCount).ToList();

                orderResult = new OrderSearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = ordertList.Count + skip,
                    MaxPrice = 0.0d,
                    MinPrice = 0.0d,
                    OrderList = ordertList,
                };
            }
            return orderResult;
        }

        private IEnumerable<OrderDetailModel> SortOrder(string sortOrder, IEnumerable<OrderDetailModel> returnlist)
        {
            switch (sortOrder)
            {
                case "OrderNumber":
                    returnlist = returnlist.OrderBy(s => s.OrderNumber);
                    break;
                case "OrderNumber_desc":
                    returnlist = returnlist.OrderByDescending(s => s.OrderNumber);
                    break;
                case "BuyerName":
                    returnlist = returnlist.OrderBy(x => x.BuyerName);
                    break;
                case "BuyerName_desc":
                    returnlist = returnlist.OrderByDescending(x => x.BuyerName);
                    break;
                case "OrderStatusTitle":
                    returnlist = returnlist.OrderBy(s => s.OrderStatusTitle);
                    break;
                case "OrderStatusTitle_desc":
                    returnlist = returnlist.OrderByDescending(s => s.OrderStatusTitle);
                    break;
                case "Status":
                    returnlist = returnlist.OrderBy(s => s.StatusTitle);
                    break;
                case "Status_desc":
                    returnlist = returnlist.OrderByDescending(s => s.StatusTitle);
                    break;
                case "ShopName":
                    returnlist = returnlist.OrderBy(s => s.ShopName);
                    break;
                case "ShopName_desc":
                    returnlist = returnlist.OrderByDescending(s => s.ShopName);
                    break;
                case "TaxTotal":
                    returnlist = returnlist.OrderBy(s => s.TaxTotal);
                    break;
                case "TaxTotal_desc":
                    returnlist = returnlist.OrderByDescending(s => s.TaxTotal);
                    break;
                case "PaymentTotal":
                    returnlist = returnlist.OrderBy(s => s.PaymentTotal);
                    break;
                case "PaymentTotal_desc":
                    returnlist = returnlist.OrderByDescending(s => s.PaymentTotal);
                    break;
                case "CreatedOn":
                    returnlist = returnlist.OrderBy(s => s.CreatedOn);
                    break;
                case "CreatedOn_desc":
                    returnlist = returnlist.OrderByDescending(s => s.CreatedOn);
                    break;
                case "ModifiedOn":
                    returnlist = returnlist.OrderBy(s => s.ModifiedOn);
                    break;
                case "ModifiedOn_desc":
                    returnlist = returnlist.OrderByDescending(s => s.ModifiedOn);
                    break;
                default:
                    returnlist = returnlist.OrderByDescending(s => s.CreatedOn);
                    break;
            }
            return returnlist;
        }

        public List<OrderDetailModel> GetCartOrderByStatus(DBStatusEnum status)
        {
            return GetOrderEnumeration(new OrderAdminSearchModel()).Where(x => x.StatusId == (int)status).ToList();
        }

        public List<OrderDetailModel> GetCartOrderByOrderStatus(long? OrderStatusId = null, bool IsOrder = true)
        {
            var result = GetOrderEnumeration(new OrderAdminSearchModel{
                OrderStatusId = OrderStatusId,
            });
            return result.ToList();
        }

        /// <summary>
        /// Get Specialized Addresses defined for Shopping e.g. Billing Addresses or Shipping/Delivery Addresses
        /// User/Admin either can select from this list or define a new
        /// </summary>
        /// <param name="CartOrderId"></param>
        /// <param name="AddressTypeId"></param>
        /// <param name="AddressTypePartialName">if address type is unknown, then part of the address type name can be used to </param>
        /// <returns></returns>
        public List<AddressViewModel> GetAddressListByCartOrderId(long CartOrderId, long? AddressTypeId = null, string AddressTypePartialName = null)
        {
            var result = (from co in uow.OMSContext.CartOrder
                          join a in uow.OMSContext.Address on co.BuyerProfileID equals a.ProfileID
                          where
                          co.CartOrderID == CartOrderId
                          &&
                          a.AddressType.AddressTypeTitle.Contains(AddressTypePartialName)
                          select a
                );
            if (AddressTypeId.HasValue)
                result = result.Where(a => a.AddressTypeID == AddressTypeId.Value);

            return result.Select(a => new AddressViewModel {
                AddressID = a.AddressID,
                AddressTypeID = a.AddressTypeID,
                AddressTypeName = a.AddressType.AddressTypeTitle,
                LocationID = a.LocationID,
                LocationName = a.LocationTree.LocationTitle,
                NearestLandmark = a.NearestLandmark,
                PlotNumber = a.PlotNumber,
                PostalCode = a.PostalCode,
                ProfileID = a.ProfileID,
                ProfileName = a.Profile.FirstName + " " + a.Profile.MiddleName + " " + a.Profile.LastName,
                StreetNumber = a.StreetNumber,
                CreatedBy = a.CreatedByUserID,
                CreatedOn = a.CreatedDateTime,
                ModifiedBy = a.LastModifiedByUserID,
                ModifiedOn = a.LastModifiedDateTime,                
            }).ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateCartOrder(OrderModel cartOrderModel)
        {
            try
            {

                var cartOrder = UpdateConcurrency(GetEntity(cartOrderModel), cartOrderModel, true);
                var recordsCount = uow.OMSContext.CartOrder_Update(cartOrder);

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        public bool UpdateOrder(OrderModel orderModel)
        {
            try
            {

                var order = UpdateConcurrency(GetEntity(orderModel), orderModel, true);
                var recordsCount = uow.OMSContext.Order_Update(order);

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        public bool UpdateOrderStatus(OrderModel orderModel)
        {
            try
            {
                var order = UpdateConcurrency(GetEntity(orderModel), orderModel, true);
                var recordsCount = uow.OMSContext.Order_Update_Status(order);

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        public bool UpdateOrderStatusAuto()
        {
            try
            {                
                var recordsCount = uow.OMSContext.Order_AutoUpdateStatus();

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool UpdateOrderStatus(List<long> orderList, DBOrderStatusEnum orderStatus)
        {
            try
            {
                var orderIds = string.Join(",", orderList.Select(n => n.ToString()).ToArray());
                var recordsCount = uow.OMSContext.Bulk_Update("CartOrder", "CartOrderID", orderIds, "OrderStatusID", ((int)orderStatus).ToString());
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add
        public virtual List<ConvertCartToOrders_ResultModel> Sp_ConvertCartToOrders(ConvertCartToOrders_SpParams paramModel)
        {
            var paramEntity = new ConvertCartToOrders_SpParamsEntity()
            {
                existing_CartId = paramModel.existing_CartId,
                new_DeliveryAddressID = paramModel.new_DeliveryAddressID,
                new_SupplierDeliveryOptionPairID = null,// paramModel.new_SupplierDeliveryOptionPairID,
                spProfileId = paramModel.RequestedByProfileId
            };
            var result = uow.OMSContext.Sp_ConvertCartToOrders(paramEntity);
            List<ConvertCartToOrders_ResultModel> returnData = new List<ConvertCartToOrders_ResultModel>();
            if (result == null) return returnData;
            var result1 = result.ToList();
            foreach (var r in result1)
            {
                returnData.Add(new ConvertCartToOrders_ResultModel() { OrderId = r.OrderId, ShopId = r.ShopId });
            }
            return returnData;
        }
        public long? AddCartOrder(OrderModel cartOrderModel)
        {
            try
            {
                var CartOrder = UpdateConcurrency(GetEntity(cartOrderModel), cartOrderModel, false);
                var outParam = new ObjectParameter("CartOrderID", typeof(long));
                var recordsCount = uow.OMSContext.CartOrder_Insert(CartOrder, outParam);

                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public long? AddOrder(OrderModel OrderModel)
        {
            try
            {
                var Order = UpdateConcurrency(GetEntity(OrderModel), OrderModel, false);
                var outParam = new ObjectParameter("OrderID", typeof(long));
                var recordsCount = uow.OMSContext.CartOrder_Insert(Order, outParam);

                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add

        #region Delete
        public bool DeleteCartOrder(OrderModel cartOrderModel)
        {
            try
            {
                var CartOrder = GetCartOrderEntity(cartOrderModel);
                uow.CartOrderRepository.Delete(CartOrder);
                uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private OrderModel GetCartOrderModel(CartOrder cartOrder)
        {
            return new OrderModel
            {
                OrderID = cartOrder.CartOrderID,
                OrderNumber = cartOrder.OrderNumber,
                ParentCartID = cartOrder.ParentCartID,
                BuyerProfileID = cartOrder.BuyerProfileID,
                OrderStatusId = cartOrder.OrderStatusID,
                StatusId = cartOrder.StatusID,
                DeliveryAddressID = cartOrder.DeliveryAddressID,
                DeliveryAddress = cartOrder.DeliveryAddress,
                ShopID = cartOrder.OrderSupplierId,
                DeliveryOptionID = cartOrder.SupplierDeliveryOptionPairID.HasValue ? cartOrder.SupplierDeliveryOptionPairID.Value : -1,
                OrderTotal = cartOrder.OrderTotal,
                TaxTotal = cartOrder.TaxTotal,
                DeliveryTotal = cartOrder.DeliveryTotal,
                DiscountTotal = cartOrder.DiscountTotal,
                PaymentTotal = cartOrder.PaymentTotal,
                CalculatedPayout = cartOrder.CalculatedPayout,
                ActualPayout = cartOrder.ActualPayout,
                CalculatedPayIn = cartOrder.CalculatedPayIn,
                ActualPayIn = cartOrder.ActualPayIn
            };
        }
        private CartOrder GetCartOrderEntity(OrderModel cartOrderModel)
        {
            return new CartOrder
            {
                CartOrderID = cartOrderModel.OrderID,
                OrderNumber = cartOrderModel.OrderNumber,
                ParentCartID = cartOrderModel.ParentCartID,
                BuyerProfileID = cartOrderModel.BuyerProfileID,
                OrderStatusID = cartOrderModel.OrderStatusId,
                StatusID = cartOrderModel.StatusId,
                DeliveryAddressID = cartOrderModel.DeliveryAddressID,
                DeliveryAddress = cartOrderModel.DeliveryAddress,
                OrderSupplierId = cartOrderModel.ShopID,
                SupplierDeliveryOptionPairID = cartOrderModel.DeliveryOptionID,

                OrderTotal = cartOrderModel.OrderTotal,
                TaxTotal = cartOrderModel.TaxTotal,
                DeliveryTotal = cartOrderModel.DeliveryTotal,
                DiscountTotal = cartOrderModel.DiscountTotal,
                PaymentTotal = cartOrderModel.PaymentTotal,
                CalculatedPayout = cartOrderModel.CalculatedPayout,
                ActualPayout = cartOrderModel.ActualPayout,
                CalculatedPayIn = cartOrderModel.CalculatedPayIn,
                ActualPayIn = cartOrderModel.ActualPayIn
            };
        }

        private IEnumerable<OrderDetailModel> GetOrderEnumeration(OrderAdminSearchModel model)
        {
            var result = from o in uow.OMSContext.CartOrder
                         join p in uow.OMSContext.Profile on o.BuyerProfileID equals p.ProfileID
                         join s in uow.OMSContext.Status on o.StatusID equals s.StatusID
                         join os in uow.OMSContext.OrderStatus on o.OrderStatusID equals os.OrderStatusID
                         where o.ParentCartID != null && (o.StatusID == (int)DBStatusEnum.Active || o.StatusID == (int)DBStatusEnum.New)
                         select new OrderDetailModel
                         {
                             OrderID = o.CartOrderID,
                             OrderNumber = o.OrderNumber,
                             ParentCartID = o.ParentCartID,
                             OrderStatusId = o.OrderStatusID,
                             BuyerProfileID = o.BuyerProfileID,
                             StatusId = o.StatusID,
                             BuyerName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                             StatusTitle = s.StatusName,
                             OrderStatusTitle = o.OrderStatus.OrderStatusTitle,
                             ShopID = o.OrderSupplierId,
                             ShopName = o.Supplier.SupplierName,
                             ShopAllowCashPayment = o.Supplier.IsCOD,
                             ShopCityId = o.Supplier.CityID.HasValue ? o.Supplier.CityID.Value : 0,
                             ShopProvinceId = o.Supplier.ProvinceID.HasValue ? o.Supplier.ProvinceID.Value : 0,

                             DeliveryAddressID = o.DeliveryAddressID,
                             DeliveryAddress = o.DeliveryAddress,
                             DeliveryOptionID = o.SupplierDeliveryOptionPairID.HasValue ? o.SupplierDeliveryOptionPairID.Value : -1,
                             DeliveryOptionTitle = o.SupplierDeliveryOptionPair.DeliveryOption.DeliveryOptionTitle,

                             DeliveryTotal = o.DeliveryTotal,
                             DiscountTotal = o.DiscountTotal,
                             TaxTotal = o.TaxTotal,
                             OrderTotal = o.OrderTotal,
                             PaymentTotal = o.PaymentTotal,

                             ActualPayIn = o.ActualPayIn,
                             ActualPayout = o.ActualPayout,
                             CalculatedPayIn = o.CalculatedPayIn,
                             CalculatedPayout = o.CalculatedPayout,

                             CreatedOn = (o.OrderStatusID == (long)DBOrderStatusEnum.NewOrder ? o.CreatedDateTime : o.Payment.Select(x => x.CreatedDateTime).FirstOrDefault()),

                             ModifiedOn = o.LastModifiedDateTime,
                             CreatedBy = o.CreatedByUserID,
                             ModifiedBy = o.LastModifiedByUserID,
                         };
            if (!string.IsNullOrEmpty(model.SearchString))
            {
                result = result.Where(x => x.OrderNumber.Contains(model.SearchString));
            }
            if (model.ShopId.HasValue)
            {
                result = result.Where(r => r.ShopID == model.ShopId);
            }
            if (model.ProvinceId.HasValue && model.ProvinceId.Value > 0)
            {
                result = result.Where(r => r.ShopProvinceId == model.ProvinceId);
            }
            if (model.CityId.HasValue && model.CityId.Value > 0)
            {
                result = result.Where(r => r.ShopCityId == model.CityId);
            }
            if (model.OrderStatusId.HasValue)
            {
                if (model.OrderStatusId > 100 && model.OrderStatusId < 105)
                {
                    var list = GetDBOrderStatusFromPublicOrderStatus((OrderPublicStatusEnum)model.OrderStatusId);
                    result = result.Where(r => list.Contains(r.OrderStatusId));
                }
                else
                {
                    result = result.Where(r => r.OrderStatusId == model.OrderStatusId);
                }
            }
            if (model.BuyerProfileId.HasValue)
            {
                result = result.Where(r => r.BuyerProfileID == model.BuyerProfileId);
            }
            if (model.ParentCartId.HasValue)
            {
                result = result.Where(r => r.ParentCartID == model.ParentCartId);
            }
            return result.OrderByDescending(x => x.CreatedOn);
        }
        private long GetPublicOrderStatusFromDBOrderStatus(long OrderStatus)
        {
            long publicOrderStatus = 0;
            switch (OrderStatus)
            {
                case (long)DBOrderStatusEnum.NewOrder:
                    publicOrderStatus = (long)OrderPublicStatusEnum.New;
                    break;
                case (long)DBOrderStatusEnum.OrderInProcess:
                case (long)DBOrderStatusEnum.OrderPlaced:
                case (long)DBOrderStatusEnum.OrderDispatched_ReadyforPickup:
                    publicOrderStatus = (long)OrderPublicStatusEnum.Inprocess;
                    break;
                case (long)DBOrderStatusEnum.OrderCompleted:
                case (long)DBOrderStatusEnum.Order_Delivered_Pickedup:
                    publicOrderStatus = (long)OrderPublicStatusEnum.Completed;
                    break;
                case (long)DBOrderStatusAdminEnum.OrderFailed:
                case (long)DBOrderStatusAdminEnum.OrderIssues:
                case (long)DBOrderStatusAdminEnum.Order_Delivery_Pickup_Failed:
                    publicOrderStatus = (long)OrderPublicStatusEnum.Failed;
                    break;
            }
            return publicOrderStatus;
        }
        private List<long> GetDBOrderStatusFromPublicOrderStatus(OrderPublicStatusEnum publicOrderStatus)
        {
            var list = new List<long>();
            switch (publicOrderStatus)
            {
                case OrderPublicStatusEnum.New:
                    list = new List<long> { (long)DBOrderStatusEnum.NewOrder };
                    break;
                case OrderPublicStatusEnum.Inprocess:
                    list = new List<long> {
                        (long)DBOrderStatusEnum.OrderInProcess,
                        (long)DBOrderStatusEnum.OrderPlaced,
                        (long)DBOrderStatusEnum.OrderDispatched_ReadyforPickup };
                    break;
                case OrderPublicStatusEnum.Completed:
                    list = new List<long> {
                        (long)DBOrderStatusEnum.OrderCompleted,
                        (long)DBOrderStatusEnum.Order_Delivered_Pickedup};
                    break;
                case OrderPublicStatusEnum.Failed:
                    list = new List<long> {
                        (long)DBOrderStatusAdminEnum.OrderFailed,
                        (long)DBOrderStatusAdminEnum.OrderIssues,
                        (long)DBOrderStatusAdminEnum.Order_Delivery_Pickup_Failed,
                        (long)DBOrderStatusEnum.OrderIssueRaisedByBuyer,
                    }; break;
            }
            return list;
        }
        #endregion Private
    }
}