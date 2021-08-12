using Cms.Core.Models;

using Microsoft.AspNetCore.Http;

namespace Cms.Razor.Extensions
{
    public static class HttpContextExtensions
    {
        public static IDocumentWrapper<TDocument> GetDocument<TDocument>(this HttpContext context)
            where TDocument : class
            => context.GetDocumentInfo() as IDocumentWrapper<TDocument>;

        public static IDocumentInfo GetDocumentInfo(this HttpContext context)
            => context.Features.Get<IDocumentInfo>();
    }
}
