using ESTA.Domain.Enum;
using ESTA.Domain.ValueObject;

namespace ESTA.Domain.Entity;

public class Order : Base.Entity
{
    public IList<Product> Products { get; set; } = [];
    public required Seller Seller { get; set; }
    public Address DeliveryAddress { get; set; }
    public DateTime? DispatchedAtUtc { get; set; }
    public DateTime? OrderOutForDeliveryAtUtc { get; set; }
    public DateTime? DeliveredAtUtc { get; set; }
    public EOrderStatus OrderStatus{ get; set; }
}
