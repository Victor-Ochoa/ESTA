
using ESTA.Domain.Contract.Repository;
using ESTA.Shared.Data.Context;
using ESTA.Shared.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.AddNpgsqlDbContext<EstaDbContext>(connectionName: "admindb");

builder.Services.AddTransient(typeof(IRepositoryEntity<>), typeof(EntityRepository<>));

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EstaDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.Run();
