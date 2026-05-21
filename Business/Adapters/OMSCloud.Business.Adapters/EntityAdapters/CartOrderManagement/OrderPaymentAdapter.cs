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
    public partial class OrderPaymentAdapter
    {

        #region Select
        public List<OrderPaymentModel> GetOrderPaymentList()
        {
            var orderPaymentList = uow.OrderPaymentRepository.GetAll().Select(a => GetOrderPaymentModel(a)).ToList();
            return orderPaymentList;
        }

        public OrderPaymentModel GetOrderPaymentById(long Id)
        {
            var orderPayment = uow.OrderPaymentRepository.GetById(Id);
            OrderPaymentModel orderPayments = GetOrderPaymentModel(orderPayment);
            return orderPayments;
        }

        #endregion Select

        #region Update

        public bool UpdateOrderPayment(OrderPaymentModel orderPaymentModel)
        {
            try
            {
                var orderPayment = UpdateConcurrency(GetEntity(orderPaymentModel), orderPaymentModel);
                var recordsCount = uow.OMSContext.OrderPayment_Update(orderPayment);
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

        public long? AddOrderPayment(OrderPaymentModel orderPaymentModel)
        {
            try
            {
                var orderPayment = UpdateConcurrency(GetEntity(orderPaymentModel), orderPaymentModel, false);
                var outParam = new ObjectParameter("OrderPaymentID", typeof(long));
                var recordsCount = uow.OMSContext.OrderPayment_Insert(orderPayment, outParam);
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
        public bool DeleteOrderPayment(OrderPaymentModel orderPaymentModel)
        {
            try
            {
                var orderPayment = GetOrderPaymentEntity(orderPaymentModel);
                uow.OrderPaymentRepository.Delete(orderPayment);
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
        private OrderPaymentModel GetOrderPaymentModel(OrderPayment orderPayment)
        {
            return new OrderPaymentModel()
            {
                CartOrderID = orderPayment.CartOrderID,
                PaymentID = orderPayment.PaymentID,
                Amount = orderPayment.Amount,
                OrderPaymentID = orderPayment.OrderPaymentID,
                BillingAddressID = orderPayment.BillingAddressID,
            };
        }
        private OrderPayment GetOrderPaymentEntity(OrderPaymentModel orderPaymentModel)
        {
            return new OrderPayment()
            {
                CartOrderID = orderPaymentModel.CartOrderID,
                PaymentID = orderPaymentModel.PaymentID,
                Amount = orderPaymentModel.Amount,
                BillingAddressID = orderPaymentModel.BillingAddressID,
                OrderPaymentID = orderPaymentModel.OrderPaymentID,
            };
        }
        #endregion Private
    }
}
