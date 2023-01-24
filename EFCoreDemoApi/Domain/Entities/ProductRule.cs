namespace EFCoreDemoApi.Domain.Entities;

public class ProductRule
{
    public long ProductRuleId { get; set; }

    public long ProductId { get; set; }

    public long RuleId { get; set; }
    
    public Product Product { get; set; }
    
    public Rule Rule { get; set; }
}