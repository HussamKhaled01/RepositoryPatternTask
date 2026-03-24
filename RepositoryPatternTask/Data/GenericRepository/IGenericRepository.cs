namespace RepositoryPatternTask.Data.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(string id);
        public Task CreateAsync(T entity);
        
    }
}
