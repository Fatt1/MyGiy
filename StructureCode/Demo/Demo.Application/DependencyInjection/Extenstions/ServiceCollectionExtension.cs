using Demo.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application.DependencyInjection.Extenstions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigurationMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));


            // Add Validation Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            // Add Performance Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformancePipelineBehavior<,>));


            // Add Validators
            services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);
            return services;
        }
    }
}
