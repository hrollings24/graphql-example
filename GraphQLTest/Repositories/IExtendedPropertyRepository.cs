using GraphQLTest.Entities;

namespace GraphQLTest.Repositories
{
    public interface IExtendedPropertyRepository
    {
        Task<ExtendedProperties> Create(ExtendedProperties exp);
        List<ExtendedProperties> GetAll(Guid productId);
    }
}