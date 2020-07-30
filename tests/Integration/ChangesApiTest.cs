using NUnit.Framework;
using System.Threading.Tasks;
using TmdbEasy.Apis;
using TmdbEasy.DTO.Changes;
using TmdbEasy.Enums;
using TmdbEasy.Tests.Integration.TestFixtures;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Tests.Integration
{
    [TestFixture]
    [Category("ChangesApi")]
    public class ChangesApiTest : TestBaseForV3
    {
        [Test]
        public async Task GetChangeListAsync_SpecificDateRange_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_client);

            IChangesApi apiUnderTest = new ChangesApi(_requestHandler);

            ChangeList changeList = await apiUnderTest.GetChangeListAsync(ChangeType.Movie, "26/07/2020", "25/07/2020", 1, _userApiKey);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }

        [Test]
        public async Task GetChangeListAsync_SpecificType_ReturnsChangeList()
        {
            var _requestHandler = new RequestHandler(_client);

            IChangesApi apiUnderTest = new ChangesApi(_requestHandler);

            ChangeList changeList = await apiUnderTest.GetChangeListAsync(ChangeType.TV, "26/07/2020", "25/07/2020", 1, _userApiKey);

            Assert.IsNotNull(changeList);
            Assert.IsNotEmpty(changeList.Results);
        }
    }
}
