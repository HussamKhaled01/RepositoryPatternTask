using Moq;
using Xunit;
using RepositoryPatternTask.Models;
using RepositoryPatternTask.Services.Categories;
using RepositoryPatternTask.Data.GenericRepository;

namespace RepositoryPatternTask.Tests.Services.Categories
{
    public class CategoryServiceTests
    {
        private readonly Mock<IGenericRepository<Category>> _mockCategoryRepo;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _mockCategoryRepo = new Mock<IGenericRepository<Category>>();
            _categoryService = new CategoryService(_mockCategoryRepo.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenCategoryExists_ShouldReturnCategory()
        {
            var categoryId = "123";
            var expectedCategory = new Category { Id = categoryId, Name = "Test Category" };
            
            _mockCategoryRepo
                .Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(expectedCategory);

            var result = await _categoryService.GetByIdAsync(categoryId);

            Assert.NotNull(result);
            Assert.Equal(categoryId, result.Id);
            Assert.Equal("Test Category", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenCategoryDoesNotExist_ShouldThrowExceptionWithInnerKeyNotFound()
        {
            var invalidId = "999";
            
            _mockCategoryRepo
                .Setup(repo => repo.GetByIdAsync(invalidId))
                .ReturnsAsync((Category)null!);

            var exception = await Assert.ThrowsAsync<Exception>(() => _categoryService.GetByIdAsync(invalidId));
            
            Assert.Equal("Failed to return category", exception.Message);
            Assert.IsType<KeyNotFoundException>(exception.InnerException);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCategories()
        {
            var expectedCategories = new List<Category> 
            { 
                new Category { Id = "1", Name = "Cat1" }, 
                new Category { Id = "2", Name = "Cat2" } 
            };
            
            _mockCategoryRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCategories);

            var result = await _categoryService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallRepositoryCreate()
        {
            var category = new Category { Name = "New Category" };

            await _categoryService.CreateAsync(category);

            _mockCategoryRepo.Verify(repo => repo.CreateAsync(category), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdate()
        {
            var category = new Category { Id = "1", Name = "Updated Category" };

            await _categoryService.UpdateAsync(category);

            _mockCategoryRepo.Verify(repo => repo.UpdateAsync(category), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            var categoryId = "123";

            await _categoryService.DeleteAsync(categoryId);

            _mockCategoryRepo.Verify(repo => repo.DeleteAsync(categoryId), Times.Once);
        }
    }
}
