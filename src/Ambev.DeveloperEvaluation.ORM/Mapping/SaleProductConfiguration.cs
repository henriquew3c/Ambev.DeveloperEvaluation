using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration : Mapping<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SaleProducts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(si => si.Quantity).IsRequired();

        builder.Property(si => si.Total).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(c => c.Product)
            .WithMany()
            .HasForeignKey(x => new { x.ProductId });

        builder.HasOne<Sale>()
            .WithMany(c => c.Products)
            .HasForeignKey(x => new { x.SaleId });
    }
}