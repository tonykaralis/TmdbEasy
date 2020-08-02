using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Tests.Integration.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("ReviewApi")]
    public class ReviewApiTest : TestBase
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithUserApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            string userApiKey = GetApiKey();

            IReviewApi apiUnderTest = new ReviewApi(_clientWithNoApiKey);

            Review result = await apiUnderTest.GetReviewDetailsAsync(reviewId, userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithSharedApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            string sharedApiKey = GetApiKey();

            ITmdbEasyClient client = GetTestClient(sharedApiKey);

            IReviewApi apiUnderTest = new ReviewApi(client);

            Review result = await apiUnderTest.GetReviewDetailsAsync(reviewId);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }
    }
}
