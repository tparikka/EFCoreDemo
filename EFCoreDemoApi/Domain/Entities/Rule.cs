namespace EFCoreDemoApi.Domain.Entities;

public class Rule
{
    public long RuleId { get; set; }

    public string RuleDescription { get; set; }

    public DateTime InsertedOn { get; set; }

    public IEnumerable<Product>? Products { get; set; }

    public IEnumerable<ProductRule>? ProductRules { get; set; }
}