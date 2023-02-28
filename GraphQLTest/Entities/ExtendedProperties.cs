using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLTest.Entities
{
	public class ExtendedProperties
	{
		[Key]
		public Guid Id { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        [Required]
		public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }
	}
}

