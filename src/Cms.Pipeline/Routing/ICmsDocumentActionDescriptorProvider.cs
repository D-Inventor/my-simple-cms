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

namespace Cms.Pipeline.Routing
{
    /// <summary>
    /// Any type that implements this interface can provide the action descriptor that fits the best with the <see cref="Core.Models.IDocument"/> associated with the current request
    /// </summary>
    public interface ICmsDocumentActionDescriptorProvider
    {
        /// <summary>
        /// When implemented by a type, this method provides an <see cref="ActionDescriptor"/> that fits best with the <see cref="Core.Models.IDocument"/> associated with the current request
        /// </summary>
        /// <returns>an <see cref="ActionDescriptor"/> from the collection</returns>
        Task<ActionDescriptor> GetActionDescriptorAsync();
    }
}
