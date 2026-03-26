using RepositoryPatternTask.Data.Repositories.Products;
using RepositoryPatternTask.Models;
using RepositoryPatternTask.Services.Categories;

namespace RepositoryPatternTask.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;

        public ProductService(IProductRepository productRepository, ICategoryService categoryService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await _productRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return products", ex);
            }
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product is null)
                    throw new KeyNotFoundException("Product not found");
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return product", ex);
            }
        }

        public async Task<List<Product>> GetByCategoryIdAsync(string categoryId)
        {
            try
            {
                return await _productRepository.GetByCategoryIdAsync(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return products by category", ex);
            }   
        }

        public async Task CreateAsync(Product product)
        {
            try
            {
                await _categoryService.GetByIdAsync(product.CategoryId);
                await _productRepository.CreateAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create product", ex);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update product", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete product", ex);
            }
        }
    }
}
