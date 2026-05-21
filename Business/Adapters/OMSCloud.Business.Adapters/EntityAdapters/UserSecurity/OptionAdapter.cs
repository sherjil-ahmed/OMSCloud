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
    public partial class OptionAdapter
    {


        #region Select
        public List<OptionModel> GetOptionList()
        {
            var optionList = uow.OptionRepository.GetAll().Select(a => GetOptionModel(a)).ToList();
            return optionList;
        }

        public OptionModel GetOptionById(long Id)
        {
            var option = uow.OptionRepository.GetById(Id);
            OptionModel optionModel = GetOptionModel(option);
            return optionModel;
        }

        public List<OptionModel> GetOptionByStatus(DBStatusEnum status)
        {
            var result = from option in uow.OptionRepository.OMSContext.Option
                         where option.StatusID == (int)status
                         select GetOptionModel(option);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateOption(OptionModel optionModel)
        {
            try
            {
                var option = UpdateConcurrency(GetEntity(optionModel), optionModel);
                var recordsCount = uow.OMSContext.Option_Update(option);
                return recordsCount > 0;

            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }

        #endregion Update

        #region Add

        public long? AddOption(OptionModel optionModel)
        {
            try
            {
                var outParam = new ObjectParameter("OptionID", typeof(int));

                var option = UpdateConcurrency(GetEntity(optionModel), optionModel);
                var recordsCount = uow.OMSContext.Option_Insert(option, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;

            }
            catch
            {
                return null;
            }
            finally
            {
            }
        }

        #endregion Add

        #region Delete
        public bool DeleteOption(OptionModel optionModel)
        {
            try
            {
                var option = GetOptionEntity(optionModel);
                uow.OptionRepository.Delete(option);
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
        private OptionModel GetOptionModel(Option option)
        {
            return new OptionModel()
            {
                //CreatedByUserID = option.CreatedByUserID,
                ExecActionID = option.ExecActionID,
                ModuleID = option.ModuleID,
                ItemTitle = option.ItemTitle,
                //CreatedDateTime = option.CreatedDateTime,
                //LastModifiedByUserID = option.LastModifiedByUserID,
                //LastModifiedDateTime = option.LastModifiedDateTime,
                MenuTitle = option.MenuTitle,
                StatusID = option.StatusID,
                ParentOptionID = option.ParentOptionID,
                DisplayOrder = option.DisplayOrder,
                OptionID = option.OptionID,
                OptionTitle = option.OptionTitle,
                OptionTypeID = option.OptionTypeID,
                NextPageURL = option.NextPageURL,
                PageURL = option.PageURL
            };
        }
        private Option GetOptionEntity(OptionModel optionModel)
        {
            return new Option()
            {
                //CreatedByUserID = optionModel.CreatedByUserID,
                ExecActionID = optionModel.ExecActionID,
                ModuleID = optionModel.ModuleID,
                ItemTitle = optionModel.ItemTitle,
                //CreatedDateTime = optionModel.CreatedDateTime,
                //LastModifiedByUserID = optionModel.LastModifiedByUserID,
                //LastModifiedDateTime = optionModel.LastModifiedDateTime,
                MenuTitle = optionModel.MenuTitle,
                StatusID = optionModel.StatusID,
                ParentOptionID = optionModel.ParentOptionID,
                DisplayOrder = optionModel.DisplayOrder,
                OptionID = optionModel.OptionID,
                OptionTitle = optionModel.OptionTitle,
                OptionTypeID = optionModel.OptionTypeID,
                NextPageURL = optionModel.NextPageURL,
                PageURL = optionModel.PageURL
            };
        }
        #endregion Private
    }
}
