/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Cms.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace Cms.Pipeline.Mvc
{
    /// <summary>
    /// Base class for all controllers that are routed by <see cref="IDocument{TModel}"/>
    /// </summary>
    /// <typeparam name="TModel">The type of the model of this request's <see cref="IDocument{TModel}"/></typeparam>
    public abstract class CmsDocumentController<TModel>
        : Controller, ICmsDocumentController<TModel>
        where TModel : class
    {
        /// <summary>
        /// The <see cref="IDocument{TModel}"/> that is associated with the current request
        /// </summary>
        public IDocument<TModel> Document
            => HttpContext.GetCmsDocument<TModel>();

        /// <summary>
        /// Creates a <see cref="ViewResult"/> object by specifying a <paramref name="model"/>.
        /// </summary>
        /// <remarks>
        /// <para>The view name is determined by the type of <typeparamref name="TModel"/>. The base folder is /Views/Documents</para>
        /// </remarks>
        /// <param name="model">The model that is rendered by the view</param>
        /// <returns>The created <see cref="ViewResult"/> for the response</returns>
        public IActionResult DocumentView(object model)
        {
            return View(GetViewName(), model);
        }

        /// <summary>
        /// Creates a <see cref="ViewResult"/> object.
        /// </summary>
        /// <remarks>
        /// <para>The view name is determined by the type of <typeparamref name="TModel"/>. The base folder is /Views/Documents</para>
        /// </remarks>
        /// <returns>The created <see cref="ViewResult"/> for the response</returns>
        public IActionResult DocumentView()
        {
            return View(GetViewName());
        }

        /// <summary>
        /// Gets the path to the view file that should be rendered by this controller
        /// </summary>
        /// <returns>The path to the view file</returns>
        protected virtual string GetViewName()
        {
            return $"/Views/Documents/{typeof(TModel).Name}.cshtml";
        }
    }
}
