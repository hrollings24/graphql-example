using System;
using GraphQLTest.Entities;
using GraphQLTest.Models;
using GraphQLTest.Repositories;

namespace GraphQLTest.Resolvers
{
	public class Mutation
	{
        private readonly IProductRepository _productRepository;
        private readonly IExtendedPropertyRepository _extendedPropertyRepository;

        public Mutation(IProductRepository productRepository, IExtendedPropertyRepository extendedPropertyRepository)
        {
            _productRepository = productRepository;
            _extendedPropertyRepository = extendedPropertyRepository;
        }

        public async Task<ProductModel> CreateProduct(CreateProductRequest request)
		{
            var productEntity = new ProductModel()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Title = request.Title,
                Price = request.Price
            };

            return await _productRepository.Create(productEntity);
        }

        public async Task<ExtendedPropertyModel> CreateExtendedProperty(CreateExtendedPropertiesRequest request)
        {
            var epEntity = new ExtendedPropertyModel()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Value = request.Value,
                Type = request.Type,
                ProductId = Guid.Parse(request.ProductId)
            };

            return await _extendedPropertyRepository.Create(epEntity);
        }
    }
}

