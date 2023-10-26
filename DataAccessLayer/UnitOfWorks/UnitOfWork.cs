using DataAccessLayer.Context;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task BeginTransactionAsync()
        {
            await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _appDbContext.Database.RollbackTransactionAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_appDbContext);
        }
    }
}
