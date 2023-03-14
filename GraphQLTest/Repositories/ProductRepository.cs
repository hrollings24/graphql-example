using System;
using GraphQLTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<MyDatabaseContext> _contextFactory;


        public ProductRepository(IDbContextFactory<MyDatabaseContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
        
        public List<Product> GetAll()
        {
            using (MyDatabaseContext context = _contextFactory.CreateDbContext())
            {
                var t = context.Products.ToList();
                return t;
            }
        }

        public async Task<Product> Create(Product product)
        {
            using (MyDatabaseContext context = _contextFactory.CreateDbContext())
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return product;
            }
        }

    }
}

