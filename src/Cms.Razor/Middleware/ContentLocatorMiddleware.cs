using Cms.Core.Services;

using Microsoft.AspNetCore.Http;

using System;
using System.Threading.Tasks;

namespace Cms.Razor.Middleware
{
    internal class ContentLocatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDocumentLocator _documentLocator;

        public ContentLocatorMiddleware(RequestDelegate next, IDocumentLocator documentLocator)
        {
            _next = next;
            _documentLocator = documentLocator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Features.Set(await _documentLocator.GetDocumentAsync(new Uri($"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{context.Request.Path}")));
            await _next(context);
        }
    }
}
