using System;
using GraphQLTest.Entities;
using System.ComponentModel.DataAnnotations;
using GraphQLTest.Repositories;
using GraphQLTest.DataLoaders;

namespace GraphQLTest.Models
{
	public class ProductModel
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public async Task<List<ExtendedPropertyModel>> ExtendedProperties([Service] ExtendedPropertyDataLoader dataLoader)
        {
            var f = await dataLoader.LoadAsync(Id, CancellationToken.None);

            if (f == null)
            {
                return new List<ExtendedPropertyModel>();
            }

            return f;
        }

    }
}

