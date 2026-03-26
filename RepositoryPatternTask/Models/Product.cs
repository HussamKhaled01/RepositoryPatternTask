namespace RepositoryPatternTask.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // FK
        public string CategoryId { get; set; } = string.Empty;

        // Navigation property
        public Category Category { get; set; } = null!;
    }
}
