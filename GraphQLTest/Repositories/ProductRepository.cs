using System;
using AutoMapper;
using GraphQLTest.Entities;
using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<MyDatabaseContext> _contextFactory;
        private readonly IMapper _mapper;

        public ProductRepository(IDbContextFactory<MyDatabaseContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<ProductModel> GetAll()
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var t = context.Products.Include(c => c.ExtendedProperties).ToList();
            return _mapper.Map<List<ProductModel>>(t);
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var p = _mapper.Map<Product>(product);

            await context.Products.AddAsync(p);
            await context.SaveChangesAsync();

            return product;
        }

    }
}

