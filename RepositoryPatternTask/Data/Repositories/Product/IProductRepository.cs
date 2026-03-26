using RepositoryPatternTask.Data.GenericRepository;
using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Data.Repositories.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Entity-specific query: get all products that belong to a category
        Task<List<Product>> GetByCategoryIdAsync(string categoryId);
    }
}
