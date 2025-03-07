namespace ESTA.Domain.Entity;

public class Product : Base.Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
}
