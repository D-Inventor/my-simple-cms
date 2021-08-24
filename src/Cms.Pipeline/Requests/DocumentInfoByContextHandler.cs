/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;
using Cms.Core.Requests;
using Cms.Pipeline.Matching;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Pipeline.Requests
{
    /// <summary>
    /// Uses <see cref="IDocumentInfoMatcher"/>s to match the current <see cref="HttpContext"/> to an instance of <see cref="IDocumentInfo"/>
    /// </summary>
    /// <remarks>
    /// <para>Registered in DI container as scoped</para>
    /// </remarks>
    public class DocumentInfoByContextHandler
        : IGetDocumentInfoRequestHandler<HttpContext>
    {
        private readonly IEnumerable<IDocumentInfoMatcher> _matchers;

        public DocumentInfoByContextHandler(IEnumerable<IDocumentInfoMatcher> matchers)
        {
            _matchers = matchers;
        }

        /// <inheritdoc />
        public async Task<IDocumentInfo> HandleAsync(HttpContext input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input));

            foreach (var matcher in _matchers)
            {
                var result = await matcher.Match(input);
                if (result is not null) return result;
            }

            return null;
        }
    }
}
