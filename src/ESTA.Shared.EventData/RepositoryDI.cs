using ESTA.Domain.Shared.Contract.Repository;
using ESTA.Shared.EventData.Projection;
using ESTA.Shared.EventData.Repository;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weasel.Core;

namespace ESTA.Shared.EventData;

public static class RepositoryDI
{
    public static IHostApplicationBuilder AddEventRepository(this IHostApplicationBuilder builder)
    {

        builder.AddNpgsqlDataSource(connectionName: "admindb");

        builder.Services.AddMarten(options =>
        {
            options.AutoCreateSchemaObjects = AutoCreate.All;

            options.UseSystemTextJsonForSerialization();

            options.Projections.Add<OrderProjection>(Marten.Events.Projections.ProjectionLifecycle.Inline);
        }).UseNpgsqlDataSource();

        builder.Services.AddTransient(typeof(IRepositoryEvent<>), typeof(EventRepository<>));
        return builder;
    }
}