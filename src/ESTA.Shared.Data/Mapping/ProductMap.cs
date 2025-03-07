using ESTA.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESTA.Shared.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.Property(p => p.Price).HasPrecision(10,2).HasDefaultValue(0);

        builder.Property(p => p.Description).HasMaxLength(300);

        builder.Property(p => p.Stock).HasDefaultValue(0);
    }
}
