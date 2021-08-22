/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Providers
{
    /// <summary>
    /// Any type that implements this interface can provide an instance of <see cref="IDocument"/> based on the given <see cref="IDocumentInfo"/>
    /// </summary>
    public interface IDocumentProvider
    {
        /// <summary>
        /// When implemented by a type, this method provides an instance of <see cref="IDocument"/> based on the given <see cref="IDocumentInfo"/>
        /// </summary>
        /// <remarks>
        /// <para>Implementations should return instances of <see cref="IDocument{TModel}"/> where the type of TModel is equal to <see cref="IDocumentInfo.ModelType"/>.</para>
        /// </remarks>
        /// <param name="info">An instance of <see cref="IDocumentInfo"/> for which the <see cref="IDocument"/> is provided</param>
        /// <returns>An instance of <see cref="IDocument"/> based on the given <paramref name="info"/></returns>
        Task<IDocument> GetDocumentAsync(IDocumentInfo info);
    }

    /// <inheritdoc/>
    /// <typeparam name="TModel">The model type of the provided <see cref="IDocument"/></typeparam>
    public interface IDocumentProviderAdapter<TModel>
        : IDocumentProvider
        where TModel : class
    { }

    /// <summary>
    /// Any type that implements this interface can provide an instance of <see cref="IDocument{TModel}"/> based on the given <see cref="IDocumentInfo"/>
    /// </summary>
    public interface IDocumentProvider<TModel>
        where TModel : class
    {
        /// <summary>
        /// When implemented by a type, this method provides an instance of <see cref="IDocument{TModel}"/> based on the given <see cref="IDocumentInfo"/>
        /// </summary>
        /// <param name="info">An instance of <see cref="IDocumentInfo"/> for which the <see cref="IDocument"/> is provided</param>
        /// <returns>An instance of <see cref="IDocument"/> based on the given <paramref name="info"/></returns>
        /// <exception cref="System.ArgumentException"></exception>
        Task<IDocument<TModel>> GetDocumentAsync(IDocumentInfo info);
    }
}
