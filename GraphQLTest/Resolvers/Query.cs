using System;
using GraphQLTest.Entities;
using GraphQLTest.Models;
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

        public List<ProductModel> GetProducts() =>
            _productRepository.GetAll();

        [UseDbContext(typeof(MyDatabaseContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        public IQueryable<ProductModel> GetPaginatedProducts([ScopedService] MyDatabaseContext context)
        {
            return context.Products.Select(x => new ProductModel()
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                Title = x.Title
            });
        }

        public ProductModel GetProductById(Guid id) =>
            _productRepository.GetAll().FirstOrDefault(x => x.Id == id);

    }
}

 