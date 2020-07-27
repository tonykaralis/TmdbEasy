using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Companies;
using TmdbEasy.Integration.Tests.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Integration.Tests.v3
{
    [TestFixture]
    [Category("CompaniesApi")]
    public class CompaniesApiTest : TestBaseForV3
    {
        [TestCase(1)]
        public async Task GetDetailsAsync_ValidId_ReturnsValidResult(int id)
        {
            ICompaniesApi apiUnderTest = new CompaniesApi(_client);

            var request = new IdRequest()
            {
                UserApiKey = _userApiKey,
                Id = id
            };

            CompanyDetails details = await apiUnderTest.GetDetailsAsync(request);

            Assert.IsNotNull(details);
            Assert.AreEqual(id, details.Id);
        }

        [TestCase(1)]
        public async Task GetMoviesAsync_ValidId_ReturnsValidResult(int id)
        {
            ICompaniesApi apiUnderTest = new CompaniesApi(_client);

            var request = new IdRequest()
            {
                UserApiKey = _userApiKey,
                Id = id
            };

            MoviesByCompany details = await apiUnderTest.GetMoviesAsync(request);

            Assert.IsNotNull(details);
            Assert.AreEqual(id, details.Id);
        }
    }
}
