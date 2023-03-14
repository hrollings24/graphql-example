using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQLTest.Models
{
	public class CreateProductRequest
	{
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}

