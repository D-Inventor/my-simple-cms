using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Caching.Memory;

using System;

namespace Cms.Razor.Providers
{
    internal class DecoratorICmsActionDescriptorProviderCaching
        : ICmsActionDescriptorProvider
    {
        private readonly ICmsActionDescriptorProvider _decoratee;
        private readonly IMemoryCache _cache;

        public DecoratorICmsActionDescriptorProviderCaching(ICmsActionDescriptorProvider decoratee, IMemoryCache cache)
        {
            _decoratee = decoratee;
            _cache = cache;
        }

        public ActionDescriptor GetActionDescriptor(IDocumentInfo document)
        {
            if (!_cache.TryGetValue<ActionDescriptor>(document.DocumentType, out var result))
            {
                result = _decoratee.GetActionDescriptor(document);
                _cache.Set(document.DocumentType, result, TimeSpan.FromMinutes(10));
            }

            return result;
        }
    }
}
