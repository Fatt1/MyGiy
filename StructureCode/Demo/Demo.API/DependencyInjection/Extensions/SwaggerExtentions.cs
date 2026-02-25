using Demo.API.DependencyInjection.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Demo.API.DependencyInjection.Extensions
{
    public static class SwaggerExtentions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigurationSwaggerOptions>();
        }

        public static void ConfigureSwagger(this WebApplication app)
        {

            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var version in apiVersionDescriptionProvider.ApiVersionDescriptions.Select(version => version.GroupName))
                {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);

                    options.DisplayRequestDuration();
                    options.EnableTryItOutByDefault();
                    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                }
            });
            app.MapGet("/", () => Results.Redirect("/swagger/index.html"))
                .WithTags(string.Empty);
        }
    }
}
