using System;
using System.Data.Entity;

namespace Framework.DBContextFactory
{
    public interface IDBFactory : IDisposable
    {
        DbContext DataContext{get;}
    }
}
