/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace Cms.Pipeline.Mvc
{
    /// <summary>
    /// When implemented by a controller, this interface marks the controller for <see cref="Core.Models.IDocument{TModel}"/> based routing
    /// </summary>
    /// <typeparam name="TModel">The type of the model of this request's <see cref="Core.Models.IDocument{TModel}"/></typeparam>
    public interface ICmsDocumentController<out TModel>
        where TModel : class
    { }
}
