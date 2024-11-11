using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/1.jpg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/2.jpg", ProductName = "Keyboard", Price = 1_000, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/3.jpg", ProductName = "Mouse", Price = 500, ShowCase = true },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/4.jpg", ProductName = "Monitor", Price = 3_700, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/5.jpg", ProductName = "Head Set", Price = 2_000, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.BookCategoryId, ImageUrl = "/images/6.jpg", ProductName = "History", Price = 75, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.BookCategoryId, ImageUrl = "/images/7.jpg", ProductName = "Hamlet", Price = 100, ShowCase = false },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.BookCategoryId, ImageUrl = "/images/6.jpg", ProductName = "Sefiller", Price = 170, ShowCase = true },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/1.jpg", ProductName = "PC X10", Price = 20_000, ShowCase = true },
                new Product() { Id = Guid.NewGuid(), CategoryId = CategoryConfig.ElectronicCategoryId, ImageUrl = "/images/2.jpg", ProductName = "Mechanic Keyboard", Price = 300, ShowCase = true }
            );
        }
    }
}
