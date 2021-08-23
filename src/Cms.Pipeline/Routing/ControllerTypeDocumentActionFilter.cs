/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Pipeline.Middleware;
using Cms.Pipeline.Mvc;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;

using System.Collections.Generic;
using System.Linq;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Filters out all <see cref="ActionDescriptor"/>s that don't implement <see cref="ICmsDocumentController{TModel}"/> or have a different model than the document that is associated with the current request
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class ControllerTypeDocumentActionFilter
        : ICmsDocumentActionDescriptorCandidateFilter
    {
        private readonly ICmsDocumentAccessor _documentAccessor;

        public ControllerTypeDocumentActionFilter(ICmsDocumentAccessor documentAccessor)
        {
            _documentAccessor = documentAccessor;
        }

        /// <inheritdoc />
        public IEnumerable<ActionDescriptor> Filter(IEnumerable<ActionDescriptor> input)
        {
            var document = _documentAccessor.Document;
            if (document is null) return input;

            var targetModelType = document.Info.ModelType;
            var targetControllerType = typeof(ICmsDocumentController<>).MakeGenericType(targetModelType);

            return from actionDescriptor in input
                   where actionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                    && controllerActionDescriptor.ControllerTypeInfo.IsAssignableTo(targetControllerType)
                   select actionDescriptor;
        }
    }
}
