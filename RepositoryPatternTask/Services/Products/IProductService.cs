using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Services.Products
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(string id);
        public Task<List<Product>> GetByCategoryIdAsync(string categoryId);
        public Task CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(string id);
    }
}
