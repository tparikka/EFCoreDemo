using EFCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Infrastructure.Persistence.Configuration;

public class ProductRuleConfiguration : IEntityTypeConfiguration<ProductRule>
{
    public void Configure(EntityTypeBuilder<ProductRule> entityTypeBuilder)
    {
        // Tables / Keys
        entityTypeBuilder.ToTable("Product_Rule"); // Provided as EF Core does not know this by convention

        // Relationships
        entityTypeBuilder
            .HasOne(productRule => productRule.Rule)
            .WithMany(rule => rule.ProductRules)
            .HasForeignKey(productRule => productRule.RuleId);
        entityTypeBuilder
            .HasOne(productRule => productRule.Product)
            .WithMany(rule => rule.ProductRules)
            .HasForeignKey(productRule => productRule.ProductId);

        // Properties
    }
}