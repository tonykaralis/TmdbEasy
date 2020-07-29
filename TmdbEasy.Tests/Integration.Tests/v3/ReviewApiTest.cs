using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Tests.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration.Tests.v3
{
    [TestFixture]
    [Category("ReviewApi")]
    public class ReviewApiTest : TestBaseForV3
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithUserApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            var options = GetDefaultOptions(GetApiKey());
            var _requestHandler = new RequestHandler(_client, options);

            string userApiKey = GetApiKey();

            IReviewApi apiUnderTest = new ReviewApi(_requestHandler);

            Review result = await apiUnderTest.GetReviewDetailsAsync(reviewId, userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithSharedApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            string sharedApiKey = GetApiKey();

            ITmdbEasyClient client = GetTestV3Client(sharedApiKey);

            var options = GetDefaultOptions(sharedApiKey);
            var _requestHandler = new RequestHandler(_client, options);

            IReviewApi apiUnderTest = new ReviewApi(_requestHandler);

            Review result = await apiUnderTest.GetReviewDetailsAsync(reviewId);

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }
    }
}
