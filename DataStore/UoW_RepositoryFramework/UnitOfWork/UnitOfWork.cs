using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Framework.DBContextFactory;
using Framework.IRepositories;
using Framework.Repositories;
using Framework.Entity;
using System.Data.Entity.Infrastructure;

namespace Framework.UnitofWork
{
    public class UnitOfWork<TContext> : IUnitofWork where TContext : DbContext, new()
    {
        #region DataMemeber

        //private Dictionary<string, object> _repositories;
        private TContext _dataContext;
        private IDBFactory _dbFactory;
        private bool _disposed;

        #endregion DataMemeber

        #region Constructors
        public UnitOfWork(IDBFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            _dataContext = dbFactory.DataContext as TContext;
        }

        public IRepositoryBase<TEntity> GetRepository<TRepositoryBase, TEntity>()
            where TEntity : BaseEntity
            where TRepositoryBase : IRepositoryBase<TEntity>
        {
            //if (_repositories == null)
            //    _repositories = new Dictionary<string, object>();

            var repositoryType = typeof(TRepositoryBase);
            var entityType = typeof(TEntity);
            if (repositoryType == null || entityType == null)
                throw new InvalidOperationException(String.Format("No implementation of required Repository was found"));

            var key = repositoryType.Name + "::" + entityType.Name;

            //if (_repositories.ContainsKey(key))
            //    return _repositories[key] as IRepositoryBase<TEntity>;

            try
            {
                var repository = Activator.CreateInstance(repositoryType, this._dataContext);
                if (repository == null)
                    throw new InvalidOperationException(String.Format("Unable to create instance of the required Repository. May be the constructor for the DataContext was not found"));

                //_repositories.Add(key, repository);
                return repository as IRepositoryBase<TEntity>;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IRepositoryBase<TEntity> GetGenericRepository<TEntity>() where TEntity : BaseEntity
        {
            return this.GetRepository<IRepositoryBase<TEntity>, TEntity>();
        }

        #endregion Constructors

        #region Context
        protected DbContext DataContext
        {
            get { return this._dataContext ?? _dbFactory.DataContext; }
        }

        public int Commit()
        {
            try
            {
                if (_dataContext.ChangeTracker.HasChanges())
                    return _dataContext.SaveChanges();
                return 0;
            }
            catch (DbUpdateConcurrencyException dbUCEx)
            {
                // handle concurrency related error here
                throw dbUCEx;
            }
            catch (DbUpdateException dbUEx)
            {
                throw dbUEx;
            }
            //DbEntityValidationException
            //NotSupportedException
            //ObjectDisposedException
            catch (Exception ex)
            {
                // handle general error here
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
        #endregion Context

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                //this._dataContext.Dispose();
                GC.SuppressFinalize(this);
            }
            _disposed = true;
        }
        #endregion Dispose
    }
}
