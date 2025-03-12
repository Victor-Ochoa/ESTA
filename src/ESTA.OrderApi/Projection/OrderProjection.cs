using ESTA.Domain.Entity;
using ESTA.Domain.Enum;
using ESTA.Domain.Event;
using Marten.Events.Aggregation;

namespace ESTA.OrderApi.Projection
{
    public class OrderProjection : SingleStreamProjection<Order>
    {
        public void Apply(OrderCreated created, Order order)
        {
            order.OrderStatus = EOrderStatus.Created;
            order.Products = [.. created.OrderItems.Select(x => new OrderItem { ProductId = x.ProductId, Quantity = x.Quantity })];
            order.SellerOpenId = created.Seller;
            order.DeliveryAddress = created.DeliveryAddress;
        }

        public void Apply(OrderDelivered delivered, Order order)
        {
            order.OrderStatus = EOrderStatus.Delivered;
            order.DeliveredAtUtc = delivered.DeliveredAtUtc;
        }
        public void Apply(OrderDispatched dispatched, Order order)
        {
            order.OrderStatus = EOrderStatus.Dispatched;
            order.DispatchedAtUtc = dispatched.DispatchedAtUtc;
        }
        public void Apply(OrderOutForDelivery outForDelivery, Order order)
        {
            order.OrderStatus = EOrderStatus.OutForDelivery;
            order.OrderOutForDeliveryAtUtc = outForDelivery.OrderOutForDeliveryAtUtc;
        }
        public void Apply(OrderAddressUpdate addressUpdate, Order order)
        {
            order.DeliveryAddress = addressUpdate.DeliveryAddress;
        }
    }
}
