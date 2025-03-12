using ESTA.Domain.Order.Entity;
using ESTA.Domain.Order.Event;
using ESTA.OrderApi.Request;
using Microsoft.AspNetCore.Mvc;
using ESTA.Shared.EventData;
using ESTA.Domain.Shared.Contract.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();

builder.AddEventRepository();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("orders", async ([FromServices] IRepositoryEvent<Order> repository) =>
{
    var orders = await repository.GetAll();
    return Results.Ok(orders);
});

app.MapGet("order/{orderid:guid}", async ([FromRoute] Guid orderId, [FromServices] IRepositoryEvent<Order> repository) =>
{
    var order = await repository.Get(orderId);

    return order is not null
        ? Results.Ok(order)
        : Results.NotFound();
});

app.MapPost("order", async ([FromServices] IRepositoryEvent<Order> repository, [FromBody] CreateOrderRequest request) =>
{

    var order = new OrderCreated
    {
        Seller = request.Seller,
        OrderItems = [.. request.Products.Select(x => new OrderCreatedItem { ProductId = x.ProductId, Quantity = x.Quantity })],
        DeliveryAddress = request.DeliveryAddress
    };

    return Results.Ok(await repository.Create(order, order.Id));
});

app.MapPost("order/{orderid:guid}/Address", async ([FromRoute] Guid orderId, [FromBody] DeliveryAddressUpdateRequest request, [FromServices] IRepositoryEvent<Order> repository) =>
{
    var addressUpdate = new OrderAddressUpdate
    {
        Id = orderId,
        DeliveryAddress = request.DeliveryAddress
    };

    await repository.AddEvent(addressUpdate, orderId);

    return Results.Ok();
});

app.MapPost("order/{orderid:guid}/dispatch", async ([FromRoute] Guid orderId, [FromServices] IRepositoryEvent<Order> repository) =>
{
    var orderEvent = new OrderDispatched
    {
        Id = orderId,
        DispatchedAtUtc = DateTime.UtcNow
    };

    await repository.AddEvent(orderEvent, orderId);

    return Results.Ok();
});

app.MapPost("order/{orderid:guid}/outfordelivery", async ([FromRoute] Guid orderId, [FromServices] IRepositoryEvent<Order> repository) =>
{
    var orderEvent = new OrderOutForDelivery
    {
        Id = orderId,
        OrderOutForDeliveryAtUtc = DateTime.UtcNow
    };


    await repository.AddEvent(orderEvent, orderId);

    return Results.Ok();
});
app.MapPost("order/{orderid:guid}/delivered", async ([FromRoute] Guid orderId, [FromServices] IRepositoryEvent<Order> repository) =>
{
    var orderEvent = new OrderDelivered
    {
        Id = orderId,
        DeliveredAtUtc = DateTime.UtcNow
    };

    await repository.AddEvent(orderEvent, orderId);

    return Results.Ok();
});

app.Run();