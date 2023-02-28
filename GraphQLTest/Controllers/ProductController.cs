using GraphQLTest.Entities;
using GraphQLTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLTest.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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
}

