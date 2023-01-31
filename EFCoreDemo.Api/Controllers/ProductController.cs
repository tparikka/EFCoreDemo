using EFCoreDemo.Application.Common.Interfaces;
using EFCoreDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpPost]
    [Route("Products")]
    public async Task<bool> PublishProducts([FromBody] IEnumerable<Product> products)
    {
        var result = await _productService.SaveNewProducts(products);

        return result;
    }

    [HttpPost]
    [Route("Test")]
    public async Task<bool> PublishProducts()
    {
        var p1 = new Product()
        {
            ProductDescription = "Test",
            InsertedOn = DateTime.Now,
            Rules = new List<Rule>()
            {
                new()
                {
                    InsertedOn = DateTime.Now,
                    RuleDescription = "Test"
                },
                new()
                {
                    InsertedOn = DateTime.Now,
                    RuleDescription = "Test2"
                }
            }
        };

        var p2 = new Product()
        {
            ProductDescription = "Test2",
            InsertedOn = DateTime.Now,
            Rules = new List<Rule>()
            {
                new()
                {
                    InsertedOn = DateTime.Now,
                    RuleDescription = "Test"
                },
                new()
                {
                    InsertedOn = DateTime.Now,
                    RuleDescription = "Test2"
                }
            }
        };

        var result = await _productService.SaveNewProducts(new[] {p1, p2});

        return result;
    }
}