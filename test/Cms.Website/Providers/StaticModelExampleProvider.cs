using Cms.Core.Models;
using Cms.Core.Providers;
using Cms.Website.Defaults;
using Cms.Website.Models;

using System;
using System.Threading.Tasks;

namespace Cms.Website.Providers
{
    public class StaticModelExampleProvider
        : IDocumentProvider<StaticModelExample>
    {
        public Task<IDocument<StaticModelExample>> GetDocumentAsync(IDocumentInfo info)
        {
            if (info.ModelType != typeof(StaticModelExample) || info.Id != StaticModelExampleDefaults.Id) throw new ArgumentException("This document provider can not provide a document with the given information.", nameof(info));
            return Task.FromResult(Document.Create(info, new StaticModelExample
            {
                Message = "Hello from the document provider!"
            }));
        }
    }
}
