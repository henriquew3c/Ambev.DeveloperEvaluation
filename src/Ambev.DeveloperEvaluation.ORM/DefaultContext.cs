using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.ORM.Mapping;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }
    public DbSet<Product> Products { get; set; }


    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<Sale>(new SaleConfiguration());
        modelBuilder.ApplyConfiguration<SaleProduct>(new SaleProductConfiguration());
        modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}