using System;
using GraphQLTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Repositories
{
    public class ExtendedPropertyRepository : IExtendedPropertyRepository
    {
        private readonly IDbContextFactory<MyDatabaseContext> _contextFactory;

        public ExtendedPropertyRepository(IDbContextFactory<MyDatabaseContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public List<ExtendedProperties> GetAll(Guid productId)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            return context.ExtendedProperties.Where(x => x.ProductId == productId).ToList();
        }

        public async Task<ExtendedProperties> Create(ExtendedProperties exp)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            await context.ExtendedProperties.AddAsync(exp);
            await context.SaveChangesAsync();
            return exp;
        }
    }
}

