using Cms.Razor.Extensions;
using Cms.Razor.Providers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

using System.Threading.Tasks;

namespace Cms.Razor.RouteValueTransformers
{
    internal sealed class CmsRouteValueTransformer
        : DynamicRouteValueTransformer
    {
        private readonly ICmsActionDescriptorProvider _cmsActionDescriptorProvider;

        public CmsRouteValueTransformer(ICmsActionDescriptorProvider cmsActionDescriptorProvider)
        {
            _cmsActionDescriptorProvider = cmsActionDescriptorProvider;
        }

        public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var document = httpContext.GetDocumentInfo();
            if (document is not null)
            {
                var action = _cmsActionDescriptorProvider.GetActionDescriptor(document);
                if (action is not null)
                {
                    foreach (var routeValue in action.RouteValues)
                    {
                        values.TryAdd(routeValue.Key, routeValue.Value);
                    }
                }
            }

            return new ValueTask<RouteValueDictionary>(values);
        }
    }
}
