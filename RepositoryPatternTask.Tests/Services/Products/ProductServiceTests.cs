using Moq;
using Xunit;
using RepositoryPatternTask.Models;
using RepositoryPatternTask.Services.Products;
using RepositoryPatternTask.Services.Categories;
using RepositoryPatternTask.Data.Repositories.Products;

namespace RepositoryPatternTask.Tests.Services.Products
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly Mock<ICategoryService> _mockCategoryService;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockProductRepo = new Mock<IProductRepository>();
            _mockCategoryService = new Mock<ICategoryService>();
            
            _productService = new ProductService(_mockProductRepo.Object, _mockCategoryService.Object);
        }

        [Fact]
        public async Task CreateAsync_WhenCategoryExists_ShouldSuccessfullySaveProduct()
        {
            var product = new Product { Name = "Phone", Price = 500, CategoryId = "Cat1" };
            
            _mockCategoryService
                .Setup(cs => cs.GetByIdAsync("Cat1"))
                .ReturnsAsync(new Category { Id = "Cat1", Name = "Electronics" });

            await _productService.CreateAsync(product);

            _mockProductRepo.Verify(repo => repo.CreateAsync(product), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_WhenCategoryDoesNotExist_ShouldThrowException()
        {
            var product = new Product { Name = "Phone", Price = 500, CategoryId = "BadCategory" };
            
            _mockCategoryService
                .Setup(cs => cs.GetByIdAsync("BadCategory"))
                .ThrowsAsync(new Exception("Category not found"));

            await Assert.ThrowsAsync<Exception>(() => _productService.CreateAsync(product));
            
            _mockProductRepo.Verify(repo => repo.CreateAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            var expectedProducts = new List<Product> 
            { 
                new Product { Id = "1", Name = "Prod1" }, 
                new Product { Id = "2", Name = "Prod2" } 
            };
            
            _mockProductRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedProducts);

            var result = await _productService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductExists_ShouldReturnProduct()
        {
            var productId = "123";
            var expectedProduct = new Product { Id = productId, Name = "Test Product" };
            
            _mockProductRepo.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);

            var result = await _productService.GetByIdAsync(productId);

            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("Test Product", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductDoesNotExist_ShouldThrowExceptionWithInnerKeyNotFound()
        {
            var invalidId = "999";
            _mockProductRepo.Setup(repo => repo.GetByIdAsync(invalidId)).ReturnsAsync((Product)null!);

            var exception = await Assert.ThrowsAsync<Exception>(() => _productService.GetByIdAsync(invalidId));
            
            Assert.Equal("Failed to return product", exception.Message);
            Assert.IsType<KeyNotFoundException>(exception.InnerException);
        }

        [Fact]
        public async Task GetByCategoryIdAsync_ShouldReturnProducts()
        {
            var categoryId = "cat1";
            var expectedProducts = new List<Product> { new Product { Id = "1", CategoryId = categoryId } };
            
            _mockProductRepo.Setup(repo => repo.GetByCategoryIdAsync(categoryId)).ReturnsAsync(expectedProducts);

            var result = await _productService.GetByCategoryIdAsync(categoryId);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdate()
        {
            var product = new Product { Id = "1", Name = "Updated Product" };

            await _productService.UpdateAsync(product);

            _mockProductRepo.Verify(repo => repo.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            var productId = "123";

            await _productService.DeleteAsync(productId);

            _mockProductRepo.Verify(repo => repo.DeleteAsync(productId), Times.Once);
        }
    }
}
