using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.UnitofWork;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using System.Data.Entity.Core.Objects;

namespace OMSCloud.Business.Adapters
{
    public partial class TaxTypeAdapter
    {
        #region select
        public List<TaxTypeModel> GetTaxTypeList()
        {
            var taxTypeList = uow.TaxTypeRepository.GetAll().Select(a => GetTaxTypeModel(a)).ToList();
            return taxTypeList;
        }

        public TaxTypeModel GetTaxTypeById(long Id)
        {
            var taxType = uow.TaxTypeRepository.GetById(Id);
            TaxTypeModel taxTypeModel = GetTaxTypeModel(taxType);
            return taxTypeModel;
        }
        #endregion select

        #region Update

        public bool UpdateTaxType(TaxTypeModel taxTypeModel)
        {
            try
            {
                var taxType = UpdateConcurrency(GetEntity(taxTypeModel), taxTypeModel);
                var recordsCount = uow.OMSContext.TaxType_Update(taxType);
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
        public long? AddTaxType(TaxTypeModel taxTypeModel)
        {
            try
            {
                var taxType = UpdateConcurrency(GetEntity(taxTypeModel), taxTypeModel, false);
                var outParam = new ObjectParameter("TaxTypeID", typeof(int));
                var recordsCount = uow.OMSContext.TaxType_Insert(taxType, outParam);
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
        public bool DeleteTaxType(TaxTypeModel taxTypeModel)
        {
            try
            {
                var taxType = GetTaxTypeEntity(taxTypeModel);
                uow.TaxTypeRepository.Delete(taxType);
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

        #region private
        public TaxTypeModel GetTaxTypeModel(TaxType taxType)
        {
            return new TaxTypeModel()
            {
                TaxTypeID = taxType.TaxTypeID,
                TaxTypeTitle = taxType.TaxTypeTitle,
                Description = taxType.Description
            };
        }

        public TaxType GetTaxTypeEntity(TaxTypeModel taxTypeModel)
        {
            return new TaxType()
            {
                TaxTypeID = taxTypeModel.TaxTypeID,
                TaxTypeTitle = taxTypeModel.TaxTypeTitle,
                Description = taxTypeModel.Description

            };

        }
        #endregion private

    }
}