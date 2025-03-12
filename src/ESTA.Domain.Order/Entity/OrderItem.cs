namespace ESTA.Domain.Order.Entity;

public class OrderItem: Shared.Base.Entity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice => Quantity * Price;
}
