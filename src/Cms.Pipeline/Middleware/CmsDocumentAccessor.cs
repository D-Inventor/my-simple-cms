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

namespace Cms.Pipeline.Middleware
{
    /// <summary>
    /// Returns the current document that is stored in the <see cref="HttpContext"/> of the current request
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class CmsDocumentAccessor
        : ICmsDocumentAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CmsDocumentAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public IDocument Document => _httpContextAccessor.HttpContext?.GetCmsDocument();
    }

    /// <summary>
    /// Returns the current document that is stored in the <see cref="HttpContext"/> of the current request
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class CmsDocumentAccessor<TModel>
        : ICmsDocumentAccessor<TModel>
        where TModel : class
    {
        private readonly ICmsDocumentAccessor _cmsDocumentAccessor;

        public CmsDocumentAccessor(ICmsDocumentAccessor cmsDocumentAccessor)
        {
            _cmsDocumentAccessor = cmsDocumentAccessor;
        }

        /// <inheritdoc />
        public IDocument<TModel> Document => _cmsDocumentAccessor.Document as IDocument<TModel>;
    }
}
