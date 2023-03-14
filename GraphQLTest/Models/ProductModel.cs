using System;
using GraphQLTest.Entities;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<ExtendedProperties> ExtendedProperties { get; set; }
    }
}

