using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Demo.API.DependencyInjection.Options
{
    public class ConfigurationSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigurationSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = AppDomain.CurrentDomain.FriendlyName,
                        Version = description.ApiVersion.ToString()
                    });

                options.MapType<DateOnly>(() => new Microsoft.OpenApi.Models.OpenApiSchema
                {

                    Format = "date",
                    Example = new OpenApiString(DateOnly.MinValue.ToString())

                });
            }
        }
    }
}
