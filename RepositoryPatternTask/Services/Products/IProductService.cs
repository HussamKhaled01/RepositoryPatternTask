using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<List<Product>> GetByCategoryIdAsync(string categoryId);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(string id);
    }
}
