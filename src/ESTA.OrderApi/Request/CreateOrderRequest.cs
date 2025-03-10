using ESTA.Domain.ValueObject;

namespace ESTA.OrderApi.Request;

public record CreateOrderRequest
{
    public Guid Seller { get; set; }
    public IList<Guid> Products { get; set; } = [];
    public Address DeliveryAddress { get; set; }
}
