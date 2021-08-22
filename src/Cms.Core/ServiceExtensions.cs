/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Factories;
using Cms.Core.Providers;
using Cms.Core.Requests;

using Microsoft.Extensions.DependencyInjection;

namespace Cms.Core
{
    /// <summary>
    /// Static helper for registering core services
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds the core services to the service collection
        /// </summary>
        /// <remarks>
        /// <para>This method must be called once if you want to make use of any cms functionality</para>
        /// </remarks>
        /// <returns>The instance of <see cref="IServiceCollection"/> when the operation has completed</returns>
        public static IServiceCollection AddCmsCore(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetDocumentRequestHandler<>), typeof(GetDocumentRequestHandler<>));
            services.AddScoped(typeof(IDocumentProviderAdapter<>), typeof(DocumentProviderAdapter<>));
            services.AddTransient<IDocumentProviderFactory, DocumentProviderFactory>();
            return services;
        }
    }
}
