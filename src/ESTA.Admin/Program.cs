﻿using ESTA.Shared.Data;
using ESTA.Shared.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddServiceDefaults();

builder.Services.AddControllers();

builder.AddAdminRepository();

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
