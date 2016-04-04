using System;
using System.Data.Entity;

namespace Repository.Interface
{
    public interface IRepositoryContext : IDisposable
    {
        IDbSet<T> DbSet<T>() where T : class;

        int SaveChanges();
    }
}
