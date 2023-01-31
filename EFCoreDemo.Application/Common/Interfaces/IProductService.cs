using EFCoreDemo.Domain.Entities;

namespace EFCoreDemo.Application.Common.Interfaces;

public interface IProductService
{
    Task<bool> SaveNewProducts(IEnumerable<Product> products);
}