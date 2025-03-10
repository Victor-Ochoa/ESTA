using ESTA.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ESTA.Shared.Data.Context;

public class EstaDbContext(DbContextOptions<EstaDbContext> options) : DbContext(options)
{
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstaDbContext).Assembly);
    }
}
