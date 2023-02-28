using GraphQLTest.Entities;
using GraphQLTest.Models;
using GraphQLTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLTest.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    IProductRepository _productRepository;
    IExtendedPropertyRepository _extendedPropertyRepository;

    public ProductController(IProductRepository productRepository, IExtendedPropertyRepository extendedPropertyRepository)
    {
        _productRepository = productRepository;
        _extendedPropertyRepository = extendedPropertyRepository;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return _productRepository.GetAll();
    }

    [HttpPost]
    public ActionResult<Product> CreateNew(Product product)
    {
        return _productRepository.Create(product).GetAwaiter().GetResult();
    }

    [HttpGet("{id}/extendedproperties")]
    public ActionResult<List<ExtendedProperties>> GetAllExtendedProperties([FromRoute] Guid id)
    {
        return _extendedPropertyRepository.GetAll(id);
    }

    [HttpPost("{id}/extendedproperties")]
    public ActionResult<ExtendedProperties> CreateNew([FromRoute] Guid id, [FromBody] CreateExtendedPropertiesRequest exp)
    {
        var expEntity = new ExtendedProperties()
        {
            Id = Guid.NewGuid(),
            ProductId = id,
            Value = exp.Value,
            Type = exp.Type,
            Name = exp.Name
        };

        return _extendedPropertyRepository.Create(expEntity).GetAwaiter().GetResult();
    }
}

