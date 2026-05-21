using Framework.Entity;
using Framework.Repositories;
using OMSCloud.DataStore.EF.OMSModel;

namespace OMSCloud.DataStore.EF.Repositories
{
    public class OMSRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public OMSRepositoryBase(OMSContext datacontext)
            : base(datacontext)
        {
        }

        public OMSContext OMSContext { get { return (OMSContext)base._dataContext; } }

    }
}
