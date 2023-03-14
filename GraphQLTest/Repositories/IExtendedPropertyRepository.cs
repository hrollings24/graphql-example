using GraphQLTest.Entities;
using GraphQLTest.Models;

namespace GraphQLTest.Repositories
{
    public interface IExtendedPropertyRepository
    {
        Task<ExtendedPropertyModel> Create(ExtendedPropertyModel exp);
        Task<List<ExtendedPropertyModel>> GetByProductId(Guid productId);
        Task<List<ExtendedPropertyModel>> GetByProductIds(IReadOnlyList<Guid> productIds);
    }
}