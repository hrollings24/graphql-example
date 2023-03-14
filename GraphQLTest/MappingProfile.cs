using System;
using AutoMapper;
using GraphQLTest.Entities;
using GraphQLTest.Models;

namespace GraphQLTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();
            CreateMap<ExtendedPropertyModel, ExtendedProperties>();
            CreateMap<ExtendedProperties, ExtendedPropertyModel>();
        }
    }
}

