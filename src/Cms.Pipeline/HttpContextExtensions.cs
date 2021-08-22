/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using Microsoft.AspNetCore.Http;

using System;

namespace Cms.Pipeline
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Sets the document that is associated with the current request.
        /// </summary>
        /// <param name="context">The current context</param>
        /// <param name="document">The document</param>
        public static void SetCmsDocument(this HttpContext context, IDocument document)
            => context.Features.Set(document);

        /// <summary>
        /// Gets the document that is associated with the current request
        /// </summary>
        /// <param name="context">The current context</param>
        /// <returns>An instance of <see cref="IDocument"/> if previously set; otherwise returns <see langword="null"/></returns>
        public static IDocument GetCmsDocument(this HttpContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));
            return context.Features.Get<IDocument>();
        }

        /// <summary>
        /// Gets the document that is associated with the current request
        /// </summary>
        /// <typeparam name="TModel">The type of the model of the document</typeparam>
        /// <param name="context">The current context</param>
        /// <returns>An instance of <see cref="IDocument{TModel}"/> if previously set; otherwise returns <see langword="null"/></returns>
        public static IDocument<TModel> GetCmsDocument<TModel>(this HttpContext context)
            where TModel : class
            => context.GetCmsDocument() as IDocument<TModel>;

        /// <summary>
        /// Gets the document info that is associated with the current request
        /// </summary>
        /// <param name="context">The current context</param>
        /// <returns>An instance of <see cref="IDocumentInfo"/> if the document is previously set; otherwise returns <see langword="null"/></returns>
        public static IDocumentInfo GetCmsDocumentInfo(this HttpContext context)
            => context.GetCmsDocument()?.Info;
    }
}
