using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests
{
    [TestFixture]
    public class RequestHandlerTests
    {
        [Test]
        public async Task ExecuteRequest_CallsClient_WithCorrectUri()
        {
            // Arrange
            string expectedURL = "/users";
            string expectedResult = "fakeReturnvalue";
            ITmdbEasyClient subClient = Substitute.For<ITmdbEasyClient>();
            subClient.GetResponseAsync<string>(expectedURL).Returns(expectedResult);

            var options = new TmdbEasyOptions(apiKey: "secret");
            var handlerUnderTest = new RequestHandler(subClient, options);
            Request request = handlerUnderTest.CreateRequest();
            request.AddUrlSegment("users");

            // Act
            var result = await handlerUnderTest.ExecuteAsync<string>(request);

            Assert.AreEqual(expectedResult, result);
            await subClient.Received().GetResponseAsync<string>(expectedURL);
        }
    }
}
