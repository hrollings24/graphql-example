using GraphQLTest.Entities;
using GraphQLTest.Models;

namespace GraphQLTest.Repositories
{
    public interface IExtendedPropertyRepository
    {
        Task<ExtendedPropertyModel> Create(ExtendedPropertyModel exp);
        List<ExtendedPropertyModel> GetAll(Guid productId);
    }
}