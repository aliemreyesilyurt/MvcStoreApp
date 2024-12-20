﻿using Entities.Dtos.Product;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLastestProducts(int n, bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IEnumerable<Product> GetShowcasesProducts(bool trackChanges);
        Product? GetOneProduct(Guid id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(Guid id);
        ProductDtoForUpdate GetOneProductForUpdate(Guid id, bool trackChanges);
    }
}
