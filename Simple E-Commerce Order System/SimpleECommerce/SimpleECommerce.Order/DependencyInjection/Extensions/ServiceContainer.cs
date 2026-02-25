using MassTransit;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Order.Data;
using SimpleECommerce.Order.DependencyInjection.Options;
using System.Reflection;

namespace SimpleECommerce.Order.DependencyInjection.Extensions
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
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.AddDelayedMessageScheduler();
                mt.AddEntityFrameworkOutbox<AppDbContext>(o =>
                {
                    o.UseSqlServer();
                    o.UseBusOutbox(); // Kích hoạt Outbox cho Bus
                    o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);


                });

                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(rabbitMQConfiguration.HostName, rabbitMQConfiguration.VHost, h =>
                    {
                        h.Username(rabbitMQConfiguration.UserName);
                        h.Password(rabbitMQConfiguration.Password);
                    });
                    // Kích hoạt tính năng lập lịch tin nhắn bị trì hoãn
                    // Có nghĩa là mình sẽ gửi 1 tin nhắn với thời gian trì hoãn nhất định
                    bus.UseDelayedMessageScheduler();
                    bus.ConfigureEndpoints(context);

                });
            });

            return services;

        }
    }
}
