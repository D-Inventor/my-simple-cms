using Cms.Core.Models;

using System;
using System.Threading.Tasks;

namespace Cms.Core.Services.DocumentMatching
{
    public interface IDocumentMatcher
    {
        Task<IDocumentInfo> GetMatchAsync(Uri url);
    }
}
