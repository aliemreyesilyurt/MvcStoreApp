namespace Entities.Dtos.Product
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public decimal Price { get; init; }
        public string Summary { get; init; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; init; }
    }
}
