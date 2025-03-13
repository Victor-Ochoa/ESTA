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
        if(OrderStatus > EOrderStatus.Created)
            throw new InvalidOperationException("Order already created");

        OrderStatus = EOrderStatus.Created;
        Products = [.. created.OrderItems.Select(x => new OrderItem { ProductId = x.ProductId, Quantity = x.Quantity})];
        SellerOpenId =  created.Seller;
        DeliveryAddress = created.DeliveryAddress;
    }

    public void Apply(OrderEnrichment enrichment)
    {
        if(OrderStatus > EOrderStatus.Approved)
            throw new InvalidOperationException("Order already enriched");

        OrderStatus = EOrderStatus.Approved;
        Products = enrichment.OrderItems;
    }

    public void Apply(OrderDelivered delivered)
    {
        if (OrderStatus > EOrderStatus.Delivered)
            throw new InvalidOperationException("Order already delivered");

        OrderStatus = EOrderStatus.Delivered;
        DeliveredAtUtc = delivered.DeliveredAtUtc;
    }
    public void Apply(OrderDispatched dispatched)
    {
        if(OrderStatus > EOrderStatus.Dispatched)
            throw new InvalidOperationException("Order already dispatched");

        OrderStatus = EOrderStatus.Dispatched;
        DispatchedAtUtc = dispatched.DispatchedAtUtc;
    }
    public void Apply(OrderOutForDelivery outForDelivery)
    {
        if (OrderStatus > EOrderStatus.OutForDelivery)
            throw new InvalidOperationException("Order already out for delivery");

        OrderStatus = EOrderStatus.OutForDelivery;
        OrderOutForDeliveryAtUtc = outForDelivery.OrderOutForDeliveryAtUtc;
    }
    public void Apply(OrderAddressUpdate addressUpdate)
    {
        if (OrderStatus > EOrderStatus.Approved)
            throw new InvalidOperationException("Order already created");

        DeliveryAddress = addressUpdate.DeliveryAddress;
    }
}
