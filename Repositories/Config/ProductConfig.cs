﻿using Entities.Models;
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
                new Product() { Id = 1, CategoryId = 2, ProductName = "Computer", Price = 17_000 },
                new Product() { Id = 2, CategoryId = 2, ProductName = "Keyboard", Price = 1_000 },
                new Product() { Id = 3, CategoryId = 2, ProductName = "Mouse", Price = 500 },
                new Product() { Id = 4, CategoryId = 2, ProductName = "Monitor", Price = 3_700 },
                new Product() { Id = 5, CategoryId = 2, ProductName = "Head Set", Price = 2_000 },
                new Product() { Id = 6, CategoryId = 1, ProductName = "History", Price = 75 },
                new Product() { Id = 7, CategoryId = 1, ProductName = "Hamlet", Price = 100 }
            );
        }
    }
}