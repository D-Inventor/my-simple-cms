using Cms.Razor.Models.Documents;
using Cms.Core.Factories;
using Cms.Core.Models;

using System;
using System.Threading.Tasks;

namespace Cms.Razor.Factories
{
    public class BackofficeDocumentFactory
        : IDocumentFactory<Backoffice>
    {
        public Task<IDocumentWrapper<Backoffice>> CreateAsync(IDocumentInfo document)
        {
            if (document.DocumentType != typeof(Backoffice)) throw new ArgumentException($"Expected document info for {typeof(Backoffice)}, but got {document.DocumentType}", nameof(document));
            return Task.FromResult(DocumentInfo.Create(document, new Backoffice()));
        }
    }
}
