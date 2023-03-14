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

        public async Task<Product> CreateProduct(CreateProductRequest request)
		{
            var productEntity = new Product()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Title = request.Title,
                Price = request.Price
            };

            return await _productRepository.Create(productEntity);
        }
	}
}

