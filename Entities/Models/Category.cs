using Entities.Models.Common;

namespace Entities.Models
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; } = String.Empty;

        public ICollection<Product> Products { get; set; }
    }
}
