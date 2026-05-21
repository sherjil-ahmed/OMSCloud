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
    public partial class AppConfigBusinessComponent
    {
        public List<AppConfigModel> GetAppConfigList()
        {
            return adapter.GetAppConfigList();
        }
        public AppConfigModel GetAppConfigById(long Id)
        {
            return adapter.GetAppConfigById(Id);
        }
        public long? AddAppConfig(AppConfigModel appConfig)
        {
            return adapter.AddAppConfig(appConfig);
        }
        public bool UpdateAppConfig(AppConfigModel appConfig)
        {
            return adapter.UpdateAppConfig(appConfig);
        }
        public bool DeleteAppConfig(AppConfigModel appConfig)
        {
            return adapter.DeleteAppConfig(appConfig);
        }
    }
}
