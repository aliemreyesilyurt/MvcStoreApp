using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public static readonly Guid BookCategoryId = Guid.NewGuid();
        public static readonly Guid ElectronicCategoryId = Guid.NewGuid();

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CategoryName).IsRequired();

            builder.HasData(
                new Category() { Id = BookCategoryId, CategoryName = "Book" },
                new Category() { Id = ElectronicCategoryId, CategoryName = "Electronic" }
            );
        }
    }
}
