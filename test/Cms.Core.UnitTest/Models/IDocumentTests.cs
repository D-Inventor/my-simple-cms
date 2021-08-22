using Cms.Core.Models;

using NUnit.Framework;

using System;

namespace Cms.Core.UnitTest.Models
{
    public class IDocumentTests
    {
        [Test]
        public void GenericIDocument_CanBeAssignedToDocumentWithModelOfInheritedType()
        {
            // Arrange
            IDocument<string> sourceDocument = Document.Create(DocumentInfo.Create<string>(Guid.NewGuid()), "TestModel");
            IDocument<object> target;

            // Act
            target = sourceDocument;

            // Assert
            Assert.AreSame(sourceDocument, target);
        }
    }
}
