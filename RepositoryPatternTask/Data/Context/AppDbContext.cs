using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.Models;

namespace RepositoryPatternTask.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            var electronicsId = "11111111-1111-1111-1111-111111111111";
            var clothingId = "22222222-2222-2222-2222-222222222222";
            var booksId = "33333333-3333-3333-3333-333333333333";
            var sportsId = "44444444-4444-4444-4444-444444444444";
            var foodId = "55555555-5555-5555-5555-555555555555";

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = electronicsId, Name = "Electronics" },
                new Category { Id = clothingId, Name = "Clothing" },
                new Category { Id = booksId, Name = "Books" },
                new Category { Id = sportsId, Name = "Sports" },
                new Category { Id = foodId, Name = "Food" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                // Electronics
                new Product { Id = "11111111-0000-0000-0000-000000000001", Name = "Laptop", Price = 999.99m, CategoryId = electronicsId },
                new Product { Id = "11111111-0000-0000-0000-000000000002", Name = "Smartphone", Price = 699.99m, CategoryId = electronicsId },
                new Product { Id = "11111111-0000-0000-0000-000000000003", Name = "Headphones", Price = 149.99m, CategoryId = electronicsId },
                new Product { Id = "11111111-0000-0000-0000-000000000004", Name = "Tablet", Price = 499.99m, CategoryId = electronicsId },
                new Product { Id = "11111111-0000-0000-0000-000000000005", Name = "Smart Watch", Price = 249.99m, CategoryId = electronicsId },

                // Clothing
                new Product { Id = "22222222-0000-0000-0000-000000000001", Name = "T-Shirt", Price = 19.99m, CategoryId = clothingId },
                new Product { Id = "22222222-0000-0000-0000-000000000002", Name = "Jeans", Price = 49.99m, CategoryId = clothingId },
                new Product { Id = "22222222-0000-0000-0000-000000000003", Name = "Jacket", Price = 89.99m, CategoryId = clothingId },
                new Product { Id = "22222222-0000-0000-0000-000000000004", Name = "Sneakers", Price = 79.99m, CategoryId = clothingId },
                new Product { Id = "22222222-0000-0000-0000-000000000005", Name = "Hat", Price = 14.99m, CategoryId = clothingId },

                // Books
                new Product { Id = "33333333-0000-0000-0000-000000000001", Name = "Clean Code", Price = 34.99m, CategoryId = booksId },
                new Product { Id = "33333333-0000-0000-0000-000000000002", Name = "The Pragmatic Programmer", Price = 39.99m, CategoryId = booksId },
                new Product { Id = "33333333-0000-0000-0000-000000000003", Name = "Design Patterns", Price = 44.99m, CategoryId = booksId },
                new Product { Id = "33333333-0000-0000-0000-000000000004", Name = "C# in Depth", Price = 29.99m, CategoryId = booksId },
                new Product { Id = "33333333-0000-0000-0000-000000000005", Name = "ASP.NET Core", Price = 37.99m, CategoryId = booksId },

                // Sports
                new Product { Id = "44444444-0000-0000-0000-000000000001", Name = "Football", Price = 24.99m, CategoryId = sportsId },
                new Product { Id = "44444444-0000-0000-0000-000000000002", Name = "Tennis Racket", Price = 59.99m, CategoryId = sportsId },
                new Product { Id = "44444444-0000-0000-0000-000000000003", Name = "Yoga Mat", Price = 29.99m, CategoryId = sportsId },
                new Product { Id = "44444444-0000-0000-0000-000000000004", Name = "Running Shoes", Price = 89.99m, CategoryId = sportsId },
                new Product { Id = "44444444-0000-0000-0000-000000000005", Name = "Dumbbells", Price = 39.99m, CategoryId = sportsId },

                // Food
                new Product { Id = "55555555-0000-0000-0000-000000000001", Name = "Protein Bar", Price = 2.99m, CategoryId = foodId },
                new Product { Id = "55555555-0000-0000-0000-000000000002", Name = "Olive Oil", Price = 9.99m, CategoryId = foodId },
                new Product { Id = "55555555-0000-0000-0000-000000000003", Name = "Green Tea", Price = 5.99m, CategoryId = foodId },
                new Product { Id = "55555555-0000-0000-0000-000000000004", Name = "Almonds", Price = 7.99m, CategoryId = foodId },
                new Product { Id = "55555555-0000-0000-0000-000000000005", Name = "Honey", Price = 6.99m, CategoryId = foodId }
            );
        }
    }
}

