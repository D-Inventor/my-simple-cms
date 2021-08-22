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

using System.Threading.Tasks;

namespace Cms.Pipeline.Matching
{
    /// <summary>
    /// Matches the url of the request to documents stored in an <see cref="IStaticDocumentInfoCollection"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class StaticDocumentInfoMatcher
        : IDocumentInfoMatcher
    {
        private readonly IStaticDocumentInfoCollection _documentInfoCollection;

        public StaticDocumentInfoMatcher(IStaticDocumentInfoCollection documentInfoCollection)
        {
            _documentInfoCollection = documentInfoCollection;
        }

        /// <inheritdoc />
        /// <remarks>
        /// <para>This method first attempts to match on domain + path. If no match was found, attempts to match only on path.</para>
        /// </remarks>
        public Task<IDocumentInfo> Match(HttpContext context)
            => Task.FromResult(DoMatch(context));

        private IDocumentInfo DoMatch(HttpContext context)
        {
            // first attempt to match on domain and path
            string path = $"{context.Request.PathBase}{context.Request.Path}";
            string url = $"{context.Request.Host}{path}";
            if (_documentInfoCollection.TryGetRoute(url, out var result)) return result;

            // if there is no match, match on path alone
            if (_documentInfoCollection.TryGetRoute(path, out result)) return result;

            // if still no match, return null
            return null;
        }
    }
}
