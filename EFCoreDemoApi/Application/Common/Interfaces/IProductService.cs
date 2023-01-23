using EFCoreDemoApi.Domain.Entities;

namespace EFCoreDemoApi.Application.Common.Interfaces;

public interface IProductService
{
    Task<bool> SaveNewProducts(IEnumerable<Product> products);
}