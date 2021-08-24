using Cms.Core.Models;
using Cms.Pipeline.Matching;
using Cms.Pipeline.Requests;

using Microsoft.AspNetCore.Http;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Pipeline.UnitTest.Requests
{
    public class DocumentInfoByContextHandlerTests
    {
        private DocumentInfoByContextHandler _requestHandler;
        private List<Mock<IDocumentInfoMatcher>> _matchers;
        private HttpContext _context;
        private IDocumentInfo _documentInfo;

        [SetUp]
        public void Setup()
        {
            _matchers = new List<Mock<IDocumentInfoMatcher>>();
            var matcherCount = TestContext.CurrentContext.Random.Next(1, 5);
            _matchers = Enumerable.Range(0, matcherCount).Select(i => new Mock<IDocumentInfoMatcher>()).ToList();
            _requestHandler = new DocumentInfoByContextHandler(_matchers.Select(m => m.Object).ToList());
            _context = new DefaultHttpContext();
            _documentInfo = DocumentInfo.Create<string>(TestContext.CurrentContext.Random.NextGuid());
        }

        [Test, Repeat(10)]
        public async Task HandleAsync_NormalFlow_ReturnsDocumentInfo()
        {
            // arrange
            int resultAt = TestContext.CurrentContext.Random.Next(_matchers.Count - 1);
            for (int index = 0; index < resultAt; index++)
            {
                _matchers[index].Setup(obj => obj.Match(It.Is<HttpContext>(input => input.Equals(_context)))).ReturnsAsync(() => null).Verifiable();
            }
            _matchers[resultAt].Setup(obj => obj.Match(It.Is<HttpContext>(input => input.Equals(_context)))).ReturnsAsync(_documentInfo).Verifiable();

            // act
            var result = await _requestHandler.HandleAsync(_context);

            // assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(_documentInfo));
            for (int index = 0; index < resultAt + 1; index++)
            {
                _matchers[index].Verify();
                _matchers[index].VerifyNoOtherCalls();
            }
        }

        [Test, Repeat(3)]
        public async Task HandleAsync_NoMatches_ReturnsNull()
        {
            // arrange
            foreach(var matcher in _matchers)
            {
                matcher.Setup(obj => obj.Match(It.Is<HttpContext>(input => input.Equals(_context)))).ReturnsAsync(() => null).Verifiable();
            }

            // act
            var result = await _requestHandler.HandleAsync(_context);

            // assert
            Assert.IsNull(result);
            foreach (var matcher in _matchers)
            {
                matcher.Verify();
                matcher.VerifyNoOtherCalls();
            }
        }

        [Test]
        public void HandleAsync_HttpContextNull_ThrowArgumentNullException()
        {
            // arrange

            // act
            Task<IDocumentInfo> result() => _requestHandler.HandleAsync(null);

            // assert
            Assert.ThrowsAsync<ArgumentNullException>(result);
        }
    }
}
