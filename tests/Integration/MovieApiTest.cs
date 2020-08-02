using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Interfaces;
using TmdbEasy.Tests.Integration.TestFixtures;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("MovieApi")]
    internal class MovieApiTest : TestBase
    {
        [TestCase(505)]
        public async Task GetDetailsAsync_ValidId_CustomApiKey_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieFullDetails result = await apiUnderTest.GetDetailsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetImagesAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            Images result = await apiUnderTest.GetImagesAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetAlternativetitlesAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            AlternativeTitle result = await apiUnderTest.GetAlternativeTitlesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.IsNotEmpty(result.Titles);
        }

        [TestCase(550)]
        public async Task GetChangesAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieChangeList result = await apiUnderTest.GetChangesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
        }

        [TestCase(550)]
        public async Task GetCreditsAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieCredits result = await apiUnderTest.GetCreditsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Cast);
            Assert.IsNotEmpty(result.Crew);
        }

        [TestCase(550)]
        public async Task GetExternalIdsAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieExternalId result = await apiUnderTest.GetExternalIdsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetReleaseDatesAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieReleaseDateList result = await apiUnderTest.GetReleaseDatesAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetVideosAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            VideoList result = await apiUnderTest.GetVideosAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetTranslationsAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            TranslationList result = await apiUnderTest.GetTranslationsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetRecommendationsAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.GetRecommendationsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase(550)]
        public async Task GetSimilarMoviesAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.GetSimilarMoviesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase(550)]
        public async Task GetUserReviewsAsync_ValidId_ReturnsValidResult(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            UserReview result = await apiUnderTest.GetUserReviewsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetLatestAsync_ValidId_ReturnsValidResult()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieFullDetails result = await apiUnderTest.GetLatestAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.Greater(result.Id, 0);
        }

        [Test]
        public async Task GetNowPlayingAsync_ValidId_ReturnsValidResult()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            DatedMovieList result = await apiUnderTest.GetNowPlayingAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetPopularAsync_ValidId_ReturnsValidResult()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.GetPopularAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetTopRatedAsync_ValidId_ReturnsValidResult()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.GetTopRatedAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetUpcomingAsync_ValidId_ReturnsValidResult()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            DatedMovieList result = await apiUnderTest.GetUpcomingAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase("Brad Pitt")]
        public async Task SearchByActorAsync_FamousActor_ReturnResults(string actorName)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.SearchByActorAsync(actorName, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task SearchMoviesAsync_VariousParameters_ReturnResults()
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.SearchByActorAsync("bond", "en", 2, true, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }
    }
}
