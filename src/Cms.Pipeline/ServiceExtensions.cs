/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Core.Requests;
using Cms.Pipeline.Factories;
using Cms.Pipeline.Matching;
using Cms.Pipeline.Requests;
using Cms.Pipeline.Routing;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Pipeline
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds relevant services to use the cms in the request pipeline
        /// </summary>
        /// <param name="services"></param>
        /// <returns>The instance of <see cref="IServiceCollection"/> after the operation has completed</returns>
        public static IServiceCollection AddCmsPipeline(this IServiceCollection services)
        {
            services.AddScoped<IGetDocumentInfoRequestHandler<HttpContext>, DocumentInfoByContextHandler>();
            services.AddSingleton<IStaticDocumentInfoCollection, StaticDocumentInfoCollection>();
            services.AddScoped<IDocumentInfoMatcher, StaticDocumentInfoMatcher>();

            services.AddTransient<CmsDocumentRouteValueTransformer>();
            services.AddScoped<IGetActionDescriptorRequestHandler<IDocument>, ActionDescriptorByDocumentHandler>();
            services.AddScoped(typeof(ICmsDocumentActionFilterAdapter<>), typeof(CmsDocumentActionFilterAdapter<>));
            services.AddTransient<ICmsDocumentActionFilterFactory, CmsDocumentActionFilterFactory>();
            services.AddScoped<ICmsDocumentActionFilter, ControllerTypeDocumentActionFilter>();

            return services;
        }
    }
}
