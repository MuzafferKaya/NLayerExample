namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
