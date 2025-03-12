using ESTA.Domain.Shared.ValueObject;

namespace ESTA.Domain.Order.Event;

public record OrderCreated : Shared.Base.Event
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public string Seller { get; set; }

    public IList<OrderCreatedItem> OrderItems { get; set; } = [];

    public Address DeliveryAddress { get; set; }
}

public record OrderCreatedItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    
}
