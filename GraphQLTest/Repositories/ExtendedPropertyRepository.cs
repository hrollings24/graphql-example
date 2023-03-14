using System;
using AutoMapper;
using GraphQLTest.Entities;
using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Repositories
{
    public class ExtendedPropertyRepository : IExtendedPropertyRepository
    {
        private readonly IDbContextFactory<MyDatabaseContext> _contextFactory;
        private readonly IMapper _mapper;

        public ExtendedPropertyRepository(IDbContextFactory<MyDatabaseContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ExtendedPropertyModel>> GetByProductId(Guid productId)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var eps = await context.ExtendedProperties.Where(x => x.ProductId == productId).ToListAsync();
            return _mapper.Map<List<ExtendedPropertyModel>>(eps);
        }

        public async Task<List<ExtendedPropertyModel>> GetByProductIds(IReadOnlyList<Guid> productIds)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var eps = await context.ExtendedProperties.Where(x => productIds.Contains(x.ProductId)).ToListAsync();
            return _mapper.Map<List<ExtendedPropertyModel>>(eps);
        }

        public async Task<ExtendedPropertyModel> Create(ExtendedPropertyModel exp)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var ep = _mapper.Map<ExtendedProperties>(exp);

            await context.ExtendedProperties.AddAsync(ep);
            await context.SaveChangesAsync();
            return exp;
        }
    }
}

