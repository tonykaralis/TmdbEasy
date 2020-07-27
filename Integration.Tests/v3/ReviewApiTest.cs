using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.v3
{
    [TestFixture]
    [Category("ReviewApi")]
    public class ReviewApiTest : TestBaseForV3
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithUserApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            ITmdbEasyClient client = GetTestV3Client();

            string userApiKey = GetApiKey();

            IReviewApi serviceUnderTest = new ReviewApi(client);

            Review result = await serviceUnderTest.GetReviewDetailsAsync(new ReviewRequest() { Id = reviewId, UserApiKey = userApiKey });

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }

        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task GetDetailsAsync_WithSharedApiKey_ExistingId_ReturnsReview(string reviewId)
        {
            string sharedApiKey = GetApiKey();

            ITmdbEasyClient client = GetTestV3Client(sharedApiKey);

            IReviewApi serviceUnderTest = new ReviewApi(client);

            Review result = await serviceUnderTest.GetReviewDetailsAsync(new ReviewRequest() { Id = reviewId });

            Assert.IsNotNull(result);
            Assert.AreEqual(reviewId, result.Id);
        }
    }
}
