using Entities.Models.Common;

namespace Entities.Models
{
    public class CartLine : BaseEntity
    {
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
