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

        public List<ExtendedPropertyModel> GetAll(Guid productId)
        {
            using MyDatabaseContext context = _contextFactory.CreateDbContext();

            var eps = context.ExtendedProperties.Where(x => x.ProductId == productId).ToList();
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

