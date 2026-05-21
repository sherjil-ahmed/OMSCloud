using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Framework.IRepositories;
using Framework.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections;
using OMSCloud.Contracts.Caching;

namespace Framework.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _dataContext;
        protected readonly IDbSet<TEntity> dbset;

        protected RepositoryBase(DbContext dataContext)
        {
            this._dataContext = dataContext;
            dbset = this._dataContext.Set<TEntity>();
        }

        protected DbContext DBContext { get { return this._dataContext; } }


        public virtual void Add(TEntity entity)
        {
            dbset.Add(entity);
        }
        public virtual void Add(List<TEntity> entities)
        {
            entities.ForEach(entity => dbset.Add(entity));
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                this.DBContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Update(List<TEntity> entities)
        {
            try
            {
                entities.ForEach(entity => this.DBContext.Entry(entity).State = EntityState.Modified);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(List<TEntity> entities)
        {
            entities.ForEach(entity => dbset.Remove(entity));
        }

        public void Delete(Func<TEntity, Boolean> where)
        {
            IEnumerable<TEntity> objects = dbset.Where<TEntity>(where).AsEnumerable();
            foreach (TEntity obj in objects)
                dbset.Remove(obj);
        }
        public virtual TEntity GetById(long id)
        {
            var type = typeof(TEntity);
            var isCAacheable = type is ICacheableEntity;
            TEntity result = null;
            if (isCAacheable)
            {
                result = CacheManager.Get<TEntity>(type.FullName, "-ById="+id.ToString());
            }
            if (result == null)
            {
                result = dbset.Find(id);
                if (result != null)
                    CacheManager.Set(type.FullName, "-ById=" + id.ToString(), result);
            }
            return result;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            //ReloadFromDB();
            var type = typeof(TEntity);
            var isCAacheable = type is ICacheableEntity;
            IEnumerable<TEntity> result = null;
            if (isCAacheable)
            {
                result = CacheManager.Get<IEnumerable<TEntity>>(type.FullName, "-All");
            }
            if (result == null)
            {
                result = dbset.ToList();
                if(result != null)
                    CacheManager.Set(type.FullName, "-All", result);
            }
            return result;
        }

        public void ReloadFromDB()
        {
            //var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            //var refreshableObjects = _dataContext.ChangeTracker.Entries().Select(c => c.Entity).ToList();
            //context.Refresh(RefreshMode.StoreWins, refreshableObjects);
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return dbset.Where(where).ToList();
        }
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return dbset.Where(where).FirstOrDefault<TEntity>();
        }

        public TEntity GetLocal(Func<TEntity, Boolean> where)
        {
            return dbset.Local.Where(where).FirstOrDefault<TEntity>();
        }

        public bool Any(Func<TEntity, Boolean> where)
        {
            return dbset.Any(where);
        }
    }
}


