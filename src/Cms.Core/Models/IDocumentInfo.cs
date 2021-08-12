using System;

namespace Cms.Core.Models
{
    /// <summary>
    /// Any type that implements this interface can provide information about a document. For the document itself, see <see cref="IDocumentWrapper{TDocument}"/>
    /// </summary>
    public interface IDocumentInfo
    {
        /// <summary>
        /// When implemented by a type, this property returns a unique identifier for this instance. This id is used to locate, store and relate documents.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// When implemented by a type, this property returns the type of the document. This value is used to produce a highly typed document.
        /// </summary>
        Type DocumentType { get; }
    }
}