/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Microsoft.AspNetCore.Mvc.Abstractions;

using System.Threading.Tasks;

namespace Cms.Pipeline.Requests
{
    /// <summary>
    /// Any type that implements this interface can find an <see cref="ActionDescriptor"/> using the given <typeparamref name="TInput"/>
    /// </summary>
    /// <typeparam name="TInput">The search parameter</typeparam>
    public interface IGetActionDescriptorRequestHandler<in TInput>
    {
        /// <summary>
        /// When implemented by a type, this method finds an <see cref="ActionDescriptor"/> based on the <paramref name="input"/>
        /// </summary>
        /// <param name="input">The search parameter</param>
        /// <returns>an <see cref="ActionDescriptor"/> that matches the given <paramref name="input"/></returns>
        Task<ActionDescriptor> HandleAsync(TInput input);
    }
}
