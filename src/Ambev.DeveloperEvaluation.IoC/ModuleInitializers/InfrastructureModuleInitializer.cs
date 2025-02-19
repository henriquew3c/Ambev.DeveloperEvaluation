using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Repository;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddSingleton<IConnection>(sp =>
        {
            var connectionFactory = sp.GetRequiredService<IConnectionFactory>();
            return connectionFactory.CreateConnection();
        });

        builder.Services.AddSingleton<RabbitMQ.Client.IModel>(sp =>
        {
            var connection = sp.GetRequiredService<IConnection>();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "sale_registered_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            return channel;
        });

    }
}