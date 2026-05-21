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
    public partial class OrderStatusAdapter
    {
        #region Select
        public List<OrderStatusModel> GetOrderStatusList()
        {
            var orderStatusList = uow.OrderStatusRepository.GetAll().Select(a => GetOrderStatusModel(a)).ToList();
            return orderStatusList;
        }
        
        public OrderStatusModel GetOrderStatusById(long Id)
        {
            var orderStatus = uow.OrderStatusRepository.GetById(Id);
            OrderStatusModel orderStatusModel = GetOrderStatusModel(orderStatus);
            return orderStatusModel;
        }

        public List<OrderStatusModel> GetRootOrderStatus()
        {
            try
            {
                var orderStatus = (from os in uow.OMSContext.OrderStatus
                                   join osm in uow.OMSContext.OrderStatusMap on os.OrderStatusID equals osm.ChildOrderStatusID
                                   select new OrderStatusModel()
                                   {
                                       OrderStatusID = os.OrderStatusID,
                                       OrderStatusTitle = os.OrderStatusTitle,
                                       Description = os.Description,
                                       IsOrder = os.IsOrder,
                                       IsSystem = os.IsSystem,
                                   }).ToList();
                                   //where !(from osm1 in uow.OMSContext.OrderStatusMap select osm1.ChildOrderStatusID).Contains(os.OrderStatusID)
                                   //select GetOrderStatusModel(os)).ToList();
                var orderStatusModel = (orderStatus);
                return orderStatusModel;
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return null;
            }
        }


        public List<ChangeOrderStatusModel> GetNextOrderStatusList(int currentOrderStatus)
        {
            var r2 = (from m in uow.OMSContext.OrderStatus
                      where m.OrderStatusID == currentOrderStatus
                      select m).ToList();
            var result = (from m in uow.OMSContext.OrderStatusMap
                          //join op in uow.OMSContext.OrderStatus on m.ParentOrderStatusID equals op.OrderStatusID
                          join oc in uow.OMSContext.OrderStatus on m.ChildOrderStatusID equals oc.OrderStatusID
                          where m.ParentOrderStatusID == currentOrderStatus && m.ChildOrderStatusID != currentOrderStatus
                          select new ChangeOrderStatusModel
                          {
                              OrderStatusID = m.ChildOrderStatusID,
                              OrderStatusTitle = oc.OrderStatusTitle + (m.IsDefault ? " : (Default Next State)" : ""),
                              IsCurrent = false,
                              IsDefault = m.IsDefault
                         }).ToList();
            if (r2.Count > 0 && r2[0] != null)
            {
                result.Add(new ChangeOrderStatusModel
                {
                    OrderStatusID = r2[0].OrderStatusID,
                    OrderStatusTitle = r2[0].OrderStatusTitle +" : (CurrentValue)",
                    IsCurrent = true,
                    IsDefault = false
                });
            }
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateOrderStatus(OrderStatusModel orderStatusModel)
        {
            try
            {
                var orderStatus = UpdateConcurrency(GetEntity(orderStatusModel), orderStatusModel);
                var recordsCount = uow.OMSContext.OrderStatus_Update(orderStatus);
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

        public long? AddOrderStatus(OrderStatusModel orderStatusModel)
        {
            try
            {
                var orderStatus = UpdateConcurrency(GetEntity(orderStatusModel), orderStatusModel, false);
                var outParam = new ObjectParameter("OrderStatusID", typeof(int));
                var recordsCount = uow.OMSContext.OrderStatus_Insert(orderStatus, outParam);
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
        public bool DeleteOrderStatus(OrderStatusModel orderStatusModel)
        {
            try
            {
                var orderstatus = GetOrderStatusEntity(orderStatusModel);
                uow.OrderStatusRepository.Delete(orderstatus);
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
        private OrderStatusModel GetOrderStatusModel(OrderStatus orderStatus)
        {
            return new OrderStatusModel()
            {
                OrderStatusID = orderStatus.OrderStatusID,
                OrderStatusTitle = orderStatus.OrderStatusTitle,
                Description = orderStatus.Description
            };
        }
        private OrderStatus GetOrderStatusEntity(OrderStatusModel orderStatusModel)
        {
            return new OrderStatus()
            {
                OrderStatusID = orderStatusModel.OrderStatusID,
                OrderStatusTitle = orderStatusModel.OrderStatusTitle,
                Description = orderStatusModel.Description
            };
        }
        #endregion Private
    }
}
