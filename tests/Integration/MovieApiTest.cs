﻿using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Movies;
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
        public async Task GetImagesAsync_IncorrectId_ThrowsException(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            Images result = await apiUnderTest.GetImagesAsync(id, _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase(550)]
        public async Task GetAlternativetitlesAsync_IncorrectId_ThrowsException(int id)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            AlternativeTitle result = await apiUnderTest.GetAlternativeTitlesAsync(id, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestCase("Brad Pitt")]
        public async Task SearchByActorAsync_FamousActor_ReturnResults(string actorName)
        {
            IMovieApi apiUnderTest = new MovieApi(_clientWithNoApiKey);

            MovieList result = await apiUnderTest.SearchByActorAsync(actorName, apiKey: _userApiKey);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Results);
        }
    }
}
