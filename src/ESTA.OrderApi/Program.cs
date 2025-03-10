using ESTA.OrderApi.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();


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

app.MapGet("orders", async () => { });

app.MapPost("order", async (CreateOrderRequest request) => { 
    
});

app.MapPost("order/{orderid:guid}/Address", async (Guid orderId, DeliveryAddressUpdateRequest request) => { });

app.MapPost("order/{orderid:guid}/dispatch", async (Guid orderId) => { });

app.MapPost("order/{orderid:guid}/outfordelivery", async (Guid orderId) => { });

app.MapPost("order/{orderid:guid}/outfordelivered", async (Guid orderId) => { });

app.Run();