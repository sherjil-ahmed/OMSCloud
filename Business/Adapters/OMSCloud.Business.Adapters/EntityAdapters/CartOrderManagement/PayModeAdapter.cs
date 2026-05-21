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
    public partial class PayModeAdapter
    {
        #region Select
        public List<PayModeModel> GetPayModeList()
        {
            var PayModeList = uow.PayModeRepository.GetAll().Select(a => GetPayModeModel(a)).ToList();
            return PayModeList;
        }

        public PayModeModel GetPayModeById(long Id)
        {
            var payModes = uow.PayModeRepository.GetById(Id);
            PayModeModel PayModeModel = GetPayModeModel(payModes);
            return PayModeModel;
        }

        public List<PayModeModel> GetPayModeListByPayTypeId(long Id)
        {
            var PayModeList = (from pom in uow.OMSContext.PayOptionMatrix
                              join pm in uow.OMSContext.PayMode on pom.PayModeID equals pm.PayModeID
                              where pom.PayTypeID == Id
                              select new PayModeModel
                              {
                                  PayModeID = pom.PayModeID,
                                  PayModeTitle = pm.PayModeTitle
                              }).ToList();                
            return PayModeList;
        }


        #endregion Select

        #region Update

        public bool UpdatePayMode(PayModeModel payModeModel)
        {
            try
            {
                var payMode = UpdateConcurrency(GetEntity(payModeModel), payModeModel);
                var recordsCount = uow.OMSContext.PayMode_Update(payMode);
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

        public long? AddPayMode(PayModeModel payModeModel)
        {
            try
            {
                var payMode = UpdateConcurrency(GetEntity(payModeModel), payModeModel, false);
                var outParam = new ObjectParameter("PayModeID", typeof(int));
                var recordsCount = uow.OMSContext.PayMode_Insert(payMode, outParam);
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
        public bool DeletePayMode(PayModeModel payModeModel)
        {
            try
            {
                var payMode = GetPayModelEntity(payModeModel);
                uow.PayModeRepository.Delete(payMode);
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
        private PayModeModel GetPayModeModel(PayMode payMode)
        {
            return new PayModeModel()
            {
                PayModeID = payMode.PayModeID,
                PayModeTitle = payMode.PayModeTitle,
                Description = payMode.Description
            };
        }
        private PayMode GetPayModelEntity(PayModeModel payModeModel)
        {
            return new PayMode()
            {
                PayModeID = payModeModel.PayModeID,
                PayModeTitle = payModeModel.PayModeTitle,
                Description = payModeModel.Description
            };
        }
        #endregion 
    }

}
