using ESTA.Domain.Entity;
using ESTA.Domain.Order.Entity;
using ESTA.Domain.Order.Event;
using ESTA.Domain.Shared.Contract.Repository;
using ESTA.Domain.Shared.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTA.Shared.Service.Order;

public class OrderService : IOrderService
{
    private readonly IRepositoryEvent<Domain.Order.Entity.Order> _orderRepository;
    private readonly IRepositoryEntity<Product> _productRepository;

    public OrderService(IRepositoryEvent<Domain.Order.Entity.Order> orderRepository ,IRepositoryEntity<Product> productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    public async Task EnrichmentOrderAsync(Guid OrderId)
    {
        var order = await _orderRepository.Get(OrderId);

        var listOrderItems = new List<OrderItem>(order.Products.Count);

        foreach (var product in order.Products)
        {
            var productEntity = await _productRepository.Get(product.ProductId);
            listOrderItems.Add(new OrderItem
            {
                Id = product.Id,
                ProductId = productEntity.Id,
                Price = productEntity.Price,
                Quantity = product.Quantity
            });
        }

        var enrichedEvent = new OrderEnrichment
        {
            Id = OrderId,
            OrderItems = listOrderItems
        };

        await _orderRepository.AddEvent(enrichedEvent, OrderId);
    }
}
