using System;
using GraphQLTest.Entities;
using GraphQLTest.Repositories;

namespace GraphQLTest.Resolvers
{
    public class Query
    {
        private readonly IProductRepository _productRepository;
        private readonly IExtendedPropertyRepository _extendedPropertyRepository;

        public Query(IProductRepository productRepository, IExtendedPropertyRepository extendedPropertyRepository)
        {
            _productRepository = productRepository;
            _extendedPropertyRepository = extendedPropertyRepository;
        }

        public List<Product> GetProducts() =>
            _productRepository.GetAll();

        public Product GetProductById(Guid id) =>
            _productRepository.GetAll().FirstOrDefault(x => x.Id == id);

        public List<ExtendedProperties> GetExtendedProperties(Guid id) =>
            _extendedPropertyRepository.GetAll(id);

        public ExtendedProperties GetExtendedPropertiesById(Guid productId, Guid id) =>
            _extendedPropertyRepository.GetAll(productId).FirstOrDefault(x => x.Id == id);
    }
}

