using RepositoryPatternTask.Data.GenericRepository;
using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                return await _categoryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return categories", ex);
            }
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category is null)
                    throw new KeyNotFoundException("Category not found");
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return category", ex);
            }
        }

        public async Task CreateAsync(Category category)
        {
            try
            {
                await _categoryRepository.CreateAsync(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create category", ex);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update category", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _categoryRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete category", ex);
            }
        }
    }
}
