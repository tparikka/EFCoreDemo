using EFCoreDemoApi.Application.Common.Interfaces;
using EFCoreDemoApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemoApi.Controllers;

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
}
