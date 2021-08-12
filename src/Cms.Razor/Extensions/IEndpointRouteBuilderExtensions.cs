
using Cms.Razor.RouteValueTransformers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cms.Razor.Extensions
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapCmsRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapDynamicControllerRoute<CmsRouteValueTransformer>("{**path}");
            return endpoints;
        }
    }
}
