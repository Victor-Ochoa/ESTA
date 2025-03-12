using ESTA.Domain.Shared.ValueObject;

namespace ESTA.OrderApi.Request;

public record CreateOrderRequest
{
    public string Seller { get; set; }
    public IList<CreateOrderItemRequest> Products { get; set; } = [];
    public Address DeliveryAddress { get; set; }
}

public record CreateOrderItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

}