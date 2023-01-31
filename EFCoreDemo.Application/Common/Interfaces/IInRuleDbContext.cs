using EFCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Application.Common.Interfaces;

public interface IInRuleDbContext
{
    public DbContext Instance {get;}
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Rule> Rules { get; set; }
    
    public DbSet<ProductRule> ProductRules { get; set; }
}