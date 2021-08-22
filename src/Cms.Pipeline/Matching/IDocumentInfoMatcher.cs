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
    /// Any type that implements this interface can match an incoming request with an <see cref="IDocumentInfo"/>
    /// </summary>
    /// <remarks>
    /// <para>Types that implement this interface should be registered in the DI container as scoped or transient</para>
    /// </remarks>
    public interface IDocumentInfoMatcher
    {
        /// <summary>
        /// When implemented by a type, this method matches an http context to an <see cref="IDocumentInfo"/>
        /// </summary>
        /// <param name="context">The current request context</param>
        /// <returns>An instance of <see cref="IDocumentInfo"/></returns>
        Task<IDocumentInfo> Match(HttpContext context);
    }
}
