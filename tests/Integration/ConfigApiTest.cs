using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Configuration;
using TmdbEasy.Tests.Integration.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("ConfigApi")]
    public class ConfigApiTest : TestBase
    {
        [Test]
        public async Task GetConfigurationAsync_ReturnsConfiguration()
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            IConfigApi apiUnderTest = new ConfigApi(_requestHandler);

            Configuration configuration = await apiUnderTest.GetConfigurationAsync(_userApiKey);

            Assert.IsNotNull(configuration);
            Assert.IsNotEmpty(configuration.Change_keys);
            Assert.IsNotNull(configuration.Images);
        }

        [Test]
        public async Task GetCountriesAsync_SpecificType_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            IConfigApi serviceUnderTest = new ConfigApi(_requestHandler);

            List<Country> countries = await serviceUnderTest.GetCountriesAsync(_userApiKey);

            Assert.IsNotEmpty(countries);
        }

        [Test]
        public async Task GetJobsAsync_SpecificType_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            IConfigApi serviceUnderTest = new ConfigApi(_requestHandler);

            List<JobsByDepartment> jobs = await serviceUnderTest.GetJobsAsync(_userApiKey);

            Assert.IsNotEmpty(jobs);
            Assert.IsNotEmpty(jobs.First().Jobs);
        }

        [Test]
        public async Task GetLanguagesAsync_SpecificType_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            IConfigApi serviceUnderTest = new ConfigApi(_requestHandler);

            List<Language> languages = await serviceUnderTest.GetLanguagesAsync(_userApiKey);

            Assert.IsNotEmpty(languages);
        }

        [Test]
        public async Task GetTimeZonesAsync_SpecificType_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_clientWithNoApiKey);

            IConfigApi serviceUnderTest = new ConfigApi(_requestHandler);

            List<TimeZones> timeZones = await serviceUnderTest.GetTimeZonesAsync(_userApiKey);

            Assert.IsNotEmpty(timeZones);
            Assert.IsNotEmpty(timeZones.First().Zones);
        }
    }
}
