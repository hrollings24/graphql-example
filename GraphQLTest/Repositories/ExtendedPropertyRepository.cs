using System;
using GraphQLTest.Entities;

namespace GraphQLTest.Repositories
{
    public class ExtendedPropertyRepository : IExtendedPropertyRepository
    {
        private readonly MyDatabaseContext _context;


        public ExtendedPropertyRepository(MyDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<ExtendedProperties> GetAll(Guid productId)
        {
            return _context.ExtendedProperties.Where(x => x.ProductId == productId).ToList();
        }

        public async Task<ExtendedProperties> Create(ExtendedProperties exp)
        {
            await _context.ExtendedProperties.AddAsync(exp);
            await _context.SaveChangesAsync();
            return exp;
        }


    }
}

