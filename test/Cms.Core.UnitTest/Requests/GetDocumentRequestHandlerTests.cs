using Cms.Core.Factories;
using Cms.Core.Models;
using Cms.Core.Providers;
using Cms.Core.Requests;

using Moq;

using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace Cms.Core.UnitTest.Requests
{
    public class GetDocumentRequestHandlerTests
    {
        private GetDocumentRequestHandler<string> _requestHandler;
        private Mock<IGetDocumentInfoRequestHandler<string>> _documentInfoRequestHandler;
        private Mock<IDocumentProviderFactory> _documentProviderFactory;
        private Mock<IDocumentProvider> _documentProvider;
        private string _parameter;
        private IDocumentInfo _info;
        private IDocument _document;

        [SetUp]
        public void Setup()
        {
            _documentInfoRequestHandler = new Mock<IGetDocumentInfoRequestHandler<string>>(MockBehavior.Strict);
            _documentProviderFactory = new Mock<IDocumentProviderFactory>(MockBehavior.Strict);
            _documentProvider = new Mock<IDocumentProvider>(MockBehavior.Strict);
            _requestHandler = new GetDocumentRequestHandler<string>(_documentInfoRequestHandler.Object,
                                                                    _documentProviderFactory.Object);

            _parameter = TestContext.CurrentContext.Random.GetString();
            _info = DocumentInfo.Create<string>(TestContext.CurrentContext.Random.NextGuid());
            _document = Document.Create(_info, _parameter);
        }

        [Test]
        public async Task HandleAsync_NormalFlow_ReturnsDocument()
        {
            // arrange
            _documentInfoRequestHandler.Setup(obj => obj.HandleAsync(It.Is<string>(input => input.Equals(_parameter)))).ReturnsAsync(_info).Verifiable();
            _documentProviderFactory.Setup(obj => obj.Create(It.Is<IDocumentInfo>(input => input.Equals(_info)))).Returns(_documentProvider.Object).Verifiable();
            _documentProvider.Setup(obj => obj.GetDocumentAsync(It.Is<IDocumentInfo>(input => input.Equals(_info)))).ReturnsAsync(_document).Verifiable();

            // act
            var result = await _requestHandler.HandleAsync(_parameter);

            // assert
            _documentInfoRequestHandler.Verify();
            _documentInfoRequestHandler.VerifyNoOtherCalls();
            _documentProviderFactory.Verify();
            _documentProviderFactory.VerifyNoOtherCalls();
            _documentProvider.Verify();
            _documentProvider.VerifyNoOtherCalls();
            Assert.AreSame(_document, result);
        }

        [Test]
        public async Task HandleAsync_DocumentInfoRequestHandlerReturnsNull_ReturnsNull()
        {
            // arrange
            _documentInfoRequestHandler.Setup(obj => obj.HandleAsync(It.Is<string>(input => input.Equals(_parameter)))).ReturnsAsync(() => null).Verifiable();

            // act
            var result = await _requestHandler.HandleAsync(_parameter);

            // assert
            _documentInfoRequestHandler.Verify();
            _documentInfoRequestHandler.VerifyNoOtherCalls();
            Assert.IsNull(result);
        }

        [Test]
        public void HandleAsync_ArgumentNull_ThrowsArgumentNullException()
        {
            // arrange

            // act
            Task<IDocument> result() => _requestHandler.HandleAsync(null);

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(result);
        }
    }
}
