/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Pipeline.Middleware;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// This class creates instances of <see cref="ICmsDocumentActionDescriptorCandidateFilter"/> by requesting them as <see cref="ICmsDocumentActionFilterAdapter{TModel}"/> from an <see cref="IServiceProvider"/> where TModel is equal to <see cref="IDocumentInfo.ModelType"/> from <see cref="IDocument.Info"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class CmsDocumentActionDescriptorCandidateFilterProvider
        : ICmsDocumentActionDescriptorCandidateFilterProvider
    {
        private readonly ICmsDocumentAccessor _documentAccessor;
        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<ICmsDocumentActionDescriptorCandidateFilter> _documentFilters;

        public CmsDocumentActionDescriptorCandidateFilterProvider(ICmsDocumentAccessor documentAccessor,
                                                                  IServiceProvider serviceProvider,
                                                                  IEnumerable<ICmsDocumentActionDescriptorCandidateFilter> documentFilters)
        {
            _documentAccessor = documentAccessor;
            _serviceProvider = serviceProvider;
            _documentFilters = documentFilters;
        }

        /// <inheritdoc />
        public IEnumerable<ICmsDocumentActionDescriptorCandidateFilter> Filters
        {
            get
            {
                var document = _documentAccessor.Document;
                if (document is null) throw new InvalidOperationException("This provider cannot be used because no document is currently associated with this request.");

                var targetModelType = document.Info.ModelType;
                var targetServiceType = typeof(ICmsDocumentActionDescriptorCandidateFilter<>).MakeGenericType(targetModelType);
                var collectionTargetServiceType = typeof(IEnumerable<>).MakeGenericType(targetServiceType);

                var services = _serviceProvider.GetRequiredService(collectionTargetServiceType) as IEnumerable<ICmsDocumentActionDescriptorCandidateFilter>;

                return _documentFilters.Concat(services).ToList();
            }
        }
    }
}
