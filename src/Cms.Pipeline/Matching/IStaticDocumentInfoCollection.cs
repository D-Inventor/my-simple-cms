/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

namespace Cms.Pipeline.Matching
{
    /// <summary>
    /// Any type that implements this interface can save and return instances of <see cref="IDocumentInfo"/> on a static url.
    /// </summary>
    /// <remarks>
    /// <para>Types that implement this interface should be registered in the DI container as singleton</para>
    /// <para>register static instances of <see cref="IDocumentInfo"/> on startup by registering a type as <see cref="Microsoft.Extensions.Hosting.IHostedService"/></para>
    /// </remarks>
    public interface IStaticDocumentInfoCollection
    {
        /// <summary>
        /// When implemented by a type, this method registers an instance of <see cref="IDocumentInfo"/> on the given <paramref name="url"/>
        /// </summary>
        /// <param name="url">The url on which the <paramref name="info"/> is registered. This can either be a path or domain + path</param>
        /// <param name="info">The instance of <see cref="IDocumentInfo"/> to register.</param>
        void AddRoute(string url, IDocumentInfo info);

        /// <summary>
        /// When implemented by a type, this method gets the <see cref="IDocumentInfo"/> associated with the given url
        /// </summary>
        /// <param name="url">The url of the <see cref="IDocumentInfo"/> to get. This can either be a path or domain + path</param>
        /// <param name="info">When this method returns, contains the <see cref="IDocumentInfo"/> associated with the given url if it exists; otherwise contains the default value.</param>
        /// <returns><see langword="true"/> if the <see cref="IStaticDocumentInfoCollection"/> contains an <see cref="IDocumentInfo"/> with the given url; otherwise returns <see langword="false"/></returns>
        bool TryGetRoute(string url, out IDocumentInfo info);
    }
}