using System;
using GraphQLTest.Entities;

namespace GraphQLTest.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Task<Product> Create(Product product);
    }
}

