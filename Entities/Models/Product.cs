using Entities.Models.Common;

namespace Entities.Models
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Summary { get; set; }
        public string ImageUrl { get; set; }

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool ShowCase { get; set; }
    }
}
