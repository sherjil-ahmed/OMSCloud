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
    public partial class MediaContentTypeAdapter
    {


        #region Select
        public List<MediaContentTypeModel> GetMediaContentTypeList()
        {
            var medaiaContentTypeList = uow.MediaContentTypeRepository.GetAll().Select(a => GetMediaContentTypeModel(a)).ToList();
            return medaiaContentTypeList;
        }

        public MediaContentTypeModel GetMediaContentTypeById(long Id)
        {
            var mediaContentType = uow.MediaContentTypeRepository.GetById(Id);
            MediaContentTypeModel mediaContentTypeModel = GetMediaContentTypeModel(mediaContentType);
            return mediaContentTypeModel;
        }


        #endregion Select

        #region Update

        public bool UpdateMediaContentType(MediaContentTypeModel mediaContentTypeModel)
        {
            try
            {
                var mediaContentType = UpdateConcurrency(GetEntity(mediaContentTypeModel), mediaContentTypeModel);
                var recordsCount = uow.OMSContext.MediaContentType_Update(mediaContentType);
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

        public long? AddMediaContentType(MediaContentTypeModel mediaContentTypeModel)
        {
            try
            {
                var outParam = new ObjectParameter("MediaContentTypeID", typeof(int));

                var mediaContentType = UpdateConcurrency(GetEntity(mediaContentTypeModel), mediaContentTypeModel);
                var recordsCount = uow.OMSContext.MediaContentType_Insert(mediaContentType, outParam);
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
        public bool DeleteMediaContentType(MediaContentTypeModel mediaContentTypeModel)
        {
            try
            {
                var mediaContentType = GetMediaContentTypeEntity(mediaContentTypeModel);
                uow.MediaContentTypeRepository.Delete(mediaContentType);
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
        private MediaContentTypeModel GetMediaContentTypeModel(MediaContentType mediaContentType)
        {
            return new MediaContentTypeModel()
            {
                MediaContentTypeID = mediaContentType.MediaContentTypeID,
                DisplayText = mediaContentType.DisplayText,
                Description = mediaContentType.Description,
                HTMLContentTypeText = mediaContentType.HTMLContentTypeText,
                IconPath = mediaContentType.IconPath
            };
        }
        private MediaContentType GetMediaContentTypeEntity(MediaContentTypeModel mediaContentTypeModel)
        {
            return new MediaContentType()
            {
                MediaContentTypeID = mediaContentTypeModel.MediaContentTypeID,
                DisplayText = mediaContentTypeModel.DisplayText,
                Description = mediaContentTypeModel.Description,
                HTMLContentTypeText = mediaContentTypeModel.HTMLContentTypeText,
                IconPath = mediaContentTypeModel.IconPath
            };
        }
        #endregion Private


    }
}
