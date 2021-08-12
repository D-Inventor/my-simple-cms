using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Factories
{
    /// <summary>
    /// Any type that inherits from this interface can produce highly typed documents of type <typeparamref name="TDoc"/> from lowly typed documents
    /// </summary>
    /// <typeparam name="TDoc">The type of the document to retrieve</typeparam>
    public interface IDocumentFactory<TDoc>
        where TDoc : class
    {
        /// <summary>
        /// When implemented by a class, this method will create a highly typed document from the given <paramref name="document"/>
        /// </summary>
        /// <param name="document">The information of the document that should be produced.</param>
        /// <returns>A highly typed document of type <typeparamref name="TDoc"/></returns>
        /// <exception cref="ArgumentException">Thrown when the provided document does not satisfy the requirements for this factory.</exception>
        Task<IDocumentWrapper<TDoc>> CreateAsync(IDocumentInfo document);
    }
}
