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
    public partial class OptionTypeAdapter
    {


        #region Select
        public List<OptionTypeModel> GetOptionTypeList()
        {
            var optionTypeList = uow.OptionTypeRepository.GetAll().Select(a => GetOptionTypeModel(a)).ToList();
            return optionTypeList;
        }

        public OptionTypeModel GetOptionTypeById(long Id)
        {
            var optionType = uow.OptionTypeRepository.GetById(Id);
            OptionTypeModel optionTypeModel = GetOptionTypeModel(optionType);
            return optionTypeModel;
        }


        #endregion Select

        #region Update

        public bool UpdateOptionType(OptionTypeModel optionTypeModel)
        {
            try
            {

                var optionType = UpdateConcurrency(GetEntity(optionTypeModel), optionTypeModel);
                var recordsCount = uow.OMSContext.OptionType_Update(optionType);
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

        public long? AddOptionType(OptionTypeModel optionTypeModel)
        {
            try
            {

                var outParam = new ObjectParameter("OptionTypeID", typeof(int));

                var optionType = UpdateConcurrency(GetEntity(optionTypeModel), optionTypeModel);
                var recordsCount = uow.OMSContext.OptionType_Insert(optionType, outParam);
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
        public bool DeleteOptionType(OptionTypeModel optionTypeModel)
        {
            try
            {
                var optionType = GetOptionTypeEntity(optionTypeModel);
                uow.OptionTypeRepository.Delete(optionType);
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
        private OptionTypeModel GetOptionTypeModel(OptionType optionType)
        {
            return new OptionTypeModel()
            {
                OptionTypeID = optionType.OptionTypeID,
                OptionTypeTitle = optionType.OptionTypeTitle,
                OptionLevel = optionType.OptionLevel,
                Description = optionType.Description
            };
        }
        private OptionType GetOptionTypeEntity(OptionTypeModel optionTypeModel)
        {
            return new OptionType()
            {
                OptionTypeID = optionTypeModel.OptionTypeID,
                OptionTypeTitle = optionTypeModel.OptionTypeTitle,
                OptionLevel = optionTypeModel.OptionLevel,
                Description = optionTypeModel.Description
            };
        }
        #endregion Private
    }
}