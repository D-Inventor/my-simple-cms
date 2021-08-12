using Cms.Razor.Models.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Razor.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IMvcBuilder AddCms(this IMvcBuilder builder)
        {
            var assembly = typeof(IServiceCollectionExtensions).Assembly;
            return builder.AddApplicationPart(assembly);
        }

        public static IServiceCollection AddCms(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<BackofficeUrlOptions>()
                .Bind(configuration.GetSection(BackofficeUrlOptions.Section))
                .ValidateDataAnnotations();

            return services;
        }
    }
}
