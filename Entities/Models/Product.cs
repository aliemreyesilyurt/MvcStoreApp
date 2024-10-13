using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
