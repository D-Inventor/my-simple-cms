/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Pipeline.Middleware;
using Cms.Pipeline.Routing;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cms.Pipeline
{
    public static class PipelineExtensions
    {
        /// <summary>
        /// Adds a <see cref="CmsDocumentMiddleware"/> to the request pipeline.
        /// </summary>
        /// <remarks>
        /// <para>Maps the request to a document in the cms and adds this document to the current <see cref="Microsoft.AspNetCore.Http.HttpContext"/>.</para>
        /// <para>Can optionally be followed up by a call to <see cref="MapCmsDocumentControllerRoute(IEndpointRouteBuilder)"/>.</para>
        /// </remarks>
        /// <returns>A reference of this instance once the operation is completed.</returns>
        public static IApplicationBuilder UseCmsDocument(this IApplicationBuilder app)
            => app.UseMiddleware<CmsDocumentMiddleware>();

        /// <summary>
        /// Adds endpoints for controller actions to the <see cref="IEndpointRouteBuilder"/> and maps them to cms documents
        /// </summary>
        /// <remarks>
        /// <para>Must be preceded by a call to <see cref="UseCmsDocument(IApplicationBuilder)"/>.</para>
        /// </remarks>
        /// <returns>A reference of this instance once the operation is completed.</returns>
        public static IEndpointRouteBuilder MapCmsDocumentControllerRoute(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapDynamicControllerRoute<CmsDocumentRouteValueTransformer>("{**path}");
            return endpoints;
        }
    }
}
