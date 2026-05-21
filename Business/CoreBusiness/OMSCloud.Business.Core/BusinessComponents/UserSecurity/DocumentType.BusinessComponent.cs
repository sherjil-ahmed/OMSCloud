using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class DocumentTypeBusinessComponent
    {
        public List<DocumentTypeModel> GetDocumentTypeList()
        {
            return adapter.GetDocumentTypeList();
        }
        public DocumentTypeModel GetDocumentTypeById(long Id)
        {
            return adapter.GetDocumentTypeById(Id);
        }
        public long? AddDocumentType(DocumentTypeModel documentTypeModel)
        {
            return adapter.AddDocumentType(documentTypeModel);
        }
        public bool UpdateDocumentType(DocumentTypeModel documentTypeModel)
        {
            return adapter.UpdateDocumentType(documentTypeModel);
        }
        public bool DeleteDocumentType(DocumentTypeModel documentTypeModel)
        {
            return adapter.DeleteDocumentType(documentTypeModel);
        }
    }
}
