using ESTA.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESTA.Shared.Data.Mapping;

public class SellerMapping : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {

        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.OpenId).IsUnique();
        builder.Property(s => s.OpenId).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        builder.ComplexProperty(s => s.Address, a =>
        {
            a.Property(a => a.Street).HasMaxLength(100);
            a.Property(a => a.Number).HasMaxLength(10);
            a.Property(a => a.Complement).HasMaxLength(300);
            a.Property(a => a.City).HasMaxLength(100);
            a.Property(a => a.State).HasMaxLength(100);
            a.Property(a => a.ZipCode).HasMaxLength(10);
        });
    }
}
