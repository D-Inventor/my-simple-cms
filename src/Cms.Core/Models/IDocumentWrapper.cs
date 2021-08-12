namespace Cms.Core.Models
{
    /// <summary>
    /// Any type that implements this interface is capable of providing a document and related information.
    /// </summary>
    /// <typeparam name="TDocument">The document type</typeparam>
    public interface IDocumentWrapper<out TDocument>
        : IDocumentInfo
        where TDocument : class
    {
        /// <summary>
        /// When implemented by a type, this property returns the document that is bound to this instance
        /// </summary>
        TDocument Document { get; }
    }
}
