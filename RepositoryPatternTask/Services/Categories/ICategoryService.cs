using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Services.Categories
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(string id);
        public Task CreateAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(string id);
    }
}
