using System;
using NUnit.Framework;
using TmdbEasy.Configurations;

namespace TmdbEasy.Tests.Unit
{
    [TestFixture]
    public class RequestHandlerTests
    {
        [Test]
        public void Constructor_WithNullClient_ShouldThrowArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RequestHandler(null));
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null. (Parameter 'client')"));
        }

        [Test]
        public void CreateRequest_CreatesValidRequest()
        {
            var handlerUnderTest = new RequestHandler(new TmdbEasyClient(new TmdbEasyOptions("apiKey")));

            Request request = handlerUnderTest.CreateRequest();

            Assert.IsNotNull(request);
        }
    }
}
