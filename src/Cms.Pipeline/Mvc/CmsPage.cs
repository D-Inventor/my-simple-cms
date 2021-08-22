/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc.Razor;

namespace Cms.Pipeline.Mvc
{
    /// <summary>
    /// Represents properties and methods that are needed in order to render a view that uses <see cref="IDocument{TModel}"/>
    /// </summary>
    /// <typeparam name="TDocModel">The type of the model of the <see cref="IDocument{TModel}"/></typeparam>
    public abstract class CmsPage<TDocModel>
        : RazorPage
        where TDocModel : class
    {
        /// <summary>
        /// The <see cref="IDocument{TModel}"/> associated with the current request
        /// </summary>
        public IDocument<TDocModel> Document => Context.GetCmsDocument<TDocModel>();
    }

    /// <summary>
    /// Represents properties and methods that are needed in order to render a view that uses <see cref="IDocument{TModel}"/>
    /// </summary>
    /// <typeparam name="TDocModel">The type of the model of the <see cref="IDocument{TModel}"/></typeparam>
    public abstract class CmsPage<TDocModel, TModel>
        : RazorPage<TModel>
        where TDocModel : class
    {
        /// <summary>
        /// The <see cref="IDocument{TModel}"/> associated with the current request
        /// </summary>
        public IDocument<TDocModel> Document => Context.GetCmsDocument<TDocModel>();
    }

    /// <summary>
    /// Represents properties and methods that are needed in order to render a view that uses <see cref="IDocument"/>
    /// </summary>
    public abstract class CmsPage
        : RazorPage
    {
        /// <summary>
        /// The <see cref="IDocument"/> associated with the current request
        /// </summary>
        public IDocument Document => Context.GetCmsDocument();
    }
}
