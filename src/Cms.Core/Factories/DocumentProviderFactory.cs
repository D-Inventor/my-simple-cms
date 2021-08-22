/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Core.Providers;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Cms.Core.Factories
{
    /// <summary>
    /// This class creates an <see cref="IDocumentProvider"/> by requesting it as an <see cref="IDocumentProviderAdapter{TModel}"/> from an <see cref="IServiceProvider"/> where TModel is equal to <see cref="IDocumentInfo.ModelType" />.
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as transient</para>
    /// </remarks>
    public class DocumentProviderFactory
        : IDocumentProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DocumentProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public IDocumentProvider Create(IDocumentInfo info)
        {
            var targetModelType = info.ModelType;
            var targetServiceType = typeof(IDocumentProviderAdapter<>).MakeGenericType(targetModelType);

            var service = _serviceProvider.GetRequiredService(targetServiceType) as IDocumentProvider;
            return service;
        }
    }
}
