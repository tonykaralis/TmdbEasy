using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class RequestHandlerTests
    {
        private readonly ITmdbEasyClient _subClient;

        public RequestHandlerTests()
        {
            _subClient = Substitute.For<ITmdbEasyClient>();
        }

        [Test]
        public void CreateRequest_CreatesValidRequest_SetsBaseUrl()
        {
            string testBaseUrl = "https://baseurl";

            _subClient.GetBaseUrl().Returns(testBaseUrl);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest();
            
            string result = request.GetUri();

            Assert.AreEqual(testBaseUrl, result);
        }

        [Test]
        public async Task ExecuteRequest_CallsClient_WithCorrectUri()
        {
            string testBaseUrl = "https://baseurl";

            string expectedResult = "fakeReturnvalue";

            _subClient.GetBaseUrl().Returns(testBaseUrl);
            _subClient.GetResponseAsync<string>(testBaseUrl).Returns(expectedResult);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest();

            var result = await handlerUnderTest.ExecuteRequestAsync<string>(request);

            Assert.AreEqual(expectedResult, result);

            await _subClient.Received().GetResponseAsync<string>(testBaseUrl);
        }
    }
}
