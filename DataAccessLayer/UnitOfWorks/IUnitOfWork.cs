using DataAccessLayer.Repositories;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveAsync();
        int Save();
    }
}
