using EFCoreDemo.Application.Common.Interfaces;
using EFCoreDemo.Domain.Entities;
using EFCoreDemo.Infrastructure.Persistence;

namespace EFCoreDemo.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly InRuleDbContext _inRuleDbContext;

    public ProductService(InRuleDbContext inRuleDbContext)
    {
        _inRuleDbContext = inRuleDbContext ?? throw new ArgumentNullException(nameof(inRuleDbContext));
    }

    public async Task<bool> SaveNewProducts(IEnumerable<Product> products)
    {
        try
        {
            await _inRuleDbContext.Products.AddRangeAsync(products);
            await _inRuleDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}