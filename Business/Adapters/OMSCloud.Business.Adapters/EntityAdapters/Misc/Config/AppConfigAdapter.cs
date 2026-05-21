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
    public partial class AppConfigAdapter
    {

        #region Select
        public List<AppConfigModel> GetAppConfigList()
        {
            var appConfigList = uow.AppConfigRepository.GetAll().Select(a => GetAppConfigModel(a)).ToList();
            return appConfigList;
        }

        public AppConfigModel GetAppConfigById(long Id)
        {
            var appConfig = uow.AppConfigRepository.GetById(Id);
            AppConfigModel appConfigModel = GetAppConfigModel(appConfig);
            return appConfigModel;
        }
        #endregion Select

        #region update
        public bool UpdateAppConfig(AppConfigModel appConfigModel)
        {
            try
            {
                var appConfig = UpdateConcurrency(GetEntity(appConfigModel), appConfigModel);
                var recordsCount = uow.OMSContext.AppConfig_Update(appConfig);


                return recordsCount > 0;

                //DO NOT USE LIKE BELOW
                //uow.OMSContext.AppConfig_Update(appConfig.ConfigID, appConfig.ConfigTitle, appConfig.ConfigValue, appConfig.DisplayText, appConfig.ParentConfigID, appConfig.Description);

                //Comment the below Commit Statement
                //uow.Commit();

                //Do not return hard coded TRUE
                //return true;

                //Instead return "recordsCount > 0"
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion update

        #region Add

        public long? AddAppConfig(AppConfigModel appConfigModel)
        {
            try
            {
                var appConfig = UpdateConcurrency(GetEntity(appConfigModel), appConfigModel, false);
                var outParam = new ObjectParameter("ConfigID", typeof(int));
                var recordsCount = uow.OMSContext.AppConfig_Insert(appConfig, outParam);

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
        public bool DeleteAppConfig(AppConfigModel appConfigModel)
        {
            try
            {
                var appConfigs = GetAppConfigEntity(appConfigModel);
                uow.AppConfigRepository.Delete(appConfigs);
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

        private AppConfigModel GetAppConfigModel(AppConfig appConfig)
        {
            return new AppConfigModel
            {
                ConfigID = appConfig.ConfigID,
                ConfigTitle = appConfig.ConfigTitle,
                ConfigValue = appConfig.ConfigValue,
                Description = appConfig.Description,
                DisplayText = appConfig.DisplayText,
                ParentConfigID = appConfig.ParentConfigID
            };
        }

        private AppConfig GetAppConfigEntity(AppConfigModel appConfigModel)
        {
            return new AppConfig
            {
                ConfigID = appConfigModel.ConfigID,
                ConfigTitle = appConfigModel.ConfigTitle,
                ConfigValue = appConfigModel.ConfigValue,
                Description = appConfigModel.Description,
                DisplayText = appConfigModel.DisplayText,
                ParentConfigID = appConfigModel.ParentConfigID
            };
        }

        #endregion Private
    }
}
