using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQLTest.Entities
{
	public class Product
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}

