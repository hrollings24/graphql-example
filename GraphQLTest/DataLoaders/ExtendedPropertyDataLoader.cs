using System;
using GraphQLTest.Models;
using GraphQLTest.Repositories;

namespace GraphQLTest.DataLoaders
{
	public class ExtendedPropertyDataLoader: BatchDataLoader<Guid, List<ExtendedPropertyModel>>
	{
        private readonly IExtendedPropertyRepository _extendedPropertyRepository;

        public ExtendedPropertyDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IExtendedPropertyRepository extendedPropertyRepository)
            : base(batchScheduler, options)
        {
            _extendedPropertyRepository = extendedPropertyRepository ?? throw new ArgumentNullException(nameof(extendedPropertyRepository));
        }

        protected override async Task<IReadOnlyDictionary<Guid, List<ExtendedPropertyModel>>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var eps = await _extendedPropertyRepository.GetByProductIds(keys);

            var epsGroup = eps.GroupBy(x => x.ProductId);

            var f = epsGroup.ToDictionary(group => group.Key, group => group.ToList());
            return f;
        }
    }
}

