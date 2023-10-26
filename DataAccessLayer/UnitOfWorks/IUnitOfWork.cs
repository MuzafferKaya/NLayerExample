using DataAccessLayer.Repositories;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
