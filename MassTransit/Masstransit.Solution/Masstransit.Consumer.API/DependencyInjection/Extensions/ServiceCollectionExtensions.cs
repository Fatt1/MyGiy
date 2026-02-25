using Masstransit.Introduce.Dependency_Injection.Options;
using MassTransit;
using System.Reflection;

namespace Masstransit.Introduce.Dependency_Injection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMeditor(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }


        public static IServiceCollection AddConfigureMasstransitRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {

            var masstransitConfiguration = new MasstransitConfiguration();
            configuration.GetSection(nameof(MasstransitConfiguration)).Bind(masstransitConfiguration);




            services.AddMassTransit(mt =>
            {
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host(masstransitConfiguration.Host, masstransitConfiguration.VHost, h =>
                    {
                        h.Username(masstransitConfiguration.Username);
                        h.Password(masstransitConfiguration.Password);

                    });

                    // Tự động tạo các Queue (Hàng đợi) và Exchange trên RabbitMQ dựa tương ứng với các Consumer đã đăng ký
                    bus.ConfigureEndpoints(context);

                });
            });
            return services;
        }
    }
}
