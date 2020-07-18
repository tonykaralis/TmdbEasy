using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TMdbEasy.Integration.Tests
{
    [TestFixture]
    [Category("ReviewApi")]
    public class ReviewApiTest : TestBase
    {
        [TestCase("5488c29bc3a3686f4a00004a")]
        public async Task V3_GetDetailsAsync_ExistingId_ReturnsReview(string id)
        {
            var client = GetTestV3Client();

            var apiKey = GetApiKey();

            IReviewApi serviceUnderTest = new ReviewApi(client);

            Review result = await serviceUnderTest.GetReviewDetailsAsync(id, apiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }
    }
}
