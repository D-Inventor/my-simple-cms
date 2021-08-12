using Cms.Razor.Middleware;

using Microsoft.AspNetCore.Builder;

namespace Cms.Razor.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCmsContentLocating(this IApplicationBuilder app)
            => app.UseMiddleware<ContentLocatorMiddleware>();
    }
}
