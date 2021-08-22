using Cms.Core.Models;
using Cms.Pipeline.Matching;
using Cms.Website.Defaults;
using Cms.Website.Models;

using Microsoft.Extensions.Hosting;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cms.Website.Services
{
    public class RegisterStaticDocumentsService : IHostedService
    {
        private readonly IStaticDocumentInfoCollection _staticDocumentInfoCollection;

        public RegisterStaticDocumentsService(IStaticDocumentInfoCollection staticDocumentInfoCollection)
        {
            _staticDocumentInfoCollection = staticDocumentInfoCollection;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Guid guid = StaticModelExampleDefaults.Id;
            IDocumentInfo info = DocumentInfo.Create<StaticModelExample>(guid);

            _staticDocumentInfoCollection.AddRoute("/staticDocument/example", info);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
