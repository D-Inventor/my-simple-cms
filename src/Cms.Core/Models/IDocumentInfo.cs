﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
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
    /// Any type that implements this interface can give information about an <see cref="IDocument{TModel}"/>
    /// </summary>
    public interface IDocumentInfo
    {
        /// <summary>
        /// When implemented by a type, this property returns the <see cref="IDocument{TModel}"/>'s unique identifier
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// When implemented by a type, this property returns the <see cref="IDocument{TModel}"/>'s model type
        /// </summary>
        Type ModelType { get; }
    }
}
