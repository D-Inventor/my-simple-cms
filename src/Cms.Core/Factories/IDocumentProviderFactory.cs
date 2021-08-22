/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Core.Providers;

namespace Cms.Core.Factories
{
    /// <summary>
    /// Any type that implements this interface can create an instance of <see cref="IDocumentProvider"/> that provides the <see cref="IDocument"/> belonging to a given <see cref="IDocumentInfo"/>.
    /// </summary>
    public interface IDocumentProviderFactory
    {
        /// <summary>
        /// When implemented by a type, this method will create an instance of <see cref="IDocumentProvider"/> that provides the <see cref="IDocument"/> belonging to the given <paramref name="info"/>.
        /// </summary>
        /// <remarks>
        /// <para>Implementations of <see cref="IDocumentProvider"/> should return instances of <see cref="IDocument{TModel}"/> where the type of TModel is equal to <see cref="IDocumentInfo.ModelType"/>.</para>
        /// </remarks>
        /// <param name="info">An instance of <see cref="IDocumentInfo"/> for which the document provider should provide a document.</param>
        /// <returns>An instance of <see cref="IDocumentProvider"/> that provides the <see cref="IDocument"/> that belongs to the given <paramref name="info"/></returns>
        IDocumentProvider Create(IDocumentInfo info);
    }
}