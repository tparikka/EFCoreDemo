namespace EFCoreDemoApi.Domain.Entities;

public class Product
{
    public long ProductId { get; set; }

    public string ProductDescription { get; set; }

    public DateTime InsertedOn { get; set; }

    public IEnumerable<Rule>? Rules { get; set; }

    public IEnumerable<ProductRule>? ProductRules { get; set; }
}