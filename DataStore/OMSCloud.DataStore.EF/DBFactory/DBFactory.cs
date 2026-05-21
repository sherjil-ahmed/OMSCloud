using System.Data.Entity;
//using System.Data.Entity;
using Framework.DBContextFactory;
using Framework;
using OMSCloud.DataStore.EF.OMSModel;
using System.Web;
using System;
using OMSCloud.Contracts.Common;

namespace OMSCloud.DataStore.EF.Factory
{
    /// <summary>
    /// It provides the singalton context of DB
    /// </summary>
    public sealed class DBFactory : Disposable, IDBFactory
    {
        private OMSContext context;
        private static DBFactory factory;

        private DBFactory()
        {
            //NLogger.Log.Debug("Constructor OMSCloud.DataStore.EF.Factory.DBFactory");
        }

        public static IDBFactory Instance
        {
            get
            {
                if (factory == null)
                    factory = new DBFactory();
                return factory;
            }
        }

        public DbContext DataContext
        {
            get
            {
                //context = (OMSContext)(WebApiSession.DbContext ?? (WebApiSession.DbContext = OMSContext.CreateInstance()));
                context = OMSContext.Instance();
                return context;
            }
        }
        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
