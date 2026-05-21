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
    public partial class DataTypeBusinessComponent
    {
        public List<DataTypeModel> GetDataTypeList()
        {
            return adapter.GetDataTypeList();
        }
        public DataTypeModel GetDataTypeById(long Id)
        {
            return adapter.GetDataTypeById(Id);
        }
        public long? AddDataType(DataTypeModel dataType)
        {
            return adapter.AddDataType(dataType);
        }
        public bool UpdateDataType(DataTypeModel dataType)
        {
            return adapter.UpdateDataType(dataType);
        }
        public bool DeleteDataType(DataTypeModel dataType)
        {
            return adapter.DeleteDataType(dataType);
        }
    }
}
