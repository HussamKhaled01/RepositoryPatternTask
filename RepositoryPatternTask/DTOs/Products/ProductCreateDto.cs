namespace RepositoryPatternTask.DTOs.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryId { get; set; } = string.Empty;
    }
}
