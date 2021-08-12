using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Cms.Razor.Providers
{
    internal interface ICmsActionDescriptorProvider
    {
        ActionDescriptor GetActionDescriptor(IDocumentInfo document);
    }
}