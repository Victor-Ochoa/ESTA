using ESTA.Domain.Contract.Repository;
using ESTA.Shared.Data.Context;
using ESTA.Shared.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ESTA.Shared.Data;


public static class RepositoryDI
{
    public static IHostApplicationBuilder AddAdminRepository(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<EstaDbContext>(connectionName: "admindb");

        builder.Services.AddTransient(typeof(IRepositoryEntity<>), typeof(EntityRepository<>));

        return builder;
    }
}
