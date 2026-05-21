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
    public partial class OrderDeliveryDetailAdapter
    {

        #region Select
        public List<OrderDeliveryDetailModel> GetOrderDeliveryDetailList()
        {
            var orderDeliverDetailList = uow.OrderDeliveryDetailRepository.GetAll().Select(a => GetOrderDeliveryDetailModel(a)).OrderBy(o => o.CartOrderName).ToList();
            return orderDeliverDetailList;
        }

        public OrderDeliveryDetailModel GetOrderDeliveryDetailById(long Id)
        {
            var orderDeliveryDetail = uow.OrderDeliveryDetailRepository.GetById(Id);
            var orderDeliveryDetails = GetOrderDeliveryDetailModel(orderDeliveryDetail);
            return orderDeliveryDetails;
        }

        #endregion Select

        #region Update

        public bool UpdateOrderDeliveryDetail(OrderDeliveryDetailModel orderDeliveryDetailModel)
        {
            try
            {
                var orderDeliveryDetail = UpdateConcurrency(GetEntity(orderDeliveryDetailModel), orderDeliveryDetailModel);
                var recordsCount = uow.OMSContext.OrderDeliveryDetail_Update(orderDeliveryDetail);
                return recordsCount > 0;

            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        #endregion Update

        #region Add

        public long? AddOrderDeliveryDetail(OrderDeliveryDetailModel orderDeliveryDetailModel)
        {
            try
            {
                var orderDeliveryDetail = UpdateConcurrency(GetEntity(orderDeliveryDetailModel), orderDeliveryDetailModel, false);
                var outParam = new ObjectParameter("OrderDeliveryDetailID", typeof(long));
                var recordsCount = uow.OMSContext.OrderDeliveryDetail_Insert(orderDeliveryDetail, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;

            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        #endregion Add

        #region Delete
        public bool DeleteOrderDeliveryDetail(OrderDeliveryDetailModel orderDeliveryDetailModel)
        {
            try
            {
                var orderDeliveryDetail = GetOrderDeliveryDetailEntity(orderDeliveryDetailModel);
                uow.OrderDeliveryDetailRepository.Delete(orderDeliveryDetail);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private OrderDeliveryDetailModel GetOrderDeliveryDetailModel(OrderDeliveryDetail orderDeliveryDetail)
        {
            var a = orderDeliveryDetail.Address;
            return new OrderDeliveryDetailModel()
            {
                CartOrderID = orderDeliveryDetail.CartOrderID,
                DeliveryAddressID = orderDeliveryDetail.DeliveryAddressID,
                DeliveryAddress = a.PlotNumber + " " + a.StreetNumber + " " + a.LocationTree.LocationTitle  + " " + a.PostalCode + " " + a.NearestLandmark,
                OrderDeliveryDetailID = orderDeliveryDetail.OrderDeliveryDetailID,
                //DeliveryProductID = orderDeliveryDetail.DeliveryProductID,
                //DeliveryProductTitle = orderDeliveryDetail.Product.ProductTitle,
                //CartOrderName = orderDeliveryDetail.CartOrder.CartName
            };
        }
        private OrderDeliveryDetail GetOrderDeliveryDetailEntity(OrderDeliveryDetailModel orderDeliveryDetailModel)
        {
            return new OrderDeliveryDetail()
            {
                CartOrderID = orderDeliveryDetailModel.CartOrderID,
                DeliveryAddressID = orderDeliveryDetailModel.DeliveryAddressID,
                OrderDeliveryDetailID = orderDeliveryDetailModel.OrderDeliveryDetailID,
                //DeliveryProductID = orderDeliveryDetailModel.DeliveryProductID
            };
        }
        #endregion Private
    }
}
