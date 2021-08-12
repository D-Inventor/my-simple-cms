using Cms.Core.Services;
using Cms.Core.UnitTest.Models;

using Moq;

using NUnit.Framework;

using System;

namespace Cms.Core.UnitTest
{
    public class HighTypeServiceBridgeTests
    {
        private IHighTypeServiceBridge _service;
        private Mock<IServiceProvider> _mockServiceProvider;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockServiceProvider = new Mock<IServiceProvider>(MockBehavior.Strict);
            _service = new HighTypeServiceBridge(_mockServiceProvider.Object);
        }

        [Test]
        public void GetHighlyTypedService_OpenGenericDoesNotImplementLowTypeEquivalent_ThrowsArgumentException()
        {
            // Arrange

            // Act
            void Act() => _service.GetHighlyTypedService<IAnotherTestService>(typeof(IGenericTestService<>), typeof(int));

            // Assert
            Assert.Throws<ArgumentException>(Act);
        }

        [Test]
        public void GetHighlyTypedService_ServiceContainerHasService_ReturnsRequestedService()
        {
            // Arrange
            var testService = new TestService();
            _mockServiceProvider
                .Setup(sp => sp.GetService(It.Is<Type>((type) => type.Equals(typeof(IGenericTestService<int>)))))
                .Returns(testService);

            // Act
            var result = _service.GetHighlyTypedService<ITestService>(typeof(IGenericTestService<>), typeof(int));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(testService, result);
        }

        [Test]
        public void GetHighlyTypedService_ServiceContainerDoesNotHaveService_ReturnsNull()
        {
            // Arrange
            _mockServiceProvider
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(null);

            // Act
            var result = _service.GetHighlyTypedService<ITestService>(typeof(IGenericTestService<>), typeof(int));

            // Assert
            Assert.IsNull(result);
        }
    }
}
