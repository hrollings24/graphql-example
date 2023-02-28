using System;
using GraphQLTest.Entities;

namespace GraphQLTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDatabaseContext _context;


        public ProductRepository(MyDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }


    }
}

