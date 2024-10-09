namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
