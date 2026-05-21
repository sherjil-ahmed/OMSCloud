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
    public partial class MediaContentTypeBusinessComponent
    {
        public List<MediaContentTypeModel> GetMediaContentTypeList()
        {
            return adapter.GetMediaContentTypeList();
        }
        public MediaContentTypeModel GetMediaContentTypeById(long Id)
        {
            return adapter.GetMediaContentTypeById(Id);
        }
        public long? AddMediaContentType(MediaContentTypeModel MediaContentType)
        {
            return adapter.AddMediaContentType(MediaContentType);
        }
        public bool UpdateMediaContentType(MediaContentTypeModel MediaContentType)
        {
            return adapter.UpdateMediaContentType(MediaContentType);
        }
        public bool DeleteMediaContentType(MediaContentTypeModel MediaContentType)
        {
            return adapter.DeleteMediaContentType(MediaContentType);
        }
    }
}
