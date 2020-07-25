using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TMdbEasy.Integration.Tests
{
    [TestFixture]
    [Category("TmdbEasyClient")]
    public class TmdbEasyClientTest : TestBaseForV3
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetResponseAsync_WithUserApiKey_ReturnsResult(string reviewId)
        {           
            string userApiKey = GetApiKey();

            string queryString = $"review/{reviewId}";

            ITmdbEasyClient client = GetTestV3Client();

            var result = await client.GetResponseAsync<Review>(queryString, userApiKey).ConfigureAwait(false);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetResponseAsync_WithSharedApiKey_ReturnsResult(string reviewId)
        {
            string sharedApiKey = GetApiKey();

            string queryString = $"review/{reviewId}";

            ITmdbEasyClient client = GetTestV3Client(sharedApiKey);

            var result = await client.GetResponseAsync<Review>(queryString).ConfigureAwait(false);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public void GetResponseAsync_WithNoApiKey_ThrowsArgumentException(string reviewId)
        {          
            string queryString = $"review/{reviewId}";

            ITmdbEasyClient client = GetTestV3Client();

            Assert.ThrowsAsync<ArgumentException>(()=>client.GetResponseAsync<Review>(queryString));
        }
    }
}
