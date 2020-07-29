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
        public void AddApiKey_GlobalApiKeySet_UserApiKeyUsed_SetsUserApiKey()
        {
            string globalApiKey = "globalApikey";
            string userApiKey = "userApikey";
            string testBasUrl = "https://baseurl";

            _subClient.GetApiKey().Returns(globalApiKey);
            _subClient.GetBaseUrl().Returns(testBasUrl);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest()
                .AddApiKey(userApiKey);

            string result = request.GetUri();

            Assert.IsTrue(result.Contains($"?api_key={userApiKey}"));
        }

        [Test]
        public void AddApiKey_GlobalApiKeySet_NoUserApiKeyProvided_SetsGlobalApiKey()
        {
            string globalApiKey = "globalApikey";
            string testBasUrl = "https://baseurl";

            _subClient.GetApiKey().Returns(globalApiKey);
            _subClient.GetBaseUrl().Returns(testBasUrl);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest()
                .AddApiKey();

            string result = request.GetUri();

            Assert.IsTrue(result.Contains($"?api_key={globalApiKey}"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_LocalLanguageUsed_SetsLocalLanguage()
        {
            string defaultLanguage = "defaultLanguage";
            string localLanguage = "localLanguage";
            string testBasUrl = "https://baseurl";

            _subClient.GetBaseUrl().Returns(testBasUrl);
            _subClient.GetDefaultLanguage().Returns(defaultLanguage);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest()
                .AddLanguage(localLanguage);

            string result = request.GetUri();

            Assert.IsTrue(result.Contains($"?language={localLanguage}"));
        }

        [Test]
        public void AddLanguage_DefaultLanguageSet_NoLocalLanguageUsed_SetsDefaultLanguage()
        {
            string defaultLanguage = "defaultLanguage";
            string testBasUrl = "https://baseurl";

            _subClient.GetDefaultLanguage().Returns(defaultLanguage);
            _subClient.GetBaseUrl().Returns(testBasUrl);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest()
                .AddLanguage();

            string result = request.GetUri();

            Assert.IsTrue(result.Contains($"?language={defaultLanguage}"));
        }

        [Test]
        public async Task ExecuteRequest_CallsClient_WithCorrectUri()
        {
            string defaultLanguage = "defaultLanguage";
            string testBaseUrl = "https://baseurl";

            string expectedQuery = $"{testBaseUrl}?language={defaultLanguage}";
            string expectedResult = "fakeReturnvalue";

            _subClient.GetBaseUrl().Returns(testBaseUrl);
            _subClient.GetResponseAsync<string>(expectedQuery).Returns(expectedResult);

            var handlerUnderTest = new RequestHandler(_subClient);

            Request request = handlerUnderTest.CreateRequest().AddLanguage();

            var result = await handlerUnderTest.ExecuteRequestAsync<string>(request);

            Assert.AreEqual(expectedResult, result);

            await _subClient.Received().GetResponseAsync<string>(expectedQuery);
        }
    }
}
