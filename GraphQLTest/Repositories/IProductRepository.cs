using System;
using GraphQLTest.Entities;
using GraphQLTest.Models;

namespace GraphQLTest.Repositories
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll();
        Task<ProductModel> Create(ProductModel product);
    }
}

