using ESTA.Domain.Order.Enum;
using ESTA.Domain.Order.Event;
using ESTA.Domain.Shared.ValueObject;

namespace ESTA.Domain.Order.Entity;

public class Order : Shared.Base.Entity
{
    public IList<OrderItem> Products { get; set; } = [];
    public required string SellerOpenId { get; set; }
    public Address DeliveryAddress { get; set; }
    public DateTime? DispatchedAtUtc { get; set; }
    public DateTime? OrderOutForDeliveryAtUtc { get; set; }
    public DateTime? DeliveredAtUtc { get; set; }
    public EOrderStatus OrderStatus{ get; set; }

    public void Apply(OrderCreated created)
    {
        OrderStatus = EOrderStatus.Created;
        Products = [.. created.OrderItems.Select(x => new OrderItem { ProductId = x.ProductId, Quantity = x.Quantity})];
        SellerOpenId =  created.Seller;
        DeliveryAddress = created.DeliveryAddress;
    }

    public void Apply(OrderDelivered delivered)
    {
        OrderStatus = EOrderStatus.Delivered;
        DeliveredAtUtc = delivered.DeliveredAtUtc;
    }
    public void Apply(OrderDispatched dispatched)
    {
        OrderStatus = EOrderStatus.Dispatched;
        DispatchedAtUtc = dispatched.DispatchedAtUtc;
    }
    public void Apply(OrderOutForDelivery outForDelivery)
    {
        OrderStatus = EOrderStatus.OutForDelivery;
        OrderOutForDeliveryAtUtc = outForDelivery.OrderOutForDeliveryAtUtc;
    }
    public void Apply(OrderAddressUpdate addressUpdate)
    {
        DeliveryAddress = addressUpdate.DeliveryAddress;
    }
}
