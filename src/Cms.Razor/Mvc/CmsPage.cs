using Cms.Razor.Extensions;
using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Razor;

namespace Cms.Razor.Mvc
{
    public abstract class CmsPage<TDocument, TModel>
        : RazorPage<TModel>
        where TDocument : class
    {
        public IDocumentWrapper<TDocument> Document
            => Context.GetDocument<TDocument>();
    }

    public abstract class CmsPage<TDocument>
        : RazorPage
        where TDocument : class
    {
        public IDocumentWrapper<TDocument> Document
            => Context.GetDocument<TDocument>();
    }
}
