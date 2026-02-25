using MassTransit;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Inventory.Data;
using SimpleECommerce.Inventory.DependencyInjection.Options;
using System.Reflection;

namespace SimpleECommerce.Inventory.DependencyInjection.Extensions
{
    public static class ServiceContainer
    {

        public static IServiceCollection AddMeditor(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        public static IServiceCollection AddDatabaseSqlServerConfig(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }

        public static IServiceCollection AddMasstransitRabbitMQConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(rabbitMQConfiguration);

            services.AddMassTransit(mt =>
            {
                // Tạo queue và gắn các consumer cho các queue đó
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.AddEntityFrameworkOutbox<AppDbContext>(o =>
                {
                    o.UseSqlServer();
                    o.UseBusOutbox(); // Kích hoạt Outbox cho Bus
                });
                mt.UsingRabbitMq((context, bus) =>
                {

                    bus.Host(rabbitMQConfiguration.HostName, rabbitMQConfiguration.VHost, h =>
                    {
                        h.Username(rabbitMQConfiguration.UserName);
                        h.Password(rabbitMQConfiguration.Password);
                    });

                    bus.ConfigureEndpoints(context);

                });
            });

            return services;

        }
    }
}

