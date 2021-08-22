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

using System.Collections.Generic;

namespace Cms.Pipeline.Factories
{
    /// <summary>
    /// Any type that implements this interface can create instances of <see cref="ICmsDocumentActionFilter"/>
    /// </summary>
    public interface ICmsDocumentActionFilterFactory
    {
        /// <summary>
        /// When implemented by a type, this method creates instances of <see cref="ICmsDocumentActionFilter"/>
        /// </summary>
        /// <remarks>
        /// <para>Result should also contain instances of <see cref="ICmsDocumentActionFilter{TModel}"/>, wrapped in an <see cref="ICmsDocumentActionFilterAdapter{TModel}"/></para>
        /// </remarks>
        /// <param name="document">The input parameter</param>
        /// <returns>A collection of instances of <see cref="ICmsDocumentActionFilter"/></returns>
        IEnumerable<ICmsDocumentActionFilter> Create(IDocument document);
    }
}