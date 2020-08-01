using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Tests.Integration.TestFixtures;
using TmdbEasy.Interfaces;
using TmdbEasy.Apis;
using TmdbEasy.Configurations;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("TmdbEasyClient")]
    public class TmdbEasyClientTest : TestBase
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetResponseAsync_WithApiKey_ReturnsResult(string reviewId)
        {
            ITmdbEasyClient client = GetTestClient();
            var options = GetDefaultOptions(sharedApiKey: null);

            string queryString = $"review/{reviewId}?api_key={GetApiKey()}";

            var result = await client.GetResponseAsync<Review>(queryString);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public void GetResponseAsync_WithNoApiKey_ThrowsHttpRequestException_With_401Message(string reviewId)
        {
            ITmdbEasyClient clientWithNoApiKey = GetTestClient();
            var options = GetDefaultOptions(sharedApiKey: null);

            string queryStringWithNoApiKey = $"review/{reviewId}";

            var exception = Assert.ThrowsAsync<HttpRequestException>(() => clientWithNoApiKey.GetResponseAsync<Review>(queryStringWithNoApiKey));

            Assert.IsTrue(exception.Message.Contains("401"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void GetResponseAsync_NullOrEmptyQuery_ThrowsArgumentException(string query)
        {
            ITmdbEasyClient client = GetTestClient();

            Assert.ThrowsAsync<ArgumentException>(() => client.GetResponseAsync<Review>(query));
        }
    }
}
