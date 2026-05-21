using System;
using System.Collections.Generic;

namespace Framework.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(List<TEntity> entities);
        void Update(TEntity entity);
        void Update(List<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(List<TEntity> entities);
        void Delete(Func<TEntity, Boolean> predicate);
        TEntity GetById(long Id);
        TEntity Get(Func<TEntity, Boolean> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        bool Any(Func<TEntity, Boolean> where);
    }
}
