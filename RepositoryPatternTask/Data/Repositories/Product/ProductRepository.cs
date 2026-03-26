using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.Data.Context;
using RepositoryPatternTask.Data.GenericRepository;
using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Data.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetByCategoryIdAsync(string categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
