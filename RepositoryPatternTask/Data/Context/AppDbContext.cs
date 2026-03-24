using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternTask.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {            
        }


    }
}
