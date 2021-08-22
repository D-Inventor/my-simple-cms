/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Pipeline.Routing;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cms.Pipeline.Factories
{
    /// <summary>
    /// This class creates instances of <see cref="ICmsDocumentActionFilter"/> by requesting them as <see cref="ICmsDocumentActionFilterAdapter{TModel}"/> from an <see cref="IServiceProvider"/> where TModel is equal to <see cref="IDocumentInfo.ModelType"/> from <see cref="IDocument.Info"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as transient</para>
    /// </remarks>
    public class CmsDocumentActionFilterFactory
        : ICmsDocumentActionFilterFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<ICmsDocumentActionFilter> _documentFilters;

        public CmsDocumentActionFilterFactory(IServiceProvider serviceProvider, IEnumerable<ICmsDocumentActionFilter> documentFilters)
        {
            _serviceProvider = serviceProvider;
            _documentFilters = documentFilters;
        }

        /// <inheritdoc />
        public IEnumerable<ICmsDocumentActionFilter> Create(IDocument document)
        {
            var targetModelType = document.Info.ModelType;
            var targetServiceType = typeof(ICmsDocumentActionFilterAdapter<>).MakeGenericType(targetModelType);
            var collectionTargetServiceType = typeof(IEnumerable<>).MakeGenericType(targetServiceType);

            var services = _serviceProvider.GetRequiredService(collectionTargetServiceType) as IEnumerable<ICmsDocumentActionFilter>;

            return _documentFilters.Concat(services).ToList();
        }
    }
}
