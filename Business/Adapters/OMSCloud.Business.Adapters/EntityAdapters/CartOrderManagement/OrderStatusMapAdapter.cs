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
    public partial class OrderStatusMapAdapter
    {
        #region Select
        public List<OrderStatusMapModel> GetSortedList()
        {
            var OrderStatusMapList = (from map in uow.OMSContext.OrderStatusMap
                                      join s in uow.OMSContext.Status on map.StatusID equals s.StatusID
                                      select new OrderStatusMapModel {
                                          OrderStatusMapID = map.OrderStatusMapID,
                                          ParentOrderStatusID = map.ParentOrderStatusID,
                                          ParentOrderStatusTitle = map.OrderStatus.OrderStatusTitle,
                                          ChildOrderStatusID = map.ChildOrderStatusID,
                                          ChildOrderStatusTitle = map.OrderStatus1.OrderStatusTitle,
                                          StatusID = map.StatusID,
                                          StatusTitle = s.StatusName,
                                          IsDefault = map.IsDefault,
                                          Description = map.Description,

                                      }).OrderBy(m => m.ParentOrderStatusID).ToList();
                
                //uow.OrderStatusMapRepository.GetAll().Select(a => GetOrderStatusMapModel(a)).OrderBy(m => m.ParentOrderStatusID).ToList();
            return OrderStatusMapList;
        }

        public OrderStatusMapModel GetOrderStatusMapById(long Id)
        {
            var orderStatusMapModel = (from map in uow.OMSContext.OrderStatusMap
                                      join s in uow.OMSContext.Status on map.StatusID equals s.StatusID
                                      where map.OrderStatusMapID == Id
                                      select new OrderStatusMapModel
                                      {
                                          OrderStatusMapID = map.OrderStatusMapID,
                                          ParentOrderStatusID = map.ParentOrderStatusID,
                                          ParentOrderStatusTitle = map.OrderStatus.OrderStatusTitle,
                                          ChildOrderStatusID = map.ChildOrderStatusID,
                                          ChildOrderStatusTitle = map.OrderStatus1.OrderStatusTitle,
                                          StatusID = map.StatusID,
                                          StatusTitle = s.StatusName,
                                          IsDefault = map.IsDefault,
                                          Description = map.Description,

                                      }).First();
            return orderStatusMapModel;
        }

        #endregion Select

        #region Delete
        public bool DeleteOrderStatusMap(OrderStatusMapModel OrderStatusMapModel)
        {
            try
            {
                var OrderStatusMap = GetOrderStatusMapEntity(OrderStatusMapModel);
                uow.OrderStatusMapRepository.Delete(OrderStatusMap);
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
        private OrderStatusMapModel GetOrderStatusMapModel(OrderStatusMap OrderStatusMap)
        {
            return new OrderStatusMapModel()
            {
                OrderStatusMapID = OrderStatusMap.OrderStatusMapID,
                ChildOrderStatusID = OrderStatusMap.ChildOrderStatusID,
                ParentOrderStatusID = OrderStatusMap.ParentOrderStatusID,
                StatusID= OrderStatusMap.StatusID,
                IsDefault = OrderStatusMap.IsDefault,
                Description = OrderStatusMap.Description
            };
        }
        private OrderStatusMap GetOrderStatusMapEntity(OrderStatusMapModel OrderStatusMapModel)
        {
            return new OrderStatusMap()
            {
                OrderStatusMapID = OrderStatusMapModel.OrderStatusMapID,
                ChildOrderStatusID = OrderStatusMapModel.ChildOrderStatusID,
                ParentOrderStatusID = OrderStatusMapModel.ParentOrderStatusID,
                StatusID = OrderStatusMapModel.StatusID,
                IsDefault = OrderStatusMapModel.IsDefault,
                Description = OrderStatusMapModel.Description
            };
        }
        #endregion Private
    }
}
