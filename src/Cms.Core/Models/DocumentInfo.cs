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
    /// This class provides the document info as a POCO.
    /// </summary>
    public class DocumentInfo
        : IDocumentInfo
    {
        /// <inheritdoc />
        public Guid Id { get; }

        /// <inheritdoc />
        public Type ModelType { get; }

        private DocumentInfo(Guid id, Type modelType)
        {
            Id = id;
            ModelType = modelType ?? throw new ArgumentNullException(nameof(modelType));
        }

        /// <summary>
        /// Creates a new instance of <see cref="IDocumentInfo"/>
        /// </summary>
        /// <param name="id">The unique identifier of the document</param>
        /// <param name="modelType">The model type of the document</param>
        /// <returns>A new instance of <see cref="IDocumentInfo"/></returns>
        public static IDocumentInfo Create(Guid id, Type modelType)
            => new DocumentInfo(id, modelType);

        /// <summary>
        /// Creates a new instance of <see cref="IDocumentInfo"/>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Same as: <code>DocumentInfo.Create(id, typeof(TModel))</code>
        /// </para>
        /// </remarks>
        /// <typeparam name="TModel">the model type of the document</typeparam>
        /// <param name="id">The unique identifier of the document</param>
        /// <returns>A new instance of <see cref="IDocumentInfo"/></returns>
        public static IDocumentInfo Create<TModel>(Guid id)
            => Create(id, typeof(TModel));
    }
}
