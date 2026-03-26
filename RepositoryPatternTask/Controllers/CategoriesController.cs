using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.DTOs.Categories;
using RepositoryPatternTask.Models;
using RepositoryPatternTask.Services.Categories;

namespace RepositoryPatternTask.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                var result = categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                return Ok(new CategoryDto { Id = category.Id, Name = category.Name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            try
            {
                var category = new Category { Name = dto.Name };
                await _categoryService.CreateAsync(category);
                return Ok(new CategoryDto { Id = category.Id, Name = category.Name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CategoryCreateDto dto)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                category.Name = dto.Name;
                await _categoryService.UpdateAsync(category);
                return Ok(new CategoryDto { Id = category.Id, Name = category.Name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
