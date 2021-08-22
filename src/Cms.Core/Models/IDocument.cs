/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace Cms.Core.Models
{
    /// <summary>
    /// Any type that implements this interface can provide <see cref="IDocumentInfo"/> about this document.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// When implemented by a type, this property returns an instance of <see cref="IDocumentInfo"/> about this document.
        /// </summary>
        IDocumentInfo Info { get; }
    }

    /// <summary>
    /// Any type that implements this interface can provide <see cref="IDocumentInfo"/> about this document and it's model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model of this document</typeparam>
    public interface IDocument<out TModel>
        : IDocument
        where TModel : class
    {
        /// <summary>
        /// When implemented by a type, this property returns the model of this <see cref="IDocument{TModel}"/>
        /// </summary>
        TModel Model { get; }
    }
}
