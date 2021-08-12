using System;

namespace Cms.Core.Models
{
    /// <summary>
    /// This class contains <see langword="static" /> helper methods for creating instances of <see cref="IDocumentInfo"/> and <see cref="IDocumentWrapper{TDocument}"/>.
    /// </summary>
    /// <remarks>
    /// <para>This class should not be instantiated. Use the <see langword="static"/> helper methods to create instances of <see cref="IDocumentInfo"/> instead.</para>
    /// </remarks>
    public class DocumentInfo
        : IDocumentInfo
    {
        internal DocumentInfo()
        { }

        /// <summary>
        /// The unique identifier of the document
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The model type that belongs to this document
        /// </summary>
        public Type DocumentType { get; set; }

        /// <summary>
        /// Creates a new document info object with an id and a document type
        /// </summary>
        /// <param name="id">The unique identifier for this document</param>
        /// <param name="documentType">The model type for this document</param>
        /// <returns>A new <see cref="IDocumentInfo"/> instance.</returns>
        internal static IDocumentInfo Create(Guid id, Type documentType)
            => new DocumentInfo
            {
                Id = id,
                DocumentType = documentType
            };

        /// <summary>
        /// Creates a new document info object with an id and a document type
        /// </summary>
        /// <typeparam name="TDocument">The model type for this document</typeparam>
        /// <param name="id">The unique identifier for this document</param>
        /// <returns>A new <see cref="IDocumentInfo"/> instance.</returns>
        public static IDocumentInfo Create<TDocument>(Guid id)
            where TDocument : class
            => Create(id, typeof(TDocument));

        /// <summary>
        /// Creates a new document object with document info and an instance of the model
        /// </summary>
        /// <typeparam name="TDocument">The type of the document model</typeparam>
        /// <param name="documentInfo">The information of the document</param>
        /// <param name="document">The instance of the model</param>
        /// <returns>A new <see cref="IDocumentWrapper{TDocument}"/> instance.</returns>
        public static IDocumentWrapper<TDocument> Create<TDocument>(IDocumentInfo documentInfo, TDocument document)
            where TDocument : class
            => new DocumentWrapper<TDocument>(documentInfo, document);

        /// <summary>
        /// Creates a new document object with unique id and an instance of the model
        /// </summary>
        /// <typeparam name="TDocument">The type of the document model</typeparam>
        /// <param name="id">The unique identifier for this document</param>
        /// <param name="document">The model type for this document</param>
        /// <returns>A new <see cref="IDocumentWrapper{TDocument}"/> instance.</returns>
        public static IDocumentWrapper<TDocument> Create<TDocument>(Guid id, TDocument document)
            where TDocument : class
            => Create(Create<TDocument>(id), document);
    }
}
