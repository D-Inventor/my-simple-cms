/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
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
    public class ControllerTypeDocumentActionFilter
        : ICmsDocumentActionFilter
    {
        /// <inheritdoc />
        public IEnumerable<ActionDescriptor> Filter(IEnumerable<ActionDescriptor> input, IDocument document)
        {
            var targetModelType = document.Info.ModelType;
            var targetControllerType = typeof(ICmsDocumentController<>).MakeGenericType(targetModelType);

            return from actionDescriptor in input
                   where actionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                    && controllerActionDescriptor.ControllerTypeInfo.IsAssignableTo(targetControllerType)
                   select actionDescriptor;
        }
    }
}
