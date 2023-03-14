using GraphQLTest;
using GraphQLTest.Repositories;
using GraphQLTest.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<MyDatabaseContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("graphqldb")));

builder.Services
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IExtendedPropertyRepository, ExtendedPropertyRepository>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting().UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

