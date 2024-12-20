﻿using AutoMapper;
using Entities.Dtos.Product;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        // DI
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        // Create
        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.CreateProduct(product);

            _repositoryManager.Save();
        }

        // Update
        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.UpdateOneProduct(entity);

            _repositoryManager.Save();
        }

        // Get Update
        public ProductDtoForUpdate GetOneProductForUpdate(Guid id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        // Delete
        public void DeleteOneProduct(Guid id)
        {
            var product = GetOneProduct(id, true);

            if (product is not null)
            {
                _repositoryManager.Product.DeleteProduct(product);
                _repositoryManager.Save();
            }
        }

        // Get All
        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetAllProducts(trackChanges);
        }

        // Get All With Details
        public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _repositoryManager.Product.GetAllProductsWithDetails(p);
        }

        // Get One
        public Product? GetOneProduct(Guid id, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetOneProduct(id, trackChanges);

            if (product is null)
                throw new Exception("Product not found!");

            return product;
        }

        // Get Showcase
        public IEnumerable<Product> GetShowcasesProducts(bool trackChanges)
        {
            return _repositoryManager.Product.GetShowcasesProducts(trackChanges);
        }

        // Get Lastest
        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _repositoryManager
                .Product
                .FindAll(trackChanges)
                .OrderByDescending(prd => prd.Id)
                .Take(n);
        }
    }
}