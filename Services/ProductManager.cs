﻿using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateProduct(Product product)
        {
            _repositoryManager.Product.CreateProduct(product);
            _repositoryManager.Save();
        }

        public void UpdateOneProduct(Product product)
        {
            var entity = _repositoryManager.Product.GetOneProduct(product.Id, true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;

            _repositoryManager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var product = GetOneProduct(id, false);

            if (product is not null)
            {
                _repositoryManager.Product.DeleteProduct(product);
                _repositoryManager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);

            if (product is null)
                throw new Exception("Product not found!");

            return product;
        }


    }
}