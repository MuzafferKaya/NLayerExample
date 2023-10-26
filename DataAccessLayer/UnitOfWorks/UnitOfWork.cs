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
        public async ValueTask DisposeAsync()
        {
            await _appDbContext.DisposeAsync();
        }

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_appDbContext);
        }
    }
}
