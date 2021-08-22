/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Pipeline.Requests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

using System.Threading.Tasks;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Transforms route values based on the <see cref="IDocument{TModel}"/> that is associated with the current request
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as transient</para>
    /// </remarks>
    public class CmsDocumentRouteValueTransformer
        : DynamicRouteValueTransformer
    {
        private readonly IGetActionDescriptorRequestHandler<IDocument> _actionDescriptorRequestHandler;

        public CmsDocumentRouteValueTransformer(IGetActionDescriptorRequestHandler<IDocument> actionDescriptorRequestHandler)
        {
            _actionDescriptorRequestHandler = actionDescriptorRequestHandler;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var document = httpContext.GetCmsDocument();
            if (document is null) return values;

            // get matching action descriptor
            var actionDescriptor = await _actionDescriptorRequestHandler.HandleAsync(document);
            if (actionDescriptor is null) return values;

            // add matching action descriptor route values to the route value dictionary
            foreach (var routeValue in actionDescriptor.RouteValues)
            {
                values.Add(routeValue.Key, routeValue.Value);
            }

            return values;
        }
    }
}
