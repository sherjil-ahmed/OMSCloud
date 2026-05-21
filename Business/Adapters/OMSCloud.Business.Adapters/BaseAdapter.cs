using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.UnitofWork;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.DataStore.EF.Repositories;
using Framework.Repositories;
using Framework.Entity;

namespace OMSCloud.Business.Adapters
{
    public interface IAdapter<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        List<TModel> GetList();
        TModel GetById(long Id);
        bool Update(TModel model);
        long? Add(TModel model);
        bool Delete(TModel model);
        bool Delete(long Id);
    }
    public abstract class BaseAdapter<TEntity, TModel> : IAdapter<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        protected OMSUnitOfWork uow = new OMSUnitOfWork();
        protected abstract OMSRepositoryBase<TEntity> Repo { get; }

        #region Select
        public List<TModel> GetList()
        {
            var List = Repo.GetAll().Select(
                a => GetModel(a)
            ).ToList();
            return List;
        }

        public TModel GetById(long Id)
        {
            var entity = Repo.GetById(Id);
            if (entity == null)
                return null;
            TModel model = GetModel(entity);
            return model;
        }

        #endregion Select

        #region Update

        public bool Update(TModel model)
        {
            try
            {
                var entity = UpdateConcurrency(GetEntity(model), model, true);
                Repo.Update(entity);
                return uow.Commit() > 0;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return false;
            }
            finally
            {

            }
        }
        #endregion Update

        #region Add

        public long? Add(TModel model)
        {
            try
            {
                TEntity entity = UpdateConcurrency(GetEntity(model), model, false);

                Repo.Add(entity);

                return uow.Commit();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return null;
            }
            finally
            {
            }
        }

        #endregion Add

        #region Delete
        public bool Delete(TModel model)
        {
            try
            {
                var address = GetEntity(model);
                Repo.Delete(address);
                return uow.Commit() > 0;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return false;
            }
            finally
            {
            }
        }
        public abstract bool Delete(long Id);
        #endregion Delete

        #region Private
        protected abstract TModel GetModel(TEntity entity);

        protected TModel GetModelWithConcurrency(TEntity entity, TModel model)
        {
            if (entity is ConcurrentBaseEntity && model is ConcurrencyBaseModel)
            {
                var entityType = typeof(TEntity);

                ConcurrencyBaseModel cbModel = model as ConcurrencyBaseModel;

                var createdBy = entityType.GetProperty("CreatedByUserID", typeof(long)) ?? entityType.GetProperty("CreatedByUserID", typeof(long?));
                cbModel.CreatedBy = (long)(createdBy?.GetValue(entity));

                var createdOn = entityType.GetProperty("CreatedDateTime", typeof(DateTime)) ?? entityType.GetProperty("CreatedDateTime", typeof(DateTime?));
                cbModel.CreatedOn = (DateTime)(createdOn?.GetValue(entity));

                var modifiedBy = entityType.GetProperty("LastModifiedByUserID", typeof(long)) ?? entityType.GetProperty("LastModifiedByUserID", typeof(long?));
                cbModel.ModifiedBy = (long)(modifiedBy?.GetValue(entity));

                var modifiedOn = entityType.GetProperty("LastModifiedDateTime", typeof(DateTime)) ?? entityType.GetProperty("LastModifiedDateTime", typeof(DateTime?));
                cbModel.ModifiedOn = (DateTime)(modifiedOn?.GetValue(entity));
            }
            return model;
        }

        protected abstract TEntity GetEntity(TModel model);

        protected TEntity UpdateConcurrency(TEntity entity, BaseModel model, bool isUpdate = true)
        {
            if (entity is ConcurrentBaseEntity && model is ConcurrencyBaseModel)
            {
                ConcurrencyBaseModel cbModel = model as ConcurrencyBaseModel;

                var entityType = typeof(TEntity);

                var CreatedBy = entityType.GetProperty("CreatedByUserID", typeof(long)) ?? entityType.GetProperty("CreatedByUserID", typeof(long?));
                var CreatedOn = entityType.GetProperty("CreatedDateTime", typeof(DateTime)) ?? entityType.GetProperty("CreatedDateTime", typeof(DateTime?));
                var ModifiedBy = entityType.GetProperty("LastModifiedByUserID", typeof(long)) ?? entityType.GetProperty("LastModifiedByUserID", typeof(long?));
                var ModifiedOn = entityType.GetProperty("LastModifiedDateTime", typeof(DateTime)) ?? entityType.GetProperty("LastModifiedDateTime", typeof(DateTime?));


                //follwoing code is extremly required as each SP that need sp_User Param, it is used by ModifiedBy Field
                if (!isUpdate)
                {
                    CreatedBy?.SetValue(entity, model.RequestedByProfileId);
                    CreatedOn?.SetValue(entity, DateTime.Now);
                    ModifiedBy?.SetValue(entity, model.RequestedByProfileId);
                    ModifiedOn.SetValue(entity, DateTime.Now);
                }
                else
                {
                    CreatedBy?.SetValue(entity, cbModel.CreatedBy);
                    CreatedOn?.SetValue(entity, cbModel.CreatedOn);
                    ModifiedBy?.SetValue(entity, model.RequestedByProfileId);
                    ModifiedOn.SetValue(entity, cbModel.ModifiedOn);
                }
            }
            return entity;

        }
        #endregion Private
    }
}
