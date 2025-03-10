using ESTA.Domain.Entity;
using ESTA.Domain.Event;
using ESTA.OrderApi.Projection;
using ESTA.OrderApi.Request;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();

builder.AddNpgsqlDataSource(connectionName: "admindb");

builder.Services.AddMarten(options =>
    {
        options.UseSystemTextJsonForSerialization();

        options.AutoCreateSchemaObjects = AutoCreate.All;

        options.Projections.Add<OrderProjection>(Marten.Events.Projections.ProjectionLifecycle.Inline);
    })
    .UseNpgsqlDataSource();

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

app.MapGet("orders", async ([FromServices] IQuerySession session) =>
{
    var orders = await session.Query<Order>().ToListAsync();
    return Results.Ok(orders);
});

app.MapGet("order/{orderid:guid}", async ([FromRoute] Guid orderId, [FromServices] IQuerySession session) =>
{
    var order = await session.LoadAsync<Order>(orderId);

    return order is not null
        ? Results.Ok(order)
        : Results.NotFound();
});

app.MapPost("order", async ([FromServices] IDocumentStore store, [FromBody] CreateOrderRequest request) =>
{

    var order = new ESTA.Domain.Event.OrderCreated
    {
        Seller = request.Seller,
        Products = request.Products,
        DeliveryAddress = request.DeliveryAddress
    };

    await using var session = store.LightweightSession();
    session.Events.StartStream<Order>(order.Id, order);
    await session.SaveChangesAsync();
    return Results.Ok(order);
});

app.MapPost("order/{orderid:guid}/Address", async ([FromRoute] Guid orderId, [FromBody] DeliveryAddressUpdateRequest request, [FromServices] IDocumentStore store) =>
{
    var addressUpdate = new OrderAddressUpdate
    {
        Id = orderId,
        DeliveryAddress = request.DeliveryAddress
    };

    await using var session = store.LightweightSession();
    session.Events.Append(orderId, addressUpdate);
    await session.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("order/{orderid:guid}/dispatch", async ([FromRoute] Guid orderId, [FromServices] IDocumentStore store) =>
{
    var orderEvent = new OrderDispatched
    {
        Id = orderId,
        DispatchedAtUtc = DateTime.UtcNow
    };

    await using var session = store.LightweightSession();
    session.Events.Append(orderId, orderEvent);
    await session.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("order/{orderid:guid}/outfordelivery", async ([FromRoute] Guid orderId, [FromServices] IDocumentStore store) =>
{
    var orderEvent = new OrderOutForDelivery
    {
        Id = orderId,
        OrderOutForDeliveryAtUtc = DateTime.UtcNow
    };

    await using var session = store.LightweightSession();
    session.Events.Append(orderId, orderEvent);
    await session.SaveChangesAsync();
    return Results.Ok();
});
app.MapPost("order/{orderid:guid}/delivered", async ([FromRoute] Guid orderId, [FromServices] IDocumentStore store) =>
{
    var orderEvent = new OrderDelivered
    {
        Id = orderId,
        DeliveredAtUtc = DateTime.UtcNow
    };

    await using var session = store.LightweightSession();
    session.Events.Append(orderId, orderEvent);
    await session.SaveChangesAsync();
    return Results.Ok();
});

app.Run();