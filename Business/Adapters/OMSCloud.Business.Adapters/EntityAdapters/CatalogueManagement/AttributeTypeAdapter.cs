using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using oms = OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OMSCloud.Business.Adapters
{
    public partial class AttributeTypeAdapter
    {
        #region Select

        public List<AttributeTypeModel> GetAttributeTypeList()
        {
            var attributeTypeList = uow.AttributeTypeRepository.GetAll().Select(a => GetAttributeTypeModel(a)).ToList();
            return attributeTypeList;
        }
        public AttributeTypeModel GetAttributeTypeById(long Id)
        {
            var attributeType = uow.AttributeTypeRepository.GetById(Id);
            AttributeTypeModel attributeTypeModel = GetAttributeTypeModel(attributeType);
            return attributeTypeModel;
        }
        #endregion Select

        #region update
        public bool UpdateAttributeType(AttributeTypeModel attributeTypeModel)
        {
            try
            {
                var attributeType = UpdateConcurrency(GetEntity(attributeTypeModel), attributeTypeModel);
                var recordsCount = uow.OMSContext.AttributeType_Update(attributeType);

                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion update

        #region Add

        public long? AddAttributeType(AttributeTypeModel attributeTypeModel)
        {
            try
            {
                var attributeType = UpdateConcurrency(GetEntity(attributeTypeModel), attributeTypeModel, false);
                var outParam = new ObjectParameter("AttributeTypeID", typeof(int));
                var recordsCount = uow.OMSContext.AttributeType_Insert(attributeType, outParam);


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

        public bool DeleteAttributeType(AttributeTypeModel attributeTypeModel)
        {
            try
            {
                var attributeType = GetAttributeTypeEntity(attributeTypeModel);
                uow.AttributeTypeRepository.Delete(attributeType);
                uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        #endregion Delete

        #region Private

        private AttributeTypeModel GetAttributeTypeModel(AttributeType attributeType)
        {
            return new AttributeTypeModel
            {
                AttributeTypeID = attributeType.AttributeTypeID,
                AttributeTypeTitle = attributeType.AttributeTypeTitle,
                Description = attributeType.Description,
                IsSystem = attributeType.IsSystem,
            };
        }
        private AttributeType GetAttributeTypeEntity(AttributeTypeModel attributeTypeModel)
        {
            return new AttributeType
            {
                AttributeTypeID = attributeTypeModel.AttributeTypeID,
                AttributeTypeTitle = attributeTypeModel.AttributeTypeTitle,
                Description = attributeTypeModel.Description,
                IsSystem = attributeTypeModel.IsSystem
            };
        }
        #endregion Private
    }
}
