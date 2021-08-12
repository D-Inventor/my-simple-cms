using Cms.Razor.Extensions;
using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace Cms.Razor.Controllers
{
    /// <summary>
    /// The base controller for a request with cms content.
    /// </summary>
    /// <typeparam name="TDocument">The type of the document that this controller can handle.</typeparam>
    public abstract class CmsControllerBase<TDocument>
        : Controller, ICmsControllerBase<TDocument>
        where TDocument : class
    {
        /// <summary>
        /// The document that is related to this request. Returns null if no document was found or if the document is of a different type.
        /// </summary>
        /// <remarks>
        /// Can only be used in combination with the Content Locator middleware. See: <see cref="Extensions.IApplicationBuilderExtensions.UseCmsContentLocating(Microsoft.AspNetCore.Builder.IApplicationBuilder)"/>
        /// </remarks>
        public IDocumentWrapper<TDocument> Document => HttpContext.GetDocument<TDocument>();

        /// <summary>
        /// The document info related to this request. Returns null if no document was found.
        /// </summary>
        /// <remarks>
        /// Can only be used in combination with the Content Locator middleware. See: <see cref="Extensions.IApplicationBuilderExtensions.UseCmsContentLocating(Microsoft.AspNetCore.Builder.IApplicationBuilder)"/>
        /// </remarks>
        public IDocumentInfo DocumentInfo => HttpContext.GetDocumentInfo();
    }
}
