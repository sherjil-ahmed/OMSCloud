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
    public partial class TaxAdapter
    {
        #region select
        public List<TaxModel> GetTaxList()
        {
            var taxList = uow.TaxRepository.GetAll().Select(a => GetTaxModel(a)).ToList();
            return taxList;
        }

        public TaxModel GetTaxById(long Id)
        {
            var tax = uow.TaxRepository.GetById(Id);
            TaxModel taxModel = GetTaxModel(tax);
            return taxModel;
        }

        public List<TaxModel> GetTaxByStatus(DBStatusEnum status)
        {
            var result = from tax in uow.TaxTypeRepository.OMSContext.Tax
                         where tax.StatusID == (int)status
                         select GetTaxModel(tax);
            return result.ToList();
        }

        #endregion select

        #region Update

        public bool UpdateTax(TaxModel taxModel)
        {
            try
            {
                var tax = UpdateConcurrency(GetEntity(taxModel), taxModel);
                var recordsCount = uow.OMSContext.Tax_Update(tax);

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
        public long? AddTax(TaxModel taxModel)
        {
            try
            {
                var tax = UpdateConcurrency(GetEntity(taxModel), taxModel, false);
                var outParam = new ObjectParameter("TaxID", typeof(int));
                var recordsCount = uow.OMSContext.Tax_Insert(tax, outParam);
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
        public bool DeleteTax(TaxModel taxModel)
        {
            try
            {
                var tax = GetTaxEntity(taxModel);
                uow.TaxRepository.Delete(tax);
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
        public TaxModel GetTaxModel(Tax tax)
        {
            return new TaxModel()
            {
                TaxID = tax.TaxID,
                TaxValue = tax.TaxValue,
                TaxTypeID = tax.TaxTypeID,
                Description = tax.Description,
                StatusID = tax.StatusID,
                IsPercentage = tax.IsPercentage,
                LocationId = tax.LocationId,
                LocationLevelId = tax.LocationLevelId,
                EffectiveDate = tax.EffectiveDate,
                ModifiedOn = tax.LastModifiedDateTime,
            };
        }

        public Tax GetTaxEntity(TaxModel taxModel)
        {
            return new Tax()
            {
                TaxID = taxModel.TaxID,
                TaxValue = taxModel.TaxValue,
                TaxTypeID = taxModel.TaxTypeID,
                Description = taxModel.Description,
                StatusID = taxModel.StatusID,
                IsPercentage = taxModel.IsPercentage,
                LocationId = taxModel.LocationId,
                LocationLevelId = taxModel.LocationLevelId,
                EffectiveDate = taxModel.EffectiveDate,
                LastModifiedDateTime = taxModel.ModifiedOn,
            };

        }
        #endregion private
    }
}