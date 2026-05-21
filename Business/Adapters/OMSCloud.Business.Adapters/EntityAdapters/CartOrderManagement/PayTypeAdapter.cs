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
    public partial class PayTypeAdapter
    {


        #region Select
        public List<PayTypeModel> GetPayTypeList()
        {
            var payTypeList = uow.PayTypeRepository.GetAll().Select(a => GetPayTypeModel(a)).ToList();
            return payTypeList;
        }

        public PayTypeModel GetPayTypeById(long Id)
        {
            var payType = uow.PayTypeRepository.GetById(Id);
            PayTypeModel payTypeModel = GetPayTypeModel(payType);
            return payTypeModel;
        }

        public List<PayTypeModel> GetPayTypeByStatus(DBStatusEnum status)
        {
            var result = from payType in uow.PayTypeRepository.OMSContext.PayType
                         where payType.StatusID == (int)status
                         select GetPayTypeModel(payType);
            return result.ToList();
        }

        #endregion Select

        #region Update

        public bool UpdatePayType(PayTypeModel payTypeModel)
        {
            try
            {
                var payType = UpdateConcurrency(GetEntity(payTypeModel), payTypeModel);
                var recordsCount = uow.OMSContext.PayType_Update(payType);
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

        public long? AddPayType(PayTypeModel payTypeModel)
        {
            try
            {
                var payType = UpdateConcurrency(GetEntity(payTypeModel), payTypeModel, false);
                var outParam = new ObjectParameter("PayTypeID", typeof(int));
                var recordsCount = uow.OMSContext.PayType_Insert(payType, outParam);
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
        public bool DeletePayType(PayTypeModel payTypeModel)
        {
            try
            {
                var payType = GetPayTypeEntity(payTypeModel);
                uow.PayTypeRepository.Delete(payType);
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
        private PayTypeModel GetPayTypeModel(PayType payType)
        {
            return new PayTypeModel()
            {
                PayTypeID = payType.PayTypeID,
                PayTypeTitle = payType.PayTypeTitle,
                Description = payType.Description,
                StatusID = payType.StatusID
            };
        }
        private PayType GetPayTypeEntity(PayTypeModel payTypeModel)
        {
            return new PayType()
            {
                PayTypeID = payTypeModel.PayTypeID,
                PayTypeTitle = payTypeModel.PayTypeTitle,
                Description = payTypeModel.Description,
                StatusID = payTypeModel.StatusID
            };
        }
        #endregion 
    }
}
