using Entities.Models;

namespace Entities.Dtos.Order
{
    public record OrderDto
    {
        public Guid Id { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        public string? Fullname { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}
