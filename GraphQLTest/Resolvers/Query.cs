using System;
using GraphQLTest.Entities;
using GraphQLTest.Repositories;

namespace GraphQLTest.Resolvers
{
    public class Query
    {
        private readonly IProductRepository _productRepository;

        public Query(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts() =>
            _productRepository.GetAll();

        public Product GetProductById(Guid id) =>
            _productRepository.GetAll().FirstOrDefault(x => x.Id == id);
    }
}

