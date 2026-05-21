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
    public partial class DataTypeAdapter
    {
        #region Select
        public List<DataTypeModel> GetDataTypeList()
        {
            var dataTypeList = uow.DataTypeRepository.GetAll().Select(a => GetDataTypeModel(a)).ToList();
            return dataTypeList;
        }
        public DataTypeModel GetDataTypeById(long Id)
        {
            var dataType = uow.DataTypeRepository.GetById(Id);
            DataTypeModel dataTypeMOdel = GetDataTypeModel(dataType);
            return dataTypeMOdel;
        }
        #endregion Select

        #region Update

        public bool UpdateDataType(DataTypeModel dataTypeModel)
        {
            try
            {
                var dataType = UpdateConcurrency(GetEntity(dataTypeModel), dataTypeModel);
                var recordsCount = uow.OMSContext.DataType_Update(dataType);

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
        public long? AddDataType(DataTypeModel dataTypeModel)
        {
            try
            {
                var outParam = new ObjectParameter("DataTypeID", typeof(int));

                var dataType = UpdateConcurrency(GetEntity(dataTypeModel), dataTypeModel);
                var recordsCount = uow.OMSContext.DataType_Insert(dataType, outParam);

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
        public bool DeleteDataType(DataTypeModel dataTypeModel)
        {
            try
            {
                var DataType = GetDataTypeEntity(dataTypeModel);
                uow.DataTypeRepository.Delete(DataType);
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
        private DataTypeModel GetDataTypeModel(DataType dataType)
        {
            return new DataTypeModel()
            {
                DataTypeID = dataType.DataTypeID,
                AssemblyName = dataType.AssemblyName,
                ClassName = dataType.ClassName,
                FriendlyName = dataType.FriendlyName,
                Namespace = dataType.Namespace
            };
        }
        private DataType GetDataTypeEntity(DataTypeModel dataTypeModel)
        {
            return new DataType()
            {
                DataTypeID = dataTypeModel.DataTypeID,
                AssemblyName = dataTypeModel.AssemblyName,
                ClassName = dataTypeModel.ClassName,
                FriendlyName = dataTypeModel.FriendlyName,
                Namespace = dataTypeModel.Namespace
            };
        }
        #endregion Private
    }
}
