/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using System.Collections.Generic;

namespace Cms.Pipeline.Matching
{
    /// <summary>
    /// Stores instances of <see cref="IDocumentInfo"/> in a <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as a singleton</para>
    /// </remarks>
    public class StaticDocumentInfoCollection
        : IStaticDocumentInfoCollection
    {
        private readonly Dictionary<string, IDocumentInfo> _routeDictionary;

        public StaticDocumentInfoCollection()
        {
            _routeDictionary = new Dictionary<string, IDocumentInfo>();
        }

        /// <inheritdoc />
        /// <remarks>
        /// <para>leading and trailing / and \ characters are removed and the url is transformed to lowercase.</para>
        /// </remarks>
        public void AddRoute(string url, IDocumentInfo info)
        {
            _routeDictionary.Add(url.Trim('/', '\\').ToLowerInvariant(), info);
        }

        /// <inheritdoc />
        /// <remarks>
        /// <para>leading and trailing / and \ characters are removed and the url is transformed to lowercase.</para>
        /// </remarks>
        public bool TryGetRoute(string url, out IDocumentInfo info)
        {
            return _routeDictionary.TryGetValue(url.Trim('/', '\\').ToLowerInvariant(), out info);
        }
    }
}
