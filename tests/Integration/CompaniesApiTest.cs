using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Companies;
using TmdbEasy.Tests.Integration.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("CompaniesApi")]
    public class CompaniesApiTest : TestBaseForV3
    {
        [TestCase(1)]
        public async Task GetDetailsAsync_ValidId_ReturnsValidResult(int id)
        {
            var _requestHandler = new RequestHandler(_client);

            ICompaniesApi apiUnderTest = new CompaniesApi(_requestHandler);

            CompanyDetails details = await apiUnderTest.GetDetailsAsync(id, _userApiKey);

            Assert.IsNotNull(details);
            Assert.AreEqual(id, details.Id);
        }

        [TestCase(1)]
        public async Task GetMoviesAsync_ValidId_ReturnsValidResult(int id)
        {
            var _requestHandler = new RequestHandler(_client);

            ICompaniesApi apiUnderTest = new CompaniesApi(_requestHandler);

            MoviesByCompany details = await apiUnderTest.GetMoviesAsync(id, _userApiKey);

            Assert.IsNotNull(details);
            Assert.AreEqual(id, details.Id);
        }
    }
}
