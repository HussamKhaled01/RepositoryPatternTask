using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(string id);
    }
}
