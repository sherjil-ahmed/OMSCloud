using System;
using Framework.IRepositories;
using Framework.Repositories;
using Framework.Entity;

namespace Framework.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IRepositoryBase<TEntity> GetRepository<TRepositoryBase, TEntity>()
            where TEntity : BaseEntity
            where TRepositoryBase : IRepositoryBase<TEntity>;

        int Commit();
        void RollBack();
    }
}
