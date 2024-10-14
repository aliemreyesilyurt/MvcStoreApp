using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.Product
{
    public record ProductDto
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; init; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = String.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
    }
}
