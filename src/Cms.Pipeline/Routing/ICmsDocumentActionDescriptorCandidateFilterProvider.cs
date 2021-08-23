/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Any type that implements this interface can create instances of <see cref="ICmsDocumentActionDescriptorCandidateFilter"/>
    /// </summary>
    public interface ICmsDocumentActionDescriptorCandidateFilterProvider
    {
        /// <summary>
        /// When implemented by a type, this property returns all available instances of <see cref="ICmsDocumentActionDescriptorCandidateFilter"/>
        /// </summary>
        /// <remarks>
        /// <para>Result should also contain instances of <see cref="ICmsDocumentActionDescriptorCandidateFilter{TModel}"/></para>
        /// </remarks>
        /// <returns>A collection of instances of <see cref="ICmsDocumentActionDescriptorCandidateFilter"/></returns>
        IEnumerable<ICmsDocumentActionDescriptorCandidateFilter> Filters { get; }
    }
}