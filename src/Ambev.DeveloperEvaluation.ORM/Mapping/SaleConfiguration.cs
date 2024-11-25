using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : Mapping<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Number).IsRequired().HasMaxLength(50);

        builder.Property(s => s.DiscountPercent).IsRequired();

        builder.Property(s => s.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(s => s.DiscountAmount).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasMany(c => c.Products)
            .WithOne()
            .HasForeignKey(x => new { x.SaleId })
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(x => new { x.UserId });


    }
}