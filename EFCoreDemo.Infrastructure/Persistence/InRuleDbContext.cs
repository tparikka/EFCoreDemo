using EFCoreDemo.Application.Common.Interfaces;
using EFCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Infrastructure.Persistence;

public class InRuleDbContext : DbContext, IInRuleDbContext
{
    public DbContext Instance => this;
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Rule> Rules { get; set; }
    
    public DbSet<ProductRule> ProductRules { get; set; }
    
    public InRuleDbContext(DbContextOptions<InRuleDbContext> options) : base(options)
    {
        // Calls base constructor only
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InRuleDbContext).Assembly);
    }
}