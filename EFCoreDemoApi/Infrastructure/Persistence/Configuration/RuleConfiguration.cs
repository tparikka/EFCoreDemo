using EFCoreDemoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemoApi.Infrastructure.Persistence.Configuration;

public class RuleConfiguration : IEntityTypeConfiguration<Rule>
{
    public void Configure(EntityTypeBuilder<Rule> entityTypeBuilder)
    {
        // Tables / Keys
        entityTypeBuilder.ToTable("Rule");
        entityTypeBuilder.HasKey(rule => rule.RuleId);

        // Relationships
        entityTypeBuilder
            .HasMany(rule => rule.Products)
            .WithMany(product => product.Rules)
            .UsingEntity<ProductRule>(
                join => join
                    .HasOne(productRule => productRule.Product)
                    .WithMany(product => product.ProductRules)
                    .HasForeignKey(productRule => productRule.ProductId),
                join => join
                    .HasOne(productRule => productRule.Rule)
                    .WithMany(rule => rule.ProductRules)
                    .HasForeignKey(productRule => productRule.RuleId),
                join =>
                {
                    join.ToTable("Product_Rule");
                });

        // Properties
        entityTypeBuilder
            .Property(rule => rule.InsertedOn)
            .HasColumnType("datetime")
            .HasDefaultValueSql("getdate()");
    }
}