using System;
using GraphQLTest.Models;
using HotChocolate.Data.Filters;

namespace GraphQLTest.Resolvers
{
    public class ProductFilter : FilterInputType<ProductModel>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ProductModel> descriptor)
        {
            descriptor.Ignore(c => c.Description);

            base.Configure(descriptor);
        }
    }
}

