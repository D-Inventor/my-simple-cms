/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Factories;
using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Requests
{
    /// <summary>
    /// Passes on the search to an <see cref="IGetDocumentInfoRequestHandler{TInput}"/> and gets a document from an <see cref="Providers.IDocumentProvider"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as a scoped open generic</para>
    /// </remarks>
    /// <typeparam name="TInput">The search parameter</typeparam>
    public class GetDocumentRequestHandler<TInput>
        : IGetDocumentRequestHandler<TInput>
    {
        private readonly IGetDocumentInfoRequestHandler<TInput> _getDocumentInfoRequestHandler;
        private readonly IDocumentProviderFactory _documentProviderFactory;

        public GetDocumentRequestHandler(IGetDocumentInfoRequestHandler<TInput> getDocumentInfoRequestHandler,
                                         IDocumentProviderFactory documentProviderFactory)
        {
            _getDocumentInfoRequestHandler = getDocumentInfoRequestHandler;
            _documentProviderFactory = documentProviderFactory;
        }

        /// <inheritdoc />
        public async Task<IDocument> HandleAsync(TInput input)
        {
            var info = await _getDocumentInfoRequestHandler.HandleAsync(input);
            if (info is null) return null;

            var documentProvider = _documentProviderFactory.Create(info);
            return await documentProvider.GetDocumentAsync(info);
        }
    }
}
