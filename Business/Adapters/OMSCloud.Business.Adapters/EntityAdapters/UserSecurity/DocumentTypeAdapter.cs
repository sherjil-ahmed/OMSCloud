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
    public partial class DocumentTypeAdapter
    {
        #region Select

        public List<DocumentTypeModel> GetDocumentTypeList()
        {
            var documentTypeList = uow.DocumentTypeRepository.GetAll().Select(a => GetDocumentTypeModel(a)).ToList();
            return documentTypeList;
        }
        public DocumentTypeModel GetDocumentTypeById(long Id)
        {
            var documentType = uow.DocumentTypeRepository.GetById(Id);
            DocumentTypeModel documentTypeModel = GetDocumentTypeModel(documentType);
            return documentTypeModel;
        }
        #endregion Select

        #region update
        public bool UpdateDocumentType(DocumentTypeModel documentTypeModel)
        {
            var documentType = UpdateConcurrency(GetEntity(documentTypeModel), documentTypeModel);
            var recordsCount = uow.OMSContext.DocumentType_Update(documentType);

            return recordsCount > 0;
        }
        #endregion update

        #region Add

        public long? AddDocumentType(DocumentTypeModel documentTypeModel)
        {
            try
            {
                var documentType = UpdateConcurrency(GetEntity(documentTypeModel), documentTypeModel, false);
                var outParam = new ObjectParameter("DocumentTypeID", typeof(int));
                var recordsCount = uow.OMSContext.DocumentType_Insert(documentType, outParam);


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

        public bool DeleteDocumentType(DocumentTypeModel documentTypeModel)
        {
            try
            {
                var documentType = GetDocumentTypeEntity(documentTypeModel);
                uow.DocumentTypeRepository.Delete(documentType);
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

        private DocumentTypeModel GetDocumentTypeModel(DocumentType documentType)
        {
            return new DocumentTypeModel
            {
                DocumentTypeID = documentType.DocumentTypeID,
                DocumentTypeTitle = documentType.DocumentTypeTitle,
                Description = documentType.Description,
                IsSystem = documentType.IsSystem
            };
        }
        private DocumentType GetDocumentTypeEntity(DocumentTypeModel documentTypeModel)
        {
            return new DocumentType
            {
                DocumentTypeID = documentTypeModel.DocumentTypeID,
                DocumentTypeTitle = documentTypeModel.DocumentTypeTitle,
                Description = documentTypeModel.Description,
                IsSystem = documentTypeModel.IsSystem
            };
        }
        #endregion Private
    }
}
