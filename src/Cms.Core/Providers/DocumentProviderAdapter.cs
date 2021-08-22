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
    /// Provides a document by wrapping around an instance of <see cref="IDocumentProvider{TModel}"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as a scoped open generic</para>
    /// </remarks>
    /// <typeparam name="TModel">The model type of the <see cref="IDocument"/></typeparam>
    public class DocumentProviderAdapter<TModel>
        : IDocumentProviderAdapter<TModel>
        where TModel : class
    {
        private readonly IDocumentProvider<TModel> _documentProvider;

        public DocumentProviderAdapter(IDocumentProvider<TModel> documentProvider)
        {
            _documentProvider = documentProvider;
        }

        /// <inheritdoc />
        public async Task<IDocument> GetDocumentAsync(IDocumentInfo info)
        {
            return await _documentProvider.GetDocumentAsync(info);
        }
    }
}
