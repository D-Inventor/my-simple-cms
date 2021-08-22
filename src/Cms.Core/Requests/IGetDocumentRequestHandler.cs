/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using System.Threading.Tasks;

namespace Cms.Core.Requests
{
    /// <summary>
    /// Any type that implements this interface can find an <see cref="IDocument"/> using the given <typeparamref name="TInput"/>
    /// </summary>
    /// <typeparam name="TInput">The search parameter</typeparam>
    public interface IGetDocumentRequestHandler<in TInput>
    {
        /// <summary>
        /// When implemented by a type, this method finds an <see cref="IDocument"/> based in the <paramref name="input"/>
        /// </summary>
        /// <param name="input">The search parameter</param>
        /// <returns>an instance of <see cref="IDocument"/> that matches the given <paramref name="input"/></returns>
        Task<IDocument> HandleAsync(TInput input);
    }
}
