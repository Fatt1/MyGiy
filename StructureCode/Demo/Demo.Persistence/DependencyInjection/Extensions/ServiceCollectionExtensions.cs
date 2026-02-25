using Demo.Domain.Abstractions;
using Demo.Domain.Abstractions.Repositories;
using Demo.Domain.Entities.Identity;
using Demo.Persistence.DependencyInjection.Options;
using Demo.Persistence.Interceptors;
using Demo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlServerRetryOptions = new SqlServerRetryOptions();
            configuration.GetSection(nameof(SqlServerRetryOptions)).Bind(sqlServerRetryOptions);


            services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, buider) =>
            {
                // LẤY INTERCEPTOR TỪ DI RA
                var auditableInterceptor = provider.GetRequiredService<AuditableEntityInterceptor>();
                buider.EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("SqlServer"),
                    sqlServerOptionsAction: optionBuider =>
                    {
                        optionBuider.ExecutionStrategy(dependencies => new SqlServerRetryingExecutionStrategy(
                            dependencies: dependencies,
                            maxRetryCount: sqlServerRetryOptions.MaxRetryCount,
                            maxRetryDelay: sqlServerRetryOptions.MaxRetryDelaySeconds,
                            errorNumbersToAdd: sqlServerRetryOptions.ErrorNumbersToAdd
                            ));
                        optionBuider.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name);
                    }
                ).AddInterceptors(auditableInterceptor);
                ;
            });

            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireDigit = true;

            })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            return services;

        }

        public static IServiceCollection AddRepositoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            return services;
        }


        public static IServiceCollection AddInterceptorPersistence(this IServiceCollection services)
        {
            // Cái này cho phép chúng ta truy cập HttpContext để lấy thông tin người dùng hiện tại trong các interceptor
            services.AddHttpContextAccessor();
            services.AddScoped<AuditableEntityInterceptor>();
            return services;

        }
    }
}