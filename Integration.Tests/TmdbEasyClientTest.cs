using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Constants;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TMdbEasy.Integration.Tests
{
    [TestFixture]
    [Category("TmdbEasyClient")]
    public class TmdbEasyClientTest : TestBaseForV3
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetResponseAsync_WithApiKey_ReturnsResult(string reviewId)
        {
            string queryString = $"review/{reviewId}?{QueryConstants.ApiKeyVariable}{GetApiKey()}";

            ITmdbEasyClient client = GetTestV3Client();

            var result = await client.GetResponseAsync<Review>(queryString).ConfigureAwait(false);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public void GetResponseAsync_WithNoApiKey_ThrowsHttpRequestException_With_401Message(string reviewId)
        {
            string queryStringWithNoApiKey = $"review/{reviewId}";

            ITmdbEasyClient clientWithNoApiKey = GetTestV3Client();

            var exception = Assert.ThrowsAsync<HttpRequestException>(() => clientWithNoApiKey.GetResponseAsync<Review>(queryStringWithNoApiKey));

            Assert.IsTrue(exception.Message.Contains("401"));
        }
    }
}
