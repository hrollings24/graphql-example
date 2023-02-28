using System;
using GraphQLTest.Entities;

namespace GraphQLTest.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Create(Product product);
    }
}

