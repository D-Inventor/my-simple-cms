/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Pipeline.Factories;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Pipeline.Requests
{
    /// <summary>
    /// Makes a selection of all the known <see cref="ActionDescriptor"/>s using all available filters.
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class ActionDescriptorByDocumentHandler
        : IGetActionDescriptorRequestHandler<IDocument>
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly ICmsDocumentActionFilterFactory _actionFilterFactory;

        public ActionDescriptorByDocumentHandler(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
                                                 ICmsDocumentActionFilterFactory actionFilterFactory)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _actionFilterFactory = actionFilterFactory;
        }

        /// <inheritdoc />
        public Task<ActionDescriptor> HandleAsync(IDocument input)
        {
            IEnumerable<ActionDescriptor> candidates = _actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (var filter in _actionFilterFactory.Create(input))
            {
                candidates = filter.Filter(candidates, input);
            }

            return Task.FromResult(candidates.FirstOrDefault());
        }
    }
}
