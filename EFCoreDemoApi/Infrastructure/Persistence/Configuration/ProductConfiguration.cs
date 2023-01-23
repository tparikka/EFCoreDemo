using EFCoreDemoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemoApi.Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
    {
        // Tables / Keys
        entityTypeBuilder.ToTable("Product");
        entityTypeBuilder.HasKey(product => product.ProductId);

        // Relationships
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
        entityTypeBuilder
            .Property(product => product.InsertedOn)
            .HasColumnType("datetime")
            .HasDefaultValueSql("getdate()");
    }
}