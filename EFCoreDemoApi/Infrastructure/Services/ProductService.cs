using EFCoreDemoApi.Application.Common.Interfaces;
using EFCoreDemoApi.Domain.Entities;

namespace EFCoreDemoApi.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly MyDbContext _myDbContext;

    public ProductService(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
    }

    public async Task<bool> SaveNewProducts(IEnumerable<Product> products)
    {
        try
        {
            await _myDbContext.Products.AddRangeAsync(products);
            await _myDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}