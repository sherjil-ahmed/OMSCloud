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
    public partial class DeliveryOptionAdapter
    {


        #region Select
        public List<DeliveryOptionModel> GetDeliveryOptionList()
        {
            var deliveryOptionList = uow.DeliveryOptionRepository.GetAll().Select(a => GetDeliveryOptionModel(a)).ToList();
            return deliveryOptionList;
        }
        public DeliveryOptionModel GetDeliveryOptionById(long Id)
        {
            var DeliveryOption = uow.DeliveryOptionRepository.GetById(Id);
            DeliveryOptionModel deliverOptionModel = GetDeliveryOptionModel(DeliveryOption);
            return deliverOptionModel;
        }
        #endregion Select

        #region Update

        public bool UpdateDeliveryOption(DeliveryOptionModel deliveryOptionModel)
        {
            try
            {
                var deliveryOption = UpdateConcurrency(GetEntity(deliveryOptionModel), deliveryOptionModel);
                var recordsCount = uow.OMSContext.DeliveryOption_Update(deliveryOption);

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
        public long? AddDeliveryOption(DeliveryOptionModel deliveryOptionModel)
        {
            try
            {
                var outParam = new ObjectParameter("DeliveryOptionID", typeof(int));

                var deliveryOption = UpdateConcurrency(GetEntity(deliveryOptionModel), deliveryOptionModel);
                var recordsCount = uow.OMSContext.DeliveryOption_Insert(deliveryOption, outParam);

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
        public bool DeleteDeliveryOption(DeliveryOptionModel deliveryOptionModel)
        {
            try
            {
                var DeliveryOption = GetDeliveryOptionEntity(deliveryOptionModel);
                uow.DeliveryOptionRepository.Delete(DeliveryOption);
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
        private DeliveryOptionModel GetDeliveryOptionModel(DeliveryOption deliveryOption)
        {
            return new DeliveryOptionModel()
            {
                DeliveryOptionID = deliveryOption.DeliveryOptionID,
                DeliveryOptionTitle = deliveryOption.DeliveryOptionTitle,
                Description = deliveryOption.Description
            };
        }
        private DeliveryOption GetDeliveryOptionEntity(DeliveryOptionModel deliveryOptionModel)
        {
            return new DeliveryOption()
            {
                DeliveryOptionID = deliveryOptionModel.DeliveryOptionID,
                DeliveryOptionTitle = deliveryOptionModel.DeliveryOptionTitle,
                Description = deliveryOptionModel.Description
            };
        }
        #endregion Private
    }
}
