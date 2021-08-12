using Cms.Core.Models;

namespace Cms.Razor.Controllers
{
    /// <summary>
    /// This interface is used internally to identify controllers that map to cms content.
    /// </summary>
    /// <remarks>
    /// <para>Do not implement this interface unless you know what you're doing. It is recommended to inherit from <see cref="CmsControllerBase{TDocument}"/> instead.</para>
    /// </remarks>
    /// <typeparam name="TDocument">The type of the model that this controller can use</typeparam>
    public interface ICmsControllerBase<TDocument>
        where TDocument : class
    {
        /// <summary>
        /// When implemented by a controller, this property will return the document model that the current url maps to.
        /// </summary>
        /// <remarks>
        /// <para>This is the same model that is returned by <see cref="ICmsControllerBase{TDocument}.DocumentInfo"/>, but more explicitly typed.</para>
        /// <para>If the model of this interface doesn't match the actual model or no model was selected in the pipeline, this property returns <see langword="null"/></para>
        /// </remarks>
        IDocumentWrapper<TDocument> Document { get; }

        /// <summary>
        /// When implemented by a controller, this property will return the document model that the current url maps to.
        /// </summary>
        /// <remarks>
        /// <para>This is the same model that is returned by <see cref="ICmsControllerBase{TDocument}.Document"/>, but less explicitly typed.</para>
        /// <para>If no model was selected in the pipeline, this property returns <see langword="null"/></para>
        /// </remarks>
        IDocumentInfo DocumentInfo { get; }
    }
}
