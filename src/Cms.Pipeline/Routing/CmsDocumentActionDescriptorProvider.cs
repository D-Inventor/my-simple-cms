/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Makes a selection of all the known <see cref="ActionDescriptor"/>s using all available filters.
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class CmsDocumentActionDescriptorProvider
        : ICmsDocumentActionDescriptorProvider
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly ICmsDocumentActionDescriptorCandidateFilterProvider _actionDescriptorFilterProvider;

        public CmsDocumentActionDescriptorProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
                                                   ICmsDocumentActionDescriptorCandidateFilterProvider actionDescriptorFilterProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _actionDescriptorFilterProvider = actionDescriptorFilterProvider;
        }

        /// <inheritdoc />
        public Task<ActionDescriptor> GetActionDescriptorAsync()
        {
            IEnumerable<ActionDescriptor> candidates = _actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (var filter in _actionDescriptorFilterProvider.Filters)
            {
                candidates = filter.Filter(candidates);
            }

            return Task.FromResult(candidates.FirstOrDefault());
        }
    }
}
