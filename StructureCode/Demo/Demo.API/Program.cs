
using Demo.API.DependencyInjection.Extensions;
using Demo.API.Middlewares;
using Demo.Application.DependencyInjection.Extenstions;
using Demo.Persistence.DependencyInjection.Extensions;
using Serilog;

namespace Demo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Configuration)
                .CreateLogger();



            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);


            // ADd Middleware
            builder.Services.AddTransient<ExceptionHandlingMiddleware>();


            //========== Add Swagger=============
            builder.Services.AddEndpointsApiExplorer()
                .AddSwagger();

            //Phải có đoạn.AddApiExplorer() này thì mới có IApiVersionDescriptionProvider
            builder.Services.AddApiVersioning(options => options.ReportApiVersions = true)
                .AddVersionedApiExplorer(options =>
                {
                    // Định dạng group name cho Swagger: 'v' + version(vd: v1, v2)
                    options.GroupNameFormat = "'v'VVV";
                    // Tự động thay thế {version} trong Route thành version thực tế
                    options.SubstituteApiVersionInUrl = true;
                });



            //# Persistence Layer
            builder.Services.AddSqlServerPersistence(builder.Configuration);
            builder.Services.AddRepositoryPersistence();
            builder.Services.AddInterceptorPersistence();


            //# Application Layer
            builder.Services.AddConfigurationMediatR();

            // JWT Authentication
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddAuthorization();

            try
            {
                Log.Information("Starting up the application");
                var app = builder.Build();

                app.UseMiddleware<ExceptionHandlingMiddleware>();
                app.UseSerilogRequestLogging();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
                {
                    app.ConfigureSwagger();
                }

                app.UseHttpsRedirection();

                app.UseAuthentication();
                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start correctly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
