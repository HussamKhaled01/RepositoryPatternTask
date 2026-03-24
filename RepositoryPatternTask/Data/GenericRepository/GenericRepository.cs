using RepositoryPatternTask.Data.Context;

namespace RepositoryPatternTask.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }        
        public async Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
