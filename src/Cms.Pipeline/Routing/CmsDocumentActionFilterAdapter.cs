/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Abstractions;

using System;
using System.Collections.Generic;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Filters by wrapping around all instances of <see cref="ICmsDocumentActionFilter{TModel}"/>
    /// </summary>
    /// <typeparam name="TModel">The model type of the document associated with the current request</typeparam>
    public class CmsDocumentActionFilterAdapter<TModel>
        : ICmsDocumentActionFilterAdapter<TModel>
        where TModel : class
    {
        private readonly IEnumerable<ICmsDocumentActionFilter<TModel>> _actionFilters;

        public CmsDocumentActionFilterAdapter(IEnumerable<ICmsDocumentActionFilter<TModel>> actionFilters)
        {
            _actionFilters = actionFilters;
        }

        /// <inheritdoc />
        public IEnumerable<ActionDescriptor> Filter(IEnumerable<ActionDescriptor> input, IDocument document)
        {
            if (document is not IDocument<TModel> documentWithModel) throw new ArgumentException("This filter cannot filter action descriptors with the given document.", nameof(document));
            foreach (var filter in _actionFilters)
            {
                input = filter.Filter(input, documentWithModel);
            }
            return input;
        }
    }
}
