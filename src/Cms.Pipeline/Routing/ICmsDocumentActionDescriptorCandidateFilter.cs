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

using System.Collections.Generic;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Any type that implements this interface can make a selection from a set of <see cref="ActionDescriptor"/>s based on a given <see cref="IDocument" />
    /// </summary>
    public interface ICmsDocumentActionDescriptorCandidateFilter
    {
        /// <summary>
        /// When implemented by a type, this method filters a given set of <see cref="ActionDescriptor"/>s
        /// </summary>
        /// <param name="input">A set of <see cref="ActionDescriptor"/>s</param>
        /// <returns>A subset of the <paramref name="input"/></returns>
        IEnumerable<ActionDescriptor> Filter(IEnumerable<ActionDescriptor> input);
    }

    /// <summary>
    /// Any type that implements this interface can make a selection from a set of <see cref="ActionDescriptor"/>s based on a given <see cref="IDocument{TModel}" />
    /// </summary>
    public interface ICmsDocumentActionDescriptorCandidateFilter<TModel>
        : ICmsDocumentActionDescriptorCandidateFilter
        where TModel : class
    { }
}
