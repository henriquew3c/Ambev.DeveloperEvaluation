using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : Mapping<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(si => si.Name).IsRequired();

        builder.Property(si => si.Price).IsRequired().HasColumnType("decimal(18,2)");
    }
}