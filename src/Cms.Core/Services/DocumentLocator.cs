using Cms.Core.Models;
using Cms.Core.Providers.Documents;
using Cms.Core.Services.DocumentMatching;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Core.Services
{
    /// <summary>
    /// The standard implementation of the <see cref="IDocumentLocator"/>.
    /// </summary>
    public class DocumentLocator
        : IDocumentLocator
    {
        private readonly IEnumerable<IDocumentMatcher> _urlMatchers;
        private readonly IHighTypeServiceBridge _highTypeServiceBridge;

        public DocumentLocator(IEnumerable<IDocumentMatcher> urlMatchers,
                               IHighTypeServiceBridge highTypeServiceBridge)
        {
            _urlMatchers = urlMatchers;
            _highTypeServiceBridge = highTypeServiceBridge;
        }

        /// <inheritdoc />
        public async Task<IDocumentInfo> GetDocumentAsync(Uri url)
        {
            IDocumentInfo baseInfo = null;
            foreach (var matcher in _urlMatchers)
            {
                baseInfo = await matcher.GetMatchAsync(url);
                if (baseInfo is not null) break;
            }

            if (baseInfo is null) return null;

            var documentProvider = _highTypeServiceBridge.GetHighlyTypedService<IDocumentProvider>(typeof(IGenericDocumentProvider<>), baseInfo.DocumentType);

            return await documentProvider.GetDocumentAsync(baseInfo);
        }
    }
}
