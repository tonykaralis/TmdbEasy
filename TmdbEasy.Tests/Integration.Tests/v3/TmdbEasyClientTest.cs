using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Tests.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration.Tests.v3
{
    [TestFixture]
    [Category("TmdbEasyClient")]
    public class TmdbEasyClientTest : TestBaseForV3
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetResponseAsync_WithApiKey_ReturnsResult(string reviewId)
        {           
            ITmdbEasyClient client = GetTestV3Client();

            string queryString = $"{client.GetBaseUrl()}/review/{reviewId}?api_key={GetApiKey()}";

            var result = await client.GetResponseAsync<Review>(queryString);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }
        
        [TestCase("5488c29bc3a3686f4a00004a")]
        public void GetResponseAsync_WithNoApiKey_ThrowsHttpRequestException_With_401Message(string reviewId)
        {
            ITmdbEasyClient clientWithNoApiKey = GetTestV3Client();

            string queryStringWithNoApiKey = $"{clientWithNoApiKey.GetBaseUrl()}/review/{reviewId}";            

            var exception = Assert.ThrowsAsync<HttpRequestException>(() => clientWithNoApiKey.GetResponseAsync<Review>(queryStringWithNoApiKey));

            Assert.IsTrue(exception.Message.Contains("401"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void GetResponseAsync_NullOrEmptyQuery_ThrowsArgumentException(string query)
        {
            ITmdbEasyClient client = GetTestV3Client();

            Assert.ThrowsAsync<ArgumentException>(() => client.GetResponseAsync<Review>(query));
        }
    }
}
