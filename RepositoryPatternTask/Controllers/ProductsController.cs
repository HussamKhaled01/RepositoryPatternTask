using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.DTOs.Products;
using RepositoryPatternTask.Models;
using RepositoryPatternTask.Services.Products;

namespace RepositoryPatternTask.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                var result = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.Name ?? string.Empty
                });
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
                var product = await _productService.GetByIdAsync(id);
                return Ok(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category?.Name ?? string.Empty
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(string categoryId)
        {
            try
            {
                var products = await _productService.GetByCategoryIdAsync(categoryId);
                var result = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.Name ?? string.Empty
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            try
            {
                var product = new Product { Name = dto.Name, Price = dto.Price, CategoryId = dto.CategoryId };
                await _productService.CreateAsync(product);
                return Ok(new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price, CategoryId = product.CategoryId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ProductCreateDto dto)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.CategoryId = dto.CategoryId;
                await _productService.UpdateAsync(product);
                return Ok(new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price, CategoryId = product.CategoryId });
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
                await _productService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
