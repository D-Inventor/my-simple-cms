/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Requests;

using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace Cms.Pipeline.Middleware
{
    /// <summary>
    /// Middleware that enriches the httpcontext with an instance of <see cref="Core.Models.IDocument{TModel}"/>, matching the current request
    /// </summary>
    internal sealed class CmsDocumentMiddleware
    {
        private readonly RequestDelegate _next;

        public CmsDocumentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
                                      IGetDocumentRequestHandler<HttpContext> getDocumentByContextRequestHandler)
        {
            var document = await getDocumentByContextRequestHandler.HandleAsync(context);
            if (document is not null) context.SetCmsDocument(document);

            await _next(context);
        }
    }
}
