using System;
using GraphQLTest.Models;
using HotChocolate.Data.Sorting;

namespace GraphQLTest.Resolvers
{
    public class ProductSort : SortInputType<ProductModel>
    {
        protected override void Configure(ISortInputTypeDescriptor<ProductModel> descriptor)
        {
            descriptor.Ignore(c => c.Id);
            descriptor.Ignore(c => c.Description);

            base.Configure(descriptor);
        }
    }
}

