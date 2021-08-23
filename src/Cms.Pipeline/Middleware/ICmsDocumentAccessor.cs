/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

namespace Cms.Pipeline.Middleware
{
    /// <summary>
    /// Any type that implements this interface can provide access to the <see cref="IDocument" /> associated with the current request
    /// </summary>
    /// <remarks>
    /// <para>Types that implement this interface should not be consumed outside of a request.</para>
    /// <para>Types that implement this interface should be registered as scoped.</para>
    /// </remarks>
    public interface ICmsDocumentAccessor
    {
        /// <summary>
        /// When implemented by a type, this property returns the <see cref="IDocument" /> associated with the current request
        /// </summary>
        IDocument Document { get; }
    }

    /// <summary>
    /// Any type that implements this interface can provide access to the <see cref="IDocument{TModel}" /> associated with the current request
    /// </summary>
    /// <typeparam name="TModel">The type of the model of the instance of <see cref="IDocument{TModel}" /></typeparam>
    /// <remarks>
    /// <para>Types that implement this interface should not be consumed outside of a request.</para>
    /// <para>Types that implement this interface should be registered as scoped.</para>
    /// </remarks>
    public interface ICmsDocumentAccessor<out TModel>
        where TModel : class
    {
        /// <summary>
        /// When implemented by a type, this property returns the <see cref="IDocument{TModel}" /> associated with the current request
        /// </summary>
        IDocument<TModel> Document { get; }
    }
}