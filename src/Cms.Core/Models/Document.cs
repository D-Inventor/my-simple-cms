/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;

namespace Cms.Core.Models
{
    /// <summary>
    /// Static helper for creating instances of <see cref="IDocument{TModel}"/>
    /// </summary>
    public static class Document
    {
        /// <summary>
        /// Creates a new instance of <see cref="IDocument{TModel}" />
        /// </summary>
        /// <typeparam name="TModel">The model type of this document</typeparam>
        /// <param name="info">The information about this document</param>
        /// <param name="model">The model of this document</param>
        /// <returns>A new instance of <see cref="IDocument{TModel}"/></returns>
        public static IDocument<TModel> Create<TModel>(IDocumentInfo info, TModel model)
            where TModel : class
            => new Document<TModel>(info, model);
    }

    /// <summary>
    /// This class provides the document as a POCO
    /// </summary>
    /// <remarks>
    /// <para><typeparamref name="TModel"/> is always equal to <see cref="IDocumentInfo.ModelType"/> in <see cref="Document{TModel}.Info"/>.</para>
    /// </remarks>
    /// <typeparam name="TModel">The model type</typeparam>
    internal class Document<TModel>
        : IDocument<TModel>
        where TModel : class
    {
        /// <inheritdoc />
        public TModel Model { get; }

        /// <inheritdoc />
        public IDocumentInfo Info { get; }

        internal Document(IDocumentInfo info, TModel model)
        {
            Info = info ?? throw new ArgumentNullException(nameof(info));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            if (!typeof(TModel).Equals(info.ModelType)) throw new ArgumentException("Model type in info is not the same as the actual model type.", nameof(info));
        }
    }
}
