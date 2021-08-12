using Cms.Razor.Models.Documents;
using Cms.Razor.Models.Options;
using Cms.Core.Models;
using Cms.Core.Services.DocumentMatching;

using Microsoft.Extensions.Options;

using System;
using System.Threading.Tasks;

namespace Cms.Razor.Services.DocumentMatching
{
    public class BackofficeDocumentMatcher
        : IDocumentMatcher
    {
        private readonly IOptions<BackofficeUrlOptions> _backofficeUrlOptions;

        public BackofficeDocumentMatcher(IOptions<BackofficeUrlOptions> backofficeUrlOptions)
        {
            _backofficeUrlOptions = backofficeUrlOptions;
        }

        public Task<IDocumentInfo> GetMatchAsync(Uri url)
        {
            var optionsModel = _backofficeUrlOptions.Value;
            if (url.AbsolutePath == $"/{optionsModel.BasePath}")
            {
                return Task.FromResult(DocumentInfo.Create<Backoffice>(default));
            }

            return Task.FromResult<IDocumentInfo>(null);
        }
    }
}
