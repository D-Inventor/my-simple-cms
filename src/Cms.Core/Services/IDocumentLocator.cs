using Cms.Core.Models;

using System;
using System.Threading.Tasks;

namespace Cms.Core.Services
{
    /// <summary>
    /// Classes that implement this interface can match parameters to a document and return that document.
    /// </summary>
    /// <remarks>
    /// <para>This interface acts on the low-type side of the cms.</para>
    /// </remarks>
    public interface IDocumentLocator
    {
        /// <summary>
        /// When implemented by a class, this method maps the given url to a document and returns that document.
        /// </summary>
        /// <remarks>
        /// <para>Implementing classes should not throw exceptions as these are not handled by the framework. If a document can not be found, this method should return null.</para>
        /// </remarks>
        /// <param name="url">The url to match a document to</param>
        /// <returns>The document that matches the given url as an <see cref="IDocumentWrapper{TDocument}"/></returns>
        Task<IDocumentInfo> GetDocumentAsync(Uri url);
    }
}