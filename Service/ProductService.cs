﻿
using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contract;
using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(Guid sellerId, bool trackChanges)
        {
            try
            {
                var product = await _repositoryManager.Product.GetAllProductAsync(sellerId , trackChanges:false);
                foreach (var p in product)
                {
                    _loggerManager.LogDebug($"Retrieved product: {p.ProductName}, Description: {p.ProductDescription}, Price: {p.Price}");
                }
                var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);
                return productDto;

            }
           catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllProductsAsync)} service method {ex}");
                throw ;
            }
            
        }

        public async Task<ProductDto> CreateProductAsync(Guid sellerId, ProductForCreationDto productForCreation, bool trackChanges)
        {
            try
            {
                var seller = await _repositoryManager.Seller.GetSellerAsync(sellerId, trackChanges);
                //throw exception here


                var productEntity  = _mapper.Map<Product>(productForCreation);//mapping Dto to an entity
               await _repositoryManager.Product.createProduct(sellerId , productEntity); // call the repo method to create new employee
                await _repositoryManager.SaveAsync();
                var productToReturn = _mapper.Map<ProductDto>(productEntity);
                return productToReturn;



            }catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(CreateProductAsync)} service method {ex}");
                throw ;
            }
        }

        //public async Task UpdateProductById(Guid sellerId, Guid productId, ProductDto product, bool prodtrackChanges)
        //{

        //    var sellerEntity = await _repositoryManager.Seller.GetSellerAsync(sellerId,  prodtrackChanges);
           

        //    var productEntity = _repositoryManager.Product.getProductAsync(sellerId,productId, );


        //    _mapper.Map(prForUpdate, employeeEntity);
        //    _repository.SaveAsync();
        //}

        public async Task<ProductDto> GetProductAsync(Guid sellerId, Guid productId, bool trackchanges)
        {
            var seller = await _repositoryManager.Seller.GetSellerAsync(sellerId, trackchanges);

            var productDb = await _repositoryManager.Product.getProductAsync(sellerId,productId, trackchanges);

            var product = _mapper.Map<ProductDto>(productDb);
            return product;
        }

        public async Task UpdateProductById(Guid sellerId, Guid productId, ProductforUpdateDto productForUpdate, bool selltrackChanges, bool prodtrackChanges)
        {
           // var sellerEntity = await _repositoryManager.Seller.GetSellerAsync(sellerId, selltrackChanges);
            var productEntity = await _repositoryManager.Product.getProductAsync(sellerId, productId, prodtrackChanges);

            _mapper.Map(productForUpdate, productEntity);
            await _repositoryManager.SaveAsync();
        }

        //Delete
        public async Task DeleteProductAsync(Guid sellerId, Guid productId, bool trackChanges)
        {
            var product = await _repositoryManager.Product.getProductAsync(sellerId, productId , trackChanges);
            
            _repositoryManager.Product.DeleteProduct(product);
            await _repositoryManager.SaveAsync();

        }
    }
}
