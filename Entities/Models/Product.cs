using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string Summary { get; set; } = String.Empty;
        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool ShowCase { get; set; }
    }
}
