using EFCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
    {
        // Tables / Keys
        // Table name not needed due to EF Core conventions
        // Primary key not needed due to EF Core conventions

        // Relationships
        // Complex many/many relationship provided where EF Core does not know relationship by convention
        entityTypeBuilder
            .HasMany(product => product.Rules)
            .WithMany(rule => rule.Products)
            .UsingEntity<ProductRule>(
                join => join
                    .HasOne(productRule => productRule.Rule)
                    .WithMany(rule => rule.ProductRules)
                    .HasForeignKey(productRule => productRule.RuleId),
                join => join
                    .HasOne(productRule => productRule.Product)
                    .WithMany(product => product.ProductRules)
                    .HasForeignKey(productRule => productRule.ProductId),
                join =>
                {
                    join.ToTable("Product_Rule");
                });

        // Properties
    }
}