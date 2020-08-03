using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Certifications;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.DTO.Television;
using TmdbEasy.DTO.TV;
using TmdbEasy.Interfaces;
using TmdbEasy.Tests.Integration.TestFixtures;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("TelevisionApi")]
    internal class TelevisionApiTest : TestBase
    {
        [TestCase("1399")]
        public async Task GetDetailsAsync_ValidId_CustomApiKey_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Tv result = await apiUnderTest.GetDetailsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
        }

        [TestCase("1399")]
        public async Task GetContentRatingsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvRatingList result = await apiUnderTest.GetContentRatingsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase("1399")]
        public async Task GetImagesAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Images result = await apiUnderTest.GetImagesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
            Assert.IsNotEmpty(result.Backdrops);
        }

        [TestCase("1399")]
        public async Task GetAlternativeTitlesAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            DTO.Television.AlternativeTitle result = await apiUnderTest.GetAlternativeTitlesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase(1399)]
        public async Task GetChangesAsync_ValidId_ReturnsValidResult(int id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            ChangeList result = await apiUnderTest.GetChangesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
        }

        [TestCase("1399")]
        public async Task GetCreditsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieCredits result = await apiUnderTest.GetCreditsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Cast);
            Assert.IsNotEmpty(result.Crew);
        }

        [TestCase("1399")]
        public async Task GetExternalIdsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieExternalId result = await apiUnderTest.GetExternalIdsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
        }

        [TestCase("1399")]
        public async Task GetVideosAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            VideoList result = await apiUnderTest.GetVideosAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
        }

        [TestCase("1399")]
        public async Task GetTranslationsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TranslationList result = await apiUnderTest.GetTranslationsAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id.ToString());
        }

        [TestCase("1399")]
        public async Task GetRecommendationsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetRecommendationsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase("1399")]
        public async Task GetSimilarTVShowsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetSimilarTVShowsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase("1399")]
        public async Task GetUserReviewsAsync_ValidId_ReturnsValidResult(string id)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            UserReview result = await apiUnderTest.GetUserReviewsAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetLatestAsync_ValidId_ReturnsValidResult()
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Tv result = await apiUnderTest.GetLatestAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.Greater(result.Id, 0);
        }

        [Test]
        public async Task GetTVOnTheAir_ValidId_ReturnsValidResult()
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetTVOnTheAir(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }


        [Test]
        public async Task GetTVAiringToday_ValidId_ReturnsValidResult()
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetTVAiringToday(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetPopularAsync_ValidId_ReturnsValidResult()
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetPopularAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [Test]
        public async Task GetTopRatedAsync_ValidId_ReturnsValidResult()
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.GetTopRatedAsync(apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase(1399,1)]
        public async Task GetSeasonDetailsAsync_ValidId_ReturnsValidResult(int tvId, int seasonNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvSeason result = await apiUnderTest.GetSeasonDetailsAsync(tvId, seasonNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Episodes);
        }

        [TestCase(1399, 1)]
        public async Task GetSeasonCreditsAsync_ValidId_ReturnsValidResult(int tvId, int seasonNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieCredits result = await apiUnderTest.GetSeasonCreditsAsync(tvId, seasonNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Cast);
            Assert.IsNotEmpty(result.Crew);
        }

        [TestCase(1399, 1)]
        public async Task GetSeasonExternalIdsAsync_ValidId_ReturnsValidResult(int tvId, int seasonNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieExternalId result = await apiUnderTest.GetSeasonExternalIdsAsync(tvId, seasonNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(3624, result.Id);
        }

        [TestCase(1399, 1)]
        public async Task GetSeasonImagesAsync_ValidId_ReturnsValidResult(int tvId, int seasonNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Images result = await apiUnderTest.GetSeasonImagesAsync(tvId, seasonNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Posters);
        }

        [TestCase(1399, 1)]
        public async Task GetSeasonVideosAsync_ValidId_ReturnsValidResult(int tvId, int seasonNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            VideoList result = await apiUnderTest.GetSeasonVideosAsync(tvId, seasonNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }

        [TestCase(1399, 1, 2)]
        public async Task GetEpisodeDetailsAsync_ValidId_ReturnsValidResult(int id, int seasonNumber, int episodeNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Episode result = await apiUnderTest.GetEpisodeDetailsAsync(id, seasonNumber, episodeNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(episodeNumber, result.Episode_number);
            Assert.AreEqual(seasonNumber, result.Season_number);
        }

        [TestCase(1399, 1, 2)]
        public async Task GetEpisodeCreditsAsync_ValidId_ReturnsValidResult(int id, int seasonNumber, int episodeNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieCredits result = await apiUnderTest.GetEpisodeCreditsAsync(id, seasonNumber, episodeNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Cast);
            Assert.IsNotEmpty(result.Crew);
        }

        [TestCase(1399, 1, 2)]
        public async Task GetEpisodeExternalIdsAsync_ValidId_ReturnsValidResult(int id, int seasonNumber, int episodeNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            MovieExternalId result = await apiUnderTest.GetEpisodeExternalIdsAsync(id, seasonNumber, episodeNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(63057, result.Id);
        }

        [TestCase(1399, 1, 2)]
        public async Task GetEpisodeImagesAsync_ValidId_ReturnsValidResult(int id, int seasonNumber, int episodeNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            Images result = await apiUnderTest.GetEpisodeImagesAsync(id, seasonNumber, episodeNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Stills);
        }

        [TestCase(1399, 1, 2)]
        public async Task GetEpisodeTranslationsAsync_ValidId_ReturnsValidResult(int id, int seasonNumber, int episodeNumber)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TranslationList result = await apiUnderTest.GetEpisodeTranslationsAsync(id, seasonNumber, episodeNumber, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Translations);
        }

        [TestCase("Game of Thrones")]
        public async Task SearchTVShowsAsync_FamousActor_ReturnResults(string tvShowName)
        {
            ITelevisionApi apiUnderTest = new TelevisionApi(_clientWithNoApiKey);

            TvShowList result = await apiUnderTest.SearchTVShowsAsync(tvShowName, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }
    }
}
