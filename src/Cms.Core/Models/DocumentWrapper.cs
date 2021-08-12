using System;

namespace Cms.Core.Models
{
    internal class DocumentWrapper<TDocument>
        : IDocumentWrapper<TDocument>
        where TDocument : class
    {
        private readonly IDocumentInfo _documentInfo;
        private readonly TDocument _document;

        public DocumentWrapper(IDocumentInfo documentInfo, TDocument document)
        {
            _documentInfo = documentInfo ?? throw new ArgumentNullException(nameof(documentInfo));
            _document = document ?? throw new ArgumentNullException(nameof(document));

            if (typeof(TDocument) != documentInfo.DocumentType) throw new ArgumentException("The type in the document info must match the type of the document.", nameof(documentInfo));
        }

        public TDocument Document => _document;
        public Guid Id => _documentInfo.Id;
        public Type DocumentType => _documentInfo.DocumentType;
    }
}
