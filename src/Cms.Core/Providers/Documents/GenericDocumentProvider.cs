using Cms.Core.Factories;
using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Providers.Documents
{
    public class GenericDocumentProvider<TDoc>
        : IGenericDocumentProvider<TDoc>
        where TDoc : class
    {
        private readonly IDocumentFactory<TDoc> _documentFactory;

        public GenericDocumentProvider(IDocumentFactory<TDoc> documentFactory)
        {
            _documentFactory = documentFactory;
        }

        /// <inheritdoc />
        public async Task<IDocumentInfo> GetDocumentAsync(IDocumentInfo documentInfo)
        {
            return await _documentFactory.CreateAsync(documentInfo);
        }
    }
}
