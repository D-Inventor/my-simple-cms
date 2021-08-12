using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Providers.Documents
{
    /// <summary>
    /// When implemented by a type, this interface adds functionality to obtain a highly typed document equivalent of a provided lowly typed document.
    /// </summary>
    /// <remarks>
    /// <para>This interface should not be implemented directly. Instead, implement the <see cref="IGenericDocumentProvider{TDoc}"/> interface.</para>
    /// </remarks>
    public interface IDocumentProvider
    {
        /// <summary>
        /// When implemented by a type, this method returns an <see cref="IDocumentWrapper{TDocument}"/> casted to <see cref="IDocumentInfo"/> based on the given <paramref name="documentInfo"/>.
        /// </summary>
        /// <param name="documentInfo">The document info for which the document should be provided.</param>
        /// <returns>An <see cref="IDocumentWrapper{TDocument}"/> based on the provided <paramref name="documentInfo"/>, casted to <see cref="IDocumentInfo"/></returns>
        Task<IDocumentInfo> GetDocumentAsync(IDocumentInfo documentInfo);
    }

    /// <summary>
    /// When implemented by a type, this interface adds functionality to obtain a high-type document equivalent of a provided low-type document.
    /// </summary>
    /// <typeparam name="TDoc">The document type that is associated with the documents that this class can provide</typeparam>
    public interface IGenericDocumentProvider<TDoc>
        : IDocumentProvider
        where TDoc : class
    { }
}
