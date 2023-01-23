using EFCoreDemoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoApi.Infrastructure;

public class MyDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Rule> Rules { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        // Calls base constructor only
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }
}