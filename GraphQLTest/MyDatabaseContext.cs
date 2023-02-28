using System;
using GraphQLTest.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ExtendedProperties> ExtendedProperties { get; set; } = null!;

        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseSerialColumns();
        }
    }
}

